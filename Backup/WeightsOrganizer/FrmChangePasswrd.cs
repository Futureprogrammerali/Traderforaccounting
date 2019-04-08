using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer
{
    public partial class FrmChangePasswrd : WeightsOrganizer.FrmMain
    {
        public FrmChangePasswrd()
        {
            isFrmDetails = true; InitializeComponent(); 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = (textBox1.Text.Length > 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Globals.Globals.PassWord == textBox2.Text)
            {
                if (textBox1.Text.Length > 0)
                {
                    Globals.Globals.PassWord = textBox1.Text;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("خطأ ادخال كلمة المرور الحالية");
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                textBox1.Enabled = true;
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            char pwch ;
            if (checkBox1.Checked) pwch=new char();else pwch='*';
            textBox1.PasswordChar = textBox2.PasswordChar = pwch;
        }

        private void FrmChangePasswrd_Load(object sender, EventArgs e)
        {
        
        }
    }
}
