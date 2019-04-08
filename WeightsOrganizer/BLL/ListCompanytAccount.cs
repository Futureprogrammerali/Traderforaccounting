using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeightsOrganizer.DAL;

namespace WeightsOrganizer.BLL 
{
    class ListCompanytAccount:DAL.LastCompanyAccountDetails
    {
        private static RealProvider myRealProvider = new RealProvider();
        public ListCompanytAccount() {}
        public ListCompanytAccount(int id, int manid, double can, double number, double sar, MyDateTime addeddate)
        {
            this.ID = id;
            this.ManId = manid;
            this.Sar = sar;
            this.Can = can;
            this.Number = number;
            this.AddedDate = addeddate;
        }
        public static List<ListCompanytAccount> GetAllListCompanytAccount(int ManId)
        {
            return GetLastCompanyAccountDetailsFromCompanytAccountDetails(myRealProvider.GetAllLastCompanytAccount(ManId));
        }
        public static int InsertCompanytAccount(int manid, double can,double number,double sar)
        {
            DAL.LastCompanyAccountDetails cr = new DAL.LastCompanyAccountDetails(0, manid, can, number, sar, MyDateTime.Now);
            return myRealProvider.InserLastCompanytAccount (cr);
        }
        public static List<ListCompanytAccount> GetLastCompanyAccountDetailsFromCompanytAccountDetails(List<DAL.LastCompanyAccountDetails> list)
        {
            List<ListCompanytAccount> newlist = new List<ListCompanytAccount>();

            foreach (LastCompanyAccountDetails tbdt in list)
            {
                newlist.Add(new ListCompanytAccount(tbdt.ID, tbdt.ManId, tbdt.Can, tbdt.Number, tbdt.Sar, tbdt.AddedDate));
                
            }
            return newlist;
        }
        public static bool DeleteListCompanytAccount(int ido)
        {
            bool x = myRealProvider.DeleteLastCompanytAccount(ido);
            return x;
        }
    }
}
