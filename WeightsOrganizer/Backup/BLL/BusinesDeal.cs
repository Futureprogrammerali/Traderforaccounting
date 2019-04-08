using System;
using System.Collections.Generic;

using System.Text;
using WeightsOrganizer.DAL;

namespace WeightsOrganizer.BLL
{
    class BusinesDeal:DAL.BusinesDealDetails
    {    
        private static RealProvider myRealProvider = new RealProvider();
        public BusinesDeal():base() { }
        public BusinesDeal(int id, int typeid, int manid, double amount, double businessprice, double clientprice, double paidmoney, string details, MyDateTime addeddate, string manname, string typename)
        :base(id,typeid,manid,amount,businessprice,clientprice,paidmoney,details,addeddate, manname, typename)
        { 
        }

        protected double _ToTalPrice = 0;
        public double ToTalPrice
        {
            set { _ToTalPrice = value; }
            get
            {
                return this.Amount * this.BusinessPrice;
            }
        }
        protected double _StayingPrice = 0;
        public double StayingPrice
        {
            set { _StayingPrice = value; }
            get
            {
                return this.ToTalPrice - this.PaidMoney;
            }
        }  
        /// Real Business Logic layer begin Here!
        public static List<BusinesDeal> GetAllBusinesDeal()
        {
          return GetBusinesDealFromBusinesDealDetails(myRealProvider.GetAllBusinesDeals());
        }
        public static BusinesDeal GetBusinesDealByID(int ido)
        {
            BusinesDealDetails tbdt = myRealProvider.GetBusinesDealByID(ido);
            if (tbdt != null) return new BusinesDeal(tbdt.ID, tbdt.TypeId, tbdt.ManId, tbdt.Amount, tbdt.BusinessPrice, tbdt.ClientPrice, tbdt.PaidMoney, tbdt.Details, tbdt.AddedDate, tbdt.ManName, tbdt.TypeName); else return null;
        }
        public BusinesDeal GetBusinesDealByID()
        {
            return BusinesDeal.GetBusinesDealByID(this.ID);
        }
        public bool DeleteClient()
        {
            return BusinesDeal.DeleteBusinesDeal(this.ID);
        }
        public static bool DeleteBusinesDeal(int ido)
        {
            return myRealProvider.DeleteBusinesDeal(ido);
        }
        public static bool DeleteBusinesDealByIDman(int ido)
        {
            return myRealProvider.DeleteBusinesDealByIDman(ido);
        }
        public static int InsertBusinesDeal(int id, int typeid, int manid, double amount, double businessprice, double clientprice, double paidmoney, string details, string manname, string typename)
        {
            BusinesDealDetails tb1 = new BusinesDealDetails(id, typeid, manid, amount, businessprice, clientprice, paidmoney, details, MyDateTime.Now, manname, typename); 
            int x= myRealProvider.InsertBusinesDeal(tb1);
            return x;
        }
        public int InsertClient()
        {
            return BusinesDeal.InsertBusinesDeal(ID, TypeId, ManId, Amount, BusinessPrice, ClientPrice, PaidMoney, Details, ManName, TypeName);
        }
 
        public bool UpdateBusinesDeal()
        {
            bool x= BusinesDeal.UpdateBusinesDeal(ID, TypeId, ManId, Amount, BusinessPrice, ClientPrice,PaidMoney, Details,ManName,TypeName);
          
         
            return x;

        }
        public static bool UpdateBusinesDeal(int id, int typeid, int manid, double amount, double businessprice, double clientprice, double paidmoney, string details, string manname, string typename)
        {
            BusinesDealDetails tb1 = new BusinesDealDetails(id, typeid, manid, amount, businessprice, clientprice, paidmoney, details, MyDateTime.Now, manname, typename);
           
            bool x= myRealProvider.UpdateBusinesDealy(tb1);
           
            return x;
        }
        public static List<BusinesDeal> Search(string key)
        {
            return BusinesDeal.GetBusinesDealFromBusinesDealDetails(myRealProvider.SearchBusinesDeal(key));

        }
        public static List<BusinesDeal> Search(int  typeid)
        {
            return BusinesDeal.GetBusinesDealFromBusinesDealDetails(myRealProvider.SearchBusinesDeal(typeid));

        }
        private static List<BusinesDeal> GetBusinesDealFromBusinesDealDetails(List<BusinesDealDetails> list)
        {
            List<BusinesDeal> newlist = new List<BusinesDeal>();
            foreach (BusinesDealDetails tbdt in list)
            {

             newlist.Add(new BusinesDeal(tbdt.ID,tbdt.TypeId,tbdt.ManId,tbdt.Amount,tbdt.BusinessPrice,tbdt.ClientPrice,tbdt.PaidMoney, tbdt.Details,tbdt.AddedDate,tbdt.ManName,tbdt.TypeName));
            }
            return newlist;
        }
        internal static object Search(int id, bool iscompany)
        {
            return BusinesDeal.GetBusinesDealFromBusinesDealDetails(myRealProvider.SearchBusinesDeal(id,iscompany));
        }
        internal static object Search(DateTime intimedateTime)
        {
         return GetBusinesDealFromBusinesDealDetails(myRealProvider.Search(intimedateTime));
        }
        internal static object Search(DateTime dateTime1, DateTime dateTime2)
        {
            return GetBusinesDealFromBusinesDealDetails(myRealProvider.Search(dateTime1, dateTime2));
        }
        internal static object Search(DateTime dateTime, int typid, int manid)
        {
            return GetBusinesDealFromBusinesDealDetails(myRealProvider.Search(dateTime, typid, manid));
        }
        internal static object Search(DateTime dateTime1, DateTime dateTime2, int typid, int manid)
        {          
            return GetBusinesDealFromBusinesDealDetails(myRealProvider.Search(dateTime1, dateTime2, typid, manid));
        }
        internal static object Search(DateTime dateTime1, DateTime dateTime2, int typid)
        {
            return GetBusinesDealFromBusinesDealDetails(myRealProvider.Search(dateTime1, dateTime2, typid));
        }
        internal static double GetAllAmount(int typeid, DateTime dateTime1, DateTime dateTime2)
        {
            return myRealProvider.GetAllAmount(typeid, dateTime1, dateTime2);
        }
        internal static double GetAllAmount(DateTime dateTime1, DateTime dateTime2)
        {
            return myRealProvider.GetAllAmount(dateTime1, dateTime2);
        }
        internal static double GetAllAmount(DateTime dateTime1)
        {
            return myRealProvider.GetAllAmount(dateTime1);
        }
        internal static double GetAllAmount(int typeid)
        {
            return myRealProvider.GetAllAmount(typeid);
        }
        internal static double GetAllTotalPrice(int typeid, DateTime dateTime1, DateTime dateTime2)
        {
         return myRealProvider.GetAllTotalPrice(typeid, dateTime1, dateTime2);
        }
        internal static double GetAllTotalPrice(DateTime dateTime1, DateTime dateTime2)
        {
            return myRealProvider.GetAllTotalPrice(dateTime1, dateTime2);
        }
        internal static double GetAllTotalPrice(DateTime dateTime1)
        {
            return myRealProvider.GetAllTotalPrice(dateTime1);
        }
        internal static double GetAllTotalPrice(int typeid)
        {
            return myRealProvider.GetAllTotalPrice(typeid);
        }
        internal static double GetAllPaidPrice(DateTime dateTime1, DateTime dateTime2)
        {
            return myRealProvider.GetAllPaidPrice(dateTime1, dateTime2);
        }
        internal static double GetAllPaidPrice(DateTime dateTime1)
        {
            return myRealProvider.GetAllPaidPrice(dateTime1);
        }
        internal static void DeleteAll()
        {
            myRealProvider.DeleteAllBusinessDeals();
        }
        //Add aLista.of BusinesDeal..
        internal static void InsertGroup(List<BusinesDeal> alcll)
        {
            myRealProvider.InsertGroup(alcll);
           
        }
    }
}
