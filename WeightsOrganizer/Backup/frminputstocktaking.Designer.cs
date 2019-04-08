namespace WeightsOrganizer
{
    partial class frminputstocktaking
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
            this.stocktakingInputControl1 = new WeightsOrganizer.Controls.StocktakingInputControl();
            this.SuspendLayout();
            // 
            // stocktakingInputControl1
            // 
            this.stocktakingInputControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.stocktakingInputControl1.Location = new System.Drawing.Point(0, 0);
            this.stocktakingInputControl1.Name = "stocktakingInputControl1";
            this.stocktakingInputControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.stocktakingInputControl1.Size = new System.Drawing.Size(832, 600);
            this.stocktakingInputControl1.TabIndex = 0;
            // 
            // frminputstocktaking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 612);
            this.Controls.Add(this.stocktakingInputControl1);
            this.Name = "frminputstocktaking";
            this.Text = "جرد المشتريات-الواردات-البضاعة التي تم سحبها  من التجار";
            this.Load += new System.EventHandler(this.frminputstocktaking_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private WeightsOrganizer.Controls.StocktakingInputControl stocktakingInputControl1;



    }
}