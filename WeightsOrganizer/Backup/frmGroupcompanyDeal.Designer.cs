namespace WeightsOrganizer
{
    partial class frmGroupcompanyDeal
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
            this.label4 = new System.Windows.Forms.Label();
            this.numbertextbox2 = new WeightsOrganizer.numbertextbox();
            this.label3 = new System.Windows.Forms.Label();
            this.numbertextbox1 = new WeightsOrganizer.numbertextbox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnaction = new System.Windows.Forms.Button();
            this.txtamount = new WeightsOrganizer.numbertextbox();
            this.label5 = new System.Windows.Forms.Label();
            this.combocompany = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.combotypes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.typeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.businessPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toTalPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stayingPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paidMoneyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orAddedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detailsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.businesDealBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btndelcur = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.baraCode128vewier1 = new WeightsOrganizer.Controls.BaraCode128vewier();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.businesDealBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 369);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 16);
            this.label4.TabIndex = 47;
            this.label4.Text = "المبلغ  المدفوع ل.س";
            // 
            // numbertextbox2
            // 
            this.numbertextbox2.Allowcomma = true;
            this.numbertextbox2.Location = new System.Drawing.Point(21, 403);
            this.numbertextbox2.Name = "numbertextbox2";
            this.numbertextbox2.Size = new System.Drawing.Size(229, 22);
            this.numbertextbox2.TabIndex = 46;
            this.numbertextbox2.Tag = "الكمية";
            this.numbertextbox2.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 302);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 16);
            this.label3.TabIndex = 45;
            this.label3.Text = "المبلغ الكلي ل.س";
            // 
            // numbertextbox1
            // 
            this.numbertextbox1.Allowcomma = true;
            this.numbertextbox1.Location = new System.Drawing.Point(17, 321);
            this.numbertextbox1.Name = "numbertextbox1";
            this.numbertextbox1.ReadOnly = true;
            this.numbertextbox1.Size = new System.Drawing.Size(233, 22);
            this.numbertextbox1.TabIndex = 44;
            this.numbertextbox1.Tag = "الكمية";
            this.numbertextbox1.Text = "0";
            this.numbertextbox1.TextChanged += new System.EventHandler(this.numbertextbox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(21, 454);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(237, 26);
            this.button1.TabIndex = 43;
            this.button1.Text = "شــــراء الـــكل";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnaction
            // 
            this.btnaction.Location = new System.Drawing.Point(14, 250);
            this.btnaction.Name = "btnaction";
            this.btnaction.Size = new System.Drawing.Size(237, 26);
            this.btnaction.TabIndex = 42;
            this.btnaction.Text = "اضافة ";
            this.btnaction.UseVisualStyleBackColor = true;
            this.btnaction.Click += new System.EventHandler(this.btnaction_Click);
            // 
            // txtamount
            // 
            this.txtamount.Allowcomma = true;
            this.txtamount.Location = new System.Drawing.Point(17, 199);
            this.txtamount.Name = "txtamount";
            this.txtamount.Size = new System.Drawing.Size(180, 22);
            this.txtamount.TabIndex = 38;
            this.txtamount.Tag = "الكمية";
            this.txtamount.Text = "20";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 16);
            this.label5.TabIndex = 39;
            this.label5.Text = "الكمية";
            // 
            // combocompany
            // 
            this.combocompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.combocompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combocompany.FormattingEnabled = true;
            this.combocompany.Location = new System.Drawing.Point(21, 125);
            this.combocompany.Name = "combocompany";
            this.combocompany.Size = new System.Drawing.Size(180, 24);
            this.combocompany.TabIndex = 37;
            this.combocompany.Tag = "الزبون";
            this.combocompany.SelectedIndexChanged += new System.EventHandler(this.combocompany_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 36;
            this.label2.Text = "التاجر";
            // 
            // combotypes
            // 
            this.combotypes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.combotypes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combotypes.FormattingEnabled = true;
            this.combotypes.Location = new System.Drawing.Point(17, 66);
            this.combotypes.Name = "combotypes";
            this.combotypes.Size = new System.Drawing.Size(180, 24);
            this.combotypes.TabIndex = 35;
            this.combotypes.Tag = "الصنف";
            this.combotypes.SelectedIndexChanged += new System.EventHandler(this.combotypes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 34;
            this.label1.Text = "الصنف او النوع";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.typeNameDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.manNameDataGridViewTextBoxColumn,
            this.businessPriceDataGridViewTextBoxColumn,
            this.toTalPriceDataGridViewTextBoxColumn,
            this.clientPriceDataGridViewTextBoxColumn,
            this.stayingPriceDataGridViewTextBoxColumn,
            this.manIdDataGridViewTextBoxColumn,
            this.paidMoneyDataGridViewTextBoxColumn,
            this.typeIdDataGridViewTextBoxColumn,
            this.orAddedDateDataGridViewTextBoxColumn,
            this.detailsDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.addedDateDataGridViewTextBoxColumn,
            this.iDDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.businesDealBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(285, 157);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(626, 323);
            this.dataGridView1.TabIndex = 48;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.DataSourceChanged += new System.EventHandler(this.dataGridView1_DataSourceChanged);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // typeNameDataGridViewTextBoxColumn
            // 
            this.typeNameDataGridViewTextBoxColumn.DataPropertyName = "TypeName";
            this.typeNameDataGridViewTextBoxColumn.HeaderText = "الصنف";
            this.typeNameDataGridViewTextBoxColumn.Name = "typeNameDataGridViewTextBoxColumn";
            this.typeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeNameDataGridViewTextBoxColumn.Width = 137;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "الكمية";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            this.amountDataGridViewTextBoxColumn.Width = 137;
            // 
            // manNameDataGridViewTextBoxColumn
            // 
            this.manNameDataGridViewTextBoxColumn.DataPropertyName = "ManName";
            this.manNameDataGridViewTextBoxColumn.HeaderText = "ManName";
            this.manNameDataGridViewTextBoxColumn.Name = "manNameDataGridViewTextBoxColumn";
            this.manNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.manNameDataGridViewTextBoxColumn.Visible = false;
            // 
            // businessPriceDataGridViewTextBoxColumn
            // 
            this.businessPriceDataGridViewTextBoxColumn.DataPropertyName = "BusinessPrice";
            this.businessPriceDataGridViewTextBoxColumn.HeaderText = "السعر";
            this.businessPriceDataGridViewTextBoxColumn.Name = "businessPriceDataGridViewTextBoxColumn";
            this.businessPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.businessPriceDataGridViewTextBoxColumn.Width = 137;
            // 
            // toTalPriceDataGridViewTextBoxColumn
            // 
            this.toTalPriceDataGridViewTextBoxColumn.DataPropertyName = "ToTalPrice";
            this.toTalPriceDataGridViewTextBoxColumn.HeaderText = "السعر الاجمالي";
            this.toTalPriceDataGridViewTextBoxColumn.Name = "toTalPriceDataGridViewTextBoxColumn";
            this.toTalPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.toTalPriceDataGridViewTextBoxColumn.Width = 137;
            // 
            // clientPriceDataGridViewTextBoxColumn
            // 
            this.clientPriceDataGridViewTextBoxColumn.DataPropertyName = "ClientPrice";
            this.clientPriceDataGridViewTextBoxColumn.HeaderText = "السعر للزبائن";
            this.clientPriceDataGridViewTextBoxColumn.Name = "clientPriceDataGridViewTextBoxColumn";
            this.clientPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.clientPriceDataGridViewTextBoxColumn.Visible = false;
            // 
            // stayingPriceDataGridViewTextBoxColumn
            // 
            this.stayingPriceDataGridViewTextBoxColumn.DataPropertyName = "StayingPrice";
            this.stayingPriceDataGridViewTextBoxColumn.HeaderText = "StayingPrice";
            this.stayingPriceDataGridViewTextBoxColumn.Name = "stayingPriceDataGridViewTextBoxColumn";
            this.stayingPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.stayingPriceDataGridViewTextBoxColumn.Visible = false;
            // 
            // manIdDataGridViewTextBoxColumn
            // 
            this.manIdDataGridViewTextBoxColumn.DataPropertyName = "ManId";
            this.manIdDataGridViewTextBoxColumn.HeaderText = "ManId";
            this.manIdDataGridViewTextBoxColumn.Name = "manIdDataGridViewTextBoxColumn";
            this.manIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.manIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // paidMoneyDataGridViewTextBoxColumn
            // 
            this.paidMoneyDataGridViewTextBoxColumn.DataPropertyName = "PaidMoney";
            this.paidMoneyDataGridViewTextBoxColumn.HeaderText = "PaidMoney";
            this.paidMoneyDataGridViewTextBoxColumn.Name = "paidMoneyDataGridViewTextBoxColumn";
            this.paidMoneyDataGridViewTextBoxColumn.ReadOnly = true;
            this.paidMoneyDataGridViewTextBoxColumn.Visible = false;
            // 
            // typeIdDataGridViewTextBoxColumn
            // 
            this.typeIdDataGridViewTextBoxColumn.DataPropertyName = "TypeId";
            this.typeIdDataGridViewTextBoxColumn.HeaderText = "TypeId";
            this.typeIdDataGridViewTextBoxColumn.Name = "typeIdDataGridViewTextBoxColumn";
            this.typeIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // orAddedDateDataGridViewTextBoxColumn
            // 
            this.orAddedDateDataGridViewTextBoxColumn.DataPropertyName = "OrAddedDate";
            this.orAddedDateDataGridViewTextBoxColumn.HeaderText = "OrAddedDate";
            this.orAddedDateDataGridViewTextBoxColumn.Name = "orAddedDateDataGridViewTextBoxColumn";
            this.orAddedDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.orAddedDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // detailsDataGridViewTextBoxColumn
            // 
            this.detailsDataGridViewTextBoxColumn.DataPropertyName = "Details";
            this.detailsDataGridViewTextBoxColumn.HeaderText = "Details";
            this.detailsDataGridViewTextBoxColumn.Name = "detailsDataGridViewTextBoxColumn";
            this.detailsDataGridViewTextBoxColumn.ReadOnly = true;
            this.detailsDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Visible = false;
            // 
            // addedDateDataGridViewTextBoxColumn
            // 
            this.addedDateDataGridViewTextBoxColumn.DataPropertyName = "AddedDate";
            this.addedDateDataGridViewTextBoxColumn.HeaderText = "AddedDate";
            this.addedDateDataGridViewTextBoxColumn.Name = "addedDateDataGridViewTextBoxColumn";
            this.addedDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.addedDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // businesDealBindingSource
            // 
            this.businesDealBindingSource.DataSource = typeof(WeightsOrganizer.BLL.BusinesDeal);
            // 
            // btndelcur
            // 
            this.btndelcur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btndelcur.Enabled = false;
            this.btndelcur.Location = new System.Drawing.Point(450, 502);
            this.btndelcur.Name = "btndelcur";
            this.btndelcur.Size = new System.Drawing.Size(226, 26);
            this.btndelcur.TabIndex = 50;
            this.btndelcur.Text = "حذف الحالي";
            this.btndelcur.UseVisualStyleBackColor = true;
            this.btndelcur.Click += new System.EventHandler(this.btndelcur_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Green;
            this.label7.Location = new System.Drawing.Point(153, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "السعر";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Green;
            this.label13.Location = new System.Drawing.Point(113, 98);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 13);
            this.label13.TabIndex = 52;
            this.label13.Text = "كل الشركات";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // baraCode128vewier1
            // 
            this.baraCode128vewier1.CtrlType = this.combotypes;
            this.baraCode128vewier1.DontCatch = true;
            this.baraCode128vewier1.EnableCreate = false;
            this.baraCode128vewier1.InStore = false;
            this.baraCode128vewier1.Location = new System.Drawing.Point(285, 17);
            this.baraCode128vewier1.Name = "baraCode128vewier1";
            this.baraCode128vewier1.Size = new System.Drawing.Size(287, 133);
            this.baraCode128vewier1.TabIndex = 10003;
            // 
            // frmGroupcompanyDeal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(901, 563);
            this.Controls.Add(this.baraCode128vewier1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btndelcur);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numbertextbox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numbertextbox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnaction);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtamount);
            this.Controls.Add(this.combocompany);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.combotypes);
            this.Controls.Add(this.label1);
            this.MinimizeBox = false;
            this.Name = "frmGroupcompanyDeal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فاتورة تاجر(سحب بضاعة من تاجر)";
            this.Load += new System.EventHandler(this.frmGroupcompanyDeal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.businesDealBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private numbertextbox numbertextbox2;
        private System.Windows.Forms.Label label3;
        private numbertextbox numbertextbox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnaction;
        private numbertextbox txtamount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox combocompany;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox combotypes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource businesDealBindingSource;
        private System.Windows.Forms.Button btndelcur;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private WeightsOrganizer.Controls.BaraCode128vewier baraCode128vewier1;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn businessPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn toTalPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stayingPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paidMoneyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orAddedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn detailsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
    }
}
