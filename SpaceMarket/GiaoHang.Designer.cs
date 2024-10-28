namespace SpaceMarket
{
    partial class GiaoHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GiaoHang));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtMoTa = new Sunny.UI.UITextBox();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.txtMaPhieu = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtDiaChiGiao = new Sunny.UI.UITextBox();
            this.txtSDT = new Sunny.UI.UITextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnLuuPhieu = new System.Windows.Forms.Button();
            this.btnHuyPhieu = new System.Windows.Forms.Button();
            this.dgvDanhSachPhieuGiaoHang = new Sunny.UI.UIDataGridView();
            this.MAPGH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MADH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGAYDUKIENGH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIACHIGIAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SDTNGUOINHANHANG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachPhieuGiaoHang)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMoTa
            // 
            this.txtMoTa.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMoTa.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoTa.Location = new System.Drawing.Point(214, 422);
            this.txtMoTa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMoTa.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.ShowText = false;
            this.txtMoTa.Size = new System.Drawing.Size(313, 39);
            this.txtMoTa.TabIndex = 5;
            this.txtMoTa.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtMoTa.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtMoTa.TextChanged += new System.EventHandler(this.txtMoTa_TextChanged);
            // 
            // uiLabel7
            // 
            this.uiLabel7.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiLabel7.Location = new System.Drawing.Point(20, 422);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(187, 43);
            this.uiLabel7.TabIndex = 52;
            this.uiLabel7.Text = "Mô tả";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel7.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiLabel6.Location = new System.Drawing.Point(20, 369);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(187, 43);
            this.uiLabel6.TabIndex = 57;
            this.uiLabel6.Text = "SDT người nhận";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel6.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiLabel5.ForeColor = System.Drawing.Color.Black;
            this.uiLabel5.Location = new System.Drawing.Point(20, 316);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(187, 43);
            this.uiLabel5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel5.TabIndex = 55;
            this.uiLabel5.Text = "Địa chỉ giao";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiLabel4.ForeColor = System.Drawing.Color.Black;
            this.uiLabel4.Location = new System.Drawing.Point(20, 142);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(321, 43);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 54;
            this.uiLabel4.Text = "Thông tin phiếu giao hàng";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtMaPhieu
            // 
            this.txtMaPhieu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaPhieu.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPhieu.Location = new System.Drawing.Point(214, 206);
            this.txtMaPhieu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMaPhieu.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtMaPhieu.Name = "txtMaPhieu";
            this.txtMaPhieu.ShowText = false;
            this.txtMaPhieu.Size = new System.Drawing.Size(313, 39);
            this.txtMaPhieu.TabIndex = 1;
            this.txtMaPhieu.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtMaPhieu.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtMaPhieu.TextChanged += new System.EventHandler(this.txtMaPhieu_TextChanged);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiLabel3.ForeColor = System.Drawing.Color.Black;
            this.uiLabel3.Location = new System.Drawing.Point(20, 260);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(187, 43);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 49;
            this.uiLabel3.Text = "Ngày giao hàng";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiLabel2.ForeColor = System.Drawing.Color.Black;
            this.uiLabel2.Location = new System.Drawing.Point(20, 206);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(187, 43);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 48;
            this.uiLabel2.Text = "Mã phiếu";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(268, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiLabel1.Location = new System.Drawing.Point(308, 31);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(981, 69);
            this.uiLabel1.TabIndex = 43;
            this.uiLabel1.Text = "QUẢN LÝ TRẠNG THÁI GIAO HÀNG";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(214, 260);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(313, 38);
            this.dateTimePicker1.TabIndex = 2;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // txtDiaChiGiao
            // 
            this.txtDiaChiGiao.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDiaChiGiao.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChiGiao.Location = new System.Drawing.Point(214, 320);
            this.txtDiaChiGiao.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDiaChiGiao.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtDiaChiGiao.Name = "txtDiaChiGiao";
            this.txtDiaChiGiao.ShowText = false;
            this.txtDiaChiGiao.Size = new System.Drawing.Size(313, 39);
            this.txtDiaChiGiao.TabIndex = 3;
            this.txtDiaChiGiao.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtDiaChiGiao.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtDiaChiGiao.TextChanged += new System.EventHandler(this.txtDiaChiGiao_TextChanged);
            // 
            // txtSDT
            // 
            this.txtSDT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSDT.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Location = new System.Drawing.Point(214, 373);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSDT.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.ShowText = false;
            this.txtSDT.Size = new System.Drawing.Size(313, 39);
            this.txtSDT.TabIndex = 4;
            this.txtSDT.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtSDT.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtSDT.TextChanged += new System.EventHandler(this.txtSDT_TextChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(28, 505);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(22, 22);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 63;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(317, 506);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(22, 22);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 62;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnLuuPhieu
            // 
            this.btnLuuPhieu.BackColor = System.Drawing.Color.Transparent;
            this.btnLuuPhieu.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLuuPhieu.Location = new System.Drawing.Point(306, 497);
            this.btnLuuPhieu.Name = "btnLuuPhieu";
            this.btnLuuPhieu.Size = new System.Drawing.Size(222, 36);
            this.btnLuuPhieu.TabIndex = 6;
            this.btnLuuPhieu.Text = "F10 - LƯU PHIẾU";
            this.btnLuuPhieu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuuPhieu.UseVisualStyleBackColor = false;
            this.btnLuuPhieu.Click += new System.EventHandler(this.btnLuuPhieu_Click);
            // 
            // btnHuyPhieu
            // 
            this.btnHuyPhieu.BackColor = System.Drawing.Color.Transparent;
            this.btnHuyPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnHuyPhieu.Location = new System.Drawing.Point(12, 498);
            this.btnHuyPhieu.Name = "btnHuyPhieu";
            this.btnHuyPhieu.Size = new System.Drawing.Size(260, 36);
            this.btnHuyPhieu.TabIndex = 7;
            this.btnHuyPhieu.Text = "ESC - HỦY PHIẾU";
            this.btnHuyPhieu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHuyPhieu.UseVisualStyleBackColor = false;
            this.btnHuyPhieu.Click += new System.EventHandler(this.btnHuyPhieu_Click);
            // 
            // dgvDanhSachPhieuGiaoHang
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.dgvDanhSachPhieuGiaoHang.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDanhSachPhieuGiaoHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvDanhSachPhieuGiaoHang.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDanhSachPhieuGiaoHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvDanhSachPhieuGiaoHang.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSachPhieuGiaoHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDanhSachPhieuGiaoHang.ColumnHeadersHeight = 32;
            this.dgvDanhSachPhieuGiaoHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDanhSachPhieuGiaoHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MAPGH,
            this.MADH,
            this.NGAYDUKIENGH,
            this.DIACHIGIAO,
            this.SDTNGUOINHANHANG,
            this.MOTA});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDanhSachPhieuGiaoHang.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDanhSachPhieuGiaoHang.EnableHeadersVisualStyles = false;
            this.dgvDanhSachPhieuGiaoHang.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.dgvDanhSachPhieuGiaoHang.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dgvDanhSachPhieuGiaoHang.Location = new System.Drawing.Point(534, 209);
            this.dgvDanhSachPhieuGiaoHang.Name = "dgvDanhSachPhieuGiaoHang";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSachPhieuGiaoHang.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDanhSachPhieuGiaoHang.RowHeadersWidth = 51;
            this.dgvDanhSachPhieuGiaoHang.RowHeight = 0;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.dgvDanhSachPhieuGiaoHang.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDanhSachPhieuGiaoHang.RowTemplate.Height = 24;
            this.dgvDanhSachPhieuGiaoHang.SelectedIndex = -1;
            this.dgvDanhSachPhieuGiaoHang.ShowGridLine = false;
            this.dgvDanhSachPhieuGiaoHang.ShowRect = false;
            this.dgvDanhSachPhieuGiaoHang.Size = new System.Drawing.Size(910, 452);
            this.dgvDanhSachPhieuGiaoHang.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.dgvDanhSachPhieuGiaoHang.TabIndex = 64;
            this.dgvDanhSachPhieuGiaoHang.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.dgvDanhSachPhieuGiaoHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDanhSachPhieuGiaoHang_CellClick);
            // 
            // MAPGH
            // 
            this.MAPGH.DataPropertyName = "MAPGH";
            this.MAPGH.HeaderText = "Mã phiếu giao";
            this.MAPGH.MinimumWidth = 6;
            this.MAPGH.Name = "MAPGH";
            this.MAPGH.Width = 178;
            // 
            // MADH
            // 
            this.MADH.DataPropertyName = "MADH";
            this.MADH.HeaderText = "Mã đơn hàng";
            this.MADH.MinimumWidth = 6;
            this.MADH.Name = "MADH";
            this.MADH.Width = 167;
            // 
            // NGAYDUKIENGH
            // 
            this.NGAYDUKIENGH.DataPropertyName = "NGAYDUKIENGH";
            this.NGAYDUKIENGH.HeaderText = "Ngày giao";
            this.NGAYDUKIENGH.MinimumWidth = 6;
            this.NGAYDUKIENGH.Name = "NGAYDUKIENGH";
            this.NGAYDUKIENGH.Width = 139;
            // 
            // DIACHIGIAO
            // 
            this.DIACHIGIAO.DataPropertyName = "DIACHIGIAO";
            this.DIACHIGIAO.HeaderText = "Địa chỉ giao hàng";
            this.DIACHIGIAO.MinimumWidth = 6;
            this.DIACHIGIAO.Name = "DIACHIGIAO";
            this.DIACHIGIAO.Width = 204;
            // 
            // SDTNGUOINHANHANG
            // 
            this.SDTNGUOINHANHANG.DataPropertyName = "SDTNGUOINHANHANG";
            this.SDTNGUOINHANHANG.HeaderText = "SĐT người nhận";
            this.SDTNGUOINHANHANG.MinimumWidth = 6;
            this.SDTNGUOINHANHANG.Name = "SDTNGUOINHANHANG";
            this.SDTNGUOINHANHANG.Width = 189;
            // 
            // MOTA
            // 
            this.MOTA.DataPropertyName = "MOTA";
            this.MOTA.HeaderText = "Mô tả";
            this.MOTA.MinimumWidth = 6;
            this.MOTA.Name = "MOTA";
            this.MOTA.Width = 97;
            // 
            // GiaoHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1456, 673);
            this.Controls.Add(this.dgvDanhSachPhieuGiaoHang);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnLuuPhieu);
            this.Controls.Add(this.btnHuyPhieu);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtDiaChiGiao);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.uiLabel7);
            this.Controls.Add(this.uiLabel6);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.txtMaPhieu);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.uiLabel1);
            this.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "GiaoHang";
            this.Text = "Giao Hàng";
            this.Load += new System.EventHandler(this.GiaoHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachPhieuGiaoHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITextBox txtMoTa;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UITextBox txtMaPhieu;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Sunny.UI.UILabel uiLabel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private Sunny.UI.UITextBox txtDiaChiGiao;
        private Sunny.UI.UITextBox txtSDT;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnLuuPhieu;
        private System.Windows.Forms.Button btnHuyPhieu;
        private Sunny.UI.UIDataGridView dgvDanhSachPhieuGiaoHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAPGH;
        private System.Windows.Forms.DataGridViewTextBoxColumn MADH;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGAYDUKIENGH;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIACHIGIAO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SDTNGUOINHANHANG;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOTA;
    }
}