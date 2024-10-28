namespace SpaceMarket
{
    partial class DanhMucSanPham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DanhMucSanPham));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.btnsearchdanhmuc = new System.Windows.Forms.PictureBox();
            this.txtsearchdanhmuc = new Sunny.UI.UITextBox();
            this.txtTenDanhMuc = new Sunny.UI.UITextBox();
            this.txtMaDanhMuc = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.btnXoa = new Sunny.UI.UIButton();
            this.btnSua = new Sunny.UI.UIButton();
            this.btnThem = new Sunny.UI.UIButton();
            this.datagwdanhsachdanhmuc = new Sunny.UI.UIDataGridView();
            this.madanhmuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tendanhmuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            ((System.ComponentModel.ISupportInitialize)(this.btnsearchdanhmuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagwdanhsachdanhmuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabel4.ForeColor = System.Drawing.Color.Red;
            this.uiLabel4.Location = new System.Drawing.Point(33, 336);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(501, 188);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 25;
            this.uiLabel4.Text = "Mã danh mục sẽ được tự động tạo nhằm đảm bảo tính đồng nhất và nhất quán trong CS" +
    "DL";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiLabel4.Click += new System.EventHandler(this.uiLabel4_Click);
            // 
            // btnsearchdanhmuc
            // 
            this.btnsearchdanhmuc.Image = ((System.Drawing.Image)(resources.GetObject("btnsearchdanhmuc.Image")));
            this.btnsearchdanhmuc.Location = new System.Drawing.Point(831, 132);
            this.btnsearchdanhmuc.Name = "btnsearchdanhmuc";
            this.btnsearchdanhmuc.Size = new System.Drawing.Size(40, 40);
            this.btnsearchdanhmuc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnsearchdanhmuc.TabIndex = 24;
            this.btnsearchdanhmuc.TabStop = false;
            this.btnsearchdanhmuc.Click += new System.EventHandler(this.btnsearchdanhmuc_Click);
            // 
            // txtsearchdanhmuc
            // 
            this.txtsearchdanhmuc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtsearchdanhmuc.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearchdanhmuc.Location = new System.Drawing.Point(552, 132);
            this.txtsearchdanhmuc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtsearchdanhmuc.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtsearchdanhmuc.Name = "txtsearchdanhmuc";
            this.txtsearchdanhmuc.ShowText = false;
            this.txtsearchdanhmuc.Size = new System.Drawing.Size(260, 39);
            this.txtsearchdanhmuc.TabIndex = 22;
            this.txtsearchdanhmuc.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtsearchdanhmuc.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtTenDanhMuc
            // 
            this.txtTenDanhMuc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenDanhMuc.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDanhMuc.Location = new System.Drawing.Point(221, 233);
            this.txtTenDanhMuc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTenDanhMuc.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtTenDanhMuc.Name = "txtTenDanhMuc";
            this.txtTenDanhMuc.ShowText = false;
            this.txtTenDanhMuc.Size = new System.Drawing.Size(313, 39);
            this.txtTenDanhMuc.TabIndex = 23;
            this.txtTenDanhMuc.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtTenDanhMuc.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtMaDanhMuc
            // 
            this.txtMaDanhMuc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaDanhMuc.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaDanhMuc.Location = new System.Drawing.Point(221, 179);
            this.txtMaDanhMuc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMaDanhMuc.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtMaDanhMuc.Name = "txtMaDanhMuc";
            this.txtMaDanhMuc.ReadOnly = true;
            this.txtMaDanhMuc.ShowText = false;
            this.txtMaDanhMuc.Size = new System.Drawing.Size(313, 39);
            this.txtMaDanhMuc.TabIndex = 21;
            this.txtMaDanhMuc.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtMaDanhMuc.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiLabel3.ForeColor = System.Drawing.Color.Black;
            this.uiLabel3.Location = new System.Drawing.Point(27, 233);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(187, 43);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 20;
            this.uiLabel3.Text = "Tên danh mục";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiLabel2.ForeColor = System.Drawing.Color.Black;
            this.uiLabel2.Location = new System.Drawing.Point(27, 179);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(187, 43);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 19;
            this.uiLabel2.Text = "Mã danh mục";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnXoa
            // 
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FillColor = System.Drawing.Color.Red;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.btnXoa.Location = new System.Drawing.Point(406, 627);
            this.btnXoa.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 35);
            this.btnXoa.Style = Sunny.UI.UIStyle.Custom;
            this.btnXoa.TabIndex = 18;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.btnSua.Location = new System.Drawing.Point(244, 627);
            this.btnSua.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 35);
            this.btnSua.TabIndex = 17;
            this.btnSua.Text = "Sửa";
            this.btnSua.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.FillColor = System.Drawing.Color.LightSeaGreen;
            this.btnThem.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.btnThem.Location = new System.Drawing.Point(48, 627);
            this.btnThem.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(131, 35);
            this.btnThem.Style = Sunny.UI.UIStyle.Custom;
            this.btnThem.TabIndex = 16;
            this.btnThem.Text = "Thêm mới";
            this.btnThem.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // datagwdanhsachdanhmuc
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.datagwdanhsachdanhmuc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.datagwdanhsachdanhmuc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagwdanhsachdanhmuc.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.datagwdanhsachdanhmuc.BackgroundColor = System.Drawing.Color.White;
            this.datagwdanhsachdanhmuc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagwdanhsachdanhmuc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.datagwdanhsachdanhmuc.ColumnHeadersHeight = 32;
            this.datagwdanhsachdanhmuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.datagwdanhsachdanhmuc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.madanhmuc,
            this.tendanhmuc});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagwdanhsachdanhmuc.DefaultCellStyle = dataGridViewCellStyle3;
            this.datagwdanhsachdanhmuc.EnableHeadersVisualStyles = false;
            this.datagwdanhsachdanhmuc.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.datagwdanhsachdanhmuc.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.datagwdanhsachdanhmuc.Location = new System.Drawing.Point(552, 179);
            this.datagwdanhsachdanhmuc.Name = "datagwdanhsachdanhmuc";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagwdanhsachdanhmuc.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.datagwdanhsachdanhmuc.RowHeadersWidth = 51;
            this.datagwdanhsachdanhmuc.RowHeight = 0;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.datagwdanhsachdanhmuc.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.datagwdanhsachdanhmuc.RowTemplate.Height = 24;
            this.datagwdanhsachdanhmuc.SelectedIndex = -1;
            this.datagwdanhsachdanhmuc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagwdanhsachdanhmuc.ShowGridLine = false;
            this.datagwdanhsachdanhmuc.ShowRect = false;
            this.datagwdanhsachdanhmuc.Size = new System.Drawing.Size(708, 491);
            this.datagwdanhsachdanhmuc.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.datagwdanhsachdanhmuc.TabIndex = 15;
            this.datagwdanhsachdanhmuc.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.datagwdanhsachdanhmuc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagwdanhsachdanhmuc_CellClick);
            // 
            // madanhmuc
            // 
            this.madanhmuc.HeaderText = "Mã danh mục";
            this.madanhmuc.MinimumWidth = 6;
            this.madanhmuc.Name = "madanhmuc";
            // 
            // tendanhmuc
            // 
            this.tendanhmuc.HeaderText = "Tên danh mục";
            this.tendanhmuc.MinimumWidth = 6;
            this.tendanhmuc.Name = "tendanhmuc";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(268, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiLabel1.Location = new System.Drawing.Point(277, 22);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(856, 69);
            this.uiLabel1.TabIndex = 13;
            this.uiLabel1.Text = "QUẢN LÝ DANH MỤC SẢN PHẨM";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // DanhMucSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.btnsearchdanhmuc);
            this.Controls.Add(this.txtsearchdanhmuc);
            this.Controls.Add(this.txtTenDanhMuc);
            this.Controls.Add(this.txtMaDanhMuc);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.datagwdanhsachdanhmuc);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.uiLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DanhMucSanPham";
            this.Text = "DanhMucSanPham";
            this.Load += new System.EventHandler(this.DanhMucSanPham_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DanhMucSanPham_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.btnsearchdanhmuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagwdanhsachdanhmuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private Sunny.UI.UILabel uiLabel4;
        private System.Windows.Forms.PictureBox btnsearchdanhmuc;
        private Sunny.UI.UITextBox txtsearchdanhmuc;
        private Sunny.UI.UITextBox txtTenDanhMuc;
        private Sunny.UI.UITextBox txtMaDanhMuc;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIButton btnXoa;
        private Sunny.UI.UIButton btnSua;
        private Sunny.UI.UIButton btnThem;
        private Sunny.UI.UIDataGridView datagwdanhsachdanhmuc;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Sunny.UI.UILabel uiLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn madanhmuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn tendanhmuc;
    }
}