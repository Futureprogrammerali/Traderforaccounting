using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer
{
    public partial class frmBuyReturnsGroup : WeightsOrganizer.FrmMain
    {
        public frmBuyReturnsGroup(bool isdetial)
        {
            this.isFrmDetails = isdetial;
            InitializeComponent();
        }
 
        void PrpeareDataSource()
        {
            combotypes.DataSource = BLL.BllGlobal.RealType();
            combocompany.DataSource = BLL.BllGlobal.allcomps;
            combotypes.DisplayMember = "Name";
            combocompany.DisplayMember = "Name";
            combotypes.ValueMember = "ID";
            combocompany.ValueMember = "ID";

            combotypes.SelectedIndex = -1;
            combotypes.Text = "اختر صنف.. ";
            combocompany.SelectedIndex = -1;
            combocompany.Text = "اختر تاجر .. ";
         
        }
        private void frmBuyReturnsGroup_Load(object sender, EventArgs e)
        {
            PrpeareDataSource();
      
        }

        double ALlPrice = 0;
        List<BLL.BusinesReturns> alloo = new List<WeightsOrganizer.BLL.BusinesReturns>();
        private void btnaction_Click(object sender, EventArgs e)
        {
            if (combotypes.SelectedIndex == -1 || combocompany.SelectedIndex == -1) { MessageBox.Show("الرجاء تحديد التاجر و الصنف", "خطأ ادخال بيانات", MessageBoxButtons.OK); return; }
            if (txtamount.Text == "0" || (string.IsNullOrEmpty(txtamount.Text))) { MessageBox.Show("الرجاء تحديد الكمية ", "خطأ ادخال بيانات", MessageBoxButtons.OK); return; }
            BLL.Types tp = BLL.Types.GetTypeByID((int)combotypes.SelectedValue);
            if (BLL.Store.GetStoreByTypeID(tp.ID).Amount < double.Parse(txtamount.Text)) { MessageBox.Show("لا تستطيع ارجاع كمية ليست متوفرة في المخزن"); return; }
            BLL.BusinesReturns cl = new WeightsOrganizer.BLL.BusinesReturns(0, (int)combotypes.SelectedValue, (int)combocompany.SelectedValue,
            double.Parse(txtamount.Text), tp.BusinessPrice, tp.ClientPrice, 0, "مجموعة", MyDateTime.Now, combocompany.Text, combotypes.Text);
            
            List<BLL.BusinesReturns> allz = new List<WeightsOrganizer.BLL.BusinesReturns>();
            allz = alloo;
            bool s = false;
            if (allz.Count > 0)
            {
                foreach (BLL.BusinesReturns bd in allz)
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
            BLL.BusinesReturns cl = new WeightsOrganizer.BLL.BusinesReturns(0, (int)combotypes.SelectedValue, (int)combocompany.SelectedValue,
            double.Parse(txtamount.Text), tp.BusinessPrice, tp.ClientPrice, 0, "", MyDateTime.Now, combocompany.Text, combotypes.Text);
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
            double paidprc = 0;
            try
            {
                paidprc = double.Parse(numbertextbox2.Text);
            }
            catch { }
            List<BLL.BusinesReturns> alcll = new List<WeightsOrganizer.BLL.BusinesReturns>();
            try
            {
                alcll = (List<BLL.BusinesReturns>)dataGridView1.DataSource;
            }
            catch { }
            WeightsOrganizer.BLL.BusinesReturns.InsertBusinesReturns(alcll);
           
            BLL.Company clo = (BLL.Company)combocompany.SelectedItem;
            if (checkBox1.Checked)
            {
                    clo.Balance -= double.Parse(numbertextbox1.Text); clo.UpdateCompany();
            }
            ALlPrice = 0;
            alloo = new List<WeightsOrganizer.BLL.BusinesReturns>();
            dataGridView1.DataSource = new object();
            combocompany.Enabled = true;
            numbertextbox1.Text = "0";
            numbertextbox2.Text = "0";
            if (frmRealMainForm.FrmTypso != null )
            {
                frmRealMainForm.FrmTypso.MyRefresh();
            }
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


     
        private void btndelcur_Click(object sender, EventArgs e)
        {
            Del(int.Parse(dataGridView1.CurrentRow.Cells["typeIdDataGridViewTextBoxColumn"].Value.ToString())); btndelcur.Enabled = false;
        }

        private void Del(int p)
        {
            ALlPrice = 0;
            List<BLL.BusinesReturns> allz = new List<WeightsOrganizer.BLL.BusinesReturns>();
            foreach (BLL.BusinesReturns cl in alloo)
            {
                allz.Add(cl);
            }
            alloo = new List<WeightsOrganizer.BLL.BusinesReturns>();
            foreach (BLL.BusinesReturns cl in allz)
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
                MessageBox.Show(" تم تحديد التاجر مسبقا", "عفوا", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void numbertextbox1_TextChanged(object sender, EventArgs e)
        {
            label6.Text = string.Format(" {1} بقيمة {0}", numbertextbox1.Text, combocompany.Text);
        }

    }
}
