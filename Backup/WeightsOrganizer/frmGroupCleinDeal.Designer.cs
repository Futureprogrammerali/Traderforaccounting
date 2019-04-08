namespace WeightsOrganizer
{
    partial class frmGroupCleinDeal
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
            this.combocompany = new System.Windows.Forms.ComboBox();
            this.combotypes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtamount = new WeightsOrganizer.numbertextbox();
            this.settingoControl1 = new WeightsOrganizer.Controls.SettingoControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btnaction = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.numbertextbox1 = new WeightsOrganizer.numbertextbox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numbertextbox2 = new WeightsOrganizer.numbertextbox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.arabicUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toTalPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stayingPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paidMoneyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.theUnitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orAddedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detailsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientDealBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.handclnt = new WeightsOrganizer.numbertextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.btndelcur = new System.Windows.Forms.Button();
            this.baraCode128vewier1 = new WeightsOrganizer.Controls.BaraCode128vewier();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientDealBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // combocompany
            // 
            this.combocompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.combocompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combocompany.FormattingEnabled = true;
            this.combocompany.Location = new System.Drawing.Point(18, 113);
            this.combocompany.Name = "combocompany";
            this.combocompany.Size = new System.Drawing.Size(158, 22);
            this.combocompany.TabIndex = 8;
            this.combocompany.Tag = "الزبون";
            this.combocompany.SelectedIndexChanged += new System.EventHandler(this.combocompany_SelectedIndexChanged);
            // 
            // combotypes
            // 
            this.combotypes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.combotypes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combotypes.FormattingEnabled = true;
            this.combotypes.Location = new System.Drawing.Point(18, 59);
            this.combotypes.Name = "combotypes";
            this.combotypes.Size = new System.Drawing.Size(158, 22);
            this.combotypes.TabIndex = 0;
            this.combotypes.Tag = "الصنف";
            this.combotypes.SelectedIndexChanged += new System.EventHandler(this.combotypes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "الصنف او النوع";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 14);
            this.label5.TabIndex = 25;
            this.label5.Text = "الكمية";
            // 
            // txtamount
            // 
            this.txtamount.Allowcomma = true;
            this.txtamount.Location = new System.Drawing.Point(18, 261);
            this.txtamount.Name = "txtamount";
            this.txtamount.Size = new System.Drawing.Size(158, 22);
            this.txtamount.TabIndex = 24;
            this.txtamount.Tag = "الكمية";
            this.txtamount.Text = "1";
            // 
            // settingoControl1
            // 
            this.settingoControl1.enableAll = true;
            this.settingoControl1.isBasecType = false;
            this.settingoControl1.Location = new System.Drawing.Point(12, 141);
            this.settingoControl1.Name = "settingoControl1";
            this.settingoControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.settingoControl1.Size = new System.Drawing.Size(213, 47);
            this.settingoControl1.TabIndex = 27;
            this.settingoControl1.TheTextBoxContinerTheAmoutn = this.txtamount;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Location = new System.Drawing.Point(15, 194);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(151, 36);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "سـعر البـيـع";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(18, 14);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(57, 18);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "مفرق";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(83, 14);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(55, 18);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "جملة";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // btnaction
            // 
            this.btnaction.Location = new System.Drawing.Point(15, 289);
            this.btnaction.Name = "btnaction";
            this.btnaction.Size = new System.Drawing.Size(207, 23);
            this.btnaction.TabIndex = 28;
            this.btnaction.Text = "اضافة ";
            this.btnaction.UseVisualStyleBackColor = true;
            this.btnaction.Click += new System.EventHandler(this.btnaction_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(12, 457);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(207, 23);
            this.button1.TabIndex = 29;
            this.button1.Text = "بـــيــع الـــكل";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numbertextbox1
            // 
            this.numbertextbox1.Allowcomma = true;
            this.numbertextbox1.Location = new System.Drawing.Point(43, 348);
            this.numbertextbox1.Name = "numbertextbox1";
            this.numbertextbox1.ReadOnly = true;
            this.numbertextbox1.Size = new System.Drawing.Size(158, 22);
            this.numbertextbox1.TabIndex = 30;
            this.numbertextbox1.Tag = "الكمية";
            this.numbertextbox1.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 331);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 14);
            this.label3.TabIndex = 31;
            this.label3.Text = "المبلغ الكلي ل.س";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 373);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 14);
            this.label4.TabIndex = 33;
            this.label4.Text = "المبلغ  المدفوع ل.س";
            // 
            // numbertextbox2
            // 
            this.numbertextbox2.Allowcomma = true;
            this.numbertextbox2.Location = new System.Drawing.Point(40, 390);
            this.numbertextbox2.Name = "numbertextbox2";
            this.numbertextbox2.Size = new System.Drawing.Size(158, 22);
            this.numbertextbox2.TabIndex = 32;
            this.numbertextbox2.Tag = "الكمية";
            this.numbertextbox2.Text = "0";
            this.numbertextbox2.TextChanged += new System.EventHandler(this.numbertextbox2_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.arabicUnit,
            this.typeNameDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.toTalPriceDataGridViewTextBoxColumn,
            this.clientNameDataGridViewTextBoxColumn,
            this.stayingPriceDataGridViewTextBoxColumn,
            this.clientIdDataGridViewTextBoxColumn,
            this.paidMoneyDataGridViewTextBoxColumn,
            this.theUnitDataGridViewTextBoxColumn,
            this.typeIdDataGridViewTextBoxColumn,
            this.orAddedDateDataGridViewTextBoxColumn,
            this.detailsDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.addedDateDataGridViewTextBoxColumn,
            this.iDDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.clientDealBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(237, 141);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(555, 347);
            this.dataGridView1.TabIndex = 34;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.DataSourceChanged += new System.EventHandler(this.dataGridView1_DataSourceChanged);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // arabicUnit
            // 
            this.arabicUnit.DataPropertyName = "ArabicUnit";
            this.arabicUnit.HeaderText = "الوحدة";
            this.arabicUnit.Name = "arabicUnit";
            this.arabicUnit.Width = 111;
            // 
            // typeNameDataGridViewTextBoxColumn
            // 
            this.typeNameDataGridViewTextBoxColumn.DataPropertyName = "TypeName";
            this.typeNameDataGridViewTextBoxColumn.HeaderText = "الصنف";
            this.typeNameDataGridViewTextBoxColumn.Name = "typeNameDataGridViewTextBoxColumn";
            this.typeNameDataGridViewTextBoxColumn.Width = 111;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "سعر الصنف";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.Width = 111;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "العدد";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.Width = 111;
            // 
            // toTalPriceDataGridViewTextBoxColumn
            // 
            this.toTalPriceDataGridViewTextBoxColumn.DataPropertyName = "ToTalPrice";
            this.toTalPriceDataGridViewTextBoxColumn.HeaderText = "اجمالي السعر";
            this.toTalPriceDataGridViewTextBoxColumn.Name = "toTalPriceDataGridViewTextBoxColumn";
            this.toTalPriceDataGridViewTextBoxColumn.Width = 111;
            // 
            // clientNameDataGridViewTextBoxColumn
            // 
            this.clientNameDataGridViewTextBoxColumn.DataPropertyName = "ClientName";
            this.clientNameDataGridViewTextBoxColumn.HeaderText = "ClientName";
            this.clientNameDataGridViewTextBoxColumn.Name = "clientNameDataGridViewTextBoxColumn";
            this.clientNameDataGridViewTextBoxColumn.Visible = false;
            // 
            // stayingPriceDataGridViewTextBoxColumn
            // 
            this.stayingPriceDataGridViewTextBoxColumn.DataPropertyName = "StayingPrice";
            this.stayingPriceDataGridViewTextBoxColumn.HeaderText = "StayingPrice";
            this.stayingPriceDataGridViewTextBoxColumn.Name = "stayingPriceDataGridViewTextBoxColumn";
            this.stayingPriceDataGridViewTextBoxColumn.Visible = false;
            // 
            // clientIdDataGridViewTextBoxColumn
            // 
            this.clientIdDataGridViewTextBoxColumn.DataPropertyName = "ClientId";
            this.clientIdDataGridViewTextBoxColumn.HeaderText = "ClientId";
            this.clientIdDataGridViewTextBoxColumn.Name = "clientIdDataGridViewTextBoxColumn";
            this.clientIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // paidMoneyDataGridViewTextBoxColumn
            // 
            this.paidMoneyDataGridViewTextBoxColumn.DataPropertyName = "PaidMoney";
            this.paidMoneyDataGridViewTextBoxColumn.HeaderText = "PaidMoney";
            this.paidMoneyDataGridViewTextBoxColumn.Name = "paidMoneyDataGridViewTextBoxColumn";
            this.paidMoneyDataGridViewTextBoxColumn.Visible = false;
            // 
            // theUnitDataGridViewTextBoxColumn
            // 
            this.theUnitDataGridViewTextBoxColumn.DataPropertyName = "TheUnit";
            this.theUnitDataGridViewTextBoxColumn.HeaderText = "TheUnit";
            this.theUnitDataGridViewTextBoxColumn.Name = "theUnitDataGridViewTextBoxColumn";
            this.theUnitDataGridViewTextBoxColumn.Visible = false;
            // 
            // typeIdDataGridViewTextBoxColumn
            // 
            this.typeIdDataGridViewTextBoxColumn.DataPropertyName = "TypeId";
            this.typeIdDataGridViewTextBoxColumn.HeaderText = "TypeId";
            this.typeIdDataGridViewTextBoxColumn.Name = "typeIdDataGridViewTextBoxColumn";
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
            this.detailsDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Visible = false;
            // 
            // addedDateDataGridViewTextBoxColumn
            // 
            this.addedDateDataGridViewTextBoxColumn.DataPropertyName = "AddedDate";
            this.addedDateDataGridViewTextBoxColumn.HeaderText = "AddedDate";
            this.addedDateDataGridViewTextBoxColumn.Name = "addedDateDataGridViewTextBoxColumn";
            this.addedDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // clientDealBindingSource
            // 
            this.clientDealBindingSource.DataSource = typeof(WeightsOrganizer.BLL.ClientDeal);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(21, 87);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(118, 18);
            this.checkBox1.TabIndex = 36;
            this.checkBox1.Text = "حدد الزبون العام";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(58, 412);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 14);
            this.label7.TabIndex = 41;
            this.label7.Text = "النقد من يد الزبون";
            // 
            // handclnt
            // 
            this.handclnt.Allowcomma = true;
            this.handclnt.Location = new System.Drawing.Point(40, 430);
            this.handclnt.Name = "handclnt";
            this.handclnt.Size = new System.Drawing.Size(158, 22);
            this.handclnt.TabIndex = 40;
            this.handclnt.Tag = "المبلغ المدفوع";
            this.handclnt.Text = "0";
            this.handclnt.TextChanged += new System.EventHandler(this.handclnt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 42;
            this.label2.Text = "السعر";
            // 
            // btndelcur
            // 
            this.btndelcur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btndelcur.Enabled = false;
            this.btndelcur.Location = new System.Drawing.Point(451, 494);
            this.btndelcur.Name = "btndelcur";
            this.btndelcur.Size = new System.Drawing.Size(198, 23);
            this.btndelcur.TabIndex = 43;
            this.btndelcur.Text = "حذف الحالي";
            this.btndelcur.UseVisualStyleBackColor = true;
            this.btndelcur.Click += new System.EventHandler(this.btndelcur_Click);
            // 
            // baraCode128vewier1
            // 
            this.baraCode128vewier1.CtrlType = this.combotypes;
            this.baraCode128vewier1.DontCatch = true;
            this.baraCode128vewier1.EnableCreate = false;
            this.baraCode128vewier1.InStore = true;
            this.baraCode128vewier1.Location = new System.Drawing.Point(253, 12);
            this.baraCode128vewier1.Name = "baraCode128vewier1";
            this.baraCode128vewier1.Size = new System.Drawing.Size(246, 116);
            this.baraCode128vewier1.TabIndex = 10001;
            // 
            // frmGroupCleinDeal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(795, 535);
            this.Controls.Add(this.baraCode128vewier1);
            this.Controls.Add(this.btndelcur);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.handclnt);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numbertextbox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numbertextbox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnaction);
            this.Controls.Add(this.settingoControl1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtamount);
            this.Controls.Add(this.combocompany);
            this.Controls.Add(this.combotypes);
            this.Controls.Add(this.label1);
            this.MinimizeBox = false;
            this.Name = "frmGroupCleinDeal";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فاتورة زبون(بيع بضاعة لزبون)";
            this.Load += new System.EventHandler(this.frmGroupCleinDeal_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientDealBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox combocompany;
        public System.Windows.Forms.ComboBox combotypes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private numbertextbox txtamount;
        private WeightsOrganizer.Controls.SettingoControl settingoControl1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button btnaction;
        private System.Windows.Forms.Button button1;
        private numbertextbox numbertextbox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private numbertextbox numbertextbox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource clientDealBindingSource;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label7;
        private numbertextbox handclnt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btndelcur;
        private WeightsOrganizer.Controls.BaraCode128vewier baraCode128vewier1;
        private System.Windows.Forms.DataGridViewTextBoxColumn arabicUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn toTalPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stayingPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paidMoneyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn theUnitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orAddedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn detailsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
    }
}
