using System;
using System.Collections.Generic;

using System.Text;

namespace WeightsOrganizer.BLL
{
    internal static class BllGlobal
    {
        ///توفير اتصال على قاعدة البيانات

        internal static List<BLL.Types> alltypes = BLL.Types.GetAllTypes();
        internal static List<BLL.Client> allclients = BLL.Client.GetAllClient();
        internal static List<BLL.Company> allcomps = BLL.Company.GetAllCompany();
        internal static List<BLL.Store> allstory = BLL.Store.GetAllStore();
        internal static List<BLL.Types> RealType()
        {
        return     Types.GetAllRealTypes();
        }

       

        private static List<BLL.Store> Getstores(int id)
        {
            return BLL.Store.Search(id);
        } 
        internal static void UpdateAllType()
        {
            alltypes = BLL.Types.GetAllTypes();
        }
        internal static void UpdateAllClients()
        {
            allclients = BLL.Client.GetAllClient();
        }
        internal static void UpdateAllCompany()
        {
            allcomps = BLL.Company.GetAllCompany();
        }
        internal static void UpdateAllStore()
        {
            allstory = BLL.Store.GetAllStore();
            WeightsOrganizer.Controls.Righto.GetDataAgainTostory();

        }
        internal static void UpdateAll()
        {
            UpdateAllType();
            UpdateAllClients();
            UpdateAllCompany();
            UpdateAllStore();
        }
 
        internal static string GetTypeNameFromListTypesHere(int TypeId)
        {
           
            foreach (Types cur in alltypes)
            {
                if (cur.ID == TypeId)  return cur.Name;
            }
            return "صنف مجهول ";
        }

        internal static string GetclientsNameFromListclientsHere(int manid)
        {
            foreach (Client cur in allclients)
            {
                if (cur.ID == manid) return cur.Name;

            } return "مجهول";
        }
        internal static string GetcompanyNameFromListcompanyssHere(int manid)
        {
            foreach (Company cur in allcomps)
            {
                if (cur.ID == manid) return cur.Name;

            } return "مجهول";
        }
        
    }
}
