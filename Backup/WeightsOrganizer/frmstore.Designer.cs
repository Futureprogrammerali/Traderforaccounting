namespace WeightsOrganizer
{
    partial class frmstore
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
            this.storeview1 = new WeightsOrganizer.Controls.StoreControl();
            this.SuspendLayout();
            // 
            // storeview1
            // 
            this.storeview1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.storeview1.Location = new System.Drawing.Point(12, 2);
            this.storeview1.Name = "storeview1";
            this.storeview1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.storeview1.Size = new System.Drawing.Size(787, 582);
            this.storeview1.TabIndex = 0;
            // 
            // frmstore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 612);
            this.Controls.Add(this.storeview1);
            this.Name = "frmstore";
            this.Text = "المخزن";
            this.Load += new System.EventHandler(this.frmstore_Load);

            this.ResumeLayout(false);

        }

        #endregion

        private WeightsOrganizer.Controls.StoreControl storeview1;



    }
}