using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;

namespace WeightsOrganizer
{
    public partial class Dbaseoperation : FrmMain
    {
        FolderBrowserDialog FolderBrowserDialog = null;
        public Dbaseoperation()
        {
            InitializeComponent();
        }
        private void Dbaseoperation_Load(object sender, EventArgs e)
        {
        
        }
        public void CreateEmptyDataBase()
        {
            try
            {
                textBox2.Text = Globals.Globals.GetPathFromFullname(Application.ExecutablePath);
                this.Show();
                this.Enabled = false;
                string source = textBox2.Text + "\\Empty.mdb";
                string gola = Globals.Globals.GetPathFromFullname(Application.ExecutablePath) + "\\WeightsOrganizer.mdb";
                if (!File.Exists(source)) { System.Windows.Forms.MessageBox.Show("الرجاء التاكد من المدخلات..الملف المصدر"); return; }
                ExportAndImportDbaseAsFile n = new ExportAndImportDbaseAsFile(source, gola);
                fthread = new Thread(new ThreadStart(n.Copy));
                fthread.IsBackground = true;
                fthread.Start();
                timer1.Enabled = true;
            }
            catch { MessageBox.Show("يوجد خطأ"); }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog = new FolderBrowserDialog();
            if (FolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = FolderBrowserDialog.SelectedPath;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog = new FolderBrowserDialog();
            if (FolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = FolderBrowserDialog.SelectedPath;
            }
        }
        Thread fthread;
        private void button1_Click(object sender, EventArgs e)
        {
        
            try
            {
                string source = Globals.Globals.GetPathFromFullname(Application.ExecutablePath) + "\\WeightsOrganizer.mdb";
                string gola = textBox1.Text + "\\WeightsOrganizer.mdb";
                if (!File.Exists(source)) { System.Windows.Forms.MessageBox.Show("الرجاء التاكد من المدخلات..الملف المصدر"); return; }
                ExportAndImportDbaseAsFile n = new ExportAndImportDbaseAsFile(source, gola);
                fthread = new Thread(new ThreadStart(n.Copy));
                fthread.IsBackground = true;
                fthread.Start();
                timer1.Enabled = true;

            }
            catch { MessageBox.Show("يوجد خطأ"); }             
        }
        void Write()
        {
                string path = textBox1.Text+@"\";
                Stream s; BinaryFormatter bf;
                s = File.Open(path+@"Type.dat", FileMode.Create);
                bf = new BinaryFormatter();
                bf.Serialize(s, BLL.BllGlobal.alltypes);
                s.Close();
                s = File.Open(path + @"Cleint.dat", FileMode.Create);
                bf = new BinaryFormatter();
                bf.Serialize(s, BLL.BllGlobal.allclients);
                s.Close();
                s = File.Open(path + @"Compay.dat", FileMode.Create);
                bf = new BinaryFormatter();
                bf.Serialize(s, BLL.BllGlobal.allcomps);
                s.Close();            
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string source = textBox2.Text + "\\WeightsOrganizer.mdb";
                string gola = Globals.Globals.GetPathFromFullname(Application.ExecutablePath) + "\\WeightsOrganizer.mdb";
                if (!File.Exists(source)) { System.Windows.Forms.MessageBox.Show("الرجاء التاكد من المدخلات..الملف المصدر"); return; }
                ExportAndImportDbaseAsFile n = new ExportAndImportDbaseAsFile(source,gola);
                fthread = new Thread(new ThreadStart(n.Copy));
                fthread.IsBackground = true;
                fthread.Start();
                timer1.Enabled = true;
                

            }
            catch { MessageBox.Show("يوجد خطأ"); }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button4.Enabled = false; 
            if (ExportAndImportDbaseAsFile.done == false)
            {
                if (progressBar1.Value == progressBar1.Maximum)
                {
                    progressBar1.Value = progressBar1.Minimum;
                }
                progressBar1.Value++;
            }
            else
            {
                timer1.Enabled = false;
                button1.Enabled = true;
                button4.Enabled = true; 
                progressBar1.Value = progressBar1.Maximum;
                MessageBox.Show("تم نسخ البيانات ..نفضل اغلاق البرنامج وفتحه من جديد");
                WeightsOrganizer.Controls.Righto.GetDataAgain();
                if (frmRealMainForm.FrmTypso!=null) frmRealMainForm.FrmTypso.Close();
               // Application.ExitThread();
            }
        }
        private void Dbaseoperation_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((ExportAndImportDbaseAsFile.done == false) || (ReadBasicInfo.done==false)) e.Cancel = true;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(textBox1.Text)) return;
            try
            {
                Write();
            }
            catch { return; }
            MessageBox.Show("تم نسخ  البيانات");
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(textBox2.Text)) return;
            try
            {
                button1.Enabled = false; button4.Enabled = false;
                button5.Enabled = false; button6.Enabled = false;
                ReadBasicInfo RBI = new ReadBasicInfo(textBox2.Text);
                Thread th = new Thread(new ThreadStart(RBI.Read));
                th.Priority = ThreadPriority.Highest;
                th.Start();
                timer2.Enabled = true;
            }
            catch { timer2.Enabled = false; }
            
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (ReadBasicInfo.done == false)
            {
                if (progressBar1.Value == progressBar1.Maximum)
                {
                    progressBar1.Value = progressBar1.Minimum;
                }
                progressBar1.Value++;
            }
            else
            {
               
                progressBar1.Value = progressBar1.Maximum; 
                if (frmRealMainForm.FrmTypso!=null) frmRealMainForm.FrmTypso.Close();
                button1.Enabled = true; button4.Enabled = true;
                button5.Enabled = true; button6.Enabled = true;
                BLL.BllGlobal.UpdateAll();
                WeightsOrganizer.Controls.Righto.GetDataAgain();
                timer2.Enabled = false;
                MessageBox.Show("تم نسخ البيانات ..نفضل اغلاق البرنامج وفتحه من جديد");
            }
        }
    }
}
