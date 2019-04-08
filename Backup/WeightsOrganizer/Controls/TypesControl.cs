using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using WeightsOrganizer.BLL;
using System.Globalization;

namespace WeightsOrganizer.Controls
{
    public partial class TypesControl : UserControl
    {
        public TypesControl()
        {
            InitializeComponent();
        }
        public object DateSource
        {
            get { return dataGridView1.DataSource; }
            set
            {
                alltyps = (List<Types>)value;
                dataGridView1.DataSource = value;
                label4.Text = "عدد الاصناف " + dataGridView1.Rows.Count.ToString();
            }
        }
        int id = 0;
        Mode Mode = Mode.Update;
        List<Types> alltyps = new List<Types>();
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lblid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtname.Text = dataGridView1.Rows[e.RowIndex].Cells["nameDataGridViewTextBoxColumn"].Value.ToString();
                txtBusinessPrice.Text = dataGridView1.Rows[e.RowIndex].Cells["businessPriceDataGridViewTextBoxColumn"].Value.ToString();
                txtClientPrice.Text = dataGridView1.Rows[e.RowIndex].Cells["clientPriceDataGridViewTextBoxColumn"].Value.ToString();
                txtprcln.Text =dataGridView1.Rows[e.RowIndex].Cells["BusinessClientPrice"].Value.ToString();
                txtprcln.Text = dataGridView1.Rows[e.RowIndex].Cells["BusinessClientPrice"].Value.ToString();
                label5.Text = " الوحدة المستخدمة " + dataGridView1.Rows[e.RowIndex].Cells["ArabicUnit"].Value.ToString();
                baraCode128vewier1.Text = dataGridView1.Rows[e.RowIndex].Cells["BaraCode"].Value.ToString();
                settingoControl1.Refresh2((TheUnito)Enum.Parse(typeof(TheUnito), dataGridView1.Rows[e.RowIndex].Cells["TheUnit"].Value.ToString()));

            }
            catch { }
        }
        private void lblid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(lblid.Text);

            }
            catch { }
            if (id > 0)
            {
                this.Mode = Mode.Update;
                ModeUpdateEnable(true);
            }
            else
            {
                this.Mode = Mode.Insert;
                ModeUpdateEnable(false);
            }
        }
        private void ModeUpdateEnable(bool p)
        {
            if (this.Mode == Mode.Insert)
            {
                btnaction.Text = "اضافة صنف";
                btndel.Enabled = false;
            }
            else
            {
                btnaction.Text = " تعديل الصنف";
                btndel.Enabled = true;
            }
        }
        private void lblid_Click(object sender, EventArgs e)
        {

        }
        private void btndel_Click(object sender, EventArgs e)
        {
            try
            {
                if (id > 0)
                {

                    BLL.Types.DeleteType(id);
                    alltyps = BLL.Types.GetAllTypes();
                    WeightsOrganizer.Controls.Righto.GetDataAgainToTypes();
                    BllGlobal.UpdateAllStore();
                    dataGridView1_DataSourceChanged(sender, e);
                    btnnew_Click(sender, e);
                    txtname.Focus();

                }
            }
            catch { }


        }
        private void btnnew_Click(object sender, EventArgs e)
        {
            string bra = "b0";
            try
            {
                bra = "b" + BLL.Types.LastIdInTypes();
            }
            catch { }
            
            foreach (Control t in groupBox1.Controls)
            {
                if (t is TextBox) t.Text = "";
            }
            lblid.Text = "0";
            baraCode128vewier1.Text = bra;
            txtname.Focus();
        }
        TheUnito TheUnito = TheUnito.Kilo;
        private void btnaction_Click(object sender, EventArgs e)
        {
            string baracode = "0";
            double bupric = 0, clpric = 0, businessclientPrice = 0;
            string nme = "";
            try
            {
                TheUnito = (TheUnito)Enum.Parse(typeof(TheUnito), Globals.Globals.gram.ToString());
                bupric = double.Parse(txtBusinessPrice.Text);
                clpric = double.Parse(txtClientPrice.Text);
                businessclientPrice = double.Parse(txtprcln.Text);
                nme = txtname.Text;
                baracode = (string.IsNullOrEmpty(baraCode128vewier1.Text) ? "0" : baraCode128vewier1.Text);
                int baraisher = 0;
                List<Types> allbracodr = new List<Types>();
                allbracodr = BLL.Types.GetTypeByBaraCode(baracode, false);
                baraisher = allbracodr.Count;
                if (id > 0)
                {
                    if ((baraisher > 0))
                        if (allbracodr[0].BaraCode != BLL.Types.GetTypeByID(id).BaraCode) { MessageBox.Show("هذا الباركود خاص بصنف اخر "); return; }


                    if ((nme != BLL.Types.GetTypeByID(id).Name)) Store.UpdateTypNamesinstore(id, nme);
                    BLL.Types.UpdateType(id, nme, bupric, clpric, businessclientPrice, TheUnito, baracode);

                }
                else
                {
                    if (BLL.Types.GetTypeByName(nme) != null) { MessageBox.Show(" الاسم موجود مسبقا الرجاء ادخال اسم اخر", "خطأ مدخلات"); return; }

                    if (baraisher > 0) { MessageBox.Show("هذا الباركود متوفر مسبقا"); return; }
                    BLL.Types.InsertType(0, nme, bupric, clpric, businessclientPrice, TheUnito, baracode);
                }
                alltyps = BLL.Types.GetAllTypes();
                dataGridView1_DataSourceChanged(sender, e);
                btnnew_Click(sender, e);
                txtname.Focus();
                BllGlobal.UpdateAllType();
                WeightsOrganizer.Controls.Righto.GetDataAgainToTypes();
                BllGlobal.UpdateAllStore();
            }
            catch{;            
                MessageBox.Show(" الرجاء التأكد من المدخلات", "خطأ مدخلات");
                SelectTheEmptyText(groupBox1);
            }

        }
 

 
        private void SelectTheEmptyText(Control ctrcontin)
        {
            foreach (Control t in ctrcontin.Controls)
            {
                if (t is TextBox) if (t.Text.Length == 0) t.Focus(); break;
            }
        }
        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = alltyps;
        }
        private void txtsrch_TextChanged(object sender, EventArgs e)
        {
            if (txtsrch.Text.Length > 0)
            {
                alltyps = BLL.Types.Search(txtsrch.Text);
                dataGridView1.DataSource = alltyps;
            }
            else
            {
                alltyps = BLL.Types.GetAllTypes();
            }
            dataGridView1.DataSource = alltyps;
            label4.Text = "عدد الاصناف " + dataGridView1.Rows.Count.ToString();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          try
           {
                if (e.ColumnIndex == 6)
                {
                    frmAllcompanybytype fr = new frmAllcompanybytype(int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));
                    fr.ShowDialog();
                }
         }
          catch { }
        }
        private void txtname_TextChanged(object sender, EventArgs e)
        {
            btnaction.Enabled = (txtname.Text.Length > 1);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Globals.Globals.PrintNow( dataGridView1,"الأصناف");
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
        Globals.Globals.PrintNow(dataGridView1, "الأصناف");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            List<BLL.Types> alltype2 = Types.GetAllTypesNotavailable();
            this.DateSource = alltype2; 
        }
        private void button3_Click(object sender, EventArgs e)
        {
            alltyps = BllGlobal.alltypes;
            dataGridView1.DataSource = alltyps;
            label4.Text = dataGridView1.Rows.Count.ToString();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
           
        }
    }
    }
