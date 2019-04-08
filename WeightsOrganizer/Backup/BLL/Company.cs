using System;
using System.Collections.Generic;

using System.Text;
using WeightsOrganizer.DAL;

namespace WeightsOrganizer.BLL
{
    [Serializable]
    class Company :CompanyDetails
    {
        private static RealProvider myRealProvider = new RealProvider();
        public Company() { }
        public Company(int id, string name, string details, MyDateTime addedDate, double blance)
            : base(id, name, details, addedDate,blance)
        {
 
        }



        /// Real Business Logic layer begin Here!
        public static List<Company> GetAllCompany()
        {
            return GetCompanyFromCompanyDetails(myRealProvider.GetAllCompanys());
        }

        public static Company GetCompanyByName(string ido)
        {
            CompanyDetails tbdt = myRealProvider.GetCompanyByName(ido);
            if (tbdt != null) return new Company(tbdt.ID, tbdt.Name, tbdt.Details, tbdt.AddedDate,tbdt.Balance); else return null;
        }
        public static Company GetCompanyByID(int ido)
        {
            CompanyDetails tbdt = myRealProvider.GetCompanyByID(ido);
            if (tbdt != null) return new Company(tbdt.ID, tbdt.Name, tbdt.Details, tbdt.AddedDate, tbdt.Balance); else return null;
        }

        public Company GetCompanyByID()
        {
            return Company.GetCompanyByID(this.ID);
        }
        public bool DeleteClient()
        {
        bool x= Company.DeleteCompany(this.ID); 
            BllGlobal.UpdateAllCompany();
               return x;
        }
        public static bool DeleteCompany(int ido)
        {
            bool x=  myRealProvider.DeleteCompany(ido);
         
            return x;
        }
        public static int InsertCompany(int id, string name, string details)
        {
            MyDateTime xx = new MyDateTime(DateTime.Now);
            CompanyDetails tb1 = new CompanyDetails(id, name, details,xx,0);
            int x= myRealProvider.InsertCompany(tb1);
            return x;
        }
        public int InsertCompany()
        {
            int x= Company.InsertCompany(ID, Name, Details);
            return x;
        }
        public bool UpdateCompany()
        { 
            bool x= Company.UpdateCompany (ID, Name, Details,this.Balance);
            return x;
        }
        public static bool UpdateCompany(int id, string name, string details,double blance)
        {
            CompanyDetails tb1 = new CompanyDetails(id, name, details, MyDateTime.Now,blance);
           bool x= myRealProvider.UpdateCompany(tb1);
            return x;
            
        }
        public static bool UpdateCompany(int id, string name, string details)
        {
            CompanyDetails tb1 = new CompanyDetails(id, name, details, MyDateTime.Now);
            bool x = myRealProvider.UpdateCompany(tb1);
            return x;

        }
        public static List<Company> Search(string key)
        {
            return Company.GetCompanyFromCompanyDetails(myRealProvider.SearchCompany(key));

        }

        private static List<Company> GetCompanyFromCompanyDetails(List<CompanyDetails> list)
        {
            List<Company> newlist = new List<Company>();
            foreach (CompanyDetails tbdt in list)
            {
                newlist.Add(new Company(tbdt.ID, tbdt.Name, tbdt.Details, tbdt.AddedDate,tbdt.Balance));
            }
            return newlist;
        }

    }
}
