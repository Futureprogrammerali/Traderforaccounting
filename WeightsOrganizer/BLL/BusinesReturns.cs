using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeightsOrganizer.DAL;

namespace WeightsOrganizer.BLL
{
    class BusinesReturns :DAL.BusinesDealDetails
    {
          private static RealProvider myRealProvider = new RealProvider();
        public BusinesReturns():base() { }
        public BusinesReturns(int id, int typeid, int manid, double amount, double businessprice, double clientprice, double paidmoney, string details, MyDateTime addeddate, string manname, string typename)
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
        public static List<BusinesReturns> GetAllBusinesDeal()
        {
            return GetBusinesDealFromBusinesDealDetails(myRealProvider.GetAllBusinesReturns());
        }

        public static BusinesReturns GetBusinesDealByID(int ido)
        {
            BusinesDealDetails tbdt = myRealProvider.GetBusinesReturnsByID(ido);
            if (tbdt != null) return new BusinesReturns(tbdt.ID, tbdt.TypeId, tbdt.ManId, tbdt.Amount, tbdt.BusinessPrice, tbdt.ClientPrice, tbdt.PaidMoney, tbdt.Details, tbdt.AddedDate, tbdt.ManName, tbdt.TypeName); else return null;
        }


        public BusinesReturns GetBusinesDealByID()
        {
            return BusinesReturns.GetBusinesDealByID(this.ID);
        }
        public bool DeleteClient()
        {
            return BusinesDeal.DeleteBusinesDeal(this.ID);
        }
        public static bool DeleteBusinesDeal(int ido)
        {
            return myRealProvider.DeleteBusinesReturns(ido);
        }
        public static bool DeleteBusinesReturns(int ido)
        {
            return myRealProvider.DeleteBusinesReturns(ido);
        }
        public static bool DeleteBusinesDealByIDman(int ido)
        {
            return myRealProvider.DeleteBusinesReturnsByIDman(ido);
        }
        public static int InsertBusinesDeal(int id, int typeid, int manid, double amount, double businessprice, double clientprice, double paidmoney, string details, string manname, string typename)
        {
            BusinesDealDetails tb1 = new BusinesDealDetails(id, typeid, manid, amount, businessprice, clientprice, paidmoney, details, MyDateTime.Now, manname, typename);
            int x = myRealProvider.InsertBusinesReturns(tb1);
            return x;
        }
        public int InsertClient()
        {
            return BusinesReturns.InsertBusinesDeal(ID, TypeId, ManId, Amount, BusinessPrice, ClientPrice, PaidMoney, Details, ManName, TypeName);
            
        }
        public bool UpdateBusinesDeal()
        {
            bool x = BusinesReturns.UpdateBusinesDeal(ID, TypeId, ManId, Amount, BusinessPrice, ClientPrice, PaidMoney, Details, ManName, TypeName);
          
            return x;

        }
        public static bool UpdateBusinesDeal(int id, int typeid, int manid, double amount, double businessprice, double clientprice, double paidmoney, string details, string manname, string typename)
        {
            BusinesDealDetails tb1 = new BusinesDealDetails(id, typeid, manid, amount, businessprice, clientprice, paidmoney, details, MyDateTime.Now, manname, typename);
           
            bool x= myRealProvider.UpdateBusinesReturnsy(tb1);
            return x;
        }

        public static List<BusinesReturns> Search(string key)
        {
            return BusinesReturns.GetBusinesDealFromBusinesDealDetails(myRealProvider.SearchBusinesReturns(key));

        }

        public static List<BusinesReturns> Search(int typeid)
        {
            return BusinesReturns.GetBusinesDealFromBusinesDealDetails(myRealProvider.SearchBusinesDeal(typeid));
        }

        private static List<BusinesReturns> GetBusinesDealFromBusinesDealDetails(List<BusinesDealDetails> list)
        {
            List<BusinesReturns> newlist = new List<BusinesReturns>();
            foreach (BusinesDealDetails tbdt in list)
            {

                newlist.Add(new BusinesReturns(tbdt.ID, tbdt.TypeId, tbdt.ManId, tbdt.Amount, tbdt.BusinessPrice, tbdt.ClientPrice, tbdt.PaidMoney, tbdt.Details, tbdt.AddedDate, tbdt.ManName, tbdt.TypeName));
            }
            return newlist;
        }

        internal static object Search(int id, bool iscompany)
        {
            return BusinesReturns.GetBusinesDealFromBusinesDealDetails(myRealProvider.SearchBusinesReturns(id, iscompany));
        }


        internal static object Search(DateTime intimedateTime)
        {
            return GetBusinesDealFromBusinesDealDetails(myRealProvider.SearchBusinesReturns(intimedateTime));
        }
        internal static object Search(DateTime dateTime1, DateTime dateTime2)
        {
            return GetBusinesDealFromBusinesDealDetails(myRealProvider.SearchBusinesReturns(dateTime1, dateTime2));
        }
        internal static object Search(DateTime dateTime, int typid, int manid)
        {
            return GetBusinesDealFromBusinesDealDetails(myRealProvider.SearchBusinesReturns(dateTime, typid, manid));
        }
        internal static object Search(DateTime dateTime1, DateTime dateTime2, int typid, int manid)
        {          
            return GetBusinesDealFromBusinesDealDetails(myRealProvider.Search(dateTime1, dateTime2, typid, manid));
        }

        internal static object Search(DateTime dateTime1, DateTime dateTime2, int typid)
        {
            return GetBusinesDealFromBusinesDealDetails(myRealProvider.SearchBusinesReturns(dateTime1, dateTime2, typid));
        }


        internal static double GetAllAmount(int typeid, DateTime dateTime1, DateTime dateTime2)
        {
            return myRealProvider.GetAllAmountBusinesReturns(typeid, dateTime1, dateTime2);
        }
        internal static double GetAllAmount(DateTime dateTime1, DateTime dateTime2)
        {
            return myRealProvider.GetAllAmountBusinesReturns(dateTime1, dateTime2);
        }
        internal static double GetAllAmount(DateTime dateTime1)
        {
            return myRealProvider.GetAllAmountBusinesReturns(dateTime1);
        }
        internal static double GetAllAmount(int typeid)
        {
            return myRealProvider.GetAllAmountBusinesReturns(typeid);
        }




        internal static double GetAllTotalPrice(int typeid, DateTime dateTime1, DateTime dateTime2)
        {
            return myRealProvider.GetAllTotalPriceBusinesReturns(typeid, dateTime1, dateTime2);
        }
        internal static double GetAllTotalPrice(DateTime dateTime1, DateTime dateTime2)
        {
            return myRealProvider.GetAllTotalPriceBusinesReturns(dateTime1, dateTime2);
        }
        internal static double GetAllTotalPrice(DateTime dateTime1)
        {
            return myRealProvider.GetAllTotalPriceBusinesReturns(dateTime1);
        }
        internal static double GetAllTotalPrice(int typeid)
        {
            return myRealProvider.GetAllTotalPriceBusinesReturns(typeid);
        }




        internal static double GetAllPaidPrice(DateTime dateTime1, DateTime dateTime2)
        {
            return myRealProvider.GetAllPaidPriceBusinesReturns(dateTime1, dateTime2);
        }
        internal static double GetAllPaidPrice(DateTime dateTime1)
        {
            return myRealProvider.GetAllPaidPriceBusinesReturns(dateTime1);
        }


        internal static void DeleteAll()
        {
            myRealProvider.DeleteAllBusinesReturns();
        }



        internal static  void  InsertBusinesReturns(List<BusinesReturns> alcll)
        {
              myRealProvider.InsertBusinesReturns(alcll);
              WeightsOrganizer.BLL.BllGlobal.UpdateAllStore();
        }
    }
}
