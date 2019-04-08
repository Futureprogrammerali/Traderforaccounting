using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer.Controls
{
    public partial class BusinesDealControl : UserControl
    {
        public BusinesDealControl()
        {
         InitializeComponent();
        }

        private void BusinesDealControl_Load(object sender, EventArgs e)
        {
            combotypes.DisplayMember = "Name";
            combocompany.DisplayMember = "Name";
            combotypes.ValueMember = "ID";
            combocompany.ValueMember = "ID";
     
        
        }
        public object BDateSource
        {
            get {
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
       combotypes.DataSource = BLL.BllGlobal.alltypes;
       combocompany.DataSource = BLL.BllGlobal.allcomps;
        
        combotypes.DisplayMember  = "Name";
        combocompany.DisplayMember = "Name";
        combotypes.ValueMember = "ID";
        combocompany.ValueMember = "ID";

        cmtyps.DataSource = BLL.Types.GetAllTypes();
        cmcmps.DataSource = BLL.Company.GetAllCompany();
        cmtyps.DisplayMember  = "Name";
        cmcmps.DisplayMember   = "Name";
        cmtyps.ValueMember = "ID";
        cmcmps.ValueMember   = "ID";


        combotypes.SelectedIndex = -1;
        combotypes.Text = "اختر صنف.. ";
        combocompany.SelectedIndex = -1;
        combocompany.Text = "اختر تاجر .. ";

        cmtyps.SelectedIndex = -1;
        cmtyps.Text = "اختر صنف.. ";
        cmcmps.SelectedIndex = -1;
        cmcmps.Text = "اختر تاجر .. ";

        }
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            
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
               if (e.ColumnIndex == 4)
               {
                   string na = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                   int idf = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                  contextMenuStrip1.Items[0].Text = " معلومات عن التاجر " + na;
                  contextMenuStrip1.Items[1].Text = " حـــســــاب التاجر   " + na;
                 contextMenuStrip1.Items[0].Tag = idf;
                 contextMenuStrip1.Items[1].Tag = idf;
                contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
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
                btndel.Enabled = true;
                button1.Enabled = true;
            }
        }
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
 
        }
  
        private void groupBox2_Enter(object sender, EventArgs e)
        {

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
            try
            {
                id = int.Parse(lblid.Text);
                btnaction.Text = "تعديل صفقة";
                btndel.Enabled = true;
                //txtamount.Enabled = false;
            }
            catch { id = 0; }
            if (lblid.Text == "0") btnaction.Text = "اضافة صفقة";
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            try
            {
                if (id > 0) BLL.BusinesDeal.DeleteBusinesDeal(id);
                lblid.Text = "0";
                btndel.Enabled = false;
              int typeid = int.Parse(combotypes.SelectedValue.ToString());
              double amnt = double.Parse(txtamount.Text);
                BLL.Store.InsertStoreFromClient(typeid, amnt, DateTime.Now,combotypes.Text);
                dataGridView1.DataSource = BLL.BusinesDeal.GetAllBusinesDeal();
                btnnew_Click(sender, e);
            }catch{}
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
                    BLL.BusinesDeal.UpdateBusinesDeal(id, typeid, manid, amnt, busric, clprc, PaidMoney, det,combocompany.Text,combotypes.Text);
                    dataGridView1.DataSource = BLL.BusinesDeal.GetAllBusinesDeal();
                    MessageBox.Show("تم تعديل صفقة المشتريات لكن لن يتم تعديل المخزن");
                }
                else
                {
                    BLL.BusinesDeal.InsertBusinesDeal(0, typeid, manid, amnt, busric, clprc, busric * amnt, det, combocompany.Text, combotypes.Text);
                    BLL.Company clo = (BLL.Company)combocompany.SelectedItem ; clo.Balance += ((amnt * busric) - PaidMoney); clo.UpdateCompany();
                    BLL.BllGlobal.UpdateAllCompany();
                    dataGridView1.DataSource = BLL.BusinesDeal.GetAllBusinesDeal();
                    BLL.Store.InsertStoreFromCompany(typeid, amnt, DateTime.Now,combotypes.Text);
                    //print
                    if (Globals.Globals.PrintWhenBuy)
                    {
                        try
                        {
                            List<BLL.BusinesDeal> curclnoo = new List<BLL.BusinesDeal>();
                            BLL.BusinesDeal cr = new BLL.BusinesDeal(0, typeid, manid, amnt, busric, clprc, busric * amnt, det,MyDateTime.Now , combocompany.Text, combotypes.Text);
                            curclnoo.Add(cr);
                            dataGridView1.DataSource = curclnoo;
                            if ((int)combocompany.SelectedValue != Globals.Globals.UnknownClient)
                                Globals.Globals.PrintNow(dataGridView1, @"السيد المحترم " + combocompany.Text, " المدفوع " + PaidMoney.ToString() + " ل.س "
                                + Environment.NewLine + " الباقي " + ((amnt * busric) - PaidMoney).ToString() + " ل.س "
                                + Environment.NewLine + string.Format("المجموع {0} ل.س ", (amnt * busric).ToString()), true);
                            else
                                Globals.Globals.PrintNow(dataGridView1, @"بتوقيت:", string.Format("المجموع {0} ل.س ", ((amnt * busric).ToString())), true);
                        }
                        catch { }
                    }

                    //end print
                }
               
 
                btnnew_Click(sender, e);
           
            }
            catch { SelectTheEmptyText(this.groupBox1); }
            
        }
        private int GetVisibleColumn(ref DataGridView x)
        {
            int xo = 0;
            foreach (DataGridViewColumn clmn in x.Columns)
            {
                if (clmn.Visible) xo++;
            }
            return xo;
        }


        protected void PrepeareStyleo(DataGridView x, int widt)
        {
            int xWidth = widt;
            int ascription = 10;
            int clmncount = GetVisibleColumn(ref x);
            switch (clmncount)
            {
                case 1: ascription = 100; break;
                case 2: ascription = 50; break;
                case 3: ascription = 33; break;
                case 4: ascription = 25; break;
                case 5: ascription = 20; break;
                case 6: ascription = 16; break;
                case 7: ascription = 14; break;
                case 8: ascription = 12; break;
                case 9: ascription = 11; break;
                default: ascription = 11; break;
            }
            foreach (DataGridViewColumn clmn in x.Columns)
            {
                if (clmn.Visible) clmn.Width = (xWidth * ascription) / 100;
            }

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
            if(id==0){
         try{
             string x = string.Format(" اشترينا كمية {0} {5} من الصنف {1} من التاجر {2} بسعر {3} ل.س بتاريخ {4}", txtamount.Text + " ", combotypes.Text, combocompany.Text + " ", txtbusprice.Text,MyDateTime.Now.ToString(),label14.Text.Replace("الوحدة ","").Replace("وزن","كغ "));
             if (txtclntprice.Text.Length > 0)
                {
                    txtdet.Text = x;
                }
             label11.Text = (double.Parse(txtbusprice.Text) * double.Parse(txtamount.Text)).ToString()+ "ل.س";
             txtpaidmny.Text = (double.Parse(txtbusprice.Text) * double.Parse(txtamount.Text)).ToString();   
            }
         catch { }}

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length > 0)
                {

                    dataGridView1.DataSource = BLL.BusinesDeal.Search(textBox1.Text);
                }
                else
                {
                    dataGridView1.DataSource = BLL.BusinesDeal.GetAllBusinesDeal();
                }
            }
            catch { }
        }

        private void cmtyps_SelectedIndexChanged(object sender, EventArgs e)
        {
                try
                {
                    this.dataGridView1.DataSource = BLL.BusinesDeal.Search(int.Parse(cmtyps.SelectedValue.ToString()), false);
                }
                catch { }
         
        }

        private void cmcmps_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.dataGridView1.DataSource = BLL.BusinesDeal.Search(int.Parse(cmcmps.SelectedValue.ToString()), true);

            }
            catch { }
          
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
     
        private void combotypes_SelectedIndexChanged(object sender, EventArgs e)
        {

            try{
                int x = 0;
                BLL.Types xx=null;
                x =int.Parse( combotypes.SelectedValue.ToString());
                xx=BLL.Types.GetTypeByID(x);
                if(id==0)   combocompany.DataSource =Globals.Globals.PleseGivespecialComapny(int.Parse(combotypes.SelectedValue.ToString()));
                else combocompany.DataSource = BLL.BllGlobal.allcomps;
                txtclntprice.Text = xx.ClientPrice.ToString();
                txtbusprice.Text = xx.BusinessPrice.ToString();
                label14.Text =" الوحدة "+ xx.ArabicUnit;
              
                }catch{}
        }
  
        private void txtpaidmny_Enter(object sender, EventArgs e)
        {
        
        }

        private void txtpaidmny_TextChanged(object sender, EventArgs e)
        {
            try{
            double pai = 0, bus = 0, amnt = 0;
            pai = double.Parse(txtpaidmny.Text);
            bus = double.Parse(txtbusprice.Text);
            amnt = double.Parse(txtamount.Text);
            
                if (pai > (bus * amnt))
                {
                txtpaidmny.Text = (double.Parse(txtbusprice.Text) * double.Parse(txtamount.Text)).ToString();
                }

            }
           catch {   }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Globals.Globals.PrintNow(dataGridView1, "المشتريات");
        }
        private void infoooToolStripMenuItem_Click(object sender, EventArgs e)
        {
        new FrmDetails(int.Parse( infoooToolStripMenuItem.Tag.ToString()), "تجار").ShowDialog();
        }

        private void acountooToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WeightsOrganizer.Controls.ViewAll.FastBill(int.Parse(acountooToolStripMenuItem.Tag.ToString()), "تجار");
           
        }

        private void combocompany_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            frmGroupcompanyDeal frm = new frmGroupcompanyDeal(true);
            frm.ShowDialog();
        }

         public   void MyRefresh()
        {

            dataGridView1.DataSource = BLL.BusinesDeal.GetAllBusinesDeal();
        }

         private void baraCode128vewier1_Load(object sender, EventArgs e)
         {

         }
    }
}
