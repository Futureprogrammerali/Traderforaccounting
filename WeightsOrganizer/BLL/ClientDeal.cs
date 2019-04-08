using System;
using System.Collections.Generic;

using System.Text;
using WeightsOrganizer.DAL;
public enum TheUnito : int
{
    Gram = 0, Kilo = 1, Piece = 2
}
namespace WeightsOrganizer.BLL
{
    [Serializable]
   public class ClientDeal:DAL.ClientDealDetails
    {
       private static RealProvider myRealProvider = new RealProvider();

 
  
        public ClientDeal():base() { }

        public ClientDeal(int id, int typeid, int clientid, double amount, double price, double paidmoney, string details, MyDateTime addeddate, TheUnito theUnit, double businessprice,string clientname,string typename)
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
        public static List<ClientDeal> GetAllClientDeal()
        {
          return GetClientDealFromClientDealDetails(myRealProvider.GetAllClientDeals());
        }

        public static ClientDeal GetClientDealByID(int ido)
        {
            ClientDealDetails tbdt = myRealProvider.GetClientDealByID(ido);
            if (tbdt != null) return new ClientDeal(tbdt.ID, tbdt.TypeId, tbdt.ClientId, tbdt.Amount, tbdt.Price, tbdt.PaidMoney, tbdt.Details, tbdt.AddedDate, tbdt.TheUnit, tbdt.BusinessPrice, tbdt.ClientName, tbdt.TypeName); else return null;
        }

        public ClientDeal GetClientDealByID()
        {
            return ClientDeal.GetClientDealByID(this.ID);
        }
        public bool DeleteClientDeal()
        {
            return ClientDeal.DeleteClientDeal(this.ID);
        }
        public static bool DeleteClientDeal(int ido)
        {
            return myRealProvider.DeleteClientDeal(ido);
        }
        public static int InsertClientDeal(int id, int typeid, int clid, double amount, double price, double paidmoney, string details, TheUnito theUnit, double busprice, string clname, string typename, bool opencon)
        {
            ClientDealDetails tb1 = new ClientDealDetails(id, typeid, clid, amount, price, paidmoney, details, new MyDateTime(DateTime.Now), theUnit, busprice, clname, typename);
            return myRealProvider.InsertClientDeal(tb1, opencon);
        }
        public static int InsertClientDeal(int id, int typeid, int clid, double amount, double price, double paidmoney, string details, TheUnito theUnit, double busprice, string clname, string typename)
        {
            ClientDealDetails tb1 = new ClientDealDetails(id, typeid, clid, amount, price, paidmoney, details, new MyDateTime(DateTime.Now), theUnit, busprice, clname, typename);
            return myRealProvider.InsertClientDeal(tb1);
        }
        public static int InsertClientDeal(int id, int typeid, int clid, double amount, double price, double paidmoney, string details, MyDateTime dayandtime, TheUnito theUnit, double busprice, string clname, string typename)
        {
            ClientDealDetails tb1 = new ClientDealDetails(id, typeid, clid, amount, price, paidmoney, details, dayandtime, theUnit, busprice, clname, typename);
            return myRealProvider.InsertClientDeal(tb1);
        }
        public int InsertClientDeal()
        {
            return ClientDeal.InsertClientDeal(ID, TypeId, ClientId, Amount, Price, PaidMoney, Details, TheUnit, BusinessPrice, ClientName, TypeName);
        }
        public int InsertClientDeal(bool openconection)
        {
            if (openconection)
            return  this.InsertClientDeal(); 
            else
                return ClientDeal.InsertClientDeal(ID, TypeId, ClientId, Amount, Price, PaidMoney, Details, TheUnit, BusinessPrice, ClientName, TypeName, openconection);
           
        }
        public bool UpdateBusinesDeal()
        {
            return ClientDeal.UpdateClientDeal(ID, TypeId, ClientId, Amount, Price, PaidMoney, Details, BusinessPrice,ClientName,TypeName );

        }
        public static bool UpdateClientDeal(int id, int typeid, int clid, double amount, double price, double paidmoney, string details, double busprice,string clname,string typename)
        {
           // if ((Globals.Globals.gram==1)) amount = amount * 1000;
            ClientDealDetails tb1 = new ClientDealDetails(id, typeid, clid, amount, price, paidmoney, details, MyDateTime.Now, TheUnito.Kilo, busprice,clname,typename);
            return myRealProvider.UpdateClientDealy(tb1);
        }

        public static List<ClientDeal> Search(string key)
        {
            return ClientDeal.GetClientDealFromClientDealDetails(myRealProvider.SearchClientDeal(key));

        }

        private static List<ClientDeal> GetClientDealFromClientDealDetails(List<ClientDealDetails> list)
        {
            List<ClientDeal> newlist = new List<ClientDeal>();
            double newamnt = 0;
            foreach (ClientDealDetails tbdt in list)
            {
                //switch (tbdt.TheUnit)
                //{
                //    case TheUnito.Gram: newamnt = tbdt.Amount; break;
                //    case TheUnito.Kilo: newamnt = tbdt.Amount/1000; break;
                //    case TheUnito.Piece: newamnt = tbdt.Amount; break;
                //}
                newamnt = tbdt.Amount;
                newlist.Add(new ClientDeal(tbdt.ID, tbdt.TypeId, tbdt.ClientId, newamnt, tbdt.Price, tbdt.PaidMoney, tbdt.Details, tbdt.AddedDate, tbdt.TheUnit,tbdt.BusinessPrice,tbdt.ClientName,tbdt.TypeName));
               
            }
            return newlist;
        }

        internal static object Search(int id, bool iscompany)
        {
            return ClientDeal.GetClientDealFromClientDealDetails(myRealProvider.SearchClientDeal(id,iscompany));
        }



        public static double GetdealPiecebyclient(int ido)
        {
            return myRealProvider.GetdealPiecebyclient(ido);
        }
        
        public static double GetclientPaidPricebyclient(int ido)
        {
            return myRealProvider.GetclientPaidPricebyclient(ido);
        }











        ///////////////////herr
        internal static object SearchClientDeals(DateTime dateTime1, DateTime dateTime2)
        {
            return GetClientDealFromClientDealDetails(myRealProvider.SearchClientDeals(dateTime1, dateTime2));
        }
        internal static object SearchClientDeals(DateTime dateTime1, DateTime dateTime2, int typid)
        {
            return GetClientDealFromClientDealDetails(myRealProvider.SearchClientDeals(dateTime1, dateTime2, typid));
        }
        internal static object SearchClientDeals(int typid)
        {
            return GetClientDealFromClientDealDetails(myRealProvider.SearchClientDeals( typid));
        }
        internal static object Search(DateTime intimedateTime)
        {
            return GetClientDealFromClientDealDetails(myRealProvider.SearchC(intimedateTime));
        }
        internal static object Search(DateTime dateTime1, DateTime dateTime2)
        {
            return GetClientDealFromClientDealDetails(myRealProvider.SearchC(dateTime1, dateTime2));
        }
        internal static object Search(DateTime dateTime, int typid, int manid)
        {
            return GetClientDealFromClientDealDetails(myRealProvider.SearchC(dateTime, typid, manid));
        }
        internal static object Search(DateTime dateTime1, DateTime dateTime2, int typid, int manid)
        {
            return GetClientDealFromClientDealDetails(myRealProvider.SearchC(dateTime1, dateTime2, typid, manid));
        }

        internal static double GetAllAmount(int typeid, DateTime dateTime1, DateTime dateTime2)
        {
            return myRealProvider.GetAllAmountC(typeid, dateTime1, dateTime2);
        }
        internal static double GetAllAmount(DateTime dateTime1, DateTime dateTime2)
        {
            return myRealProvider.GetAllAmountC(dateTime1, dateTime2);
        }
        internal static double GetAllAmount(DateTime dateTime1)
        {
            return myRealProvider.GetAllAmountC(dateTime1);
        }
        internal static double GetAllAmount(int typeid)
        {
            return myRealProvider.GetAllAmountC(typeid);
        }




        internal static double GetAllTotalPrice(int typeid, DateTime dateTime1, DateTime dateTime2)
        {
            return myRealProvider.GetAllTotalPriceC(typeid, dateTime1, dateTime2);
        }
        internal static double GetAllTotalPrice(DateTime dateTime1, DateTime dateTime2)
        {
            return myRealProvider.GetAllTotalPriceC(dateTime1, dateTime2);
        }
        internal static double GetAllTotalPrice(DateTime dateTime1)
        {
            return myRealProvider.GetAllTotalPriceC(dateTime1);
        }
        internal static double GetAllTotalPrice(int typeid)
        {
            return myRealProvider.GetAllTotalPriceC(typeid);
        }



        internal static double GetAllPaidPrice(int typeid, DateTime dateTime1, DateTime dateTime2)
        {
            return myRealProvider.GetAllPaidPriceC(typeid, dateTime1, dateTime2);
        }
        internal static double GetAllPaidPrice(DateTime dateTime1, DateTime dateTime2)
        {
            return myRealProvider.GetAllPaidPriceC(dateTime1, dateTime2);
        }
        internal static double GetAllPaidPrice(DateTime dateTime1)
        {
            return myRealProvider.GetAllPaidPriceC(dateTime1);
        }
        internal static double GetAllPaidPrice(int typeid)
        {
            return myRealProvider.GetAllPaidPriceC(typeid);
        }


        internal static double GetAllProfit(int typeid, DateTime dateTime1, DateTime dateTime2)
        {
            return myRealProvider.GetAllProfit(typeid, dateTime1, dateTime2);
        }
        internal static double GetAllProfit(DateTime dateTime1, DateTime dateTime2)
        {
            return myRealProvider.GetAllProfit(dateTime1, dateTime2);
        }
        internal static double GetAllProfit(DateTime dateTime1)
        {
            return myRealProvider.GetAllProfit(dateTime1);
        }
        internal static double GetAllProfit(int typeid)
        {
            return myRealProvider.GetAllProfit(typeid);
        }



        internal static bool DeleteClientDealByIDclient(int p)
        {
            return myRealProvider.DeleteClientDealByIDclient(p);    
        }

        internal static void DeleteAll()
        {
            myRealProvider.DeleteAllClientDeals();       
        }

        internal static void InsertGroup(List<ClientDeal> alcll)
        {
            myRealProvider.InsertGroupDeal(alcll);

        }
    }
   
}
