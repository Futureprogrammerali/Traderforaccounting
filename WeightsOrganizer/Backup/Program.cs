using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WeightsOrganizer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        { 
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Globals.Globals.SetGlobalizationCulture();
                Globals.Globals.SillySafe();
                Application.Run(new frmRealMainForm());
            }
            catch (Exception exx) { MessageBox.Show(exx.Message+""+exx.Source.ToString()+" "+exx.StackTrace); }
      

        }
    }

}
