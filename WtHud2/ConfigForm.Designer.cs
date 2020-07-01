namespace wthud3
{
    partial class ConfigForm
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
            this.ActiveParamsDGV = new System.Windows.Forms.DataGridView();
            this.ReloadBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.RemBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.XPosSpinner = new System.Windows.Forms.NumericUpDown();
            this.YPosSpinner = new System.Windows.Forms.NumericUpDown();
            this.AvailableParamsLB = new System.Windows.Forms.ListBox();
            this.UpBtn = new System.Windows.Forms.Button();
            this.DnBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ActiveParamsDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XPosSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YPosSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // ActiveParamsDGV
            // 
            this.ActiveParamsDGV.AllowUserToResizeRows = false;
            this.ActiveParamsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ActiveParamsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ActiveParamsDGV.Location = new System.Drawing.Point(364, 12);
            this.ActiveParamsDGV.MultiSelect = false;
            this.ActiveParamsDGV.Name = "ActiveParamsDGV";
            this.ActiveParamsDGV.RowHeadersVisible = false;
            this.ActiveParamsDGV.RowHeadersWidth = 51;
            this.ActiveParamsDGV.RowTemplate.Height = 24;
            this.ActiveParamsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ActiveParamsDGV.Size = new System.Drawing.Size(553, 532);
            this.ActiveParamsDGV.TabIndex = 1;
            // 
            // ReloadBtn
            // 
            this.ReloadBtn.Location = new System.Drawing.Point(12, 550);
            this.ReloadBtn.Name = "ReloadBtn";
            this.ReloadBtn.Size = new System.Drawing.Size(75, 23);
            this.ReloadBtn.TabIndex = 2;
            this.ReloadBtn.Text = "Reload";
            this.ReloadBtn.UseVisualStyleBackColor = true;
            this.ReloadBtn.Click += new System.EventHandler(this.ReloadBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(283, 224);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(75, 23);
            this.AddBtn.TabIndex = 3;
            this.AddBtn.Text = "Add";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // RemBtn
            // 
            this.RemBtn.Location = new System.Drawing.Point(283, 253);
            this.RemBtn.Name = "RemBtn";
            this.RemBtn.Size = new System.Drawing.Size(75, 23);
            this.RemBtn.TabIndex = 4;
            this.RemBtn.Text = "Remove";
            this.RemBtn.UseVisualStyleBackColor = true;
            this.RemBtn.Click += new System.EventHandler(this.RemBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 678);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 706);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Y:";
            // 
            // XPosSpinner
            // 
            this.XPosSpinner.Location = new System.Drawing.Point(101, 676);
            this.XPosSpinner.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.XPosSpinner.Name = "XPosSpinner";
            this.XPosSpinner.Size = new System.Drawing.Size(75, 22);
            this.XPosSpinner.TabIndex = 7;
            this.XPosSpinner.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.XPosSpinner.ValueChanged += new System.EventHandler(this.XPosSpinner_ValueChanged);
            // 
            // YPosSpinner
            // 
            this.YPosSpinner.Location = new System.Drawing.Point(101, 704);
            this.YPosSpinner.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.YPosSpinner.Name = "YPosSpinner";
            this.YPosSpinner.Size = new System.Drawing.Size(75, 22);
            this.YPosSpinner.TabIndex = 8;
            this.YPosSpinner.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.YPosSpinner.ValueChanged += new System.EventHandler(this.XPosSpinner_ValueChanged);
            // 
            // AvailableParamsLB
            // 
            this.AvailableParamsLB.FormattingEnabled = true;
            this.AvailableParamsLB.ItemHeight = 16;
            this.AvailableParamsLB.Location = new System.Drawing.Point(12, 12);
            this.AvailableParamsLB.Name = "AvailableParamsLB";
            this.AvailableParamsLB.Size = new System.Drawing.Size(265, 532);
            this.AvailableParamsLB.TabIndex = 9;
            // 
            // UpBtn
            // 
            this.UpBtn.Location = new System.Drawing.Point(923, 224);
            this.UpBtn.Name = "UpBtn";
            this.UpBtn.Size = new System.Drawing.Size(75, 23);
            this.UpBtn.TabIndex = 10;
            this.UpBtn.Text = "Up";
            this.UpBtn.UseVisualStyleBackColor = true;
            this.UpBtn.Click += new System.EventHandler(this.UpBtn_Click);
            // 
            // DnBtn
            // 
            this.DnBtn.Location = new System.Drawing.Point(923, 253);
            this.DnBtn.Name = "DnBtn";
            this.DnBtn.Size = new System.Drawing.Size(75, 23);
            this.DnBtn.TabIndex = 11;
            this.DnBtn.Text = "Down";
            this.DnBtn.UseVisualStyleBackColor = true;
            this.DnBtn.Click += new System.EventHandler(this.DnBtn_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 779);
            this.Controls.Add(this.DnBtn);
            this.Controls.Add(this.UpBtn);
            this.Controls.Add(this.AvailableParamsLB);
            this.Controls.Add(this.YPosSpinner);
            this.Controls.Add(this.XPosSpinner);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RemBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.ReloadBtn);
            this.Controls.Add(this.ActiveParamsDGV);
            this.Name = "ConfigForm";
            this.Text = "WTHUD Config";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ActiveParamsDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XPosSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YPosSpinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView ActiveParamsDGV;
        private System.Windows.Forms.Button ReloadBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button RemBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown XPosSpinner;
        private System.Windows.Forms.NumericUpDown YPosSpinner;
        private System.Windows.Forms.ListBox AvailableParamsLB;
        private System.Windows.Forms.Button UpBtn;
        private System.Windows.Forms.Button DnBtn;
    }
}

