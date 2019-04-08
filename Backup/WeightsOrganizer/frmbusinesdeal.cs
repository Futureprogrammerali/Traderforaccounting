using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer
{
    public partial class frmbusinesdeal : FrmMain
    {
        public frmbusinesdeal()
        {
            InitializeComponent();
        }
        public  override void MyRefresh()
        {
            businesDealControl1.MyRefresh();
            base.MyRefresh();
        }
        private void frmbusinesdeal_Load(object sender, EventArgs e)
        {
       businesDealControl1.BDateSource = BLL.BusinesDeal.GetAllBusinesDeal();
 
        }
 
        private void businesDealControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
