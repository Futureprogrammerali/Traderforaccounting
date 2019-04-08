using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WeightsOrganizer
{
    public partial class frmabout : WeightsOrganizer.FrmMain
    {
       
        public frmabout()
        {
            isFrmDetails = true;
            InitializeComponent();
        }
 
        private void frmabout_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        this.Close();
        }

        private void frmabout_Shown(object sender, EventArgs e)
        {
            this.pictureBox3.Image = Icon.ToBitmap();
        }



     
    }
}
