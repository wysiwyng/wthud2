namespace WtHud2
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
            this.SaveBtn = new System.Windows.Forms.Button();
            this.LoadBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CurrentCraftNameLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ConfigNameLbl = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.HUDFontBtn = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.LogShownRB = new System.Windows.Forms.RadioButton();
            this.LogAllRB = new System.Windows.Forms.RadioButton();
            this.LoggingEnableChkBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LogFileNameLbl = new System.Windows.Forms.Label();
            this.LogFileSizeLbl = new System.Windows.Forms.Label();
            this.LogEntriesLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ActiveParamsDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XPosSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YPosSpinner)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // ActiveParamsDGV
            // 
            this.ActiveParamsDGV.AllowUserToResizeRows = false;
            this.ActiveParamsDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ActiveParamsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ActiveParamsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ActiveParamsDGV.Location = new System.Drawing.Point(4, 45);
            this.ActiveParamsDGV.Margin = new System.Windows.Forms.Padding(2);
            this.ActiveParamsDGV.MultiSelect = false;
            this.ActiveParamsDGV.Name = "ActiveParamsDGV";
            this.ActiveParamsDGV.RowHeadersVisible = false;
            this.ActiveParamsDGV.RowHeadersWidth = 51;
            this.ActiveParamsDGV.RowTemplate.Height = 24;
            this.ActiveParamsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ActiveParamsDGV.Size = new System.Drawing.Size(353, 422);
            this.ActiveParamsDGV.TabIndex = 1;
            // 
            // ReloadBtn
            // 
            this.ReloadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ReloadBtn.Enabled = false;
            this.ReloadBtn.Location = new System.Drawing.Point(4, 471);
            this.ReloadBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ReloadBtn.Name = "ReloadBtn";
            this.ReloadBtn.Size = new System.Drawing.Size(75, 23);
            this.ReloadBtn.TabIndex = 2;
            this.ReloadBtn.Text = "Reload";
            this.ReloadBtn.UseVisualStyleBackColor = true;
            this.ReloadBtn.Click += new System.EventHandler(this.ReloadBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.Enabled = false;
            this.AddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBtn.Location = new System.Drawing.Point(214, 205);
            this.AddBtn.Margin = new System.Windows.Forms.Padding(2);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(45, 37);
            this.AddBtn.TabIndex = 3;
            this.AddBtn.Text = "→";
            this.AddBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // RemBtn
            // 
            this.RemBtn.Enabled = false;
            this.RemBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemBtn.Location = new System.Drawing.Point(214, 246);
            this.RemBtn.Margin = new System.Windows.Forms.Padding(2);
            this.RemBtn.Name = "RemBtn";
            this.RemBtn.Size = new System.Drawing.Size(45, 37);
            this.RemBtn.TabIndex = 4;
            this.RemBtn.Text = "←";
            this.RemBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RemBtn.UseVisualStyleBackColor = true;
            this.RemBtn.Click += new System.EventHandler(this.RemBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "X Position:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Y Position:";
            // 
            // XPosSpinner
            // 
            this.XPosSpinner.Location = new System.Drawing.Point(77, 17);
            this.XPosSpinner.Margin = new System.Windows.Forms.Padding(2);
            this.XPosSpinner.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.XPosSpinner.Name = "XPosSpinner";
            this.XPosSpinner.Size = new System.Drawing.Size(56, 20);
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
            this.YPosSpinner.Location = new System.Drawing.Point(77, 40);
            this.YPosSpinner.Margin = new System.Windows.Forms.Padding(2);
            this.YPosSpinner.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.YPosSpinner.Name = "YPosSpinner";
            this.YPosSpinner.Size = new System.Drawing.Size(56, 20);
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
            this.AvailableParamsLB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AvailableParamsLB.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvailableParamsLB.FormattingEnabled = true;
            this.AvailableParamsLB.ItemHeight = 14;
            this.AvailableParamsLB.Location = new System.Drawing.Point(4, 17);
            this.AvailableParamsLB.Margin = new System.Windows.Forms.Padding(2);
            this.AvailableParamsLB.Name = "AvailableParamsLB";
            this.AvailableParamsLB.Size = new System.Drawing.Size(191, 452);
            this.AvailableParamsLB.TabIndex = 9;
            // 
            // UpBtn
            // 
            this.UpBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UpBtn.Enabled = false;
            this.UpBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpBtn.Location = new System.Drawing.Point(361, 194);
            this.UpBtn.Margin = new System.Windows.Forms.Padding(2);
            this.UpBtn.Name = "UpBtn";
            this.UpBtn.Size = new System.Drawing.Size(45, 37);
            this.UpBtn.TabIndex = 10;
            this.UpBtn.Text = "↑";
            this.UpBtn.UseVisualStyleBackColor = true;
            this.UpBtn.Click += new System.EventHandler(this.UpBtn_Click);
            // 
            // DnBtn
            // 
            this.DnBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DnBtn.Enabled = false;
            this.DnBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DnBtn.Location = new System.Drawing.Point(361, 235);
            this.DnBtn.Margin = new System.Windows.Forms.Padding(2);
            this.DnBtn.Name = "DnBtn";
            this.DnBtn.Size = new System.Drawing.Size(45, 37);
            this.DnBtn.TabIndex = 11;
            this.DnBtn.Text = "↓";
            this.DnBtn.UseVisualStyleBackColor = true;
            this.DnBtn.Click += new System.EventHandler(this.DnBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveBtn.Enabled = false;
            this.SaveBtn.Location = new System.Drawing.Point(4, 471);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 12;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // LoadBtn
            // 
            this.LoadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LoadBtn.Enabled = false;
            this.LoadBtn.Location = new System.Drawing.Point(83, 471);
            this.LoadBtn.Margin = new System.Windows.Forms.Padding(2);
            this.LoadBtn.Name = "LoadBtn";
            this.LoadBtn.Size = new System.Drawing.Size(75, 23);
            this.LoadBtn.TabIndex = 13;
            this.LoadBtn.Text = "Load";
            this.LoadBtn.UseVisualStyleBackColor = true;
            this.LoadBtn.Click += new System.EventHandler(this.LoadBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.AvailableParamsLB);
            this.groupBox1.Controls.Add(this.ReloadBtn);
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(199, 498);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Available Parameters";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.CurrentCraftNameLbl);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.ConfigNameLbl);
            this.groupBox2.Controls.Add(this.ActiveParamsDGV);
            this.groupBox2.Controls.Add(this.UpBtn);
            this.groupBox2.Controls.Add(this.LoadBtn);
            this.groupBox2.Controls.Add(this.DnBtn);
            this.groupBox2.Controls.Add(this.SaveBtn);
            this.groupBox2.Location = new System.Drawing.Point(263, 11);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(410, 498);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Active Parameters";
            // 
            // CurrentCraftNameLbl
            // 
            this.CurrentCraftNameLbl.AutoSize = true;
            this.CurrentCraftNameLbl.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentCraftNameLbl.ForeColor = System.Drawing.Color.DarkRed;
            this.CurrentCraftNameLbl.Location = new System.Drawing.Point(118, 29);
            this.CurrentCraftNameLbl.Name = "CurrentCraftNameLbl";
            this.CurrentCraftNameLbl.Size = new System.Drawing.Size(112, 14);
            this.CurrentCraftNameLbl.TabIndex = 17;
            this.CurrentCraftNameLbl.Text = "No plane active";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Current craft name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Loaded config name:";
            // 
            // ConfigNameLbl
            // 
            this.ConfigNameLbl.AutoSize = true;
            this.ConfigNameLbl.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfigNameLbl.Location = new System.Drawing.Point(118, 15);
            this.ConfigNameLbl.Name = "ConfigNameLbl";
            this.ConfigNameLbl.Size = new System.Drawing.Size(119, 14);
            this.ConfigNameLbl.TabIndex = 14;
            this.ConfigNameLbl.Text = "No config loaded";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.HUDFontBtn);
            this.groupBox3.Controls.Add(this.XPosSpinner);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.YPosSpinner);
            this.groupBox3.Location = new System.Drawing.Point(11, 514);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(199, 93);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "HUD Appearance";
            // 
            // HUDFontBtn
            // 
            this.HUDFontBtn.Location = new System.Drawing.Point(5, 65);
            this.HUDFontBtn.Name = "HUDFontBtn";
            this.HUDFontBtn.Size = new System.Drawing.Size(128, 23);
            this.HUDFontBtn.TabIndex = 9;
            this.HUDFontBtn.Text = "Change HUD Font...";
            this.HUDFontBtn.UseVisualStyleBackColor = true;
            this.HUDFontBtn.Click += new System.EventHandler(this.HUDFontBtn_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.LogEntriesLbl);
            this.groupBox4.Controls.Add(this.LogFileSizeLbl);
            this.groupBox4.Controls.Add(this.LogFileNameLbl);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.LogShownRB);
            this.groupBox4.Controls.Add(this.LogAllRB);
            this.groupBox4.Controls.Add(this.LoggingEnableChkBox);
            this.groupBox4.Location = new System.Drawing.Point(215, 514);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(458, 92);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Logging";
            // 
            // LogShownRB
            // 
            this.LogShownRB.AutoSize = true;
            this.LogShownRB.Checked = true;
            this.LogShownRB.Location = new System.Drawing.Point(6, 63);
            this.LogShownRB.Name = "LogShownRB";
            this.LogShownRB.Size = new System.Drawing.Size(99, 17);
            this.LogShownRB.TabIndex = 2;
            this.LogShownRB.TabStop = true;
            this.LogShownRB.Text = "Log only shown";
            this.LogShownRB.UseVisualStyleBackColor = true;
            // 
            // LogAllRB
            // 
            this.LogAllRB.AutoSize = true;
            this.LogAllRB.Location = new System.Drawing.Point(6, 40);
            this.LogAllRB.Name = "LogAllRB";
            this.LogAllRB.Size = new System.Drawing.Size(56, 17);
            this.LogAllRB.TabIndex = 1;
            this.LogAllRB.Text = "Log all";
            this.LogAllRB.UseVisualStyleBackColor = true;
            // 
            // LoggingEnableChkBox
            // 
            this.LoggingEnableChkBox.AutoSize = true;
            this.LoggingEnableChkBox.Location = new System.Drawing.Point(6, 18);
            this.LoggingEnableChkBox.Name = "LoggingEnableChkBox";
            this.LoggingEnableChkBox.Size = new System.Drawing.Size(65, 17);
            this.LoggingEnableChkBox.TabIndex = 0;
            this.LoggingEnableChkBox.Text = "Enabled";
            this.LoggingEnableChkBox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(123, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Log entries:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(123, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "File size:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(123, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "File name:";
            // 
            // LogFileNameLbl
            // 
            this.LogFileNameLbl.AutoSize = true;
            this.LogFileNameLbl.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogFileNameLbl.Location = new System.Drawing.Point(202, 19);
            this.LogFileNameLbl.Name = "LogFileNameLbl";
            this.LogFileNameLbl.Size = new System.Drawing.Size(133, 14);
            this.LogFileNameLbl.TabIndex = 6;
            this.LogFileNameLbl.Text = "Logging not active";
            // 
            // LogFileSizeLbl
            // 
            this.LogFileSizeLbl.AutoSize = true;
            this.LogFileSizeLbl.Location = new System.Drawing.Point(202, 32);
            this.LogFileSizeLbl.Name = "LogFileSizeLbl";
            this.LogFileSizeLbl.Size = new System.Drawing.Size(28, 13);
            this.LogFileSizeLbl.TabIndex = 7;
            this.LogFileSizeLbl.Text = "0 kb";
            // 
            // LogEntriesLbl
            // 
            this.LogEntriesLbl.AutoSize = true;
            this.LogEntriesLbl.Location = new System.Drawing.Point(202, 45);
            this.LogEntriesLbl.Name = "LogEntriesLbl";
            this.LogEntriesLbl.Size = new System.Drawing.Size(13, 13);
            this.LogEntriesLbl.TabIndex = 8;
            this.LogEntriesLbl.Text = "0";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 618);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RemBtn);
            this.Controls.Add(this.AddBtn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(700, 657);
            this.Name = "ConfigForm";
            this.Text = "WTHUD Config";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigForm_FormClosing);
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ActiveParamsDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XPosSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YPosSpinner)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button LoadBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button HUDFontBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ConfigNameLbl;
        private System.Windows.Forms.Label CurrentCraftNameLbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton LogShownRB;
        private System.Windows.Forms.RadioButton LogAllRB;
        private System.Windows.Forms.CheckBox LoggingEnableChkBox;
        private System.Windows.Forms.Label LogEntriesLbl;
        private System.Windows.Forms.Label LogFileSizeLbl;
        private System.Windows.Forms.Label LogFileNameLbl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}

