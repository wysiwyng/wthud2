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
            this.plotView1 = new OxyPlot.WindowsForms.PlotView();
            ((System.ComponentModel.ISupportInitialize)(this.PlotConfigDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadLogBtn
            // 
            this.LoadLogBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LoadLogBtn.Location = new System.Drawing.Point(12, 415);
            this.LoadLogBtn.Name = "LoadLogBtn";
            this.LoadLogBtn.Size = new System.Drawing.Size(75, 23);
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
            this.PlotConfigDGV.Location = new System.Drawing.Point(12, 12);
            this.PlotConfigDGV.Name = "PlotConfigDGV";
            this.PlotConfigDGV.RowHeadersVisible = false;
            this.PlotConfigDGV.Size = new System.Drawing.Size(202, 397);
            this.PlotConfigDGV.TabIndex = 3;
            this.PlotConfigDGV.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.PlotConfigDGV_CellMouseUp);
            this.PlotConfigDGV.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.PlotConfigDGV_CellValueChanged);
            // 
            // plotView1
            // 
            this.plotView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plotView1.Location = new System.Drawing.Point(220, 12);
            this.plotView1.Name = "plotView1";
            this.plotView1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView1.Size = new System.Drawing.Size(568, 423);
            this.plotView1.TabIndex = 4;
            this.plotView1.Text = "plotView1";
            this.plotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // LogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.plotView1);
            this.Controls.Add(this.PlotConfigDGV);
            this.Controls.Add(this.LoadLogBtn);
            this.Name = "LogView";
            this.Text = "WTHUD Log Viewer";
            this.Load += new System.EventHandler(this.LogView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PlotConfigDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoadLogBtn;
        private System.Windows.Forms.DataGridView PlotConfigDGV;
        private OxyPlot.WindowsForms.PlotView plotView1;
    }
}

