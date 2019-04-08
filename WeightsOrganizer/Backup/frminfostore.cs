using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer
{
    public partial class frminfostore : WeightsOrganizer.FrmMain
    {
        public frminfostore()
        {
            InitializeComponent();
        }
        List<BLL.Store> allstore=new List<WeightsOrganizer.BLL.Store>();
        List<BLL.Types> alltypeavailable = new List<WeightsOrganizer.BLL.Types>();
        double amount = 0;
        double Totalbusprice = 0;
        double Totalcliprice = 0;
        double Totalbuscliprice = 0;
        double aa= 0;
        private void button1_Click(object sender, EventArgs e)
        {
            allstore = BLL.Store.GetAllStore();
            foreach (BLL.Store str in allstore)
            {
                amount+=str.Amount;
            }
            label1.Text = amount.ToString();
            Avilable();
            getlbltot();
            
        }

        private void getlbltot()
        {
             amount = 0;
             Totalbusprice = 0;
             Totalcliprice = 0;
             Totalbuscliprice = 0;
            BLL.Types curtypr = null;
            foreach (BLL.Store str in allstore)
            {
                curtypr = GetTypefrmmstrname(str.TypeName);
                //MessageBox.Show(str.TypeName + " " + str.Amount.ToString());
                //MessageBox.Show(curtypr.Name + " " + curtypr.BusinessPrice.ToString() + " " + curtypr.BusinessClientPrice.ToString() + " " + curtypr.ClientPrice.ToString());

                Totalbusprice += (str.Amount * curtypr.BusinessPrice);
                Totalbuscliprice += (str.Amount * curtypr.BusinessClientPrice);
                Totalcliprice += (str.Amount * curtypr.ClientPrice);
                
 
            }
            lbltotbus.Text = Totalbusprice.ToString();
            lbltotbuscli.Text = Totalbuscliprice.ToString();
            lbltotcli.Text = Totalcliprice.ToString();
        }

        private WeightsOrganizer.BLL.Types GetTypefrmmstrname(string p)
        {
            foreach (BLL.Types curtype in alltypeavailable)
            {
                if (curtype.Name == p) return curtype;
            }
            WeightsOrganizer.BLL.Types typnul = null;
            return typnul;
        }
        void Avilable()
        {
             alltypeavailable = WeightsOrganizer.BLL.Types.GetAllTypesNotavailable();
            label4.Text = alltypeavailable.Count.ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
