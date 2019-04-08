using System;
using System.Collections.Generic;

using System.Text;
using WeightsOrganizer.DAL;

namespace WeightsOrganizer.BLL
{
    [Serializable]
    class Store
    {
        private static RealProvider myRealProvider = new RealProvider();


        public DateTime OrAddedDateCompany
        {
            get { return AddedDateCompany.MyDateTimeasDateTime; }
        }
        public DateTime OrAddedDateClient
        {
           get { return AddedDateClient.MyDateTimeasDateTime; }
        }
        protected int _id = 0;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private double _Amount = 0;
        public double Amount
        {
            get
            {
                return _Amount;
            }
            set
            {
                _Amount = value;
            }
        }
        protected int _TypeId = 0;
        public int TypeId
        {
            get { return _TypeId; }
            set { _TypeId = value; }
        }
        protected string _TypeName = null;
        public string  TypeName
        {
            set{ _TypeName=value;}
            get {
                if ((_TypeName == null) && TypeId > 0) return "الصنف";
                return _TypeName;
                 }
        }
        protected MyDateTime _AddedDateCompany = MyDateTime.Now;
        public MyDateTime AddedDateCompany
        {
            get { return _AddedDateCompany; }
            set
            {
                if (value == null) value = _AddedDateCompany;
                _AddedDateCompany = value;
            }
        }
        protected MyDateTime _AddedDateClient = MyDateTime.Now;
        public MyDateTime AddedDateClient
        {
            get { return _AddedDateClient; }
            set
            {
                if (value == null) value = _AddedDateClient;
                _AddedDateClient = value;
            }
        }
        public Store() { }
        public Store(int id, int typeid, double amount, MyDateTime addedDatecompany, MyDateTime addedDateclient,string typename)
        {
            this.ID = id;
            this.TypeId = typeid;
            this.Amount = amount;
            this.AddedDateClient = addedDateclient;
            this.AddedDateCompany = addedDatecompany;
            this.TypeName = typename;
        }
        /// Real Business Logic layer begin Here!
        public static List<Store> GetAllStore()
        {
            return GetStoreFromStoreDetails(myRealProvider.GetAllStores());
        }
        public static Store GetStoreByID(int ido)
        {
            StoreDetails tbdt = myRealProvider.GetStoreByID(ido);
            MyDateTime x1 = new MyDateTime(tbdt.AddedDateCompany);
            MyDateTime x2 = new MyDateTime(tbdt.AddedDateClient);
            if (tbdt != null) return new Store(tbdt.ID, tbdt.TypeId , tbdt.Amount,x1, x2,tbdt.TypeName); else return null;
        }
        public static Store GetStoreByTypeID(int typid)
        {
          DAL.StoreDetails strdet=  myRealProvider.GetStoreByTypeID(typid);
          if (strdet == null) return null;
          return new Store(strdet.ID, strdet.TypeId, strdet.Amount,new MyDateTime( strdet.AddedDateClient),new  MyDateTime( strdet.AddedDateClient),strdet.TypeName);
        }
        public Store GetStoreByID()
        {
            return Store.GetStoreByID(this.ID);
        }
        public static bool DeleteStore(int ido)
        {
            bool x = myRealProvider.DeleteStore(ido);
            BllGlobal.UpdateAllStore();
            return x;
        }
        public static int InsertStoreFromCompany(int typeid, double amount, DateTime addedDatecompany, string typename)
        {
            StoreDetails tb1 = new StoreDetails(0, typeid, amount, addedDatecompany, addedDatecompany, typename);
            int x = myRealProvider.InsertStoreFromCompany(tb1);
            BllGlobal.UpdateAllStore();
            return x;
        }
 
        public static int InsertStoreFromCompany(int typeid, double amount, DateTime addedDatecompany, string typename,string  UpgradeUi)
        {
            StoreDetails tb1 = new StoreDetails(0, typeid, amount, addedDatecompany, addedDatecompany, typename);
            int x = myRealProvider.InsertStoreFromCompany(tb1);
          if(UpgradeUi.Length>20)  WeightsOrganizer.BLL.BllGlobal.UpdateAllStore();
            return x;
        }
        public static int InsertStoreFromCompany(int typeid, double amount, DateTime addedDatecompany, string typename,bool decrment)
        {
            StoreDetails tb1 = new StoreDetails(0, typeid, amount, addedDatecompany, addedDatecompany, typename);
            int x = myRealProvider.InsertStoreFromCompany(tb1, decrment);
            BllGlobal.UpdateAllStore();
            return x;
        }
        public static int InsertStoreFromClient(int typeid, double amount, DateTime addedDateclient, string typename)
        {
            StoreDetails tb1 = new StoreDetails(0, typeid, amount, addedDateclient, addedDateclient, typename);
            int x = myRealProvider.InsertStoreFromClient(tb1);
            WeightsOrganizer.BLL.BllGlobal.UpdateAllStore();
            return x;
        }
        public static int InsertStoreFromClient(int typeid, double amount, DateTime addedDateclient, string typename, bool addthstore, bool opencon)
        {
            StoreDetails tb1 = new StoreDetails(0, typeid, amount, addedDateclient, addedDateclient, typename);
            int x = myRealProvider.InsertStoreFromClient(tb1,true,true);
            WeightsOrganizer.BLL.BllGlobal.UpdateAllStore();
            return x;
        }

        /// <summary>
        /// البضاعة المرتججعة
        /// </summary>
        /// <returns></returns>
        public static int InsertStoreFromClient(int typeid, double amount, DateTime addedDateclient, string typename,bool addthstore)
        {
            StoreDetails tb1 = new StoreDetails(0, typeid, amount, addedDateclient, addedDateclient, typename);
            int x = myRealProvider.InsertStoreFromClient(tb1, addthstore);
            WeightsOrganizer.BLL.BllGlobal.UpdateAllStore();
            return x;
        }
        public static List<Store> Search(string key)
        {
            return Store.GetStoreFromStoreDetails(myRealProvider.SearchStore(key));

        }
        public static List<Store> Search(int typid)
        {
            return Store.GetStoreFromStoreDetails(myRealProvider.SearchStore(typid));
        }
        private static List<Store> GetStoreFromStoreDetails(List<StoreDetails> list)
        {
            List<Store> newlist = new List<Store>();
            foreach (StoreDetails tbdt in list)
            {
            MyDateTime x=    new MyDateTime( tbdt.AddedDateCompany);
                MyDateTime xx=    new MyDateTime( tbdt.AddedDateClient);
                newlist.Add(new Store(tbdt.ID, tbdt.TypeId, tbdt.Amount, x,xx,tbdt.TypeName));
            }
            return newlist;
        }
        internal static void UpdateTypNamesinstore(int typeid,string newname)
        {
            myRealProvider.UpdateTypNamesinstore( typeid,newname);
        }

        internal static void InsertStoreFromCompany(int p, double p_2, DateTime dateTime, string p_4, System.Data.OleDb.OleDbConnection cn)
        {    
        }
    }
}
