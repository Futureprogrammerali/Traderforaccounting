namespace WeightsOrganizer
{
    partial class frmclients
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
            this.clientcontrol1 = new WeightsOrganizer.Controls.clientcontrol();
            this.SuspendLayout();
            // 
            // clientcontrol1
            // 
            this.clientcontrol1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.clientcontrol1.Location = new System.Drawing.Point(0, 1);
            this.clientcontrol1.Name = "clientcontrol1";
            this.clientcontrol1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.clientcontrol1.Size = new System.Drawing.Size(800, 600);
            this.clientcontrol1.TabIndex = 0;
            // 
            // frmclients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 612);
            this.Controls.Add(this.clientcontrol1);
            this.Name = "frmclients";
            this.Text = "الزبائن";
            this.Load += new System.EventHandler(this.frmclients_Load);
            this.Click += new System.EventHandler(this.frmclients_Click);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmclients_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private WeightsOrganizer.Controls.clientcontrol clientcontrol1;





    }
}