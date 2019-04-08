using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer.Controls
{
    public partial class LogInOut : UserControl
    {
        public LogInOut()
        {
            InitializeComponent();
            
        }
        static bool _IsIn = false;
        private bool IsIn
        {
            get { return _IsIn; }
            set
            {
                _IsIn = value;
                if (value)
                {
                    linkLabel1.Visible = true;
                    linkLabel2.Visible = true;
                    textBox1.Visible = false;
                    pictureBox1.Image = global::WeightsOrganizer.Properties.Resources._in;
                }
                else
                {
                    linkLabel1.Visible = false;
                    linkLabel2.Visible = false;
                    textBox1.Visible = true;
                    textBox1.Text = "كلمة مرور المدير";
                    pictureBox1.Image = global::WeightsOrganizer.Properties.Resources._out;
                }
            }
        }

        private void LogIn()
        {
            Test(textBox1.Text);
 
        }
        private void LogOut()
        {
            if (MessageBox.Show("هل تريد تسجيل الخروج من وضع المدير ؟", "تسجيل خروج مدير", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                IsIn = false;
                try { if (frmRealMainForm.FrmTypso != null)  frmRealMainForm.FrmTypso.Close(); }
                catch  { }
            }
          
        }
        private void Test(string password)
        {
            if (Globals.Globals.PassWord == password) IsIn = true;
            else { MessageBox.Show("كلمة المرور خطأ", "عذرا", MessageBoxButtons.OK); textBox1.SelectAll(); }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
         Modify();
        }
        public static bool State
        {
            get { return _IsIn; }
        }
        private void Modify()
        {
            FrmChangePasswrd frm = new FrmChangePasswrd();
            frm.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LogIn();
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (IsIn == true)
            {
                LogOut();
            }
            else
            {
                LogIn();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1_Click(sender, (EventArgs)e);
        }
    }
}
