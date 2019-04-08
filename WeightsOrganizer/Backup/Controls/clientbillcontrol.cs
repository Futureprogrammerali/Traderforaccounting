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
    public partial class clientbillcontrol : UserControl
    {
        public clientbillcontrol()
        {
            InitializeComponent();
        }

        private void clientbillcontrol_Load(object sender, EventArgs e)
        {
            if (cuuid > 0) PrpeareDataSource(cuuid); else
          PrpeareDataSource();
            
        }
        public object DateSource
        {
            get
            {
                return dataGridView1.DataSource;
            }
            set
            {
                dataGridView1.DataSource = value;
            }
        }
        int cuuid = 0;
        public int SetClient
        {
            set
            {
            cuuid = value;
            PrpeareDataSource(value);
            }
        }
        void PrpeareDataSource()
        {
            cmcmps.DataSource = BLL.BllGlobal.allclients;        
            cmcmps.DisplayMember = "Name";
            cmcmps.ValueMember = "ID";
            cmcmps.SelectedIndex = -1;
            cmcmps.Text = "اختر زبون ";
        }
        void PrpeareDataSource(int idoo)
        {
            cmcmps.DataSource = BLL.BllGlobal.allclients;
            cmcmps.DisplayMember = "Name";
            cmcmps.ValueMember = "ID";
            cmcmps.SelectedValue = idoo;
            cmcmps_SelectedIndexChanged(cmcmps, new EventArgs());


        }
     
        private void cmcmps_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                WeightsOrganizer.Controls.Righto.GetDataAgainToclient();
             this.groupBox1.Visible = true;
             this.dataGridView1.DataSource = BLL.ClientDeal.Search(int.Parse(cmcmps.SelectedValue.ToString()), true);
             this.groupBox1.Text = cmcmps.Text;
             this.label2.Text = dataGridView1.Rows.Count.ToString();
             double xpp = 0;
             xpp = (BLL.Client.GetClientByID((int)cmcmps.SelectedValue).Balance);
             label10.Text = xpp.ToString();
             if(xpp<=0) xpp=xpp*-1;
             numbertextbox1.Text = xpp.ToString();
             label24.Text = numbertextbox1.Text;
             linkLabel1.Enabled = true; linkLabel2.Enabled = true;
             linkLabel1.Text = " مدونة  الحساب ل  " + " " + cmcmps.Text;
             linkLabel2.Text = "افراغ مدونة  الحساب ل" + " " + cmcmps.Text;
             Sendo = sender;
             eo = e;
            }
            catch { }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string clnt,typo;
                clnt= dataGridView1.Rows[e.RowIndex].Cells["clientNameDataGridViewTextBoxColumn"].Value.ToString();
                typo= dataGridView1.Rows[e.RowIndex].Cells["typeNameDataGridViewTextBoxColumn"].Value.ToString();
                this.groupBox2.Text = string.Format("الزبون {0}  الصنف  {1}", clnt, typo);
                label15.Text = dataGridView1.Rows[e.RowIndex].Cells["toTalPriceDataGridViewTextBoxColumn"].Value.ToString();
                label17.Text = dataGridView1.Rows[e.RowIndex].Cells["stayingPriceDataGridViewTextBoxColumn"].Value.ToString();
                label16.Text = dataGridView1.Rows[e.RowIndex].Cells["paidMoneyDataGridViewTextBoxColumn"].Value.ToString();
                label19.Text = dataGridView1.Rows[e.RowIndex].Cells["amountDataGridViewTextBoxColumn1"].Value.ToString();
                label21.Text = dataGridView1.Rows[e.RowIndex].Cells["priceDataGridViewTextBoxColumn"].Value.ToString();
                lbllid.Text = dataGridView1.Rows[e.RowIndex].Cells["iDDataGridViewTextBoxColumn"].Value.ToString();
                label20.Text = "الكمية." + dataGridView1.Rows[e.RowIndex].Cells["ArabicUnit"].Value.ToString();
                //
                if (e.ColumnIndex == 0)
                {
                    int rid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["typeIdDataGridViewTextBoxColumn"].Value.ToString());
                    FrmDetails sss = new FrmDetails(rid, "أصناف");
                  sss.ShowDialog();
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            BLL.Client clno= (BLL.Client)cmcmps.SelectedItem;
            if (clno.Balance >= 0)
                clno.Balance = clno.Balance - double.Parse(numbertextbox1.Text);
            else clno.Balance = clno.Balance + double.Parse(numbertextbox1.Text);

            clno.UpdateClient();
            BLL.BllGlobal.UpdateAllClients();
            BLL.ListClienttAccount.InsertListClienttAccount(int.Parse(cmcmps.SelectedValue.ToString()), double.Parse(label10.Text), double.Parse(numbertextbox1.Text), (double.Parse(label10.Text) - double.Parse(numbertextbox1.Text)));
            cmcmps_SelectedIndexChanged(Sendo, eo);
            button1.Enabled = true;
            clno = null;
           
       
        }
        object Sendo = null; EventArgs eo = EventArgs.Empty;
     
        
      
        private void numbertextbox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled=(numbertextbox1.Text.Length != 0);
            }
            catch { }
        }

        private void lbllid_Click(object sender, EventArgs e)
        {

        }
        int id = 0;
        private void lbllid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(lbllid.Text);
                button1.Enabled=(id>0);
            }
            catch { }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            Globals.Globals.PrintNow( dataGridView1,"الزبائن");

        }

        private void numbertextbox1_Click(object sender, EventArgs e)
        {
            numbertextbox1.SelectAll();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new LastClientAcount((int)cmcmps.SelectedValue).ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool x= BLL.ListClienttAccount.DeleteListClienttAccount((int)cmcmps.SelectedValue);
            string xx = ((x==false ? "لا يوجد ارتباطات للحذف" : "تم الحذف بنجاح "));
            MessageBox.Show(xx);
        }

 

 
     
 
    }
}
