using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer
{
    public partial class BaraCodeDesigner : WeightsOrganizer.FrmMain
    {
        public BaraCodeDesigner()
        {
            InitializeComponent();
        }
        BarcodeLib.Barcode b = new BarcodeLib.Barcode();
        private void BaraCodeDesigner_Load(object sender, EventArgs e)
        {
     
        this.Icon = global::WeightsOrganizer.Properties.Resources.Barcode;   
        laod();
        combotypes.DisplayMember = "Name";
        combotypes.ValueMember = "ID";
        combotypes.DataSource = BLL.BllGlobal.alltypes;
        combotypes.SelectedIndex = -1; combotypes.Text = "اختر صنف.. ";

        }

        private void laod()
        {
            Bitmap temp = new Bitmap(1, 1);
            temp.SetPixel(0, 0, this.BackColor);
            barcode.Image = (Image)temp;
            this.cbEncodeType.SelectedIndex = 15;
            this.cbBarcodeAlign.SelectedIndex = 0;
            this.cbLabelLocation.SelectedIndex = 0;
            this.cbRotateFlip.DataSource = GetThe();
            lblfonttitle.Font = Globals.Globals.FontPrintBarCode;

            //int i = 0;
            //foreach (object o in cbRotateFlip.Items)
            //{
            //    if (o.ToString().Trim().ToLower() == "rotatenoneflipnone")
            //        break;
            //    i++;
            //}//foreach
            //this.cbRotateFlip.SelectedIndex = i;
 
            this.tslblLibraryVersion.Text = "تصميم و طباعة الباركود";
            this.btnBackColor.BackColor = this.b.BackColor;
            this.btnForeColor.BackColor = this.b.ForeColor;

            /*We Are Delete Because Syia is ery old EAN-13  JAN-13*/
        }

        private object GetThe()
        {
           // System.Enum.GetNames(typeof(RotateFlipType));
            List<string> all = new List<string>();
            all.Add("عادي");      //RotateFlipType.Rotate180FlipXY.ToString()
            all.Add("قلب");       //RotateFlipType.Rotate180FlipNone.ToString()
            all.Add("شاقولي1");   //RotateFlipType.Rotate90FlipNone.ToString()
            all.Add("شاقولي2");  //RotateFlipType.Rotate270FlipNone
            return all;

        }

  

        private void btnEncode_Click(object sender, EventArgs e)
        {
            if ((txtHeight.Text.Length > 0) && (txtHeight.Text.Length > 0) && (txtWidth.Text.Length > 0))
                Vewiooo();
            else MessageBox.Show("يوجد خطأ في الاعدادت الرجاء التأكد من تصميم لصاقة باركود");
         
        }
        private void Vewiooo()
        {
            errorProvider1.Clear();
            
            int W = Convert.ToInt32(this.txtWidth.Text.Trim());
            int H = Convert.ToInt32(this.txtHeight.Text.Trim());
            b.Alignment = BarcodeLib.AlignmentPositions.CENTER;
            b.LabelFont = lblfonttitle.Font;

            //barcode alignment
            switch (cbBarcodeAlign.SelectedItem.ToString().Trim().ToLower())
            {
                case "يسار": b.Alignment = BarcodeLib.AlignmentPositions.LEFT; break;
                case "يمين": b.Alignment = BarcodeLib.AlignmentPositions.RIGHT; break;
                default: b.Alignment = BarcodeLib.AlignmentPositions.CENTER; break;
            }//switch

            BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;
            switch (cbEncodeType.SelectedItem.ToString().Trim())
            {
                case "UPC-A": type = BarcodeLib.TYPE.UPCA; break;
                case "UPC-E": type = BarcodeLib.TYPE.UPCE; break;
                case "UPC 2 Digit Ext.": type = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_2DIGIT; break;
                case "UPC 5 Digit Ext.": type = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_5DIGIT; break;
                case "EAN-13": type = BarcodeLib.TYPE.EAN13; break;
                case "JAN-13": type = BarcodeLib.TYPE.JAN13; break;
                case "EAN-8": type = BarcodeLib.TYPE.EAN8; break;
                case "ITF-14": type = BarcodeLib.TYPE.ITF14; break;
                case "Codabar": type = BarcodeLib.TYPE.Codabar; break;
                case "PostNet": type = BarcodeLib.TYPE.PostNet; break;
                case "Bookland/ISBN": type = BarcodeLib.TYPE.BOOKLAND; break;
                case "Code 11": type = BarcodeLib.TYPE.CODE11; break;
                case "Code 39": type = BarcodeLib.TYPE.CODE39; break;
                case "Code 39 Extended": type = BarcodeLib.TYPE.CODE39Extended; break;
                case "Code 93": type = BarcodeLib.TYPE.CODE93; break;
                case "LOGMARS": type = BarcodeLib.TYPE.LOGMARS; break;
                case "MSI": type = BarcodeLib.TYPE.MSI_Mod10; break;
                case "Interleaved 2 of 5": type = BarcodeLib.TYPE.Interleaved2of5; break;
                case "Standard 2 of 5": type = BarcodeLib.TYPE.Standard2of5; break;
                case "Code 128": type = BarcodeLib.TYPE.CODE128; break;
                case "Code 128-A": type = BarcodeLib.TYPE.CODE128A; break;
                case "Code 128-B": type = BarcodeLib.TYPE.CODE128B; break;
                case "Code 128-C": type = BarcodeLib.TYPE.CODE128C; break;
                case "Telepen": type = BarcodeLib.TYPE.TELEPEN; break;
                case "FIM": type = BarcodeLib.TYPE.FIM; break;
                default: MessageBox.Show("باركود باركود الرجاء حدد نوع تشفير باركود"); break;
            }//switch

            try
            {
                if (type != BarcodeLib.TYPE.UNSPECIFIED)
                {
                    b.IncludeLabel = (this.chkGenerateLabel.Checked );
                    if (checkBox1.Checked) b.AnotherDate = combotypes.Text;
                    else b.AnotherDate = "";
                    //  b.RotateFlipType = (RotateFlipType)Enum.Parse(typeof(RotateFlipType), this.cbRotateFlip.SelectedItem.ToString(), true);
                    b.RotateFlipType = GetThe(this.cbRotateFlip.Text);
       
                    //label alignment and position
                    switch (this.cbLabelLocation.SelectedItem.ToString().Trim().ToUpper())
                    {
                       
                        case "توسط أيسر": b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMLEFT; break;
                        case "توسط أيمن": b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMRIGHT; break;
                        case "توسط علوي": b.LabelPosition = BarcodeLib.LabelPositions.TOPCENTER; break;
                        case "أعلى اليسار": b.LabelPosition = BarcodeLib.LabelPositions.TOPLEFT; break;
                        case "أعلى اليمين": b.LabelPosition = BarcodeLib.LabelPositions.TOPRIGHT; break;
                        default: b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER; break;
                    }//switch
                     
                    //===== Encoding performed here =====
                    barcode.Image = b.Encode(type, this.txtData.Text.Trim(), this.btnForeColor.BackColor, this.btnBackColor.BackColor, W, H);
                    //===================================

                    //show the encoding time
                    //this.lblEncodingTime.Text = "(" + Math.Round(b.EncodingTime, 0, MidpointRounding.AwayFromZero).ToString() + "ms)";

                   // txtEncoded.Text = b.EncodedValue;

                    tsslEncodedType.Text = " نوع تشفير باركود : " + b.EncodedType.ToString();
                }//if

                barcode.Width = barcode.Image.Width;
                barcode.Height = barcode.Image.Height;

                //reposition the barcode image to the middle
                barcode.Location = new Point((this.groupBox2.Location.X + this.groupBox2.Width / 2) - barcode.Width / 2, (this.groupBox2.Location.Y + this.groupBox2.Height / 2) - barcode.Height / 2);
            }//try
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }//catch
        }//Vewiooo
        private void btnForeColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog cdialog = new ColorDialog())
            {
                cdialog.AnyColor = true;
                if (cdialog.ShowDialog() == DialogResult.OK)
                {
                    this.b.ForeColor = cdialog.Color;
                    this.btnForeColor.BackColor = cdialog.Color;
                }//if
            }//using
        }
        private void btnBackColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog cdialog = new ColorDialog())
            {
                cdialog.AnyColor = true;
                if (cdialog.ShowDialog() == DialogResult.OK)
                {
                    this.b.BackColor = cdialog.Color;
                    this.btnBackColor.BackColor = cdialog.Color;
                }//if
            }//using
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "BMP (*.bmp)|*.bmp|GIF (*.gif)|*.gif|JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|TIFF (*.tif)|*.tif";
            sfd.FilterIndex = 2;
            sfd.AddExtension = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                BarcodeLib.SaveTypes savetype = BarcodeLib.SaveTypes.UNSPECIFIED;
                switch (sfd.FilterIndex)
                {
                    case 1: /* BMP */ savetype = BarcodeLib.SaveTypes.BMP; break;
                    case 2: /* GIF */ savetype = BarcodeLib.SaveTypes.GIF; break;
                    case 3: /* JPG */ savetype = BarcodeLib.SaveTypes.JPG; break;
                    case 4: /* PNG */ savetype = BarcodeLib.SaveTypes.PNG; break;
                    case 5: /* TIFF */ savetype = BarcodeLib.SaveTypes.TIFF; break;
                    default: break;
                }//switch
                b.SaveImage(sfd.FileName, savetype);
            }//if
        }

        private void BaraCodeDesigner_Enter(object sender, EventArgs e)
        {
       //  Globals.Globals.SetLang(WeightsOrganizer.Globals.Globals.Languge.English);
        }

        private void lblfonttitle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (FontDialog Fd = new FontDialog())
            {
                Fd.Font = lblfonttitle.Font;
                if (Fd.ShowDialog() == DialogResult.OK)
                {
                    lblfonttitle.Font = Fd.Font;
                    Globals.Globals.FontPrintBarCode = Fd.Font ;
                    b.LabelFont = Fd.Font;
                }

            }
        }
        string myRotateFlipTypestr= "";
        private void cbRotateFlip_SelectedIndexChanged(object sender, EventArgs e)
        {
            //RotateFlipType myRotateFlipType = (RotateFlipType)Enum.Parse(typeof(RotateFlipType), this.cbRotateFlip.SelectedItem.ToString(), true);
            RotateFlipType myRotateFlipType = GetThe(this.cbRotateFlip.SelectedItem.ToString()); 
            switch ((int)myRotateFlipType)
            {
                
                case 0:
                    {
                        myRotateFlipTypestr = "بلا دوران"; break;
                    }
                case 1:
                    {
                        myRotateFlipTypestr = "دوران 90 درجة بلا قلب"; break;
                    }
                case 2:
                    {
                        myRotateFlipTypestr = "دوران 180 درجة بلا قلب"; break;
                    }
                case 3:
                    {
                        myRotateFlipTypestr = "دوران 270 درجة بلا قلب"; break;
                    }
                case 4:
                    {
                        myRotateFlipTypestr = "بلا دوران"; break;
                    }
                case 5:
                    {
                        myRotateFlipTypestr = "دوران 90 درجة  افقي"; break;
                    }
                case 6:
                    {
                        myRotateFlipTypestr = "بلا دوران"; break;
                    }
                case 7:
                    {
                        myRotateFlipTypestr = "دوران 90 درجة مع قلب"; break;
                    }

            }
            label10.Text=myRotateFlipTypestr;
        }

        private RotateFlipType GetThe(string p)
        {
            RotateFlipType x = new RotateFlipType();
            switch(p)
            {
                case "قلب": x = RotateFlipType.Rotate180FlipNone; break;
                case "عادي": x = RotateFlipType.Rotate180FlipXY; break;
                case "شاقولي1": x = RotateFlipType.Rotate90FlipNone; break;
                case "شاقولي2": x = RotateFlipType.Rotate270FlipNone; break;
                default: x= RotateFlipType.Rotate180FlipNone;break;
            }
            return x;
        }

        private void combotypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtData.Text = ((BLL.Types)combotypes.SelectedItem).BaraCode;
            }
            catch { }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked && chkGenerateLabel.Checked  )
            {
                label1.Text = "اظهار الاسم والرمز  ";
            }
            if (checkBox1.Checked && !chkGenerateLabel.Checked  )
            {
                label1.Text = "اظهار الاسم   ";
            }
            if (checkBox1.Checked && chkGenerateLabel.Checked  )
            {
                label1.Text = "اظهار الاسم والرمز ";
            }
            if (checkBox1.Checked && !chkGenerateLabel.Checked )
            {
                label1.Text = "اظهار الاسم "; 
            }
            if (!checkBox1.Checked && chkGenerateLabel.Checked )
            {
                label1.Text = "اظهار الرمز  ";
            }

            if (!checkBox1.Checked && chkGenerateLabel.Checked  )
            {
                label1.Text = "اظهار الرمز";
            }
 
            if (!checkBox1.Checked && !chkGenerateLabel.Checked )
            {
                label1.Text = "عدم اظهار النص";
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            printo.Text = "طباعة "+textBox1.Text+"لصاقة ";
        }

        private void printo_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                number = int.Parse(textBox1.Text);
                if (number > 0)
                {
                    groupBox1.Enabled = false;
                    printDocument1.Print();
                }
            }
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
        printDocument1.DefaultPageSettings.PrinterSettings.PrinterName = Globals.Globals.BaraCodePrinter;
        string[] mar = Globals.Globals.BaraCodePrinterMarGin.Split(',');
         ;
         printDocument1.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(int.Parse(mar[0]), int.Parse(mar[1]), int.Parse(mar[2]),int.Parse(mar[3]));
        }
        int number = 0;
        int i = 0;
        int y = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
         i++; 
         number = int.Parse(textBox1.Text);
         e.Graphics.DrawImage(barcode.Image, new Point(e.MarginBounds.Left, e.MarginBounds.Top));
         if (i == number)
         {
             e.HasMorePages = false;
             i = 0; y = 0;
             groupBox1.Enabled = true;
         }
         else { e.HasMorePages = true;  }
        }

        private void cbLabelLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
     
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                string[] x = comboBox1.Text.Split('#');
                txtHeight.Text=x[0];
                txtWidth.Text=x[1];
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

 
    }
}
