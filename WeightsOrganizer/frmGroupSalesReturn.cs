using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer
{
    public partial class frmGroupSalesReturn : WeightsOrganizer.FrmMain
    {
        public frmGroupSalesReturn(bool isFrmDetails)
        {
            this.isFrmDetails = isFrmDetails; 
            InitializeComponent();
        }
        void PrpeareDataSource()
        {
            combotypes.DataSource = BLL.BllGlobal.alltypes;
            combocompany.DataSource = BLL.BllGlobal.allclients;
            combotypes.DisplayMember = "Name";
            combocompany.DisplayMember = "Name";
            combotypes.ValueMember = "ID";
            combocompany.ValueMember = "ID";

            combotypes.SelectedIndex = -1;
            combotypes.Text = "اختر صنف.. ";
            combocompany.SelectedIndex = -1;
            combocompany.Text = "اختر زبون .. ";
            //   label4.Text = " عدد الـصـفـقـات لهذا الــيــوم " + dataGridView1.Rows.Count.ToString();
        }
        private void frmSalesReturns_Load(object sender, EventArgs e)
        {
            PrpeareDataSource();
            combocompany.SelectedValue = Globals.Globals.UnknownClient;
        }
        double ALlPrice = 0;
   
        List<BLL.SalesReturns> alloo = new List<WeightsOrganizer.BLL.SalesReturns>();
        private void btnaction_Click(object sender, EventArgs e)
        {
            if (combotypes.SelectedIndex == -1 || combocompany.SelectedIndex == -1) { MessageBox.Show("الرجاء تحديد الزبون و الصنف", "خطأ ادخال بيانات", MessageBoxButtons.OK); return; }
            if (txtamount.Text == "0" || (string.IsNullOrEmpty(txtamount.Text))) { MessageBox.Show("الرجاء تحديد الكمية ", "خطأ ادخال بيانات", MessageBoxButtons.OK); return; }
            TheUnito TheUnito = TheUnito.Kilo;
            TheUnito = (TheUnito)Enum.Parse(typeof(TheUnito), Globals.Globals.gram.ToString());
            BLL.Types tp = (BLL.Types)combotypes.SelectedItem;
            //
            double stramnt = 0;
            stramnt = double.Parse(txtamount.Text);
            if (tp.TheUnit == TheUnito.Gram) stramnt = double.Parse(txtamount.Text) / 1000;

            TheUnito = (TheUnito)Enum.Parse(typeof(TheUnito), Globals.Globals.gram.ToString());
            BLL.SalesReturns cl = new WeightsOrganizer.BLL.SalesReturns(0, (int)combotypes.SelectedValue, (int)combocompany.SelectedValue,
            double.Parse(txtamount.Text), (radioButton2.Checked ? tp.ClientPrice : tp.BusinessClientPrice), 0, "مجموعة", MyDateTime.Now, TheUnito, tp.BusinessPrice, combocompany.Text, combotypes.Text);

            List<BLL.SalesReturns> allz = new List<WeightsOrganizer.BLL.SalesReturns>();
            allz = alloo;
            bool s = false;
            if (allz.Count > 0)
            {
                foreach (BLL.SalesReturns bd in allz)
                {
                    if ((bd.TypeId == cl.TypeId) && (bd.TheUnit == cl.TheUnit))
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
            txtamount.Text = "";
            combotypes.SelectedIndex = -1;
            combotypes.Text = "اختر صنف.. ";
            combotypes.SelectAll();
            txtamount.Text = "1";
            dataGridView1.DataSource = new object();
            dataGridView1.DataSource = alloo;
            combocompany.Enabled = false;
            checkBox1.Enabled = false;
            groupBox3.Enabled = false;
            label2.Text = "السعر";
        }


        private void datagrid_change()
        {
            button1.Enabled = (dataGridView1.Rows.Count > 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            double stramnt = 0;
            List<BLL.SalesReturns> alcll = new List<WeightsOrganizer.BLL.SalesReturns>();
            try
            {
                alcll = (List<BLL.SalesReturns>)dataGridView1.DataSource;
            }
            catch { }
            BLL.SalesReturns.InsertClientDeal(alcll);
            BLL.Client clo = (BLL.Client)combocompany.SelectedItem;
            if (clo.ID != Globals.Globals.UnknownClient )
            {
                clo.Balance -= double.Parse(numbertextbox1.Text);
                clo.UpdateClient();
            }

            ALlPrice = 0;
            alloo = new List<WeightsOrganizer.BLL.SalesReturns>();
            dataGridView1.DataSource = new object();
            combocompany.Enabled = true;
            checkBox1.Enabled = true;
            groupBox3.Enabled = true;
            numbertextbox1.Text = "0";
            numbertextbox2.Text = "0";
            handclnt.Text = "0";

            combocompany.SelectedValue = Globals.Globals.UnknownClient;
            if (frmRealMainForm.FrmTypso != null && frmRealMainForm.FrmTypso.Name == "frmSalesReturn")
            {
                frmRealMainForm.FrmTypso.MyRefresh();
            }
            button1.Enabled = true;
        }
        void go(object alcll)
        {
            double stramnt = 0;
            foreach (BLL.SalesReturns curcl in (List<BLL.SalesReturns>)alcll)
            {
                ///  curcl.Details = "مجموعة ب " + numbertextbox1.Text + "ل.س " + "دفع نقدا   " + handclnt.Text;
                curcl.InsertClientDeal(true);
                stramnt = curcl.Amount;
                if (curcl.TheUnit == TheUnito.Gram) stramnt = curcl.Amount / 1000;
                BLL.Store.InsertStoreFromClient(curcl.TypeId, stramnt, DateTime.Now, curcl.TypeName);
            }
            BLL.Client clo = (BLL.Client)combocompany.SelectedItem;
            clo.Balance += double.Parse(numbertextbox1.Text) - double.Parse(numbertextbox2.Text);
            clo.UpdateClient();
            WeightsOrganizer.Controls.Righto.GetDataAgainTostory();

        }
        private void combotypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BLL.Types tp = (BLL.Types)combotypes.SelectedItem;
                label2.Text = (radioButton2.Checked ? tp.ClientPrice : tp.BusinessClientPrice).ToString();
                settingoControl1.Refresh(tp.TheUnit);
                if ((baraCode128vewier1.Text.Length > 0) && (!string.IsNullOrEmpty(baraCode128vewier1.Text) && baraCode128vewier1.Text != " "))
                {
                    btnaction_Click(sender, e);
                }
            }
            catch { }
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = alloo;
            button1.Enabled = (dataGridView1.Rows.Count > 0);
        }
        private void numbertextbox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                handclnt.Text = numbertextbox2.Text;
                if (double.Parse(numbertextbox2.Text) > double.Parse(numbertextbox1.Text))
                {
                    MessageBox.Show("أدخل رقم اصغر من المجموع او يساويه");
                    numbertextbox2.Text = numbertextbox1.Text;
                    handclnt.Text = numbertextbox2.Text;
                }
            }
            catch { }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int x = Globals.Globals.UnknownClient;
            if (checkBox1.Checked == true) combocompany.SelectedValue = ((x == -1) ? -1 : x);
            else
            {
                combocompany.SelectedIndex = -1; combocompany.Text = "اختر زبون .. ";
            }
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

        private void Del(int p, TheUnito theUnito)
        {
            ALlPrice = 0;
            List<BLL.SalesReturns> allz = new List<WeightsOrganizer.BLL.SalesReturns>();
            foreach (BLL.SalesReturns cl in alloo)
            {
                allz.Add(cl);
            }
            alloo = new List<WeightsOrganizer.BLL.SalesReturns>();
            foreach (BLL.SalesReturns cl in allz)
            {
                if (cl.TheUnit == theUnito && (cl.TypeId == p)) { }
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



        private void btndelcur_Click(object sender, EventArgs e)
        {
            Del(int.Parse(dataGridView1.CurrentRow.Cells["typeIdDataGridViewTextBoxColumn"].Value.ToString()),
(TheUnito)Enum.Parse(typeof(TheUnito), dataGridView1.CurrentRow.Cells["theUnitDataGridViewTextBoxColumn"].Value.ToString())
); btndelcur.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellContentClick(sender, e);
        }

    }
}
