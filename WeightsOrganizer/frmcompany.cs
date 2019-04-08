using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer
{
    public partial class frmcompany : FrmMain
    {
        public frmcompany()
        {
            InitializeComponent();
          
        }
        private void frmcompany_Load(object sender, EventArgs e) 
        {
            this.companyControl1.DateSource = BLL.Company.GetAllCompany();
        }
 
    }
}
