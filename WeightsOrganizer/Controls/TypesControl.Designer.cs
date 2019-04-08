using WeightsOrganizer.BLL;
namespace WeightsOrganizer.Controls
{
    partial class TypesControl
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


        private void myinitliaze()
        {

            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            dataGridView1.ReadOnly = true;
            this.lblid = new System.Windows.Forms.Label();
            this.lblid.Visible = false;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnnew = new System.Windows.Forms.Button();
            this.btndel = new System.Windows.Forms.Button();
            this.btnaction = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblprice = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtsrch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClientPrice = new WeightsOrganizer.numbertextbox();
            this.txtBusinessPrice = new WeightsOrganizer.numbertextbox();
   
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.businessPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BusinessClientPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            
            this.addedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.typesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.businessPriceDataGridViewTextBoxColumn,
            this.clientPriceDataGridViewTextBoxColumn,
            this.addedDateDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.typesBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(236, 76);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.Size = new System.Drawing.Size(724, 258);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.DataSourceChanged += new System.EventHandler(this.dataGridView1_DataSourceChanged);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Location = new System.Drawing.Point(34, 16);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(35, 13);
            this.lblid.TabIndex = 1;
            this.lblid.Text = "label1";
            this.lblid.TextChanged += new System.EventHandler(this.lblid_TextChanged);
            this.lblid.Click += new System.EventHandler(this.lblid_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnnew);
            this.groupBox1.Controls.Add(this.btndel);
            this.groupBox1.Controls.Add(this.btnaction);
            this.groupBox1.Controls.Add(this.txtClientPrice);
            this.groupBox1.Controls.Add(this.txtBusinessPrice);
        
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblprice);
            this.groupBox1.Controls.Add(this.lblname);
            this.groupBox1.Controls.Add(this.txtname);
            this.groupBox1.Controls.Add(this.lblid);
            this.groupBox1.Location = new System.Drawing.Point(7, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 344);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "الانواع";
            // 
            // btnnew
            // 
            this.btnnew.Location = new System.Drawing.Point(6, 284);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(208, 24);
            this.btnnew.TabIndex = 14;
            this.btnnew.Text = "جديد";
            this.btnnew.UseVisualStyleBackColor = true;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // btndel
            // 
            this.btndel.Enabled = false;
            this.btndel.Location = new System.Drawing.Point(6, 254);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(208, 24);
            this.btndel.TabIndex = 13;
            this.btndel.Text = "حذف";
            this.btndel.UseVisualStyleBackColor = true;
            this.btndel.Click += new System.EventHandler(this.btndel_Click);
 
            // 
            // btnaction
            // 
            this.btnaction.Location = new System.Drawing.Point(6, 224);
            this.btnaction.Name = "btnaction";
            this.btnaction.Size = new System.Drawing.Size(208, 24);
            this.btnaction.TabIndex = 11;
            this.btnaction.Text = "اضافة صنف";
            this.btnaction.UseVisualStyleBackColor = true;
            this.btnaction.Click += new System.EventHandler(this.btnaction_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "سعر البيع للزبائن";
            // 
            // lblprice
            // 
            this.lblprice.AutoSize = true;
            this.lblprice.Location = new System.Drawing.Point(110, 88);
            this.lblprice.Name = "lblprice";
            this.lblprice.Size = new System.Drawing.Size(107, 13);
            this.lblprice.TabIndex = 5;
            this.lblprice.Text = "سعر الشراء من التاجر";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(156, 37);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(61, 13);
            this.lblname.TabIndex = 3;
            this.lblname.Text = "اسم الصنف";
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(6, 53);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(211, 20);
            this.txtname.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtsrch);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(7, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(953, 56);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "البحث";
            // 
            // txtsrch
            // 
            this.txtsrch.Location = new System.Drawing.Point(575, 23);
            this.txtsrch.Name = "txtsrch";
            this.txtsrch.Size = new System.Drawing.Size(211, 20);
            this.txtsrch.TabIndex = 5;
            this.txtsrch.TextChanged += new System.EventHandler(this.txtsrch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(805, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "أدخل اسم النوع أو سعره :";
            // 
            // txtClientPrice
            // 
            this.txtClientPrice.Location = new System.Drawing.Point(6, 161);
            this.txtClientPrice.Name = "txtClientPrice";
            this.txtClientPrice.Size = new System.Drawing.Size(208, 20);
            this.txtClientPrice.TabIndex = 10;
            // 
            // txtBusinessPrice
            // 
            this.txtBusinessPrice.Location = new System.Drawing.Point(6, 104);
            this.txtBusinessPrice.Name = "txtBusinessPrice";
            this.txtBusinessPrice.Size = new System.Drawing.Size(208, 20);
            this.txtBusinessPrice.TabIndex = 9;

    
            
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "اسم الصنف-النوع";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 200;
            // 
            // businessPriceDataGridViewTextBoxColumn
            // 
            this.businessPriceDataGridViewTextBoxColumn.DataPropertyName = "BusinessPrice";
            this.businessPriceDataGridViewTextBoxColumn.HeaderText = "سعر  الشراء";
            this.businessPriceDataGridViewTextBoxColumn.Name = "businessPriceDataGridViewTextBoxColumn";
            // 
            // clientPriceDataGridViewTextBoxColumn
            // 
            this.clientPriceDataGridViewTextBoxColumn.DataPropertyName = "ClientPrice";
            this.clientPriceDataGridViewTextBoxColumn.HeaderText = "سعر المبيع";
            this.clientPriceDataGridViewTextBoxColumn.Name = "clientPriceDataGridViewTextBoxColumn";
            // 
            // BusinessClientPrice
            // 
            this.BusinessClientPriceDataGridViewTextBoxColumn.DataPropertyName = "ClientPrice";
            this.BusinessClientPriceDataGridViewTextBoxColumn.HeaderText = " لل جملة سعر المبيع";
            this.BusinessClientPriceDataGridViewTextBoxColumn.Name = "BusinessClientPriceDataGridViewTextBoxColumn";
            // 
            // addedDateDataGridViewTextBoxColumn
            // 
            this.addedDateDataGridViewTextBoxColumn.DataPropertyName = "AddedDate";
            this.addedDateDataGridViewTextBoxColumn.HeaderText = "تاريخ الاضافة";
            this.addedDateDataGridViewTextBoxColumn.Name = "addedDateDataGridViewTextBoxColumn";
            this.addedDateDataGridViewTextBoxColumn.Width = 200;
            // 
            // typesBindingSource
            // 
            this.typesBindingSource.DataSource = typeof(WeightsOrganizer.BLL.Types);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 430);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

            this.Text = "Form1";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.typesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.businessPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BusinessClientPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllCompanyId = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ArabicUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TheUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BaraCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblid = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.baraCode128vewier1 = new WeightsOrganizer.Controls.BaraCode128vewier();
            this.label5 = new System.Windows.Forms.Label();
            this.settingoControl1 = new WeightsOrganizer.Controls.SettingoControl();
            this.button1 = new System.Windows.Forms.Button();
            this.txtprcln = new WeightsOrganizer.numbertextbox();
            this.lblprcln = new System.Windows.Forms.Label();
            this.btnnew = new System.Windows.Forms.Button();
            this.btndel = new System.Windows.Forms.Button();
            this.btnaction = new System.Windows.Forms.Button();
            this.txtClientPrice = new WeightsOrganizer.numbertextbox();
            this.txtBusinessPrice = new WeightsOrganizer.numbertextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblprice = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtsrch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BusinessClientPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typesBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.businessPriceDataGridViewTextBoxColumn,
            this.clientPriceDataGridViewTextBoxColumn,
            this.BusinessClientPrice,
            this.addedDateDataGridViewTextBoxColumn,
            this.AllCompanyId,
            this.ArabicUnit,
            this.TheUnit,
            this.BaraCode});
            this.dataGridView1.DataSource = this.typesBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(18, 96);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.Size = new System.Drawing.Size(531, 474);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            this.dataGridView1.DataSourceChanged += new System.EventHandler(this.dataGridView1_DataSourceChanged);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "اسم الصنف-النوع";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 200;
            // 
            // businessPriceDataGridViewTextBoxColumn
            // 
            this.businessPriceDataGridViewTextBoxColumn.DataPropertyName = "BusinessPrice";
            this.businessPriceDataGridViewTextBoxColumn.HeaderText = "سعر  الشراء";
            this.businessPriceDataGridViewTextBoxColumn.Name = "businessPriceDataGridViewTextBoxColumn";
            this.businessPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clientPriceDataGridViewTextBoxColumn
            // 
            this.clientPriceDataGridViewTextBoxColumn.DataPropertyName = "ClientPrice";
            this.clientPriceDataGridViewTextBoxColumn.HeaderText = "سعر المبيع";
            this.clientPriceDataGridViewTextBoxColumn.Name = "clientPriceDataGridViewTextBoxColumn";
            this.clientPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // BusinessClientPrice
            // 
            this.BusinessClientPrice.DataPropertyName = "BusinessClientPrice";
            this.BusinessClientPrice.HeaderText = "سعر المبيع (بالجملة)";
            this.BusinessClientPrice.Name = "BusinessClientPrice";
            this.BusinessClientPrice.ReadOnly = true;
            this.BusinessClientPrice.ToolTipText = "للزبائن التجار";
            // 
            // addedDateDataGridViewTextBoxColumn
            // 
            this.addedDateDataGridViewTextBoxColumn.DataPropertyName = "AddedDate";
            this.addedDateDataGridViewTextBoxColumn.HeaderText = "تاريخ الاضافة";
            this.addedDateDataGridViewTextBoxColumn.Name = "addedDateDataGridViewTextBoxColumn";
            this.addedDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.addedDateDataGridViewTextBoxColumn.Width = 226;
            // 
            // AllCompanyId
            // 
            this.AllCompanyId.DataPropertyName = "AllCompanyname";
            this.AllCompanyId.HeaderText = "الموردون";
            this.AllCompanyId.Name = "AllCompanyId";
            this.AllCompanyId.ReadOnly = true;
            this.AllCompanyId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AllCompanyId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AllCompanyId.Text = "تحديد الموردون";
            this.AllCompanyId.ToolTipText = "التجار المسؤلين عن توريد الصنف المحدد";
            // 
            // ArabicUnit
            // 
            this.ArabicUnit.DataPropertyName = "ArabicUnit";
            this.ArabicUnit.HeaderText = "الوحدة";
            this.ArabicUnit.Name = "ArabicUnit";
            this.ArabicUnit.ReadOnly = true;
            this.ArabicUnit.ToolTipText = "الوحدة المستخدمة في المبيع";
            // 
            // TheUnit
            // 
            this.TheUnit.DataPropertyName = "TheUnit";
            this.TheUnit.HeaderText = "TheUnit";
            this.TheUnit.Name = "TheUnit";
            this.TheUnit.ReadOnly = true;
            this.TheUnit.Visible = false;
            // 
            // BaraCode
            // 
            this.BaraCode.DataPropertyName = "BaraCode";
            this.BaraCode.HeaderText = "BaraCode";
            this.BaraCode.Name = "BaraCode";
            this.BaraCode.ReadOnly = true;
            this.BaraCode.Visible = false;
            // 
            // typesBindingSource
            // 
            this.typesBindingSource.DataSource = typeof(WeightsOrganizer.BLL.Types);
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Location = new System.Drawing.Point(34, 16);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(35, 13);
            this.lblid.TabIndex = 1;
            this.lblid.Text = "label1";
            this.lblid.Visible = false;
            this.lblid.TextChanged += new System.EventHandler(this.lblid_TextChanged);
            this.lblid.Click += new System.EventHandler(this.lblid_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.baraCode128vewier1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.settingoControl1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtprcln);
            this.groupBox1.Controls.Add(this.lblprcln);
            this.groupBox1.Controls.Add(this.btnnew);
            this.groupBox1.Controls.Add(this.btndel);
            this.groupBox1.Controls.Add(this.btnaction);
            this.groupBox1.Controls.Add(this.txtClientPrice);
            this.groupBox1.Controls.Add(this.txtBusinessPrice);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblprice);
            this.groupBox1.Controls.Add(this.lblname);
            this.groupBox1.Controls.Add(this.txtname);
            this.groupBox1.Controls.Add(this.lblid);
            this.groupBox1.Location = new System.Drawing.Point(574, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 478);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "الانواع";
            // 
            // baraCode128vewier1
            // 
            this.baraCode128vewier1.CtrlType = null;
            this.baraCode128vewier1.DontCatch = false;
            this.baraCode128vewier1.EnableCreate = true;
            this.baraCode128vewier1.InStore = true;
            this.baraCode128vewier1.Location = new System.Drawing.Point(9, 199);
            this.baraCode128vewier1.Name = "baraCode128vewier1";
            this.baraCode128vewier1.Size = new System.Drawing.Size(203, 105);
            this.baraCode128vewier1.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(79, 339);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "الوحدة";
            this.label5.Visible = false;
            // 
            // settingoControl1
            // 
            this.settingoControl1.enableAll = true;
            this.settingoControl1.isBasecType = true;
            this.settingoControl1.Location = new System.Drawing.Point(9, 303);
            this.settingoControl1.Name = "settingoControl1";
            this.settingoControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.settingoControl1.Size = new System.Drawing.Size(189, 49);
            this.settingoControl1.TabIndex = 18;
            this.settingoControl1.TheTextBoxContinerTheAmoutn = null;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 446);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(205, 22);
            this.button1.TabIndex = 17;
            this.button1.Text = "طــــبــاعــــة";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtprcln
            // 
            this.txtprcln.Allowcomma = true;
            this.txtprcln.Location = new System.Drawing.Point(6, 173);
            this.txtprcln.Name = "txtprcln";
            this.txtprcln.Size = new System.Drawing.Size(211, 20);
            this.txtprcln.TabIndex = 4;
            this.txtprcln.Text = "0";
            // 
            // lblprcln
            // 
            this.lblprcln.AutoSize = true;
            this.lblprcln.Location = new System.Drawing.Point(127, 154);
            this.lblprcln.Name = "lblprcln";
            this.lblprcln.Size = new System.Drawing.Size(88, 13);
            this.lblprcln.TabIndex = 16;
            this.lblprcln.Text = "سعر البيع بالجملة";
            // 
            // btnnew
            // 
            this.btnnew.Location = new System.Drawing.Point(9, 416);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(208, 24);
            this.btnnew.TabIndex = 7;
            this.btnnew.Text = "جديد";
            this.btnnew.UseVisualStyleBackColor = true;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // btndel
            // 
            this.btndel.Enabled = false;
            this.btndel.Location = new System.Drawing.Point(9, 386);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(208, 24);
            this.btndel.TabIndex = 6;
            this.btndel.Text = "حذف";
            this.btndel.UseVisualStyleBackColor = true;
            this.btndel.Click += new System.EventHandler(this.btndel_Click);
            // 
            // btnaction
            // 
            this.btnaction.Enabled = false;
            this.btnaction.Location = new System.Drawing.Point(9, 356);
            this.btnaction.Name = "btnaction";
            this.btnaction.Size = new System.Drawing.Size(208, 24);
            this.btnaction.TabIndex = 5;
            this.btnaction.Text = "اضافة صنف";
            this.btnaction.UseVisualStyleBackColor = true;
            this.btnaction.Click += new System.EventHandler(this.btnaction_Click);
            // 
            // txtClientPrice
            // 
            this.txtClientPrice.Allowcomma = true;
            this.txtClientPrice.Location = new System.Drawing.Point(6, 124);
            this.txtClientPrice.Name = "txtClientPrice";
            this.txtClientPrice.Size = new System.Drawing.Size(211, 20);
            this.txtClientPrice.TabIndex = 3;
            this.txtClientPrice.Text = "0";
            // 
            // txtBusinessPrice
            // 
            this.txtBusinessPrice.Allowcomma = true;
            this.txtBusinessPrice.Location = new System.Drawing.Point(6, 81);
            this.txtBusinessPrice.Name = "txtBusinessPrice";
            this.txtBusinessPrice.Size = new System.Drawing.Size(211, 20);
            this.txtBusinessPrice.TabIndex = 2;
            this.txtBusinessPrice.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "سعر البيع للزبائن";
            // 
            // lblprice
            // 
            this.lblprice.AutoSize = true;
            this.lblprice.Location = new System.Drawing.Point(108, 63);
            this.lblprice.Name = "lblprice";
            this.lblprice.Size = new System.Drawing.Size(107, 13);
            this.lblprice.TabIndex = 5;
            this.lblprice.Text = "سعر الشراء من التاجر";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(154, 16);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(61, 13);
            this.lblname.TabIndex = 3;
            this.lblname.Text = "اسم الصنف";
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(6, 32);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(211, 20);
            this.txtname.TabIndex = 1;
            this.txtname.TextChanged += new System.EventHandler(this.txtname_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.txtsrch);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(7, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(790, 58);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "البحث";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(382, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 24);
            this.button3.TabIndex = 19;
            this.button3.Text = "عرض الكل";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(147, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(229, 26);
            this.button2.TabIndex = 18;
            this.button2.Text = " الأصناف التي تتوفر في المخزن";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtsrch
            // 
            this.txtsrch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsrch.Location = new System.Drawing.Point(601, 32);
            this.txtsrch.Name = "txtsrch";
            this.txtsrch.Size = new System.Drawing.Size(178, 20);
            this.txtsrch.TabIndex = 8;
            this.txtsrch.TextChanged += new System.EventHandler(this.txtsrch_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "0";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(596, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "أدخل اسم النوع أو الباركود الخاص به :";
            // 
            // BusinessClientPriceDataGridViewTextBoxColumn
            // 
            this.BusinessClientPriceDataGridViewTextBoxColumn.DataPropertyName = "ClientPrice";
            this.BusinessClientPriceDataGridViewTextBoxColumn.HeaderText = " لل جملة سعر المبيع";
            this.BusinessClientPriceDataGridViewTextBoxColumn.Name = "BusinessClientPriceDataGridViewTextBoxColumn";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(323, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(261, 23);
            this.label3.TabIndex = 18;
            this.label3.Text = "   الأصـــــنـاف الرئيـــســـــة   ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "TheUnit";
            this.dataGridViewTextBoxColumn1.HeaderText = "TheUnit";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // TypesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "TypesControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.TypesControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typesBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

     
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource typesBindingSource;
        private System.Windows.Forms.Label lblid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BusinessClientPriceDataGridViewTextBoxColumn;
 
        private System.Windows.Forms.Label lblprice;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label label1;
        private numbertextbox txtBusinessPrice;
        private numbertextbox txtClientPrice;
        private System.Windows.Forms.Button btnaction;
        private System.Windows.Forms.Button btndel;
        private System.Windows.Forms.Button btnnew;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtsrch;
        private System.Windows.Forms.Label label2;
        private numbertextbox txtprcln;
        private System.Windows.Forms.Label lblprcln;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private SettingoControl settingoControl1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn businessPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BusinessClientPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn addedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn AllCompanyId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArabicUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn TheUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn BaraCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private BaraCode128vewier baraCode128vewier1;

    
       
 

    }
}
