using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer
{
    public partial class LastCompanyAcount : WeightsOrganizer.FrmMain
    {
        int _manid = 0;
 
        public LastCompanyAcount(int manid)
        {
      
            isFrmDetails = true;
            _manid = manid;
            InitializeComponent();
            label1.Text = "مدونة حــســاب التاجــر " + BLL.BllGlobal.GetcompanyNameFromListcompanyssHere(manid);
 
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //       
            label18.Text = string.Format("بتاريخ {0} كان الحساب {1} دفع {2} مبلغ {3} صار الحساب الجديد {4}", dataGridView1.CurrentRow.Cells["addedDateDataGridViewTextBoxColumn"].Value.ToString()
  , dataGridView1.CurrentRow.Cells["canDataGridViewTextBoxColumn"].Value.ToString(), BLL.BllGlobal.GetcompanyNameFromListcompanyssHere(int.Parse(dataGridView1.CurrentRow.Cells["manIdDataGridViewTextBoxColumn"].Value.ToString())), dataGridView1.CurrentRow.Cells["numberDataGridViewTextBoxColumn"].Value.ToString()
 , dataGridView1.CurrentRow.Cells["sarDataGridViewTextBoxColumn"].Value.ToString());
        }

        private void LastCompanyAcount_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLL.ListCompanytAccount.GetAllListCompanytAccount(_manid);
        }
    }
}
