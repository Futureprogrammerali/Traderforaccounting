using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer
{
    public partial class frminputstocktaking : FrmMain
    {
        public frminputstocktaking()
        {
            InitializeComponent();
        }

        private void frminputstocktaking_Load(object sender, EventArgs e)
        {
            stocktakingInputControl1.DateSource = BLL.BusinesDeal.GetAllBusinesDeal();
        }
    }
}
