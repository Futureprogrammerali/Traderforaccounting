using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeightsOrganizer.DAL;

namespace WeightsOrganizer.BLL
{
    class ListClienttAccount:DAL.LastClientsAccountDetails
    {
        private static RealProvider myRealProvider = new RealProvider();
        public ListClienttAccount() {}
        public ListClienttAccount(int id, int clid, double can, double number, double sar, MyDateTime addeddate)
        {
            this.ID = id;
            this.ClientId = clid;
            this.Sar = sar;
            this.Can = can;
            this.Number = number;
            this.AddedDate = addeddate;
        }
        public static List<ListClienttAccount> GetAllListClienttAccount(int ManId)
        {
            return GetListClienttAccountDetailsFromListClienttAccountDetails(myRealProvider.GetAllLastClienttAccount(ManId));
        }
        public static int InsertListClienttAccount(int clid, double can, double number, double sar)
        {
            DAL.LastClientsAccountDetails cr = new DAL.LastClientsAccountDetails(0, clid, can, number, sar, MyDateTime.Now);
            return myRealProvider.InserLastClienttAccount(cr);
        }
        public static List<ListClienttAccount> GetListClienttAccountDetailsFromListClienttAccountDetails(List<DAL.LastClientsAccountDetails> list)
        {
            List<ListClienttAccount> newlist = new List<ListClienttAccount>();

            foreach (LastClientsAccountDetails tbdt in list)
            {
                newlist.Add(new ListClienttAccount(tbdt.ID, tbdt.ClientId, tbdt.Can, tbdt.Number, tbdt.Sar, tbdt.AddedDate));
                
            }
            return newlist;
        }
        public static bool DeleteListClienttAccount(int ido)
        {
            bool x = myRealProvider.DeleteLastClientAccount(ido);
            return x;
        }
    }
}
