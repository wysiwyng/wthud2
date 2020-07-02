namespace WtHud2
{
    partial class HUDForm
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
            this.HUDLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HUDLabel
            // 
            this.HUDLabel.AutoSize = true;
            this.HUDLabel.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HUDLabel.ForeColor = System.Drawing.Color.White;
            this.HUDLabel.Location = new System.Drawing.Point(0, 0);
            this.HUDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.HUDLabel.Name = "HUDLabel";
            this.HUDLabel.Size = new System.Drawing.Size(76, 22);
            this.HUDLabel.TabIndex = 0;
            this.HUDLabel.Text = "label1";
            // 
            // HUDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.HUDLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "HUDForm";
            this.Text = "WTHUD OSD";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.ControlDarkDark;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label HUDLabel;
    }
}