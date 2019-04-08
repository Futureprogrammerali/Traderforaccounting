using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer.Controls
{
    public partial class SettingoControl : UserControl
    {
        public SettingoControl()
        {
            InitializeComponent();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
       
        }
        private void SettingoControl_Load(object sender, EventArgs e)
        {
           this.radioButton1.Checked = Globals.Globals.gram==0;
           this.radioButton2.Checked = (Globals.Globals.gram == 1);
           this.radioButton3.Checked = (Globals.Globals.gram == 2);
           this.enableAll = true;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Globals.Globals.gram = 0;
            changetext();
        }
        private void changetext()
        {
            if (_TheTextBoxContinerTheAmoutn != null)
            {
                string x = _TheTextBoxContinerTheAmoutn.Text;
                _TheTextBoxContinerTheAmoutn.Text = "";
                _TheTextBoxContinerTheAmoutn.Text = x;  
    }
          
           
        }
        private bool _isBasecType = false;
        public bool isBasecType
        {
            get { return _isBasecType; }
            set { _isBasecType = value;
            if (value)
            {
                radioButton2.Text = "الوزن";
                radioButton2.Checked = true;
                radioButton1.Visible = false;
                radioButton2.Left = radioButton2.Left + 20;
                radioButton3.Left = radioButton3.Left + 20;
            }
            }
        }
        private TextBox _TheTextBoxContinerTheAmoutn = null;
        public TextBox TheTextBoxContinerTheAmoutn
        {
            get { return _TheTextBoxContinerTheAmoutn; }
            set { _TheTextBoxContinerTheAmoutn = value; }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Globals.Globals.gram = 1;
            changetext();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Globals.Globals.gram = 2;
            changetext();
        }
        bool _enableAll = true;
        public bool enableAll
        {
            get { return _enableAll; }
            set { _enableAll = value;
            foreach (Control rb in this.groupBox1.Controls) { if (rb is RadioButton) rb.Enabled = value; }
            }
        }



        internal void Refresh(TheUnito theUnito)
        {
            switch (theUnito)
            {
                case TheUnito.Piece: { radioButton3.Checked = true; radioButton2.Enabled = false; radioButton1.Enabled = false; radioButton3.Enabled = true; break; }
                case TheUnito.Kilo: { radioButton2.Checked = true; radioButton3.Enabled = false; radioButton2.Enabled = true; radioButton1.Enabled = true; break; }
                case TheUnito.Gram: { radioButton1.Checked = true; radioButton3.Enabled = false; radioButton2. Enabled = true; radioButton1.Enabled = true; break; }
            }
          
        }

        internal void Refresh2(TheUnito theUnito)
        {
            switch (theUnito)
            {
                case TheUnito.Piece: { radioButton3.Checked = true; break; }
                case TheUnito.Kilo: { radioButton2.Checked = true;  break; }
                case TheUnito.Gram: { radioButton1.Checked = true; break; }
            }   
        }
    }
}
