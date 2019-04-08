using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeightsOrganizer.DAL
{
    class LastCompanyAccountDetails
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
        protected int _ManId = 0;
        public int ManId
        {
            get { return _ManId; }
            set { _ManId = value; }
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
        public LastCompanyAccountDetails() { }
        public LastCompanyAccountDetails(int id, int manid, double can, double number, double sar, MyDateTime addeddate)
        {
            this.ID = id;
            this.ManId = manid;
            this.Can = can;
            this.Sar = sar;
            this.Number = number;
            this.AddedDate = addeddate;
        }
    }
}
