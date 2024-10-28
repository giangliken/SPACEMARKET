using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceMarket
{
    public partial class QuanLySanPham : Form
    {
        private readonly ProductService productService = new ProductService();
        public QuanLySanPham()
        {
            InitializeComponent();
        }

        // Trong lớp QuanLySanPham
        public void DisableAddButton()
        {
            btnThem.Visible = false; // Vô hiệu hóa button thêm
            btnSua.Visible = false;
            btnXoa.Visible = false;
        }


        private void QuanLySanPham_Load(object sender, EventArgs e)
        {
            //Đổ dữ liệu vào cbb Nhà cung cấp
            cbbNhaCungCap.DataSource = productService.GetNCC();
            cbbNhaCungCap.DisplayMember = "TENNCC";
            cbbNhaCungCap.ValueMember = "MANCC";

            //Đổ dữ liệu vào cbb Danh mục
            cbbDanhMuc.DataSource = productService.GetDM();
            cbbDanhMuc.DisplayMember = "TENDM";
            cbbDanhMuc.ValueMember = "MADM";
            datagwdanhsachsanpham.DataSource = productService.GetAll();
        }

        private void datagwdanhsachsanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có ô nào được chọn hay không
            if (e.RowIndex >= 0)
            {
                // Lấy dữ liệu từ DataGridView
                int rowIndex = e.RowIndex;
                ////string manv = datagwdanhsachnhanvien.Rows[rowIndex].Cells["MANV"].Value.ToString();
                //string tennv = datagwdanhsachnhanvien.Rows[rowIndex].Cells["TENNV"].Value.ToString();
                //string cv = datagwdanhsachnhanvien.Rows[rowIndex].Cells["CV"].Value.ToString();
                //string sdt = datagwdanhsachnhanvien.Rows[rowIndex].Cells["SDTNV"].Value.ToString();
                //string email = datagwdanhsachnhanvien.Rows[rowIndex].Cells["EMAILNV"].Value.ToString();
                //string cccd = datagwdanhsachnhanvien.Rows[rowIndex].Cells["CCCD"].Value.ToString();
                //DateTime ngaysinh = (DateTime)datagwdanhsachnhanvien.Rows[rowIndex].Cells["NGAYSINH"].Value; // Lấy ngày sinh

                string masp = datagwdanhsachsanpham.Rows[rowIndex].Cells["MASP"].Value.ToString();
                string tensp = datagwdanhsachsanpham.Rows[rowIndex].Cells["TENSP"].Value.ToString();
                string tenncc = datagwdanhsachsanpham.Rows[rowIndex].Cells["NCC"].Value.ToString();
                string tendm = datagwdanhsachsanpham.Rows[rowIndex].Cells["DM"].Value.ToString();
                string gia = datagwdanhsachsanpham.Rows[rowIndex].Cells["GIA"].Value.ToString();
                // Đổ dữ liệu ngược vào các ô nhập liệu
                txtMaSanPham.Text = masp;
                txtTenSanPham.Text = tensp;
                cbbNhaCungCap.Text = tenncc;
                cbbDanhMuc.Text = tendm;
                txtGia.Text = gia;
                //txtm.Text = manv; // Đảm bảo bạn có txtMaNV để hiển thị Mã NV
                //txtFullName.Text = tennv;
                //txtChucVu.Text = cv;
                //txtPhone.Text = sdt;
                //txtEmail.Text = email;
                //txtcccd.Text = cccd; // Thêm ô nhập liệu cho CCCD
                //dtpNgaySinh.Value = ngaysinh; // Đổ ngày sinh vào DateTimePicker
            }
        }

        private void txtMaSanPham_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenSanPham_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbbNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các ô nhập liệu
            string masp = txtMaSanPham.Text;
            string tensp = txtTenSanPham.Text;
            string mancc = cbbNhaCungCap.SelectedValue.ToString(); // Giả sử ComboBox chứa mã nhà cung cấp dưới dạng Value
            string madm = cbbDanhMuc.SelectedValue.ToString();     // Giả sử ComboBox chứa mã danh mục dưới dạng Value
            decimal giaban;

            // Kiểm tra nếu giá bán nhập vào hợp lệ
            if (!decimal.TryParse(txtGia.Text, out giaban))
            {
                MessageBox.Show("Vui lòng nhập giá bán hợp lệ!");
                return;
            }

            // Gọi phương thức AddProduct để thêm sản phẩm
            bool result = productService.AddProduct(masp, mancc, madm, tensp, giaban);

            // Hiển thị thông báo kết quả
            if (result)
            {
                MessageBox.Show("Thêm sản phẩm thành công!");
                // Làm sạch các ô nhập liệu
                ClearInputFields();
                // Tải lại dữ liệu
                LoadData();
            }
            else
            {
                MessageBox.Show("Thêm sản phẩm thất bại. Vui lòng kiểm tra lại thông tin!");
            }
        }


        // Phương thức làm sạch các ô nhập liệu (nếu cần)
        private void ClearInputFields()
        {
            txtMaSanPham.Clear();
            txtTenSanPham.Clear();
            cbbNhaCungCap.SelectedIndex = -1; // Reset ComboBox về trạng thái ban đầu
            cbbDanhMuc.SelectedIndex = -1;
            txtGia.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các ô nhập liệu
            string masp = txtMaSanPham.Text;
            string tensp = txtTenSanPham.Text;
            string mancc = cbbNhaCungCap.SelectedValue.ToString();
            string madm = cbbDanhMuc.SelectedValue.ToString();
            decimal giaban;

            // Kiểm tra nếu giá bán nhập vào hợp lệ
            if (!decimal.TryParse(txtGia.Text, out giaban))
            {
                MessageBox.Show("Vui lòng nhập giá bán hợp lệ!");
                return;
            }

            // Gọi phương thức UpdateProduct để sửa sản phẩm
            bool result = productService.UpdateProduct(masp, mancc, madm, tensp, giaban);

            // Hiển thị thông báo kết quả
            if (result)
            {
                MessageBox.Show("Sửa sản phẩm thành công!");
                ClearInputFields();  // Làm sạch các ô nhập liệu sau khi sửa
                LoadData();  // Tải lại dữ liệu vào DataGridView sau khi sửa
            }
            else
            {
                MessageBox.Show("Sửa sản phẩm thất bại!");
            }
        }

        private void LoadData()
        {
            // Gọi phương thức GetAll để lấy danh sách sản phẩm và đổ vào DataGridView
            datagwdanhsachsanpham.DataSource = productService.GetAll();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Lấy mã sản phẩm từ ô nhập liệu
            string masp = txtMaSanPham.Text;

            // Kiểm tra nếu người dùng chưa chọn mã sản phẩm
            if (string.IsNullOrEmpty(masp))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!");
                return;
            }

            // Hiển thị hộp thoại xác nhận xóa
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Gọi phương thức DeleteProduct để xóa sản phẩm
                bool deleteResult = productService.DeleteProduct(masp);

                // Hiển thị thông báo kết quả
                if (deleteResult)
                {
                    MessageBox.Show("Xóa sản phẩm thành công!");
                    ClearInputFields();  // Làm sạch các ô nhập liệu sau khi xóa
                    LoadData();  // Tải lại dữ liệu vào DataGridView sau khi xóa
                }
                else
                {
                    MessageBox.Show("Xóa sản phẩm thất bại!");
                }
            }
        }

        private void txtsearchsp_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtsearchsp.Text.Trim(); // Lấy từ khóa tìm kiếm

            if (string.IsNullOrEmpty(keyword))
            {
                LoadData();
            }
            else
            {
                datagwdanhsachsanpham.DataSource = productService.SearchProducts(keyword);
            }

        }

        private void txtsearchsp_Enter(object sender, EventArgs e)
        {
            if (txtsearchsp.Text == "Tìm kiếm theo mã, theo tên, theo nhà cung cấp,...")
            {
                txtsearchsp.Text = string.Empty;
                txtsearchsp.ForeColor = Color.Black;
            }
        }

        private void txtsearchsp_Leave(object sender, EventArgs e)
        {
            if (txtsearchsp.Text == string.Empty)
            {
                txtsearchsp.Text = "Tìm kiếm theo mã, theo tên, theo nhà cung cấp,...";
                txtsearchsp.ForeColor = Color.Silver;
            }
            LoadData();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            InSanPham inSanPham = new InSanPham();
            inSanPham.ShowDialog();
        }
    }
}
