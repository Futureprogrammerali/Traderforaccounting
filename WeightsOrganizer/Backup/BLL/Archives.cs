using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeightsOrganizer.DAL;

namespace WeightsOrganizer.BLL
{
    class Archives : DAL.ArchivesDetails
    {
        private static RealProvider myRealProvider = new RealProvider();
    public    string SmallTypeName
        { 
            get {
                string _string="صنف فقط";
                switch (this.SmallType)
                {
                    case 0: _string = "صنف فقط"; break;
                    case 1: _string = "تاريخ فقط"; break;
                    case 2: _string = "صنف وتاريخ"; break;
                }
                return _string;
            }
        }

        public static List<Archives> GetAllArchives(archivesTypes archivesTypeso)
        {
            return GetArchivesFromArchivesDetails(myRealProvider.GetAllArchives(archivesTypeso));
        }
        private static List<Archives> GetArchivesFromArchivesDetails(List<ArchivesDetails> list)
        {
            List<Archives> newlist = new List<Archives>();

            foreach (ArchivesDetails tbdt in list)
            {
                newlist.Add(new Archives(tbdt.ID, tbdt.BigType, tbdt.SmallType, tbdt.Amount, tbdt.Price, tbdt.PaidMoney, tbdt.StayingPrice, tbdt.Profit, tbdt.AddedDate1, tbdt.AddedDate2, tbdt.AddedDate, tbdt.Details));
            }
            return newlist;
        }
        public static bool DeleteArchives(int ido)
        {
            bool x = myRealProvider.DeleteArchives(ido);
            return x;
        }
        public static int InsertArchives(byte bigType, byte smallType, double amount, double price, double paidMoney, double stayingPrice, double profit, MyDateTime addeddate1, MyDateTime addeddate2, MyDateTime addeddate, string details)
        {
            ArchivesDetails tb1 = new ArchivesDetails(0, bigType, smallType, amount, price, paidMoney, stayingPrice, profit, addeddate1, addeddate2, addeddate, details);
            int x = myRealProvider.InsertArchives(tb1);
            return x;
        }
        public Archives(int id, byte bigType, byte smallType, double amount, double price, double paidMoney, double stayingPrice, double profit, MyDateTime addeddate1, MyDateTime addeddate2, MyDateTime addeddate, string details)
            : base(id, bigType, smallType, amount, price, paidMoney, stayingPrice, profit, addeddate1, addeddate2, addeddate, details)
       {

       }

 
    }
}
