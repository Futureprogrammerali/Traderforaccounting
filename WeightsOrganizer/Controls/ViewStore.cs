using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WeightsOrganizer.Controls
{
    public partial class ViewStore : UserControl
    {
        public ViewStore()
        {
            InitializeComponent();
            
        }
        public object DateSource
        {
            set
            {
                try
                {
                    dataGridView1.DataSource = value;
                    cmtyps.DataSource = BLL.BllGlobal.RealType();
                    cmtyps.DisplayMember = "Name";
                    cmtyps.ValueMember = "ID"; cmtyps.SelectedIndex = -1;
                    cmtyps.Text = "بضاعة المخزن"; 
                }
                catch { }

          
       
  
            }
        }
        private void ViewStore_Load(object sender, EventArgs e)
        {
            
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try{
            if (e.ColumnIndex == 0)
            {
            new FrmDetails(int.Parse(dataGridView1.CurrentRow.Cells["TypeId"].Value.ToString()), "أصناف").ShowDialog();
            }
            }
            catch { }
        }
        private void cmtyps_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmtyps.SelectedIndex != -1) dataGridView1.DataSource = BLL.Store.Search(int.Parse(cmtyps.SelectedValue.ToString()));
            }
            catch { }
        }
        private void cmtyps_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmtyps.Text.Length == 0)
                {
                    cmtyps.Text = "بضاعة المخزن";
                    dataGridView1.DataSource = BLL.BllGlobal.allstory;
                }
            }
            catch { }
        }
        private void cmtyps_Click(object sender, EventArgs e)
        {
            cmtyps.SelectAll();
        }
    }
}
