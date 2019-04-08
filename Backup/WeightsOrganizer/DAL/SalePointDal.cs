using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace WeightsOrganizer.DAL
{
    /// <summary>
    /// مزود صغير
    /// </summary>
    class SalePointDal:BaseData
    {
        OleDbConnection cn = null;
        public SalePointDal()
        {
            this.ConnectionString = Globals.Globals.ConnectionString;
           // OleDbConnection cn = new OleDbConnection(this.ConnectionString);
        }
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
                , (double)iDataReader["Amount"], (double)iDataReader["Price"], (double)iDataReader["PaidMoney"],
             iDataReader["Details"].ToString(),
             MyDateTime.Parse(iDataReader["AddedDate"].ToString()), (TheUnito)Enum.Parse(typeof(TheUnito), iDataReader["TheUnit"].ToString()), (double)iDataReader["BusinessPrice"], iDataReader["ClientName"].ToString(), iDataReader["TypeName"].ToString());

        }
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
                , iDataReader["TypeName"].ToString());

        }
        public  StoreDetails GetStoreByTypeID(int TypeId)
        {
            using (cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("select * from Store where TypeId=" + TypeId.ToString(), cn);
                try
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                }
                catch {  }
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetStoreFromReader(reader);
                else
                    return null;
            }
        }
        public void InsertClientDeal(List<WeightsOrganizer.BLL.ClientDeal> alcl, bool updateClentccount, double Price)
        {
           using (cn = new OleDbConnection(this.ConnectionString))
            {
            cn.Open();
            foreach (WeightsOrganizer.BLL.ClientDeal cl in alcl)
            {
                InsertClientDeal(cl);
                InsertToStoreFromClient(cl);
            }
            if (updateClentccount) updateClentAcountplease(alcl[0].ClientId, Price);
            cn.Close();
            }
        }
        private void updateClentAcountplease(int clid, double Price)
        {
            OleDbCommand cmd = new OleDbCommand(@"UPDATE Clients  SET"
                + " Balance=(Balance+" + Price.ToString()
               + ") WHERE Id=" + clid.ToString(), cn);
            cmd.CommandType = CommandType.Text;
            try
            {
                ExuteNonQuery(cmd);
            }
            finally { } 
            
        }
        private void InsertToStoreFromClient(WeightsOrganizer.BLL.ClientDeal cl)
        {
            if (cl.TheUnit == TheUnito.Gram) cl.Amount = cl.Amount / 1000;
            StoreDetails StoreDetails = new StoreDetails(0, cl.TypeId,cl.Amount,DateTime.Now,DateTime.Now, cl.TypeName);
            InsertStoreFromClient(StoreDetails);
        }
        private   void InsertStoreFromClient(StoreDetails StoreDetails)
        {

                    OleDbCommand cmd = new OleDbCommand(@"UPDATE Store  SET  "   
                + "Amount=(Amount-" + (StoreDetails.Amount).ToString()
               + "),AddedDateClient='" + StoreDetails.AddedDateClient
               + "' WHERE TypeId=" + StoreDetails.TypeId.ToString(), cn);
                    cmd.CommandType = CommandType.Text;
                     try
                    {
               ExuteNonQuery(cmd);
                    }
                    finally { }       
           
        }
        public void InsertClientDeal(WeightsOrganizer.BLL.ClientDeal cl)
        {
            InsertClientDeal(new ClientDealDetails (0,cl.TypeId,cl.ClientId,cl.Amount,cl.Price,cl.ToTalPrice,cl.Details,cl.AddedDate,cl.TheUnit,cl.BusinessPrice,cl.ClientName,cl.TypeName));
        }
        private    void  InsertClientDeal(ClientDealDetails ClientDealDetails)
        {
                byte x = 1;
                switch (ClientDealDetails.TheUnit)
                {
                    case TheUnito.Gram: x = 0; break;
                    case TheUnito.Kilo: x = 1; break;
                    case TheUnito.Piece: x = 2; break;
                }
                OleDbCommand cmd = new OleDbCommand(string.Format(@"INSERT INTO  ClientDeals
(ClientId,TypeId,Amount,Price,PaidMoney,Details,AddedDate,TheUnit,BusinessPrice,ClientName,TypeName)VALUES
( {0},{1},{2},{3},{4},'{5}','{6}',{7},{8},'{9}','{10}')"
, ClientDealDetails.ClientId.ToString(),
ClientDealDetails.TypeId.ToString(),
ClientDealDetails.Amount.ToString(),
ClientDealDetails.Price.ToString(),
ClientDealDetails.PaidMoney.ToString(),
ClientDealDetails.Details.ToString(),
ClientDealDetails.AddedDate.ToStringToinsert(), x, ClientDealDetails.BusinessPrice.ToString(),
ClientDealDetails.ClientName, ClientDealDetails.TypeName), cn);
                cmd.CommandType = CommandType.Text;
                ExuteNonQuery(cmd);
           
        }
    }
}
