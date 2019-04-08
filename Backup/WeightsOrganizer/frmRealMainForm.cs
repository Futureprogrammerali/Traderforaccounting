using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WeightsOrganizer
{
    
    public   enum TypesControls : int
    {
        VeiwTypesoption = 0,
        Veiwstoryoption = 1,
        Veiwclientoption = 2,
        Veiwcompanyoption = 3,All=4
    }
    enum FormTypesControls : int
    {
        frmtypes = 0,
        frmclient = 1,
        frmcomapny = 2,
        frmbusinesdeal = 4,
        frmclienbill = 5,
        frmclientdeal = 6,
        frminputstocktaking = 7,
        frmstore = 8,
        frmoutputstocktaking = 9,
        frmcompanybill=10,
        Checkcleancompany=11,
        Checkcleanclient=12,
        Zero=13,
        SalEpoint = 14, frmSalesReturn = 15, BuyReturns=16
    }
    public partial class frmRealMainForm : FrmMain
    {
        public frmRealMainForm() 
        {
            InitializeComponent();
        }
        bool _RightPanel = false;
        /// <summary>
        /// أداة الرايت حسب اصطلاحي
        /// </summary>
        public bool RightPanelTools
        {
            get { return _RightPanel; }
            set
            {
                _RightPanel = value;
                righto1.Visible = value;
                PnlLeft.Visible = value;
            }
        }
        internal static FrmMain FrmTypso = null;
        public FrmMain FrmoInclude
        {
  
            set {
                frmRealMainForm.FrmTypso = value;
                PleasePrePerE(value.WindowState); 
            }
        }
        private void frmRealMainForm_Load(object sender, EventArgs e)
        {
          this.RightPanelTools = true;
          //this.pictureBox1.Size = new Size(this.ClientSize.Width-righto1.Width,this.ClientSize.Height-50);
        }
        void CreateControlForms(FormTypesControls typesControlso, FormWindowState fw)
        {
            if (FrmTypso != null)
            { FrmTypso.Dispose(); FrmTypso = null; }
            
            switch (typesControlso)
            {   
                case FormTypesControls.frmtypes:
                    {
                        FrmTypso = new frmtypes(); PleasePrePerE(fw); break;
                    }
                case FormTypesControls.frmstore:
                    {
                        FrmTypso = new frmstore(); PleasePrePerE(fw); break;
                    }
                case FormTypesControls.frmcomapny:
                    {
                        FrmTypso = new frmcompany();
                        PleasePrePerE(fw); break;
                    }
                case FormTypesControls.frmclient:
                    {
                        FrmTypso = new frmclients(); PleasePrePerE(fw); break;
                    }
                case FormTypesControls.frmbusinesdeal:
                    {
                        FrmTypso = new frmbusinesdeal();
                        PleasePrePerE(fw); break;
                    }
                case FormTypesControls.frmclienbill:
                    {
                        FrmTypso = new frmclienbill(); PleasePrePerE(fw); break;
                    }
                case FormTypesControls.frmcompanybill:
                    {
                        FrmTypso = new frmcompanybill(); PleasePrePerE(fw); break;
                    }
                case FormTypesControls.frmoutputstocktaking:
                    {
                        FrmTypso = new frmoutputstocktaking(); PleasePrePerE(fw); break;
                    }
                case FormTypesControls.frminputstocktaking:
                    {
                        FrmTypso = new frminputstocktaking(); PleasePrePerE(fw); break;
                    }
                case FormTypesControls.frmclientdeal:
                    {
                        FrmTypso = new frmclientdeal(); PleasePrePerE(fw); break;
                    }

                case FormTypesControls.Zero:
                    {
                        FrmTypso = new Zero(); PleasePrePerE(fw); break;
                    }
                case FormTypesControls.SalEpoint:
                    {
                        FrmTypso =new SalePointFrm(); PleasePrePerE(fw); break;
                    }
                case FormTypesControls.frmSalesReturn:
                    {
                        FrmTypso = new frmSalesReturn(); PleasePrePerE(fw); break;
                    }
                  case FormTypesControls.BuyReturns:
                    {
                        FrmTypso = new frmBuyReturns(); PleasePrePerE(fw); break;
                    } 
            }
        }
        private void CreateControlForms(FormTypesControls typesControlso)
        {
            if (FrmTypso != null)
            { FrmTypso.Dispose(); FrmTypso = null; }
            switch (typesControlso)
            {
                case FormTypesControls.frmtypes:
                    {
                        FrmTypso = new frmtypes(); PleasePrePerE(); break;
                    }
                case FormTypesControls.frmstore:
                    {
                        FrmTypso = new frmstore(); PleasePrePerE(); break;
                    }
                case FormTypesControls.frmcomapny:
                    {
                       FrmTypso = new frmcompany();
                        PleasePrePerE(); break;
                    }
                case FormTypesControls.frmclient:
                    {
                        FrmTypso = new frmclients(); PleasePrePerE(); break;
                    }
                 case FormTypesControls.frmbusinesdeal:
                    {
                        FrmTypso = new frmbusinesdeal();
                        PleasePrePerE(); break;
                    }
                case FormTypesControls.frmclienbill:
                    {
                        FrmTypso = new frmclienbill(); PleasePrePerE(); break;
                    }
               case FormTypesControls.frmcompanybill:
                    {
                        FrmTypso = new frmcompanybill(); PleasePrePerE(); break;
                    }
               case FormTypesControls.frmoutputstocktaking:
                    {
                        FrmTypso = new frmoutputstocktaking(); PleasePrePerE(); break;
                    }
               case FormTypesControls.frminputstocktaking:
                    {
                        FrmTypso = new frminputstocktaking(); PleasePrePerE(); break;
                    }
               case FormTypesControls.frmclientdeal:
                    {
                        FrmTypso = new frmclientdeal(); PleasePrePerE(); break;
                    }
               case FormTypesControls.SalEpoint:
                    {
                        FrmTypso = new SalePointFrm(); PleasePrePerE(); break;
                    }
               case FormTypesControls.frmSalesReturn:
                    {
                        FrmTypso = new frmSalesReturn(); PleasePrePerE(); break;
                    }
               case FormTypesControls.BuyReturns:
                    {
                        FrmTypso = new frmBuyReturns(); PleasePrePerE(); break;
                    }
                      
            }
        }
        private void PleasePrePerE()
        {
  
            if (FrmTypso != null)
            {
 
                FrmTypso.MdiParent = this;
                FrmTypso.FormClosing += new FormClosingEventHandler(FrmTypso_FormClosing);
                FrmTypso.FormBorderStyle = FormBorderStyle.Sizable;
                FrmTypso.MinimizeBox = false;
                FrmTypso.StartPosition = FormStartPosition.CenterScreen;
                FrmTypso.ClientSize = new Size(this.ClientSize.Width - (righto1.Width + 33), this.ClientSize.Height - (30 * 3));
                FrmTypso.Top = PnlLeft.Height;
                FrmTypso.Show();
            }

        }
        private void PleasePrePerE(FormWindowState fw)
        {

            if (FrmTypso != null)
            {
                PnlLeft.Visible = false;
                FrmTypso.MdiParent = this;
                FrmTypso.WindowState = FormWindowState.Normal;
                FrmTypso.FormClosing += new FormClosingEventHandler(FrmTypso_FormClosing);
                FrmTypso.Show();
                FrmTypso.WindowState = fw;
            }

        }
        void FrmTypso_FormClosing(object sender, FormClosingEventArgs e)
        {
        
        }
        private void button2_Click(object sender, EventArgs e)
        {
            CreateControlForms(FormTypesControls.frminputstocktaking);           
        }
        private void button8_Click(object sender, EventArgs e)
        {
            CreateControlForms(FormTypesControls.frmcompanybill);  
        }
        private void btn1(object sender, EventArgs e)
        {
            CreateControlForms(FormTypesControls.frmoutputstocktaking);  
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateControlForms(FormTypesControls.frmtypes);
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateControlForms(FormTypesControls.frmcomapny);   
        }
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateControlForms(FormTypesControls.frmclient);    
        }
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateControlForms(FormTypesControls.SalEpoint);
        }
        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateControlForms(FormTypesControls.frmclienbill); 
        }
        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateControlForms(FormTypesControls.frmclientdeal);   
        }
        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateControlForms(FormTypesControls.frmSalesReturn);
        }
        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateControlForms(FormTypesControls.frmbusinesdeal);

        }
        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateControlForms(FormTypesControls.frmcompanybill);  
        }
        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateControlForms(FormTypesControls.BuyReturns);
        }
        private void typesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateControlForms(FormTypesControls.frmtypes,FormWindowState.Maximized);
        }
        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateControlForms(FormTypesControls.frmcomapny, FormWindowState.Maximized);   
        }
        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateControlForms(FormTypesControls.frmclient, FormWindowState.Maximized);   
        }
        private void storeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            CreateControlForms(FormTypesControls.frmstore, FormWindowState.Maximized);
        }
        private void acountClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateControlForms(FormTypesControls.frmclienbill, FormWindowState.Maximized);
        }
        private void acountCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateControlForms(FormTypesControls.frmcompanybill, FormWindowState.Maximized);
        }
        private void otus2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateControlForms(FormTypesControls.frmclientdeal, FormWindowState.Maximized);
        }
        private void inss2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateControlForms(FormTypesControls.frmbusinesdeal, FormWindowState.Maximized);
        }
        private void outsvewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateControlForms(FormTypesControls.frmoutputstocktaking, FormWindowState.Maximized);
        }
        private void inssviewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateControlForms(FormTypesControls.frminputstocktaking, FormWindowState.Maximized);
        }
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dbaseoperation d = new Dbaseoperation();
            d.ShowDialog();
        }
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dbaseoperation d = new Dbaseoperation();
            d.ShowDialog();
        }
        string titlestrip = "f";
        private void timer1_Tick(object sender, EventArgs e)
        {
        statusStrip1.Items["toolStripStatusLabel5"].Text = MyDateTime.Now.ToString();
        }
        private void jrdalmabeatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSumInput f = new FrmSumInput(Summing.Output);
            f.ShowDialog();
        }
        private void jardalmoshtreaatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSumInput f = new FrmSumInput(Summing.Input);
            f.ShowDialog();
        }
        private void aboutprogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
         frmabout f = new frmabout(); f.ShowDialog();
        }
        private void aboutpToolStripMenuItem_Click(object sender, EventArgs e)
        {
        frmabout f = new frmabout(); f.ShowDialog();
        }
        private void frmRealMainForm_Click(object sender, EventArgs e)
        {
          
        }
        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            aboutprogramToolStripMenuItem_Click(sender, e);
     
        }
        private void arChivToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FrmTypso != null)
            { FrmTypso.Dispose(); FrmTypso = null; }
            FrmTypso = new archives(archivesTypes.Out);
            PleasePrePerE(FormWindowState.Maximized);
        }
        private void arChivinnnnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FrmTypso != null)
            { FrmTypso.Dispose(); FrmTypso = null; }
            FrmTypso  = new archives(archivesTypes.In);
            PleasePrePerE(FormWindowState.Maximized);
        
        }
        private void trancatedataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zero frm = new Zero(); frm.ShowDialog();
        }
        private void grpclintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { frmGroupCleinDeal frm = new frmGroupCleinDeal(true); frm.ShowDialog(); }
            catch { }
        }
        private void grpcompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGroupcompanyDeal frm = new frmGroupcompanyDeal(true); frm.ShowDialog();
        } 
        private void salePointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateControlForms(FormTypesControls.SalEpoint, FormWindowState.Maximized);
           
        }
        private void salesReturnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateControlForms(FormTypesControls.frmSalesReturn, FormWindowState.Maximized);
        }
        private void buyReturnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateControlForms(FormTypesControls.BuyReturns, FormWindowState.Maximized);
        }
        private void seto1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingUi frm = new SettingUi();
            frm.ShowDialog();
        }
        private void barcodedesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaraCodeDesigner Bd = new BaraCodeDesigner();
            Bd.ShowDialog();
        }
        private void fatorabedamortaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { frmGroupSalesReturn frm = new frmGroupSalesReturn(true); frm.ShowDialog(); }
            catch { }
        }
        private void fatorabedamoshtraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { frmBuyReturnsGroup frm = new frmBuyReturnsGroup(true); frm.ShowDialog(); }
            catch { }
        }
        private void frmRealMainForm_Shown(object sender, EventArgs e)
        {
          //  this.pictureBox1.Size = new Size(this.Width / 2+20, this.Height / 2+20);
          //  this.pictureBox1.Location = new Point(this.Width / 4, this.Height / 4);
            if (Globals.Globals.is_i_am_in_memory)
            {
                Application.Exit();
                Application.ExitThread();
            }
        }
       public void Repaint()
        {
            frmRealMainForm_Paint(this, new PaintEventArgs(this.CreateGraphics(), this.ClientRectangle));
        }
        private void frmRealMainForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripMenuItemrefresh_Click(object sender, EventArgs e)
        {
            FrmTypso.MyRefresh();
        }

        private void toolStripMenuItemclose_Click(object sender, EventArgs e)
        {
            FrmTypso.Close();
        } 
 
    }
}
