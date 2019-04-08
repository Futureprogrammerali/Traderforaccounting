using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WeightsOrganizer
{
    public partial class Zero : FrmMain
    {
        public Zero() 
        {
            this.isFrmDetails = true;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           this.Enabled = false;
            Beshure();
            BLL.ClientDeal.DeleteAll();
            BLL.SalesReturns.DeleteAll();
            this.Enabled = true;
        }

        private void Beshure()
        {
            if (MessageBox.Show(" هل تريد تنفيذ الافراغ ؟", "تنبيه ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
            }
            else
            {
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Beshure();
            foreach (BLL.Archives ar in BLL.Archives.GetAllArchives(archivesTypes.Out))
            {
                BLL.Archives.DeleteArchives(ar.ID);    
            }
            this.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Beshure();
            BLL.BusinesDeal.DeleteAll();
            BLL.BusinesReturns.DeleteAll();
            this.Enabled = true  ;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Beshure(); 
            foreach (BLL.Archives ar in BLL.Archives.GetAllArchives(archivesTypes.In))
            {
                BLL.Archives.DeleteArchives(ar.ID);
            }
            this.Enabled = true ;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Beshure(); 
            foreach (BLL.Store ar in BLL.Store.GetAllStore())
            {
                BLL.Store.DeleteStore(ar.ID);
            }
            this.Enabled = true ;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            if (!(File.Exists("Empty.mdb") && File.Exists("WeightsOrganizer.mdb"))) MessageBox.Show("غير قادر على اكمال العملية يوجد نقص في بيانات البرنامج");
            MessageBox.Show("سيتم استبدال قاعدة البيانات الحالية بواحدة فارغة");
            if (MessageBox.Show(" هل تريد تنفيذ الافراغ ؟", "تنبيه ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    File.Delete(@"WeightsOrganizer.mdb");
                }
                catch { MessageBox.Show("لم أستطيع حذف قاعدة البيانات"); return; }
                try
                {
                    //File.Copy("Empty.mdb", "WeightsOrganizer.mdb");
                    Dbaseoperation dbo = new Dbaseoperation();
                    dbo.CreateEmptyDataBase();
                    frmRealMainForm.FrmTypso.MyRefresh();
                    BLL.BllGlobal.UpdateAll();
                    WeightsOrganizer.Controls.Righto.GetDataAgain();
                }
                catch { }
            }
            this.Enabled = true ;
                    }

        private void Zero_Load(object sender, EventArgs e)
        {

        }
    }
}
