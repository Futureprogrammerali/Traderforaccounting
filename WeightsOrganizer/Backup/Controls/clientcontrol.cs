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
    public partial class clientcontrol : UserControl
    {
        public clientcontrol()
        {
        InitializeComponent();
        }
        public object DateSource
        {
            get { return dataGridView1.DataSource; }
            set
            {
                alltyps = (List<Client>)value;
                dataGridView1.DataSource = value;
                label1.Text = "عدد الزبائن " + dataGridView1.Rows.Count.ToString();
                cmcmps.DataSource = BLL.BllGlobal.allclients;
                cmcmps.DisplayMember = "Name";
                cmcmps.ValueMember = "ID";
                cmcmps.SelectedValue= - 1;
                cmcmps.Text = "حدد الزبون العام ";
            }
        }
        int id = 0;
        Mode Mode = Mode.Update;
        List<Client> alltyps = new List<Client>();

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
                btnaction.Text = "اضافة زبون";
                btndel.Enabled = false;
            }
            else
            {
                btnaction.Text = " تعديل بيانات زبون";
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

                    BLL.Client.DeleteClient(id);
                    alltyps = BLL.Client.GetAllClient();
                    dataGridView1_DataSourceChanged(sender, e);
                    btnnew_Click(sender, e);
                    txtname.Focus();
                    WeightsOrganizer.Controls.Righto.GetDataAgainToclient();
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
            try
            {
                det = txtdet.Text;
                nme = txtname.Text;
                if ((id > 0))
                {
                    BLL.Client.UpdateClient(id, nme, det);
                }
                else
                {
                    if (BLL.Client.GetClientByName(nme) != null) { MessageBox.Show(" الاسم موجود مسبقا الرجاء ادخال اسم اخر", "خطأ مدخلات"); return; }
                    BLL.Client.InsertClient(0, nme, det);
                    BllGlobal.UpdateAllClients();
                    cmcmps.DataSource = BLL.BllGlobal.allclients;
                }
                alltyps = BLL.Client.GetAllClient();
                BLL.BllGlobal.UpdateAllCompany();
                dataGridView1_DataSourceChanged(sender, e);
                this.Refresh();
                btnnew_Click(sender, e);
                txtname.Focus();
            }
            catch
            {
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtsrch_TextChanged(object sender, EventArgs e)
        {
            if (txtsrch.Text.Length > 0)
            {
                alltyps = BLL.Client.Search(txtsrch.Text);
                dataGridView1.DataSource = alltyps;
            }
            else
            {
                alltyps = BLL.Client.GetAllClient();
            }
            dataGridView1.DataSource = alltyps;
            label1.Text = "عدد الزبائن " + dataGridView1.Rows.Count.ToString();
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {
            btnaction.Enabled = (txtname.Text.Length != 0);
        }

        private void clientcontrol_Load(object sender, EventArgs e)
        {
           int x=Globals.Globals.UnknownClient;
           cmcmps.SelectedValue =x;
           label4.Text ="الزبون العام :" +BLL.BllGlobal.GetclientsNameFromListclientsHere(x);
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Globals.Globals.PrintNow( dataGridView1,"الزبائن");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            alltyps = BllGlobal.allclients;
            dataGridView1.DataSource = alltyps;
            label1.Text = dataGridView1.Rows.Count.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cmcmps.SelectedIndex != -1) {
                Globals.Globals.UnknownClient = (int)cmcmps.SelectedValue;
                button3.Enabled = false;
                cmcmps.SelectedValue = (int)Globals.Globals.UnknownClient;
            }
            else MessageBox.Show("حدد الزبون");
        }

        private void cmcmps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmcmps.SelectedIndex != -1) button3.Enabled = true;
        }

 
    }
}
