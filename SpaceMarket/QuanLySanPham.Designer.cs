namespace SpaceMarket
{
    partial class QuanLySanPham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuanLySanPham));
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.txtsearchsp = new Sunny.UI.UITextBox();
            this.txtTenSanPham = new Sunny.UI.UITextBox();
            this.txtMaSanPham = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.btnXoa = new Sunny.UI.UIButton();
            this.btnSua = new Sunny.UI.UIButton();
            this.btnThem = new Sunny.UI.UIButton();
            this.datagwdanhsachsanpham = new Sunny.UI.UIDataGridView();
            this.MASP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TENSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.txtGia = new Sunny.UI.UITextBox();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.cbbNhaCungCap = new Sunny.UI.UIComboBox();
            this.cbbDanhMuc = new Sunny.UI.UIComboBox();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.btnIn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.datagwdanhsachsanpham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnIn)).BeginInit();
            this.SuspendLayout();
            // 
            // uiContextMenuStrip1
            // 
            this.uiContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiContextMenuStrip1.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.uiContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.uiContextMenuStrip1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtsearchsp
            // 
            this.txtsearchsp.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtsearchsp.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearchsp.Location = new System.Drawing.Point(552, 132);
            this.txtsearchsp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtsearchsp.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtsearchsp.Name = "txtsearchsp";
            this.txtsearchsp.ShowText = false;
            this.txtsearchsp.Size = new System.Drawing.Size(298, 39);
            this.txtsearchsp.TabIndex = 35;
            this.txtsearchsp.Text = "Tìm kiếm theo mã, theo tên, theo nhà cung cấp,...";
            this.txtsearchsp.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtsearchsp.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtsearchsp.TextChanged += new System.EventHandler(this.txtsearchsp_TextChanged);
            this.txtsearchsp.Leave += new System.EventHandler(this.txtsearchsp_Leave);
            this.txtsearchsp.Enter += new System.EventHandler(this.txtsearchsp_Enter);
            // 
            // txtTenSanPham
            // 
            this.txtTenSanPham.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenSanPham.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenSanPham.Location = new System.Drawing.Point(222, 289);
            this.txtTenSanPham.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTenSanPham.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtTenSanPham.Name = "txtTenSanPham";
            this.txtTenSanPham.ShowText = false;
            this.txtTenSanPham.Size = new System.Drawing.Size(313, 39);
            this.txtTenSanPham.TabIndex = 36;
            this.txtTenSanPham.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtTenSanPham.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtTenSanPham.TextChanged += new System.EventHandler(this.txtTenSanPham_TextChanged);
            // 
            // txtMaSanPham
            // 
            this.txtMaSanPham.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaSanPham.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSanPham.Location = new System.Drawing.Point(222, 235);
            this.txtMaSanPham.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMaSanPham.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtMaSanPham.Name = "txtMaSanPham";
            this.txtMaSanPham.ShowText = false;
            this.txtMaSanPham.Size = new System.Drawing.Size(313, 39);
            this.txtMaSanPham.TabIndex = 34;
            this.txtMaSanPham.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtMaSanPham.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtMaSanPham.TextChanged += new System.EventHandler(this.txtMaSanPham_TextChanged);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiLabel3.ForeColor = System.Drawing.Color.Black;
            this.uiLabel3.Location = new System.Drawing.Point(28, 289);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(187, 43);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 33;
            this.uiLabel3.Text = "Tên sản phẩm";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiLabel2.ForeColor = System.Drawing.Color.Black;
            this.uiLabel2.Location = new System.Drawing.Point(28, 235);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(187, 43);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 32;
            this.uiLabel2.Text = "Mã sản phẩm";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnXoa
            // 
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FillColor = System.Drawing.Color.Red;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.btnXoa.Location = new System.Drawing.Point(411, 576);
            this.btnXoa.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 35);
            this.btnXoa.Style = Sunny.UI.UIStyle.Custom;
            this.btnXoa.TabIndex = 31;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.btnSua.Location = new System.Drawing.Point(249, 576);
            this.btnSua.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 35);
            this.btnSua.TabIndex = 30;
            this.btnSua.Text = "Sửa";
            this.btnSua.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.FillColor = System.Drawing.Color.LightSeaGreen;
            this.btnThem.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.btnThem.Location = new System.Drawing.Point(53, 576);
            this.btnThem.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(131, 35);
            this.btnThem.Style = Sunny.UI.UIStyle.Custom;
            this.btnThem.TabIndex = 29;
            this.btnThem.Text = "Thêm mới";
            this.btnThem.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // datagwdanhsachsanpham
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.datagwdanhsachsanpham.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.datagwdanhsachsanpham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.datagwdanhsachsanpham.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.datagwdanhsachsanpham.BackgroundColor = System.Drawing.Color.White;
            this.datagwdanhsachsanpham.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagwdanhsachsanpham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.datagwdanhsachsanpham.ColumnHeadersHeight = 32;
            this.datagwdanhsachsanpham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.datagwdanhsachsanpham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MASP,
            this.TENSP,
            this.NCC,
            this.DM,
            this.GIA});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagwdanhsachsanpham.DefaultCellStyle = dataGridViewCellStyle3;
            this.datagwdanhsachsanpham.EnableHeadersVisualStyles = false;
            this.datagwdanhsachsanpham.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.datagwdanhsachsanpham.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.datagwdanhsachsanpham.Location = new System.Drawing.Point(552, 179);
            this.datagwdanhsachsanpham.Name = "datagwdanhsachsanpham";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagwdanhsachsanpham.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.datagwdanhsachsanpham.RowHeadersWidth = 51;
            this.datagwdanhsachsanpham.RowHeight = 0;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.datagwdanhsachsanpham.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.datagwdanhsachsanpham.RowTemplate.Height = 24;
            this.datagwdanhsachsanpham.SelectedIndex = -1;
            this.datagwdanhsachsanpham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagwdanhsachsanpham.ShowGridLine = false;
            this.datagwdanhsachsanpham.ShowRect = false;
            this.datagwdanhsachsanpham.Size = new System.Drawing.Size(1014, 491);
            this.datagwdanhsachsanpham.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.datagwdanhsachsanpham.TabIndex = 28;
            this.datagwdanhsachsanpham.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.datagwdanhsachsanpham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagwdanhsachsanpham_CellClick);
            // 
            // MASP
            // 
            this.MASP.DataPropertyName = "MASP";
            this.MASP.HeaderText = "Mã sản phẩm";
            this.MASP.MinimumWidth = 6;
            this.MASP.Name = "MASP";
            this.MASP.Width = 170;
            // 
            // TENSP
            // 
            this.TENSP.DataPropertyName = "TENSP";
            this.TENSP.HeaderText = "Tên sản phẩm";
            this.TENSP.MinimumWidth = 6;
            this.TENSP.Name = "TENSP";
            this.TENSP.Width = 173;
            // 
            // NCC
            // 
            this.NCC.DataPropertyName = "NCC";
            this.NCC.HeaderText = "Nhà cung cấp";
            this.NCC.MinimumWidth = 6;
            this.NCC.Name = "NCC";
            this.NCC.Width = 172;
            // 
            // DM
            // 
            this.DM.DataPropertyName = "DM";
            this.DM.HeaderText = "Danh mục";
            this.DM.MinimumWidth = 6;
            this.DM.Name = "DM";
            this.DM.Width = 136;
            // 
            // GIA
            // 
            this.GIA.DataPropertyName = "GIA";
            this.GIA.HeaderText = "Giá";
            this.GIA.MinimumWidth = 6;
            this.GIA.Name = "GIA";
            this.GIA.Width = 71;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(268, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiLabel1.Location = new System.Drawing.Point(374, 19);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(856, 69);
            this.uiLabel1.TabIndex = 26;
            this.uiLabel1.Text = "QUẢN LÝ SẢN PHẨM";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiLabel4.ForeColor = System.Drawing.Color.Black;
            this.uiLabel4.Location = new System.Drawing.Point(28, 179);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(229, 43);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 38;
            this.uiLabel4.Text = "Thông tin sản phẩm";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiLabel5.ForeColor = System.Drawing.Color.Black;
            this.uiLabel5.Location = new System.Drawing.Point(28, 345);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(187, 43);
            this.uiLabel5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel5.TabIndex = 39;
            this.uiLabel5.Text = "Nhà cung cấp";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiLabel6.Location = new System.Drawing.Point(28, 398);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(187, 43);
            this.uiLabel6.TabIndex = 41;
            this.uiLabel6.Text = "Danh mục";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel6.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtGia
            // 
            this.txtGia.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGia.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGia.Location = new System.Drawing.Point(222, 451);
            this.txtGia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtGia.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtGia.Name = "txtGia";
            this.txtGia.ShowText = false;
            this.txtGia.Size = new System.Drawing.Size(313, 39);
            this.txtGia.TabIndex = 38;
            this.txtGia.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtGia.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtGia.TextChanged += new System.EventHandler(this.txtGia_TextChanged);
            // 
            // uiLabel7
            // 
            this.uiLabel7.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiLabel7.Location = new System.Drawing.Point(28, 451);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(187, 43);
            this.uiLabel7.TabIndex = 37;
            this.uiLabel7.Text = "Giá";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel7.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cbbNhaCungCap
            // 
            this.cbbNhaCungCap.DataSource = null;
            this.cbbNhaCungCap.FillColor = System.Drawing.Color.White;
            this.cbbNhaCungCap.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbNhaCungCap.Location = new System.Drawing.Point(222, 345);
            this.cbbNhaCungCap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbbNhaCungCap.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbbNhaCungCap.Name = "cbbNhaCungCap";
            this.cbbNhaCungCap.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbbNhaCungCap.Size = new System.Drawing.Size(313, 43);
            this.cbbNhaCungCap.TabIndex = 40;
            this.cbbNhaCungCap.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbbNhaCungCap.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cbbNhaCungCap.SelectedIndexChanged += new System.EventHandler(this.cbbNhaCungCap_SelectedIndexChanged);
            // 
            // cbbDanhMuc
            // 
            this.cbbDanhMuc.DataSource = null;
            this.cbbDanhMuc.FillColor = System.Drawing.Color.White;
            this.cbbDanhMuc.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbDanhMuc.Location = new System.Drawing.Point(222, 398);
            this.cbbDanhMuc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbbDanhMuc.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbbDanhMuc.Name = "cbbDanhMuc";
            this.cbbDanhMuc.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbbDanhMuc.Size = new System.Drawing.Size(313, 43);
            this.cbbDanhMuc.TabIndex = 42;
            this.cbbDanhMuc.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbbDanhMuc.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cbbDanhMuc.SelectedIndexChanged += new System.EventHandler(this.cbbDanhMuc_SelectedIndexChanged);
            // 
            // uiLabel9
            // 
            this.uiLabel9.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabel9.ForeColor = System.Drawing.Color.Red;
            this.uiLabel9.Location = new System.Drawing.Point(962, 148);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(459, 23);
            this.uiLabel9.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel9.TabIndex = 44;
            this.uiLabel9.Text = "Bấm vào biẻu tượng in để in danh sách sản phẩm hiện có";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel9.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnIn
            // 
            this.btnIn.Image = ((System.Drawing.Image)(resources.GetObject("btnIn.Image")));
            this.btnIn.Location = new System.Drawing.Point(1427, 133);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(40, 40);
            this.btnIn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnIn.TabIndex = 43;
            this.btnIn.TabStop = false;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // QuanLySanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1578, 673);
            this.Controls.Add(this.uiLabel9);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.txtGia);
            this.Controls.Add(this.uiLabel7);
            this.Controls.Add(this.cbbDanhMuc);
            this.Controls.Add(this.uiLabel6);
            this.Controls.Add(this.cbbNhaCungCap);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.txtsearchsp);
            this.Controls.Add(this.txtTenSanPham);
            this.Controls.Add(this.txtMaSanPham);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.datagwdanhsachsanpham);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.uiLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QuanLySanPham";
            this.Text = "QUẢN LÝ SẢN PHẨM";
            this.Load += new System.EventHandler(this.QuanLySanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagwdanhsachsanpham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnIn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private Sunny.UI.UITextBox txtsearchsp;
        private Sunny.UI.UITextBox txtTenSanPham;
        private Sunny.UI.UITextBox txtMaSanPham;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIButton btnXoa;
        private Sunny.UI.UIButton btnSua;
        private Sunny.UI.UIButton btnThem;
        private Sunny.UI.UIDataGridView datagwdanhsachsanpham;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel5;
        private System.Windows.Forms.DataGridViewTextBoxColumn MASP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TENSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn NCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn DM;
        private System.Windows.Forms.DataGridViewTextBoxColumn GIA;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UITextBox txtGia;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UIComboBox cbbNhaCungCap;
        private Sunny.UI.UIComboBox cbbDanhMuc;
        private Sunny.UI.UILabel uiLabel9;
        private System.Windows.Forms.PictureBox btnIn;
    }
}