namespace WeightsOrganizer
{
    partial class frmclientdeal
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
            this.clientDealControl1 = new WeightsOrganizer.Controls.ClientDealControl();
            this.SuspendLayout();
            // 
            // clientDealControl1
            // 
            this.clientDealControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.clientDealControl1.Location = new System.Drawing.Point(0, -2);
            this.clientDealControl1.Name = "clientDealControl1";
            this.clientDealControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.clientDealControl1.Size = new System.Drawing.Size(822, 600);
            this.clientDealControl1.TabIndex = 0;
            // 
            // frmclientdeal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 612);
            this.Controls.Add(this.clientDealControl1);
            this.Name = "frmclientdeal";
            this.Text = "صفقة مع زبون بيع بضاعة";
            this.Load += new System.EventHandler(this.frmclientdeal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private WeightsOrganizer.Controls.ClientDealControl clientDealControl1;

    }
}