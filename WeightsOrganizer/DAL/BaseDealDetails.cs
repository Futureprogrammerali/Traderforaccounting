using System;
using System.Collections.Generic;

using System.Text;

namespace WeightsOrganizer.DAL
{
    /// <summary>
    /// عمومية تغليف الصفقات
    /// </summary>
    [Serializable]
  public   class BaseDealDetails:BaseDetails
    {
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
        public BaseDealDetails():base() { }
        public BaseDealDetails(int id, int typeid, double amount, string details, MyDateTime addeddate)
            : base(id, "deal", details, addeddate)
        {
            this.TypeId = typeid;
            this.Amount = amount;
        }
    }
}
