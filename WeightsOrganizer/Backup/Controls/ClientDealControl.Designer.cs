using System.Windows.Forms;
namespace WeightsOrganizer.Controls
{
    partial class ClientDealControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.handclnt = new WeightsOrganizer.numbertextbox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.settingoControl1 = new WeightsOrganizer.Controls.SettingoControl();
            this.txtamount = new WeightsOrganizer.numbertextbox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.lblid = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtpaidmny = new WeightsOrganizer.numbertextbox();
            this.btnnew = new System.Windows.Forms.Button();
            this.btnaction = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtdet = new System.Windows.Forms.TextBox();
            this.txtclntprice = new WeightsOrganizer.numbertextbox();
            this.combocompany = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.combotypes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeName = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ManName = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ClientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArabicUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detailsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToTalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaidMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StayingPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priceo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TheUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientDealBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.infooToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.baraCode128vewier1 = new WeightsOrganizer.Controls.BaraCode128vewier();
            this.typesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.companyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientDealBindingSource)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.typesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.handclnt);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.settingoControl1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.lblid);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtpaidmny);
            this.groupBox1.Controls.Add(this.btnnew);
            this.groupBox1.Controls.Add(this.btnaction);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtdet);
            this.groupBox1.Controls.Add(this.txtclntprice);
            this.groupBox1.Controls.Add(this.combocompany);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtamount);
            this.groupBox1.Controls.Add(this.combotypes);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(596, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(201, 576);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "صفقة  بيع لزبون";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(93, 350);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "النقد من يد الزبون";
            // 
            // handclnt
            // 
            this.handclnt.Allowcomma = true;
            this.handclnt.Location = new System.Drawing.Point(25, 366);
            this.handclnt.Name = "handclnt";
            this.handclnt.Size = new System.Drawing.Size(158, 20);
            this.handclnt.TabIndex = 8;
            this.handclnt.Tag = "يد الزبون";
            this.handclnt.Text = "0";
            this.handclnt.TextChanged += new System.EventHandler(this.handclnt_TextChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(21, 72);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(98, 17);
            this.checkBox1.TabIndex = 37;
            this.checkBox1.Text = "حدد الزبون العام";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 527);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "فـــــاتـــورة زبـــون";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(141, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "الكمية";
            // 
            // settingoControl1
            // 
            this.settingoControl1.enableAll = true;
            this.settingoControl1.isBasecType = false;
            this.settingoControl1.Location = new System.Drawing.Point(12, 119);
            this.settingoControl1.Name = "settingoControl1";
            this.settingoControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.settingoControl1.Size = new System.Drawing.Size(183, 44);
            this.settingoControl1.TabIndex = 3;
            this.settingoControl1.TheTextBoxContinerTheAmoutn = this.txtamount;
            this.settingoControl1.Load += new System.EventHandler(this.settingoControl1_Load);
            // 
            // txtamount
            // 
            this.txtamount.Allowcomma = false;
            this.txtamount.Location = new System.Drawing.Point(21, 184);
            this.txtamount.Name = "txtamount";
            this.txtamount.Size = new System.Drawing.Size(158, 20);
            this.txtamount.TabIndex = 4;
            this.txtamount.Tag = "الكمية";
            this.txtamount.Text = "2";
            this.txtamount.TextChanged += new System.EventHandler(this.txtclntprice_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "سعر البيع";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Location = new System.Drawing.Point(28, 213);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(151, 36);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "سـعر البـيـع";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(18, 14);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(48, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "مفرق";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(83, 14);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(45, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "جملة";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Location = new System.Drawing.Point(12, 166);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(13, 13);
            this.lblid.TabIndex = 16;
            this.lblid.Text = "0";
            this.lblid.Visible = false;
            this.lblid.TextChanged += new System.EventHandler(this.lblid_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(30, 311);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "المدفوع";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(137, 311);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "المدفوع";
            // 
            // txtpaidmny
            // 
            this.txtpaidmny.Allowcomma = true;
            this.txtpaidmny.Location = new System.Drawing.Point(25, 327);
            this.txtpaidmny.Name = "txtpaidmny";
            this.txtpaidmny.Size = new System.Drawing.Size(158, 20);
            this.txtpaidmny.TabIndex = 7;
            this.txtpaidmny.Tag = "المبلغ المدفوع";
            this.txtpaidmny.Text = "0";
            this.txtpaidmny.TextChanged += new System.EventHandler(this.txtpaidmny_TextChanged);
            this.txtpaidmny.Enter += new System.EventHandler(this.txtpaidmny_Enter);
            // 
            // btnnew
            // 
            this.btnnew.Location = new System.Drawing.Point(23, 500);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(159, 23);
            this.btnnew.TabIndex = 12;
            this.btnnew.Text = "جديد";
            this.btnnew.UseVisualStyleBackColor = true;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // btnaction
            // 
            this.btnaction.Location = new System.Drawing.Point(24, 471);
            this.btnaction.Name = "btnaction";
            this.btnaction.Size = new System.Drawing.Size(158, 23);
            this.btnaction.TabIndex = 10;
            this.btnaction.Text = "اضافة الصفقة";
            this.btnaction.UseVisualStyleBackColor = true;
            this.btnaction.Click += new System.EventHandler(this.btnaction_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(84, 391);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "تفاصيل عن الصفقة";
            // 
            // txtdet
            // 
            this.txtdet.Location = new System.Drawing.Point(19, 408);
            this.txtdet.Multiline = true;
            this.txtdet.Name = "txtdet";
            this.txtdet.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtdet.Size = new System.Drawing.Size(160, 57);
            this.txtdet.TabIndex = 9;
            this.txtdet.Tag = "تفاصيل";
            // 
            // txtclntprice
            // 
            this.txtclntprice.Allowcomma = true;
            this.txtclntprice.Location = new System.Drawing.Point(23, 277);
            this.txtclntprice.Name = "txtclntprice";
            this.txtclntprice.Size = new System.Drawing.Size(158, 20);
            this.txtclntprice.TabIndex = 6;
            this.txtclntprice.Tag = "سعر المبيع";
            this.txtclntprice.Text = "0";
            this.txtclntprice.TextChanged += new System.EventHandler(this.txtclntprice_TextChanged);
            // 
            // combocompany
            // 
            this.combocompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.combocompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combocompany.FormattingEnabled = true;
            this.combocompany.Location = new System.Drawing.Point(19, 92);
            this.combocompany.Name = "combocompany";
            this.combocompany.Size = new System.Drawing.Size(158, 21);
            this.combocompany.TabIndex = 1;
            this.combocompany.Tag = "الزبون";
            this.combocompany.TextChanged += new System.EventHandler(this.txtclntprice_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "الزبون";
            // 
            // combotypes
            // 
            this.combotypes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.combotypes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combotypes.FormattingEnabled = true;
            this.combotypes.Location = new System.Drawing.Point(19, 43);
            this.combotypes.Name = "combotypes";
            this.combotypes.Size = new System.Drawing.Size(158, 21);
            this.combotypes.TabIndex = 0;
            this.combotypes.Tag = "الصنف";
            this.combotypes.SelectedIndexChanged += new System.EventHandler(this.combotypes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
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
            this.iDDataGridViewTextBoxColumn,
            this.typeIdDataGridViewTextBoxColumn,
            this.TypeName,
            this.ManName,
            this.ClientId,
            this.amountDataGridViewTextBoxColumn,
            this.ArabicUnit,
            this.detailsDataGridViewTextBoxColumn,
            this.addedDateDataGridViewTextBoxColumn,
            this.ToTalPrice,
            this.PaidMoney,
            this.StayingPrice,
            this.Priceo,
            this.TheUnit});
            this.dataGridView1.DataSource = this.ClientDealBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(14, 126);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(576, 468);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            this.iDDataGridViewTextBoxColumn.Width = 5;
            // 
            // typeIdDataGridViewTextBoxColumn
            // 
            this.typeIdDataGridViewTextBoxColumn.DataPropertyName = "TypeId";
            this.typeIdDataGridViewTextBoxColumn.HeaderText = "الصنف(النوع)";
            this.typeIdDataGridViewTextBoxColumn.Name = "typeIdDataGridViewTextBoxColumn";
            this.typeIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeIdDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.typeIdDataGridViewTextBoxColumn.Visible = false;
            this.typeIdDataGridViewTextBoxColumn.Width = 140;
            // 
            // TypeName
            // 
            this.TypeName.DataPropertyName = "TypeName";
            this.TypeName.HeaderText = "الصنف(النوع)";
            this.TypeName.Name = "TypeName";
            this.TypeName.ReadOnly = true;
            this.TypeName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TypeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.TypeName.ToolTipText = "الصنف(النوع)";
            this.TypeName.Width = 150;
            // 
            // ManName
            // 
            this.ManName.DataPropertyName = "ClientName";
            this.ManName.HeaderText = "الزبون";
            this.ManName.Name = "ManName";
            this.ManName.ReadOnly = true;
            this.ManName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ManName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ManName.ToolTipText = "المشتري";
            this.ManName.Width = 150;
            // 
            // ClientId
            // 
            this.ClientId.DataPropertyName = "ClientId";
            this.ClientId.HeaderText = "ClientId";
            this.ClientId.Name = "ClientId";
            this.ClientId.ReadOnly = true;
            this.ClientId.Visible = false;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "الكمية";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ArabicUnit
            // 
            this.ArabicUnit.DataPropertyName = "ArabicUnit";
            this.ArabicUnit.HeaderText = "الوحدة";
            this.ArabicUnit.Name = "ArabicUnit";
            this.ArabicUnit.ReadOnly = true;
            this.ArabicUnit.ToolTipText = "الوحدة المستخدمة في المبيع";
            // 
            // detailsDataGridViewTextBoxColumn
            // 
            this.detailsDataGridViewTextBoxColumn.DataPropertyName = "Details";
            this.detailsDataGridViewTextBoxColumn.HeaderText = "تفاصيل ";
            this.detailsDataGridViewTextBoxColumn.Name = "detailsDataGridViewTextBoxColumn";
            this.detailsDataGridViewTextBoxColumn.ReadOnly = true;
            this.detailsDataGridViewTextBoxColumn.ToolTipText = "متعلقة بحدث الشراء هذا";
            this.detailsDataGridViewTextBoxColumn.Width = 150;
            // 
            // addedDateDataGridViewTextBoxColumn
            // 
            this.addedDateDataGridViewTextBoxColumn.DataPropertyName = "AddedDate";
            this.addedDateDataGridViewTextBoxColumn.HeaderText = "التاريخ";
            this.addedDateDataGridViewTextBoxColumn.Name = "addedDateDataGridViewTextBoxColumn";
            this.addedDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.addedDateDataGridViewTextBoxColumn.Width = 130;
            // 
            // ToTalPrice
            // 
            this.ToTalPrice.DataPropertyName = "ToTalPrice";
            this.ToTalPrice.HeaderText = "اجمالي السعر ل.س";
            this.ToTalPrice.Name = "ToTalPrice";
            this.ToTalPrice.ReadOnly = true;
            this.ToTalPrice.ToolTipText = "ل.س";
            // 
            // PaidMoney
            // 
            this.PaidMoney.DataPropertyName = "PaidMoney";
            this.PaidMoney.HeaderText = "المدفوع ل.س";
            this.PaidMoney.Name = "PaidMoney";
            this.PaidMoney.ReadOnly = true;
            this.PaidMoney.ToolTipText = "ل.س";
            this.PaidMoney.Visible = false;
            // 
            // StayingPrice
            // 
            this.StayingPrice.DataPropertyName = "StayingPrice";
            this.StayingPrice.HeaderText = "الباقي ل.س";
            this.StayingPrice.Name = "StayingPrice";
            this.StayingPrice.ReadOnly = true;
            this.StayingPrice.ToolTipText = "ل.س";
            this.StayingPrice.Visible = false;
            // 
            // Priceo
            // 
            this.Priceo.DataPropertyName = "Price";
            this.Priceo.HeaderText = "السعر";
            this.Priceo.Name = "Priceo";
            this.Priceo.ReadOnly = true;
            // 
            // TheUnit
            // 
            this.TheUnit.DataPropertyName = "TheUnit";
            this.TheUnit.HeaderText = "TheUnit";
            this.TheUnit.Name = "TheUnit";
            this.TheUnit.ReadOnly = true;
            this.TheUnit.Visible = false;
            // 
            // ClientDealBindingSource
            // 
            this.ClientDealBindingSource.DataSource = typeof(WeightsOrganizer.BLL.ClientDeal);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infooToolStripMenuItem,
            this.accoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(103, 48);
            // 
            // infooToolStripMenuItem
            // 
            this.infooToolStripMenuItem.Name = "infooToolStripMenuItem";
            this.infooToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.infooToolStripMenuItem.Text = "infoo";
            this.infooToolStripMenuItem.Click += new System.EventHandler(this.infooToolStripMenuItem_Click);
            // 
            // accoToolStripMenuItem
            // 
            this.accoToolStripMenuItem.Name = "accoToolStripMenuItem";
            this.accoToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.accoToolStripMenuItem.Text = "acco";
            this.accoToolStripMenuItem.Click += new System.EventHandler(this.accoToolStripMenuItem_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "TheUnit";
            this.dataGridViewTextBoxColumn1.HeaderText = "TheUnit";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TheUnit";
            this.dataGridViewTextBoxColumn2.HeaderText = "TheUnit";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(10, 32);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(172, 20);
            this.dateTimePicker1.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(77, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 19);
            this.label4.TabIndex = 22;
            this.label4.Text = "التاريخ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(465, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 19);
            this.label8.TabIndex = 22;
            this.label8.Text = "مبيعات اليوم";
            this.label8.Click += new System.EventHandler(this.label4_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(479, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 19);
            this.label9.TabIndex = 22;
            this.label9.Text = "التاريخ";
            this.label9.Click += new System.EventHandler(this.label4_Click);
            // 
            // baraCode128vewier1
            // 
            this.baraCode128vewier1.CtrlType = this.combotypes;
            this.baraCode128vewier1.DontCatch = true;
            this.baraCode128vewier1.EnableCreate = false;
            this.baraCode128vewier1.InStore = true;
            this.baraCode128vewier1.Location = new System.Drawing.Point(234, 4);
            this.baraCode128vewier1.Name = "baraCode128vewier1";
            this.baraCode128vewier1.Size = new System.Drawing.Size(236, 116);
            this.baraCode128vewier1.TabIndex = 15;
            this.baraCode128vewier1.Load += new System.EventHandler(this.baraCode128vewier1_Load);
            // 
            // typesBindingSource
            // 
            this.typesBindingSource.DataSource = typeof(WeightsOrganizer.BLL.Types);
            // 
            // companyBindingSource
            // 
            this.companyBindingSource.DataSource = typeof(WeightsOrganizer.BLL.Company);
            // 
            // ClientDealControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.baraCode128vewier1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Name = "ClientDealControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(800, 610);
            this.Load += new System.EventHandler(this.ClientDealControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientDealBindingSource)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.typesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource ClientDealBindingSource ;
        private System.Windows.Forms.BindingSource typesBindingSource;
        private System.Windows.Forms.BindingSource companyBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combocompany;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnaction;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtdet;
        private System.Windows.Forms.Button btnnew;
        private System.Windows.Forms.Label lblid;
        private numbertextbox txtamount;
        private numbertextbox txtclntprice;
        private System.Windows.Forms.Label label10;
        private numbertextbox txtpaidmny;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.ComboBox combotypes;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label3;
        private SettingoControl settingoControl1;
        private System.Windows.Forms.Label label5;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem infooToolStripMenuItem;
        private ToolStripMenuItem accoToolStripMenuItem;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private Button button1;
        private CheckBox checkBox1;
        private Label label7;
        private numbertextbox handclnt;
        private BaraCode128vewier baraCode128vewier1;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn typeIdDataGridViewTextBoxColumn;
        private DataGridViewLinkColumn TypeName;
        private DataGridViewLinkColumn ManName;
        private DataGridViewTextBoxColumn ClientId;
        private DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ArabicUnit;
        private DataGridViewTextBoxColumn detailsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn addedDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ToTalPrice;
        private DataGridViewTextBoxColumn PaidMoney;
        private DataGridViewTextBoxColumn StayingPrice;
        private DataGridViewTextBoxColumn Priceo;
        private DataGridViewTextBoxColumn TheUnit;
        private DateTimePicker dateTimePicker1;
        private Label label4;
        private Label label8;
        private Label label9;
    }
}
