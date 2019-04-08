using System;
using System.Collections.Generic;

using System.Text;

namespace WeightsOrganizer.DAL
{
    /// <summary>
    /// تغليف الزبون
    /// </summary>
      [Serializable]
    class ClientDetails:BaseDetails
    {
        protected double _Balance = 0;
        public double Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }
        public ClientDetails():base()
        {
        }
        public ClientDetails(int id, string name, string details, MyDateTime addeddate)
            : base(id, name, details, addeddate)
        {
            this.Balance = 0;
        }
        public ClientDetails(int id, string name, string details, MyDateTime addeddate,double blance)
            : base(id, name, details, addeddate)
        {
            this.Balance =blance;
        }
    }
}
