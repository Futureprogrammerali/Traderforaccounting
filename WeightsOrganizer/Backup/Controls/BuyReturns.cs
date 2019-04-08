using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer.Controls
{
    public partial class BuyReturns : UserControl
    {
        public BuyReturns()
        {
            InitializeComponent();
            WeightsOrganizer.Controls.Righto.GetDataAgainTocompany();
        }
        private void BuyReturns_Load(object sender, EventArgs e)
        {
            combotypes.DisplayMember = "Name";
            combocompany.DisplayMember = "Name";
            combotypes.ValueMember = "ID";
            combocompany.ValueMember = "ID";

        }
        public object BDateSource
        {
            get
            {
                return dataGridView1.DataSource;
            }
            set
            {
                dataGridView1.DataSource = value;
                PrpeareDataSource();
                btnnew_Click(new object(), new EventArgs());
            }
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtamount.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtbusprice.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtclntprice.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtdet.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                Enabledo(false);
                combotypes.SelectedValue = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                combocompany.SelectedValue = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                lblid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtpaidmny.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
                label11.Text = "من أصل" + dataGridView1.Rows[e.RowIndex].Cells["ToTalPrice"].Value.ToString() + "ل.س";
                if (e.ColumnIndex == 2)
                {
                    int rid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    new FrmDetails(rid, "أصناف").ShowDialog();
                }
            }
            catch { }

        }
        private void Enabledo(bool p)
        {
            foreach (Control ctr in groupBox1.Controls)
                ctr.Enabled = p;
            if (p == false)
            {
                btnnew.Enabled = true;

            }
        }
        private void btnnew_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control t in groupBox1.Controls)
                {
                    if ((t is TextBox) || (t is numbertextbox)) t.Text = "";
                    t.Enabled = true;
                }
                combocompany.SelectedIndex = -1;
                combotypes.SelectedIndex = -1;
                combotypes.Text = "اختر صنف.. ";
                combocompany.Text = "اختر تاجر  .. ";

                label11.Text = "";
                lblid.Text = "0";
                combotypes.Focus();
                txtdet.Text = "";
                txtpaidmny.Text = "";
                txtamount.Enabled = true; txtamount.Text = "20";
            }
            catch { }
        }
        int id = 0;
        private void lblid_TextChanged(object sender, EventArgs e)
        {

        }
        private void btndel_Click(object sender, EventArgs e)
        {
            try
            {
                if (id > 0) BLL.BusinesReturns.DeleteBusinesDeal(id);
                lblid.Text = "0";
                int typeid = int.Parse(combotypes.SelectedValue.ToString());
                double amnt = double.Parse(txtamount.Text);
                BLL.Store.InsertStoreFromClient(typeid, amnt, DateTime.Now, combotypes.Text);
                dataGridView1.DataSource = BLL.BusinesReturns.GetAllBusinesDeal();
                btnnew_Click(sender, e);
            }
            catch { }
        }
        private void btnaction_Click(object sender, EventArgs e)
        {
            int typeid = 0, manid = 0;
            double amnt = 0, busric = 0, clprc = 0, PaidMoney = 0;
            string det = "";
            try
            {
                typeid = int.Parse(combotypes.SelectedValue.ToString());
                manid = int.Parse(combocompany.SelectedValue.ToString());
                amnt = double.Parse(txtamount.Text);
                busric = double.Parse(txtbusprice.Text);
                clprc = double.Parse(txtclntprice.Text);
                PaidMoney = double.Parse(txtpaidmny.Text);
                det = txtdet.Text;
                if (id > 0)
                {
                    BLL.BusinesReturns.UpdateBusinesDeal(id, typeid, manid, amnt, busric, clprc, PaidMoney, det, combocompany.Text, combotypes.Text);
                    dataGridView1.DataSource = BLL.BusinesReturns.GetAllBusinesDeal();
                    MessageBox.Show("تم تعديل  المشتريات لكن لن يتم تعديل المخزن");
                }
                else
                {
                    if (BLL.Store.GetStoreByTypeID(typeid).Amount<amnt) { MessageBox.Show("لا تستطيع ارجاع كمية ليست متوفرة في المخزن"); return; }
                    BLL.BusinesReturns.InsertBusinesDeal(0, typeid, manid, amnt, busric, clprc, busric * amnt, det, combocompany.Text, combotypes.Text);

                   if (checkBox1.Checked) {
                   BLL.Company clo = (BLL.Company)combocompany.SelectedItem;
                   clo.Balance -= ((amnt * busric));
                   clo.UpdateCompany();
                    }
                   BLL.BllGlobal.UpdateAllCompany();
                    dataGridView1.DataSource = BLL.BusinesReturns.GetAllBusinesDeal();
                    BLL.Store.InsertStoreFromCompany(typeid, amnt, DateTime.Now, combotypes.Text,true);
  
                }


                btnnew_Click(sender, e);

            }
            catch { SelectTheEmptyText(this.groupBox1); }

        }
 
        private void SelectTheEmptyText(Control ctrcontin)
        {
            string messago = "الرجاء وضع قيم بشكل مناسب" + "\n"; bool ok = false;
            try
            {
                foreach (Control t in ctrcontin.Controls)
                {
                    if ((t is TextBox) || (t is ComboBox)) if (t.Text.Length == 0) { messago += ", " + t.Tag; ok = true; }
                    if (t is ComboBox) if ((t as ComboBox).SelectedIndex == -1) { messago += ", " + t.Tag; ok = true; }
                }
                if (ok) MessageBox.Show(messago, "الرجاء التاكد من المدخلات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch { }
        }
        private void txtclntprice_TextChanged(object sender, EventArgs e)
        {
            if (id == 0)
            {
                try
                {
                    string x = string.Format(" ردينا كمية {0} {5} من الصنف {1} من التاجر {2} بسعر {3} ل.س بتاريخ {4}", txtamount.Text + " ", combotypes.Text, combocompany.Text + " ", txtbusprice.Text, MyDateTime.Now.ToString(), label14.Text.Replace("الوحدة ", "").Replace("وزن", "كغ "));
                    if (txtclntprice.Text.Length > 0)
                    {
                        txtdet.Text = x;
                    }
                    label11.Text = (double.Parse(txtbusprice.Text) * double.Parse(txtamount.Text)).ToString() + "ل.س";
                    txtpaidmny.Text = (double.Parse(txtbusprice.Text) * double.Parse(txtamount.Text)).ToString();
                    label5.Text = string.Format(" {1} بقيمة {0}", txtpaidmny.Text,combocompany.Text);
                }
                catch { }
            }

        }
         
       
        private void combotypes_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                int x = 0;
                BLL.Types xx = null;
                x = int.Parse(combotypes.SelectedValue.ToString());
                xx = BLL.Types.GetTypeByID(x);
                //MessageBox.Show(id.ToString());
                if (id == 0) combocompany.DataSource =Globals.Globals.PleseGivespecialComapny(int.Parse(combotypes.SelectedValue.ToString()));
                else combocompany.DataSource = BLL.BllGlobal.allcomps;
                //combocompany.DroppedDown = true;  
                txtclntprice.Text = xx.ClientPrice.ToString();
                txtbusprice.Text = xx.BusinessPrice.ToString();
                label14.Text = " الوحدة " + xx.ArabicUnit;

            }
            catch { }
        }
        private object PleseGivespecialComapny(int p)
        {
            BLL.Types tp = BLL.Types.GetTypeByID(p);
            List<BLL.Company> all2 = new List<WeightsOrganizer.BLL.Company>();
            if ((!string.IsNullOrEmpty(tp.AllCompanyId)) && (tp.AllCompanyId.Length != 0) && (tp.AllCompanyId != " "))
            {
                string[] all = tp.AllCompanyId.Split(',');
                foreach (string s in all)
                {
                    all2.Add(BLL.Company.GetCompanyByID(int.Parse(s)));
                }
            }
            return all2;
        }
        private void txtpaidmny_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double pai = 0, bus = 0, amnt = 0;
                pai = double.Parse(txtpaidmny.Text);
                bus = double.Parse(txtbusprice.Text);
                amnt = double.Parse(txtamount.Text);

                if (pai > (bus * amnt))
                {
                    txtpaidmny.Text = (double.Parse(txtbusprice.Text) * double.Parse(txtamount.Text)).ToString();
                }

            }
            catch { }

        }
     
        private object PleseGivespecialTypes(int p)
        {
            List<BLL.Types> all = BLL.BllGlobal.alltypes;
            List<BLL.Types> all2 = new List<WeightsOrganizer.BLL.Types>();

            foreach (BLL.Types cp in all)
            {
                if (cp.AllCompanyId.Contains(p.ToString())) { all2.Add(cp); }
            }
            return all2;
        }

        private void label13_Click(object sender, EventArgs e)
        {
            combocompany.DataSource = BLL.BllGlobal.allcomps;
            combocompany.DroppedDown = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmBuyReturnsGroup frm = new frmBuyReturnsGroup(true);
            frm.ShowDialog();
        }

        public void MyRefresh()
        {
            dataGridView1.DataSource = BLL.BusinesReturns.GetAllBusinesDeal();
        }

        private void baraCode128vewier1_Load(object sender, EventArgs e)
        {

        }

    }
}
