using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer
{
    public partial class frmcompanybill : FrmMain
    {
        public frmcompanybill()
        {
            InitializeComponent();
        }
        public frmcompanybill(int Idman) 
        {
            InitializeComponent();
           // this.clientbillcontrol1.cmcmps.SelectedValue = Idman;
            this.companybillcontrol1.SetClient = Idman;
            
        }
        public frmcompanybill(int Idman, bool _isFrmDetails) 
        {
         
            this.AdminSavo(this);
            if (_isFrmDetails) this.isFrmDetails = true;
            InitializeComponent();
            this.companybillcontrol1.SetClient = Idman;
        }
        private void frmcompanybill_Load(object sender, EventArgs e)
        {
           //companybillcontrol1.DateSource = BLL.BusinesDeal.GetAllBusinesDeal();
        }
    }
}
