using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer
{
    public partial class frmclienbill : FrmMain
    {

        public frmclienbill()
        {
            InitializeComponent();

        }
 
        public frmclienbill(int Idman)
        {
            InitializeComponent();
           // this.clientbillcontrol1.cmcmps.SelectedValue = Idman;
            this.clientbillcontrol1.SetClient = Idman;
        }
        public frmclienbill(int Idman, bool _isFrmDetails)  
        {

            if (_isFrmDetails) this.isFrmDetails = true; InitializeComponent(); 
            this.clientbillcontrol1.SetClient = Idman; 
        }
        private void frmclienbill_Load(object sender, EventArgs e)
        {
         //clientbillcontrol1.DateSource = BLL.ClientDeal.GetAllClientDeal();
   
        }

        private void clientbillcontrol1_Load(object sender, EventArgs e)
        {

        }
    }
}
