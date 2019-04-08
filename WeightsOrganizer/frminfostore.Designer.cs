namespace WeightsOrganizer
{
    partial class frminfostore
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.storeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbltotbus = new System.Windows.Forms.Label();
            this.lbltotcli = new System.Windows.Forms.Label();
            this.lbltotbuscli = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.storeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(279, 381);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(370, 88);
            this.button1.TabIndex = 0;
            this.button1.Text = "عرض المعلومات المتعلقة بالمخزن";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(628, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "00";
            // 
            // storeBindingSource
            // 
            this.storeBindingSource.DataSource = typeof(WeightsOrganizer.BLL.Store);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "عدد الاصناف المتوفرة ضمن المخزن";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(286, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "مجموع الكميات في المخزن";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(632, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(266, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(351, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "معلومات المخزن والكميات المتوفرة";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(268, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(267, 14);
            this.label6.TabIndex = 1;
            this.label6.Text = "قيمة الكميات المتوفرة بسعر الشراء من التاجر";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(267, 245);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(240, 14);
            this.label7.TabIndex = 1;
            this.label7.Text = "قيمة الكميات المتوفرة بسعر البيع للزبائن";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(268, 303);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(245, 14);
            this.label8.TabIndex = 1;
            this.label8.Text = "قيمة الكميات المتوفرة بسعر البيع بالجملة";
            // 
            // lbltotbus
            // 
            this.lbltotbus.AutoSize = true;
            this.lbltotbus.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotbus.ForeColor = System.Drawing.Color.Red;
            this.lbltotbus.Location = new System.Drawing.Point(628, 175);
            this.lbltotbus.Name = "lbltotbus";
            this.lbltotbus.Size = new System.Drawing.Size(38, 25);
            this.lbltotbus.TabIndex = 1;
            this.lbltotbus.Text = "00";
            // 
            // lbltotcli
            // 
            this.lbltotcli.AutoSize = true;
            this.lbltotcli.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotcli.ForeColor = System.Drawing.Color.Red;
            this.lbltotcli.Location = new System.Drawing.Point(628, 236);
            this.lbltotcli.Name = "lbltotcli";
            this.lbltotcli.Size = new System.Drawing.Size(38, 25);
            this.lbltotcli.TabIndex = 1;
            this.lbltotcli.Text = "00";
            // 
            // lbltotbuscli
            // 
            this.lbltotbuscli.AutoSize = true;
            this.lbltotbuscli.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotbuscli.ForeColor = System.Drawing.Color.Red;
            this.lbltotbuscli.Location = new System.Drawing.Point(628, 292);
            this.lbltotbuscli.Name = "lbltotbuscli";
            this.lbltotbuscli.Size = new System.Drawing.Size(38, 25);
            this.lbltotbuscli.TabIndex = 1;
            this.lbltotbuscli.Text = "00";
            // 
            // frminfostore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(954, 481);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbltotbuscli);
            this.Controls.Add(this.lbltotcli);
            this.Controls.Add(this.lbltotbus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "frminfostore";
            this.Text = "معلومات المخزن";
            ((System.ComponentModel.ISupportInitialize)(this.storeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource storeBindingSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbltotbus;
        private System.Windows.Forms.Label lbltotcli;
        private System.Windows.Forms.Label lbltotbuscli;
    }
}
