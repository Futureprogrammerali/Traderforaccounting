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
    public partial class BaraCode128vewier : UserControl
    {
        bool _DontCatch = true;
        public bool DontCatch
        {
            get { return _DontCatch; }
            set { _DontCatch = value; }
        }
        public override  string Text
        {
            get { return textBox1.Text; }
            set { textBox1.Text=value; }
        }
        bool _EnableCreate = true;
        public bool EnableCreate
        {
            get { return _EnableCreate; }
            set { _EnableCreate = value; linkLabel1.Visible = value; }
        }
        bool _InStore = true;
        public bool InStore
        {
            get { return _InStore; }
            set { _InStore = value;}
        }
        public BaraCode128vewier()
        {
            InitializeComponent();
        }
        Control _CtrlType = null;
        public Control CtrlType
        {
            get { return _CtrlType; }
            set { _CtrlType = value; }
        }
 
        static string allcharts = "9ab8AB7cd6CD5estuf4EFGHIJK20gh13k2lL3M4N5O6P7m8nQR9ijSop1TU2V3W8X9YZqr9vwxyz01";
        static char[] chars = new char[allcharts.Length];
        static bool isful = false;
        static Random Randomo = new Random();

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string x = "";
            if (!isful)
            {
                for (int i = 0; i < allcharts.Length; i++)
                {
                    chars[i] = allcharts[i];
                }
            }
            isful = true;
            for (int iss = 0; iss < 12; iss++)
            {
                x += chars[Randomo.Next(0, allcharts.Length)].ToString();
                // MessageBox.Show(x);
            }
            textBox1.Text = x;
        }

        private void BaraCode128vewier_Enter(object sender, EventArgs e)
        {
            textBox1.Focus();
            Globals.Globals.SetLang(WeightsOrganizer.Globals.Globals.Languge.English);
        }
        public void FocusMy()
        {
            try { textBox1.SelectAll(); textBox1.Focus();  }
            catch { }
        }
        private void BaraCode128vewier_Leave(object sender, EventArgs e)
        {
        Globals.Globals.SetLang(Globals.Globals.LanguageCurunet.Split('=')[1]);
        }

        private void BaraCode128vewier_Load(object sender, EventArgs e)
        {
            textBox1.RightToLeft = RightToLeft.No;
            ErrStromsg = (InStore ? "الصنف غير موجود في المخزن" : "الصنف غير موجود  ");
            if (DontCatch) textBox1.Multiline = true; else textBox1.Multiline = false;
        }
        string thecode = "";
        BLL.Types typcode = null;
        string ErrStromsg = "الصنف غير موجود في المخزن";
       
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {  
            if (DontCatch)
            {
                if (e.KeyChar == 13)
                {
                    try
                    {
                        thecode = textBox1.Text;
                        e.Handled = true;
                        typcode = BLL.Types.GetTypeByBaraCode(thecode, InStore)[0];
                        if ((typcode != null))
                        {
                            (CtrlType as ComboBox).SelectedValue = typcode.ID;
                            typcode = null;
                        }
                    }
                    catch (Exception) { MessageBox.Show(ErrStromsg,"قارئ الباراكود"); }
                    textBox1.Text = "";
                }
            }
        }
    }
}
