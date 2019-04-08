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
    public partial class FrmDetails : FrmMain
    {
        protected  TypesControls xx;
        int _idr = 0;

        public FrmDetails(int idr, string typeo)
        {
            isFrmDetails = true;
            InitializeComponent();
            _idr = idr;
            if (typeo == "أصناف")
            {
                if (!WeightsOrganizer.Controls.LogInOut.State) { txtBusinessPrice.Visible = false; lblprice.Visible = false; }
                xx = TypesControls.VeiwTypesoption; vewtypes();
            }
            else if (typeo == "تجار")
            {
                xx = TypesControls.Veiwcompanyoption; vewcomp();
            }
            else if (typeo == "زبائن")
            {
                xx = TypesControls.Veiwclientoption; vewclnt();
            }
        }

        private void vewclnt()
        {
            this.Text = "معلومات زبون";
            this.label10.Text = "معلومات زبون";
            groupBox1.Visible = true;
            groupBox1.Location = new Point(this.Width / 4, 50);
            BLL.Client tp = BLL.Client.GetClientByID(_idr);
            groupBox1.Controls["textBox1"].Text = tp.Name;
            groupBox1.Controls["txtdet"].Text = tp.Details.ToString();
            groupBox1.Controls["label2"].Text = tp.AddedDate.ToString();
        }

        private void vewcomp()
        {
            this.Text = "معلومات تاجر";
            this.label10.Text = "معلومات تاجر";
            groupBox2.Visible = true;
            groupBox2.Location = new Point(this.Width/4,50);
            BLL.Company tp = BLL.Company.GetCompanyByID(_idr);
            groupBox2.Controls["textBox3"].Text = tp.Name;
            groupBox2.Controls["textBox2"].Text = tp.Details.ToString();
            groupBox2.Controls["label6"].Text = tp.AddedDate.ToString();
        }

        private void FrmDetails_Load(object sender, EventArgs e)
        {
                    
        }

        private void vewtypes()
        {
            try
            {
                this.Text = "معلومات صنف";
                this.label10.Text = "معلومات صنف";
                grouptypes.Visible = true;
                grouptypes.Location = new Point(this.Width / 4, 50);
                BLL.Types tp = BLL.Types.GetTypeByID(_idr);
                grouptypes.Controls["txtname"].Text = tp.Name;
                grouptypes.Controls["txtBusinessPrice"].Text = tp.BusinessPrice.ToString();
                grouptypes.Controls["txtClientPrice"].Text = tp.ClientPrice.ToString();
                grouptypes.Controls["txtprcln"].Text = tp.BusinessClientPrice.ToString();
                grouptypes.Text = "تاريخ الاضافة  "+tp.AddedDate.ToString();
                baraCode128vewier1.Text = tp.BaraCode;
                double amnt = 0; try { amnt = BLL.Store.GetStoreByTypeID(_idr).Amount; }
                catch { }

                grouptypes.Controls["amnto"].Text = "الكمية المتوفرة " + amnt.ToString() + (tp.ArabicUnit);
            }
            catch { }
        }

 

 
 
 
    }
}
