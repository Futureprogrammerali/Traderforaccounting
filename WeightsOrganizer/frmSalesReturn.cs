using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer
{
    public partial class frmSalesReturn : WeightsOrganizer.FrmMain
    {
        public frmSalesReturn()
        {
            InitializeComponent();
        }

        public override void MyRefresh()
        {
            salesReturns1.MyRefresh();
            base.MyRefresh();
        }
        private void frmSalesReturn_Load(object sender, EventArgs e)
        {

            salesReturns1.BDateSource = BLL.SalesReturns.GetAllClientDeal();
        }
    }
}
