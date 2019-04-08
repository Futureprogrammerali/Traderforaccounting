using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WeightsOrganizer.BLL
{
    [Serializable]
    static class SalePoint
    {
      /// <summary>
      /// Get Or Set The Safka
      /// </summary>
        internal static List<BLL.ClientDeal> ALL
        {
            get { return all; }
            set { all = value; _Price = 0; foreach (ClientDeal c in all) _Price += c.ToTalPrice; }
        }
        private static DAL.SalePointDal SalePointDal = new WeightsOrganizer.DAL.SalePointDal();
        private static List<BLL.ClientDeal> all = new List<ClientDeal>();
        private static double _Price = 0;
        internal static object Add(BLL.ClientDeal curcl)
        {
            MyAdd(curcl);
            _Price += curcl.ToTalPrice;
            return all;
        }
        private static void MyAdd(ClientDeal cl)
        {    
            List<BLL.ClientDeal> allz = new List<WeightsOrganizer.BLL.ClientDeal>();
            allz = all;
            bool s = false;
            if (allz.Count > 0)
            {
                foreach (BLL.ClientDeal bd in allz)
                {
                    if ((bd.TypeId == cl.TypeId) && (bd.TheUnit == cl.TheUnit))
                    {
                        bd.Amount += cl.Amount; s = false; 
                        break;
                    }
                    else { s = true; }
                }
                if (s) { all.Add(cl);   }
            }
            else
            {
                all.Add(cl); 
            }
        }
        internal static void SaleNow(double myprice)
        {
           //MessageBox.Show("price param "+myprice.ToString());
            bool x = false;
            x = !(all[0].ClientId == Globals.Globals.UnknownClient);
            ///عملية الادخال
            SalePointDal.InsertClientDeal(all, x,Price - myprice);
            EMpty();
            BllGlobal.UpdateAllStore();
            BllGlobal.UpdateAllClients();
        }

        public static void EMpty()
        {
            all = new List<ClientDeal>();
            _Price = 0;
        }
        internal static bool ISinStore(int typeid, int amnt)
        {
            DAL.StoreDetails teststore = SalePointDal.GetStoreByTypeID(typeid);
            if (teststore != null)
            {
                if ((teststore.Amount < amnt)) { MessageBox.Show(" لا تتوفر هذه الكمية من الصنف  " + teststore.TypeName, "الكميات المتوفرة-المخزن", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
            }
            else
            {
                MessageBox.Show(" صنف غير موجود بالمخزن", "الكميات المتوفرة-المخزن", MessageBoxButtons.OK, MessageBoxIcon.Information); return false;
            }
            return true;
        }
        internal static object Delete(int idtype, TheUnito unet ,double clpric)
        {
            _Price -= clpric;
            MyDelete(idtype, unet);
            return all;
        }
        private static void MyDelete(int idtype, TheUnito unet)
        {
            List<BLL.ClientDeal> allz = new List<WeightsOrganizer.BLL.ClientDeal>();
            foreach (BLL.ClientDeal bd in all)
            {
                if ((bd.TypeId == idtype) && (bd.TheUnit == unet))
                {
                         
                }
                else
                {
                    allz.Add(bd);
                }
            }
            all = allz;

        }
        internal static double Price
        {
            get
            {
              
                return _Price; }
        }
        
        internal static void WriteSerolizeMe ( )
        {
            if (all.Count > 0)
            {
                try
                {
                   
                    Stream s = File.Open(@"FutureProgrammer.dat", FileMode.Create);
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(s, all);
                    s.Close();
                }
                catch { }
            }
           
        }
        internal static List<BLL.ClientDeal> ReadSerolizeMe()
        {
            List<BLL.ClientDeal> Thiso = new List<ClientDeal>();
            try
            {
                Stream s = File.Open(@"FutureProgrammer.dat", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                object o = bf.Deserialize(s);
                 Thiso = o as List<BLL.ClientDeal>;
            }
            catch { MessageBox.Show("عذرا لم أستطيع استرداد الفاتورة");}
            return Thiso;
        }



        internal static object Add(int _idtype)
        {
            double pr = 0;
            foreach (BLL.ClientDeal cl in all)
            {
                if (cl.TypeId == _idtype) {
                    cl.Amount++;
                    pr= cl.Price;
                   _Price += pr ;
                }
            }
            return all;
        }

        internal static object Delete(int _idtype)
        {
            double pr = 0;
            foreach (BLL.ClientDeal cl in all)
            {
                if (cl.TypeId == _idtype)
                {
                    if (cl.Amount>1)
                    {
                        cl.Amount--;
                        pr = cl.Price;
                        _Price -= pr;
                    }
                }
            }
            return all;
        }
    }
}
