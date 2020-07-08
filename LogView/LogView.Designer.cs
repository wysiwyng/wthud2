namespace LogView
{
    partial class LogView
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
            this.LoadLogBtn = new System.Windows.Forms.Button();
            this.PlotConfigDGV = new System.Windows.Forms.DataGridView();
            this.TelemPlotView = new OxyPlot.WindowsForms.PlotView();
            this.ExportCSVBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PlotConfigDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadLogBtn
            // 
            this.LoadLogBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LoadLogBtn.Location = new System.Drawing.Point(16, 511);
            this.LoadLogBtn.Margin = new System.Windows.Forms.Padding(4);
            this.LoadLogBtn.Name = "LoadLogBtn";
            this.LoadLogBtn.Size = new System.Drawing.Size(100, 28);
            this.LoadLogBtn.TabIndex = 0;
            this.LoadLogBtn.Text = "Load Log...";
            this.LoadLogBtn.UseVisualStyleBackColor = true;
            this.LoadLogBtn.Click += new System.EventHandler(this.LoadLogBtn_Click);
            // 
            // PlotConfigDGV
            // 
            this.PlotConfigDGV.AllowUserToAddRows = false;
            this.PlotConfigDGV.AllowUserToDeleteRows = false;
            this.PlotConfigDGV.AllowUserToResizeRows = false;
            this.PlotConfigDGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PlotConfigDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PlotConfigDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PlotConfigDGV.Location = new System.Drawing.Point(16, 15);
            this.PlotConfigDGV.Margin = new System.Windows.Forms.Padding(4);
            this.PlotConfigDGV.Name = "PlotConfigDGV";
            this.PlotConfigDGV.RowHeadersVisible = false;
            this.PlotConfigDGV.RowHeadersWidth = 51;
            this.PlotConfigDGV.Size = new System.Drawing.Size(325, 489);
            this.PlotConfigDGV.TabIndex = 3;
            this.PlotConfigDGV.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.PlotConfigDGV_CellMouseUp);
            // 
            // TelemPlotView
            // 
            this.TelemPlotView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TelemPlotView.BackColor = System.Drawing.SystemColors.Control;
            this.TelemPlotView.Location = new System.Drawing.Point(349, 15);
            this.TelemPlotView.Margin = new System.Windows.Forms.Padding(4);
            this.TelemPlotView.Name = "TelemPlotView";
            this.TelemPlotView.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.TelemPlotView.Size = new System.Drawing.Size(701, 521);
            this.TelemPlotView.TabIndex = 4;
            this.TelemPlotView.Text = "plotView1";
            this.TelemPlotView.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.TelemPlotView.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.TelemPlotView.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // ExportCSVBtn
            // 
            this.ExportCSVBtn.Enabled = false;
            this.ExportCSVBtn.Location = new System.Drawing.Point(123, 511);
            this.ExportCSVBtn.Name = "ExportCSVBtn";
            this.ExportCSVBtn.Size = new System.Drawing.Size(100, 28);
            this.ExportCSVBtn.TabIndex = 5;
            this.ExportCSVBtn.Text = "Export CSV...";
            this.ExportCSVBtn.UseVisualStyleBackColor = true;
            this.ExportCSVBtn.Click += new System.EventHandler(this.ExportCSVBtn_Click);
            // 
            // LogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.ExportCSVBtn);
            this.Controls.Add(this.TelemPlotView);
            this.Controls.Add(this.PlotConfigDGV);
            this.Controls.Add(this.LoadLogBtn);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LogView";
            this.Text = "WTHUD Log Viewer";
            this.Load += new System.EventHandler(this.LogView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PlotConfigDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoadLogBtn;
        private System.Windows.Forms.DataGridView PlotConfigDGV;
        private OxyPlot.WindowsForms.PlotView TelemPlotView;
        private System.Windows.Forms.Button ExportCSVBtn;
    }
}

