using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using DataGridGVeiwPrinter;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;

//using System.Security.Cryptography;

namespace WeightsOrganizer.Globals
{
    class Globals
    {
      static string _LanguageCurunet;
        /// <summary>
        /// اللغة الحالية
        /// </summary>
        public static string LanguageCurunet
        {
            get {
                try
                {
                    _LanguageCurunet = (GetFromRegEdit("LanguageCurunet"));
                }
                catch { _LanguageCurunet = InputLanguage.CurrentInputLanguage.Culture.NativeName + "=" + InputLanguage.CurrentInputLanguage.Culture.EnglishName;
                SetToRegEdit("LanguageCurunet", _LanguageCurunet.ToString());
                }
                return _LanguageCurunet;
            }
            set { SetToRegEdit("LanguageCurunet", value.ToString()); }
        }
        /// <summary>
        /// اللغات المدعومة
        /// </summary>
        public static  List<string> AllInputLanguage
        {
            get {
                List<string> all = new List<string>();  
                foreach (InputLanguage ThisLang in InputLanguage.InstalledInputLanguages)
                    all.Add(ThisLang.Culture.NativeName + "=" + ThisLang.Culture.EnglishName);
                return all;
            }
        }
        private static string _CompanyName="الليث للمحاسبة";
        ///<summary>
        ///  الترويسة النصي المستخدمة في الطباعة 
        /// </summary>
        public static string CompanyName
        {
            get
            {
                try
                {
                    _CompanyName = (GetFromRegEdit("CompanyName"));
                }
                catch  {  }
                return _CompanyName;
            }
            set { SetToRegEdit("CompanyName", value.ToString()); }
        }
        /// <summary>
        /// هوامش الكاشير
        /// </summary>
        public static string CasherPrinterMarGin
        {
            get
            {
                try
                {
                    return (GetFromRegEdit("CasherPrinterMarGin"));
                }
                catch { return "0,0,0,0"; }
          
            }
            set { SetToRegEdit("CasherPrinterMarGin", value.ToString()); }
        }
        /// <summary>
        /// هوامش الباركود
        /// </summary>
        public static string BaraCodePrinterMarGin
        {
            get
            {
                try
                {
                    return  (GetFromRegEdit("BaraCodePrinterMarGin"));
                }
                catch  {  }
                return "0,0,0,0";
            }
            set { SetToRegEdit("BaraCodePrinterMarGin", value.ToString()); }
        }
        private static System.Drawing.Font _FontPrintTitle = new System.Drawing.Font("Andalus", 12,FontStyle.Regular);
        ///<summary>
        /// الخط المستخدم في   عنوان الطباعة
        /// </summary>
        public static System.Drawing.Font FontPrintTitle
        {
            get
            {
                return FontSero("FontPrintTitle");
                return _FontPrintTitle;
            }
            set { FontSero("FontPrintTitle", value); }
        }
        private static System.Drawing.Font _FontApp = new System.Drawing.Font("Andalus", 8, FontStyle.Regular);   
        public static System.Drawing.Font FontApp
        {
            get
            {
                return FontSero("FontApp");
                return _FontApp;
            }
            set { FontSero("FontApp", value); }
        }
        private static Font FontSero(string name)
        {
            try
            {
                Font fnt;
                Stream s = File.Open(name + @".dat", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                fnt = (Font)bf.Deserialize(s);
                s.Close();
                return fnt;

            }
            catch { return new System.Drawing.Font("Tahoma", 9, FontStyle.Bold); }
        }
        private static void FontSero(string name, Font fnt)
        {
            try
            {

                Stream s = File.Open(name+@".dat", FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(s, fnt);
                s.Close();
            }
            catch { }
        }
        public static System.Drawing.Font FontPrintBarCode
        {
            get
            {
                return FontSero("FontPrintBarCode");
            }
            set { FontSero("FontPrintBarCode", value); }
        }
        private static System.Drawing.Font _FontPrint = new System.Drawing.Font("Mudir MT", 8,FontStyle.Regular);
        ///<summary>
        /// الخط المستخدم في الطباعة
        /// </summary>
        public  static System.Drawing.Font FontPrint
        {
            get
            {
                return FontSero("FontPrint");
                return _FontPrint;
            }
            set { FontSero("FontPrint", value); }
        }
        ///<summary>
        /// أسماء أجهزة الطباعة المتوفرة
        /// </summary>
        internal static  List<string>AllPrintersNames
        {
            get
            {
                System.Drawing.Printing.PrinterSettings.StringCollection all = System.Drawing.Printing.PrinterSettings.InstalledPrinters;
                List<string> ALll = new List<string>();
                foreach (string s in all) ALll.Add(s);
                return ALll;
            }
        }
        public enum Languge : int
        {
            Arabic = 0,
            English = 1
        }
        public enum CultureInfoType : int
        {
            ArabicSyria = 0,
            ArabicSudi =1,
            English = 2
        }
       private static string _ConnectionString = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}\WeightsOrganizer.mdb;Persist Security Info=False;Jet OLEDB:Database Password=fp", Globals.GetPathFromFullname(Application.ExecutablePath));
       // 2007 private static string _ConnectionString = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}\WeightsOrganizer.mdb;Persist Security Info=False;Jet OLEDB:Database Password=fp", Globals.GetPathFromFullname(Application.ExecutablePath));
        private static RegistryKey myregkey = Registry.CurrentUser.CreateSubKey(Application.ProductName.ToString());
        private static RegistryKey safekey = Registry.CurrentUser.OpenSubKey(@"Control Panel\PowerCfg\PowerPolicies\0", true);
        public static  byte gram
        {
            get
            {
                byte gramoo = 1;
                try
                {
                    gramoo = byte.Parse(GetFromRegEdit("gramoo"));
                }
                catch
                { SetToRegEdit("gramoo", 1.ToString()); }
                return gramoo;
            }
            set { SetToRegEdit("gramoo", value.ToString()); }
        }
        public static bool NotSafe
        {      
            get
            {
                bool NotSafeo = true;
                try
                {
                    string x= GetFromRegEditSafe("BackGoundFont");
                    if (x == erroro.Processorid) { return false; }
                    
                }
                catch { SetToRegEditSafe("BackGoundFont", "nooo"); }
                return NotSafeo;
            }
            set { if (!value) SetToRegEditSafe("BackGoundFont", erroro.Processorid); else  SetToRegEditSafe("BackGoundFont", "nooo"); }
        }
        public static bool PrintWhenBuy
        {
            get
            {

                bool _PrintWhenBuy = true ;
                try
                {
                    _PrintWhenBuy = bool.Parse(GetFromRegEdit("PrintWhenBuy"));
                }
                catch { SetToRegEdit("PrintWhenBuy", true.ToString()); }
                return _PrintWhenBuy;
            }
            set { SetToRegEdit("PrintWhenBuy", value.ToString()); }
        }
        public static bool PrintWhenSell
        {
            get
            {
                bool _PrintWhenSell = true;
                try
                {
                    _PrintWhenSell = bool.Parse(GetFromRegEdit("PrintWhenSell"));
                }
                catch { SetToRegEdit("PrintWhenSell", true.ToString()); }
                return _PrintWhenSell;
            }
            set { SetToRegEdit("PrintWhenSell", value.ToString() ); }
        }
        public static double Opacity
        {
            get
            {
                double x = 0.9;
                try { x = double.Parse(GetFromRegEdit("Opacity")); }
                catch { SetToRegEdit("Opacity", "0.9"); }
                return x;
            }
            set { double x = 0.9; x = value / 100; SetToRegEdit("Opacity", x.ToString()); }
        }
        public static string ConnectionString
        {
            get
            {
                return _ConnectionString;
            }
        }
        public static string GetPathFromFullname(string s_fullpath)
        {
            if (s_fullpath.Length > 0)
            {
                FileInfo file = new FileInfo(s_fullpath);
                string filename = file.DirectoryName;
                file = null;
                return filename;
            }
            return "";
        }
        public static string GetNameFromFullname(string s_fullpath)
        {
            if (s_fullpath.Length > 0)
            {
                FileInfo file = new FileInfo(s_fullpath);
                string filename = file.Name;
                file = null;
                return filename;
            }
            return "";
        }
        private static void SetToRegEdit(string keuy, string val)
        {
            myregkey.SetValue(keuy, val, RegistryValueKind.String);
        }
        private static void SetToRegEditSafe(string keuy, string val)
        {
            safekey.SetValue(keuy, ASCIIEncoding.Unicode.GetBytes(val), RegistryValueKind.Binary);
        }
        private static string GetFromRegEditSafe(string keuy)
        {
            string stro = "";
            try { stro =ASCIIEncoding.Unicode.GetString((byte[])safekey.GetValue(keuy));   }
            finally { }
            return stro;
        }   
        private static string GetFromRegEdit(string keuy)
        {
            string stro = "";
            try { stro = myregkey.GetValue(keuy).ToString(); }
            finally { }
            return stro;
        }
        public static void Closely()
        {
            //try
            //{
            //  (frmRealMainForm.ActiveForm.FindForm() as frmRealMainForm).Close();            
            //}
            //catch { MessageBox.Show("عذرا يجب اغلاق البرنامج ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error); }            
            Application.Exit();
            Application.ExitThread();
                //}
        }
        public static void SetLang(Languge Lang)
        {
            try
            {
                string MyLang;
                if (Lang == Languge.Arabic)
                    MyLang = "Arabic";
                else
                    MyLang = "English";

                foreach (InputLanguage ThisLang in InputLanguage.InstalledInputLanguages)
                    if (ThisLang.Culture.EnglishName.Contains(MyLang))
                    {
                        InputLanguage.CurrentInputLanguage = ThisLang;
                        return;
                    }
            }
            catch { MessageBox.Show("اللغة العربية غير مدعومة"); }
        }
        public static void SetLang(string Lang)
        {
            try
            {
                foreach (InputLanguage ThisLang in InputLanguage.InstalledInputLanguages)
                    if (ThisLang.Culture.EnglishName.Contains(Lang))
                    {
                        InputLanguage.CurrentInputLanguage = ThisLang;
                        return;
                    }
            }
            catch { MessageBox.Show("اللغة العربية غير مدعومة"); }
        }
        public static string PassWord
        {
            get
            {
                string _PassWord = @"12";
                try
                {
                    _PassWord =((GetFromRegEditSafe("PassWord")));
                }
                catch
                { SetToRegEditSafe("PassWord", ("12")); }
                return _PassWord;
            }
            set { SetToRegEditSafe("PassWord", value.ToString()); }
        }
        public static string DangerAmount
        {
            get
            {
                string _DangerAmount = "13";
                try
                {
                    _DangerAmount = (GetFromRegEdit("DangerAmount"));
                    
                }
                catch
                { SetToRegEdit("DangerAmount", "13"); }
                return _DangerAmount;
            }
            set { SetToRegEdit("DangerAmount", value.ToString());  }
        }
        public static string DangerAmount2
        {
            get
            {
                string _DangerAmount2 = "20";
                try
                {
                    _DangerAmount2 = (GetFromRegEdit("DangerAmount2"));
                }
                catch
                { SetToRegEdit("DangerAmount2", "20"); }
                return _DangerAmount2;
            }
            set { SetToRegEdit("DangerAmount2", value.ToString()); }
        }
        public static int UnknownClient
        {
            get
            {
                int _UnknownClient = -1;
                try
                {
                    _UnknownClient =int.Parse( (GetFromRegEdit("UnknownClient")));
                }
                catch
                { SetToRegEdit("UnknownClient", "1"); }
                return _UnknownClient;
            }
            set { SetToRegEdit("UnknownClient", value.ToString()); }
        }
        public static string CasherPrinterWidth
        {
            get
            {
                string _CasherPrinterWidth = new System.Drawing.Printing.PrinterSettings().DefaultPageSettings.PaperSize.Width.ToString();
                try
                {
                    _CasherPrinterWidth = (GetFromRegEdit("CasherPrinterWidth"));
                }
                catch
                {
                    SetToRegEdit("CasherPrinterWidth", _CasherPrinterWidth);
                }
                return _CasherPrinterWidth;
            }
            set { SetToRegEdit("CasherPrinterWidth", value.ToString()); }
        }
        public static string CasherPrinter
        {
            get
            {
                string _CasherPrinter = new System.Drawing.Printing.PrintDocument().DefaultPageSettings.PrinterSettings.PrinterName;
                try
                {
                    _CasherPrinter = (GetFromRegEdit("CasherPrinter"));
                }
                catch
                {
                    SetToRegEdit("CasherPrinter", _CasherPrinter);
                }
                return _CasherPrinter;
            }
            set { SetToRegEdit("CasherPrinter", value.ToString());
            try
            {
                System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
                pd.PrinterSettings.PrinterName = value;
                CasherPrinterWidth = pd.PrinterSettings.DefaultPageSettings.PaperSize.Width.ToString();
            }
            catch { }
            }
        }
        public static string BaraCodePrinter
        {
            get
            {
                string _BaraCodePrinter =new  System.Drawing.Printing.PrintDocument().DefaultPageSettings.PrinterSettings.PrinterName;
                try
                {
                    _BaraCodePrinter =(GetFromRegEdit("BaraCodePrinter"));
                }
                catch
                { SetToRegEdit("BaraCodePrinter", _BaraCodePrinter); }
                return _BaraCodePrinter;
            }
            set { SetToRegEdit("BaraCodePrinter", value.ToString()); }
        }
        public static  bool  is_i_am_in_memory
        {
              get{
                  if (System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
                {
                    MessageBox.Show("يوجد نسخة اخرى من البرنامج", "فتح نسخ من البرنامج", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      return true;
                }
            return false;
              }
        }

        /// <summary>
       /// التنسيق الافتراضي العربي السوري
       /// </summary>
        internal static void SetGlobalizationCulture()
        {
            SetGlobalizationCulture(CultureInfoType.ArabicSyria);
        }
        /// <summary>
        /// التنسيقات المدعومة عربي سوري سعودي انكليزي عادي
        /// </summary>
        internal static void SetGlobalizationCulture(CultureInfoType CultureInfoTypee)
        {
            string ax = "ar-SY";
            switch (CultureInfoTypee)
            {
                case CultureInfoType.ArabicSudi: ax = "ar-SA"; break;
                case CultureInfoType.ArabicSyria: ax = "ar-SY"; break;
                case CultureInfoType.English: ax = "en"; break;
            }
            try
            {
                CultureInfo bewcrl = new CultureInfo(ax);
                DateTimeFormatInfo dfi = new DateTimeFormatInfo();
                dfi.MonthDayPattern = "dd/MM/yyyy hh:mm:ss tt";
                bewcrl.DateTimeFormat = dfi;
                Application.CurrentCulture = bewcrl;
                System.Threading.Thread.CurrentThread.CurrentCulture = bewcrl;
                System.Threading.Thread.CurrentThread.CurrentUICulture = bewcrl;
            }
            catch { MessageBox.Show("عذرا يجب أن يدعم النظام لغة الادخال العربية","خطأ",MessageBoxButtons.OK,MessageBoxIcon.Error);
            Closely();
            }
        }
       /// <summary>
       /// الحماية البسيطة
       /// </summary>
        internal static void SillySafe()
        {
            if (NotSafe)
            {
                erroro erroro=new erroro();
                erroro.ShowDialog();
            }
        }
        internal static void DeleteFatora()
        {
            try
            {
                File.Delete(@"FutureProgrammer.dat");
            }
            catch { }
        }
        internal static object PleseGivespecialComapny(int p)
        {
            BLL.Types tp = BLL.Types.GetTypeByID(p);
            List<BLL.Company> all2 = new List<WeightsOrganizer.BLL.Company>();
            if ((!string.IsNullOrEmpty(tp.AllCompanyId)) && (tp.AllCompanyId.Length != 0) && (tp.AllCompanyId != " "))
            {
                string[] all = tp.AllCompanyId.Split(',');
                foreach (string s in all)
                {
                    all2.Add(BLL.Company.GetCompanyByID(int.Parse(s)));
                }
            }
            else
            {
                all2 = BLL.BllGlobal.allcomps; 
            }
            return all2;
        }


        internal static void PrintNow(DataGridView p_2, string title, string foter)
        {
            PrintNow(p_2, title, foter, false);
        }
        internal static void PrintNow(DataGridView p_2, string title ,string foter  ,bool casherprinter)
        {
            try
            {
                //data grid font 
                DataGridViewCellStyle rd = new DataGridViewCellStyle(p_2.RowsDefaultCellStyle);
                rd.Font = FontPrint;
                Font oldfont = p_2.RowsDefaultCellStyle.Font;
                p_2.RowsDefaultCellStyle = rd;
                int oldwidth =p_2.Width;
                DataGridGVeiwPrinter.DGVPrinter Pr = new DGVPrinter();
                Pr.Footer = foter + Environment.NewLine + "الليث للمحاسبة";
                Pr.CellAlignment = System.Drawing.StringAlignment.Center;
                Pr.EnableLogging = false;
                Pr.FooterBorder = new System.Drawing.Pen(System.Drawing.Brushes.Black, 1);
                Pr.FooterFont = Pr.TitleFont = Globals.FontPrintTitle;
                Pr.HeaderCellAlignment = System.Drawing.StringAlignment.Center;
                Pr.ShowTotalPageNumber = false; Pr.PageNumbers = false;
                Pr.TableAlignment = DGVPrinter.Alignment.Center;
                Pr.Title =Globals.CompanyName+ Environment.NewLine+ title + " "+ MyDateTime.Now.ToString();
                Pr.TitleAlignment = System.Drawing.StringAlignment.Center;
                if (casherprinter)
                {
                    Pr.PrinterName = Globals.CasherPrinter;
                    try { p_2.Columns["ArabicUnit"].Visible = false; }
                    catch { }
                    string[] marg = Globals.CasherPrinterMarGin.Split(',');
                    Pr.PrintMargins.Left = int.Parse(marg[0]);
                    Pr.PrintMargins.Right = int.Parse(marg[1]);
                    Pr.PrintMargins.Top = int.Parse(marg[2]);
                    Pr.PrintMargins.Bottom = int.Parse(marg[3]);
                    
                    PrepeareStyleo(p_2, int.Parse(CasherPrinterWidth));
                    Pr.PrintDataGridView(p_2, false);
                    try { p_2.Columns["ArabicUnit"].Visible = true; }
                    catch { }
                }
                else
                {      
                    if (Pr.DisplayPrintDialog() == DialogResult.OK)
                    {
                        PrepeareStyleo(p_2,Pr.PrintSettings.DefaultPageSettings.PaperSize.Width);
                        Pr.PrintPreviewNoDisplay(p_2);
                    }     
                }

                //data grid font
                rd = new DataGridViewCellStyle(p_2.RowsDefaultCellStyle);
                rd.Font = oldfont;
                p_2.RowsDefaultCellStyle = rd;
                PrepeareStyleo(p_2, oldwidth); 
            }
            catch  { MessageBox.Show("عذرا يوجد خطأ في في محاولة ضبط حجم الطباعة "+"\n"+"تأكد من تعريف جهاز الطابعة"); }
          
        }
        /// <summary>
        /// اسم اليوم من الأسبوع
        /// </summary>
        /// <param name="dayOfWeek">رقم اليوم</param>
        /// <returns></returns>
        public  static string GetNameOfDay(DayOfWeek dayOfWeek)
        {
            string x = "";
            switch (dayOfWeek)
            {
                case DayOfWeek.Friday: x = "الجمعة"; break;
                case DayOfWeek.Monday: x = "الاثنين"; break;
                case DayOfWeek.Saturday: x = "السبت"; break;
                case DayOfWeek.Sunday: x = "الأحد"; break;
                case DayOfWeek.Thursday: x = "الخميس"; break;
                case DayOfWeek.Tuesday: x = "الثلاثاء"; break;
                case DayOfWeek.Wednesday: x = "الأربعاء"; break;
            }
            return x;
        }
        /// <summary>
        /// اسم اليوم من الأسبوع
        /// </summary>
        /// <param name="dayOfWeek">  تاريخ</param>
        /// <returns></returns>
        public static string GetNameOfDay(DateTime dayOfWeek)
        {
        return    GetNameOfDay(dayOfWeek.DayOfWeek);
        }
        /// <summary>
        /// اسم اليوم من الأسبوع
        /// </summary>
        public static string GetNameOfDay()
        {
            return GetNameOfDay(DateTime.Now.DayOfWeek);
        }
        /// <summary>
        /// اسم اليوم من الأسبوع
        /// </summary>
        /// <param name="dayOfWeek">تاريخي الخطير  </param>
        /// <returns></returns>
        public static string GetNameOfDay(MyDateTime dayOfWeek)
        {
         return GetNameOfDay(dayOfWeek.MyDateTimeasDateTime.DayOfWeek);
        }
        internal static void PrintNow(DataGridView p_2, string title)
        {
            PrintNow(p_2, title,"" ,false);
        }

           private static void PrepeareStyleo(DataGridView x, int widt)
        {

            int xWidth = widt;
            int clmncount = GetVisibleColumn(ref x);
            int ascription = (int)(xWidth / clmncount);
            ascription = xWidth / clmncount;
            foreach (DataGridViewColumn clmn in x.Columns)
            {
                if (clmn.Visible) clmn.Width = ascription;
            }

        }
           static int GetVisibleColumn(ref DataGridView x)
        {
            int xo = 0;
            foreach (DataGridViewColumn clmn in x.Columns)
            {
                if (clmn.Visible) xo++;
            }
            return xo;
        }



           /// <summary>
           /// crypt the string with key
           /// </summary>
           /// <returns></returns>
        internal static string Encrypt(string source, int theKey)
        {
        int counter;  
       Random jumbleMethod=new Random(theKey);

        byte[] keySet = new byte[source.Length - 1];
        byte [] sourceBytes =System.Text.Encoding.UTF8.GetBytes(source);
        jumbleMethod.NextBytes(keySet);

        for (counter = 0; counter < sourceBytes.Length - 1; counter++)
           {
          sourceBytes[counter] = (byte)(sourceBytes[counter] ^ keySet[counter]);
           }

           return Convert.ToBase64String(sourceBytes);
       }

            }
}
