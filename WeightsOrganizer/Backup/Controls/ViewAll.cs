using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer.Controls
{
  
    public partial class ViewAll : UserControl
    {
        public ViewAll()
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
            try
            {
                if ((e.ColumnIndex == 0))
                {
                int rid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                string typeo =dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();              
                new FrmDetails(rid,typeo).ShowDialog();
                }
                if ((e.ColumnIndex ==1))
                {
                    int rid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                    string typeo = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    if (typeo == "أصناف") new FrmDetails(rid, typeo).ShowDialog();
                    else FastBill(rid,typeo);
                }
            }
            catch { }
        }

 

       public static  void  FastBill(int idr, string typeo)
        {
          if (typeo == "تجار")
           {
               frmcompanybill frm = new frmcompanybill(idr,true);
               frm.WindowState = FormWindowState.Normal;
               frm.StartPosition = FormStartPosition.CenterScreen;
               frm.MinimizeBox = false;
               frm.ShowDialog();
           }
           else if (typeo == "زبائن")
           {
               frmclienbill frm = new frmclienbill(idr,true); 
               frm.WindowState = FormWindowState.Normal;
               frm.StartPosition = FormStartPosition.CenterScreen;
               frm.MinimizeBox = false;
               frm.ShowDialog();
           }
        }


 

   

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if ((!string.IsNullOrEmpty(textBox1.Text)) && (textBox1.Text != "اكتب كلمة للبحث"))
                {
                    dataGridView1.DataSource = BLL.All.GetAll(textBox1.Text);
                }
            }
            catch { }
             }

        private void textBox1_Click(object sender, EventArgs e)
        {
      if(  textBox1.Text=="اكتب كلمة للبحث"  )  textBox1.SelectAll();
     
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
         
        }

        private void ViewAll_Scroll(object sender, ScrollEventArgs e)
        {

        }
    }
}
