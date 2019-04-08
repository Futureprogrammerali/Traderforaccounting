using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;

namespace WeightsOrganizer
{
    class ExportAndImportDbaseAsFile
    {
        public static bool done = true;
        string _source = ""; string _goal = "";
        FileStream fs, rfs = null;
        BinaryReader SR = null;
        byte[] allbyte = null;
        byte[] bytes = null;
        public ExportAndImportDbaseAsFile(string source, string goal)
        {
            this._source = source;
            this._goal = goal;
        }
        public bool is_done
        {
            get
            {
                return done;
            }
        }

        [STAThread]
        private byte[] get_bytes_from_file()
        {
            if (File.Exists(this._source) == true)
            {
                try
                {
                    fs = new FileStream(_source, FileMode.Open, FileAccess.Read);
                    SR = new BinaryReader(fs);
                    bytes = new byte[fs.Length];
                    bytes = SR.ReadBytes((int)fs.Length);

                }
                catch
                {
                    if (SR != null) SR.Close();
                    if (fs != null) fs.Dispose();
                }
                if (SR != null) SR.Close();
                if (fs != null) fs.Dispose();
            }
            else
            {
                Console.Beep(400, 400); Console.Beep(400, 500);
            }

            return bytes;
        }
        [STAThread]
        public void Copy()
        {
            allbyte = this.get_bytes_from_file();
            done = false;
            try
            {
                rfs = new FileStream(_goal, FileMode.Create, FileAccess.Write);
                for (int i = 0; i < allbyte.Length; i++)
                {
                    byte b = allbyte[i];
                    rfs.WriteByte(b);///ربع ميغا
                    if ((i % 262144) == 0)
                    {
                    Thread.Sleep(2);
                    }


                }
                done = true;
            }
            catch
            {
                return;
            }

            finally
            {
                if (rfs != null) rfs.Dispose();
            }
        }
        [STAThread]
        ~ExportAndImportDbaseAsFile()
        {
            if (fs != null) fs.Dispose();
        }
    }
    class ReadBasicInfo
    {
        public static bool done = true;
        string path = "";
        public ReadBasicInfo(string pth)
        {
            path = pth;
        }

        public void Read()
        {
            done = false;
            List<BLL.Types> Typo;
            List<BLL.Client> Clo;
            List<BLL.Company> Como;
            //List<BLL.Store> Stro;
            Globals.Globals.SetGlobalizationCulture(WeightsOrganizer.Globals.Globals.CultureInfoType.ArabicSyria);

            Stream s; BinaryFormatter bf;

            //Cleint  Compay   Store
            s = File.Open(path + @"\Compay.dat", FileMode.Open);
            bf = new BinaryFormatter();
            Como = (List<BLL.Company>)bf.Deserialize(s);

            foreach (BLL.Company t in Como)
            {
                t.InsertCompany();
            }

            s = File.Open(path + @"\Type.dat", FileMode.Open);
            bf = new BinaryFormatter();
            Typo = (List<BLL.Types>)bf.Deserialize(s);
            foreach (BLL.Types t in Typo)
            {
                t.InsertType();
            }


            s = File.Open(path + @"\Cleint.dat", FileMode.Open);
            bf = new BinaryFormatter();
            Clo = (List<BLL.Client>)bf.Deserialize(s);
            foreach (BLL.Client t in Clo)
            {
                t.InsertClient();
            }

            //s = File.Open(path + @"\Store.dat", FileMode.Open);
            //bf = new BinaryFormatter();
            //Stro = (List<BLL.Store>)bf.Deserialize(s);
            //foreach (BLL.Store t in Stro)
            //{                    
            //    BLL.Store.InsertStoreFromCompany(t.TypeId, t.Amount, t.OrAddedDateCompany, t.TypeName,"UpgradeUi");
            //    Thread.Sleep(5);
            //}
            done = true;
        }
    }
}
