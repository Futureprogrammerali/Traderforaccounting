namespace WeightsOrganizer
{
    partial class frmSalesReturn
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
            this.salesReturns1 = new WeightsOrganizer.Controls.SalesReturns();
            this.SuspendLayout();
            // 
            // salesReturns1
            // 
            this.salesReturns1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.salesReturns1.Location = new System.Drawing.Point(0, 0);
            this.salesReturns1.Name = "salesReturns1";
            this.salesReturns1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.salesReturns1.Size = new System.Drawing.Size(966, 734);
            this.salesReturns1.TabIndex = 10001;
            // 
            // frmSalesReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(967, 746);
            this.Controls.Add(this.salesReturns1);
            this.Name = "frmSalesReturn";
            this.Text = "مردود المبيعات (المرتجع)";
            this.Load += new System.EventHandler(this.frmSalesReturn_Load);
            this.Controls.SetChildIndex(this.salesReturns1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private WeightsOrganizer.Controls.SalesReturns salesReturns1;














    }
}
