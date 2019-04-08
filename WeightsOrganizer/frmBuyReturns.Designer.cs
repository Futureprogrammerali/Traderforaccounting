namespace WeightsOrganizer
{
    partial class frmBuyReturns
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
            this.buyReturns1 = new WeightsOrganizer.Controls.BuyReturns();
            this.SuspendLayout();
            // 
            // buyReturns1
            // 
            this.buyReturns1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buyReturns1.Location = new System.Drawing.Point(2, 11);
            this.buyReturns1.Name = "buyReturns1";
            this.buyReturns1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buyReturns1.Size = new System.Drawing.Size(936, 681);
            this.buyReturns1.TabIndex = 10001;
            // 
            // frmBuyReturns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(950, 696);
            this.Controls.Add(this.buyReturns1);
            this.Name = "frmBuyReturns";
            this.Text = "مردود المشتريات";
            this.Load += new System.EventHandler(this.frmBuyReturns_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private WeightsOrganizer.Controls.BuyReturns buyReturns1;


    }
}
