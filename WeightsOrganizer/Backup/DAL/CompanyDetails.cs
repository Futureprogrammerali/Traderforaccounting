using System;
using System.Collections.Generic;

using System.Text;

namespace WeightsOrganizer.DAL
{
    /// <summary>
    /// تغليف الشركة او التاجر
    /// </summary>
    [Serializable]
    class CompanyDetails:BaseDetails
    {
         public CompanyDetails():base()
        {
        }
         protected double _Balance = 0;
         public double Balance
         {
             get { return _Balance; }
             set { _Balance = value; }
         }
         public CompanyDetails(int id, string name, string details, MyDateTime addeddate  )
             : base(id, name, details, addeddate)
         {
         
         }
         public CompanyDetails(int id, string name, string details, MyDateTime addeddate,double blance)
            : base(id, name, details, addeddate)
        {
            this.Balance = blance;  
        }
    }
}
