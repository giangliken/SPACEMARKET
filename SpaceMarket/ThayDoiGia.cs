using BLL;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceMarket
{
    public partial class ThayDoiGia : Form
    {
        private readonly ProductService productService = new ProductService();
        public ThayDoiGia()
        {
            InitializeComponent();
            txtma.ReadOnly = true;
            txtten.ReadOnly = true;
            txtgiacu.ReadOnly = true;
        }



        private void ThayDoiGia_Load(object sender, EventArgs e)
        {
            datagwdanhsachsanpham.DataSource = productService.GetAll();
            //datagwdanhsachsanpham.Columns["NCC"].Visible = false;
            //datagwdanhsachsanpham.Columns["DM"].Visible = false;


            datagwdanhsachlichsugia.DataSource = productService.GetAllLichSu();
        }

        private void datagwdanhsachsanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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
                txtma.Text = masp;
                txtten.Text = tensp;
                txtgiacu.Text = gia;

                string mancc = productService.GetMaNCCByTen(tenncc);
                string madm = productService.GetMaDMByTen(tendm);

                // Lưu MANCC và MADM vào các biến tạm (khai báo private trong form)
                this.selectedMancc = mancc;
                this.selectedMadm = madm;
                //txtm.Text = manv; // Đảm bảo bạn có txtMaNV để hiển thị Mã NV
                //txtFullName.Text = tennv;
                //txtChucVu.Text = cv;
                //txtPhone.Text = sdt;
                //txtEmail.Text = email;
                //txtcccd.Text = cccd; // Thêm ô nhập liệu cho CCCD
                //dtpNgaySinh.Value = ngaysinh; // Đổ ngày sinh vào DateTimePicker
            }
        }
        // Khai báo các biến tạm trong class ThayDoiGia
        private string selectedMancc;
        private string selectedMadm;


        private void txtma_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtten_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtgia_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnthaydoi_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các ô nhập liệu
            string masp = txtma.Text;
            string tensp = txtten.Text;
            decimal giaban;

            //// Tìm kiếm sản phẩm theo từ khóa
            //var sanpham = productService.SearchProducts(masp).FirstOrDefault();

            //// Lấy giá trị của mancc và madm
            //string mancc = sanpham.NCC;
            //string madm = sanpham.DM;

            // Kiểm tra nếu giá bán nhập vào hợp lệ
            if (!decimal.TryParse(txtgiamoi.Text, out giaban))
            {
                MessageBox.Show("Vui lòng nhập giá bán hợp lệ!");
                return;
            }

            // Gọi phương thức UpdateProduct để sửa sản phẩm
            bool result = productService.UpdateProduct(masp, selectedMancc, selectedMadm, tensp, giaban);

            // Hiển thị thông báo kết quả
            if (result)
            {
                MessageBox.Show("Sửa sản phẩm thành công!");
                ClearInputFields();  // Làm sạch các ô nhập liệu sau khi sửa
                LoadData();  // Tải lại dữ liệu vào DataGridView sau khi sửa
            }
            else
            {

                MessageBox.Show("MASP: " + masp + "\ntenNCC: " + selectedMancc + "\ntenDM: " + selectedMadm + "\nTENSP: " + tensp + "\nGIABAN: " + giaban);

                MessageBox.Show("Sửa sản phẩm thất bại!");
            }
        }

        private void LoadData()
        {
            // Gọi phương thức GetAll để lấy danh sách sản phẩm và đổ vào DataGridView
            datagwdanhsachsanpham.DataSource = productService.GetAll();


            datagwdanhsachlichsugia.DataSource = productService.GetAllLichSu();

        }
        private void ClearInputFields()
        {
            txtma.Clear();
            txtten.Clear();
            txtgiacu.Clear();
            //cbbNhaCungCap.SelectedIndex = -1; // Reset ComboBox về trạng thái ban đầu
            //cbbDanhMuc.SelectedIndex = -1;
            txtgiamoi.Clear();
        }

        private void txtgiamoi_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu chuỗi nhập vào không phải là số hoặc dài quá 18 ký tự
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtgiamoi.Text, @"^\d{0,18}$"))
            {
                // Lưu lại vị trí con trỏ chuột
                int cursorPosition = txtgiamoi.SelectionStart - 1;

                // Loại bỏ ký tự không hợp lệ vừa nhập vào
                txtgiamoi.Text = txtgiamoi.Text.Remove(txtgiamoi.Text.Length - 1);

                // Đặt lại vị trí con trỏ chuột
                txtgiamoi.SelectionStart = cursorPosition > 0 ? cursorPosition : 0;
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

        private void txtsearchspls_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtsearchspls.Text.Trim(); // Lấy từ khóa tìm kiếm

            if (string.IsNullOrEmpty(keyword))
            {
                LoadData(); // Tải lại dữ liệu nếu không có từ khóa tìm kiếm
            }
            else
            {
                datagwdanhsachlichsugia.DataSource = productService.SearchLichSu(keyword);
            }
        }

        private void txtsearchsp_Enter(object sender, EventArgs e)
        {
            if (txtsearchsp.Text == "Tìm kiếm theo mã, theo tên,...")
            {
                txtsearchsp.Text = string.Empty;
                txtsearchsp.ForeColor = Color.Black;
            }
        }

        private void txtsearchsp_Leave(object sender, EventArgs e)
        {
            if (txtsearchsp.Text == string.Empty)
            {
                txtsearchsp.Text = "Tìm kiếm theo mã, theo tên,...";
                txtsearchsp.ForeColor = Color.Silver;
            }
            LoadData();
        }

        private void txtsearchspls_Leave(object sender, EventArgs e)
        {
            if (txtsearchspls.Text == string.Empty)
            {
                txtsearchspls.Text = "Tìm kiếm theo mã, theo tên,...";
                txtsearchspls.ForeColor = Color.Silver;
            }
            LoadData();
        }

        private void txtsearchspls_Enter(object sender, EventArgs e)
        {
            if (txtsearchspls.Text == "Tìm kiếm theo mã, theo tên,...")
            {
                txtsearchspls.Text = string.Empty;
                txtsearchspls.ForeColor = Color.Black;
            }
        }
    }
}
