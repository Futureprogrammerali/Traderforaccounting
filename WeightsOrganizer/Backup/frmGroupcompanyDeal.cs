using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer
{
    public partial class frmGroupcompanyDeal : WeightsOrganizer.FrmMain
    {
        public frmGroupcompanyDeal(bool isdetails)
        {
            this.isFrmDetails = isdetails;
            InitializeComponent();
        }
        void PrpeareDataSource()
        {
            combotypes.DataSource = BLL.BllGlobal.alltypes;
            combocompany.DataSource = BLL.BllGlobal.allcomps;
            combotypes.DisplayMember = "Name";
            combocompany.DisplayMember = "Name";
            combotypes.ValueMember = "ID";
            combocompany.ValueMember = "ID";

            combotypes.SelectedIndex = -1;
            combotypes.Text = "اختر صنف.. ";
            combocompany.SelectedIndex = -1;
            combocompany.Text = "اختر تاجر .. ";
            //   label4.Text = " عدد الـصـفـقـات لهذا الــيــوم " + dataGridView1.Rows.Count.ToString();
        }
        private void frmGroupcompanyDeal_Load(object sender, EventArgs e)
        {
            PrpeareDataSource();
        }
        double ALlPrice = 0;
        List<BLL.BusinesDeal> alloo = new List<WeightsOrganizer.BLL.BusinesDeal>();
        private void btnaction_Click(object sender, EventArgs e)
          {
              if (combotypes.SelectedIndex == -1 || combocompany.SelectedIndex == -1) { MessageBox.Show("الرجاء تحديد التاجر و الصنف", "خطأ ادخال بيانات", MessageBoxButtons.OK); return; }
              if (txtamount.Text == "0" || (string.IsNullOrEmpty(txtamount.Text))) { MessageBox.Show("الرجاء تحديد الكمية ", "خطأ ادخال بيانات", MessageBoxButtons.OK); return; }
              BLL.Types tp = BLL.Types.GetTypeByID((int)combotypes.SelectedValue);
              BLL.BusinesDeal cl = new WeightsOrganizer.BLL.BusinesDeal(0, (int)combotypes.SelectedValue, (int)combocompany.SelectedValue,
              double.Parse(txtamount.Text), tp.BusinessPrice, tp.ClientPrice, 0, "مجموعة", MyDateTime.Now,combocompany.Text,combotypes.Text);
              
              List<BLL.BusinesDeal> allz = new List<WeightsOrganizer.BLL.BusinesDeal>();
              allz = alloo;
              bool s = false;
              if (allz.Count > 0)
              {
                  foreach (BLL.BusinesDeal bd in allz)
                  {
                      if (bd.TypeId == cl.TypeId)
                      {
                          bd.Amount += cl.Amount; s = false;
                          break;
                      }
                      else { s = true; }
                  }
                  if (s) alloo.Add(cl);
              }
              else
              {
                  alloo.Add(cl);
              }

              ALlPrice += cl.ToTalPrice;
              numbertextbox1.Text = ALlPrice.ToString();
              numbertextbox2.Text = ALlPrice.ToString();
              txtamount.Text = "20";
              combotypes.SelectedIndex = -1;
              combotypes.Text = "اختر صنف.. ";
              dataGridView1.DataSource = new object();
              dataGridView1.DataSource = alloo;
              combocompany.Enabled = false;
          }
        void goo()
        {
            if (combotypes.SelectedIndex == -1 || combocompany.SelectedIndex == -1) { MessageBox.Show("الرجاء تحديد التاجر و الصنف", "خطأ ادخال بيانات", MessageBoxButtons.OK); return; }
            if (txtamount.Text == "0" || (string.IsNullOrEmpty(txtamount.Text))) { MessageBox.Show("الرجاء تحديد الكمية ", "خطأ ادخال بيانات", MessageBoxButtons.OK); return; }
            BLL.Types tp = BLL.Types.GetTypeByID((int)combotypes.SelectedValue);
            BLL.BusinesDeal cl = new WeightsOrganizer.BLL.BusinesDeal(0, (int)combotypes.SelectedValue, (int)combocompany.SelectedValue,
            double.Parse(txtamount.Text), tp.BusinessPrice, tp.ClientPrice, 0, "", MyDateTime.Now,combocompany.Text,combotypes.Text);
            alloo.Add(cl);
            ALlPrice += cl.ToTalPrice;
            numbertextbox1.Text = ALlPrice.ToString();
            numbertextbox2.Text = ALlPrice.ToString();
            txtamount.Text = "";
            combotypes.SelectedIndex = -1;
            combotypes.Text = "اختر صنف.. ";
            dataGridView1.DataSource = new object();
            dataGridView1.DataSource = alloo;
            combocompany.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            double paidprc = 0;
            try
            {
                paidprc = double.Parse(numbertextbox2.Text);
            }
            catch { }
            List<BLL.BusinesDeal> alcll = new List<WeightsOrganizer.BLL.BusinesDeal>();
            try
            {
                alcll = (List<BLL.BusinesDeal>)dataGridView1.DataSource;
            }
            catch { }
            BLL.BusinesDeal.InsertGroup(alcll);
            BLL.Company clo = (BLL.Company)combocompany.SelectedItem; 
            clo.Balance +=double.Parse(numbertextbox1.Text)  -  double.Parse(numbertextbox2.Text)  ;
            clo.UpdateCompany();
           
            if (Globals.Globals.PrintWhenBuy)
            {
                try
                {
          Globals.Globals.PrintNow(dataGridView1, "السيد " + combocompany.Text, string.Format("المجموع {0} ل.س ", ALlPrice) +Environment.NewLine  +" الباقي " + (ALlPrice - paidprc).ToString() + " ل.س ", true);
                }
                catch { }
            }

            ALlPrice = 0;
            alloo = new List<WeightsOrganizer.BLL.BusinesDeal>();
            dataGridView1.DataSource = new object();
            combocompany.Enabled = true;
            numbertextbox1.Text = "0";
            numbertextbox2.Text = "0";
            if (frmRealMainForm.FrmTypso != null && frmRealMainForm.FrmTypso.Name =="frmbusinesdeal") 
            {
            frmRealMainForm.FrmTypso.MyRefresh();           
            }
            button1.Enabled = true;
            combocompany.SelectedItem = clo;
        }
        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = alloo; button1.Enabled = (dataGridView1.Rows.Count > 0);
        }
        private void combocompany_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
        private void combotypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combocompany.Enabled)
            {
                try
                {
                    BLL.Types tp = BLL.Types.GetTypeByID((int)combotypes.SelectedValue);
                    label7.Text = tp.BusinessPrice.ToString();
                    if (combocompany.Enabled)
                    {
                        combocompany.DataSource = Globals.Globals.PleseGivespecialComapny((int)combotypes.SelectedValue);

                    }

                }
                catch { }
            }
        }
        private void btndelcur_Click(object sender, EventArgs e)
        {
            Del(int.Parse(dataGridView1.CurrentRow.Cells["typeIdDataGridViewTextBoxColumn"].Value.ToString())); btndelcur.Enabled = false;
        }
        private void Del(int p)
        {
            ALlPrice = 0;
            List<BLL.BusinesDeal> allz = new List<WeightsOrganizer.BLL.BusinesDeal>();
            foreach (BLL.BusinesDeal cl in alloo)
            {
                allz.Add(cl);
            }
            alloo = new List<WeightsOrganizer.BLL.BusinesDeal>();
            foreach (BLL.BusinesDeal cl in allz)
            {
                if ((cl.TypeId == p)) { }
                else
                {
                    alloo.Add(cl);
                    ALlPrice += cl.ToTalPrice;
                }
            }
            dataGridView1.DataSource = alloo;
            numbertextbox1.Text = ALlPrice.ToString();
            numbertextbox2.Text = ALlPrice.ToString();
            
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellContentClick(sender, e);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (int.Parse(dataGridView1.Rows[e.RowIndex].Cells["typeIdDataGridViewTextBoxColumn"].Value.ToString()) > 0)
                {
                    btndelcur.Text = "حذف الـ " + dataGridView1.Rows[e.RowIndex].Cells["typeNameDataGridViewTextBoxColumn"].Value.ToString();
                    btndelcur.Enabled = true;
                }
            }
            catch { }
        }
        private void label13_Click(object sender, EventArgs e)
        {
            if (combocompany.Enabled)
            {
                combocompany.DataSource = BLL.BllGlobal.allcomps;
                combocompany.DisplayMember = "Name";
                combocompany.ValueMember = "ID";
                combocompany.DroppedDown = true;
            }
            else
            {
                MessageBox.Show(" تم تحديد التاجر مسبقا","عفوا",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

        }
        private void numbertextbox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
