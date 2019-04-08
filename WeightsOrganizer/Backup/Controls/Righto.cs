using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WeightsOrganizer.Properties;
 
 

namespace WeightsOrganizer.Controls
{
    public partial class Righto : UserControl
    {
        static Font FontRight = new Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Pixel);
        Graphics gr;
        static   UserControl myUserControl = null;
        static object allclnt= null; 
        static object allcmny =null; 
        static object alltyps =null; 
        static object allstry=null ; 
        public Righto()
        {
            try
            {
                InitializeComponent();
                this.timer2.Enabled = true;
            }
            catch { } 
            
        }
        private void Righto_Load(object sender, EventArgs e)
        {
            // 
            // timer1
            //
           
            timer1 = new System.Windows.Forms.Timer(this.components);
            timer1.Interval = 1000;
            timer1.Tick += new System.EventHandler(this.timer1_Tick);  
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CreateControly(TypesControls.Veiwclientoption, ref allclnt);
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            CreateControly(TypesControls.Veiwcompanyoption, ref allcmny);
        }
        public void pictureBox4_Click(object sender, EventArgs e)
        {
           CreateControly(TypesControls.Veiwstoryoption,ref allstry);
        }
        
        private void CreateControly(TypesControls type,ref object datasource)
        {
            if (myUserControl != null) { myUserControl.Dispose(); myUserControl = null;}
            gr = Graphics.FromHwnd(this.Handle);
            gr.DrawString(" ..يتم تحميل البيانات ", FontRight, Brushes.Red, new PointF(this.Width / 2, this.Height / 2));
            gr.Dispose();
            switch (type)
            {
                case TypesControls.Veiwstoryoption:
                    {
                        Createstorey(ref  datasource);
                        pictureBox4.Image = global::WeightsOrganizer.Properties.Resources.greenamount;
                        break;
                    }
                case TypesControls.All:
                    {
                        CreateAll(ref  datasource);
                        pictureBox1.Image = global::WeightsOrganizer.Properties.Resources.searchgreen;
                        break;
                    }
                case TypesControls.VeiwTypesoption:
                    {
                        CreateViewTypesy(ref datasource);
                        pictureBox3.Image = global::WeightsOrganizer.Properties.Resources.greentype; 
                        break;
                    }
         
            }
            if (myUserControl != null)
            {
                myUserControl.Left = 38;
                myUserControl.Size = new Size(myUserControl.Width,this.Height);
               OpenCadget(new object(), new EventArgs());

            }
        }
        private void Createstorey(ref object datasource)
        {
            if (myUserControl != null) { myUserControl.Dispose(); myUserControl = null; }
            myUserControl = new WeightsOrganizer.Controls.ViewStore();
            myUserControl.Name = "myUserControl";
           myUserControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
           ((ViewStore)myUserControl).dataGridView1.MouseLeave += new EventHandler(Righto_MouseLeave);
            myUserControl.MouseLeave += new EventHandler(Righto_MouseLeave);
            ((ViewStore)myUserControl).DateSource = datasource;
           this.Controls.Add( myUserControl);
            
        }
        private void CreateAll(ref object datasource)
        {
            if (myUserControl != null) { myUserControl.Dispose(); myUserControl = null; }
            myUserControl = new WeightsOrganizer.Controls.ViewAll();
            myUserControl.Name = "myUserControl";
           myUserControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
           ((ViewAll)myUserControl).dataGridView1.MouseLeave += new EventHandler(Righto_MouseLeave);
            myUserControl.MouseLeave += new EventHandler(Righto_MouseLeave);
            ((ViewAll)myUserControl).DateSource = datasource;
            this.Controls.Add( myUserControl);
            
        }
        private void SetMySize()
        {
         this.Width = 293 + 44;
         label1.Text = "اخفاء";
        }
        private void ReSetMySize(object sender)
        {
            if (Isfixed==false)
            {
                this.ReSetMySize();
            }
        }
        public void ReSetMySize()
        {
        this.Width = 31;
        label1.Text = "اظهار";
        }
        private void Righto_MouseLeave(object sender, EventArgs e)
        {
            ReSetMySize(sender);
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {

            CreateControly(TypesControls.VeiwTypesoption, ref  alltyps);
        }
        private void CreateViewTypesy(ref object datasource)
        {
            if (myUserControl != null) { myUserControl.Dispose(); myUserControl = null;
            this.Controls.Remove(myUserControl);
            }
            myUserControl = new WeightsOrganizer.Controls.ViewTypes();
             myUserControl.Name = "myUserControl";
            myUserControl.MouseLeave += new EventHandler(Righto_MouseLeave);
            ((ViewTypes)myUserControl).dataGridView1.MouseLeave += new EventHandler(Righto_MouseLeave);
            ((ViewTypes)myUserControl).DateSource = datasource;
            this.Controls.Add( myUserControl);
        }
        private  void timer1_Tick(object sender, EventArgs e)
        {
            try
             {
                 GetDataAgainTocompany(); GetDataAgainToclient();
                 GetDataAgainToTypes(); GetDataAgainTostory();
            }
            catch {           }
            try
            {
                timer1.Enabled = false;
            }
            catch { }
        }
        internal static void GetDataAgain()
        { 
            myUserControl.Refresh();
            timer1.Enabled = true;
        }
        internal static void GetDataAgainTocompany()
        {
            allcmny = BLL.BllGlobal.allcomps;
            if (myUserControl is ViewCompany) (myUserControl as ViewCompany).DateSource = allcmny;
        }
        internal static void GetDataAgainToclient()
        {
            allclnt = BLL.BllGlobal.allclients;
            if (myUserControl is viewClient) (myUserControl as viewClient).DateSource = allclnt;
        }
        internal static void GetDataAgainToTypes()
        {
            alltyps = BLL.BllGlobal.alltypes;
            if (myUserControl is ViewTypes) (myUserControl as ViewTypes).DateSource = alltyps;
        }
        internal static void GetDataAgainTostory()
        {
            allstry = BLL.BllGlobal.allstory;
            if(myUserControl is ViewStore)   (myUserControl as ViewStore).DateSource=allstry;
        }
        bool Isfixed = false;
        public    void CloseCadget(object sender, EventArgs e)
        {
            try
            {
                label1.Text = "اظهار";
                if (myUserControl == null) pictureBox4_Click(sender, e);
                else { this.ReSetMySize(); }
            }
            catch { }
        }
        void OpenCadget(object sender, EventArgs e)
        {
            label1.Text = "اخفاء";
            if (myUserControl == null) pictureBox4_Click(sender, e);
            else { this.SetMySize();
            }
        }
        Image  pictureBox4img = null;
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
         if (sender == pictureBox1) (sender as PictureBox).Image = global::WeightsOrganizer.Properties.Resources.searchred; 
          //  if (sender == pictureBox2) (sender as PictureBox).Image = global::WeightsOrganizer.Properties.Resources.redcompany;
            if (sender == pictureBox3) (sender as PictureBox).Image = global::WeightsOrganizer.Properties.Resources.redtype;
            if (sender == pictureBox4) (sender as PictureBox).Image = global::WeightsOrganizer.Properties.Resources.redamount; 

        }
        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {

        if (sender == pictureBox4) (sender as PictureBox).Image = pictureBox4img;
        WhatTypeOfControl();
        }
        private void WhatTypeOfControl()
        {
            if (myUserControl != null)
            {
             if (myUserControl is ViewAll) pictureBox1.Image = global::WeightsOrganizer.Properties.Resources.searchgreen; else pictureBox1.Image =global::WeightsOrganizer.Properties.Resources.search;
                if (myUserControl is ViewTypes) pictureBox3.Image = global::WeightsOrganizer.Properties.Resources.greentype; else pictureBox3.Image = global::WeightsOrganizer.Properties.Resources.type;
                if (myUserControl is ViewStore) pictureBox4.Image = global::WeightsOrganizer.Properties.Resources.greenamount; else pictureBox4.Image = global::WeightsOrganizer.Properties.Resources.amount;

            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Isfixed)
                    OpenCadget(sender, e);
                else CloseCadget(sender, e);

                Isfixed = !Isfixed;
                if (frmRealMainForm.FrmTypso != null)
                {
                    frmRealMainForm.FrmTypso.Size = new Size((FrmMain.ActiveForm.FindForm() as Form).ClientSize.Width - (this.Width + 15), (FrmMain.ActiveForm.FindForm() as Form).ClientSize.Height);
                    frmRealMainForm.FrmTypso.Refresh();
                }
                //(frmRealMainForm.ActiveForm.FindForm() as frmRealMainForm).Repaint();
            }
            catch { }
            
        }
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
         object x=  new object();
         CreateControly(TypesControls.All, ref x);  
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Height = this.Parent.ClientRectangle.Height -52;
            timer1_Tick(sender, e);
            label1_Click(sender, e);
            timer2.Enabled = false;
        }

 
    }
}
