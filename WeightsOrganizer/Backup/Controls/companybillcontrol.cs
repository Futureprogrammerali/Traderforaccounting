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
    public partial class companybillcontrol : UserControl
    {
        public companybillcontrol()
        {
            InitializeComponent();
        }
        int cuuid = 0;
        void PrpeareDataSource(int idoo)
        {
           
            cmcmps.DataSource = BLL.BllGlobal.allcomps;
            cmcmps.DisplayMember = "Name";
            cmcmps.ValueMember = "ID";
            cmcmps.SelectedValue = idoo;
            cmcmps_SelectedIndexChanged(cmcmps, new EventArgs());

        }
        public int SetClient
        {
            set
            {
                cuuid = value;
                PrpeareDataSource(value);
            }
        }
        private void companybillcontrol_Load(object sender, EventArgs e)
        {
            if (cuuid > 0) PrpeareDataSource(cuuid);
            else
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
              //  PrpeareDataSource();
            }
        }

        void PrpeareDataSource()
        {
            cmcmps.DataSource = BLL.BllGlobal.allcomps;
            cmcmps.DisplayMember = "Name";
            cmcmps.ValueMember = "ID";
            cmcmps.SelectedIndex = -1;
            cmcmps.Text = "اختر شركة.. ";

        }
      
        private void cmcmps_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
             WeightsOrganizer.Controls.Righto.GetDataAgainTocompany();
             this.groupBox1.Visible = true;
             this.dataGridView1.DataSource = BLL.BusinesDeal.Search(int.Parse(cmcmps.SelectedValue.ToString()), true);
             this.groupBox1.Text = cmcmps.Text;
             this.label2.Text = dataGridView1.Rows.Count.ToString();

             double xpp = 0;
             xpp = ( (BLL.Company)cmcmps.SelectedItem).Balance;
             label10.Text = xpp.ToString();
             if (xpp <= 0) xpp = xpp * -1;
             numbertextbox1.Text = xpp.ToString();


             label24.Text = label10.Text;
             linkLabel1.Enabled = true; linkLabel2.Enabled = true;
             linkLabel1.Text = " مدونة  الحساب ل  " + " " + cmcmps.Text;
             linkLabel2.Text = "افراغ مدونة  الحساب ل" + " " + cmcmps.Text;
             Sendo = sender;
             eo = e;

            }
            catch { }
        }
     static    int clmn = 0, rs = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string clnt, typo;
                clnt = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                typo = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                this.groupBox2.Text = string.Format("التاجر {0}  الصنف  {1}", clnt, typo);
                label15.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                label16.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                label17.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                lbllid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                label20.Text= dataGridView1.Rows[e.RowIndex].Cells["paidMoneyDataGridViewTextBoxColumn2"].Value.ToString();
                label21.Text = dataGridView1.Rows[e.RowIndex].Cells["businessPriceDataGridViewTextBoxColumn2"].Value.ToString();
                //numbertextbox1.Text = label17.Text;
                clmn=e.ColumnIndex ;
                rs = e.RowIndex;
                if (e.ColumnIndex == 2)
                {
                    int rid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["typeIdDataGridViewTextBoxColumn2"].Value.ToString());
                    new FrmDetails(rid, "أصناف").ShowDialog();
                }
            }
            catch { }

        }

        void companybillcontrol_Click(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            BLL.Company clno = (BLL.Company)cmcmps.SelectedItem;
            double blanceee = clno.Balance;

            if (clno.Balance >= 0)
                clno.Balance = clno.Balance - double.Parse(numbertextbox1.Text);
            else
                clno.Balance = clno.Balance + double.Parse(numbertextbox1.Text);

            clno.UpdateCompany();
            BLL.BllGlobal.UpdateAllCompany();
            BLL.ListCompanytAccount.InsertCompanytAccount(int.Parse(cmcmps.SelectedValue.ToString()), double.Parse(label10.Text), double.Parse(numbertextbox1.Text), (double.Parse(label10.Text) - double.Parse(numbertextbox1.Text)));
            cmcmps_SelectedIndexChanged(Sendo, eo);
            button1.Enabled = true;

        }
        object Sendo = null; EventArgs eo = EventArgs.Empty;


    
        private void numbertextbox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = (numbertextbox1.Text.Length!=0);
                //if (double.Parse(numbertextbox1.Text) > double.Parse(label10.Text))
                //{
                //    MessageBox.Show("أدخل رقم اصغر من الباقي او يساويه");
                //    numbertextbox1.Text = label24.Text;
                //}

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
        private void label17_TextChanged(object sender, EventArgs e)
        {
          
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Globals.Globals.PrintNow(dataGridView1, string.Format("{0} صفقات ",cmcmps.Text));
        }
        private void numbertextbox1_Click(object sender, EventArgs e)
        {
            numbertextbox1.SelectAll();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new LastCompanyAcount((int)cmcmps.SelectedValue).ShowDialog();
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool x = BLL.ListCompanytAccount.DeleteListCompanytAccount((int)cmcmps.SelectedValue);
            string xx = ((x == false ? "لا يوجد ارتباطات للحذف" : "تم الحذف بنجاح "));
            MessageBox.Show(xx);
        }
    }
}
