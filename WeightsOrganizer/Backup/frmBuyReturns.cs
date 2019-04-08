using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer
{
    public partial class frmBuyReturns : WeightsOrganizer.FrmMain
    {
        public frmBuyReturns()
        {
            InitializeComponent();
        }
        public override void MyRefresh()
        {
       buyReturns1.MyRefresh();
       base.MyRefresh();
        }
        private void frmBuyReturns_Load(object sender, EventArgs e)
        {
        buyReturns1.BDateSource = BLL.BusinesReturns.GetAllBusinesDeal();
        }
    }
}
