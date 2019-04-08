namespace WeightsOrganizer
{
    partial class frmcompany
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
            this.companyControl1 = new WeightsOrganizer.Controls.CompanyControl();
            this.SuspendLayout();
            // 
            // companyControl1
            // 
            this.companyControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.companyControl1.Location = new System.Drawing.Point(0, 0);
            this.companyControl1.Name = "companyControl1";
            this.companyControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.companyControl1.Size = new System.Drawing.Size(800, 600);
            this.companyControl1.TabIndex = 1;
            // 
            // frmcompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 612);
            this.Controls.Add(this.companyControl1);
            this.Name = "frmcompany";
            this.Text = "الــتـــجـــار";
            this.Load += new System.EventHandler(this.frmcompany_Load);
            this.Controls.SetChildIndex(this.companyControl1, 0);
    
            this.ResumeLayout(false);

        }

        #endregion

        private WeightsOrganizer.Controls.CompanyControl companyControl1;






    }
}