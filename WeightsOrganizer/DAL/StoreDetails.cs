using System;
using System.Collections.Generic;

using System.Text;

namespace WeightsOrganizer.DAL
{
    /// <summary>
    /// تغليف المخزن يتعدل المخزن عند عقد صفقة مع تاجر او زبون
    /// </summary>
    class StoreDetails
    {
        protected int _id = 0;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private double _Amount = 0;
        public double Amount
        {
            get
            {
                return _Amount;
            }
            set
            {
                _Amount = value;
            }
        }
        protected int _TypeId = 0;
        public int TypeId
        {
            get { return _TypeId; }
            set { _TypeId = value; }
        }
        protected string _TypeName = null;
        public string TypeName
        {
            set { _TypeName = value; }
            get
            {
                if ((_TypeName == null) && TypeId > 0)   return "الصنف";
                return _TypeName;     
            }
        }
        protected DateTime _AddedDateCompany = DateTime.Now;
        public DateTime AddedDateCompany
        {
            get { return _AddedDateCompany; }
            set
            {
                if (value == null) value = _AddedDateCompany;
                _AddedDateCompany = value;
            }
        }
        protected DateTime _AddedDateClient = DateTime.Now;
        public DateTime AddedDateClient
        {
            get { return _AddedDateClient; }
            set
            {
                if (value == null) value = _AddedDateClient;
                _AddedDateClient = value;
            }
        }


        public StoreDetails(int id, int typeid ,   double amount, DateTime addedDatecompany, DateTime addedDateclient,string typename)
        {
            this.ID = id;
            this.TypeId = typeid;
            this.Amount = amount;
            this.AddedDateClient = addedDateclient;
            this.AddedDateCompany = addedDatecompany;
            this.TypeName = typename;
        }
    }
}
