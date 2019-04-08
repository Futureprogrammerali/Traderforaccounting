using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeightsOrganizer.DAL
{
    class ArchivesDetails
    {
        protected string _Details = " ";
        public string Details
        {
            get { return _Details; }
            set { if (string.IsNullOrEmpty(value)) value = _Details; _Details = value; }
        }
 
        protected MyDateTime _AddedDate2 = MyDateTime.Now;
        public MyDateTime AddedDate2
        {
            get { return _AddedDate2; }
            set
            {
                if (value == null) value = _AddedDate2;
                _AddedDate2 = value;
            }
        }
        protected MyDateTime _AddedDate1 = MyDateTime.Now;
        public MyDateTime AddedDate1
        {
            get { return _AddedDate1; }
            set
            {
                if (value == null) value = _AddedDate1;
                _AddedDate1 = value;
            }
        }
        protected MyDateTime _AddedDate = MyDateTime.Now;
        public MyDateTime AddedDate
        {
            get { return _AddedDate; }
            set
            {
                if (value == null) value = _AddedDate;
                _AddedDate = value;
            }
        }
        protected int _id = 0;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        protected double _ٍٍProfit = 0;
        public double  Profit
        {
            get { return _ٍٍProfit; }
            set { _ٍٍProfit = value; }
        }
        protected double _ٍٍStayingPrice = 0;
        public double StayingPrice
        {
            get { return _ٍٍStayingPrice; }
            set { _ٍٍStayingPrice = value; }
        }
        protected double _ٍٍAmount = 0;
        public double Amount
        {
            get { return _ٍٍAmount; }
            set { _ٍٍAmount = value; }
        }
        
        protected double _Price = 0;
        public double Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        public double _PaidMoney = 0;
        public double PaidMoney
        {
            get { return _PaidMoney; }
            set { _PaidMoney = value; }
        }
        byte _SmallType = 1;
        public byte SmallType
        {
            get { return _SmallType; }
            set { _SmallType = value; }
        }
        byte _BigType = 1;
        public byte BigType
        {
            get { return _BigType; }
            set { _BigType = value; }
        }
        public ArchivesDetails(int id, byte bigType, byte smallType,double amount, double price, double paidMoney, double stayingPrice, double profit, MyDateTime addeddate1, MyDateTime addeddate2,MyDateTime addedDate, string details)
        {
            this.ID = id;
            this.Details = details;
            this.PaidMoney = paidMoney;
            this.Amount = amount;
            this.Price = price;
            this.BigType = bigType;
            this.SmallType = smallType;
            this.AddedDate1 = addeddate1;
            this.AddedDate2 = addeddate2;
            this.AddedDate = addedDate;
            this.StayingPrice = stayingPrice;
            this.Profit = profit;
        }
    }
}
