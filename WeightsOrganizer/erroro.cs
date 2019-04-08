using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;


namespace WeightsOrganizer
{
    public partial class 
        erroro : Form
    {
        public erroro()
        {
            InitializeComponent();
        }
       public  static string Processorid
        {
          
            get
            {
                string x = "Fu0991tu30re96pro95gra19mm88er2020";
                ManagementObjectSearcher cpus = new System.Management.ManagementObjectSearcher("Select * From Win32_Processor");
                ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select * From Win32_BaseBoard");
                ManagementObjectSearcher bioss = new ManagementObjectSearcher("Select * From Win32_Bios");
                foreach (System.Management.ManagementObject cpu in cpus.Get())
                {
                    x += cpu["Processorid"].ToString() + "*";
                }
                foreach (ManagementObject mo in mbs.Get())
                {
                    x += mo["SerialNumber"].ToString() + "*";
                }
                foreach (ManagementObject bio in bioss.Get())
                {
                    x += bio["SerialNumber"].ToString() + "*";
                }
                return x;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                button1.Enabled = false;
                if (numbertextbox1.Text== Processorid)
                {
                 Globals.Globals.NotSafe = false;
                }
                else
                {
                    Application.Exit();
                    Application.ExitThread();
                }
                this.Close();
            }
            catch { }
            button1.Enabled = true;
        }
        private void numbertextbox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled=(numbertextbox1.Text.Length>5 ? true : false);
        }
        private void erroro_Load(object sender, EventArgs e)
        {
          
            this.textBox1.Text = Globals.Globals.Encrypt(Processorid,2014);
            frmRealMainForm r = new frmRealMainForm();
            this.Icon = r.Icon;
            r.Dispose();
        }              
        private void erroro_FormClosing(object sender, FormClosingEventArgs e)
        {
         if (Globals.Globals.NotSafe){
             Application.Exit();
            Application.ExitThread();
         }
        }
        private void numbertextbox1_TextChanged_1(object sender, EventArgs e)
        {
            button1.Enabled = (numbertextbox1.Text.Length>10 ? true : false);
        }
    }
}
