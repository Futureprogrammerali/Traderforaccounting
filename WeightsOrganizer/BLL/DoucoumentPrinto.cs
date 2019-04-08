using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Text;
using System.Drawing;

namespace WeightsOrganizer.BLL
{
    class DoucoumentPrinto : PrintDocument
    {
        private Font MyFont;
        private int count=0;
        private List<BLL.ClientDeal>All;
        public DoucoumentPrinto(Font font,List<BLL.ClientDeal> all)
        {
            MyFont = font;
            All=all;
        }
        protected override void OnBeginPrint(PrintEventArgs e)
        {
            this.PrinterSettings.PrinterName = Globals.Globals.CasherPrinter;
            this.DefaultPageSettings.PaperSize = this.PrinterSettings.DefaultPageSettings.PaperSize;
            this.DefaultPageSettings.Margins.Bottom = 10; // 0,5 inches
            this.DefaultPageSettings.Margins.Top = 10;
            this.DefaultPageSettings.Margins.Left = 10;
            this.DefaultPageSettings.Margins.Right = 10; 
            base.OnBeginPrint(e);
        }
        protected override void OnPrintPage(PrintPageEventArgs e)
        {

            if (count < All.Count) count++; else e.HasMorePages = false;
            base.OnPrintPage(e);
        }
    }
}
