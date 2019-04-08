using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer
{
    public partial class frmclients : FrmMain
    {
        public frmclients()
        {
            InitializeComponent();
          
        }
        private void frmclients_Load(object sender, EventArgs e) 
        {
            clientcontrol1.DateSource = BLL.Client.GetAllClient();
             
        }

        private void frmclients_Click(object sender, EventArgs e)
        {
   
        }

        private void frmclients_KeyUp(object sender, KeyEventArgs e)
        {
          
        }
    }
}
