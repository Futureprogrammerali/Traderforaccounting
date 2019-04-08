using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer
{
    public partial class frmtypes : FrmMain
    {
        public frmtypes()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            typesControl1.DateSource = BLL.Types.GetAllTypes();
        }
    public    override void MyRefresh()
        {
            try { typesControl1.DateSource = BLL.Types.GetAllTypes(); }
            catch { }
        }
        private void typesControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
