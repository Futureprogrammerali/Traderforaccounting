using System;
using System.Collections.Generic;

using System.Text;

namespace WeightsOrganizer.DAL
{
    /// <summary>
    /// تغليف الصنف او النوع
    /// </summary>
    [Serializable] 
   public  class TypeDetails:BaseDetails
    {
        private double _BusinessPrice = 0;
        public double BusinessPrice
        {
            get
            {
                return _BusinessPrice;
            }
            set
            {
                _BusinessPrice = value;
            }
        }
        TheUnito _TheUnit = TheUnito.Kilo;
        public TheUnito TheUnit
        {
            get { return _TheUnit; }
            set { _TheUnit = value; }
        }  
        private double _ClientPrice = 0;
        public double ClientPrice
        {
            get
            {
                return _ClientPrice;
            }
            set
            {
                _ClientPrice = value;
            }
        }
        private double _BusinessClientPrice = 0;
        public double BusinessClientPrice
        {
            get
            {
                return _BusinessClientPrice;
            }
            set
            {
                _BusinessClientPrice = value;
            }
        }
        string _AllCompanyId ="";
        public string AllCompanyId
        {
            get { return _AllCompanyId; }
            set { _AllCompanyId = value; }
        }
        protected string _BaraCode = "0";
        public string BaraCode
        {
            get { return _BaraCode; }
            set { if (string.IsNullOrEmpty(value)) value = _BaraCode; _BaraCode = value; }
        }
     
        public TypeDetails():base()
        {
        }

        public TypeDetails(int id, string name, double businessprice, double clientprice, double businessclientprice, MyDateTime addeddate, string allCompanyId, TheUnito theUnit,string baracode)
            : base(id, name, "type", addeddate)
        {
            this.BusinessPrice = businessprice;
            this.ClientPrice = clientprice;
            this.BusinessClientPrice = businessclientprice;
            this.AllCompanyId = allCompanyId;
            this.TheUnit = theUnit;
            this.BaraCode = baracode;
           
        }
    }
}
