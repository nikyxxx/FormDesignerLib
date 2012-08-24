using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DNA
{
    public partial class FrmTabManager : Form
    {
        public Hashtable m_has;
        public Hashtable m_returnHas;
        public FrmTabManager()
        {
            InitializeComponent();
        }

        private void FrmTabManager_Load(object sender, EventArgs e)
        {
            c1FlexGrid1.Rows.Count = 1;
            for (int _index = 1; _index <= m_has.Count; _index++)
            {
                c1FlexGrid1.Rows.Add();
                c1FlexGrid1[_index, "FName"] = m_has[_index].ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int _row = c1FlexGrid1.Row;
            if (_row <= 1 || _row >= c1FlexGrid1.Rows.Count) return;

            c1FlexGrid1.Rows[_row].Move(_row - 1);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int _row = c1FlexGrid1.Row;
            if (_row <= 0 || _row >= c1FlexGrid1.Rows.Count-1) return;

            c1FlexGrid1.Rows[_row].Move(_row + 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            m_returnHas = new Hashtable();
            for (int _index = 1; _index <= c1FlexGrid1.Rows.Count - 1; _index++)
            {
                m_returnHas.Add(_index, c1FlexGrid1[_index,"FName"].ToString());
            }
            Close();
        }
    }
}
