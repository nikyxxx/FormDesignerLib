using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DNA
{
    public partial class FrmTabEdit : Form
    {
        public string m_tabName = "";

        public FrmTabEdit()
        {
            InitializeComponent();
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_tabName = this.textBox1.Text;
            Close();

        }

        private void FrmTabEdit_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = m_tabName;
        }
    }
}
