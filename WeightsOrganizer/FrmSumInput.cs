using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer
{
    public enum Summing : int
    {
       Input=0,Output=1 
    }
    public partial class FrmSumInput : FrmMain
    {
        Summing s;  
        public FrmSumInput(Summing Summings)
        {
            this.isFrmDetails = true;
            s = Summings; 
            InitializeComponent();
            string strfrmtyep;
            bool x = (s == Summing.Output ? true : false);
            if (!x) { strfrmtyep = "احصاء المشتريات"; button1.Text = "نسخ النتائج لأرشيف المشتريات";
            Nstat.Text = "مشتريات";
            RNstat.Text = "مرود مشتريات";
            label3.Text = "صافي المشتريات";
            }
            else { strfrmtyep = "احصاء المبيعات"; button1.Text = "نسخ النتائج لأرشيف المبيعات";
            Nstat.Text = "مبيعات";
            RNstat.Text = "مرود مبيعات";
            
            }
          this.Text = strfrmtyep;
          label1.Text = strfrmtyep;
          lblproffit.Visible = x; label12.Visible = x;
          rlblproffit.Visible = x;
          safilblprofit.Visible = x;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Visible = !(radioButton1.Checked);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Visible = !(radioButton1.Checked);
        }


        private void Inputoo( )
        {

            if (radiotypwithdte.Checked)
            {
                this.lblamnt.Text = (BLL.BusinesDeal.GetAllAmount(int.Parse(cmtyps.SelectedValue.ToString()), dateTimePicker1.Value, dateTimePicker2.Value)).ToString();
               this.rlblamnt.Text = (BLL.BusinesReturns.GetAllAmount(int.Parse(cmtyps.SelectedValue.ToString()), dateTimePicker1.Value, dateTimePicker2.Value)).ToString();
                this.lbltotprice.Text = (BLL.BusinesDeal.GetAllTotalPrice(int.Parse(cmtyps.SelectedValue.ToString()), dateTimePicker1.Value, dateTimePicker2.Value)).ToString();
                 this.rlbltotprice.Text = (BLL.BusinesReturns.GetAllTotalPrice(int.Parse(cmtyps.SelectedValue.ToString()), dateTimePicker1.Value, dateTimePicker2.Value)).ToString();
                dataGridViewino.DataSource = BLL.BusinesDeal.Search(dateTimePicker1.Value, dateTimePicker2.Value, int.Parse(cmtyps.SelectedValue.ToString()));
                dataGridViewino.Visible = true;
                dataGridViewouto.Visible = false;
            }
            if (radiotyp.Checked)
            {
                dataGridViewino.DataSource = BLL.BusinesDeal.Search(int.Parse( cmtyps.SelectedValue.ToString()));
                dataGridViewino.Visible = true;
                dataGridViewouto.Visible = false;
                this.lblamnt.Text = (BLL.BusinesDeal.GetAllAmount(int.Parse(cmtyps.SelectedValue.ToString()))).ToString();
                this.rlblamnt.Text = (BLL.BusinesReturns.GetAllAmount(int.Parse(cmtyps.SelectedValue.ToString()))).ToString();
                this.lbltotprice.Text = (BLL.BusinesDeal.GetAllTotalPrice(int.Parse(cmtyps.SelectedValue.ToString()))).ToString();
                this.rlbltotprice.Text = (BLL.BusinesReturns.GetAllTotalPrice(int.Parse(cmtyps.SelectedValue.ToString()))).ToString();

            }



            if (radiodte.Checked)
            {
                if (radioButton2.Checked)
                {
                 //   MessageBox.Show("3333333");
                    dataGridViewino.DataSource = BLL.BusinesDeal.Search(dateTimePicker1.Value, dateTimePicker2.Value);
                    dataGridViewino.Visible = true;
                    dataGridViewouto.Visible = false;
                    this.lblamnt.Text = (BLL.BusinesDeal.GetAllAmount(dateTimePicker1.Value, dateTimePicker2.Value)).ToString();
                    this.rlblamnt.Text = (BLL.BusinesReturns.GetAllAmount(dateTimePicker1.Value, dateTimePicker2.Value)).ToString();
                    this.lbltotprice.Text = (BLL.BusinesDeal.GetAllTotalPrice(dateTimePicker1.Value, dateTimePicker2.Value)).ToString();
                    this.rlbltotprice.Text = (BLL.BusinesReturns.GetAllTotalPrice(dateTimePicker1.Value, dateTimePicker2.Value)).ToString();
                }
                else
                {
                   // MessageBox.Show("4444444444444444");
                    dataGridViewino.DataSource = BLL.BusinesDeal.Search(dateTimePicker1.Value, dateTimePicker1.Value);
                    dataGridViewino.Visible = true;
                    dataGridViewouto.Visible = false;
                    this.lblamnt.Text = (BLL.BusinesDeal.GetAllAmount(dateTimePicker1.Value)).ToString();
                    this.rlblamnt.Text = (BLL.BusinesReturns.GetAllAmount(dateTimePicker1.Value)).ToString();
                    this.lbltotprice.Text = (BLL.BusinesDeal.GetAllTotalPrice(dateTimePicker1.Value, dateTimePicker1.Value)).ToString();
                    this.rlbltotprice.Text = (BLL.BusinesReturns.GetAllTotalPrice(dateTimePicker1.Value, dateTimePicker1.Value)).ToString();
                }
            }
        
            
        }
        void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;  
         if(s==Summing.Input)   Inputoo();
            else Outputoo();
         CalcSafiProfit();
         button1.Enabled = true;
         button2.Enabled = true;
        }

        private void CalcSafiProfit()
        {
            safiamnt.Text = (double.Parse(lblamnt.Text) - double.Parse(rlblamnt.Text)).ToString();
            safilbltotprice.Text = (double.Parse(lbltotprice.Text) - double.Parse(rlbltotprice.Text)).ToString();
            safilblprofit.Text = (double.Parse(lblproffit.Text) - double.Parse(rlblproffit.Text)).ToString();
        }

        private void Outputoo()
{

 if (radiotypwithdte.Checked)
            {
              //  MessageBox.Show("11");
                this.lblamnt.Text = (BLL.ClientDeal.GetAllAmount(int.Parse(cmtyps.SelectedValue.ToString()), dateTimePicker1.Value, dateTimePicker2.Value)).ToString();
                this.rlblamnt.Text = (BLL.SalesReturns.GetAllAmount(int.Parse(cmtyps.SelectedValue.ToString()), dateTimePicker1.Value, dateTimePicker2.Value)).ToString();
                this.lbltotprice.Text = (BLL.ClientDeal.GetAllTotalPrice(int.Parse(cmtyps.SelectedValue.ToString()), dateTimePicker1.Value, dateTimePicker2.Value)).ToString();
                this.rlbltotprice.Text = (BLL.SalesReturns.GetAllTotalPrice(int.Parse(cmtyps.SelectedValue.ToString()), dateTimePicker1.Value, dateTimePicker2.Value)).ToString();
                this.lblproffit.Text = (BLL.ClientDeal.GetAllProfit(int.Parse(cmtyps.SelectedValue.ToString()), dateTimePicker1.Value, dateTimePicker2.Value)).ToString();
                this.rlblproffit.Text = (BLL.SalesReturns.GetAllProfit(int.Parse(cmtyps.SelectedValue.ToString()), dateTimePicker1.Value, dateTimePicker2.Value)).ToString();
                dataGridViewouto.DataSource = BLL.ClientDeal.SearchClientDeals(dateTimePicker1.Value, dateTimePicker2.Value, int.Parse(cmtyps.SelectedValue.ToString()));
                dataGridViewouto.Visible = true;
                dataGridViewino.Visible = false;
            }
            if (radiotyp.Checked)
            {
              //  MessageBox.Show("222");
                this.lblamnt.Text = (BLL.ClientDeal.GetAllAmount(int.Parse(cmtyps.SelectedValue.ToString()))).ToString();
                this.rlblamnt.Text = (BLL.SalesReturns.GetAllAmount(int.Parse(cmtyps.SelectedValue.ToString()))).ToString();
                this.lbltotprice.Text = (BLL.ClientDeal.GetAllTotalPrice(int.Parse(cmtyps.SelectedValue.ToString()))).ToString();
                this.rlbltotprice.Text = (BLL.SalesReturns.GetAllTotalPrice(int.Parse(cmtyps.SelectedValue.ToString()))).ToString();

                this.lblproffit.Text = (BLL.ClientDeal.GetAllProfit(int.Parse(cmtyps.SelectedValue.ToString()))).ToString();
                this.rlblproffit.Text = (BLL.SalesReturns.GetAllProfit(int.Parse(cmtyps.SelectedValue.ToString()))).ToString();
           dataGridViewouto.DataSource = BLL.ClientDeal.SearchClientDeals(int.Parse(cmtyps.SelectedValue.ToString()));
           dataGridViewouto.Visible = true;
           dataGridViewino.Visible = false;
            }



            if (radiodte.Checked)
            {
                //// MessageBox.Show("33");
                if (radioButton2.Checked){
                    this.lblamnt.Text = (BLL.ClientDeal.GetAllAmount(dateTimePicker1.Value, dateTimePicker2.Value)).ToString();
                    this.rlblamnt.Text = (BLL.SalesReturns.GetAllAmount(dateTimePicker1.Value, dateTimePicker2.Value)).ToString();
                    this.lbltotprice.Text = (BLL.ClientDeal.GetAllTotalPrice(dateTimePicker1.Value, dateTimePicker2.Value)).ToString();
                    this.rlbltotprice.Text = (BLL.SalesReturns.GetAllTotalPrice(dateTimePicker1.Value, dateTimePicker2.Value)).ToString();


                    this.lblproffit.Text = (BLL.ClientDeal.GetAllProfit(dateTimePicker1.Value, dateTimePicker2.Value)).ToString();
                    this.rlblproffit.Text = (BLL.SalesReturns.GetAllProfit(dateTimePicker1.Value, dateTimePicker2.Value)).ToString();
                    dataGridViewouto.DataSource = BLL.ClientDeal.SearchClientDeals(dateTimePicker1.Value, dateTimePicker2.Value);
                    dataGridViewouto.Visible = true;
                    dataGridViewino.Visible = false;
            }
            else
                {
                   /// MessageBox.Show("4444444444444444");
                    this.lblamnt.Text = (BLL.ClientDeal.GetAllAmount(dateTimePicker1.Value, dateTimePicker1.Value)).ToString();
                    this.rlblamnt.Text = (BLL.SalesReturns.GetAllAmount(dateTimePicker1.Value, dateTimePicker1.Value)).ToString();
                    this.lbltotprice.Text = (BLL.ClientDeal.GetAllTotalPrice(dateTimePicker1.Value, dateTimePicker1.Value)).ToString(); 
                    this.lblproffit.Text = (BLL.ClientDeal.GetAllProfit(dateTimePicker1.Value, dateTimePicker1.Value)).ToString();
                    this.rlbltotprice.Text = (BLL.SalesReturns.GetAllTotalPrice(dateTimePicker1.Value, dateTimePicker1.Value)).ToString();
                    this.lblproffit.Text = (BLL.ClientDeal.GetAllProfit(dateTimePicker1.Value, dateTimePicker1.Value)).ToString();
                    this.rlblproffit.Text = (BLL.SalesReturns.GetAllProfit(dateTimePicker1.Value, dateTimePicker1.Value)).ToString();
                    dataGridViewouto.DataSource = BLL.ClientDeal.SearchClientDeals(dateTimePicker1.Value, dateTimePicker1.Value);
                    dataGridViewouto.Visible = true;
                    dataGridViewino.Visible = false;
            }
        }
}

       

 
        private void FrmSumInput_Load(object sender, EventArgs e)
        {
            cmtyps.DataSource = BLL.BllGlobal.alltypes;
            cmtyps.DisplayMember = "Name";
            cmtyps.ValueMember = "ID";
 
        }

        private void radiotyp_CheckedChanged(object sender, EventArgs e)
        {
            cmtyps.Enabled = true;
            dateTimePicker1.Enabled = dateTimePicker2.Enabled = false;
            label2.Text = "صنف فقط";
        }

        private void radiodte_CheckedChanged(object sender, EventArgs e)
        {
            cmtyps.Enabled = false;
            dateTimePicker1.Enabled = dateTimePicker2.Enabled = true;
            label2.Text = " تاريخ  او تاريخين محددين";
        }

        private void radiotypwithdte_CheckedChanged(object sender, EventArgs e)
        {
            cmtyps.Enabled = true;
            dateTimePicker1.Enabled = dateTimePicker2.Enabled = true;
            radioButton2.Checked = true;
            label2.Text = "صنف وتاريخين";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            bool go = false;
            string strx="صنف فقط";
            byte x=0;
            if (radiotyp.Checked) { x = 0; strx ="على "+ cmtyps.Text; }
            if (radiodte.Checked) { x = 1; strx ="في "+ new MyDateTime(dateTimePicker1.Value).ToString() + " , " + new MyDateTime(dateTimePicker2.Value); }
            if (radiotypwithdte.Checked) { x = 2; strx = "على " + cmtyps.Text + " " + "في " + new MyDateTime(dateTimePicker1.Value).ToString() + " , " + new MyDateTime(dateTimePicker2.Value); }
            string deto = "أجرينا احصاء :"+strx;
            MyDateTime mydtenew = new MyDateTime(dateTimePicker1.Value);
            if(MessageBox.Show("هل تريد الانتقال للأرشــــيف؟","تم نسخ النتائج",MessageBoxButtons.YesNo)==DialogResult.Yes) go=true;
            if (radioButton2.Checked) mydtenew = new MyDateTime(dateTimePicker2.Value);
            if (s == Summing.Output)
            {
                BLL.Archives.InsertArchives(1, x, double.Parse(safiamnt.Text), double.Parse(safilbltotprice.Text),
               double.Parse("0"), double.Parse("0"), double.Parse(safilblprofit.Text),
               new MyDateTime(dateTimePicker1.Value), mydtenew, MyDateTime.Now, deto);
                if (go) new archives(archivesTypes.Out).ShowDialog();
            }
            else
            {
                BLL.Archives.InsertArchives(0, x, double.Parse(safiamnt.Text), double.Parse(safilbltotprice.Text),
double.Parse("0"), double.Parse("0"), 0,
new MyDateTime(dateTimePicker1.Value), mydtenew, MyDateTime.Now, deto);
                if (go) new archives(archivesTypes.In).ShowDialog();
            }
        }
    }
}
