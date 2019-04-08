using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer.Controls
{
    public partial class ViewTypes : UserControl
    {
        public ViewTypes()
        {
            InitializeComponent();
            this.Cursor = Cursors.Hand;
        }

        bool _alloclk = false;
        public bool alloclick
        {
            get { return _alloclk; }
            set { _alloclk = value; }
        }
        Control _ctrl = null;
        public Control Controlfolowing
        {
            get { return _ctrl; }
            set { _ctrl = value; }
        }
        public object DateSource
        {
       
            set
            {
                dataGridView1.DataSource = value;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try{
            if (e.ColumnIndex == 0)
            {
               new FrmDetails(int.Parse(dataGridView1.CurrentRow.Cells["ID"].Value.ToString()), "أصناف").ShowDialog();
            }
            }
            catch { }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try{
            if ((!string.IsNullOrEmpty(textBox1.Text)) && (textBox1.Text != "البحث في الأصناف"))
            {
                dataGridView1.DataSource = BLL.Types.Search(textBox1.Text);
            }
            else
            {
                dataGridView1.DataSource = BLL.Types.GetAllTypes();
                if (textBox1.Text.Length == 0) { textBox1.Text = "البحث في الأصناف"; textBox1.SelectAll(); }
            }
            }
            catch { }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "البحث في الأصناف") textBox1.SelectAll();
        }
    }
}
