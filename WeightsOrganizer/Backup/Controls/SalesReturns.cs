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
    public partial class SalesReturns : UserControl
    {
        public SalesReturns()
        {
            InitializeComponent();
        }
        private void SalesReturns_Load(object sender, EventArgs e)
        {
            combotypes.DisplayMember = "Name";
            combocompany.DisplayMember = "Name";
            combotypes.ValueMember = "ID";
            combocompany.ValueMember = "ID";
            combocompany.SelectedValue = Globals.Globals.UnknownClient;
          
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
                btnnew_Click(this, new EventArgs());
                txtamount.Text = "1";
                this.txtamount.Allowcomma = (!(Globals.Globals.gram == 0));
            }
        }

        void PrpeareDataSource()
        {

            combotypes.DataSource = BLL.BllGlobal.alltypes;
            combocompany.DataSource = BLL.BllGlobal.allclients;
            combotypes.DisplayMember = "Name";
            combocompany.DisplayMember = "Name";
            combotypes.ValueMember = "ID";
            combocompany.ValueMember = "ID";
            combotypes.SelectedIndex = -1;combotypes.Text = "اختر صنف.. ";
         
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            try
            {
                settingoControl1.enableAll = true;
                foreach (Control t in groupBox1.Controls)
                {
                    if (t is TextBox) t.Text = "";
                    t.Enabled = true;
                }
                combocompany.SelectedValue = Globals.Globals.UnknownClient;
                combotypes.Enabled = true;
                combotypes.SelectedIndex = -1; combotypes.Text = "اختر الصنف..";
                label11.Text = "";
                lblid.Text = "0";
                txtamount.Text = "1";
                combotypes.SelectAll();
                txtdet.Text = "";
                txtamount.Enabled = true;
                radioButton2.Checked = true;
            }
            catch { }
        }
        int id = 0;
        private void lblid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(lblid.Text);
                btnaction.Text = "تعديل بيعة";
                txtamount.Enabled = false;
            }
            catch { id = 0; }
            if (lblid.Text == "0") btnaction.Text = "ارجاع";
        }



        private void btnaction_Click(object sender, EventArgs e)
        {

            int typeid = 0, manid = 0;
            double amnt = 0, clprc = 0, PaidMoney = 0;
            string det = "";
            BLL.Types tppp = null;
            try
            {
                typeid = int.Parse(combotypes.SelectedValue.ToString());
                manid = int.Parse(combocompany.SelectedValue.ToString());
                amnt = double.Parse(txtamount.Text);
                clprc = double.Parse(txtclntprice.Text);
                PaidMoney = double.Parse(txtpaidmny.Text);
                det = txtdet.Text;
                tppp = (BLL.Types)combotypes.SelectedItem;
                TheUnito TheUnito = TheUnito.Kilo;
                TheUnito = (TheUnito)Enum.Parse(typeof(TheUnito), Globals.Globals.gram.ToString());
                if (id > 0)
                {
                    //  MessageBox.Show(string.Format("{0}  {1} {2} {3} {4} {5} {6}",id.ToString(), typeid.ToString(), manid.ToString(), amnt.ToString(), clprc.ToString(), PaidMoney.ToString(), det));
                    BLL.SalesReturns.UpdateClientDeal(id, typeid, manid, amnt, clprc, PaidMoney, det, 0, combocompany.Text, combotypes.Text);
                    dataGridView1.DataSource = BLL.SalesReturns.GetAllClientDeal();
                }
                else
                {
                    double stramnt = amnt;
                    if (Globals.Globals.gram == 0) stramnt = amnt / 1000;
                    BLL.Store.InsertStoreFromClient(typeid, stramnt, DateTime.Now, combotypes.Text,true);
                    BLL.SalesReturns.InsertClientDeal(0, typeid, manid, amnt, clprc, amnt * clprc, det, TheUnito, tppp.BusinessPrice, combocompany.Text, combotypes.Text);
                
                    BLL.Client clo = BLL.Client.GetClientByID(manid);
                    if (clo.ID != Globals.Globals.UnknownClient)
                    {
                        clo.Balance -= ((amnt * clprc)); clo.UpdateClient();
                        BLL.BllGlobal.UpdateAllClients();
                    }
                    dataGridView1.DataSource = BLL.SalesReturns.GetAllClientDeal();
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
                    if ((t is ComboBox)) if ((t as ComboBox).SelectedIndex == -1) { messago += ", " + t.Tag; ok = true; }
                }
                if (ok) MessageBox.Show(messago, "الرجاء التاكد من المدخلات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch { }
        }
        string unitgram = "كيلو غرام";

        public void txtclntprice_TextChanged(object sender, EventArgs e)
        {
            bool dontchngpaid = true;
            if ((sender as Control).Name == handclnt.Name) dontchngpaid = false;
            if (id == 0)
            {
                try
                {
                    switch (Globals.Globals.gram)
                    {
                        case 0: unitgram = "غرام"; break;
                        case 1: unitgram = "كيلو غرام"; break;
                        case 2: unitgram = "قطعة "; break;
                    }
                    string x = string.Format(" استردينا {0}   من الصنف {1} للزبون   {2} بسعر {3} ل.س بتاريخ {4}", txtamount.Text + " " + unitgram, combotypes.Text, combocompany.Text + " ", txtclntprice.Text, MyDateTime.Now.ToString());
                    if (txtclntprice.Text.Length > 0)
                    {
                        txtdet.Text = x;
                    }
                    if (!(Globals.Globals.gram == 0))
                    {
                        // amount = amount * 1000;
                        label11.Text = " السعر الاجمالي " + ((double.Parse(txtclntprice.Text) * double.Parse(txtamount.Text))).ToString() + "ل.س"; ;
                        if (dontchngpaid) txtpaidmny.Text = ((double.Parse(txtclntprice.Text) * double.Parse(txtamount.Text))).ToString();
                    }
                    else
                    {
                        label11.Text = ((double.Parse(txtclntprice.Text) * double.Parse(txtamount.Text)) / 1000).ToString() + "ل.س";
                        if (dontchngpaid) txtpaidmny.Text = ((double.Parse(txtclntprice.Text) * double.Parse(txtamount.Text)) / 1000).ToString();
                    }

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
                txtclntprice.Text = xx.ClientPrice.ToString();
                settingoControl1.Refresh(xx.TheUnit);
                if ((baraCode128vewier1.Text.Length > 0) && (!string.IsNullOrEmpty(baraCode128vewier1.Text) && baraCode128vewier1.Text != " "))
                {
                    btnaction_Click(sender, e);
                }
            }
            catch { }
        }



 

        private void txtpaidmny_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double pai = 0, bus = 0, amnt = 0;
                pai = double.Parse(txtpaidmny.Text);
                bus = double.Parse(txtclntprice.Text);
                amnt = double.Parse(txtamount.Text);


                if (pai > ((bus * amnt)))
                {
                    txtpaidmny.Text = ((double.Parse(txtclntprice.Text) * double.Parse(txtamount.Text))).ToString();
                }
                handclnt.Text = txtpaidmny.Text;
            }
            catch { }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                settingoControl1.enableAll = false;
                //  if (dataGridView1.Rows[e.RowIndex].Cells["TheUnit"].Value.ToString()==TheUnito.Gram.ToString())
                txtamount.Text = (double.Parse(dataGridView1.Rows[e.RowIndex].Cells["amountDataGridViewTextBoxColumn"].Value.ToString())).ToString();
                txtclntprice.Text = dataGridView1.Rows[e.RowIndex].Cells["Priceo"].Value.ToString();
                txtdet.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                combotypes.Text = dataGridView1.Rows[e.RowIndex].Cells["TypeName"].Value.ToString();
                Enabledo(false);
                combocompany.SelectedValue = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["ClientId"].Value.ToString());
                lblid.Text = dataGridView1.Rows[e.RowIndex].Cells["iDDataGridViewTextBoxColumn"].Value.ToString();
                txtpaidmny.Text = dataGridView1.Rows[e.RowIndex].Cells["PaidMoney"].Value.ToString();
                label11.Text = "من أصل" + (double.Parse(dataGridView1.Rows[e.RowIndex].Cells["ToTalPrice"].Value.ToString())).ToString() + "ل.س";
                if (e.ColumnIndex == 2)
                {
                    int rid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    new FrmDetails(rid, "أصناف").ShowDialog();
                }
                if (e.ColumnIndex == 3)
                {

                    string na = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    int idf = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
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
                button1.Enabled = true;
            }
        }

 
        void changeprice(object sender)
        {
            BLL.Types xx = null;
            xx = (BLL.Types)combotypes.SelectedItem;
            if ((sender as RadioButton).Text.Equals("جملة"))
            {
                txtclntprice.Text = xx.BusinessClientPrice.ToString();
            }
            else
            {
                txtclntprice.Text = xx.ClientPrice.ToString();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            changeprice(sender);
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            frmGroupSalesReturn frm = new frmGroupSalesReturn(true);
            frm.ShowDialog();
        }


        public void MyRefresh()
        {
            dataGridView1.DataSource = BLL.SalesReturns.GetAllClientDeal();
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            int x = Globals.Globals.UnknownClient;
            if (checkBox1.Checked == true) combocompany.SelectedValue = ((x == -1) ? -1 : x);
            else
            {
                combocompany.SelectedIndex = -1; combocompany.Text = "اختر زبون .. ";
            }
        }

       
    }
}
