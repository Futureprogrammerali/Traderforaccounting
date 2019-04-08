namespace WeightsOrganizer
{
    partial class SalePointFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numbertextbox1 = new WeightsOrganizer.numbertextbox();
            this.baraCode128vewier1 = new WeightsOrganizer.Controls.BaraCode128vewier();
            this.combotypes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.settingoControl1 = new WeightsOrganizer.Controls.SettingoControl();
            this.label1 = new System.Windows.Forms.Label();
            this.combocompany = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnsubfast = new System.Windows.Forms.Button();
            this.btnaddfast = new System.Windows.Forms.Button();
            this.btnnew = new System.Windows.Forms.Button();
            this.lblallprice = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.deltype = new System.Windows.Forms.Button();
            this.txtallprice = new WeightsOrganizer.numbertextbox();
            this.addtype = new System.Windows.Forms.Button();
            this.btnsale = new System.Windows.Forms.Button();
            this.ClientDealBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priceo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToTalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArabicUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TheUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientDealBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numbertextbox1);
            this.groupBox1.Controls.Add(this.baraCode128vewier1);
            this.groupBox1.Controls.Add(this.combotypes);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.settingoControl1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.combocompany);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(891, 146);
            this.groupBox1.TabIndex = 10001;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(8, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(153, 114);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(310, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 14);
            this.label4.TabIndex = 29;
            this.label4.Text = "الكمية";
            // 
            // numbertextbox1
            // 
            this.numbertextbox1.Allowcomma = false;
            this.numbertextbox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numbertextbox1.Location = new System.Drawing.Point(167, 114);
            this.numbertextbox1.Name = "numbertextbox1";
            this.numbertextbox1.Size = new System.Drawing.Size(122, 22);
            this.numbertextbox1.TabIndex = 19;
            this.numbertextbox1.Text = "1";
            this.numbertextbox1.TextChanged += new System.EventHandler(this.numbertextbox1_TextChanged);
            // 
            // baraCode128vewier1
            // 
            this.baraCode128vewier1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.baraCode128vewier1.CtrlType = this.combotypes;
            this.baraCode128vewier1.DontCatch = true;
            this.baraCode128vewier1.EnableCreate = false;
            this.baraCode128vewier1.InStore = true;
            this.baraCode128vewier1.Location = new System.Drawing.Point(594, 15);
            this.baraCode128vewier1.Name = "baraCode128vewier1";
            this.baraCode128vewier1.Size = new System.Drawing.Size(275, 125);
            this.baraCode128vewier1.TabIndex = 16;
            // 
            // combotypes
            // 
            this.combotypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combotypes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.combotypes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combotypes.FormattingEnabled = true;
            this.combotypes.Location = new System.Drawing.Point(167, 39);
            this.combotypes.Name = "combotypes";
            this.combotypes.Size = new System.Drawing.Size(221, 22);
            this.combotypes.TabIndex = 9;
            this.combotypes.Tag = "الصنف";
            this.combotypes.SelectedIndexChanged += new System.EventHandler(this.combotypes_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "الصنف او المادة:";
            // 
            // settingoControl1
            // 
            this.settingoControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.settingoControl1.enableAll = true;
            this.settingoControl1.isBasecType = false;
            this.settingoControl1.Location = new System.Drawing.Point(167, 67);
            this.settingoControl1.Name = "settingoControl1";
            this.settingoControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.settingoControl1.Size = new System.Drawing.Size(221, 47);
            this.settingoControl1.TabIndex = 4;
            this.settingoControl1.TheTextBoxContinerTheAmoutn = null;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(476, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "الـحـسـاب";
            // 
            // combocompany
            // 
            this.combocompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combocompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.combocompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combocompany.FormattingEnabled = true;
            this.combocompany.Location = new System.Drawing.Point(403, 39);
            this.combocompany.Name = "combocompany";
            this.combocompany.Size = new System.Drawing.Size(171, 22);
            this.combocompany.TabIndex = 2;
            this.combocompany.Tag = "الزبون";
            this.combocompany.SelectedIndexChanged += new System.EventHandler(this.combocompany_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Location = new System.Drawing.Point(408, 91);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(171, 45);
            this.groupBox3.TabIndex = 6;
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
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
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
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(262, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 19);
            this.label5.TabIndex = 30;
            this.label5.Text = "عدد البنود ";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnsubfast);
            this.groupBox2.Controls.Add(this.btnaddfast);
            this.groupBox2.Controls.Add(this.btnnew);
            this.groupBox2.Controls.Add(this.lblallprice);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.deltype);
            this.groupBox2.Controls.Add(this.txtallprice);
            this.groupBox2.Controls.Add(this.addtype);
            this.groupBox2.Controls.Add(this.btnsale);
            this.groupBox2.Location = new System.Drawing.Point(15, 483);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(891, 92);
            this.groupBox2.TabIndex = 10002;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "الدفع  ";
            // 
            // btnsubfast
            // 
            this.btnsubfast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsubfast.Enabled = false;
            this.btnsubfast.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsubfast.Image = global::WeightsOrganizer.Properties.Resources.sub;
            this.btnsubfast.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsubfast.Location = new System.Drawing.Point(170, 34);
            this.btnsubfast.Name = "btnsubfast";
            this.btnsubfast.Size = new System.Drawing.Size(75, 48);
            this.btnsubfast.TabIndex = 31;
            this.btnsubfast.Text = "F4";
            this.btnsubfast.UseVisualStyleBackColor = true;
            this.btnsubfast.Click += new System.EventHandler(this.btnsubfast_Click);
            // 
            // btnaddfast
            // 
            this.btnaddfast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnaddfast.Enabled = false;
            this.btnaddfast.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaddfast.Image = global::WeightsOrganizer.Properties.Resources.add;
            this.btnaddfast.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnaddfast.Location = new System.Drawing.Point(270, 34);
            this.btnaddfast.Name = "btnaddfast";
            this.btnaddfast.Size = new System.Drawing.Size(75, 48);
            this.btnaddfast.TabIndex = 30;
            this.btnaddfast.Text = "\r\nF3";
            this.btnaddfast.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnaddfast.UseVisualStyleBackColor = true;
            this.btnaddfast.Click += new System.EventHandler(this.btnaddfast_Click);
            // 
            // btnnew
            // 
            this.btnnew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnnew.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnew.Image = global::WeightsOrganizer.Properties.Resources.clean;
            this.btnnew.Location = new System.Drawing.Point(6, 13);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(158, 73);
            this.btnnew.TabIndex = 29;
            this.btnnew.Text = "فاتورة جديدة\r\nF5";
            this.btnnew.UseVisualStyleBackColor = true;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // lblallprice
            // 
            this.lblallprice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblallprice.AutoSize = true;
            this.lblallprice.Location = new System.Drawing.Point(725, 64);
            this.lblallprice.Name = "lblallprice";
            this.lblallprice.Size = new System.Drawing.Size(14, 14);
            this.lblallprice.TabIndex = 28;
            this.lblallprice.Text = "0";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(791, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 14);
            this.label3.TabIndex = 27;
            this.label3.Text = "المبلغ ل . س";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(323, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 14);
            this.label6.TabIndex = 25;
            this.label6.Text = "مــواد الـفـاتـورة";
            // 
            // deltype
            // 
            this.deltype.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deltype.Enabled = false;
            this.deltype.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deltype.Image = global::WeightsOrganizer.Properties.Resources.delete;
            this.deltype.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deltype.Location = new System.Drawing.Point(351, 34);
            this.deltype.Name = "deltype";
            this.deltype.Size = new System.Drawing.Size(75, 48);
            this.deltype.TabIndex = 24;
            this.deltype.Text = "F2";
            this.deltype.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deltype.UseVisualStyleBackColor = true;
            this.deltype.Click += new System.EventHandler(this.deltype_Click);
            // 
            // txtallprice
            // 
            this.txtallprice.Allowcomma = false;
            this.txtallprice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtallprice.Location = new System.Drawing.Point(681, 26);
            this.txtallprice.Name = "txtallprice";
            this.txtallprice.Size = new System.Drawing.Size(199, 22);
            this.txtallprice.TabIndex = 18;
            this.txtallprice.TextChanged += new System.EventHandler(this.txtallprice_TextChanged);
            // 
            // addtype
            // 
            this.addtype.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addtype.Enabled = false;
            this.addtype.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addtype.Image = global::WeightsOrganizer.Properties.Resources.insert;
            this.addtype.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addtype.Location = new System.Drawing.Point(427, 34);
            this.addtype.Name = "addtype";
            this.addtype.Size = new System.Drawing.Size(80, 48);
            this.addtype.TabIndex = 17;
            this.addtype.Text = "F1";
            this.addtype.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addtype.UseVisualStyleBackColor = true;
            this.addtype.Click += new System.EventHandler(this.addtype_Click);
            // 
            // btnsale
            // 
            this.btnsale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsale.Enabled = false;
            this.btnsale.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsale.ForeColor = System.Drawing.Color.Red;
            this.btnsale.Image = global::WeightsOrganizer.Properties.Resources.save;
            this.btnsale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsale.Location = new System.Drawing.Point(521, 34);
            this.btnsale.Name = "btnsale";
            this.btnsale.Size = new System.Drawing.Size(80, 48);
            this.btnsale.TabIndex = 2;
            this.btnsale.Tag = "";
            this.btnsale.Text = "F12";
            this.btnsale.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnsale.UseVisualStyleBackColor = true;
            this.btnsale.Click += new System.EventHandler(this.btnsale_Click);
            // 
            // ClientDealBindingSource
            // 
            this.ClientDealBindingSource.DataSource = typeof(WeightsOrganizer.BLL.ClientDeal);
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
            this.TypeName,
            this.amountDataGridViewTextBoxColumn,
            this.Priceo,
            this.ToTalPrice,
            this.ArabicUnit,
            this.ClientId,
            this.TheUnit,
            this.TypeId});
            this.dataGridView1.DataSource = this.ClientDealBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(15, 179);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Size = new System.Drawing.Size(888, 297);
            this.dataGridView1.TabIndex = 10003;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.DataSourceChanged += new System.EventHandler(this.dataGridView1_DataSourceChanged);
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
            // TypeName
            // 
            this.TypeName.DataPropertyName = "TypeName";
            this.TypeName.HeaderText = "الصنف";
            this.TypeName.Name = "TypeName";
            this.TypeName.ReadOnly = true;
            this.TypeName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TypeName.ToolTipText = "الصنف(النوع)";
            this.TypeName.Width = 150;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "كمية";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Priceo
            // 
            this.Priceo.DataPropertyName = "Price";
            this.Priceo.HeaderText = "السعر";
            this.Priceo.Name = "Priceo";
            this.Priceo.ReadOnly = true;
            // 
            // ToTalPrice
            // 
            this.ToTalPrice.DataPropertyName = "ToTalPrice";
            this.ToTalPrice.HeaderText = "إجمالي ل.س";
            this.ToTalPrice.Name = "ToTalPrice";
            this.ToTalPrice.ReadOnly = true;
            this.ToTalPrice.ToolTipText = "ل.س";
            // 
            // ArabicUnit
            // 
            this.ArabicUnit.DataPropertyName = "ArabicUnit";
            this.ArabicUnit.HeaderText = "الوحدة";
            this.ArabicUnit.Name = "ArabicUnit";
            this.ArabicUnit.ReadOnly = true;
            this.ArabicUnit.ToolTipText = "الوحدة المستخدمة في المبيع";
            // 
            // ClientId
            // 
            this.ClientId.DataPropertyName = "ClientId";
            this.ClientId.HeaderText = "ClientId";
            this.ClientId.Name = "ClientId";
            this.ClientId.ReadOnly = true;
            this.ClientId.Visible = false;
            // 
            // TheUnit
            // 
            this.TheUnit.DataPropertyName = "TheUnit";
            this.TheUnit.HeaderText = "TheUnit";
            this.TheUnit.Name = "TheUnit";
            this.TheUnit.ReadOnly = true;
            this.TheUnit.Visible = false;
            // 
            // TypeId
            // 
            this.TypeId.DataPropertyName = "TypeId";
            this.TypeId.HeaderText = "TypeId";
            this.TypeId.Name = "TypeId";
            this.TypeId.ReadOnly = true;
            this.TypeId.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SalePointFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 605);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SalePointFrm";
            this.Text = "نـقـطــة بــيــع";
            this.Load += new System.EventHandler(this.SalePointFrm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SalePointFrm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientDealBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ComboBox combocompany;
        private System.Windows.Forms.Label label1;
        private WeightsOrganizer.Controls.SettingoControl settingoControl1;
        public System.Windows.Forms.ComboBox combotypes;
        private System.Windows.Forms.Label label2;
        private WeightsOrganizer.Controls.BaraCode128vewier baraCode128vewier1;
        private System.Windows.Forms.Button btnsale;
        private System.Windows.Forms.Button addtype;
        private numbertextbox txtallprice;
        private System.Windows.Forms.BindingSource ClientDealBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button deltype;
        private System.Windows.Forms.Label lblallprice;
        private System.Windows.Forms.Label label3;
        private numbertextbox numbertextbox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnnew;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priceo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToTalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArabicUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TheUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeId;
        private System.Windows.Forms.Button btnsubfast;
        private System.Windows.Forms.Button btnaddfast;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
    }
}