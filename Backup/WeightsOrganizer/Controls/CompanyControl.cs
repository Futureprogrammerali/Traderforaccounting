using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using WeightsOrganizer.BLL;

namespace WeightsOrganizer.Controls
{
    public partial class CompanyControl : UserControl
    {
        public CompanyControl()
        {
            InitializeComponent();
        }

        private void CompanyControl_Load(object sender, EventArgs e)
        {
           
        }
        public object DateSource
        {
            get { return dataGridView1.DataSource; }
            set
            {

                alltyps = (List<Company>)value;
                dataGridView1.DataSource = value;
                label1.Text = "عدد التجار " + dataGridView1.Rows.Count.ToString();
            }
        }
        int id = 0;
        Mode Mode = Mode.Update;
        List<Company> alltyps = new List<Company>();

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lblid.Text = dataGridView1.Rows[e.RowIndex].Cells["iDDataGridViewTextBoxColumn"].Value.ToString();
                txtname.Text = dataGridView1.Rows[e.RowIndex].Cells["nameDataGridViewTextBoxColumn"].Value.ToString();
                txtdet.Text = dataGridView1.Rows[e.RowIndex].Cells["detailsDataGridViewTextBoxColumn"].Value.ToString();
                lbladded.Text = dataGridView1.Rows[e.RowIndex].Cells["addedDateDataGridViewTextBoxColumn"].Value.ToString();

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
                btnaction.Text = "اضافة شركة او تاجر";
                btndel.Enabled = false;
            }
            else
            {
                btnaction.Text = "تعديل بيانات";
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

                    BLL.Company.DeleteCompany(id);
                    alltyps = BLL.Company.GetAllCompany();
                    dataGridView1_DataSourceChanged(sender, e);
                    btnnew_Click(sender, e);
                    txtname.Focus();
                     WeightsOrganizer.Controls.Righto.GetDataAgainTocompany();
                }
            }
            catch { }


        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            foreach (Control t in groupBox1.Controls)
            {
                if (t is TextBox) t.Text = "";
            }
            lblid.Text = "0";
            txtname.Focus();
        }

        private void btnaction_Click(object sender, EventArgs e)
        {

            string nme = "";
            string det = "";
            //try
            //{
                det = txtdet.Text;
                nme = txtname.Text;
                if ((id > 0))
                {
                    BLL.Company.UpdateCompany(id, nme, det);
                    WeightsOrganizer.Controls.Righto.GetDataAgainTocompany();
                }
                else
                {
                    if (BLL.Company.GetCompanyByName(nme) == null)
                    {
                    BLL.Company.InsertCompany(0, nme, det);
                    WeightsOrganizer.Controls.Righto.GetDataAgainTocompany();
                    }
                    else
                    {
                    MessageBox.Show(" الاسم موجود مسبقا الرجاء ادخال اسم اخر", "خطأ مدخلات");
                    }
                }
                alltyps = BLL.Company.GetAllCompany();
                BllGlobal.UpdateAllCompany();
                dataGridView1_DataSourceChanged(sender, e);
                btnnew_Click(sender, e);
                txtname.Focus();
            //}
            //catch
            //{
            //    MessageBox.Show(" الرجاء التأكد من المدخلات", "خطأ مدخلات");
            //    SelectTheEmptyText(groupBox1);
            //}

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtsrch_TextChanged(object sender, EventArgs e)
        {
            if (txtsrch.Text.Length > 0)
            {
                alltyps = BLL.Company.Search(txtsrch.Text);
                dataGridView1.DataSource = alltyps;
            }
            else
            {
                alltyps = BLL.Company.GetAllCompany();
            }
            dataGridView1.DataSource = alltyps;
            label1.Text = "عدد التجار " + dataGridView1.Rows.Count.ToString();
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {
            btnaction.Enabled = (txtname.Text.Length != 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Globals.Globals.PrintNow( dataGridView1,"التجار");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            alltyps = BllGlobal.allcomps;
            dataGridView1.DataSource = alltyps;
            label1.Text = dataGridView1.Rows.Count.ToString();
        }

        
    }
}
