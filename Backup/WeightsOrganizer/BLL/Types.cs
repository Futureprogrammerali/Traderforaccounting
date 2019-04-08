using System;
using System.Collections.Generic;

using System.Text;
using WeightsOrganizer.DAL;

namespace WeightsOrganizer.BLL
{
    [Serializable]
   public  class Types:DAL.TypeDetails
    {
      private static RealProvider myRealProvider = new RealProvider();

      public static int LastIdInTypes()
      {
        return   myRealProvider.LastIdInTypes();
      }
      public string AllCompanyname
      {
          get
          {
              string geto = ""; try
              {

                  string[] all = AllCompanyId.Split(',');
                  foreach (string s in all)
                  {
                      geto += BLL.BllGlobal.GetcompanyNameFromListcompanyssHere(int.Parse(s)) + ",";
                  } if (geto.Length < 3) geto = " عرض ";
              }
              catch { if (geto.Length < 3) geto = " عرض "; }
              return geto;
          }
      } 

      protected string _ArabicUnit = null;
      public string ArabicUnit
      {
          set { _ArabicUnit = value; }
          get
          {
              switch (this.TheUnit)
              {
                  case TheUnito.Gram: _ArabicUnit = "وزن"; break;
                  case TheUnito.Kilo: _ArabicUnit = "وزن"; break;
                  case TheUnito.Piece: _ArabicUnit = "قطعة"; break;
              }
              return _ArabicUnit;
          }
      }
 
      public Types():base()
        {
         
        }
      public Types(int id, string name, double businessprice, double clientprice, double businessclientPrice, MyDateTime addedDate, string allCompanyId, TheUnito theUnit,string baracode)
          : base(id, name, businessprice, clientprice, businessclientPrice, addedDate,allCompanyId,theUnit,baracode)
        {
           
        }
      public Types(int id, string name, double businessprice, double clientprice, double businessclientPrice, MyDateTime addedDate, TheUnito theUnit,string baracode)
          : base(id, name, businessprice, clientprice, businessclientPrice, addedDate,"",theUnit,baracode)
      {

      }
     /// Real Business Logic layer begin Here!
      public static List<Types> GetAllTypes()
          {  
          return GetTypesFromTypesDetails(myRealProvider.GetAllTypes());
          }
      public static List<Types> GetAllRealTypes()
      {
          return GetTypesFromTypesDetails(myRealProvider.GetAllRealTypes());
      }
      public static List<Types> GetAllTypesNotavailable()
      {
          return GetTypesFromTypesDetails(myRealProvider.GetAllTypesNotavailable());
      }

      private static List<Types> GetTypesFromTypesDetails(List<TypeDetails> list)
          {
          List<Types> newlist = new List<Types>();  
          
          foreach (TypeDetails tbdt in list)
              {
                  newlist.Add(new Types(tbdt.ID, tbdt.Name, tbdt.BusinessPrice, tbdt.ClientPrice, tbdt.BusinessClientPrice, tbdt.AddedDate, tbdt.AllCompanyId, tbdt.TheUnit,tbdt.BaraCode));
              }
              return newlist;
          }
      public static List<Types> GetTypeByBaraCode(string bara,bool instore)
      {
          return GetTypesFromTypesDetails(myRealProvider.GetTypeBybaracode(bara,instore));
      }
      public static Types GetTypeByName(string ido)
      {
          TypeDetails tbdt = myRealProvider.GetTypeByName(ido);
          if (tbdt != null) return new Types(tbdt.ID, tbdt.Name, tbdt.BusinessPrice, tbdt.ClientPrice, tbdt.BusinessClientPrice, tbdt.AddedDate, tbdt.TheUnit, tbdt.BaraCode); else return null;
      }
      public static Types GetTypeByID(int ido)
          {
              TypeDetails tbdt = myRealProvider.GetTypeByID(ido);
              if (tbdt != null) return new Types(tbdt.ID, tbdt.Name, tbdt.BusinessPrice, tbdt.ClientPrice, tbdt.BusinessClientPrice, tbdt.AddedDate, tbdt.AllCompanyId, tbdt.TheUnit, tbdt.BaraCode); else return null;
          }
        
      public Types GetTypesByID()
        {
            return Types.GetTypeByID(this.ID);
        }
      public bool DeleteType()
        {
            bool x = Types.DeleteType(this.ID);
                BllGlobal.UpdateAllType();
                return x;                
        }
      public static bool DeleteType(int ido)
        {
          bool x=myRealProvider.DeleteType(ido);
          BllGlobal.UpdateAllType();
          return x;
        }
      public static int InsertType(int id, string name, double businessprice, double clientprice, double businessclientprice, TheUnito theUnit,string baracode)
        {
         MyDateTime xx=  new MyDateTime(DateTime.Now);

         TypeDetails tb1 = new TypeDetails(id, name, businessprice, clientprice, businessclientprice, xx, "", theUnit, baracode);

          int x=myRealProvider.InsertType(tb1);
          return x;
        }
      public int InsertType()
        {
            int x = Types.InsertType(ID, Name, BusinessPrice, ClientPrice, BusinessClientPrice, this.TheUnit, BaraCode);
            return x;
        }
      public bool UpdateType()
        {
          bool x = Types.UpdateType(ID, Name, BusinessPrice, ClientPrice, BusinessClientPrice,AllCompanyId,this.TheUnit,BaraCode);
          BllGlobal.UpdateAllType();
          return x;
         
        }
      public static bool UpdateType(int id, string name, double businessprice, double clientprice, double businessclientprice, string allCompanyId, TheUnito theUnit,string baracode)
        {
            TypeDetails tb1 = new TypeDetails(id, name, businessprice, clientprice, businessclientprice, MyDateTime.Now, allCompanyId, theUnit, baracode);
          bool x= myRealProvider.UpdateTypebyallcomp(tb1);
          return x;
        }
      public static bool UpdateType(int id, string name, double businessprice, double clientprice, double businessclientprice,TheUnito theUnit,string baracode)
      {
          TypeDetails tb1 = new TypeDetails(id, name, businessprice, clientprice, businessclientprice, MyDateTime.Now, "", theUnit,baracode);
          bool x = myRealProvider.UpdateType(tb1);
          BllGlobal.UpdateAllType();
          return x;
      }
      public static List<Types> Search(string keyorbara)
         {
             return Types.GetTypeFromTypeDetails(myRealProvider.SearchTypes(keyorbara));
         }

      private static List<Types> GetTypeFromTypeDetails(List<TypeDetails> list)
      {
          List<Types> newlist = new List<Types>();
          foreach (TypeDetails tbdt in list)
          {
              newlist.Add(new Types(tbdt.ID, tbdt.Name, tbdt.BusinessPrice, tbdt.ClientPrice, tbdt.BusinessClientPrice, tbdt.AddedDate, tbdt.AllCompanyId, tbdt.TheUnit, tbdt.BaraCode));
          }
          return newlist;
      }

      
    }
}
