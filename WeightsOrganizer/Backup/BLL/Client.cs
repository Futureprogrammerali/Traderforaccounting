using System;
using System.Collections.Generic;

using System.Text;
using WeightsOrganizer.DAL;
namespace WeightsOrganizer.BLL
{
    [Serializable]
    class Client : DAL.ClientDetails
    {

        private static RealProvider myRealProvider = new RealProvider();
        public Client()
        {
        }
        public Client(int id, string name, string details, MyDateTime addedDate, double balance)
            : base(id, name, details, addedDate,balance)
        {

        }

        /// Real Business Logic layer begin Here!
        public static List<Client> GetAllClient()
        {
            return GetClientFromClientDetails(myRealProvider.GetAllClients());
        }
        public static Client GetClientByID(int ido)
        {
            ClientDetails tbdt = myRealProvider.GetClientByID(ido);
            if (tbdt != null) return new Client(tbdt.ID, tbdt.Name, tbdt.Details, tbdt.AddedDate,tbdt.Balance); else return null;
        }
        public Client GetClientByID()
        {
            return Client.GetClientByID(this.ID);
        }
        public static Client GetClientByName(string ido)
        {
            ClientDetails tbdt = myRealProvider.GetClientByName(ido);
if (tbdt != null) return new Client(tbdt.ID, tbdt.Name, tbdt.Details, tbdt.AddedDate,tbdt.Balance); else return null;
        }        
        public bool DeleteClient()
        {
            bool x = Client.DeleteClient(this.ID); ;
            BllGlobal.UpdateAllClients();
            return x;
        }
        public static bool DeleteClient(int ido)
        {
            bool x= myRealProvider.DeleteClient(ido);
            BllGlobal.UpdateAllClients();
            return x;
        }
        public static int InsertClient(int id, string name, string details )
        {
            ClientDetails tb1 = new ClientDetails(id, name, details, MyDateTime.Now,0);
            int x = myRealProvider.InsertClient(tb1);
           return x;
        }
        public int InsertClient()
        {
            int x = Client.InsertClient(ID, Name, Details);

            return x;
        }
        public bool UpdateClient()
        {
            bool  x = Client.UpdateClient(ID, Name, Details,this.Balance); 
            return x;

        }
        public static bool UpdateClient(int id, string name, string details, double blance)
        {
            ClientDetails tb1 = new ClientDetails(id, name, details, MyDateTime.Now, blance);
            bool x = myRealProvider.UpdateClient(tb1);
            return x;
        }
        public static bool UpdateClient(int id, string name, string details)
        {
            ClientDetails tb1 = new ClientDetails(id, name, details, MyDateTime.Now);
            bool x = myRealProvider.UpdateClient(tb1);
            BllGlobal.UpdateAllClients();
            return x;
        }
        public static List<Client> Search(string key)
        {
            return Client.GetClientFromClientDetails(myRealProvider.SearchClient(key));
    
        }
        private static List<Client> GetClientFromClientDetails(List<ClientDetails> list)
        {
            List<Client> newlist = new List<Client>();
            foreach (ClientDetails tbdt in list)
            {
                 newlist.Add(new Client(tbdt.ID, tbdt.Name, tbdt.Details, tbdt.AddedDate,tbdt.Balance));
            }
            return newlist;
        }

         
    }
}
