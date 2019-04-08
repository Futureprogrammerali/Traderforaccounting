using System;
using System.Collections.Generic;

using System.Text;

namespace WeightsOrganizer.DAL
{
    /// <summary>
    /// تغليف الصفقة مع الشركة
    /// </summary>
    class BusinesDealDetails:BaseDealDetails
    {
        protected int _ManId = 0;
        public int ManId
        {
            get { return _ManId; }
            set { _ManId = value; }
        }

        protected string _TypeName = "االصنف";
        public string TypeName
        {
          get { return _TypeName; }
            set { if (string.IsNullOrEmpty(value)) value = _TypeName; _TypeName = value; }
        }
        protected string _ManName = "التاجر";
        public string ManName
        {
            get { return _ManName; }
            set { if (string.IsNullOrEmpty(value)) value = _ManName; _ManName = value; }
        }



        protected double _BusinessPrice = 0;
        public double BusinessPrice
        {
            get { return _BusinessPrice; }
            set { _BusinessPrice = value; }
        }
        protected double _ClientPrice = 0;
        public double ClientPrice
        {
            get { return _ClientPrice; }
            set { _ClientPrice = value; }
        }
        
        protected double _PaidMoney = 0;
        public double PaidMoney
        {
            get { return _PaidMoney; }
            set { _PaidMoney = value; }
        }
        
        public BusinesDealDetails():base() { }
        public BusinesDealDetails(int id, int typeid, int manid, double amount, double businessprice, double clientprice, double paidmoney, string details, MyDateTime addeddate,string manname,string typename)
            :base(id,typeid,amount,details,addeddate)
        {
            this.ManId = manid;
            this.ClientPrice = clientprice;
            this.PaidMoney=paidmoney;
            this.BusinessPrice = businessprice;
            this.ManName = manname; 
            this.TypeName = typename;
        } 
    }
}
