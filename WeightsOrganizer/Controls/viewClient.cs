using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer.Controls
{
    public partial class viewClient : UserControl
    {
        public viewClient()
        {
            InitializeComponent();
            this.Cursor = Cursors.Hand;
        }
        public object DateSource
        {

            set
            {
                dataGridView1.DataSource = value;
            }
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
       if (alloclick)
            {
                try
                {
                    (_ctrl as ComboBox).SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                    this.dataGridView1.CurrentRow.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Red;
                }
                catch { }
        }
    }
}
}
