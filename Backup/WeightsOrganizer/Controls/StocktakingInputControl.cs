﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer.Controls
{
    public partial class StocktakingInputControl : UserControl
    {
        public StocktakingInputControl()
        {
            InitializeComponent();
        }
        public object  DateSource
        {
            get
            {
                return dataGridView1.DataSource;
            }
            set
            {
                dataGridView1.DataSource = value;
                PrpeareDataSource();

            }
        }

        void PrpeareDataSource()
        {
            cmtyps.DataSource = BLL.BllGlobal.alltypes;
            cmcmps.DataSource = BLL.BllGlobal.allcomps;
            cmtyps.DisplayMember = "Name";
            cmcmps.DisplayMember = "Name";

            cmtyps.ValueMember = "ID";
            cmcmps.ValueMember = "ID";

        }

        private void cmtyps_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = cmtyps.Text;
            label2.Text = cmcmps.Text;
        }

        private void cmcmps_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = cmtyps.Text;
            label2.Text = cmcmps.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length > 0)
                {

                    dataGridView1.DataSource = BLL.BusinesDeal.Search(textBox1.Text);
                }
                else
                {
                    dataGridView1.DataSource = BLL.BusinesDeal.GetAllBusinesDeal();
                }
            }
            catch { }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Visible = !(radioButton1.Checked);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            cmcmps.Enabled = cmtyps.Enabled = checkBox1.Checked;
            if (checkBox1.Checked)
            {
                label1.Text = cmtyps.Text;
                label2.Text = cmcmps.Text;
            }
            else
            {
           label1.Text = "";
           label2.Text = "";
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            Globals.Globals.PrintNow(dataGridView1, "مردود المشتريات");
        }

        private void StocktakingInputControl_Load(object sender, EventArgs e)
        {

        }

        private void radiotypwithdte_CheckedChanged(object sender, EventArgs e)
        {

        }

  

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FrmSumInput f = new FrmSumInput(Summing.Input);
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((checkBox1.Checked) && (radioButton2.Checked))
                {
                    dataGridView1.DataSource = BLL.BusinesDeal.Search(dateTimePicker1.Value, dateTimePicker2.Value, int.Parse(cmtyps.SelectedValue.ToString()), int.Parse(cmcmps.SelectedValue.ToString()));
                }
                if ((checkBox1.Checked) && (!radioButton2.Checked))
                {
                    dataGridView1.DataSource = BLL.BusinesDeal.Search(dateTimePicker1.Value, int.Parse(cmtyps.SelectedValue.ToString()), int.Parse(cmcmps.SelectedValue.ToString()));
                }
                if ((!checkBox1.Checked) && (!radioButton2.Checked))
                {
                    dataGridView1.DataSource = BLL.BusinesDeal.Search(DateTime.Parse(dateTimePicker1.Value.ToShortDateString()));
                }
                if ((!checkBox1.Checked) && (radioButton2.Checked))
                {
                    dataGridView1.DataSource = BLL.BusinesDeal.Search(dateTimePicker1.Value, dateTimePicker2.Value);
                }
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                FrmSumInput f = new FrmSumInput(Summing.Input);
                f.ShowDialog();
            }
            catch { }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try{
            if (e.ColumnIndex == 1)
            {
                int rid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString());
                new FrmDetails(rid, "أصناف").ShowDialog();
            }
            if (e.ColumnIndex == 0)
            {
                string na = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                int idf = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
                contextMenuStrip1.Items[0].Text = " معلومات عن التاجر " + na;
                contextMenuStrip1.Items[1].Text = " حـــســــاب التاجر   " + na;
                contextMenuStrip1.Items[0].Tag = idf;
                contextMenuStrip1.Items[1].Tag = idf;
                contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            }
            }
            catch { }
        }

        private void groupBox2_Enter_1(object sender, EventArgs e)
        {

        }

        private void infooToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmDetails(int.Parse(infooToolStripMenuItem.Tag.ToString()), "تجار").ShowDialog();
        }

        private void acooToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WeightsOrganizer.Controls.ViewAll.FastBill(int.Parse(acooToolStripMenuItem.Tag.ToString()), "تجار");
        }
    }
}
