namespace WeightsOrganizer
{
    partial class archives
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.archivesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.smallTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paidMoneyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stayingPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addedDate1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addedDate2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detailsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bigTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SmallType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.archivesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 23);
            this.label1.TabIndex = 39;
            this.label1.Text = "أرشيف احصائيات الــتـاجـر-";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.smallTypeDataGridViewTextBoxColumn,
            this.Amount,
            this.priceDataGridViewTextBoxColumn,
            this.paidMoneyDataGridViewTextBoxColumn,
            this.stayingPriceDataGridViewTextBoxColumn,
            this.profitDataGridViewTextBoxColumn,
            this.AddedDate,
            this.addedDate1DataGridViewTextBoxColumn,
            this.addedDate2DataGridViewTextBoxColumn,
            this.detailsDataGridViewTextBoxColumn,
            this.bigTypeDataGridViewTextBoxColumn,
            this.SmallType});
            this.dataGridView1.DataSource = this.archivesBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(28, 113);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(744, 537);
            this.dataGridView1.TabIndex = 40;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // archivesBindingSource
            // 
            this.archivesBindingSource.DataSource = typeof(WeightsOrganizer.BLL.Archives);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(454, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 14);
            this.label2.TabIndex = 41;
            this.label2.Visible = false;
            this.label2.TextChanged += new System.EventHandler(this.label2_TextChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(181, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 42;
            this.button1.Text = "حذف المحدد";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 14);
            this.label3.TabIndex = 43;
            this.label3.Text = "نوع الاحصاء";
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // smallTypeDataGridViewTextBoxColumn
            // 
            this.smallTypeDataGridViewTextBoxColumn.DataPropertyName = "SmallTypeName";
            this.smallTypeDataGridViewTextBoxColumn.HeaderText = "نوع الاحصاء";
            this.smallTypeDataGridViewTextBoxColumn.Name = "smallTypeDataGridViewTextBoxColumn";
            this.smallTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "الكمية-العدد";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.ToolTipText = "العدد";
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "اجمالي السعر ل.س";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            this.priceDataGridViewTextBoxColumn.ToolTipText = "اجمالي السعر ل.س";
            // 
            // paidMoneyDataGridViewTextBoxColumn
            // 
            this.paidMoneyDataGridViewTextBoxColumn.DataPropertyName = "PaidMoney";
            this.paidMoneyDataGridViewTextBoxColumn.HeaderText = "المدفوع ل.س";
            this.paidMoneyDataGridViewTextBoxColumn.Name = "paidMoneyDataGridViewTextBoxColumn";
            this.paidMoneyDataGridViewTextBoxColumn.ReadOnly = true;
            this.paidMoneyDataGridViewTextBoxColumn.Visible = false;
            // 
            // stayingPriceDataGridViewTextBoxColumn
            // 
            this.stayingPriceDataGridViewTextBoxColumn.DataPropertyName = "StayingPrice";
            this.stayingPriceDataGridViewTextBoxColumn.HeaderText = "الباقي ل.س";
            this.stayingPriceDataGridViewTextBoxColumn.Name = "stayingPriceDataGridViewTextBoxColumn";
            this.stayingPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.stayingPriceDataGridViewTextBoxColumn.ToolTipText = "الباقي ل.س";
            this.stayingPriceDataGridViewTextBoxColumn.Visible = false;
            // 
            // profitDataGridViewTextBoxColumn
            // 
            this.profitDataGridViewTextBoxColumn.DataPropertyName = "Profit";
            this.profitDataGridViewTextBoxColumn.HeaderText = "الربح ل.س";
            this.profitDataGridViewTextBoxColumn.Name = "profitDataGridViewTextBoxColumn";
            this.profitDataGridViewTextBoxColumn.ReadOnly = true;
            this.profitDataGridViewTextBoxColumn.ToolTipText = "الربح";
            // 
            // AddedDate
            // 
            this.AddedDate.DataPropertyName = "AddedDate";
            this.AddedDate.HeaderText = "تاريخ اجراء الاحصاء";
            this.AddedDate.Name = "AddedDate";
            this.AddedDate.ReadOnly = true;
            // 
            // addedDate1DataGridViewTextBoxColumn
            // 
            this.addedDate1DataGridViewTextBoxColumn.DataPropertyName = "AddedDate1";
            this.addedDate1DataGridViewTextBoxColumn.HeaderText = "التاريخ الأول المستخدم في الاحصاء";
            this.addedDate1DataGridViewTextBoxColumn.Name = "addedDate1DataGridViewTextBoxColumn";
            this.addedDate1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // addedDate2DataGridViewTextBoxColumn
            // 
            this.addedDate2DataGridViewTextBoxColumn.DataPropertyName = "AddedDate2";
            this.addedDate2DataGridViewTextBoxColumn.HeaderText = "التاريخ الثاني المستخدم في الاحصاء";
            this.addedDate2DataGridViewTextBoxColumn.Name = "addedDate2DataGridViewTextBoxColumn";
            this.addedDate2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // detailsDataGridViewTextBoxColumn
            // 
            this.detailsDataGridViewTextBoxColumn.DataPropertyName = "Details";
            this.detailsDataGridViewTextBoxColumn.HeaderText = "معلومات";
            this.detailsDataGridViewTextBoxColumn.Name = "detailsDataGridViewTextBoxColumn";
            this.detailsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bigTypeDataGridViewTextBoxColumn
            // 
            this.bigTypeDataGridViewTextBoxColumn.DataPropertyName = "BigType";
            this.bigTypeDataGridViewTextBoxColumn.HeaderText = "BigType";
            this.bigTypeDataGridViewTextBoxColumn.Name = "bigTypeDataGridViewTextBoxColumn";
            this.bigTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.bigTypeDataGridViewTextBoxColumn.Visible = false;
            // 
            // SmallType
            // 
            this.SmallType.DataPropertyName = "SmallType";
            this.SmallType.HeaderText = "SmallType";
            this.SmallType.Name = "SmallType";
            this.SmallType.ReadOnly = true;
            this.SmallType.Visible = false;
            // 
            // archives
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(784, 662);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.MinimizeBox = false;
            this.Name = "archives";
            this.Text = "أرشيف احصائيات الــتـاجـر-";
            this.Load += new System.EventHandler(this.archives_Load);
 
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.archivesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource archivesBindingSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn smallTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paidMoneyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stayingPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn profitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn addedDate1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addedDate2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn detailsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bigTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SmallType;
    }
}
