namespace DNA
{
    partial class FrmDesign
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
 
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnBringforward = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnLock = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Load = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BillList = new System.Windows.Forms.ToolStripComboBox();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Fields_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.Fields_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.Fields_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.页签管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tab_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.Tab_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.Tab_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.Tab_Mamager = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.tableLayoutPanel1.Controls.Add(this.propertyGrid1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(768, 424);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(545, 2);
            this.propertyGrid1.Margin = new System.Windows.Forms.Padding(2);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(221, 292);
            this.propertyGrid1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Controls.Add(this.btnBringforward);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnCopy);
            this.groupBox1.Controls.Add(this.btnLock);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(545, 298);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(221, 124);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Double click the listbox to add control";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(112, 16);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(105, 112);
            this.listBox1.TabIndex = 2;
            // 
            // btnBringforward
            // 
            this.btnBringforward.Location = new System.Drawing.Point(4, 104);
            this.btnBringforward.Margin = new System.Windows.Forms.Padding(2);
            this.btnBringforward.Name = "btnBringforward";
            this.btnBringforward.Size = new System.Drawing.Size(102, 26);
            this.btnBringforward.TabIndex = 1;
            this.btnBringforward.Text = "&Bring Forward";
            this.btnBringforward.Click += new System.EventHandler(this.btnBringforward_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(4, 75);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(102, 26);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(5, 46);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(2);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(101, 26);
            this.btnCopy.TabIndex = 3;
            this.btnCopy.Text = "&Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnLock
            // 
            this.btnLock.Location = new System.Drawing.Point(5, 16);
            this.btnLock.Margin = new System.Windows.Forms.Padding(2);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(101, 26);
            this.btnLock.TabIndex = 4;
            this.btnLock.Text = "&Lock";
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.BillList,
            this.编辑ToolStripMenuItem,
            this.页签管理ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(768, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_Load,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.loadToolStripMenuItem.Text = "&File";
            // 
            // menu_Load
            // 
            this.menu_Load.Name = "menu_Load";
            this.menu_Load.Size = new System.Drawing.Size(94, 22);
            this.menu_Load.Text = "&Load";
            this.menu_Load.Click += new System.EventHandler(this.loadToolStripMenuItem1_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(91, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            // 
            // BillList
            // 
            this.BillList.Items.AddRange(new object[] {
            "销售出库单",
            "外购入库单"});
            this.BillList.Name = "BillList";
            this.BillList.Size = new System.Drawing.Size(200, 20);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Fields_Add,
            this.Fields_Delete,
            this.Fields_Edit});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.编辑ToolStripMenuItem.Text = "字段管理";
            // 
            // Fields_Add
            // 
            this.Fields_Add.Name = "Fields_Add";
            this.Fields_Add.Size = new System.Drawing.Size(94, 22);
            this.Fields_Add.Text = "增加";
            // 
            // Fields_Delete
            // 
            this.Fields_Delete.Name = "Fields_Delete";
            this.Fields_Delete.Size = new System.Drawing.Size(94, 22);
            this.Fields_Delete.Text = "删除";
            // 
            // Fields_Edit
            // 
            this.Fields_Edit.Name = "Fields_Edit";
            this.Fields_Edit.Size = new System.Drawing.Size(94, 22);
            this.Fields_Edit.Text = "修改";
            this.Fields_Edit.Click += new System.EventHandler(this.Fields_Edit_Click);
            // 
            // 页签管理ToolStripMenuItem
            // 
            this.页签管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Tab_Add,
            this.Tab_Delete,
            this.Tab_Edit,
            this.Tab_Mamager});
            this.页签管理ToolStripMenuItem.Name = "页签管理ToolStripMenuItem";
            this.页签管理ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.页签管理ToolStripMenuItem.Text = "页签管理";
            // 
            // Tab_Add
            // 
            this.Tab_Add.Name = "Tab_Add";
            this.Tab_Add.Size = new System.Drawing.Size(94, 22);
            this.Tab_Add.Text = "增加";
            this.Tab_Add.Click += new System.EventHandler(this.Tab_Add_Click);
            // 
            // Tab_Delete
            // 
            this.Tab_Delete.Name = "Tab_Delete";
            this.Tab_Delete.Size = new System.Drawing.Size(94, 22);
            this.Tab_Delete.Text = "删除";
            this.Tab_Delete.Click += new System.EventHandler(this.Tab_Delete_Click);
            // 
            // Tab_Edit
            // 
            this.Tab_Edit.Name = "Tab_Edit";
            this.Tab_Edit.Size = new System.Drawing.Size(94, 22);
            this.Tab_Edit.Text = "修改";
            this.Tab_Edit.ToolTipText = "修改名称";
            this.Tab_Edit.Click += new System.EventHandler(this.Tab_Edit_Click);
            // 
            // Tab_Mamager
            // 
            this.Tab_Mamager.Name = "Tab_Mamager";
            this.Tab_Mamager.Size = new System.Drawing.Size(94, 22);
            this.Tab_Mamager.Text = "管理";
            this.Tab_Mamager.ToolTipText = "顺序调整";
            this.Tab_Mamager.Click += new System.EventHandler(this.Tab_Mamager_Click);
            // 
            // FrmDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 448);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmDesign";
            this.Text = "Designer Host";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
 
 
 
        #endregion
 
 
 
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
 
        private System.Windows.Forms.PropertyGrid propertyGrid1;
 
        private System.Windows.Forms.GroupBox groupBox1;
 
        private System.Windows.Forms.Button btnBringforward;
 
        private System.Windows.Forms.Button btnDelete;
 
        private System.Windows.Forms.Button btnCopy;
 
        private System.Windows.Forms.Button btnLock;

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_Load;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox BillList;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Fields_Add;
        private System.Windows.Forms.ToolStripMenuItem Fields_Delete;
        private System.Windows.Forms.ToolStripMenuItem 页签管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Tab_Add;
        private System.Windows.Forms.ToolStripMenuItem Tab_Delete;
        private System.Windows.Forms.ToolStripMenuItem Tab_Edit;
        private System.Windows.Forms.ToolStripMenuItem Tab_Mamager;
        private System.Windows.Forms.ToolStripMenuItem Fields_Edit;
    }
 
}