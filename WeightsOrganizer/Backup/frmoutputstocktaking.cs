using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer
{
    public partial class frmoutputstocktaking : FrmMain
    {
        public frmoutputstocktaking()
        {
            InitializeComponent();
        }

        private void frmoutputstocktaking_Load(object sender, EventArgs e)
        {
            stocktakingOutPutControl1.DateSource = BLL.ClientDeal.GetAllClientDeal();
        }
    }
}
