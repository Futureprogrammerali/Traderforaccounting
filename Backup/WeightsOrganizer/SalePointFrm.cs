using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace WeightsOrganizer
{
    public partial class SalePointFrm : FrmMain
    {
        static string SaledProcrdere = "M";
        static int _idtype = 0;
        static TheUnito unittodel = TheUnito.Piece;
        static double _clnprice = 0;
        public SalePointFrm()
        {
            InitializeComponent();            
        }
        private void SalePointFrm_Load(object sender, EventArgs e)
        {
            pictureBox1BackColor = pictureBox1.BackColor;
            namedaypoint = new PointF(0, pictureBox1.Height - (picfontday.GetHeight() * 3));
            Timeponit = new PointF(0, pictureBox1.Height - (picfontday.GetHeight()));
            justdatepoint = new PointF(0, pictureBox1.Height - (picfontday.GetHeight() * 2));
          Prepear();
          OldFatora();
        }

        private void OldFatora()
        {
            if (WeHaveFator())
            {
                List<BLL.ClientDeal> alldd = new List<WeightsOrganizer.BLL.ClientDeal>();
                if (MessageBox.Show("هل تريد استرداد اخر فاتورة", "استرداد اخر فاتورة", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    alldd = BLL.SalePoint.ReadSerolizeMe();
                    if (alldd != null)
                    {
                        combocompany.SelectedValue = alldd[0].ClientId;
                        BLL.SalePoint.ALL = alldd;
                        dataGridView1.DataSource = alldd;
                    }
                }
                DefaultState(true);
            }
 
        }

        private bool WeHaveFator()
        {
            try
            {
                System.IO.Stream s = File.Open(@"FutureProgrammer.dat", System.IO.FileMode.Open);
                s.Close(); s.Dispose(); s = null;
            }
            catch { return false; }
            return true;
        }
        void Prepear()
        {
            BLL.SalePoint.EMpty();
            combotypes.DataSource = BLL.BllGlobal.RealType();
            combocompany.DataSource = BLL.BllGlobal.allclients;
            combotypes.DisplayMember = "Name";
            combocompany.DisplayMember = "Name";
            combotypes.ValueMember = "ID";
            combocompany.ValueMember = "ID";
            combotypes.SelectedIndex = -1; combotypes.Text = "اختر صنف.. ";
            combocompany.SelectedValue = Globals.Globals.UnknownClient;
            
        
        }
        private void combotypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLL.Types xx = null;
            try
            {
                xx = (BLL.Types)combotypes.SelectedItem;
                if (xx != null) addtype.Enabled = true; else return;
                settingoControl1.Refresh(xx.TheUnit);
                if ((baraCode128vewier1.Text.Length > 0) && (!string.IsNullOrEmpty(baraCode128vewier1.Text) && baraCode128vewier1.Text != " "))
                {
                    addtype_Click(sender, e);
                }
            }
            catch { }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SaledProcrdere = "G";
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SaledProcrdere = "M";
        }
        private void addtype_Click(object sender, EventArgs e)
        {
            if (combotypes.SelectedIndex != -1 || combocompany.SelectedIndex != -1)
            {
                int typeid = 0, manid = 0;
                double price = 0; int amnt = 1;
                BLL.Types tppp = null;
                try
                {
                    try { amnt = int.Parse(numbertextbox1.Text); }
                    catch { amnt = 1; }
                    tppp = (BLL.Types)combotypes.SelectedItem;
                    if (!BLL.SalePoint.ISinStore(tppp.ID, amnt)) { DefaultState(true); return; }
                    typeid = int.Parse(combotypes.SelectedValue.ToString());
                    manid = int.Parse(combocompany.SelectedValue.ToString());
                    price = ((SaledProcrdere == "M") ? tppp.ClientPrice : tppp.BusinessClientPrice);
                    tppp = (BLL.Types)combotypes.SelectedItem;
                    TheUnito TheUnito = TheUnito.Kilo;
                    TheUnito = (TheUnito)Enum.Parse(typeof(TheUnito), Globals.Globals.gram.ToString());                   
                    BLL.ClientDeal cl = new WeightsOrganizer.BLL.ClientDeal(0, typeid, manid,amnt, price, price, "", MyDateTime.Now, TheUnito, tppp.BusinessPrice, combocompany.Text, combotypes.Text);
                    dataGridView1.DataSource = new object();
                    dataGridView1.DataSource = BLL.SalePoint.Add(cl);
                    DefaultState(true);
                    BLL.SalePoint.WriteSerolizeMe();
                }
                catch { }
            }
            else
            {
                MessageBox.Show("معلومات مطلوبة", "الحساب و المادة", MessageBoxButtons.OK, MessageBoxIcon.Information);   
            }
        }
        private void DefaultState(bool Half)
        {
            if (Half)
            {
               if (eRowIndex > 0) dataGridView1.Rows[eRowIndex].Selected = true;
               else
               {
                   _idtype = 0; _clnprice = 0; eRowIndex = 0;
                   deltype.Enabled = addtype.Enabled = false;
                   btnsubfast.Enabled = btnaddfast.Enabled = false;
               }
              combotypes.SelectedIndex = -1; combotypes.Text = "المادة او الصنف";
            
            }
            lblallprice.Text = BLL.SalePoint.Price.ToString();
            txtallprice.Text = BLL.SalePoint.Price.ToString();
            baraCode128vewier1.FocusMy();
        }

        private void btnsale_Click(object sender, EventArgs e)
        {
            double muprice = 0;
            try
            {
                muprice = double.Parse(txtallprice.Text);
                if (BLL.SalePoint.Price > 0 && txtallprice.Text.Length > 0)
                {
                    if (Globals.Globals.PrintWhenSell)
                    {
                        try
                        {
                           if ((int)combocompany.SelectedValue != Globals.Globals.UnknownClient)
                            Globals.Globals.PrintNow(dataGridView1, @"السيد المحترم " + combocompany.Text, " المدفوع " + (Double.Parse(txtallprice.Text)).ToString() + " ل.س "
                            + Environment.NewLine + " الباقي " + (BLL.SalePoint.Price - (Double.Parse(txtallprice.Text))).ToString() + " ل.س "
                            +Environment.NewLine+ string.Format("المجموع {0} ل.س ", BLL.SalePoint.Price), true);
                           else
                          Globals.Globals.PrintNow(dataGridView1, @"بتوقيت:"  , string.Format("المجموع {0} ل.س ", BLL.SalePoint.Price), true);
                        }
                        catch { }
                    }
                    btnsale.Enabled = false;
                    dataGridView1.DataSource = new object();
                    if (double.Parse(lblallprice.Text) < muprice)
                    {
                       MessageBox.Show("الباقي للزبون " + (muprice - double.Parse(lblallprice.Text)).ToString() + "ل.س ");
                        muprice = double.Parse(lblallprice.Text);
                    }

                    BLL.SalePoint.SaleNow(muprice);
                    deltype.Enabled = false;
                    addtype.Enabled = false;
                    lblallprice.Text = "0";
                    txtallprice.Text = "0";

                }
            }
            catch { }
            Globals.Globals.DeleteFatora();
            baraCode128vewier1.FocusMy();
             
        }


        private void deltype_Click(object sender, EventArgs e)
        {
            if (_idtype > 0)
            {
                dataGridView1.DataSource = new object();
                dataGridView1.DataSource = BLL.SalePoint.Delete(_idtype, unittodel,_clnprice);
            }
            eRowIndex = 0; _idtype = 0;
            DefaultState(true);
            BLL.SalePoint.WriteSerolizeMe();
        }
        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            //try
            //{
            btnsale.Enabled 
            =btnaddfast.Enabled 
            =btnsubfast.Enabled = (dataGridView1.Rows.Count > 0);
            combocompany.Enabled = !(dataGridView1.Rows.Count > 0);
                label5.Text = "عدد البنود  " + dataGridView1.Rows.Count.ToString();
            //}
            //catch { }
            
        }
        private void SalePointFrm_FormClosing(object sender, FormClosingEventArgs e)
        {  
            BLL.SalePoint.EMpty(); 
        }
        private void numbertextbox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtallprice_TextChanged(object sender, EventArgs e)
        { 
            try
            {
                btnsale.Enabled = (txtallprice.Text.Length != 0);
                //if (double.Parse(txtallprice.Text) > double.Parse(lblallprice.Text))
                //{
                //    MessageBox.Show("أدخل رقم اصغر من السعر او يساويه");
                //    txtallprice.Text = lblallprice.Text;
                //}
            }
            catch { }
        }
        int eRowIndex = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (int.Parse(dataGridView1.Rows[e.RowIndex].Cells["TypeId"].Value.ToString()) > 0)
                {
                    ///deltype.Text = "حذف الـ " + dataGridView1.Rows[e.RowIndex].Cells["TypeName"].Value.ToString();
                    eRowIndex = e.RowIndex;
                    _idtype = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["TypeId"].Value.ToString());
                    _clnprice = double.Parse(dataGridView1.Rows[e.RowIndex].Cells["ToTalPrice"].Value.ToString());
                    unittodel = (TheUnito)Enum.Parse(typeof(TheUnito), dataGridView1.Rows[e.RowIndex].Cells["TheUnit"].Value.ToString());
                    deltype.Enabled = true;
                    btnaddfast.Enabled = true;
                    btnsubfast.Enabled = true;
                    if (e.ColumnIndex == 1)
                    {
                        int rid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString());
                        new FrmDetails(rid, "أصناف").ShowDialog();
                    }
                }
            }
            catch { }
        }
        private void btnnew_Click(object sender, EventArgs e)
        {
            BLL.SalePoint.EMpty();
            btnsale.Enabled = false;
            dataGridView1.DataSource = new object();
            combocompany.SelectedValue = Globals.Globals.UnknownClient;
            DefaultState(true);
            btnsale.Enabled = false;

        }

        private void combocompany_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1: addtype_Click(new object(), e); break;
                case Keys.F2: deltype_Click(new object(), e); break;
                case Keys.F3: btnaddfast_Click(new object(), e); break;
                case Keys.F4: btnsubfast_Click(new object(), e); break;
                case Keys.F5: btnnew_Click(new object(), e); break;                
                case Keys.F12: btnsale_Click(new object(), e); break;

            }
            base.OnKeyDown(e);
        }

        private void btnaddfast_Click(object sender, EventArgs e)
        {
            if (_idtype > 0)
            {
                dataGridView1.DataSource = new object();
                dataGridView1.DataSource = BLL.SalePoint.Add(_idtype);
            }
            DefaultState(true);
            BLL.SalePoint.WriteSerolizeMe();
        }

        private void btnsubfast_Click(object sender, EventArgs e)
        {
            if (_idtype > 0)
            {
                dataGridView1.DataSource = new object();
                dataGridView1.DataSource = BLL.SalePoint.Delete(_idtype);
            }
            DefaultState(true);
            BLL.SalePoint.WriteSerolizeMe();
        }
        Font picfontday = new Font("Andalus", 22, FontStyle.Regular, GraphicsUnit.Pixel);
        Color pictureBox1BackColor;
        string nameday = Globals.Globals.GetNameOfDay(); PointF namedaypoint;
        string justdate = MyDateTime.Now.JustDate; PointF justdatepoint;
        PointF Timeponit;
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Bitmap img = global::WeightsOrganizer.Properties.Resources.logo;
      
            e.Graphics.Clear(pictureBox1BackColor);
            e.Graphics.DrawString(nameday, picfontday, Brushes.Blue, namedaypoint);
            e.Graphics.DrawString(justdate, picfontday, Brushes.Red, justdatepoint);
            e.Graphics.DrawString(MyDateTime.Now.Time, picfontday, Brushes.Blue, Timeponit);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1_Paint(pictureBox1, new PaintEventArgs(pictureBox1.CreateGraphics(), pictureBox1.ClientRectangle));
        }
 
    }
}
