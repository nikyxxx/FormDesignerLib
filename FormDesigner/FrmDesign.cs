using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using D1Lib;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Collections;
using DNA.PropertyClass;

namespace DNA
{
    public partial class FrmDesign : Form
    {
        #region "Parameters"
        string connString;
        string connection;
        const int DESIGN_HEIGHT = 600;
        const int DESIGN_WIDTH=800;
        const string TabControlName = "TabControl";
        Dictionary<string, int> BillType;
        Dictionary<string, string> ControlMap;
        DesignSurface designSurface; 
        IDesignerHost formDesignerHost;
        #endregion

        public FrmDesign()
        {
            InitializeComponent(); 
            InitializeDesignerSurface();
            InitializeListBox();
            initializeDesignForm();
            InitConnectionString();
            InitBillType();

            System.Threading.Thread.Sleep(1000);
            initializeproperty();

        }

        private void InitializeDesignerSurface()         
    {            
        this.designSurface = new System.ComponentModel.Design.DesignSurface(typeof(Form));        
        Control view =  this.designSurface.View as Control;           
        this.tableLayoutPanel1.Controls.Add(view, 0, 0);   
        this.tableLayoutPanel1.SetRowSpan(view, 2);            
        view.Dock = DockStyle.Fill;           
        this.formDesignerHost = this.designSurface.GetService(typeof(IDesignerHost)) as IDesignerHost;  
        this.formDesignerHost.AddService(typeof(INameCreationService), new MyNameService());      
        ISelectionService selectionService = this.formDesignerHost.GetService(typeof(ISelectionService)) as ISelectionService;         
        selectionService.SelectionChanged += delegate          
        {                
            System.Collections.ICollection collection = selectionService.GetSelectedComponents();   
            object[] selectedObjects = new object[collection.Count];   
            collection.CopyTo(selectedObjects, 0);  
            this.propertyGrid1.SelectedObjects = selectedObjects;
        };         
    }          

        private void InitializeListBox() 
        {           
            this.listBox1.DisplayMember = "Name";   
            this.listBox1.DataSource = new Type[]        
            {               
                //typeof(Label), typeof(Button), typeof(TextBox), typeof(RadioButton),typeof(CheckBox),  
                typeof(CheckBox),typeof(D1TextBox),typeof(D1DateTime),typeof(C1.Win.C1FlexGrid.C1FlexGrid),typeof(TabControl)
            };            
            this.listBox1.DoubleClick += delegate   
            {               
                CreateControl(this.listBox1.SelectedItem as Type); 
            }; 
        }

        private void initializeproperty()
        {
            //this.propertyGrid1.SelectedObject = this.formDesignerHost.RootComponent;
            this.propertyGrid1.SelectedObject = null;
        }

        private void initializeDesignForm()
        {
            Control form = this.formDesignerHost.RootComponent as Control;
            form.Height = DESIGN_HEIGHT;
            form.Width = DESIGN_WIDTH;
        }

        private void InitConnectionString()
        {
            this.connString = System.Configuration.ConfigurationManager.ConnectionStrings["connString"].ToString();
        }

        private void InitBillType()
        {

            ControlMap = new Dictionary<string, string>();
            BillType = new Dictionary<string, int>();
            this.BillList.Items.Clear();

            DataTable dt = new DataTable();
            string myCommandText = "select fid as FBillID,fnote as FBillName from t_sgl_billtable order by fid";
            dt = DBUtility.SqlHelper.ExecuteDataset(connString, myCommandText).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BillType.Add(dt.Rows[i]["FBillName"].ToString(), (int)dt.Rows[i]["FBillID"]);
                this.BillList.Items.Add(dt.Rows[i]["FBillName"].ToString());
            }

        }

        private void CreateControl(Type controlType)    
        {          
            if (typeof(Control).IsAssignableFrom(controlType) && !typeof(Form).IsAssignableFrom(controlType))     
            {               
                Control control = this.formDesignerHost.CreateComponent(controlType) as Control;         
                control.Text = control.Name;     
                control.Location = new Point(5, System.Environment.TickCount % 200);  
                (this.formDesignerHost.RootComponent as Form).Controls.Add(control); 
            }        
        }        

        private void btnLock_Click(object sender, EventArgs e)     
        {            
            foreach (IComponent component in this.propertyGrid1.SelectedObjects)     
            {               
                PropertyDescriptor lockedProperty = TypeDescriptor.GetProperties(component)["Locked"]; 
                if (lockedProperty != null)             
                {               
                    lockedProperty.SetValue(component, true);                  
                    this.propertyGrid1.Refresh();           
                }          
            }         
        }          

        private void btnCopy_Click(object sender, EventArgs e) 
        {            
            Control control = this.propertyGrid1.SelectedObject as Control;      
            if (control != null) CreateControl(control.GetType());   
        }       

        private void btnDelete_Click(object sender, EventArgs e)  
        {          
            foreach (IComponent component in this.propertyGrid1.SelectedObjects) 
            {            
                if (component is Form == false && !IsLocked(component))   
                {                   
                    this.formDesignerHost.DestroyComponent(component);
                    initializeproperty();
                }      
            }         
        }          

        private void btnBringforward_Click(object sender, EventArgs e)
        {          
            Control control = this.propertyGrid1.SelectedObject as Control;    
            if (control != null && !IsLocked(control) ) control.BringToFront();  
        }           

        private bool IsLocked(IComponent component)     
        {            
            PropertyDescriptor lockedProperty = TypeDescriptor.GetProperties(component)["Locked"];   
            if (lockedProperty != null) return (bool)lockedProperty.GetValue(component);         
            return false;        
        }

        private void LoadData(int _trantype)
        {
            CreateView(_trantype);
        }

        public void CreateView(int _trantype)
        {
 
            (this.formDesignerHost.RootComponent as Form).Controls.Clear();

            #region "InitLab"
            DataTable dtTabLocation = new DataTable();
            string myCommandText = "select * from t_cs_ICBillTabPage where fid=" + _trantype.ToString();
            dtTabLocation = DBUtility.SqlHelper.ExecuteDataset(connString, myCommandText).Tables[0];

            DataTable dtTabEntry = new DataTable();
            myCommandText = "select * from t_cs_ICBillTabPageEntry where fid=" + _trantype.ToString() + " order by FTabID";
            dtTabEntry = DBUtility.SqlHelper.ExecuteDataset(connString, myCommandText).Tables[0];
          
            LoadTab(dtTabLocation, dtTabEntry);
            #endregion

            #region "InitMain"
            DataTable dt = new DataTable();
            myCommandText = "select * from t_sgl_ictemplate where  FVisForBillType=1 and fid=" + _trantype.ToString();
            dt = DBUtility.SqlHelper.ExecuteDataset(connString, myCommandText).Tables[0];
          
            ControlMap.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LoadControl(dt.Rows[i]);
                ControlMap.Add(dt.Rows[i]["FFieldName"].ToString(), dt.Rows[i]["FFieldName"].ToString());
            }
            #endregion

            #region "InitEntry"
            dt = new DataTable();
            myCommandText = "select * from t_sgl_icentry where fid=" + _trantype.ToString();
            dt = DBUtility.SqlHelper.ExecuteDataset(connString, myCommandText).Tables[0];
          
            if (dt.Rows.Count > 0)
            {
                LoadEntry(dt.Rows[0]);
            }
            #endregion

        }

        private void LoadTab(DataTable _dtTabLocation, DataTable _dtTabEntry)
        {
            TabControl tabMain;
            
            if (_dtTabLocation.Rows.Count > 0)
            {
                if ((this.formDesignerHost.RootComponent as Form).Controls.Find(TabControlName, true).Length > 0)
                {
                    tabMain = ((this.formDesignerHost.RootComponent as Form).Controls.Find(TabControlName, true)[0] as TabControl);
                    //tc.TabPages.Add(_tabName, _tabName);
                }
                else
                {
                    Type controlType = typeof(TabControl);
                    tabMain = this.formDesignerHost.CreateComponent(controlType) as TabControl;
                    tabMain.Name = TabControlName;
                    tabMain.Text = TabControlName;
                    //tabMain.Location = new Point(5, System.Environment.TickCount % 200);
                    (this.formDesignerHost.RootComponent as Form).Controls.Add(tabMain);
                    //(control as TabControl).TabPages.Add(_tabName, _tabName);
                }

                tabMain.Left = int.Parse(_dtTabLocation.Rows[0]["FLeft"].ToString());
                tabMain.Width = int.Parse(_dtTabLocation.Rows[0]["FWidth"].ToString());
                tabMain.Top = int.Parse(_dtTabLocation.Rows[0]["FTop"].ToString());
                tabMain.Height = int.Parse(_dtTabLocation.Rows[0]["FHeight"].ToString());
                tabMain.BringToFront(); //置前

                foreach (DataRow item in _dtTabEntry.Rows)
                {
                    tabMain.TabPages.Add(item["FTabName"].ToString(), item["FTabName"].ToString());
                }
            }
        }

        private void LoadEntry(DataRow dr)
        {
            //int _Top;
            //int _Left;
            //int _Height;
            //int _Width;
            Control cl;

            cl = this.formDesignerHost.CreateComponent(typeof(C1.Win.C1FlexGrid.C1FlexGrid)) as Control;
            cl.Name = "C1FlexGrid1";
            cl.Top = (int)dr["FTop"];
            cl.Left = (int)dr["FLeft"];
            cl.Width = (int)dr["FWidth"];
            cl.Height = (int)dr["FHeight"];
            ((Control)this.formDesignerHost.RootComponent).Controls.Add(cl);
        }

        public void LoadControl(DataRow dr)
        {
            //int _Top;
            //int _Left;
            //int _Height;
            //int _Width;
            Control cl;

            //switch (dr["FTableIndex"])
            //{
            //    case 0:
            //        cl = new Label();

            //    default:

            //}
            if ((int)dr["FTabIndex"] == 0)
            {
                //cl = new Label();
                cl = this.formDesignerHost.CreateComponent(typeof(Label)) as Control;
                cl.Text = dr["FCaption"].ToString();
            }
            else
            {
                if (dr["FCtlType"].ToString() == "4")
                {
                    //cl = new D1DateTime();
                    cl = this.formDesignerHost.CreateComponent(typeof(D1DateTime)) as Control;
                    ((D1DateTime)cl).LabelName = dr["FCaption"].ToString();
                }
                else if (dr["FCtlType"].ToString() == "5")
                {
                    cl = this.formDesignerHost.CreateComponent(typeof(CheckBox)) as Control;
                    cl.Text = dr["FCaption"].ToString();
                }
                else
                {
                    //cl = new D1TextBox();
                    cl = this.formDesignerHost.CreateComponent(typeof(D1TextBox)) as Control;
                    ((D1TextBox)cl).LabelName = dr["FCaption"].ToString();
                }
            }
            cl.Name = dr["FFieldName"].ToString();
            cl.Top = (int)dr["FTop"];
            cl.Left = (int)dr["FLeft"];
            cl.Width = (int)dr["FWidth"];
            cl.Height = (int)dr["FHeight"];

            if (dr["FTabName"].ToString() != "")
            {
                ((this.formDesignerHost.RootComponent as Form).Controls.Find(dr["FTabName"].ToString(), true)[0] as TabPage).Controls.Add(cl);
            }
            else
            {
                ((Control)this.formDesignerHost.RootComponent).Controls.Add(cl);
            }
        }

        private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string key = this.BillList.SelectedItem.ToString();
            if (key == "") return;
            int _trantype;
            _trantype = BillType[this.BillList.SelectedItem.ToString()];
            LoadData(_trantype);
        }

        private void SaveData(int _trantype)
        {
            AddTab(_trantype); //页签信息保存

            string myCommandText = "";
            Control ctl;
            string _TabName = "";
            foreach (KeyValuePair<string, string> cm in ControlMap)
            {
                _TabName = "";
                ctl = (this.formDesignerHost.RootComponent as Form).Controls.Find(cm.Key.ToString(), true)[0];
                if (ctl.Parent.GetType() == typeof(TabPage))
                {
                    _TabName = ctl.Parent.Name;
                }
                myCommandText += " update t_sgl_ictemplate set FTop=" + ctl.Top.ToString() + ",FLeft=" + ctl.Left.ToString() + ",FHeight=" + ctl.Height.ToString() + ",FWidth=" + ctl.Width.ToString() + ",FTabName='" + _TabName + "' where FID=" + _trantype.ToString() + " and FFieldName='" + ctl.Name + "'";
            }
            ctl = null;
            if ((this.formDesignerHost.RootComponent as Form).Controls.Find("C1Flexgrid1", true).Length > 0)
            {
                ctl = (this.formDesignerHost.RootComponent as Form).Controls.Find("C1Flexgrid1", true)[0];
                myCommandText += " update t_sgl_ICEntry set FTop=" + ctl.Top.ToString() + ",FLeft=" + ctl.Left.ToString() + ",FHeight=" + ctl.Height.ToString() + ",FWidth=" + ctl.Width.ToString() + " where FID=" + _trantype.ToString();
            }
            int result = DBUtility.SqlHelper.ExecuteNonQuery(connString, myCommandText);
        }

        /// <summary>
        /// 页签信息保存
        /// </summary>
        /// <param name="_trantype"></param>
        private void AddTab(int _trantype)
        {
            string myCommandText = "";
            Control ctl;
          
            if ((this.formDesignerHost.RootComponent as Form).Controls.Find(TabControlName, false).Length > 0)
            {
                ctl = (this.formDesignerHost.RootComponent as Form).Controls.Find(TabControlName, true)[0];
                int _Left = ctl.Left;
                int _Width = ctl.Width;
                int _Top = ctl.Top;
                int _Height = ctl.Height;
                myCommandText = @"delete from t_cs_ICBillTabPage where FID={0};
                insert into t_cs_ICBillTabPage( FID, FLeft, FTop, FHeight, FWidth)
                select {0},{1},{2},{3},{4};
                delete from t_cs_ICBillTabPageEntry where FID={0};
                ";
                myCommandText = string.Format(myCommandText, _trantype.ToString(), _Left.ToString(), _Top.ToString(), _Height.ToString(), _Width.ToString());
                //myCommandText = "delete from t_cs_ICBillTabPage where FID=" + _trantype.ToString();
                //myCommandText += " insert into t_cs_ICBillTabPage( FID, FLeft, FTop, FHeight, FWidth)";
                //myCommandText += " select " + _trantype.ToString() + "," + _Left.ToString() + "," + _Top.ToString() + "," + _Height.ToString() + "," + _Width.ToString();
                //myCommandText += " delete from t_cs_ICBillTabPageEntry where FID=" + _trantype.ToString();
                int _index = 0;
                foreach (TabPage item in (ctl as TabControl).TabPages)
                {
                    _index += 1;
                    myCommandText += " insert into t_cs_ICBillTabPageEntry(FID,FTabID,FTabName) select " + _trantype.ToString() + "," + _index + ",'" + item.Name + "';";
                }

                int result =DBUtility.SqlHelper.ExecuteNonQuery(connString, myCommandText);
            }  
        }

        /// <summary>
        /// 删除某一页签（按页签名称）
        /// </summary>
        /// <param name="_trantype"></param>
        /// <param name="_tabPageName"></param>
        private void DeleteOneTabPageByName(int _trantype, string _tabPageName)
        {
 
            string myCommandText = "";
            Control ctl;

            if ((this.formDesignerHost.RootComponent as Form).Controls.Find(TabControlName, false).Length > 0)
            {
                ctl = (this.formDesignerHost.RootComponent as Form).Controls.Find(TabControlName, true)[0];

                myCommandText = @"delete from t_cs_ICBillTabPageEntry where FID={0} and FTabName='{1}';
                update t_sgl_ictemplate set FTabName='' where  FID={0} and FTabName='{1}';
                ";

                myCommandText = string.Format(myCommandText, _trantype.ToString(), _tabPageName);
                int result = DBUtility.SqlHelper.ExecuteNonQuery(connString, myCommandText);

                (ctl as TabControl).TabPages.RemoveByKey(_tabPageName);

                if ((ctl as TabControl).TabPages.Count == 0)
                {
                    DeleteTabMain(_trantype);
                }
            }  
        }

        /// <summary>
        /// 删除TabControl（当没有子页签时）
        /// </summary>
        /// <param name="_trantype"></param>
        private void DeleteTabMain(int _trantype)
        {
            string myCommandText = "";
            if ((this.formDesignerHost.RootComponent as Form).Controls.Find(TabControlName, false).Length > 0)
            {
                myCommandText = @"delete from t_cs_ICBillTabPage where FID={0};";
                myCommandText = string.Format(myCommandText, _trantype.ToString());
                int result = DBUtility.SqlHelper.ExecuteNonQuery(connString, myCommandText);

                (this.formDesignerHost.RootComponent as Form).Controls.RemoveByKey(TabControlName);
            }
        }

        /// <summary>
        /// 修改某一页签的名称
        /// </summary>
        /// <param name="_trantype"></param>
        /// <param name="_tabPageNameOld"></param>
        /// <param name="_tabPageNameNew"></param>
        private void EditOneTabPageName(int _trantype, string _tabPageNameOld, string _tabPageNameNew)
        {
            string myCommandText = "";
            Control ctl;

            if ((this.formDesignerHost.RootComponent as Form).Controls.Find(TabControlName, false).Length > 0)
            {
                ctl = (this.formDesignerHost.RootComponent as Form).Controls.Find(TabControlName, true)[0];
                //(ctl as TabControl).TabPages
                myCommandText = @"update t_cs_ICBillTabPageEntry set FTabName='{0]' where FID={1} and FTabName='{2}';
                update t_sgl_ictemplate set FTabName='{0}' where FID={1} and FTabName='{2}';
                ";
                myCommandText = string.Format(myCommandText, _tabPageNameNew, _trantype.ToString(), _tabPageNameOld);
                //myCommandText = "update t_cs_ICBillTabPageEntry set FTabName='" + _tabPageNameNew + "' where FID=" + _trantype.ToString() + " and FTabName='" + _tabPageNameOld + "'";
                //myCommandText += " update t_sgl_ictemplate set FTabName='" + _tabPageNameNew + "' where FID=" + _trantype.ToString() + " and FTabName='" + _tabPageNameOld + "'";

                int result = DBUtility.SqlHelper.ExecuteNonQuery(connString, myCommandText);

                (ctl as TabControl).TabPages[_tabPageNameOld].Text = _tabPageNameNew;
                (ctl as TabControl).TabPages[_tabPageNameOld].Name = _tabPageNameNew;
                
            }  
        }

        /// <summary>
        /// 调整页签的顺序
        /// </summary>
        /// <param name="_trantype"></param>
        /// <param name="_has"></param>
        private void ChangetheTabPagesIndex(int _trantype, Hashtable _has)
        {
            if ((this.formDesignerHost.RootComponent as Form).Controls.Find(TabControlName, false).Length > 0)
            {
                TabControl tc = (this.formDesignerHost.RootComponent as Form).Controls.Find(TabControlName, true)[0] as TabControl;
            
                string Sql = "";
                for (int _index = 1; _index <= _has.Count; _index++)
                {
                    Sql += " update t_cs_ICBillTabPageEntry set FTabID=" + _index +" where FID=" + _trantype.ToString() + " and FTabName='" + _has[_index].ToString() + "'";
                }
                connection = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ToString();
                //connection = "Database=ZW1208K;Server=139.255.253.178;uid=sa;password=sa;Connection Timeout=300;";
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                command.CommandText = Sql;
                command.ExecuteNonQuery();

                con.Close();

                LoadData(_trantype);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string key = this.BillList.SelectedItem.ToString();
            if (key == "") return;
            int _trantype;
            _trantype = BillType[this.BillList.SelectedItem.ToString()];
            SaveData(_trantype);
        }

        /// <summary>
        /// 页签新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tab_Add_Click(object sender, EventArgs e)
        {
            FrmTabAdd frm = new FrmTabAdd();
            frm.ShowDialog();
            string _tabName = frm.m_tabName;
            if (_tabName.Trim() == "") return;
            if ((this.formDesignerHost.RootComponent as Form).Controls.Find(TabControlName, true).Length > 0)
            {
                TabControl tc = ((this.formDesignerHost.RootComponent as Form).Controls.Find(TabControlName, true)[0] as TabControl);
               tc.TabPages.Add(_tabName, _tabName);
               tc.BringToFront(); //置前
            }
            else
            {
                Type controlType = typeof(TabControl);
                Control control = this.formDesignerHost.CreateComponent(controlType) as Control;
                control.Name = TabControlName;
                control.Text = TabControlName;
                control.Location = new Point(5, System.Environment.TickCount % 200);
                (this.formDesignerHost.RootComponent as Form).Controls.Add(control);

                (control as TabControl).TabPages.Add(_tabName, _tabName);

                control.BringToFront(); //置前
            }
            

        }

        /// <summary>
        /// 页签删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tab_Delete_Click(object sender, EventArgs e)
        {
            Control control = this.propertyGrid1.SelectedObject as Control;
            if (control != null && !IsLocked(control))
            {
                if (control.GetType() == typeof(TabPage))
                {
                    if ((control as TabPage).Controls.Count==0)
                    {
                        string key = this.BillList.SelectedItem.ToString();
                        if (key == "") return;
                        int _trantype;
                        _trantype = BillType[this.BillList.SelectedItem.ToString()];
                        DeleteOneTabPageByName(_trantype, control.Name);
                    }
                    else
                    {
                        MessageBox.Show("页签中已存在其他控件（字段），操作无效！");
                    }
                }

                else
                {
                    MessageBox.Show("选中项不是页签，操作无效！");
                }
            }
            else
            {
                MessageBox.Show("未选中任何项或选中项已锁定，操作无效！");
            }
        }

        /// <summary>
        /// 修改选中页签的名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tab_Edit_Click(object sender, EventArgs e)
        {
            Control control = this.propertyGrid1.SelectedObject as Control;
            if (control != null && !IsLocked(control))
            {
                if (control.GetType() == typeof(TabPage))
                {
                    string key = this.BillList.SelectedItem.ToString();
                    if (key == "") return;
                    int _trantype;
                    _trantype = BillType[this.BillList.SelectedItem.ToString()];
                    FrmTabEdit frm = new FrmTabEdit();
                    frm.m_tabName = control.Name;
                    frm.ShowDialog();
                    string _TabName = frm.m_tabName.Trim();
                    if (_TabName == "") return;
                    EditOneTabPageName(_trantype, control.Name, _TabName);
                }

                else
                {
                    MessageBox.Show("选中项不是页签，操作无效！");
                }
            }
            else
            {
                MessageBox.Show("未选中任何项或选中项已锁定，操作无效！");
            }
        }

        private void Tab_Mamager_Click(object sender, EventArgs e)
        {
            Hashtable _has,_returnHas;
            _has = new Hashtable();
            if ((this.formDesignerHost.RootComponent as Form).Controls.Find(TabControlName, true).Length > 0)
            {
                TabControl tc = (this.formDesignerHost.RootComponent as Form).Controls.Find(TabControlName, true)[0] as TabControl;
                
                int _index = 1;
                foreach (TabPage item in tc.TabPages)
                {
                    _has.Add(_index, item.Name);
                    _index += 1;
                }
            }
            if (_has.Count==0) return;
            FrmTabManager frm = new FrmTabManager();
            frm.m_has = _has;
            frm.ShowDialog();
            _returnHas = frm.m_returnHas;
            if (_returnHas != null && _returnHas.Count > 0)
            {
                string key = this.BillList.SelectedItem.ToString();
                if (key == "") return;
                int _trantype;
                _trantype = BillType[this.BillList.SelectedItem.ToString()];
                ChangetheTabPagesIndex(_trantype, _returnHas);
            }
        }

        private void Fields_Edit_Click(object sender, EventArgs e)
        {
            Control ctl = this.propertyGrid1.SelectedObjects[0] as Control;
            FrmPropertyDesign frmPropertyDesign = new FrmPropertyDesign();
            frmPropertyDesign.m_control = ctl;
            frmPropertyDesign.ShowDialog();
            D1TextBoxProperty pro = (frmPropertyDesign.m_return as D1TextBoxProperty);
            if (pro==null) return;
            if (ctl.Name != pro.Name && ControlMap.ContainsKey(pro.Name))
            {
                MessageBox.Show("字段名重复，请检查！");
                return;
            }
            
            

            Console.WriteLine(pro.Name + pro.LabelName);
            this.propertyGrid1.Refresh();
        }

    }   
  
    class MyNameService : INameCreationService  
    {         
        static int s_i = 0; 
        public string CreateName(IContainer container, Type dataType)      
        {        
            return dataType.Name + s_i++;    
        }         
        public bool IsValidName(string name)       
        {          
            if (string.IsNullOrEmpty(name) == true) return false; 
            if (char.IsDigit(name[0])) return false;           
            foreach(char ch in name)       
            {            
                if (char.IsLetterOrDigit(ch) == false && ch != '_') return false;       
            }            
            return true;  
        }         
        public void ValidateName(string name)  
        {           
            if (!IsValidName(name)) throw new Exception("Invalid name");  
        }   
    } 
}


