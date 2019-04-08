namespace WeightsOrganizer
{
    partial class frmbusinesdeal
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
            this.businesDealControl1 = new WeightsOrganizer.Controls.BusinesDealControl();
            this.SuspendLayout();
            // 
            // businesDealControl1
            // 
            this.businesDealControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.businesDealControl1.Location = new System.Drawing.Point(12, -4);
            this.businesDealControl1.Name = "businesDealControl1";
            this.businesDealControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.businesDealControl1.Size = new System.Drawing.Size(822, 600);
            this.businesDealControl1.TabIndex = 0;
            // 
            // frmbusinesdeal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 612);
            this.Controls.Add(this.businesDealControl1);
            this.Name = "frmbusinesdeal";
            this.Text = "صفقات مع التجار وتنزيل البضاعة";
            this.Load += new System.EventHandler(this.frmbusinesdeal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private WeightsOrganizer.Controls.BusinesDealControl businesDealControl1;



    }
}