using System;
using System.Collections.Generic;

using System.Text;

namespace WeightsOrganizer.DAL
{
    /// <summary>
    /// تغليف الصفقة مع الزبون
    /// </summary>
    [Serializable]
 public class ClientDealDetails : BaseDealDetails
    {


        protected string _TypeName = "االصنف";
        public string TypeName
        {
            get { return _TypeName; }
            set { if (string.IsNullOrEmpty(value)) value = _TypeName; _TypeName = value; }
        }
        protected string _ClientName = "الزبون";
        public string ClientName
        {
            get { return _ClientName; }
            set { if (string.IsNullOrEmpty(value)) value = _ClientName; _ClientName = value; }
        }
 
        protected int _ClientId = 0;
        public int ClientId
        {
            get { return _ClientId; }
            set { _ClientId = value; }
        }
        protected double _BusinessPrice = 0;
        public double BusinessPrice
        {
            get { return _BusinessPrice; }
            set { _BusinessPrice = value; }
        }
        protected double _Price = 0;
        public double Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        protected double _PaidMoney = 0;
        public double PaidMoney
        {
            get {  return _PaidMoney; }
            set { _PaidMoney = value; }
        }
        TheUnito _TheUnit = TheUnito.Kilo;
        public TheUnito TheUnit
        {
            get { return _TheUnit; }
            set { _TheUnit = value; }
        }  
        public ClientDealDetails() : base() { }
        public ClientDealDetails(int id, int typeid, int clientid, double amount, double price, double paidmoney, string details, MyDateTime addeddate, TheUnito theUnit, double businessPrice, string clientname, string typename)
            :base(id,typeid,amount,details,addeddate)
        {
            this.ClientId = clientid;
            this.BusinessPrice = businessPrice;
            this.PaidMoney = paidmoney;
            this.Price = price;
            this.TheUnit = theUnit;
            this.ClientName = clientname;
            this.TypeName = typename;
        } 
    }
}
