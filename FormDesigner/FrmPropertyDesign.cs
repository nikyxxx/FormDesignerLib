using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DNA.PropertyClass;

namespace DNA
{
    public partial class FrmPropertyDesign : Form
    {
        public Control m_control;
        public object m_return;
        public FrmPropertyDesign()
        {
            InitializeComponent();
        }

        private void FrmPropertyDesign_Load(object sender, EventArgs e)
        {
            Console.WriteLine(m_control.GetType());
            D1TextBoxProperty per = new D1TextBoxProperty()
            {
                Name = m_control.Name,
                LabelName = (m_control as D1Lib.D1TextBox).LabelName

            };

            this.propertyGrid1.SelectedObject = per;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            D1TextBoxProperty per = (this.propertyGrid1.SelectedObject as D1TextBoxProperty);
            m_return = per;
            Console.WriteLine(per.Name + per.LabelName);
            Close();
        }
    }
}
