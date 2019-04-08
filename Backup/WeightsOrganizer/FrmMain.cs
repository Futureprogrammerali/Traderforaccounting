using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.IO;

namespace WeightsOrganizer
{
    enum Mode
    {
        Insert, Update
    }
    public partial class FrmMain : Form
    {
        static Font _FontApp = null;
        public static Font FontApp
        {
            get
            {
                if (_FontApp == null) _FontApp = Globals.Globals.FontApp;
                return _FontApp; }
            set { _FontApp = value; Globals.Globals.FontApp = value ; }
        }
        bool _FrmDetails = false;
        public bool isFrmDetails
     {
         get { return _FrmDetails; }
         set { _FrmDetails = value; }
     }
        protected void CloseMYY(object sender, EventArgs e)
        {
            if (!((this.GetType().ToString().Equals("WeightsOrganizer.frmRealMainForm")) || (this.GetType().ToString().Equals("WeightsOrganizer.FrmMain"))))
            {
                this.Close();
            }
        }
        protected virtual void AdminSavo(Object sender)
        {
            if (!WeightsOrganizer.Controls.LogInOut.State)
            {
                switch (sender.GetType().Name)
                {
                    case "frmtypes": msgsqrt(); break;
                    case "frmbusinesdeal": msgsqrt(); break;
                    case "frmstore": msgsqrt(); break;
                    case "frminputstocktaking": msgsqrt(); break;
                    case "frmoutputstocktaking": msgsqrt(); break;
                    case "FrmSumInput": msgsqrt(); break;
                    case "archives": msgsqrt(); break;
                    case "Dbaseoperation": msgsqrt(); break;
                    case "Zero": msgsqrt(); break;
                    case "frmcompany": msgsqrt(); break;
                    case "frmcompanybill": msgsqrt(); break;
                    case "frmGroupcompanyDeal": msgsqrt(); break;
                    case "frmBuyReturns": msgsqrt(); break;
                    case "frmBuyReturnsGroup": msgsqrt(); break;
                    case "SettingUi": msgsqrt(); break;
                }
            }
        }
        private void msgsqrt()
        {
            try
            {
                this.Enabled = false;   try
            {
                (frmRealMainForm.ActiveForm.FindForm() as frmRealMainForm).logInOut1.BackColor = Color.Red;
            }
                catch { }
                MessageBox.Show("عليك تسجيل الدخول كمدير", "تنبيه ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   try
            {   (frmRealMainForm.ActiveForm.FindForm() as frmRealMainForm).logInOut1.BackColor = Color.Black;
            (frmRealMainForm.ActiveForm.FindForm() as frmRealMainForm).logInOut1.Focus();
            }
                   catch { }
                this.Close();
            }
            catch { }
        }
        public FrmMain()
        {
           InitializeComponent();
           this.Font = FontApp;
           if (this is  frmRealMainForm) this.ShowIcon = true;
           if (!((this is frmRealMainForm )||(this is SalePointFrm))) Globals.Globals.DeleteFatora();
           try { if (!(this is frmRealMainForm) && (!(this is FrmDetails))) (frmRealMainForm.ActiveForm.FindForm() as frmRealMainForm).pictureBox1.Visible = false; }
           catch { }
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (!(this is frmRealMainForm))
            {
            PrepeareStyle(this);
            }
            else
            {
           Globals.Globals.SetLang(Globals.Globals.LanguageCurunet.Split('=')[1]);
            }
        }
        protected void PrepeareStyle( Control mainctrl)
        {
             if(mainctrl==null) return ;
                foreach (Control cr in mainctrl.Controls)
                {
                    if (cr.Controls.Count > 0) PrepeareStyle(cr);
                    if (cr is DataGridView) PrepeareStyleo((cr as DataGridView));
                    if (cr is WeightsOrganizer.Controls.BaraCode128vewier) PrepeareStyleo((cr as WeightsOrganizer.Controls.BaraCode128vewier));
                }                 
        }
        private void PrepeareStyleo(WeightsOrganizer.Controls.BaraCode128vewier baraCode128vewier)
        {
            baraCode128vewier.FocusMy();
        }
        private void PrepeareStyleo( DataGridView x)
        {
            int xWidth= x.Width;
            int ascription = 10;
            int clmncount = GetVisibleColumn(ref x);
            switch (clmncount)
            {
                case 1: ascription = 100; break;
                case 2: ascription = 50; break;
                case 3: ascription = 33; break;
                case 4: ascription = 25; break;
                case 5: ascription = 20; break;
                case 6: ascription = 16; break;
                case 7: ascription = 14; break;
                case 8: ascription = 12; break;
                case 9: ascription = 11; break;
                default: ascription = 11; break;
            }
            foreach (DataGridViewColumn clmn in x.Columns)
            {
                if (clmn.Visible) clmn.Width = (xWidth * ascription) / 100;
            }
      
        }
        private int GetVisibleColumn(ref DataGridView x)
        {
            int xo = 0;
            foreach (DataGridViewColumn clmn in x.Columns)
            {
             if (clmn.Visible) xo++;
            }
            return xo;
        }
        public void FrmMain_Resize(object sender, EventArgs e)
        {
            if (!(sender is frmRealMainForm))
            {
                try
                {
                    PrepeareStyle(this);
                    if (!(sender is frmRealMainForm))
                    {
                        if (!isFrmDetails)
                        {
                            if (this.WindowState == FormWindowState.Maximized)
                            {
                           
                                (frmRealMainForm.ActiveForm as frmRealMainForm).RightPanelTools = false;
                            }
                            else
                            {
                                (frmRealMainForm.ActiveForm as frmRealMainForm).RightPanelTools = true;
                            }
                        }
                    }
                }
                catch { }
            }
        }
        protected virtual void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Globals.Globals.DeleteFatora();
            if (sender.ToString().Contains("frmRealMainForm"))
            {
                if (MessageBox.Show("هل تريد الخروج من البرنامج ؟", "اغلاق برنامج التاجر", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                try { (frmRealMainForm.ActiveForm.FindForm() as frmRealMainForm).pictureBox1.Visible = true; }
                catch { }
            }
        }
        public  virtual void MyRefresh()
        {
            this.Refresh();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape: CloseMYY(new object(), e); break;
            }
            base.OnKeyDown(e);
        }
        private void FrmMain_Shown(object sender, EventArgs e)
        {
            if (!(this is frmRealMainForm)) AdminSavo(this);
        }
    }
}
