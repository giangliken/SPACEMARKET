namespace SpaceMarket.Bao_cao
{
    partial class InHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InHoaDon));
            this.reportCHITIETHOADON = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportCHITIETHOADON
            // 
            this.reportCHITIETHOADON.Location = new System.Drawing.Point(3, 13);
            this.reportCHITIETHOADON.Name = "reportCHITIETHOADON";
            this.reportCHITIETHOADON.ServerReport.BearerToken = null;
            this.reportCHITIETHOADON.Size = new System.Drawing.Size(940, 629);
            this.reportCHITIETHOADON.TabIndex = 0;
            this.reportCHITIETHOADON.Load += new System.EventHandler(this.reportCHITIETHOADON_Load);
            // 
            // InHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 654);
            this.Controls.Add(this.reportCHITIETHOADON);
            this.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "InHoaDon";
            this.Text = "IN HÓA ĐƠN";
            this.Load += new System.EventHandler(this.InHoaDon_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportCHITIETHOADON;
    }
}