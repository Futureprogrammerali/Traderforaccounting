using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer.Controls
{
    public partial class StoreControl : UserControl
    {
        public StoreControl()
        {
            InitializeComponent();
        }
        DataGridViewCellStyle myDataGridViewCellStyle;
        private void StoreControl_Load(object sender, EventArgs e)
        {
            this.numbertextbox1.Text = Globals.Globals.DangerAmount;
            this.numbertextbox2.Text = Globals.Globals.DangerAmount2;
            dnramnt2 = double.Parse(Globals.Globals.DangerAmount2); 
            dnramnt = double.Parse(Globals.Globals.DangerAmount);
            myDataGridViewCellStyle = new DataGridViewCellStyle();
            myDataGridViewCellStyle.BackColor = Color.Red;

        }
        public object DateSource
        {
            get { return dataGridView1.DataSource; }
            set
            {
                dataGridView1.DataSource = value;
                cmtyps.DataSource = BLL.BllGlobal.alltypes;
                cmtyps.DisplayMember = "Name";
                cmtyps.ValueMember = "ID";
            }
        }
        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {

                dataGridView1.DataSource = BLL.Store.Search(textBox1.Text);
            }
            else
            {
                dataGridView1.DataSource = BLL.Store.GetAllStore();
            }
          

          
        }
        private void cmtyps_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.dataGridView1.DataSource = BLL.Store.Search(int.Parse(cmtyps.SelectedValue.ToString()));
            }
            catch { }
        }
        double   dnramnt = 0, dnramnt2=0;
        private void numbertextbox1_TextChanged(object sender, EventArgs e)
        {
            if (numbertextbox1.Text.Length > 0)
            {
                Globals.Globals.DangerAmount = numbertextbox1.Text;
  
                textBox1_TextChanged(sender, e);
                dnramnt = double.Parse(Globals.Globals.DangerAmount);
            }
        }      
        private void button1_Click(object sender, EventArgs e)
        {
            Globals.Globals.PrintNow(dataGridView1,"المخزن");
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try{
            if (e.ColumnIndex == 2)
            {
                int rid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                new FrmDetails(rid, "أصناف").ShowDialog();
            }
            }
            catch { }

        }
        private void numbertextbox2_TextChanged(object sender, EventArgs e)
        {
            if (numbertextbox2.Text.Length > 0)
            {
                Globals.Globals.DangerAmount2 = numbertextbox2.Text;
           
                textBox1_TextChanged(sender, e);
                dnramnt2 = double.Parse(Globals.Globals.DangerAmount2);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         try{
            if (e.ColumnIndex == 0)
            {
                int rid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                FrmDetails sss = new FrmDetails(rid, "أصناف");
                sss.ShowDialog();
            }
         }
         catch { }
        }
        int myid =0;
        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            try
            {
                myid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["TypeId"].Value.ToString());
                if (GetTypoo(myid).TheUnit == TheUnito.Piece)
                {
               if((double )dataGridView1.Rows[e.RowIndex].Cells["amountDataGridViewTextBoxColumn"].Value <double.Parse( Globals.Globals.DangerAmount2)) dataGridView1.Rows[e.RowIndex].DefaultCellStyle = myDataGridViewCellStyle;
                }
                else
                {
                    if ((double)dataGridView1.Rows[e.RowIndex].Cells["amountDataGridViewTextBoxColumn"].Value <double.Parse( Globals.Globals.DangerAmount)) dataGridView1.Rows[e.RowIndex].DefaultCellStyle = myDataGridViewCellStyle;
                }
                
            }
            catch { }
           
        }

        private BLL.Types GetTypoo(int myid)
        {
            foreach (BLL.Types tp in BLL.BllGlobal.alltypes)
            {
                if (myid == tp.ID) return tp;
            }
            return null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frminfostore frm = new frminfostore();
            frm.ShowDialog();
        }
 
    }
}
