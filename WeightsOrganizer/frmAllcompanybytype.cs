using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer
{
     public partial class frmAllcompanybytype : WeightsOrganizer.FrmMain
    {
         List<BLL.Company> Allcom = null;
         int _idtype = -1;
        public frmAllcompanybytype(int idtype)
        {
            InitializeComponent();
            this.isFrmDetails = true;
            _idtype = idtype;
            string allo = BLL.Types.GetTypeByID(idtype).AllCompanyId;

            combotypes.DataSource = BLL.BllGlobal.alltypes;
            combocompany.DataSource = BLL.BllGlobal.allcomps;
            combotypes.DisplayMember = "Name";
            combocompany.DisplayMember = "Name";
            combotypes.ValueMember = "ID";
            combocompany.ValueMember = "ID";
            combotypes.SelectedValue = idtype;
            combocompany.SelectedIndex = -1; combocompany.Text = "....";
          ///  MessageBox.Show(allo.Length.ToString());
            if ((!string.IsNullOrEmpty(allo)) &&(allo.Length!=0)&&(allo!=" "))
            {
                string[] all = allo.Split(',');
                Allcom = new List<WeightsOrganizer.BLL.Company>();
                foreach (string s in all)
                {
                    Allcom.Add(BLL.Company.GetCompanyByID(int.Parse(s)));
                }
            }
            else
            {
                Allcom = new List<WeightsOrganizer.BLL.Company>();
            }
            dataGridView1.DataSource=Allcom;
        }

   

        private void frmAllcompanybytype_Load(object sender, EventArgs e)
        {
            
        }

        private void combotypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string allo = BLL.Types.GetTypeByID(int.Parse(combotypes.SelectedValue.ToString())).AllCompanyId;
                _idtype = int.Parse(combotypes.SelectedValue.ToString());
                if ((!string.IsNullOrEmpty(allo)) && (allo.Length != 0) && (allo != " "))
                {
                    string[] all = allo.Split(',');
                    Allcom = new List<WeightsOrganizer.BLL.Company>();
                    foreach (string s in all)
                    {
                        Allcom.Add(BLL.Company.GetCompanyByID(int.Parse(s)));
                    }
                }
                else
                {
                    Allcom = new List<WeightsOrganizer.BLL.Company>();
                }
                dataGridView1.DataSource = Allcom;
            }
            catch { }
        }
        List<BLL.Company> Allcom2 = null;
        private void button1_Click(object sender, EventArgs e)
        {
            if (combocompany.SelectedIndex == -1) return;
            bool her = false;
            Allcom2 = new List<WeightsOrganizer.BLL.Company>();
            BLL.Company cm = BLL.Company.GetCompanyByID(int.Parse(combocompany.SelectedValue.ToString()));
            if (Allcom.Count > 0)
            {
                foreach (BLL.Company c in Allcom)
                {

                    if (c.ID == cm.ID)
                    {

                    }
                    else { Allcom2.Add(c); her = true; }
                }
            }
            else
            {
                Allcom2.Add(cm);
            }
         if(her) Allcom2.Add(cm);
            dataGridView1.DataSource = new object();
            Allcom = Allcom2;
            dataGridView1.DataSource=Allcom;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (int.Parse(dataGridView1.Rows[e.RowIndex].Cells["iDDataGridViewTextBoxColumn"].Value.ToString()) > 0)
                {
                    btndelcur.Text = "حذف الـ " + dataGridView1.Rows[e.RowIndex].Cells["nameDataGridViewTextBoxColumn"].Value.ToString();
                    btndelcur.Enabled = true;
                }
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Del(int.Parse(dataGridView1.CurrentRow.Cells["iDDataGridViewTextBoxColumn"].Value.ToString())); btndelcur.Enabled = false;
        }

        private void Del(int p)
        {
          
            List<BLL.Company> allz = new List<WeightsOrganizer.BLL.Company>();
            foreach (BLL.Company cl in Allcom)
            {
                allz.Add(cl);
            }
            Allcom = new List<WeightsOrganizer.BLL.Company>();
            foreach (BLL.Company cl in allz)
            {
                if (cl.ID == p) { }
                else
                {
                    Allcom.Add(cl);
                }
            }
            dataGridView1.DataSource = Allcom;
 
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string x = "";
            if (Allcom.Count > 0)
            {
                foreach (BLL.Company c in Allcom)
                {
                    x += c.ID + ",";
                }
                x = x.Substring(0, x.Length - 1);
            }
            else
            {
                x = "";
            }
            BLL.Types tpp = BLL.Types.GetTypeByID(_idtype);
            tpp.AllCompanyId = x; tpp.UpdateType();
            frmRealMainForm.FrmTypso.MyRefresh();
            MessageBox.Show("تم  حفظ قائمة التجار","تنبيه",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
      
   
    }
}
