namespace WeightsOrganizer
{
    partial class frmoutputstocktaking
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
            this.stocktakingOutPutControl1 = new WeightsOrganizer.Controls.StocktakingOutPutControl();
            this.SuspendLayout();
            // 
            // stocktakingOutPutControl1
            // 
            this.stocktakingOutPutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.stocktakingOutPutControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.stocktakingOutPutControl1.Location = new System.Drawing.Point(1, 0);
            this.stocktakingOutPutControl1.Name = "stocktakingOutPutControl1";
            this.stocktakingOutPutControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.stocktakingOutPutControl1.Size = new System.Drawing.Size(821, 600);
            this.stocktakingOutPutControl1.TabIndex = 0;
            // 
            // frmoutputstocktaking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 612);
            this.Controls.Add(this.stocktakingOutPutControl1);
            this.Name = "frmoutputstocktaking";
            this.Text = "جرد المبيعات -البضاعة التي اشتراها الزبائن";
            this.Load += new System.EventHandler(this.frmoutputstocktaking_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private WeightsOrganizer.Controls.StocktakingOutPutControl stocktakingOutPutControl1;





    }
}