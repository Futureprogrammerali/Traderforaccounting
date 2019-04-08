using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using WeightsOrganizer.BLL;

namespace WeightsOrganizer.DAL
{
    class RealProvider : VirtualProvider
    {

        public override List<TypeDetails> GetAllTypesNotavailable()
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("SELECT Types.*, Store.Id AS Store_Id FROM Types INNER JOIN Store ON Types.[Id] = Store.[TypeId]", cn);
                try
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                }
                catch {  }
                return GetTypesCollectionFromReader(ExecuteReader(cmd));
            }
        }
        public override List<TypeDetails> GetAllRealTypes()
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("SELECT Types.*, Store.Id AS Store_Id FROM Types INNER JOIN Store ON Types.[Id] = Store.[TypeId] where Store.[Amount]>0", cn);
                try
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                }
                catch {  }
                return GetTypesCollectionFromReader(ExecuteReader(cmd));
            }
        }
        public override List<TypeDetails> GetAllTypes()
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("select * from Types order by TypeName", cn);
                try
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                }
                catch  {   }
                return GetTypesCollectionFromReader(ExecuteReader(cmd));
            }
        }
        public override List<TypeDetails> SearchTypes(string keyorbara)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(
     string.Format("select * from Types where TypeName like '%{0}%' or BusinessPrice like '%{0}%' or ClientPrice like '%{0}%' or BaraCode like '%{0}%' order by TypeName", keyorbara), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetTypesCollectionFromReader(ExecuteReader(cmd));
            }
        }
        public override TypeDetails GetTypeByID(int ID)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("select * from Types where Id=" + ID.ToString(), cn);
                try
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                }
                catch (Exception) { System.Windows.Forms.MessageBox.Show("يوجد خطأ(جلب البيانات)"); }
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetTypeFromReader(reader);
                else
                    return null;
            }
        }
        public override TypeDetails GetTypeByName(string name)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("select * from Types where TypeName='" + name.ToString()+"'", cn);
                try
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                }
                catch (Exception) { System.Windows.Forms.MessageBox.Show("يوجد خطأ(جلب البيانات)"); }
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetTypeFromReader(reader);
                else
                    return null;
            }
        }
        public override List<TypeDetails> GetTypeBybaracode(string bara,bool instore)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd=null;
                if(instore)
                 cmd = new OleDbCommand("SELECT Types.*, Store.Id AS Store_Id FROM Types INNER JOIN Store ON Types.[Id] = Store.[TypeId] where BaraCode='" + bara.ToString() + "'", cn);
                else 
                cmd = new OleDbCommand("SELECT *  FROM Types where BaraCode='" + bara.ToString() + "'", cn); 
                try
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                }
                catch (Exception) { System.Windows.Forms.MessageBox.Show("يوجد خطأ(جلب البيانات)"); }
                return GetTypesCollectionFromReader(ExecuteReader(cmd));
            }     
        }
        public override bool DeleteType(int Id)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("delete from Types where Id =" + Id.ToString(), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                int ret = ExuteNonQuery(cmd);
                return (ret == 1);
            }
        }
        public override int LastIdInTypes()
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("select max(Id) from Types", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return (int) ExecuteScalar(cmd);   
            }
        }
        public override bool UpdateType(TypeDetails TypeDetails)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                byte x = 1;
                switch (TypeDetails.TheUnit)
                {
                    case TheUnito.Gram: x = 0; break;
                    case TheUnito.Kilo: x = 1; break;
                    case TheUnito.Piece: x = 2; break;
                }

                OleDbCommand cmd = new OleDbCommand(@"UPDATE Types  SET BusinessPrice ="
                + TypeDetails.BusinessPrice.ToString()
                + ",ClientPrice=" + TypeDetails.ClientPrice.ToString()
                 + ",BusinessClientPrice=" + TypeDetails.BusinessClientPrice.ToString()
                + ",TypeName='" + TypeDetails.Name.ToString()
                 + "',TheUnit=" + x.ToString() +",BaraCode='"+TypeDetails.BaraCode+"'"
                + " WHERE Id=" + TypeDetails.ID.ToString(), cn);
                cmd.CommandType = CommandType.Text;
                int ret = 0;
                cn.Open(); try
                {
                    ret = ExuteNonQuery(cmd);
                }
                finally { }
                return (ret == 1);
            }
        }
        public override bool UpdateTypebyallcomp(TypeDetails TypeDetails)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(@"UPDATE Types  SET"
                + " AllCompanyId='" + TypeDetails.AllCompanyId.ToString()
                + "' WHERE Id=" + TypeDetails.ID.ToString(), cn);
              //  System.Windows.Forms.MessageBox.Show("dd "+cmd.CommandText);
                cmd.CommandType = CommandType.Text;
                int ret = 0;
                cn.Open(); try
                {
                    ret = ExuteNonQuery(cmd);
                }
                finally { }
                return (ret == 1);
            }
        }
        public override int InsertType(TypeDetails TypeDetails)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                byte x = 1;
                switch (TypeDetails.TheUnit)
                {
                    case TheUnito.Gram: x = 0; break;
                    case TheUnito.Kilo: x = 1; break;
                    case TheUnito.Piece: x = 2; break;
                }
                OleDbCommand cmd = new OleDbCommand(string.Format(@"INSERT INTO Types
(TypeName,ClientPrice ,BusinessPrice,BusinessClientPrice,AddedDate,TheUnit,BaraCode)VALUES
('{0}',{1},{2},{3},'{4}',{5},'{6}')"
, TypeDetails.Name.ToString(), TypeDetails.ClientPrice.ToString(),
TypeDetails.BusinessPrice.ToString(),
TypeDetails.BusinessClientPrice.ToString(), TypeDetails.AddedDate.ToStringToinsert(),x,TypeDetails.BaraCode), cn);
                cmd.CommandType = CommandType.Text;
 
                cn.Open();
                int ret = ExuteNonQuery(cmd);
                return ret;
            }
        }
        ///Archives  Archives
        public override int InsertArchives(ArchivesDetails TypeDetails)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(string.Format(@"INSERT INTO Archives
(BigType,SmallType,Amount,Price,PaidMoney,StayingPrice,Profit,Addeddate1,Addeddate2,Addeddate,Details)VALUES
({0},{1},{2},{3},{4},{5},{6},'{7}','{8}','{9}','{10}')"
, TypeDetails.BigType.ToString(), TypeDetails.SmallType.ToString(),
TypeDetails.Amount.ToString(), TypeDetails.Price.ToString(),
TypeDetails.PaidMoney.ToString(),
TypeDetails.StayingPrice.ToString(),
TypeDetails.Profit.ToString(),
TypeDetails.AddedDate1.ToStringToinsert(),
TypeDetails.AddedDate2.ToStringToinsert(),
TypeDetails.AddedDate.ToStringToinsert(),
 TypeDetails.Details), cn);
                cmd.CommandType = CommandType.Text;

                cn.Open();
                int ret = ExuteNonQuery(cmd);
                return ret;
            }
        }
        public override bool DeleteArchives(int Id)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("delete from Archives where Id =" + Id.ToString(), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                int ret = ExuteNonQuery(cmd);
                return (ret == 1);
            }
        }
        public override List<ClientDetails> GetAllClients()
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("select * from Clients order by ClientName", cn);
                try
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                }
                catch (Exception) { System.Windows.Forms.MessageBox.Show("يوجد خطأ(جلب البيانات)"); }
                return GetClientsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        public override List<ClientDetails> SearchClient(string key)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(
     string.Format("select * from  Clients where  ClientName like '%{0}%' or Details like '%{0}%'", key), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetClientsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        public override ClientDetails GetClientByName(string ido)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("select * from Clients where ClientName='" + ido.ToString()+"'", cn);
                try
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                }
                catch (Exception) { System.Windows.Forms.MessageBox.Show("يوجد خطأ(جلب البيانات)"); }
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetClientFromReader(reader);
                else
                    return null;
            }
        }
        public override ClientDetails GetClientByID(int ID)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("select * from Clients where Id=" + ID.ToString(), cn);
                try
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                }
                catch (Exception) { System.Windows.Forms.MessageBox.Show("يوجد خطأ(جلب البيانات)"); }
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetClientFromReader(reader);
                else
                    return null;
            }
        }
        public override bool DeleteClient(int Id)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("delete from Clients where Id =" + Id.ToString(), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                int ret = ExuteNonQuery(cmd);
                return (ret == 1);
            }
        }
        public override bool UpdateClient(ClientDetails ClientDetails)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(@"UPDATE Clients  SET ClientName ='"
                + ClientDetails.Name.ToString()

                + "',Details='" + ClientDetails.Details.ToString()
                 + "',Balance=" + ClientDetails.Balance.ToString()
                + " WHERE Id=" + ClientDetails.ID.ToString(), cn);
                cmd.CommandType = CommandType.Text;
                int ret = 0;
                cn.Open(); try
                {
                    ret = ExuteNonQuery(cmd);
                }
                finally { }
                return (ret == 1);
            }
        }
        public override int InsertClient(ClientDetails ClientDetails)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(string.Format(@"INSERT INTO Clients
(ClientName,Details,AddedDate)VALUES
('{0}','{1}', '{2}' )"
, ClientDetails.Name.ToString(), ClientDetails.Details.ToString(), ClientDetails.AddedDate.ToStringToinsert()), cn);
                cmd.CommandType = CommandType.Text;

                cn.Open();
                int ret = ExuteNonQuery(cmd);
                return ret;
            }
        }
        public override List<CompanyDetails> GetAllCompanys()
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("select * from Companys order by CompanyName ", cn);
                try
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                }
                catch (Exception) { System.Windows.Forms.MessageBox.Show("يوجد خطأ(جلب البيانات)"); }
                return GetCompanysCollectionFromReader(ExecuteReader(cmd));
            }
        }
        public override List<CompanyDetails> SearchCompany(string key)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(
     string.Format("select * from  Companys where  CompanyName like '%{0}%' or Details like '%{0}%' order by CompanyName", key), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetCompanysCollectionFromReader(ExecuteReader(cmd));
            }

        }
        public override CompanyDetails GetCompanyByName(string ID)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("select * from Companys where CompanyName='" + ID.ToString() + "'", cn);
                try
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                }
                catch (Exception) { System.Windows.Forms.MessageBox.Show("يوجد خطأ(جلب البيانات)"); }
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetCompanyFromReader(reader);
                else
                    return null;
            }
        }
        public override CompanyDetails GetCompanyByID(int ID)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("select * from Companys where Id=" + ID.ToString(), cn);
                try
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                }
                catch (Exception) { System.Windows.Forms.MessageBox.Show("يوجد خطأ(جلب البيانات)"); }
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetCompanyFromReader(reader);
                else
                    return null;
            }
        }
        public override bool DeleteCompany(int Id)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("delete from Companys where Id =" + Id.ToString(), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                int ret = ExuteNonQuery(cmd);
                return (ret == 1);
            }
        }
        public override bool UpdateCompany(CompanyDetails CompanyDetails)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
       
                OleDbCommand cmd = new OleDbCommand(@"UPDATE Companys  SET CompanyName ='"
                + CompanyDetails.Name.ToString()
                    + "',Balance=" + CompanyDetails.Balance.ToString()
                + ",Details='" + CompanyDetails.Details.ToString()
                + "' WHERE Id=" + CompanyDetails.ID.ToString(), cn);
         
                cmd.CommandType = CommandType.Text;
                int ret = 0;
                cn.Open(); try
                {
                    ret = ExuteNonQuery(cmd);
                }
                finally { }
                return (ret == 1);
            }
        }
        public override int InsertCompany(CompanyDetails CompanyDetails)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(string.Format(@"INSERT INTO Companys
(CompanyName,Details,AddedDate)VALUES
('{0}','{1}', '{2}' )"
, CompanyDetails.Name.ToString(), CompanyDetails.Details.ToString(), CompanyDetails.AddedDate.ToStringToinsert()), cn);
                cmd.CommandType = CommandType.Text;

                cn.Open();
                int ret = ExuteNonQuery(cmd);
                return ret;
            }
        }
        public override List<ClientDealDetails> GetAllSalesReturns()
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                //old by real date
               //OleDbCommand cmd = new OleDbCommand(string.Format("select * from SalesReturns where (DateValue(AddedDate)=DateValue('{0}')) order by ID desc ", MyDateTime.Now.JustDate), cn);
                //by string
                OleDbCommand cmd = new OleDbCommand(string.Format("select * from SalesReturns where (left(AddedDate,10)= '{0}') order by ID desc ", MyDateTime.Now.JustDate), cn);
               //System.Windows.Forms.MessageBox.Show(cmd.CommandText);
                try
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                }
                catch (Exception) { System.Windows.Forms.MessageBox.Show("يوجد خطأ(جلب البيانات)"); }
                return GetClientDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        public override List<ClientDealDetails> GetAllClientDeals()
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
            
           //by string
                OleDbCommand cmd = new OleDbCommand(string.Format("select * from ClientDeals where (left(AddedDate,10)='{0}') order by ID desc ", MyDateTime.Now.JustDate), cn);
                //old by realdate    
                //OleDbCommand cmd = new OleDbCommand(string.Format("select * from ClientDeals where (DateValue(AddedDate)=DateValue('{0}')) order by ID desc ", MyDateTime.Now.JustDate), cn);
                //System.Windows.Forms.MessageBox.Show(cmd.CommandText);
                try
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                }
                catch (Exception) { System.Windows.Forms.MessageBox.Show("يوجد خطأ(جلب البيانات)"); }
                return GetClientDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        
       
        public override List<ClientDealDetails> SearchClientDeal(string key)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(
               string.Format("select * from  ClientDeals where   ClientId ={0} or  TypeId ={0} or Amount={0} or Price={0} or Details like '%{0}%' order by ID desc", key), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetClientDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        public override List<ClientDealDetails> SearchSalesReturns(string key)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(
               string.Format("select * from  SalesReturns where   ClientId ={0} or  TypeId ={0} or Amount={0} or Price={0} or Details like '%{0}%' order by ID desc", key), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetClientDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        public override ClientDealDetails GetSalesReturnsByID(int ID)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("select * from SalesReturns where Id=" + ID.ToString(), cn);
                try
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                }
                catch  {  }
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetClientDealFromReader(reader);
                else
                    return null;
            }
        }
        public override ClientDealDetails GetClientDealByID(int ID)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("select * from ClientDeals where Id=" + ID.ToString(), cn);
                try
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                }
                catch (Exception) { System.Windows.Forms.MessageBox.Show("يوجد خطأ(جلب البيانات)"); }
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetClientDealFromReader(reader);
                else
                    return null;
            }
        }
        public override bool DeleteClientDeal(int Id)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("delete from ClientDeals where Id =" + Id.ToString(), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                int ret = ExuteNonQuery(cmd);
                return (ret == 1);
            }
        }
        public override bool DeleteSalesReturns(int Id)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("delete from SalesReturns where Id =" + Id.ToString(), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                int ret = ExuteNonQuery(cmd);
                return (ret == 1);
            }
        }
        public override bool UpdateSalesReturns(ClientDealDetails ClientDealDetails)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(@"UPDATE SalesReturns  SET ClientId ="
                + ClientDealDetails.ClientId.ToString()
                + ",TypeId=" + ClientDealDetails.TypeId.ToString()
                + ",Amount=" + ClientDealDetails.Amount.ToString()
               + ",Price=" + ClientDealDetails.Price.ToString()
                + ",PaidMoney=" + ClientDealDetails.PaidMoney.ToString()
                   + ",ClientName='" + ClientDealDetails.ClientName.ToString()
                        + "',TypeName='" + ClientDealDetails.TypeName.ToString()

                   + "',Details='" + ClientDealDetails.Details.ToString()
                + "' WHERE Id=" + ClientDealDetails.ID.ToString(), cn);
                cmd.CommandType = CommandType.Text;
                //  System.Windows.Forms.MessageBox.Show(cmd.CommandText);
                int ret = 0;
                cn.Open(); try
                {
                    ret = ExuteNonQuery(cmd);
                }
                finally { }
                return (ret == 1);
            }
        }
        public override bool UpdateClientDealy(ClientDealDetails ClientDealDetails)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(@"UPDATE ClientDeals  SET ClientId ="
                + ClientDealDetails.ClientId.ToString()
                + ",TypeId=" + ClientDealDetails.TypeId.ToString()
                + ",Amount=" + ClientDealDetails.Amount.ToString()
               + ",Price=" + ClientDealDetails.Price.ToString()
                + ",PaidMoney=" + ClientDealDetails.PaidMoney.ToString()
                   + ",ClientName='" + ClientDealDetails.ClientName.ToString()
                        + "',TypeName='" + ClientDealDetails.TypeName.ToString()

                   + "',Details='" + ClientDealDetails.Details.ToString()
                + "' WHERE Id=" + ClientDealDetails.ID.ToString(), cn);
                cmd.CommandType = CommandType.Text;
                //  System.Windows.Forms.MessageBox.Show(cmd.CommandText);
                int ret = 0;
                cn.Open(); try
                {
                    ret = ExuteNonQuery(cmd);
                }
                finally { }
                return (ret == 1);
            }
        }
        public override int InsertSalesReturns(ClientDealDetails ClientDealDetails)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                byte x = 1;
                switch (ClientDealDetails.TheUnit)
                {
                    case TheUnito.Gram: x = 0; break;
                    case TheUnito.Kilo: x = 1; break;
                    case TheUnito.Piece: x = 2; break;
                }
                OleDbCommand cmd = new OleDbCommand(string.Format(@"INSERT INTO  SalesReturns
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
                //    System.Windows.Forms.MessageBox.Show(ClientDealDetails.AddedDate.ToStringToinsert());
                cn.Open();
                int ret = ExuteNonQuery(cmd);
                return ret;
            }
        }
        public override int InsertClientDeal(ClientDealDetails ClientDealDetails)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                byte x=1;
              switch (ClientDealDetails.TheUnit){
                  case TheUnito.Gram :x=0;break;
                      case TheUnito.Kilo :x=1;break;
                      case TheUnito.Piece :x=2;break;
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
ClientDealDetails.ClientName,ClientDealDetails.TypeName), cn);
                cmd.CommandType = CommandType.Text;
             //    System.Windows.Forms.MessageBox.Show(ClientDealDetails.AddedDate.ToStringToinsert());
                cn.Open();
                int ret = ExuteNonQuery(cmd);
                return ret;
            }
        }
        public override int InsertClientDeal(ClientDealDetails ClientDealDetails,bool opencon)
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
ClientDealDetails.ClientName, ClientDealDetails.TypeName));
                cmd.CommandType = CommandType.Text;
                //    System.Windows.Forms.MessageBox.Show(ClientDealDetails.AddedDate.ToStringToinsert());
              //  cn.Open();
                int ret = ExuteNonQuery(cmd);
                return ret;
 
        }
        public override List<BusinesDealDetails> GetAllBusinesReturns()
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                //OleDbCommand cmd = new OleDbCommand(string.Format("select * from BuyReturns  where (DateValue(AddedDate)=DateValue('{0}'))  order by ID desc ", MyDateTime.Now.JustDate), cn);
                OleDbCommand cmd = new OleDbCommand(string.Format("select * from BuyReturns  where (left(AddedDate,10)= '{0}')  order by ID desc ", MyDateTime.Now.JustDate), cn);
                try
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                }
                catch (Exception) { System.Windows.Forms.MessageBox.Show("يوجد خطأ(جلب البيانات)"); }
                return GetBusinesDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        public override List<BusinesDealDetails> GetAllBusinesDeals()
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                //OleDbCommand cmd = new OleDbCommand(string.Format("select * from BusinessDeals  where (DateValue(AddedDate)=DateValue('{0}'))  order by ID desc ", MyDateTime.Now.JustDate), cn);
                OleDbCommand cmd = new OleDbCommand(string.Format("select * from BusinessDeals where (left(AddedDate,10)= '{0}')  order by ID desc ", MyDateTime.Now.JustDate), cn);
                try
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                }
                catch (Exception) { System.Windows.Forms.MessageBox.Show("يوجد خطأ(جلب البيانات)"); }
                return GetBusinesDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        public override List<BusinesDealDetails> SearchBusinesReturns(string key)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(
               string.Format("select * from  BuyReturns where  Amount={0} or BusinessPrice={0}  or ClientPrice={0} order by ID desc", key), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetBusinesDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        public override List<BusinesDealDetails> SearchBusinesDeal(string key)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(
               string.Format("select * from  BusinessDeals where  Amount={0} or BusinessPrice={0}  or ClientPrice={0} order by ID desc", key), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetBusinesDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        public override List<BusinesDealDetails> SearchBusinesDeal(int typeid)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(
               string.Format("select * from  BusinessDeals where   TypeId={0} order by ID desc", typeid), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetBusinesDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        public override List<BusinesDealDetails> SearchBusinesReturns(int typeid)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(
               string.Format("select * from  BuyReturns where   TypeId={0} order by ID desc", typeid), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetBusinesDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        public override BusinesDealDetails GetBusinesReturnsByID(int ID)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("select * from BuyReturns where Id=" + ID.ToString(), cn);
                try
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                }
                catch { }
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetBusinesDealFromReader(reader);
                else
                    return null;
            }
        }
        public override BusinesDealDetails GetBusinesDealByID(int ID)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("select * from BusinessDeals where Id=" + ID.ToString(), cn);
                try
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                }
                catch {  }
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetBusinesDealFromReader(reader);
                else
                    return null;
            }
        }
        public override bool DeleteBusinesReturns(int Id)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("delete from BuyReturns where Id =" + Id.ToString(), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                int ret = ExuteNonQuery(cmd);
                return (ret == 1);
            }
        }
        public override bool DeleteBusinesDeal(int Id)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("delete from BusinessDeals where Id =" + Id.ToString(), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                int ret = ExuteNonQuery(cmd);
                return (ret == 1);
            }
        }
        public override bool UpdateBusinesReturnsy(BusinesDealDetails BusinesDealDetails)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(@"UPDATE BuyReturns  SET TypeId ="
                + BusinesDealDetails.TypeId.ToString()
                + ",ManId=" + BusinesDealDetails.ManId.ToString()
                + ",Amount=" + BusinesDealDetails.Amount.ToString()
               + ",BusinessPrice=" + BusinesDealDetails.BusinessPrice.ToString()
               + ",ClientPrice=" + BusinesDealDetails.ClientPrice.ToString()
          + ",PaidMoney=" + BusinesDealDetails.PaidMoney.ToString()
                   + ",Details='" + BusinesDealDetails.Details.ToString()
                   + "',ManName='" + BusinesDealDetails.ManName.ToString()
                   + "',Typename='" + BusinesDealDetails.TypeName.ToString()
                + "' WHERE Id=" + BusinesDealDetails.ID.ToString(), cn);
                cmd.CommandType = CommandType.Text;
                int ret = 0;
                cn.Open(); try
                {
                    ret = ExuteNonQuery(cmd);
                }
                finally { }
                return (ret == 1);
            }
        }
        public override bool UpdateBusinesDealy(BusinesDealDetails BusinesDealDetails)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(@"UPDATE BusinessDeals  SET TypeId ="
                + BusinesDealDetails.TypeId.ToString()
                + ",ManId=" + BusinesDealDetails.ManId.ToString()
                + ",Amount=" + BusinesDealDetails.Amount.ToString()
               + ",BusinessPrice=" + BusinesDealDetails.BusinessPrice.ToString()
               + ",ClientPrice=" + BusinesDealDetails.ClientPrice.ToString()
          + ",PaidMoney=" + BusinesDealDetails.PaidMoney.ToString()
                   + ",Details='" + BusinesDealDetails.Details.ToString()
                   + "',ManName='" + BusinesDealDetails.ManName.ToString()
                   + "',Typename='" + BusinesDealDetails.TypeName.ToString()
                + "' WHERE Id=" + BusinesDealDetails.ID.ToString(), cn);
                cmd.CommandType = CommandType.Text;
                int ret = 0;
                cn.Open(); try
                {
                    ret = ExuteNonQuery(cmd);
                }
                finally { }
                return (ret == 1);
            }
        }
        public override int InsertBusinesDeal(BusinesDealDetails BusinesDealDetails)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(string.Format(@"INSERT INTO  BusinessDeals 
(ManId,TypeId,Amount,BusinessPrice,ClientPrice,PaidMoney,Details,AddedDate,ManName,TypeName)VALUES
( {0},{1},{2},{3},{4},{5},'{6}','{7}','{8}','{9}')"
    , BusinesDealDetails.ManId.ToString(),
    BusinesDealDetails.TypeId.ToString(),
    BusinesDealDetails.Amount.ToString(),
    BusinesDealDetails.BusinessPrice.ToString(),
    BusinesDealDetails.ClientPrice.ToString(),
    BusinesDealDetails.PaidMoney.ToString(),
    BusinesDealDetails.Details.ToString(),
    BusinesDealDetails.AddedDate.ToStringToinsert(),
    BusinesDealDetails.ManName, BusinesDealDetails.TypeName),cn);
                cn.Open();
                cmd.CommandType = CommandType.Text;
               int  ret = ExuteNonQuery(cmd); 
                return ret;
            }
        }
        private int InsertBusinesDeal(BLL.BusinesDeal BusinesDealDetails,  OleDbConnection conopend )
        {
       OleDbCommand cmd = new OleDbCommand(string.Format(@"INSERT INTO  BusinessDeals 
(ManId,TypeId,Amount,BusinessPrice,ClientPrice,PaidMoney,Details,AddedDate,ManName,TypeName)VALUES
( {0},{1},{2},{3},{4},{5},'{6}','{7}','{8}','{9}')"
    , BusinesDealDetails.ManId.ToString(),
    BusinesDealDetails.TypeId.ToString(),
    BusinesDealDetails.Amount.ToString(),
    BusinesDealDetails.BusinessPrice.ToString(),
    BusinesDealDetails.ClientPrice.ToString(),
    BusinesDealDetails.PaidMoney.ToString(),
    BusinesDealDetails.Details.ToString(),
    BusinesDealDetails.AddedDate.ToStringToinsert(),
    BusinesDealDetails.ManName, BusinesDealDetails.TypeName), conopend);
                cmd.CommandType = CommandType.Text;
              int   ret = ExuteNonQuery(cmd); 
                return ret;
            
        }
        private   int InsertBusinesReturns(BusinesDealDetails BusinesDealDetails,OleDbConnection cn)
        {

                OleDbCommand cmd = new OleDbCommand(string.Format(@"INSERT INTO  BuyReturns 
(ManId,TypeId,Amount,BusinessPrice,ClientPrice,PaidMoney,Details,AddedDate,ManName,TypeName)VALUES
( {0},{1},{2},{3},{4},{5},'{6}','{7}','{8}','{9}')"
, BusinesDealDetails.ManId.ToString(),
BusinesDealDetails.TypeId.ToString(),
BusinesDealDetails.Amount.ToString(),
BusinesDealDetails.BusinessPrice.ToString(),
BusinesDealDetails.ClientPrice.ToString(),
BusinesDealDetails.PaidMoney.ToString(),
BusinesDealDetails.Details.ToString(),
BusinesDealDetails.AddedDate.ToStringToinsert(),
BusinesDealDetails.ManName, BusinesDealDetails.TypeName), cn);
                cmd.CommandType = CommandType.Text;
                int ret = ExuteNonQuery(cmd);
                return ret;
        }
        public override int InsertBusinesReturns(BusinesDealDetails BusinesDealDetails)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(string.Format(@"INSERT INTO  BuyReturns 
(ManId,TypeId,Amount,BusinessPrice,ClientPrice,PaidMoney,Details,AddedDate,ManName,TypeName)VALUES
( {0},{1},{2},{3},{4},{5},'{6}','{7}','{8}','{9}')"
, BusinesDealDetails.ManId.ToString(),
BusinesDealDetails.TypeId.ToString(),
BusinesDealDetails.Amount.ToString(),
BusinesDealDetails.BusinessPrice.ToString(),
BusinesDealDetails.ClientPrice.ToString(),
BusinesDealDetails.PaidMoney.ToString(),
BusinesDealDetails.Details.ToString(),
BusinesDealDetails.AddedDate.ToStringToinsert(),
BusinesDealDetails.ManName, BusinesDealDetails.TypeName), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                int ret = ExuteNonQuery(cmd);
                return ret;
            }
        }
        public override List<StoreDetails> GetAllStores()
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("select * from Store", cn);
                try
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                }
                catch  { }
                return GetStoresCollectionFromReader(ExecuteReader(cmd));
            }
        }
        public override List<StoreDetails> SearchStore(string key)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                OleDbCommand cmd = new OleDbCommand(string.Format("select * from  Store where  Amount like  '%{0}%'", key), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetStoresCollectionFromReader(ExecuteReader(cmd));
            }
        }
        public override List<StoreDetails> SearchStore(int typeid)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                OleDbCommand cmd = new OleDbCommand(string.Format("select * from  Store where  TypeId={0}", typeid), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetStoresCollectionFromReader(ExecuteReader(cmd));
            }
        }
        public override StoreDetails GetStoreByID(int ID)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("select * from Store where Id=" + ID.ToString(), cn);
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
        public override StoreDetails GetStoreByTypeID(int TypeId)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
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
        public override bool DeleteStore(int Id)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("delete from Store where Id =" + Id.ToString(), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                int ret = ExuteNonQuery(cmd);
                return (ret == 1);
            }
        }
 
        public override int InsertStoreFromCompany(StoreDetails StoreDetails)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                StoreDetails tmp = null; tmp = this.GetStoreByTypeID(StoreDetails.TypeId);
                if (tmp != null)
                {
                    //update
                    OleDbCommand cmd = new OleDbCommand(@"UPDATE Store  SET TypeId ="
                + StoreDetails.TypeId.ToString()

                + ",Amount=" + (tmp.Amount + StoreDetails.Amount).ToString()
               + ",AddedDateCompany='" + StoreDetails.AddedDateCompany + "' WHERE Id=" + tmp.ID.ToString(), cn);
                    cmd.CommandType = CommandType.Text;
                    int ret = 0;
                    cn.Open(); try
                    {
                        ret = ExuteNonQuery(cmd);
                    }
                    finally { }
                    return (ret);
                }
                else
                {
                    //insert
                    OleDbCommand cmd = new OleDbCommand(string.Format(@"INSERT INTO  Store 
(TypeId,Amount,AddedDateClient,AddedDateCompany,TypeName)VALUES
( {0},{1},'{2}', '{3}' ,'{4}' )"
, StoreDetails.TypeId.ToString(),
StoreDetails.Amount.ToString(),
StoreDetails.AddedDateClient, StoreDetails.AddedDateCompany, StoreDetails.TypeName), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    int ret = ExuteNonQuery(cmd);
                    return ret;
                }
            }
        }
        public override int InsertStoreFromCompany(StoreDetails StoreDetails,bool decremnt)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                StoreDetails tmp = null; tmp = this.GetStoreByTypeID(StoreDetails.TypeId);
                if (tmp != null)
                {
                    //update
                    OleDbCommand cmd = new OleDbCommand(@"UPDATE Store  SET TypeId ="
                + StoreDetails.TypeId.ToString()

                + ",Amount=" + (tmp.Amount - StoreDetails.Amount).ToString()
               + ",AddedDateCompany='" + StoreDetails.AddedDateCompany + "' WHERE Id=" + tmp.ID.ToString(), cn);
                    cmd.CommandType = CommandType.Text;
                    int ret = 0;
                    cn.Open(); try
                    {
                        ret = ExuteNonQuery(cmd);
                    }
                    finally { }
                    return (ret);
                }
                else
                {
                    //insert
                    OleDbCommand cmd = new OleDbCommand(string.Format(@"INSERT INTO  Store 
(TypeId,Amount,AddedDateClient,AddedDateCompany,TypeName)VALUES
( {0},{1},'{2}', '{3}' ,'{4}' )"
, StoreDetails.TypeId.ToString(),
StoreDetails.Amount.ToString(),
StoreDetails.AddedDateClient, StoreDetails.AddedDateCompany, StoreDetails.TypeName), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    int ret = ExuteNonQuery(cmd);
                    return ret;
                }
            }
        }
        private   int InsertStoreFromCompany(BusinesReturns StoreDetails, OleDbConnection cn)
        {
                StoreDetails tmp = null; tmp = this.GetStoreByTypeID(StoreDetails.TypeId);
                if (tmp != null)
                {
                    //update
                    OleDbCommand cmd = new OleDbCommand(@"UPDATE Store  SET TypeId ="
                + StoreDetails.TypeId.ToString()

                + ",Amount=" + (tmp.Amount - StoreDetails.Amount).ToString()
               + ",AddedDateCompany='" + DateTime.Now + "' WHERE Id=" + tmp.ID.ToString(), cn);
                    cmd.CommandType = CommandType.Text;
                    int ret = 0;
                   try
                    {
                        ret = ExuteNonQuery(cmd);
                    }
                    finally { }
                    return (ret);
                }
                else
                {
                    //insert
                    OleDbCommand cmd = new OleDbCommand(string.Format(@"INSERT INTO  Store 
(TypeId,Amount,AddedDateCompany,TypeName)VALUES
( {0},{1},'{2}', '{3}' )"
, StoreDetails.TypeId.ToString(),
StoreDetails.Amount.ToString(),
DateTime.Now, StoreDetails.TypeName), cn);
                    cmd.CommandType = CommandType.Text;
                    int ret = ExuteNonQuery(cmd);
                    return ret;
                }
             
        }
        public override int InsertStoreFromClient(StoreDetails StoreDetails)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                StoreDetails tmp = null; tmp = this.GetStoreByTypeID(StoreDetails.TypeId);
                if (tmp != null)
                {
                    if (tmp.Amount - StoreDetails.Amount < 0)
                    {
                        string text = " الصنف " + BLL.BllGlobal.GetTypeNameFromListTypesHere(StoreDetails.TypeId) + "  تأكد من المخزن والبضاعة المتوفر لا توجد لديك هذه الكمية";
                        string caption = "رسالة تحذير من المخزن-البضاعة المتوفرة";
                        System.Windows.Forms.MessageBox.Show(text, caption, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning); return 0;
                    }
                    OleDbCommand cmd = new OleDbCommand(@"UPDATE Store  SET TypeId ="
                + StoreDetails.TypeId.ToString()

                + ",Amount=" + (tmp.Amount - StoreDetails.Amount).ToString()
               + ",AddedDateClient='" + StoreDetails.AddedDateClient
               + "' WHERE Id=" + tmp.ID.ToString(), cn);
                    cmd.CommandType = CommandType.Text;
                    int ret = 0;
                    cn.Open();
                    try
                    {
                        ret = ExuteNonQuery(cmd);
                    }
                    finally { }
                    return (ret);
                }
                else
                {
                    string text = "لا يوجد من هذا الصنف ضمن المخزن-قسم البضاعة المتوفرة";
                    string caption = "رسالة تحذير من المخزن-البضاعة المتوفرة";
                    System.Windows.Forms.MessageBox.Show(text, caption, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);

                    return 0;
                }
            }
        }
        public override int InsertStoreFromClient(StoreDetails StoreDetails, bool addthstore)
        {
            ///هون فرضنا القيمة صحيحة
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                StoreDetails tmp = null; tmp = this.GetStoreByTypeID(StoreDetails.TypeId);
                if (tmp != null)
                {
                    //update
                    OleDbCommand cmd = new OleDbCommand(@"UPDATE Store  SET TypeId ="
                + StoreDetails.TypeId.ToString()

                + ",Amount=" + (tmp.Amount + StoreDetails.Amount).ToString()
               + ",AddedDateClient='" + StoreDetails.AddedDateClient + "' WHERE Id=" + tmp.ID.ToString(), cn);
                    cmd.CommandType = CommandType.Text;
                    int ret = 0;
                    cn.Open(); try
                    {
                        ret = ExuteNonQuery(cmd);
                    }
                    finally { }
                    return (ret);
                }
                else
                {
                    //insert
                    OleDbCommand cmd = new OleDbCommand(string.Format(@"INSERT INTO  Store 
(TypeId,Amount,AddedDateClient,AddedDateCompany,TypeName)VALUES
( {0},{1},'{2}', '{3}' ,'{4}' )"
, StoreDetails.TypeId.ToString(),
StoreDetails.Amount.ToString(),
StoreDetails.AddedDateClient, StoreDetails.AddedDateCompany, StoreDetails.TypeName), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    int ret = ExuteNonQuery(cmd);
                    return ret;
                }
            }
        }
        private int InsertStoreFromClient(SalesReturns StoreDetails, OleDbConnection cn)
        {
                StoreDetails tmp = null; tmp = this.GetStoreByTypeID(StoreDetails.TypeId);
                if (tmp != null)
                {
                    //update
                    OleDbCommand cmd = new OleDbCommand(@"UPDATE Store  SET TypeId ="
                + StoreDetails.TypeId.ToString()

                + ",Amount=" + (tmp.Amount + StoreDetails.Amount).ToString()
               + ",AddedDateClient='" + DateTime.Now + "' WHERE Id=" + tmp.ID.ToString(), cn);
                    cmd.CommandType = CommandType.Text;
                    int ret = 0;
                     try
                    {
                        ret = ExuteNonQuery(cmd);
                    }
                    finally { }
                    return (ret);
                }
                else
                {
                    //insert
                    OleDbCommand cmd = new OleDbCommand(string.Format(@"INSERT INTO  Store 
(TypeId,Amount,AddedDateClient,TypeName)VALUES
( {0},{1},'{2}', '{3}' ,'{4}' )"
, StoreDetails.TypeId.ToString(),
StoreDetails.Amount.ToString(),
DateTime.Now, StoreDetails.TypeName), cn);
                    cmd.CommandType = CommandType.Text;
             
                    int ret = ExuteNonQuery(cmd);
                    return ret;
                 
            }
        }
        public override int InsertStoreFromClient(StoreDetails StoreDetails, bool addthstore,bool opencon)
        {
            ///هون فرضنا القيمة صحيحة
 

                StoreDetails tmp = null; tmp = this.GetStoreByTypeID(StoreDetails.TypeId);
                if (tmp != null)
                {
                    //update
                    OleDbCommand cmd = new OleDbCommand(@"UPDATE Store  SET TypeId ="
                + StoreDetails.TypeId.ToString()

                + ",Amount=" + (tmp.Amount + StoreDetails.Amount).ToString()
               + ",AddedDateClient='" + StoreDetails.AddedDateClient + "' WHERE Id=" + tmp.ID.ToString() );
                    cmd.CommandType = CommandType.Text;
                    int ret = 0;
                    try
                    {
                        ret = ExuteNonQuery(cmd);
                    }
                    finally { }
                    return (ret);
                }
                else
                {
                    //insert
                    OleDbCommand cmd = new OleDbCommand(string.Format(@"INSERT INTO  Store 
(TypeId,Amount,AddedDateClient,AddedDateCompany,TypeName)VALUES
( {0},{1},'{2}', '{3}' ,'{4}' )"
, StoreDetails.TypeId.ToString(),
StoreDetails.Amount.ToString(),
StoreDetails.AddedDateClient, StoreDetails.AddedDateCompany, StoreDetails.TypeName) );
                    cmd.CommandType = CommandType.Text;
                    int ret = ExuteNonQuery(cmd);
                    return ret;
                 
            }
        }
        public override void UpdateTypNamesinstore(int typied, string newname)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(@"UPDATE Store  SET TypeName ='" + newname +"' WHERE TypeId=" + typied.ToString(), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open(); try
                {
                ExuteNonQuery(cmd);
                }
                finally { }

            }
        }
        internal List<BusinesDealDetails> SearchBusinesDeal(int id, bool iscompany)
        {
            string sqlo = "";

            if (!iscompany) sqlo = "select * from  BusinessDeals where  TypeId ={0}";
            else sqlo = "select * from  BusinessDeals where ManId ={0}";
            sqlo += " order by ID desc";
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, id.ToString()), cn);
                cmd.CommandType = CommandType.Text;
                
                cn.Open();
                return GetBusinesDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        internal List<BusinesDealDetails> SearchBusinesReturns(int id, bool iscompany)
        {
            string sqlo = "";

            if (!iscompany) sqlo = "select * from  BuyReturns where  TypeId ={0}";
            else sqlo = "select * from  BuyReturns where ManId ={0}";
            sqlo += " order by ID desc";
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, id.ToString()), cn);
                cmd.CommandType = CommandType.Text;

                cn.Open();
                return GetBusinesDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        internal List<ClientDealDetails> SearchSalesReturns(int id, bool isclint)
        {
            string sqlo = "";
            if (!isclint) sqlo = "select * from  SalesReturns where  TypeId ={0}";
            else sqlo = "select * from  ClientDeals where ClientId ={0}";
            sqlo += " order by ID desc";
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, id.ToString()), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetClientDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        internal List<ClientDealDetails> SearchClientDeal(int id, bool isclint)
        {
            string sqlo = "";
            if (!isclint) sqlo = "select * from  ClientDeals where  TypeId ={0}";
            else sqlo = "select * from  ClientDeals where ClientId ={0}";
            sqlo += " order by ID desc";
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, id.ToString()), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetClientDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        internal double GetclientPaidPricebyclient(int ido)
        {
            string sqlo = "SELECT  Sum(PaidMoney)FROM ClientDeals where ClientId={0}";
            try
            {
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {

                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, ido.ToString()), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }
        internal double GetclientPaidPriceSalesReturns(int ido)
        {
            string sqlo = "SELECT  Sum(PaidMoney)FROM SalesReturns where ClientId={0}";
            try
            {
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {

                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, ido.ToString()), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }
        internal double GetdealPiecebySalesReturns(int ido)
        {

            string sqlo = "SELECT  Sum((Amount))FROM SalesReturns where ClientId ={0} and( TheUnit=2)";
            try
            {
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {

                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, ido.ToString()), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }
        internal double GetdealPiecebyclient(int ido)
        {

            string sqlo = "SELECT  Sum((Amount))FROM ClientDeals where ClientId ={0} and( TheUnit=2)";
            try
            {
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {

                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, ido.ToString()), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }
        //internal double GetdealPiecebyclient(int ido)
        //{

        //    string sqlo = "SELECT  Sum((Amount))FROM ClientDeals where ClientId ={0} and( TheUnit=2)";
        //    try
        //    {
        //        using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
        //        {

        //            OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, ido.ToString()), cn);
        //            cmd.CommandType = CommandType.Text;
        //            cn.Open();
        //            return ((double)ExecuteScalar(cmd));
        //        }
        //    }
        //    catch { return 0; }
        //}
        internal List<BusinesDealDetails> Search(DateTime intimedateTime)
        {
            string sqlo = "";
            //sqlo = @"SELECT * FROM BusinessDeals WHERE  DateValue(AddedDate)Like DateValue ('{0}') order by ID desc";
            sqlo = @"SELECT * FROM BusinessDeals  where (left(AddedDate,10)='{0}') order by ID desc";
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref intimedateTime).JustDate), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetBusinesDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        internal List<BusinesDealDetails> SearchBusinesReturns(DateTime intimedateTime)
        {
            string sqlo = "";
            // sqlo = @"SELECT * FROM BuyReturns WHERE  DateValue(AddedDate)Like DateValue ('{0}') order by ID desc";
            sqlo = @"SELECT * FROM BuyReturns  where (left(AddedDate,10)= '{0}')    order by ID desc";
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref intimedateTime).JustDate), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetBusinesDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        internal List<ClientDealDetails> SearchC(DateTime intimedateTime)
        {
            string sqlo = "";
//            sqlo = @"SELECT * FROM ClientDeals WHERE  DateValue(AddedDate)Like DateValue ('{0}') order by ID desc";
            sqlo = @"SELECT * FROM ClientDeals  where (left(AddedDate,10)= '{0}') order by ID desc";
           
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref intimedateTime).JustDate), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetClientDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        internal List<ClientDealDetails> SearchCSalesReturns(DateTime intimedateTime)
        {
            string sqlo = "";
            //sqlo = @"SELECT * FROM SalesReturns WHERE  DateValue(AddedDate)Like DateValue ('{0}') order by ID desc";
            sqlo = @"SELECT * FROM SalesReturns where (left(AddedDate,10)= '{0}')   order by ID desc";
            
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref intimedateTime).JustDate), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetClientDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        internal List<BusinesDealDetails> Search(DateTime dateTime1, DateTime dateTime2)
        {
            string sqlo = "";
            //sqlo = @"SELECT * FROM BusinessDeals WHERE DateValue(AddedDate) BETWEEN DateValue('{0}') and DateValue ('{1}') order by ID desc";
            sqlo = @"SELECT * FROM BusinessDeals WHERE (left(AddedDate,10) BETWEEN '{0}' and '{1}')  order by ID desc";
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                 
                OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetBusinesDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        internal List<BusinesDealDetails> SearchBusinesReturns(DateTime dateTime1, DateTime dateTime2)
        {
            string sqlo = "";
            //  sqlo = @"SELECT * FROM BuyReturns WHERE DateValue(AddedDate) BETWEEN DateValue('{0}') and DateValue ('{1}') order by ID desc";
            sqlo = @"SELECT * FROM BuyReturns WHERE (left(AddedDate,10) BETWEEN '{0}' and '{1}') order by ID desc";
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetBusinesDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        internal List<ClientDealDetails> SearchC(DateTime dateTime1, DateTime dateTime2)
        {
            string sqlo = "";
            // sqlo = @"SELECT * FROM ClientDeals WHERE DateValue(AddedDate) BETWEEN DateValue('{0}') and DateValue ('{1}') order by ID desc";
            sqlo = @"SELECT * FROM ClientDeals WHERE (left(AddedDate,10) BETWEEN '{0}' and '{1}') order by ID desc";
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetClientDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        internal List<ClientDealDetails> SearchCSalesReturns(DateTime dateTime1, DateTime dateTime2)
        {
            string sqlo = "";
            //sqlo = @"SELECT * FROM SalesReturns WHERE DateValue(AddedDate) BETWEEN DateValue('{0}') and DateValue ('{1}') order by ID desc";
            sqlo = @"SELECT * FROM SalesReturns WHERE (left(AddedDate,10) BETWEEN '{0}' and '{1}') order by ID desc";
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetClientDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        internal List<BusinesDealDetails> Search(DateTime dateTime, int typid, int manid)
        {
            string sqlo = "";
            sqlo = @"SELECT * FROM BusinessDeals WHERE  (left(AddedDate,10)='{0}') and (ManId={2} or TypeId={1}) order by ID desc";
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(dateTime).JustDate, typid.ToString(), manid.ToString()), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetBusinesDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        internal List<BusinesDealDetails> SearchBusinesReturns(DateTime dateTime, int typid, int manid)
        {
            string sqlo = "";
            sqlo = @"SELECT * FROM BuyReturns WHERE  (left(AddedDate,10)= '{0}') and (ManId={2} or TypeId={1}) order by ID desc";
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(dateTime).JustDate, typid.ToString(), manid.ToString()), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetBusinesDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        internal List<ClientDealDetails> SearchC(DateTime dateTime, int typid, int manid)
        {
            string sqlo = "";
            //sqlo = @"SELECT * FROM ClientDeals WHERE  (DateValue(AddedDate)Like DateValue ('{0}')) and (ClientId={2} or TypeId={1}) order by ID desc";
            sqlo = @"SELECT * FROM ClientDeals WHERE  (left(AddedDate,10)='{0}') and (ClientId={2} or TypeId={1}) order by ID desc";
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(dateTime).JustDate, typid.ToString(), manid.ToString()), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetClientDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        internal List<ClientDealDetails> SearchCSalesReturns(DateTime dateTime, int typid, int manid)
        {
            string sqlo = "";
            sqlo = @"SELECT * FROM SalesReturns WHERE  (left(AddedDate,10)='{0}') and (ClientId={2} or TypeId={1}) order by ID desc";
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(dateTime).JustDate, typid.ToString(), manid.ToString()), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetClientDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        internal List<ClientDealDetails> SearchClientDeals(int typid)
        {
            string sqlo = "";
            ///  
            sqlo = @"SELECT * FROM ClientDeals WHERE  TypeId={0}  order by ID desc";

            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typid.ToString()), cn);
                //System.Windows.Forms.MessageBox.Show(cmd.CommandText);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetClientDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        internal List<ClientDealDetails> SearchClientDealsSalesReturns(int typid)
        {
            string sqlo = "";
            ///  
            sqlo = @"SELECT * FROM SalesReturns WHERE  TypeId={0}  order by ID desc";

            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typid.ToString()), cn);
                //System.Windows.Forms.MessageBox.Show(cmd.CommandText);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetClientDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        internal List<ClientDealDetails> SearchClientDeals(DateTime dateTime1, DateTime dateTime2)
        {
            string sqlo = "";
            ///  
            sqlo = @"SELECT * FROM ClientDeals WHERE (left(AddedDate,10) BETWEEN '{0}' and '{1}') order by ID desc";

            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate), cn);
                //System.Windows.Forms.MessageBox.Show(cmd.CommandText);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetClientDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        internal List<ClientDealDetails> SearchClientDealsSalesReturns(DateTime dateTime1, DateTime dateTime2)
        {
            string sqlo = "";
            ///  
            sqlo = @"SELECT * FROM SalesReturns WHERE (left(AddedDate,10) BETWEEN  '{0}'  and  '{1}' ) order by ID desc";

            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate), cn);
                //System.Windows.Forms.MessageBox.Show(cmd.CommandText);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetClientDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        internal List<ClientDealDetails> SearchClientDeals(DateTime dateTime1, DateTime dateTime2, int typid)
        {
            string sqlo = "";
            ///  
            sqlo = @"SELECT * FROM ClientDeals WHERE (left(AddedDate,10) BETWEEN '{0}'  and '{1}')
and TypeId={2} order by ID desc";

            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate, typid.ToString()), cn);
                //System.Windows.Forms.MessageBox.Show(cmd.CommandText);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetClientDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        internal List<ClientDealDetails> SearchClientDealsSalesReturns(DateTime dateTime1, DateTime dateTime2, int typid)
        {
            string sqlo = "";
            ///  
            sqlo = @"SELECT * FROM SalesReturns WHERE (left(AddedDate,10) BETWEEN  '{0}'  and '{1}' 
and TypeId={2}) order by ID desc";

            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate, typid.ToString()), cn);
                //System.Windows.Forms.MessageBox.Show(cmd.CommandText);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetClientDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        internal List<BusinesDealDetails> Search(DateTime dateTime1, DateTime dateTime2, int typid)
        {
            string sqlo = "";
            ///  
            sqlo = @"SELECT * FROM BusinessDeals WHERE (left(AddedDate,10) BETWEEN '{0}'  and  '{1}' 
and TypeId={2}) order by ID desc";

            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate, typid.ToString()), cn);
                //System.Windows.Forms.MessageBox.Show(cmd.CommandText);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetBusinesDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        internal List<BusinesDealDetails> SearchBusinesReturns(DateTime dateTime1, DateTime dateTime2, int typid)
        {
            string sqlo = "";
            ///  
            sqlo = @"SELECT * FROM BuyReturns WHERE (left(AddedDate,10) BETWEEN   '{0}'  and '{1}' 
and TypeId={2}) order by ID desc";

            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate, typid.ToString()), cn);
                //System.Windows.Forms.MessageBox.Show(cmd.CommandText);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetBusinesDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        internal List<BusinesDealDetails> Search(DateTime dateTime1, DateTime dateTime2, int typid, int manid)
        {
            string sqlo = "";
            ///  
            sqlo = @"SELECT * FROM BusinessDeals WHERE (left(AddedDate,10) BETWEEN  '{0}'  and '{1}' 
and (ManId={3} or TypeId={2})) order by ID desc";
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate, typid.ToString(), manid.ToString()), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetBusinesDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        internal List<BusinesDealDetails> SearchBusinesReturns(DateTime dateTime1, DateTime dateTime2, int typid, int manid)
        {
            string sqlo = "";
            ///  
            sqlo = @"SELECT * FROM BuyReturns WHERE (left(AddedDate,10) BETWEEN  '{0}'  and '{1}' 
and (ManId={3} or TypeId={2})) order by ID desc";
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate, typid.ToString(), manid.ToString()), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetBusinesDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        internal List<ClientDealDetails> SearchCSalesReturns(DateTime dateTime1, DateTime dateTime2, int typid, int manid)
        {
            string sqlo = "";
            sqlo = @"SELECT * FROM SalesReturns WHERE (left(AddedDate,10) BETWEEN '{0}'  and '{1}') 
and (ClientId={3} or TypeId={2}) order by ID desc ";
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                OleDbCommand cmd = new OleDbCommand(string.Format(sqlo,new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate, typid.ToString(), manid.ToString()), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetClientDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        internal List<ClientDealDetails> SearchC(DateTime dateTime1, DateTime dateTime2, int typid, int manid)
        {
            string sqlo = "";
            sqlo = @"SELECT * FROM ClientDeal WHERE (left(AddedDate,10) BETWEEN  '{0}'  and  '{1}' )
and (ClientId={3} or TypeId={2}) order by ID desc ";
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {

                OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate, typid.ToString(), manid.ToString()), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetClientDealsCollectionFromReader(ExecuteReader(cmd));
            }
        }
        internal double GetAllAmount(int typeid, DateTime dateTime11, DateTime dateTime22)
        {
            try
            {
                string sqlo = @"SELECT  Sum((Amount))FROM BusinessDeals  where TypeId ={0} and left(AddedDate,10) BETWEEN  '{1}'  and  '{2}'";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    //  OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString(), new MyDateTime(dateTime11).JustDate, new MyDateTime(dateTime22).JustDate), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }
        internal double GetAllAmountBusinesReturns(int typeid, DateTime dateTime11, DateTime dateTime22)
        {
            try
            {
                string sqlo = @"SELECT  Sum((Amount))FROM BuyReturns  where TypeId ={0} and left(AddedDate,10) BETWEEN '{1}'  and  '{2}'";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    //  OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString(), new MyDateTime(dateTime11).JustDate, new MyDateTime(dateTime22).JustDate), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }
        internal double GetAllAmount(DateTime dateTime11, DateTime dateTime22)
        {
            try
            {
                string sqlo = @"SELECT  Sum((Amount))FROM BusinessDeals  where left(AddedDate,10) BETWEEN  '{0}'  and '{1}'";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    //  OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(dateTime11).JustDate, new MyDateTime(dateTime22).JustDate), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }
        internal double GetAllAmountBusinesReturns(DateTime dateTime11, DateTime dateTime22)
        {
            try
            {
                string sqlo = @"SELECT  Sum((Amount))FROM BuyReturns  where left(AddedDate,10) BETWEEN  '{0}'  and '{1}'";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    //  OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(dateTime11).JustDate, new MyDateTime(dateTime22).JustDate), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }
        internal double GetAllAmount(int typeid)
        {
            try
            {
                string sqlo = @"SELECT  Sum((Amount))FROM BusinessDeals  where TypeId ={0}";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));

                }
            }
            catch { return 0; }
        }
        internal double GetAllAmountBusinesReturns(int typeid)
        {
            try
            {
                string sqlo = @"SELECT  Sum((Amount))FROM BuyReturns  where TypeId ={0}";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));

                }
            }
            catch { return 0; }
        }
        internal double GetAllAmount(DateTime dateTime11)
        {
            try
            {
                string sqlo = @"SELECT  Sum(Amount)FROM BusinessDeals  where  left(AddedDate,10)='{0}'";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    //  OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(dateTime11).JustDate), cn);
                    //   System.Windows.Forms.MessageBox.Show(cmd.CommandText);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }
        internal double GetAllAmountBusinesReturns(DateTime dateTime11)
        {
            try
            {
                string sqlo = @"SELECT  Sum(Amount)FROM BuyReturns  where left(AddedDate,10)='{0}'";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    //  OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(dateTime11).JustDate), cn);
                    //   System.Windows.Forms.MessageBox.Show(cmd.CommandText);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }
        internal double GetAllTotalPrice(int typeid, DateTime dateTime1, DateTime dateTime2)
        {
            try
            {
                string sqlo = @"SELECT  Sum((Amount * BusinessPrice))FROM BusinessDeals  where TypeId ={0} and left(AddedDate,10) BETWEEN '{1}'  and '{2}'";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    //  OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString(), new MyDateTime(dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }
        internal double GetAllTotalPriceBusinesReturns(int typeid, DateTime dateTime1, DateTime dateTime2)
        {
            try
            {
                string sqlo = @"SELECT  Sum((Amount * BusinessPrice))FROM BuyReturns  where TypeId ={0} and left(AddedDate,10) BETWEEN  '{1}'  and  '{2}'";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    //  OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString(), new MyDateTime(dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }
        internal double GetAllTotalPrice(DateTime dateTime1)
        {
            try
            {
                string sqlo = @"SELECT  Sum((Amount * BusinessPrice))FROM BusinessDeals  where  left(AddedDate,10)='{0}'";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    //  OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, dateTime1.ToString()), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }
        internal double GetAllTotalPriceBusinesReturns(DateTime dateTime1)
        {
            try
            {
                string sqlo = @"SELECT  Sum((Amount * BusinessPrice))FROM BuyReturns  where left(AddedDate,10) ='{0}'";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    //  OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, dateTime1.ToString()), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }
        internal double GetAllTotalPrice(int typeid)
        {
            try
            {
                string sqlo = @"SELECT  Sum((Amount * BusinessPrice))FROM BusinessDeals  where TypeId ={0}";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));

                }
            }
            catch { return 0; }
        }
        internal double GetAllTotalPriceBusinesReturns(int typeid)
        {
            try
            {
                string sqlo = @"SELECT  Sum((Amount * BusinessPrice))FROM BuyReturns  where TypeId ={0}";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));

                }
            }
            catch { return 0; }
        }
        internal double GetAllTotalPrice(DateTime dateTime1, DateTime dateTime2)
        {
            try
            {
                string sqlo = @"SELECT  Sum((Amount * BusinessPrice))FROM BusinessDeals  where  left(AddedDate,10) BETWEEN  '{0}'  and  '{1}'";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    //  OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }
        internal double GetAllTotalPriceBusinesReturns(DateTime dateTime1, DateTime dateTime2)
        {
            try
            {
                string sqlo = @"SELECT  Sum((Amount * BusinessPrice))FROM BuyReturns  where left(AddedDate,10) BETWEEN '{0}' and '{1}'";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    //  OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }
        internal double GetAllPaidPrice(DateTime dateTime1)
        {
            try
            {
                string sqlo = @"SELECT  Sum((PaidMoney))FROM BusinessDeals  where  left(AddedDate,10) = '{0}'";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    //  OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(dateTime1).JustDate), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }
        internal double GetAllPaidPriceBusinesReturns(DateTime dateTime1)
        {
            try
            {
                string sqlo = @"SELECT  Sum((PaidMoney))FROM BuyReturns  where left(AddedDate,10)= '{0}'";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    //  OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(dateTime1).JustDate), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }
        internal double GetAllPaidPrice(DateTime dateTime1, DateTime dateTime2)
        {
            try
            {
                string sqlo = @"SELECT  Sum((PaidMoney))FROM BusinessDeals  where left(AddedDate,10) BETWEEN '{0}' and '{1}'";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    //  OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }
        internal double GetAllPaidPriceBusinesReturns(DateTime dateTime1, DateTime dateTime2)
        {
            try
            {
                string sqlo = @"SELECT  Sum((PaidMoney))FROM BuyReturns  where left(AddedDate,10) BETWEEN '{0}' and '{1}'";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    //  OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }       
        //to client buys
        internal double GetAllAmountC(int typeid, DateTime dateTime11, DateTime dateTime22)
        {
            double x = 0;
            string sqlo = @"SELECT  Sum((Amount/1000))FROM ClientDeals  where(( TypeId ={0}) and (TheUnit=0) and (left(AddedDate,10) BETWEEN '{1}' and '{2}'))";
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString(), new MyDateTime(dateTime11).JustDate, new MyDateTime(ref dateTime22).JustDate), cn);
                cn.Open();
                cmd.CommandType = CommandType.Text;
                try
                {
                    x = ((double)ExecuteScalar(cmd));
                }
                catch { }
                try
                {
                    sqlo = @"SELECT  Sum((Amount))FROM ClientDeals  where TypeId ={0} and (TheUnit=1 or TheUnit=2) and left(AddedDate,10) BETWEEN '{1}' and '{2}'";
                    cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString(), new MyDateTime(dateTime11).JustDate, new MyDateTime(ref dateTime22).JustDate), cn);
                    cmd.CommandType = CommandType.Text;
                    x += ((double)ExecuteScalar(cmd));
                }
                catch { }
                return x;
            }
        }
        internal double GetAllAmountCSalesReturns(int typeid, DateTime dateTime11, DateTime dateTime22)
        {
            double x = 0;
            string sqlo = @"SELECT  Sum((Amount/1000))FROM SalesReturns  where(( TypeId ={0}) and (TheUnit=0) and (left(AddedDate,10) BETWEEN '{1}' and '{2}'))";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {                    
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString(), new MyDateTime(dateTime11).JustDate, new MyDateTime(ref dateTime22).JustDate), cn);
                    cn.Open();
                    cmd.CommandType = CommandType.Text;
                    try
                    {
                        x = ((double)ExecuteScalar(cmd));
                    }
                    catch { }
                    try
                    {
                        sqlo = @"SELECT  Sum((Amount))FROM SalesReturns  where TypeId ={0} and (TheUnit=1 or TheUnit=2) and left(AddedDate,10) BETWEEN  '{1}'  and  '{2}'";
                        cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString(), new MyDateTime(dateTime11).JustDate, new MyDateTime(ref dateTime22).JustDate), cn);
                        cmd.CommandType = CommandType.Text;
                        x += ((double)ExecuteScalar(cmd));
                    }
                    catch { }
                    return x;
                }
        
        }
        internal double GetAllAmountC(DateTime dateTime11, DateTime dateTime22)
        {
            double x = 0;
            string sqlo = @"SELECT  Sum((Amount/1000))FROM ClientDeals  where left(AddedDate,10) BETWEEN '{0}' and '{1}'  and (TheUnit=0)";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime( ref dateTime11).JustDate, new MyDateTime(ref dateTime22).JustDate), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                   try
                   {  x = ((double)ExecuteScalar(cmd)); }
                   catch { }
                    try
                    {
                        sqlo = @"SELECT  Sum((Amount))FROM ClientDeals  where  left(AddedDate,10) BETWEEN  '{0}'  and  '{1}'  and (TheUnit=1 or TheUnit=2)";
                        cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime11).JustDate, new MyDateTime(ref dateTime22).JustDate), cn);
                        cmd.CommandType = CommandType.Text;
                        x += ((double)ExecuteScalar(cmd));
                    }
                    catch { }

                } return x;
       
        }
        internal double GetAllAmountCSalesReturns(DateTime dateTime11, DateTime dateTime22)
        {
            double x = 0;
            string sqlo = @"SELECT  Sum((Amount/1000))FROM SalesReturns  where  left(AddedDate,10) BETWEEN  '{0}' and '{1}' and (TheUnit=0)";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime( ref dateTime11).JustDate, new MyDateTime(ref dateTime22).JustDate), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                   try
                   {  x = ((double)ExecuteScalar(cmd)); }
                   catch { }
                    try
                    {
                        sqlo = @"SELECT  Sum((Amount))FROM SalesReturns  where  left(AddedDate,10) BETWEEN  '{0}' and '{1}' and (TheUnit=1 or TheUnit=2)";
                        cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime11).JustDate, new MyDateTime(ref dateTime22).JustDate), cn);
                        cmd.CommandType = CommandType.Text;
                        x += ((double)ExecuteScalar(cmd));
                    }
                    catch { }

                } return x;
       
        }
        internal double GetAllAmountC(int typeid)
        {
            double x = 0;
                string sqlo = @"SELECT  Sum((Amount))FROM ClientDeals  where TypeId ={0} and (TheUnit=1 or TheUnit=2)";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    try
                    {
                        x = ((double)ExecuteScalar(cmd));
                    }
                    catch { }
                    try
                    {
                        sqlo = @"SELECT  Sum((Amount/1000))FROM ClientDeals  where TypeId ={0} and (TheUnit=0)";
                        cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                        cmd.CommandType = CommandType.Text;
                        x += ((double)ExecuteScalar(cmd));
                    }
                    catch { }
                    return x;
                }
            
            
        }
        internal double GetAllAmountCSalesReturns(int typeid)
        {
            double x = 0;
            string sqlo = @"SELECT  Sum((Amount))FROM SalesReturns  where TypeId ={0} and (TheUnit=1 or TheUnit=2)";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    try
                    {
                        x = ((double)ExecuteScalar(cmd));
                    }
                    catch { }
                    try
                    {
                        sqlo = @"SELECT  Sum((Amount/1000))FROM SalesReturns  where TypeId ={0} and (TheUnit=0)";
                        cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                        cmd.CommandType = CommandType.Text;
                        x += ((double)ExecuteScalar(cmd));
                    }
                    catch { }
                    return x;
                }
            
            
        }
        internal double GetAllAmountCSalesReturns(DateTime dateTime11)
        {
            try
            {
                string sqlo = @"SELECT  Sum((Amount/1000))FROM SalesReturns  where left(AddedDate,10)='{0}')";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime11).JustDate), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }
        internal double GetAllAmountC(DateTime dateTime11)
        {
            try
            {
                string sqlo = @"SELECT  Sum((Amount/1000))FROM ClientDeals  where  left(AddedDate,10)= '{0}')";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    //  OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime11).JustDate), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }
        internal double GetAllTotalPriceC(int typeid, DateTime dateTime1, DateTime dateTime2)
        {
                double x = 0;
                string sqlo = @"SELECT  Sum(((Amount/1000) * Price))FROM ClientDeals  where TypeId ={0} and (TheUnit=0) and left(AddedDate,10) BETWEEN '{1}' and '{2}'";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString(), new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    try
                    {
                        x = ((double)ExecuteScalar(cmd));
                    }
                    catch { }
                    try
                    {
                        sqlo = @"SELECT  Sum(((Amount) * Price))FROM ClientDeals  where TypeId ={0} and (TheUnit=1 or TheUnit=2) and left(AddedDate,10) BETWEEN '{1}' and '{2}'";
                        cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString(), new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate), cn);
                        cmd.CommandType = CommandType.Text;
                        x += ((double)ExecuteScalar(cmd));
                    }
                    catch { } 
                }
                return x;
            
        }
        internal double GetAllTotalPriceCSalesReturns(int typeid, DateTime dateTime1, DateTime dateTime2)
        {
                double x = 0;
                string sqlo = @"SELECT  Sum(((Amount/1000) * Price))FROM SalesReturns  where TypeId ={0} and (TheUnit=0) and left(AddedDate,10) BETWEEN '{1}' and '{2}'";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString(), new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    try
                    {
                        x = ((double)ExecuteScalar(cmd));
                    }
                    catch { }
                    try
                    {
                        sqlo = @"SELECT  Sum(((Amount) * Price))FROM SalesReturns  where TypeId ={0} and (TheUnit=1 or TheUnit=2) and left(AddedDate,10) BETWEEN '{1}' and '{2}'";
                        cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString(), new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate), cn);
                        cmd.CommandType = CommandType.Text;
                        x += ((double)ExecuteScalar(cmd));
                    }
                    catch { } 
                }
                return x;
            
        }
        internal double GetAllTotalPriceC(DateTime dateTime1)
        {
            try
            {
                string sqlo = @"SELECT  Sum(((Amount/1000) * Price))FROM ClientDeals  where left(AddedDate,10)='{0}'";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    //  OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }
        internal double GetAllTotalPriceCSalesReturns(DateTime dateTime1)
        {
            try
            {
                string sqlo = @"SELECT  Sum(((Amount/1000) * Price))FROM SalesReturns  where left(AddedDate,10)='{0}'";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    //  OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }
        internal double GetAllTotalPriceC(int typeid)
        {
            double x = 0;
                string sqlo = @"SELECT  Sum(((Amount) *  Price))FROM ClientDeals  where TypeId ={0} and (TheUnit=1 or TheUnit=2)";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    try { x = ((double)ExecuteScalar(cmd)); }
                    catch { }
                    try
                    {
                        sqlo = @"SELECT  Sum(((Amount/1000) *  Price))FROM ClientDeals  where TypeId ={0} and (TheUnit=0)";
                        cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                        cmd.CommandType = CommandType.Text;
                        x += ((double)ExecuteScalar(cmd));
                    }
                    catch { }

                } return x;
         
        }
        internal double GetAllTotalPriceCSalesReturns(int typeid)
        {
            double x = 0;
                string sqlo = @"SELECT  Sum(((Amount) *  Price))FROM SalesReturns  where TypeId ={0} and (TheUnit=1 or TheUnit=2)";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    try { x = ((double)ExecuteScalar(cmd)); }
                    catch { }
                    try
                    {
                        sqlo = @"SELECT  Sum(((Amount/1000) *  Price))FROM SalesReturns  where TypeId ={0} and (TheUnit=0)";
                        cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                        cmd.CommandType = CommandType.Text;
                        x += ((double)ExecuteScalar(cmd));
                    }
                    catch { }

                } return x;
         
        }
        internal double GetAllTotalPriceC(DateTime dateTime1, DateTime dateTime2)
        {
            double x = 0;
            string sqlo = @"SELECT  Sum(((Amount/1000) * Price))FROM ClientDeals  where  left(AddedDate,10) BETWEEN '{0}' and '{1}' and (TheUnit=0)";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {

                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();   try
                    {
                      x = ((double)ExecuteScalar(cmd));
                    }
                    catch { }
                    try
                    {
                        sqlo = @"SELECT  Sum(((Amount) * Price))FROM ClientDeals  where  left(AddedDate,10) BETWEEN '{0}' and '{1}' and (TheUnit=1 or TheUnit=2)";
                        cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate), cn);
                        cmd.CommandType = CommandType.Text;
                        x += ((double)ExecuteScalar(cmd));
                    }
                    catch { }

                } return x;
        }
        internal double GetAllTotalPriceCSalesReturns(DateTime dateTime1, DateTime dateTime2)
        {
            double x = 0;
            string sqlo = @"SELECT  Sum(((Amount/1000) * Price))FROM SalesReturns  where  left(AddedDate,10) BETWEEN '{0}' and '{1}' and (TheUnit=0)";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {

                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();   try
                    {
                      x = ((double)ExecuteScalar(cmd));
                    }
                    catch { }
                    try
                    {
                        sqlo = @"SELECT  Sum(((Amount) * Price))FROM SalesReturns  where left(AddedDate,10) BETWEEN '{0}' and '{1}' and (TheUnit=1 or TheUnit=2)";
                        cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate), cn);
                        cmd.CommandType = CommandType.Text;
                        x += ((double)ExecuteScalar(cmd));
                    }
                    catch { }

                } return x;
        }
        internal double GetAllPaidPriceCSalesReturns(int typeid, DateTime dateTime1, DateTime dateTime2)
        {
            try
            {
                string sqlo = @"SELECT  Sum((PaidMoney))FROM SalesReturns  where TypeId ={0} and left(AddedDate,10) BETWEEN '{1}' and '{2}'";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString(), new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }
        internal double GetAllPaidPriceC(int typeid, DateTime dateTime1, DateTime dateTime2)
        {
            try
            {
                string sqlo = @"SELECT  Sum((PaidMoney))FROM ClientDeals  where TypeId ={0} and left(AddedDate,10) BETWEEN '{1}' and '{2}'";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString(), new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }
        internal double GetAllPaidPriceC(DateTime dateTime1)
        {
            try
            {
                string sqlo = @"SELECT  Sum((PaidMoney))FROM ClientDeals  where left(AddedDate,10)='{0}')";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    //  OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }
        internal double GetAllPaidPriceCSalesReturns(DateTime dateTime1)
        {
            try
            {
                string sqlo = @"SELECT  Sum((PaidMoney))FROM SalesReturns  where left(AddedDate,10)='{0}')";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    //  OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }
        internal double GetAllPaidPriceC(int typeid)
        {
            try
            {
                string sqlo = @"SELECT  Sum((PaidMoney))FROM ClientDeals  where TypeId ={0}";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));

                }
            }
            catch { return 0; }
        }
        internal double GetAllPaidPriceCSalesReturns(int typeid)
        {
            try
            {
                string sqlo = @"SELECT  Sum((PaidMoney))FROM SalesReturns  where TypeId ={0}";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));

                }
            }
            catch { return 0; }
        }
        internal double GetAllPaidPriceC(DateTime dateTime1, DateTime dateTime2)
        {
            try
            {
                string sqlo = @"SELECT  Sum((PaidMoney))FROM ClientDeals  where left(AddedDate,10) BETWEEN '{0}' and '{1}'";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    //  OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }
        internal double GetAllPaidPriceCSalesReturns(DateTime dateTime1, DateTime dateTime2)
        {
            try
            {
                string sqlo = @"SELECT  Sum((PaidMoney))FROM SalesReturns  where  left(AddedDate,10) BETWEEN '{0}' and '{1}'";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    //  OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }      
        internal double GetAllProfitSalesReturns(int typeid, DateTime dateTime1, DateTime dateTime2)
        {
            TypeDetails td = GetTypeByID(typeid); double x = 0;
                double typprc = td.BusinessPrice;
                double prc = td.ClientPrice;
                string sqlo = @"SELECT  (Sum((Amount/1000) * Price))-(Sum((Amount/1000) *  BusinessPrice)) FROM SalesReturns  where (TypeId={4} and  (TheUnit=0)and (left(AddedDate,10) BETWEEN '{0}' and  '{1}'))";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    OleDbCommand cmd;
                    cn.Open();
                    try
                    {
                       cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate, typprc, prc, typeid), cn);
                        cmd.CommandType = CommandType.Text;
                        x = ((double)ExecuteScalar(cmd));
                    }
                    catch { }
                    try
                    {
                        sqlo = @"SELECT  (Sum((Amount) * Price))-(Sum((Amount) *  BusinessPrice)) FROM SalesReturns  where (TypeId={4} and  (TheUnit=1 or TheUnit=2)and (left(AddedDate,10) BETWEEN '{0}' and  '{1}'))";
                        cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate, typprc, prc, typeid), cn);
                        cmd.CommandType = CommandType.Text;
                        x += ((double)ExecuteScalar(cmd));
                    }
                    catch { }
                    return x;
                } 
         
        }
        internal double GetAllProfit(int typeid, DateTime dateTime1, DateTime dateTime2)
        {
            TypeDetails td = GetTypeByID(typeid); double x = 0;
                double typprc = td.BusinessPrice;
                double prc = td.ClientPrice;
                string sqlo = @"SELECT  (Sum((Amount/1000) * Price))-(Sum((Amount/1000) *  BusinessPrice)) FROM ClientDeals  where (TypeId={4} and  (TheUnit=0)and (left(AddedDate,10) BETWEEN '{0}' and  '{1}'))";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    OleDbCommand cmd;
                    cn.Open();
                    try
                    {
                       cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate, typprc, prc, typeid), cn);
                        cmd.CommandType = CommandType.Text;
                        x = ((double)ExecuteScalar(cmd));
                    }
                    catch { }
                    try
                    {
                        sqlo = @"SELECT  (Sum((Amount) * Price))-(Sum((Amount) * BusinessPrice)) FROM ClientDeals  where (TypeId={4} and  (TheUnit=1 or TheUnit=2)and (left(AddedDate,10) BETWEEN '{0}' and '{1}'))"; 
                        cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate, typprc, prc, typeid), cn);
                        cmd.CommandType = CommandType.Text;
                        x += ((double)ExecuteScalar(cmd));
                    }
                    catch { }
                    return x;
                } 
         
        }
        internal double GetAllProfit(DateTime dateTime1)
        {
            try
            {
  string sqlo = @"SELECT (Sum((ClientDeals.Price*(ClientDeals.Amount/1000)))-Sum((Types.BusinessPrice*(ClientDeals.Amount/1000))))  
FROM (SELECT *  FROM ClientDeals INNER JOIN Types ON ClientDeals.TypeId =Types.Id) where  left(ClientDeals.AddedDate,10) ='{0}'";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    //  OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }
        internal double GetAllProfitSalesReturns(DateTime dateTime1)
        {
            try
            {
  string sqlo = @"SELECT (Sum((SalesReturns.Price*(SalesReturns.Amount/1000)))-Sum((Types.BusinessPrice*(SalesReturns.Amount/1000))))  
FROM (SELECT *  FROM SalesReturns INNER JOIN Types ON SalesReturns.TypeId =Types.Id) where left(SalesReturns.AddedDate,10) like '{0}'";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    //  OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, typeid.ToString()), cn);
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate), cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    return ((double)ExecuteScalar(cmd));
                }
            }
            catch { return 0; }
        }
        internal double GetAllProfit(int typeid)
        {
                double x = 0;  
                TypeDetails td = GetTypeByID(typeid);
                double typprc = td.BusinessPrice;
                double prc = td.ClientPrice;
                string sqlo = @"SELECT  (Sum((Amount/1000) * Price))-(Sum((Amount/1000) * BusinessPrice)) FROM ClientDeals  where (TypeId={2} and (TheUnit=0))";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo,prc,typprc, typeid), cn);
                    cmd.CommandType = CommandType.Text; cn.Open();
                    try
                    {
                        x = (double)ExecuteScalar(cmd);
                    }
                    catch { }
                    try
                    {
                        sqlo = @"SELECT  (Sum((Amount) * Price))-(Sum((Amount) * BusinessPrice)) FROM ClientDeals  where (TypeId={2} and (TheUnit=2 or TheUnit=1 ))";
                        cmd = new OleDbCommand(string.Format(sqlo, prc, typprc, typeid), cn);
                        cmd.CommandType = CommandType.Text;
                        //System.Windows.Forms.MessageBox.Show(x.ToString()); 
                        x += (double)ExecuteScalar(cmd);

                    }
                    catch { /*System.Windows.Forms.MessageBox.Show(ex.ToString());*/ }
                        return x;

                }
        
        }
        internal double GetAllProfitSalesReturns(int typeid)
        {
                double x = 0;  
                TypeDetails td = GetTypeByID(typeid);
                double typprc = td.BusinessPrice;
                double prc = td.ClientPrice;
                string sqlo = @"SELECT  (Sum((Amount/1000) * Price))-(Sum((Amount/1000) * BusinessPrice)) FROM SalesReturns  where (TypeId={2} and (TheUnit=0))";
                using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
                {
                    OleDbCommand cmd = new OleDbCommand(string.Format(sqlo,prc,typprc, typeid), cn);
                    cmd.CommandType = CommandType.Text; cn.Open();
                    try
                    {
                        x = (double)ExecuteScalar(cmd);
                    }
                    catch { }
                    try
                    {
                        sqlo = @"SELECT  (Sum((Amount) * Price))-(Sum((Amount) * BusinessPrice)) FROM SalesReturns  where (TypeId={2} and (TheUnit=2 or TheUnit=1 ))";
                        cmd = new OleDbCommand(string.Format(sqlo, prc, typprc, typeid), cn);
                        cmd.CommandType = CommandType.Text;
                        //System.Windows.Forms.MessageBox.Show(x.ToString()); 
                        x += (double)ExecuteScalar(cmd);

                    }
                    catch { /*System.Windows.Forms.MessageBox.Show(ex.ToString());*/ }
                        return x;

                }
        
        }
        internal double GetAllProfit(DateTime dateTime1, DateTime dateTime2)
        {
            double x = 0;
            string sqlo = @"SELECT (Sum((ClientDeals.Price*(ClientDeals.Amount/1000)))-Sum((ClientDeals.BusinessPrice*(ClientDeals.Amount/1000))))  
  FROM ClientDeals  where  ((left(ClientDeals.AddedDate,10) BETWEEN  '{0}'  and  '{1}' ) and (ClientDeals.TheUnit=0))";
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate), cn); 
                cmd.CommandType = CommandType.Text; cn.Open();
                try
                {
                    x = (double)ExecuteScalar(cmd);
                }
                catch { }
                try
                {
                    sqlo = @"SELECT (Sum((ClientDeals.Price*(ClientDeals.Amount)))-Sum((BusinessPrice*(ClientDeals.Amount))))  
FROM ClientDeals  where  ((left(ClientDeals.AddedDate,10) BETWEEN  '{0}'  and  '{1}')  and (ClientDeals.TheUnit=2 or ClientDeals.TheUnit=1))";
                    cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate), cn); 
                    cmd.CommandType = CommandType.Text;
                    //System.Windows.Forms.MessageBox.Show(x.ToString());
                    x += (double)ExecuteScalar(cmd);
                }
                catch  { /*System.Windows.Forms.MessageBox.Show(ex.ToString());*/ }
                return x;

            }
        }
        internal double GetAllProfitSalesReturns(DateTime dateTime1, DateTime dateTime2)
        {
            double x = 0;
            string sqlo = @"SELECT (Sum((SalesReturns.Price*(SalesReturns.Amount/1000)))-Sum((SalesReturns.BusinessPrice*(SalesReturns.Amount/1000))))  
  FROM SalesReturns  where  ((left(SalesReturns.AddedDate,10) BETWEEN  '{0}'  and  '{1}' ) and (SalesReturns.TheUnit=0))";
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate), cn);
                //System.Windows.Forms.MessageBox.Show(cmd.CommandText);
                cmd.CommandType = CommandType.Text; cn.Open();
                try
                {
                    x = (double)ExecuteScalar(cmd);
                }
                catch { }
                try
                {
                   sqlo = @"SELECT (Sum((SalesReturns.Price*(SalesReturns.Amount)))-Sum((SalesReturns.BusinessPrice*(SalesReturns.Amount))))  
  FROM SalesReturns  where  ((left(SalesReturns.AddedDate,10) BETWEEN  '{0}'  and  '{1}' ) and (SalesReturns.TheUnit=2 or SalesReturns.TheUnit=1))";
                    cmd = new OleDbCommand(string.Format(sqlo, new MyDateTime(ref dateTime1).JustDate, new MyDateTime(ref dateTime2).JustDate), cn); 
                    cmd.CommandType = CommandType.Text;
                  //  System.Windows.Forms.MessageBox.Show(cmd.CommandText.ToString());
                    x += (double)ExecuteScalar(cmd);
                }
                catch  { /*System.Windows.Forms.MessageBox.Show(ex.ToString());*/ }
                return x;

            }
        }
        internal List<ArchivesDetails> GetAllArchives(archivesTypes archivesTypeso)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                string sql="select * from Archives";
                if (archivesTypeso == archivesTypes.In) sql += " where BigType=0"; else sql += " where BigType=1";
                sql += " order by Id desc";
                OleDbCommand cmd = new OleDbCommand(sql, cn);
                try
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                }
                catch {  }
                return GetArchivesCollectionFromReader(ExecuteReader(cmd));
            }
        }
        internal bool DeleteBusinesDealByIDman(int ido)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("delete from BusinessDeals where ManId =" + ido.ToString(), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                int ret = ExuteNonQuery(cmd);
                cmd = new OleDbCommand("delete from LastCompanyAccount where ManId =" + ido.ToString(), cn);
                cmd.CommandType = CommandType.Text;
                ret = ExuteNonQuery(cmd);
                return (ret == 1);
            }
        }
        internal bool DeleteBusinesReturnsByIDman(int ido)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("delete from BuyReturns where ManId =" + ido.ToString(), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                int ret = ExuteNonQuery(cmd);
                return (ret == 1);
            }
        }
        internal bool DeleteClientDealByIDclient(int p)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("delete from ClientDeals where ClientId =" + p.ToString(), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                int ret = ExuteNonQuery(cmd);
                cmd = new OleDbCommand("delete from LastClientsAccount where ClientId =" + p.ToString(), cn);
                cmd.CommandType = CommandType.Text;
                ret = ExuteNonQuery(cmd);
                return (ret == 1);
            }
        }
        internal bool DeleteClientDealByIDclientSalesReturns(int p)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("delete from SalesReturns where ClientId =" + p.ToString(), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                int ret = ExuteNonQuery(cmd);
                return (ret == 1);
            }
        }
        internal object DeleteAllBusinessDeals()
         {
             using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
             {
                 OleDbCommand cmd = new OleDbCommand("delete from BusinessDeals", cn);
                 cmd.CommandType = CommandType.Text;
                 cn.Open();
                 int ret = ExuteNonQuery(cmd);
                 return (ret == 1);
             }
         }
        internal object DeleteAllBusinesReturns()
         {
             using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
             {
                 OleDbCommand cmd = new OleDbCommand("delete from BuyReturns", cn);
                 cmd.CommandType = CommandType.Text;
                 cn.Open();
                 int ret = ExuteNonQuery(cmd);
                 return (ret == 1);
             }
         }
        internal object DeleteAllClientDeals()
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("delete from ClientDeals", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                int ret = ExuteNonQuery(cmd);
                return (ret == 1);
            }
        }
        internal object DeleteAllClientDealsSalesReturns()
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("delete from SalesReturns", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                int ret = ExuteNonQuery(cmd);
                return (ret == 1);
            }
        }
        internal  void DeletAll()
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("delete from Types", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                int ret = ExuteNonQuery(cmd);
                  cmd = new OleDbCommand("delete from Companys", cn);
                cmd.CommandType = CommandType.Text;

                  ret = ExuteNonQuery(cmd);
                  cmd = new OleDbCommand("delete from Clients", cn);
                cmd.CommandType = CommandType.Text;
   
                  ret = ExuteNonQuery(cmd);

                  cmd = new OleDbCommand("delete from LastCompanyAccount", cn);
                  cmd.CommandType = CommandType.Text;

                  ret = ExuteNonQuery(cmd);
                  cmd = new OleDbCommand("delete from LastClientsAccount", cn);
                  cmd.CommandType = CommandType.Text;

                  ret = ExuteNonQuery(cmd);
               
            }
        }
        public override List<LastCompanyAccountDetails> GetAllLastCompanytAccount(int ID)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(string.Format("select * from LastCompanyAccount where ManId={0} order by Id desc",ID.ToString()), cn);
                try
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                }
                catch {  }
                return GetLastCompanytAccountCollectionFromReader(ExecuteReader(cmd));
            }   
        }
        public override int InserLastCompanytAccount(LastCompanyAccountDetails CompanytAccount)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(string.Format(@"INSERT INTO LastCompanyAccount(ManId,Can,Numbero,Sar,AddedDate) VALUES ({0},{1},{2},{3},'{4}')"
, CompanytAccount.ManId.ToString(), CompanytAccount.Can.ToString(), CompanytAccount.Number.ToString(), CompanytAccount.Sar.ToString(), CompanytAccount.AddedDate.ToStringToinsert()), cn);
                cmd.CommandType = CommandType.Text;
          // System.Windows.Forms.MessageBox.Show(cmd.CommandText);
                cn.Open();
                int ret = ExuteNonQuery(cmd);
                return ret;
            }   
        }
        public override bool DeleteLastCompanytAccount(int Id)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("delete from LastCompanyAccount where ManId =" + Id.ToString(), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                int ret = ExuteNonQuery(cmd);
                return (ret > 0);
            }
        }
        public override List<LastClientsAccountDetails> GetAllLastClienttAccount(int ID)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(string.Format("select * from LastClientsAccount where ClientId={0} order by Id desc", ID.ToString()), cn);
                try
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                }
                catch {  }
                return GetLastClientAccountCollectionFromReader(ExecuteReader(cmd));
            }
        }
        public override int InserLastClienttAccount(LastClientsAccountDetails CompanytAccount)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(string.Format(@"INSERT INTO LastClientsAccount(ClientId,Can,Numbero,Sar,AddedDate) VALUES ({0},{1},{2},{3},'{4}')"
, CompanytAccount.ClientId.ToString(), CompanytAccount.Can.ToString(), CompanytAccount.Number.ToString(), CompanytAccount.Sar.ToString(), CompanytAccount.AddedDate.ToStringToinsert()), cn);
                cmd.CommandType = CommandType.Text;
               //  System.Windows.Forms.MessageBox.Show(cmd.CommandText);
                cn.Open();
                int ret = ExuteNonQuery(cmd);
                return ret;
            } 
        }
        public override bool DeleteLastClientAccount(int Id)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand("delete from LastClientsAccount where ClientId =" + Id.ToString(), cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                int ret = ExuteNonQuery(cmd);
                return (ret> 0);
            }
        }
        internal void InsertGroupDeal(List<ClientDeal> alcll)
        {
            double stramnt = 0;
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                cn.Open();
                foreach (BLL.ClientDeal curcl in alcll)
                {
                    curcl.PaidMoney = curcl.Amount * curcl.Price;
                    curcl.StayingPrice = 0;
                    curcl.InsertClientDeal(true);
                    stramnt = curcl.Amount;
                    if (curcl.TheUnit == TheUnito.Gram) stramnt = curcl.Amount / 1000;
                    BLL.Store.InsertStoreFromClient(curcl.TypeId, stramnt, DateTime.Now, curcl.TypeName);
                }
            }
        }
        internal void InsertGroup(List<BusinesDeal> alcll)
        {
           using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
              cn.Open();
            foreach (BLL.BusinesDeal curcl in alcll)
            {
                curcl.PaidMoney = curcl.ToTalPrice;
                this.InsertBusinesDeal(curcl,  cn);
                this.InsertStoreFromCompany(curcl, cn);

            }
            }
           BllGlobal.UpdateAllStore();

        }
        /// <summary>
        /// للزيادة من التجار 
        /// </summary>
        private int  InsertStoreFromCompany(BusinesDeal StoreDetails, OleDbConnection cn)
        {
                int ret = 0;
                StoreDetails tmp = null; tmp = this.GetStoreByTypeID(StoreDetails.TypeId);
                
                if (tmp != null)
                {
                    //update
                    OleDbCommand cmd = new OleDbCommand(@"UPDATE Store  SET TypeId ="
                + StoreDetails.TypeId.ToString()
                + ",Amount=" + (tmp.Amount + StoreDetails.Amount).ToString()
               + ",AddedDateCompany='" + DateTime.Now + "' WHERE Id=" + tmp.ID.ToString(), cn);
                    
                    cmd.CommandType = CommandType.Text;
                    
                     try
                    {
                        ret = ExuteNonQuery(cmd);
                    }
                    finally { }
                  
                }
                else
                {
                    //insert
                    OleDbCommand cmd = new OleDbCommand(string.Format(@"INSERT INTO  Store 
(TypeId,Amount,AddedDateCompany,AddedDateClient,TypeName)VALUES
( {0},{1},'{2}', '{3}', '{4}'  )"
, StoreDetails.TypeId.ToString(),
StoreDetails.Amount.ToString(), DateTime.Now, DateTime.Now, StoreDetails.TypeName), cn);
                    cmd.CommandType = CommandType.Text;
                      ret = ExuteNonQuery(cmd); 
                }
                return ret;
        }

        internal void  InsertSalesReturns(List<SalesReturns> alcll)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                cn.Open();
                foreach (SalesReturns sr in alcll)
                {
                    this.InsertSalesReturns(sr,cn);
                    this.InsertStoreFromClient(sr, cn);
                }
            } BllGlobal.UpdateAllStore();
        }

        private void InsertSalesReturns(SalesReturns ClientDealDetails, OleDbConnection cn)
        {
                byte x = 1;
                switch (ClientDealDetails.TheUnit)
                {
                    case TheUnito.Gram: x = 0; break;
                    case TheUnito.Kilo: x = 1; break;
                    case TheUnito.Piece: x = 2; break;
                }
                OleDbCommand cmd = new OleDbCommand(string.Format(@"INSERT INTO  SalesReturns
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



        internal int InsertBusinesReturns(List<BusinesReturns> alcll)
        {
            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                cn.Open();
                foreach (BLL.BusinesReturns curcl in alcll)
                {
                    curcl.PaidMoney = curcl.ToTalPrice;
                   this.InsertBusinesReturns(curcl,cn);
                   this.InsertStoreFromCompany(curcl, cn);
                }
            }
            return 1;
        }
    }
}
 
