using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeightsOrganizer.DAL
{
    class LastClientsAccountDetails
    {
         protected MyDateTime _AddedDate = MyDateTime.Now;
         public MyDateTime AddedDate
        {
            get { return  _AddedDate  ; }
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
        protected int _ClientId = 0;
        public int ClientId
        {
            get { return _ClientId; }
            set { _ClientId = value; }
        }
        protected double _Number = 0;
        public double Number
        {
            get { return _Number; }
            set { _Number = value; }
        }
        protected double _Can = 0;
        public double Can
        {
            get { return _Can; }
            set { _Can = value; }
        }
        protected double _Sar = 0;
        public double Sar
        {
            get { return _Sar; }
            set { _Sar = value; }
        }
        public LastClientsAccountDetails() { }
        public LastClientsAccountDetails(int id, int clientId, double can, double number, double sar, MyDateTime addeddate)
        {
            this.ID = id;
            this.ClientId = clientId;
            this.Can = can;
            this.Sar = sar;
            this.Number = number;
            this.AddedDate = addeddate;
        }
    }
}
