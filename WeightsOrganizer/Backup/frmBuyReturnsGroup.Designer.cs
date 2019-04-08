namespace WeightsOrganizer
{
    partial class frmBuyReturnsGroup
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
            this.baraCode128vewier1 = new WeightsOrganizer.Controls.BaraCode128vewier();
            this.combotypes = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btndelcur = new System.Windows.Forms.Button();
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
            this.label4 = new System.Windows.Forms.Label();
            this.numbertextbox2 = new WeightsOrganizer.numbertextbox();
            this.label3 = new System.Windows.Forms.Label();
            this.numbertextbox1 = new WeightsOrganizer.numbertextbox();
            this.button1 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.btnaction = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtamount = new WeightsOrganizer.numbertextbox();
            this.combocompany = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.businesDealBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // baraCode128vewier1
            // 
            this.baraCode128vewier1.CtrlType = this.combotypes;
            this.baraCode128vewier1.DontCatch = true;
            this.baraCode128vewier1.EnableCreate = false;
            this.baraCode128vewier1.InStore = true;
            this.baraCode128vewier1.Location = new System.Drawing.Point(239, 16);
            this.baraCode128vewier1.Name = "baraCode128vewier1";
            this.baraCode128vewier1.Size = new System.Drawing.Size(251, 116);
            this.baraCode128vewier1.TabIndex = 10019;
            // 
            // combotypes
            // 
            this.combotypes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.combotypes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combotypes.FormattingEnabled = true;
            this.combotypes.Location = new System.Drawing.Point(8, 62);
            this.combotypes.Name = "combotypes";
            this.combotypes.Size = new System.Drawing.Size(158, 22);
            this.combotypes.TabIndex = 10020;
            this.combotypes.Tag = "الصنف";
            this.combotypes.SelectedIndexChanged += new System.EventHandler(this.combotypes_SelectedIndexChanged);
            this.combotypes.TextChanged += new System.EventHandler(this.numbertextbox1_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Green;
            this.label7.Location = new System.Drawing.Point(124, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 10017;
            this.label7.Text = "السعر";
            // 
            // btndelcur
            // 
            this.btndelcur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btndelcur.Enabled = false;
            this.btndelcur.Location = new System.Drawing.Point(384, 440);
            this.btndelcur.Name = "btndelcur";
            this.btndelcur.Size = new System.Drawing.Size(198, 23);
            this.btndelcur.TabIndex = 10016;
            this.btndelcur.Text = "حذف الحالي";
            this.btndelcur.UseVisualStyleBackColor = true;
            this.btndelcur.Click += new System.EventHandler(this.btndelcur_Click);
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
            this.dataGridView1.Location = new System.Drawing.Point(239, 138);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(548, 283);
            this.dataGridView1.TabIndex = 10015;
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
            this.typeNameDataGridViewTextBoxColumn.Width = 120;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "الكمية";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            this.amountDataGridViewTextBoxColumn.Width = 150;
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
            // 
            // toTalPriceDataGridViewTextBoxColumn
            // 
            this.toTalPriceDataGridViewTextBoxColumn.DataPropertyName = "ToTalPrice";
            this.toTalPriceDataGridViewTextBoxColumn.HeaderText = "السعر الاجمالي";
            this.toTalPriceDataGridViewTextBoxColumn.Name = "toTalPriceDataGridViewTextBoxColumn";
            this.toTalPriceDataGridViewTextBoxColumn.ReadOnly = true;
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
            this.businesDealBindingSource.DataSource = typeof(WeightsOrganizer.BLL.BusinesReturns);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 318);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 14);
            this.label4.TabIndex = 10014;
            this.label4.Text = "المبلغ  المدفوع ل.س";
            this.label4.Visible = false;
            // 
            // numbertextbox2
            // 
            this.numbertextbox2.Allowcomma = true;
            this.numbertextbox2.Location = new System.Drawing.Point(8, 335);
            this.numbertextbox2.Name = "numbertextbox2";
            this.numbertextbox2.Size = new System.Drawing.Size(201, 20);
            this.numbertextbox2.TabIndex = 10013;
            this.numbertextbox2.Tag = "الكمية";
            this.numbertextbox2.Text = "0";
            this.numbertextbox2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 10012;
            this.label3.Text = "المبلغ الكلي ل.س";
            // 
            // numbertextbox1
            // 
            this.numbertextbox1.Allowcomma = true;
            this.numbertextbox1.Location = new System.Drawing.Point(5, 282);
            this.numbertextbox1.Name = "numbertextbox1";
            this.numbertextbox1.ReadOnly = true;
            this.numbertextbox1.Size = new System.Drawing.Size(204, 20);
            this.numbertextbox1.TabIndex = 10011;
            this.numbertextbox1.Tag = "الكمية";
            this.numbertextbox1.Text = "0";
            this.numbertextbox1.TextChanged += new System.EventHandler(this.numbertextbox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(8, 402);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(207, 23);
            this.button1.TabIndex = 10010;
            this.button1.Text = "رد الـــكل";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Green;
            this.label13.Location = new System.Drawing.Point(89, 87);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 13);
            this.label13.TabIndex = 10018;
            this.label13.Text = "كل الشركات";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // btnaction
            // 
            this.btnaction.Location = new System.Drawing.Point(2, 220);
            this.btnaction.Name = "btnaction";
            this.btnaction.Size = new System.Drawing.Size(207, 23);
            this.btnaction.TabIndex = 10009;
            this.btnaction.Text = "اضافة ";
            this.btnaction.UseVisualStyleBackColor = true;
            this.btnaction.Click += new System.EventHandler(this.btnaction_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 14);
            this.label5.TabIndex = 10008;
            this.label5.Text = "الكمية";
            // 
            // txtamount
            // 
            this.txtamount.Allowcomma = true;
            this.txtamount.Location = new System.Drawing.Point(5, 175);
            this.txtamount.Name = "txtamount";
            this.txtamount.Size = new System.Drawing.Size(158, 20);
            this.txtamount.TabIndex = 10007;
            this.txtamount.Tag = "الكمية";
            this.txtamount.Text = "20";
            // 
            // combocompany
            // 
            this.combocompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.combocompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combocompany.FormattingEnabled = true;
            this.combocompany.Location = new System.Drawing.Point(8, 110);
            this.combocompany.Name = "combocompany";
            this.combocompany.Size = new System.Drawing.Size(158, 22);
            this.combocompany.TabIndex = 10006;
            this.combocompany.Tag = "الزبون";
            this.combocompany.SelectedIndexChanged += new System.EventHandler(this.combocompany_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 14);
            this.label2.TabIndex = 10005;
            this.label2.Text = "التاجر";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 10004;
            this.label1.Text = "الصنف او النوع";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(53, 353);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(79, 18);
            this.checkBox1.TabIndex = 10022;
            this.checkBox1.Text = "انقاص حساب ";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Green;
            this.label6.Location = new System.Drawing.Point(89, 377);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 14);
            this.label6.TabIndex = 10021;
            this.label6.Text = "..";
            // 
            // frmBuyReturnsGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(788, 493);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.combotypes);
            this.Controls.Add(this.baraCode128vewier1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btndelcur);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numbertextbox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numbertextbox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnaction);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtamount);
            this.Controls.Add(this.combocompany);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmBuyReturnsGroup";
            this.Text = "مردود المشتريات";
            this.Load += new System.EventHandler(this.frmBuyReturnsGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.businesDealBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WeightsOrganizer.Controls.BaraCode128vewier baraCode128vewier1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btndelcur;
        private System.Windows.Forms.DataGridView dataGridView1;
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
        private System.Windows.Forms.BindingSource businesDealBindingSource;
        private System.Windows.Forms.Label label4;
        private numbertextbox numbertextbox2;
        private System.Windows.Forms.Label label3;
        private numbertextbox numbertextbox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnaction;
        private System.Windows.Forms.Label label5;
        private numbertextbox txtamount;
        private System.Windows.Forms.ComboBox combocompany;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox combotypes;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label6;
    }
}
