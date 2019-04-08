using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeightsOrganizer.DAL;

namespace WeightsOrganizer.BLL
{
     [Serializable]
    class SalesReturns : DAL.ClientDealDetails
    {
    private static RealProvider myRealProvider = new RealProvider();

 
  
        public SalesReturns():base() { }

        public SalesReturns(int id, int typeid, int clientid, double amount, double price, double paidmoney, string details, MyDateTime addeddate, TheUnito theUnit, double businessprice, string clientname, string typename)
            : base(id, typeid, clientid, amount, price, paidmoney, details, addeddate, theUnit, businessprice,clientname,typename)
        { 
        
        }
        public override string ToString()
        {
            return this.TypeName;
        }

   
     protected string _ArabicUnit = null;
      public string ArabicUnit
     {
         set { _ArabicUnit = value; }
         get
            {
                switch (this.TheUnit)
                {
                    case TheUnito.Gram: _ArabicUnit = "غرام"; break;
                    case TheUnito.Kilo: _ArabicUnit = "كيلو"; break;
                    case TheUnito.Piece: _ArabicUnit = "قطعة"; break;
                }
                return _ArabicUnit;
            }
     } 
        protected double _ToTalPrice = 0;
        public double ToTalPrice
        {
            set { _ToTalPrice = value; }
            get
            {
                double amnt = 0;
                amnt = (this.TheUnit == TheUnito.Gram ? this.Amount / 1000 : this.Amount);
                return (amnt * this.Price);

            }
        }
        protected double _StayingPrice = 0;
        public double StayingPrice
        {
            set { _StayingPrice = value; }
            get
            {
                return ((this.ToTalPrice ) - this.PaidMoney);
            }
        }

        
        /// Real Business Logic layer begin Here!
        public static List<SalesReturns> GetAllClientDeal()
        {
          return GetClientDealFromClientDealDetails(myRealProvider.GetAllSalesReturns());
        }

        public static SalesReturns GetClientDealByID(int ido)
        {
            ClientDealDetails tbdt = myRealProvider.GetSalesReturnsByID(ido);
            if (tbdt != null) return new SalesReturns(tbdt.ID, tbdt.TypeId, tbdt.ClientId, tbdt.Amount, tbdt.Price, tbdt.PaidMoney, tbdt.Details, tbdt.AddedDate, tbdt.TheUnit, tbdt.BusinessPrice, tbdt.ClientName, tbdt.TypeName); else return null;
        }

        public SalesReturns GetClientDealByID()
        {
            return SalesReturns.GetClientDealByID(this.ID);
        }
        public bool DeleteClientDeal()
        {
            return SalesReturns.DeleteClientDeal(this.ID);
        }
        public static bool DeleteClientDeal(int ido)
        {
            return myRealProvider.DeleteSalesReturns(ido);
        }
        public static int InsertClientDeal(int id, int typeid, int clid, double amount, double price, double paidmoney, string details, TheUnito theUnit, double busprice, string clname, string typename, bool WithUpdatestore)
        {
            ClientDealDetails tb1 = new ClientDealDetails(id, typeid, clid, amount, price, paidmoney, details, new MyDateTime(DateTime.Now), theUnit, busprice, clname, typename);
            return myRealProvider.InsertSalesReturns(tb1);
        }
        public static int InsertClientDeal(int id, int typeid, int clid, double amount, double price, double paidmoney, string details, TheUnito theUnit, double busprice, string clname, string typename)
        {
            ClientDealDetails tb1 = new ClientDealDetails(id, typeid, clid, amount, price, paidmoney, details, new MyDateTime(DateTime.Now), theUnit, busprice, clname, typename);
            return myRealProvider.InsertSalesReturns(tb1);
        }
        public int InsertClientDeal()
        {
            return SalesReturns.InsertClientDeal(ID, TypeId, ClientId, Amount, Price, PaidMoney, Details, TheUnit, BusinessPrice, ClientName, TypeName);
        }
        public int InsertClientDeal(bool WithUpdatestore)
        {
            return SalesReturns.InsertClientDeal(ID, TypeId, ClientId, Amount, Price, PaidMoney, Details, TheUnit, BusinessPrice, ClientName, TypeName, WithUpdatestore);
        }
        public bool UpdateBusinesDeal()
        {
            return SalesReturns.UpdateClientDeal(ID, TypeId, ClientId, Amount, Price, PaidMoney, Details, BusinessPrice, ClientName, TypeName);

        }
        public static bool UpdateClientDeal(int id, int typeid, int clid, double amount, double price, double paidmoney, string details, double busprice,string clname,string typename)
        {
           // if ((Globals.Globals.gram==1)) amount = amount * 1000;
            ClientDealDetails tb1 = new ClientDealDetails(id, typeid, clid, amount, price, paidmoney, details, MyDateTime.Now, TheUnito.Kilo, busprice,clname,typename);
            return myRealProvider.UpdateSalesReturns(tb1);
        }

        public static List<SalesReturns> Search(string key)
        {
            return SalesReturns.GetClientDealFromClientDealDetails(myRealProvider.SearchSalesReturns(key));

        }

        private static List<SalesReturns> GetClientDealFromClientDealDetails(List<ClientDealDetails> list)
        {
            List<SalesReturns> newlist = new List<SalesReturns>();
            double newamnt = 0;
            foreach (ClientDealDetails tbdt in list)
            {
                newamnt = tbdt.Amount;
                newlist.Add(new SalesReturns(tbdt.ID, tbdt.TypeId, tbdt.ClientId, newamnt, tbdt.Price, tbdt.PaidMoney, tbdt.Details, tbdt.AddedDate, tbdt.TheUnit, tbdt.BusinessPrice, tbdt.ClientName, tbdt.TypeName));
               
            }
            return newlist;
        }

        internal static object Search(int id, bool iscompany)
        {
            return SalesReturns.GetClientDealFromClientDealDetails(myRealProvider.SearchSalesReturns(id, iscompany));
        }



        public static double GetdealPiecebyclient(int ido)
        {
            return myRealProvider.GetdealPiecebySalesReturns(ido);
        }
        
        public static double GetclientPaidPricebyclient(int ido)
        {
            return myRealProvider.GetclientPaidPriceSalesReturns(ido);
        }











        ///////////////////herr
        internal static object SearchClientDeals(DateTime dateTime1, DateTime dateTime2)
        {
            return GetClientDealFromClientDealDetails(myRealProvider.SearchClientDealsSalesReturns(dateTime1, dateTime2));
        }

        internal static object SearchClientDeals(DateTime dateTime1, DateTime dateTime2, int typid)
        {
            return GetClientDealFromClientDealDetails(myRealProvider.SearchClientDealsSalesReturns(dateTime1, dateTime2, typid));
        }
        internal static object SearchClientDeals(int typid)
        {
            return GetClientDealFromClientDealDetails(myRealProvider.SearchClientDealsSalesReturns(typid));
        }
        internal static object Search(DateTime intimedateTime)
        {
            return GetClientDealFromClientDealDetails(myRealProvider.SearchCSalesReturns(intimedateTime));
        }
        internal static object Search(DateTime dateTime1, DateTime dateTime2)
        {
            return GetClientDealFromClientDealDetails(myRealProvider.SearchCSalesReturns(dateTime1, dateTime2));
        }

        internal static object Search(DateTime dateTime, int typid, int manid)
        {
            return GetClientDealFromClientDealDetails(myRealProvider.SearchCSalesReturns(dateTime, typid, manid));
        }
        internal static object Search(DateTime dateTime1, DateTime dateTime2, int typid, int manid)
        {
            return GetClientDealFromClientDealDetails(myRealProvider.SearchCSalesReturns(dateTime1, dateTime2, typid, manid));
        }

        internal static double GetAllAmount(int typeid, DateTime dateTime1, DateTime dateTime2)
        {
            return myRealProvider.GetAllAmountCSalesReturns(typeid, dateTime1, dateTime2);
        }
        internal static double GetAllAmount(DateTime dateTime1, DateTime dateTime2)
        {
            return myRealProvider.GetAllAmountCSalesReturns(dateTime1, dateTime2);
        }
        internal static double GetAllAmount(DateTime dateTime1)
        {
            return myRealProvider.GetAllAmountCSalesReturns(dateTime1);
        }
        internal static double GetAllAmount(int typeid)
        {
            return myRealProvider.GetAllAmountCSalesReturns(typeid);
        }




        internal static double GetAllTotalPrice(int typeid, DateTime dateTime1, DateTime dateTime2)
        {
            return myRealProvider.GetAllTotalPriceCSalesReturns(typeid, dateTime1, dateTime2);
        }
        internal static double GetAllTotalPrice(DateTime dateTime1, DateTime dateTime2)
        {
            return myRealProvider.GetAllTotalPriceCSalesReturns(dateTime1, dateTime2);
        }
        internal static double GetAllTotalPrice(DateTime dateTime1)
        {
            return myRealProvider.GetAllTotalPriceCSalesReturns(dateTime1);
        }
        internal static double GetAllTotalPrice(int typeid)
        {
            return myRealProvider.GetAllTotalPriceCSalesReturns(typeid);
        }



        internal static double GetAllPaidPrice(int typeid, DateTime dateTime1, DateTime dateTime2)
        {
            return myRealProvider.GetAllPaidPriceCSalesReturns(typeid, dateTime1, dateTime2);
        }
        internal static double GetAllPaidPrice(DateTime dateTime1, DateTime dateTime2)
        {
            return myRealProvider.GetAllPaidPriceCSalesReturns(dateTime1, dateTime2);
        }
        internal static double GetAllPaidPrice(DateTime dateTime1)
        {
            return myRealProvider.GetAllPaidPriceCSalesReturns(dateTime1);
        }
        internal static double GetAllPaidPrice(int typeid)
        {
            return myRealProvider.GetAllPaidPriceCSalesReturns(typeid);
        }


        internal static double GetAllProfit(int typeid, DateTime dateTime1, DateTime dateTime2)
        {
            return myRealProvider.GetAllProfitSalesReturns(typeid, dateTime1, dateTime2);
        }
        internal static double GetAllProfit(DateTime dateTime1, DateTime dateTime2)
        {
            return myRealProvider.GetAllProfitSalesReturns(dateTime1, dateTime2);
        }
        internal static double GetAllProfit(DateTime dateTime1)
        {
            return myRealProvider.GetAllProfitSalesReturns(dateTime1);
        }
        internal static double GetAllProfit(int typeid)
        {
            return myRealProvider.GetAllProfitSalesReturns(typeid);
        }



        internal static bool DeleteClientDealByIDclient(int p)
        {
            return myRealProvider.DeleteClientDealByIDclientSalesReturns(p);    
        }

        internal static void DeleteAll()
        {
            myRealProvider.DeleteAllClientDealsSalesReturns();       
        }

        internal static void InsertClientDeal(List<SalesReturns> alcll)
        {
          myRealProvider.InsertSalesReturns(alcll);
        }
    }
   
}
