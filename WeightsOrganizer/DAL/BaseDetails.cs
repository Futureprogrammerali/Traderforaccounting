using System;
using System.Collections.Generic;

using System.Text;

namespace WeightsOrganizer.DAL
{
    /// <summary>
    /// عمومية التغليف
    /// </summary>
    [Serializable]
  public  class BaseDetails
    {
  
        public DateTime OrAddedDate
        {
            get { return AddedDate.MyDateTimeasDateTime; }
        }

        protected string _Details = " ";
        public string Details
        {
            get { return _Details; }
            set { if (string.IsNullOrEmpty(value)) value = _Details; _Details = value; }
        }
        protected string _Name = "الاسم";
        public string Name
        {
            get { return _Name; }
            set { if (string.IsNullOrEmpty(value)) value = _Name; _Name = value; }
        }

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

        public BaseDetails() { }
        public BaseDetails(int id, string name, string details, MyDateTime addeddate)
        {
            this.ID = id;
            this.Details = details;
            this.AddedDate = addeddate;
            this.Name = name;
        }
    }
}
