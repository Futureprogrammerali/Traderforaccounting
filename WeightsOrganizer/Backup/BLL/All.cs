using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeightsOrganizer.DAL;

namespace WeightsOrganizer.BLL
{
  internal   class All : BaseDetails
    {
 
      public All():base()
        {
        }
      string _type = "";
      public string Typeo
      {
          get { return _type; }
          set {
              switch (value)
              {
                  case "WeightsOrganizer.BLL.Types": value = "أصناف"; break;
                  case "WeightsOrganizer.BLL.Company": value = "تجار"; break;
                  case "WeightsOrganizer.BLL.Client": value = "زبائن"; break;
              }
              _type =value; 
          }
      }
      public All(int id, string name, string details,string typeo)
          : base( id,  name,  details,  MyDateTime.Now)
        {
            Typeo = typeo;
        }
      public static List<All> GetAll(string Key)
      {
      List <All >x=new List<All>();
      x.AddRange(GetAll(BLL.Types.Search(Key)));
      x.AddRange(GetAll(BLL.Company.Search(Key)));
      x.AddRange(GetAll(BLL.Client.Search(Key)));
      return x;
      }
      static List<All> GetAll(List<Types> xo)
      {
          List<All> x = new List<All>();
          foreach (BLL.Types tp in xo)
          {
              x.Add(new All(tp.ID, tp.Name, tp.ClientPrice.ToString()+" ل.س ", tp.GetType().ToString()));
          }
          return x;
      }
      static List<All> GetAll(List<Client> xo)
      {
          List<All> x = new List<All>();
          foreach (BLL.Client tp in xo)
          {
              x.Add(new All(tp.ID, tp.Name, tp.Details, tp.GetType().ToString()));
          }
          return x;
      }
      static List<All> GetAll(List<Company> xo)
      {
          List<All> x = new List<All>();
          foreach (BLL.Company tp in xo)
          {
              x.Add(new All(tp.ID, tp.Name, tp.Details, tp.GetType().ToString()));
          }
          return x;
      }

      internal static void DeletAll()
      {
        new  RealProvider().DeletAll();
      }
    }
}
