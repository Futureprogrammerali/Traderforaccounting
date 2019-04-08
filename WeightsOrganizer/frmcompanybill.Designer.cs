namespace WeightsOrganizer
{
    partial class frmcompanybill
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
            this.companybillcontrol1 = new WeightsOrganizer.Controls.companybillcontrol();
            this.SuspendLayout();
            // 
            // companybillcontrol1
            // 
            this.companybillcontrol1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.companybillcontrol1.Location = new System.Drawing.Point(0, 0);
            this.companybillcontrol1.Name = "companybillcontrol1";
            this.companybillcontrol1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.companybillcontrol1.Size = new System.Drawing.Size(800, 600);
            this.companybillcontrol1.TabIndex = 0;
            // 
            // frmcompanybill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 612);
            this.Controls.Add(this.companybillcontrol1);
            this.Name = "frmcompanybill";
            this.Text = "كشف حساب تاجر";
            this.Load += new System.EventHandler(this.frmcompanybill_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private WeightsOrganizer.Controls.companybillcontrol companybillcontrol1;

    }
}