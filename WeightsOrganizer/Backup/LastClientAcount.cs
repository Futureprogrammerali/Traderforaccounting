using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer
{
    public partial class LastClientAcount : FrmMain
    {

        int _manid = 0;
        public LastClientAcount(int manid)
        {
            
            this.isFrmDetails = true;
            _manid = manid;
            InitializeComponent();
            label1.Text = "مدونة حــســاب الزبون " + BLL.BllGlobal.GetclientsNameFromListclientsHere(manid);

        }
        private void LastClientAcount_Load(object sender, EventArgs e)
        {
          dataGridView1.DataSource = BLL.ListClienttAccount.GetAllListClienttAccount(_manid);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label18.Text = string.Format("بتاريخ {0} كان الحساب {1} دفع {2} مبلغ {3} صار الحساب الجديد {4}", dataGridView1.CurrentRow.Cells["dataGridViewTextBoxColumn1"].Value.ToString()
  , dataGridView1.CurrentRow.Cells["dataGridViewTextBoxColumn2"].Value.ToString(), BLL.BllGlobal.GetclientsNameFromListclientsHere(int.Parse(dataGridView1.CurrentRow.Cells["ClientId"].Value.ToString())), dataGridView1.CurrentRow.Cells["dataGridViewTextBoxColumn3"].Value.ToString()
 , dataGridView1.CurrentRow.Cells["dataGridViewTextBoxColumn4"].Value.ToString());
        }
    }
}
