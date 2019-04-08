using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer
{
    public partial class SettingUi : WeightsOrganizer.FrmMain
    {
        public SettingUi()
        {
            this.isFrmDetails = true;
            InitializeComponent();
        }

        private void SettingUi_Load(object sender, EventArgs e)
        {
        comboBoxcasher.DataSource = Globals.Globals.AllPrintersNames;
        comboBoxbaracode.DataSource = Globals.Globals.AllPrintersNames;
       if(Globals.Globals.CasherPrinter!="-1") comboBoxcasher.SelectedItem = Globals.Globals.CasherPrinter;
       if (Globals.Globals.BaraCodePrinter != "-1") comboBoxbaracode.SelectedItem = Globals.Globals.BaraCodePrinter;
       checkBox1.Checked = Globals.Globals.PrintWhenSell;
       checkBox2.Checked = Globals.Globals.PrintWhenBuy;
       txtcompany.Text = Globals.Globals.CompanyName;
       lblfonttitle.Font = Globals.Globals.FontPrintTitle;
       lblfont.Font = Globals.Globals.FontPrint;
       linkLabel1.Font = FrmMain.FontApp;
       string[] mar = Globals.Globals.BaraCodePrinterMarGin.Split(',');
       numericUpDownleft.Value = decimal.Parse(mar[0]);
       numericUpDownright.Value = decimal.Parse(mar[1]);
       numericUpDowntop.Value = decimal.Parse(mar[2]);
       numericUpDownbot.Value = decimal.Parse(mar[3]);

       mar = Globals.Globals.CasherPrinterMarGin.Split(',');
       numericUpDown2.Value = decimal.Parse(mar[0]);
       numericUpDown3.Value = decimal.Parse(mar[1]);
       numericUpDown4.Value = decimal.Parse(mar[2]);
       numericUpDown1.Value = decimal.Parse(mar[3]);
       comboBolang.DataSource = Globals.Globals.AllInputLanguage;
       comboBolang.Text = Globals.Globals.LanguageCurunet; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                Globals.Globals.CasherPrinter = comboBoxcasher.SelectedValue.ToString();
                Globals.Globals.BaraCodePrinter = comboBoxbaracode.SelectedValue.ToString();
                if (txtcompany.Text.Length > 0) Globals.Globals.CompanyName = txtcompany.Text;
                Globals.Globals.BaraCodePrinterMarGin = numericUpDownleft.Value.ToString() + "," + numericUpDownright.Value.ToString() + "," + numericUpDowntop.Value.ToString() + "," + numericUpDownbot.Value.ToString();
                Globals.Globals.CasherPrinterMarGin = numericUpDown2.Value.ToString() + "," + numericUpDown3.Value.ToString() + "," + numericUpDown4.Value.ToString() + "," + numericUpDown1.Value.ToString();
                if (Globals.Globals.AllInputLanguage.Contains(comboBolang.Text)) Globals.Globals.LanguageCurunet = comboBolang.Text;
                this.Enabled = true;
                this.Close();
            }
            catch { }
            finally { this.Enabled = true; }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Globals.Globals.PrintWhenSell = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Globals.Globals.PrintWhenBuy = checkBox1.Checked;
        }

        private void lblfonttitle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        using (FontDialog Fd=new FontDialog())
        {
            Fd.Font = lblfonttitle.Font;
            if (Fd.ShowDialog() == DialogResult.OK)
            {
                Globals.Globals.FontPrintTitle = Fd.Font;
                lblfonttitle.Font = Fd.Font;
            }

        }
        }

        private void lblfont_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (FontDialog Fd = new FontDialog())
            {
                Fd.Font = lblfont.Font;
                if (Fd.ShowDialog() == DialogResult.OK)
                {  
                    Globals.Globals.FontPrint = Fd.Font;
                    lblfont.Font = Fd.Font;
                }
            }
        }

        private void comboBolang_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void SettingUi_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (FontDialog Fd = new FontDialog())
            {
                Fd.Font = linkLabel1.Font;
                if (Fd.ShowDialog() == DialogResult.OK)
                {
                    Globals.Globals.FontApp = Fd.Font;
                    linkLabel1.Font = Fd.Font;
                    FrmMain.FontApp = Fd.Font;
                }

            }
        }
 
    }
}
