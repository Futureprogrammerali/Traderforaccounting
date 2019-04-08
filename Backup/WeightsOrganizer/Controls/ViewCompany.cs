using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace WeightsOrganizer.Controls
{
    public partial class ViewCompany : UserControl
    {
        public ViewCompany()
        {
            InitializeComponent();
        }
        public object DateSource
        {

            set
            {
                dataGridView1.DataSource = value;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
