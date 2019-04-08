using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer
{
    public partial class frmclientdeal : FrmMain
    {
        public frmclientdeal()
        {
            InitializeComponent();
        }
        public override void MyRefresh()
        {
            clientDealControl1.MyRefresh();
            base.MyRefresh();
        }
        private void frmclientdeal_Load(object sender, EventArgs e)
        {
          clientDealControl1.BDateSource = BLL.ClientDeal.GetAllClientDeal();
        }
    }
}
