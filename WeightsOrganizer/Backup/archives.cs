using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer
{

    public enum archivesTypes : int
{
   Out = 0, In = 1  
}
    public partial class archives : WeightsOrganizer.FrmMain
    {
        archivesTypes _archivesTypeso = archivesTypes.In;
        public archives(archivesTypes archivesTypeso)
        {
            InitializeComponent();
            this.Text += ((archivesTypeso==archivesTypes.In )? "المشتريات" : "المبيعات");
            label1.Text += ((archivesTypeso == archivesTypes.In) ? "المشتريات" : "المبيعات");
            _archivesTypeso = archivesTypeso;
            dataGridView1.DataSource = BLL.Archives.GetAllArchives(archivesTypeso);
            xx.BackColor = Color.White;
            xx.ForeColor = Color.White;
            xx.SelectionForeColor = Color.White;
            xx.SelectionBackColor = Color.White;
         if (archivesTypeso == archivesTypes.In) dataGridView1.Columns["profitDataGridViewTextBoxColumn"].Visible = false;
        }

        private void archives_Load(object sender, EventArgs e)
        {       
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                label2.Text = dataGridView1.Rows[e.RowIndex].Cells["iDDataGridViewTextBoxColumn"].Value.ToString();
                label3.Text = dataGridView1.Rows[e.RowIndex].Cells["smallTypeDataGridViewTextBoxColumn"].Value.ToString();
            }
            catch { }
        }

        private void label2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = label2.Text.Length > 0;
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.Archives.DeleteArchives(int.Parse(label2.Text));
                dataGridView1.DataSource = BLL.Archives.GetAllArchives(_archivesTypeso);
            }
            catch { }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                label2.Text = dataGridView1.Rows[e.RowIndex].Cells["iDDataGridViewTextBoxColumn"].Value.ToString();
                label3.Text = dataGridView1.Rows[e.RowIndex].Cells["smallTypeDataGridViewTextBoxColumn"].Value.ToString();
            }
            catch { }
        }
        DataGridViewCellStyle xx = new DataGridViewCellStyle();
       
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells["SmallType"].Value.ToString() == "0")
            {
                dataGridView1.Rows[e.RowIndex].Cells["addedDate1DataGridViewTextBoxColumn"].Style = xx;
                dataGridView1.Rows[e.RowIndex].Cells["addedDate2DataGridViewTextBoxColumn"].Style = xx;
            }
            //if (dataGridView1.Rows[e.RowIndex].Cells["SmallType"].Value.ToString() == "1")
            //{
            //    dataGridView1.Rows[e.RowIndex].Cells["addedDate2DataGridViewTextBoxColumn"].Style = x;
            //}
 

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                label2.Text = dataGridView1.Rows[e.RowIndex].Cells["iDDataGridViewTextBoxColumn"].Value.ToString();
                label3.Text = dataGridView1.Rows[e.RowIndex].Cells["smallTypeDataGridViewTextBoxColumn"].Value.ToString();
            }
            catch { }
        }
    }
}
