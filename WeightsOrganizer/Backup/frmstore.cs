using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer
{
    public partial class frmstore : FrmMain
    {
        public frmstore()
        {
            InitializeComponent();
        }

        private void frmstore_Load(object sender, EventArgs e)
        {


            storeview1.DateSource = BLL.Store.GetAllStore();
    
     
        }


    }
}
