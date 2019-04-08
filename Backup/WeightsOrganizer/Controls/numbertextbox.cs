using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer
{
    class numbertextbox:TextBox
    {
        public numbertextbox():base()
        {
            InitializeComponent();
            this.KeyPress += new KeyPressEventHandler(this.JustNumber);   
        }
        void JustNumber(object sender, KeyPressEventArgs e)
        {
     if(Allowcomma){
   if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8 && e.KeyChar!='.'))
      {
       e.Handled = true; // Remove the character
                       }
       }else{
       if ((e.KeyChar < 48 || e.KeyChar > 57)  && e.KeyChar != 8)
       {
       e.Handled = true; // Remove the character

       }
        } 

        }  
        bool _Allowcomma = false;
        public bool Allowcomma
        {
            get { return _Allowcomma; }
            set { _Allowcomma = value; }
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();
        }
        private System.ComponentModel.IContainer components;
    }
}
