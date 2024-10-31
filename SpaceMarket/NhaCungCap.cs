using BLL;
using SpaceMarket.Bao_cao;
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
    public partial class NhaCungCap : Form
    {
        NhaCungCapService nhaCungCapService = new NhaCungCapService();
        public NhaCungCap()
        {
            InitializeComponent();
        }

        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            txtMaNCC.Text = nhaCungCapService.GenerateNewMANCC();
            LoadData();
        }

        //Phương thức Load
        public void LoadData()
        {
            dgvDanhSachNCC.DataSource = nhaCungCapService.GetAll();
        }

        private void txtTenNCC_TextChanged(object sender, EventArgs e)
        {
            // Lấy giá trị hiện tại trong txtTenNCC
            string input = txtTenNCC.Text;

            // Biểu thức chính quy để chỉ cho phép chữ cái (A-Z, a-z) và khoảng trắng
            string pattern = @"^[a-zA-Z\s]*$";

            // Kiểm tra xem giá trị có phù hợp với biểu thức chính quy không
            if (!System.Text.RegularExpressions.Regex.IsMatch(input, pattern))
            {
                // Nếu không, xóa ký tự không hợp lệ
                MessageBox.Show("Tên nhà cung cấp chỉ được phép chứa chữ cái và khoảng trắng.");
                // Chỉ giữ lại các ký tự hợp lệ
                txtTenNCC.Text = new string(input.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());
                txtTenNCC.SelectionStart = txtTenNCC.Text.Length; // Đặt con trỏ về cuối ô nhập
            }
        }


        private void txtDiaChiNCC_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSDTNCC_TextChanged(object sender, EventArgs e)
        {
            // Lấy giá trị hiện tại trong txtSDTNCC
            string input = txtSDTNCC.Text;

            // Kiểm tra xem có ký tự không phải là chữ số không
            if (!string.IsNullOrEmpty(input) && !input.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại chỉ được phép chứa chữ số.");
                // Xóa ký tự không hợp lệ
                txtSDTNCC.Text = new string(input.Where(char.IsDigit).ToArray());
                txtSDTNCC.SelectionStart = txtSDTNCC.Text.Length; // Đặt con trỏ về cuối ô nhập
            }

            // Đảm bảo độ dài không vượt quá 11
            if (txtSDTNCC.Text.Length > 11)
            {
                MessageBox.Show("Số điện thoại tối đa là 11 chữ số.");
                // Cắt chuỗi về 11 ký tự
                txtSDTNCC.Text = txtSDTNCC.Text.Substring(0, 11);
                txtSDTNCC.SelectionStart = txtSDTNCC.Text.Length; // Đặt con trỏ về cuối ô nhập
            }
        }


        private void txtEmailNCC_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng NCC với thông tin từ các ô nhập liệu
            NCC ncc = new NCC
            {
                MANCC = txtMaNCC.Text,  // MANCC được lấy từ Form
                TENNCC = txtTenNCC.Text,
                DIACHINCC = txtDiaChiNCC.Text,
                SDTNCC = txtSDTNCC.Text,
                EMAILNCC = txtEmailNCC.Text
            };

            // Gọi phương thức thêm từ lớp BLL và kiểm tra kết quả
            if (nhaCungCapService.Add(ncc))
            {
                MessageBox.Show("Thêm nhà cung cấp thành công!");
                LoadData(); // Làm mới dữ liệu trước khi tạo mã mới

                ClearTXT(); // Xóa các ô nhập liệu sau khi thêm
                // Tạo mã mới cho ô txtMaNCC
                txtMaNCC.Text = nhaCungCapService.GenerateNewMANCC();

               
            }
            else
            {
                MessageBox.Show("Thêm nhà cung cấp thất bại!");
            }
        }




        private void btnSua_Click(object sender, EventArgs e)
        {
            // Lấy mã nhà cung cấp từ ô nhập liệu
            string mancc = txtMaNCC.Text;

            // Tạo đối tượng NCC với thông tin mới
            NCC ncc = new NCC
            {
                MANCC = mancc,
                TENNCC = txtTenNCC.Text,
                DIACHINCC = txtDiaChiNCC.Text,
                SDTNCC = txtSDTNCC.Text,
                EMAILNCC = txtEmailNCC.Text
            };

            // Gọi phương thức cập nhật từ lớp BLL và kiểm tra kết quả
            if (nhaCungCapService.Update(ncc))
            {
                MessageBox.Show("Cập nhật thông tin nhà cung cấp thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin nhà cung cấp thất bại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Lấy mã nhà cung cấp từ ô nhập liệu
            string mancc = txtMaNCC.Text;

            // Gọi phương thức xóa từ lớp BLL và kiểm tra kết quả
            if (nhaCungCapService.Delete(mancc))
            {
                MessageBox.Show("Xóa nhà cung cấp thành công!");
                ClearTXT(); // Xóa các ô nhập liệu sau khi thêm
                // Tạo mã mới cho ô txtMaNCC
                txtMaNCC.Text = nhaCungCapService.GenerateNewMANCC();
            }
            else
            {
                MessageBox.Show("Xóa nhà cung cấp thất bại!");
            }
        }

        private void txtMaNCC_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvDanhSachNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có phải là hàng hợp lệ không
            if (e.RowIndex >= 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow row = dgvDanhSachNCC.Rows[e.RowIndex];

                // Gán giá trị của các cột vào các TextBox tương ứng
                txtMaNCC.Text = row.Cells["MANCC"].Value.ToString();
                txtTenNCC.Text = row.Cells["TENNCC"].Value.ToString();
                txtDiaChiNCC.Text = row.Cells["DIACHINCC"].Value.ToString();
                txtSDTNCC.Text = row.Cells["SDTNCC"].Value.ToString();
                txtEmailNCC.Text = row.Cells["EMAILNCC"].Value.ToString();
            }
        }


        private void ClearTXT()
        {
            // Xóa các ô nhập liệu khác (nếu cần)
            txtMaNCC.Clear();
            txtTenNCC.Clear();
            txtDiaChiNCC.Clear();
            txtSDTNCC.Clear();
            txtEmailNCC.Clear();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            // Gọi phương thức tìm kiếm từ lớp BLL
            var results = nhaCungCapService.Search(keyword);

            // Cập nhật DataGridView với kết quả tìm kiếm
            dgvDanhSachNCC.DataSource = results;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            InNhaCungCap inNhaCungCap = new InNhaCungCap(); 
            inNhaCungCap.ShowDialog();
        }

        private void NhaCungCap_MouseClick(object sender, MouseEventArgs e)
        {
            ClearTXT();
            txtMaNCC.Text = nhaCungCapService.GenerateNewMANCC();
        }
    }
}
