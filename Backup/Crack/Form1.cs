using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;

namespace Crack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                textBox2.Text =  Decrypt(textBox1.Text, 2014);
            }
            catch { }
            button1.Enabled = true;
        }
        //public string Processorid
        //{
        //    get
        //    {
        //        string x = "Fu0991tu30re96pro95gra19mm88er2020";
        //        ManagementObjectSearcher cpus = new System.Management.ManagementObjectSearcher("Select * From Win32_Processor");
        //        ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select * From Win32_BaseBoard");
        //        ManagementObjectSearcher bioss = new ManagementObjectSearcher("Select * From Win32_Bios");
        //        foreach (System.Management.ManagementObject cpu in cpus.Get())
        //        {
        //            x += cpu["Processorid"].ToString()+"*";   
        //        }
        //        foreach (ManagementObject mo in mbs.Get())
        //        {
        //            x += mo["SerialNumber"].ToString() + "*";
        //        }
        //        foreach (ManagementObject bio in bioss.Get())
        //        {
        //            x += bio["SerialNumber"].ToString() + "*";
        //        }

        //        return x;
        //    }

        //}


        internal static string Encrypt(string source, int theKey)
        {
            int counter;
            Random jumbleMethod = new Random(theKey);

            byte[] keySet = new byte[source.Length - 1];
            byte[] sourceBytes = System.Text.Encoding.UTF8.GetBytes(source);
            jumbleMethod.NextBytes(keySet);

            for (counter = 0; counter < sourceBytes.Length - 1; counter++)
            {
                sourceBytes[counter] = (byte)(sourceBytes[counter] ^ keySet[counter]);
            }

            return Convert.ToBase64String(sourceBytes);
        }

        internal static string Decrypt(string source, int theKey)
        {
            int counter;
            Random jumbleMethod = new Random(theKey);
            byte[] sourceBytes = Convert.FromBase64String(source);
            byte[] keySet = new byte[source.Length - 1];

            jumbleMethod.NextBytes(keySet);
            for (counter = 0; counter < sourceBytes.Length - 1; counter++)
            {
                sourceBytes[counter] = (byte)(sourceBytes[counter] ^ keySet[counter]);
            }


            return System.Text.Encoding.UTF8.GetString(sourceBytes);
        }
    }
}
