namespace SpaceMarket
{
    partial class TraCuuPhieuQuaTang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TraCuuPhieuQuaTang));
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaPhieu = new System.Windows.Forms.TextBox();
            this.dgvDanhSachPQT = new Sunny.UI.UIDataGridView();
            this.MAPHIEU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PTGIAM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.THOIGIANBD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.THOIGIANKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DKAPDUNG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.txtPTGiam = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachPQT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(501, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(671, 64);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tra Cứu Phiếu Quà Tặng";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtMaPhieu
            // 
            this.txtMaPhieu.Location = new System.Drawing.Point(296, 155);
            this.txtMaPhieu.Multiline = true;
            this.txtMaPhieu.Name = "txtMaPhieu";
            this.txtMaPhieu.Size = new System.Drawing.Size(253, 43);
            this.txtMaPhieu.TabIndex = 2;
            // 
            // dgvDanhSachPQT
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.dgvDanhSachPQT.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDanhSachPQT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvDanhSachPQT.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDanhSachPQT.BackgroundColor = System.Drawing.Color.White;
            this.dgvDanhSachPQT.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSachPQT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDanhSachPQT.ColumnHeadersHeight = 32;
            this.dgvDanhSachPQT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDanhSachPQT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MAPHIEU,
            this.PTGIAM,
            this.THOIGIANBD,
            this.THOIGIANKT,
            this.DKAPDUNG});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDanhSachPQT.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDanhSachPQT.EnableHeadersVisualStyles = false;
            this.dgvDanhSachPQT.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.dgvDanhSachPQT.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dgvDanhSachPQT.Location = new System.Drawing.Point(34, 239);
            this.dgvDanhSachPQT.Name = "dgvDanhSachPQT";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSachPQT.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDanhSachPQT.RowHeadersWidth = 51;
            this.dgvDanhSachPQT.RowHeight = 0;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.dgvDanhSachPQT.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDanhSachPQT.RowTemplate.Height = 24;
            this.dgvDanhSachPQT.SelectedIndex = -1;
            this.dgvDanhSachPQT.ShowGridLine = false;
            this.dgvDanhSachPQT.ShowRect = false;
            this.dgvDanhSachPQT.Size = new System.Drawing.Size(1067, 452);
            this.dgvDanhSachPQT.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.dgvDanhSachPQT.TabIndex = 83;
            this.dgvDanhSachPQT.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // MAPHIEU
            // 
            this.MAPHIEU.DataPropertyName = "MAPHIEU";
            this.MAPHIEU.HeaderText = "Mã Phiếu";
            this.MAPHIEU.MinimumWidth = 6;
            this.MAPHIEU.Name = "MAPHIEU";
            this.MAPHIEU.Width = 157;
            // 
            // PTGIAM
            // 
            this.PTGIAM.DataPropertyName = "PTGIAM";
            this.PTGIAM.HeaderText = "PT Giảm Giá (%)";
            this.PTGIAM.MinimumWidth = 6;
            this.PTGIAM.Name = "PTGIAM";
            this.PTGIAM.Width = 233;
            // 
            // THOIGIANBD
            // 
            this.THOIGIANBD.DataPropertyName = "THOIGIANBD";
            this.THOIGIANBD.HeaderText = "Thời Gian Bắt Đầu";
            this.THOIGIANBD.MinimumWidth = 6;
            this.THOIGIANBD.Name = "THOIGIANBD";
            this.THOIGIANBD.Width = 256;
            // 
            // THOIGIANKT
            // 
            this.THOIGIANKT.DataPropertyName = "THOIGIANKT";
            this.THOIGIANKT.HeaderText = "Thời Gian Kết Thúc";
            this.THOIGIANKT.MinimumWidth = 6;
            this.THOIGIANKT.Name = "THOIGIANKT";
            this.THOIGIANKT.Width = 265;
            // 
            // DKAPDUNG
            // 
            this.DKAPDUNG.DataPropertyName = "DKAPDUNG";
            this.DKAPDUNG.HeaderText = "Điều Kiện Áp Dụng";
            this.DKAPDUNG.MinimumWidth = 6;
            this.DKAPDUNG.Name = "DKAPDUNG";
            this.DKAPDUNG.Width = 267;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(268, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 84;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 29);
            this.label2.TabIndex = 85;
            this.label2.Text = "Mã phiếu quà tặng";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnThoat.Location = new System.Drawing.Point(1180, 643);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(288, 48);
            this.btnThoat.TabIndex = 86;
            this.btnThoat.Text = "Thoát tra cứu (F4)";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // txtPTGiam
            // 
            this.txtPTGiam.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPTGiam.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPTGiam.Location = new System.Drawing.Point(877, 159);
            this.txtPTGiam.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPTGiam.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtPTGiam.Name = "txtPTGiam";
            this.txtPTGiam.ReadOnly = true;
            this.txtPTGiam.ShowText = false;
            this.txtPTGiam.Size = new System.Drawing.Size(224, 39);
            this.txtPTGiam.TabIndex = 87;
            this.txtPTGiam.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtPTGiam.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiLabel3.ForeColor = System.Drawing.Color.Black;
            this.uiLabel3.Location = new System.Drawing.Point(666, 152);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(187, 43);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 88;
            this.uiLabel3.Text = "PT giảm";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // TraCuuPhieuQuaTang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1642, 799);
            this.Controls.Add(this.txtPTGiam);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvDanhSachPQT);
            this.Controls.Add(this.txtMaPhieu);
            this.Controls.Add(this.label1);
            this.Name = "TraCuuPhieuQuaTang";
            this.Text = "TraCuuPhieuQuaTang";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachPQT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaPhieu;
        private Sunny.UI.UIDataGridView dgvDanhSachPQT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAPHIEU;
        private System.Windows.Forms.DataGridViewTextBoxColumn PTGIAM;
        private System.Windows.Forms.DataGridViewTextBoxColumn THOIGIANBD;
        private System.Windows.Forms.DataGridViewTextBoxColumn THOIGIANKT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DKAPDUNG;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThoat;
        private Sunny.UI.UITextBox txtPTGiam;
        private Sunny.UI.UILabel uiLabel3;
    }
}