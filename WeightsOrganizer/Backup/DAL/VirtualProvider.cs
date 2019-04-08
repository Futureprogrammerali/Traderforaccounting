using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace WeightsOrganizer.DAL
{
    /// <summary>
    /// توفير الأجرائيات التي تحقق قاعدة البيانات  والتي تستدى من الطبقة العملية
    /// </summary>
     abstract  class VirtualProvider:BaseData
    {
         public VirtualProvider()
         {
             this.ConnectionString = Globals.Globals.ConnectionString;
         }
         // Types
         public abstract List<TypeDetails> GetAllTypes();
         public abstract List<TypeDetails> GetAllRealTypes();
         public abstract List<TypeDetails> GetAllTypesNotavailable();
         public abstract List<TypeDetails> SearchTypes(string key);
         public abstract TypeDetails GetTypeByID(int ID);
         public abstract TypeDetails GetTypeByName(string name);
         public abstract List<TypeDetails> GetTypeBybaracode(string bara,bool instore);
         public abstract bool DeleteType(int Id);
         public abstract int LastIdInTypes();
         public abstract bool DeleteArchives(int Id);
         public abstract bool UpdateType(TypeDetails TypeDetails);
         public abstract bool UpdateTypebyallcomp(TypeDetails TypeDetails);  
         public abstract int InsertType(TypeDetails TypeDetails);
         public abstract int InsertArchives(ArchivesDetails TypeDetails);
         protected List<TypeDetails> GetTypesCollectionFromReader(IDataReader iDataReader)
         {
             List<TypeDetails> Tbs = new List<TypeDetails>();
             while (iDataReader.Read())
                 Tbs.Add(GetTypeFromReader(iDataReader));
             return Tbs;
         }
         protected TypeDetails GetTypeFromReader(IDataReader iDataReader)
         {
             return new TypeDetails(
                 (int)iDataReader["Id"],
                 iDataReader["TypeName"].ToString(),
               (double)iDataReader["BusinessPrice"],
                 (double)iDataReader["ClientPrice"], (double)iDataReader["BusinessClientPrice"],
               MyDateTime.Parse(iDataReader["AddedDate"].ToString()), iDataReader["AllCompanyId"].ToString(), (TheUnito)Enum.Parse(typeof(TheUnito), iDataReader["TheUnit"].ToString()),iDataReader["BaraCode"].ToString());


         }

         protected List<ArchivesDetails> GetArchivesCollectionFromReader(IDataReader iDataReader)
         {
             List<ArchivesDetails> Tbs = new List<ArchivesDetails>();
             try
             {
                 while (iDataReader.Read())
                     Tbs.Add(GetArchivesFromReader(iDataReader));
             }
             catch   {// System.Windows.Forms.MessageBox.Show(xxx.StackTrace+" "+xxx.Source+""+xxx.TargetSite.ToString());
             }
             return Tbs;
         }

         protected ArchivesDetails GetArchivesFromReader(IDataReader iDataReader)
         {
             return new ArchivesDetails((int)iDataReader["Id"], (byte)iDataReader["BigType"], (byte)iDataReader["SmallType"]
           , (double)iDataReader["Amount"], (double)iDataReader["Price"], (double)iDataReader["PaidMoney"], (double)iDataReader["StayingPrice"]
           , (double)iDataReader["Profit"], MyDateTime.Parse(iDataReader["AddedDate1"].ToString())
           , MyDateTime.Parse(iDataReader["AddedDate2"].ToString()), MyDateTime.Parse(iDataReader["AddedDate"].ToString()), iDataReader["Details"].ToString());
         }   
         // Client..
         public abstract List<ClientDetails> GetAllClients();
         public abstract List<ClientDetails> SearchClient(string key);
         public abstract ClientDetails GetClientByID(int ID);
         public abstract ClientDetails GetClientByName(string ido);
         public abstract bool DeleteClient(int Id);
         public abstract bool UpdateClient(ClientDetails ClientDetails);
         public abstract int InsertClient(ClientDetails ClientDetails);
         protected List<ClientDetails> GetClientsCollectionFromReader(IDataReader iDataReader)
         {
             List<ClientDetails> Tbs = new List<ClientDetails>();
             while (iDataReader.Read())
                 Tbs.Add(GetClientFromReader(iDataReader));
             return Tbs;
         }
         protected ClientDetails GetClientFromReader(IDataReader iDataReader)
         {

             return new ClientDetails(
                 (int)iDataReader["Id"],
                 iDataReader["ClientName"].ToString(),
              iDataReader["Details"].ToString(),
              MyDateTime.Parse(iDataReader["AddedDate"].ToString()), (double)iDataReader["Balance"]
 );

         }




         // Companys..
         public abstract List<CompanyDetails> GetAllCompanys();
         public abstract List<CompanyDetails> SearchCompany(string key);
         public abstract CompanyDetails GetCompanyByID(int ID);
         public abstract CompanyDetails GetCompanyByName(string ID);
         public abstract bool DeleteCompany(int Id);
         public abstract bool UpdateCompany(CompanyDetails CompanyDetails);
         public abstract int InsertCompany(CompanyDetails CompanyDetails);
         protected List<CompanyDetails> GetCompanysCollectionFromReader(IDataReader iDataReader)
         {
             List<CompanyDetails> Tbs = new List<CompanyDetails>();
             while (iDataReader.Read())
                 Tbs.Add(GetCompanyFromReader(iDataReader));
             return Tbs;
         }
         protected CompanyDetails GetCompanyFromReader(IDataReader iDataReader)
         {

             return new CompanyDetails(
                 (int)iDataReader["Id"],
                 iDataReader["CompanyName"].ToString(),
              iDataReader["Details"].ToString(),
               MyDateTime.Parse(iDataReader["AddedDate"].ToString()), (double)iDataReader["Balance"])
               ;
         }
         public abstract List<ClientDealDetails> GetAllSalesReturns();
         public abstract ClientDealDetails GetSalesReturnsByID(int ID);
         public abstract bool DeleteSalesReturns(int Id);
         public abstract bool UpdateSalesReturns(ClientDealDetails ClientDealDetails);
         public abstract List<ClientDealDetails> SearchSalesReturns(string key);
         // ClientDealDetails..
         public abstract List<ClientDealDetails> GetAllClientDeals();
         public abstract List<ClientDealDetails> SearchClientDeal(string key);
         public abstract ClientDealDetails GetClientDealByID(int ID);
         public abstract bool DeleteClientDeal(int Id);
         public abstract bool UpdateClientDealy(ClientDealDetails ClientDealDetails);
         public abstract int InsertClientDeal(ClientDealDetails ClientDealDetails);
         public abstract int InsertClientDeal(ClientDealDetails ClientDealDetails, bool opencon);
         public abstract int InsertSalesReturns(ClientDealDetails ClientDealDetails);

         protected List<ClientDealDetails> GetClientDealsCollectionFromReader(IDataReader iDataReader)
         {
             List<ClientDealDetails> Tbs = new List<ClientDealDetails>();
             while (iDataReader.Read())
                 Tbs.Add(GetClientDealFromReader(iDataReader));
             return Tbs;
         }
         protected ClientDealDetails GetClientDealFromReader(IDataReader iDataReader)
         {

             return new ClientDealDetails(
                 (int)iDataReader["Id"], (int)iDataReader["TypeId"], (int)iDataReader["ClientId"]
                 , (double)iDataReader["Amount"], (double)iDataReader["Price"],(double)iDataReader["PaidMoney"],
              iDataReader["Details"].ToString(),
              MyDateTime.Parse(iDataReader["AddedDate"].ToString()), (TheUnito)Enum.Parse(typeof(TheUnito), iDataReader["TheUnit"].ToString()), (double)iDataReader["BusinessPrice"], iDataReader["ClientName"].ToString(), iDataReader["TypeName"].ToString());

         }



         // BusinesDealDetails..
         public abstract List<BusinesDealDetails> GetAllBusinesDeals();
         public abstract List<BusinesDealDetails> GetAllBusinesReturns();
         public abstract List<BusinesDealDetails> SearchBusinesDeal(string key);
         public abstract List<BusinesDealDetails> SearchBusinesReturns(string key);
         public abstract List<BusinesDealDetails> SearchBusinesDeal(int typeid);
         public abstract List<BusinesDealDetails> SearchBusinesReturns(int typeid);
         public abstract BusinesDealDetails GetBusinesDealByID(int ID);
         public abstract BusinesDealDetails GetBusinesReturnsByID(int ID);
         public abstract bool DeleteBusinesDeal(int Id);
         public abstract bool DeleteBusinesReturns(int Id);
         public abstract bool UpdateBusinesDealy(BusinesDealDetails BusinesDealDetails);
         public abstract bool UpdateBusinesReturnsy(BusinesDealDetails BusinesDealDetails);
         public abstract int InsertBusinesDeal(BusinesDealDetails BusinesDealDetails);
      
         public abstract int InsertBusinesReturns(BusinesDealDetails BusinesDealDetails);
         protected List<BusinesDealDetails> GetBusinesDealsCollectionFromReader(IDataReader iDataReader)
         {
             List<BusinesDealDetails> Tbs = new List<BusinesDealDetails>();
             while (iDataReader.Read())
                 Tbs.Add(GetBusinesDealFromReader(iDataReader));
             return Tbs;
         }
         protected BusinesDealDetails GetBusinesDealFromReader(IDataReader iDataReader)
         {

             return new BusinesDealDetails(
                 (int)iDataReader["Id"], (int)iDataReader["TypeId"], (int)iDataReader["ManId"]
                 , (double)iDataReader["Amount"], (double)iDataReader["BusinessPrice"],
                (double)iDataReader["ClientPrice"], (double)iDataReader["PaidMoney"],
              iDataReader["Details"].ToString(),
          MyDateTime.Parse(iDataReader["AddedDate"].ToString()), iDataReader["ManName"].ToString(), iDataReader["TypeName"].ToString());

         }
         

         // LastCompanytAccountDetails

         public abstract List<LastCompanyAccountDetails> GetAllLastCompanytAccount(int ID);
         public abstract int InserLastCompanytAccount(LastCompanyAccountDetails CompanytAccount);
         public abstract bool DeleteLastCompanytAccount(int Id);
         protected List<LastCompanyAccountDetails> GetLastCompanytAccountCollectionFromReader(IDataReader iDataReader)
         {
             List<LastCompanyAccountDetails> Tbs = new List<LastCompanyAccountDetails>();
             while (iDataReader.Read())
                 Tbs.Add(GetLastCompanytAccountFromReader(iDataReader));
             return Tbs;
         }
         protected LastCompanyAccountDetails GetLastCompanytAccountFromReader(IDataReader iDataReader)
         {

             return new LastCompanyAccountDetails(
                 (int)iDataReader["Id"],
                 (int)iDataReader["ManId"],
           (double)iDataReader["Can"],
                 (double)iDataReader["Numbero"],
                 (double)iDataReader["Sar"],
                 MyDateTime.Parse(iDataReader["AddedDate"].ToString()));


         }

         // LastClientsAccountDetails

         public abstract List<LastClientsAccountDetails> GetAllLastClienttAccount(int ID);
         public abstract int InserLastClienttAccount(LastClientsAccountDetails ClienttAccount);
         public abstract bool DeleteLastClientAccount(int Id);
         protected List<LastClientsAccountDetails> GetLastClientAccountCollectionFromReader(IDataReader iDataReader)
         {
             List<LastClientsAccountDetails> Tbs = new List<LastClientsAccountDetails>();
             while (iDataReader.Read())
                 Tbs.Add(GetLastClientAccountFromReader(iDataReader));
             return Tbs;
         }
         protected LastClientsAccountDetails GetLastClientAccountFromReader(IDataReader iDataReader)
         {

             return new LastClientsAccountDetails(
                 (int)iDataReader["Id"],
                 (int)iDataReader["ClientId"],
           (double)iDataReader["Can"],
                 (double)iDataReader["Numbero"],
                 (double)iDataReader["Sar"],
                 MyDateTime.Parse(iDataReader["AddedDate"].ToString()));


         }


         // StoreDetails..
         public abstract List<StoreDetails> GetAllStores();
         public abstract List<StoreDetails> SearchStore(string key);
         public abstract List<StoreDetails> SearchStore(int typeid);
         public abstract StoreDetails GetStoreByID(int ID);
         public abstract StoreDetails GetStoreByTypeID(int ID);
         public abstract bool DeleteStore(int Id);
         public abstract int InsertStoreFromCompany(StoreDetails StoreDetails);
         public abstract int InsertStoreFromCompany(StoreDetails StoreDetails, bool decremnt);
         public abstract int InsertStoreFromClient(StoreDetails StoreDetails);

         public abstract void UpdateTypNamesinstore(int typied, string newname);
         public abstract int InsertStoreFromClient(StoreDetails StoreDetails, bool addthstore);
         public abstract int InsertStoreFromClient(StoreDetails StoreDetails, bool addthstore, bool opencon);
         protected List<StoreDetails> GetStoresCollectionFromReader(IDataReader iDataReader)
         {
             List<StoreDetails> Tbs = new List<StoreDetails>();
             while (iDataReader.Read())
                 Tbs.Add(GetStoreFromReader(iDataReader));
             return Tbs;
         }
         protected StoreDetails GetStoreFromReader(IDataReader iDataReader)
         {
             return new StoreDetails(
                 (int)iDataReader["Id"], (int)iDataReader["TypeId"] 
                 , (double)iDataReader["Amount"]
                 , DateTime.Parse(iDataReader["AddedDateClient"].ToString())
                 , DateTime.Parse(iDataReader["AddedDateCompany"].ToString())
                 ,iDataReader["TypeName"].ToString());

         }
     }
}
