namespace WeightsOrganizer
{
    partial class frmclienbill
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
            this.clientbillcontrol1 = new WeightsOrganizer.Controls.clientbillcontrol();
            this.SuspendLayout();
            // 
            // clientbillcontrol1
            // 
            this.clientbillcontrol1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.clientbillcontrol1.Location = new System.Drawing.Point(-1, -2);
            this.clientbillcontrol1.Name = "clientbillcontrol1";
            this.clientbillcontrol1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.clientbillcontrol1.Size = new System.Drawing.Size(850, 650);
            this.clientbillcontrol1.TabIndex = 0;
            // 
            // frmclienbill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 612);
            this.Controls.Add(this.clientbillcontrol1);
            this.Name = "frmclienbill";
            this.Text = "كشف حساب زبون";
            this.Load += new System.EventHandler(this.frmclienbill_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private WeightsOrganizer.Controls.clientbillcontrol clientbillcontrol1;

    }
}