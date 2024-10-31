using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceMarket
{
    public partial class DanhMucSanPham : Form
    {
        private readonly DanhMucService danhMucService = new DanhMucService();
        public DanhMucSanPham()
        {
            InitializeComponent();
        }

        private void DanhMucSanPham_Load(object sender, EventArgs e)
        {
            //
            txtMaDanhMuc.Text = danhMucService.GenerateNewCategoryCode();
            // Thiết lập AutoGenerateColumns thành false
            datagwdanhsachdanhmuc.AutoGenerateColumns = false;
            datagwdanhsachdanhmuc.DataSource = danhMucService.GetAll();

            datagwdanhsachdanhmuc.Columns[0].DataPropertyName = "MADM";
            datagwdanhsachdanhmuc.Columns[1].DataPropertyName = "TENDM";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenDanhMuc = txtTenDanhMuc.Text; // Lấy tên từ textbox
            if (tenDanhMuc == "")
            {
                MessageBox.Show("Tên danh mục không được để trống","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string result = danhMucService.AddCategory(tenDanhMuc);

                MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReloadData();
                // Làm trống các ô nhập
                txtTenDanhMuc.Clear();

                // Tạo mã danh mục mới và gán cho txtMaDanhMuc
                txtMaDanhMuc.Text = danhMucService.GenerateNewCategoryCode();

            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void uiLabel4_Click(object sender, EventArgs e)
        {

        }

        private void ReloadData()
        {
            datagwdanhsachdanhmuc.DataSource = danhMucService.GetAll();
        }

        private void datagwdanhsachdanhmuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (e.RowIndex >= 0) // e.RowIndex = -1 nếu không có hàng nào được chọn
            {
                // Lấy chỉ số hàng đã chọn
                int rowIndex = e.RowIndex;

                // Lấy dữ liệu từ ô trong hàng đã chọn
                string maDanhMuc = datagwdanhsachdanhmuc.Rows[rowIndex].Cells["madanhmuc"].Value.ToString();
                string tenDanhMuc = datagwdanhsachdanhmuc.Rows[rowIndex].Cells["tendanhmuc"].Value.ToString();

                // Gán giá trị vào các ô nhập
                txtMaDanhMuc.Text = maDanhMuc;
                txtTenDanhMuc.Text = tenDanhMuc;
            }
        }

        private void DanhMucSanPham_MouseClick(object sender, MouseEventArgs e)
        {
            ReloadData();
            // Làm trống các ô nhập
            txtTenDanhMuc.Clear();

            // Tạo mã danh mục mới và gán cho txtMaDanhMuc
            txtMaDanhMuc.Text = danhMucService.GenerateNewCategoryCode();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maDanhMuc = txtMaDanhMuc.Text; // Lấy mã danh mục từ textbox
            string tenDanhMuc = txtTenDanhMuc.Text; // Lấy tên danh mục từ textbox

            if (string.IsNullOrEmpty(maDanhMuc) || string.IsNullOrEmpty(tenDanhMuc))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string result = danhMucService.UpdateCategory(maDanhMuc, tenDanhMuc);
            MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ReloadData(); // Làm mới danh sách sau khi sửa
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maDanhMuc = txtMaDanhMuc.Text; // Lấy mã danh mục từ textbox

            if (string.IsNullOrEmpty(maDanhMuc))
            {
                MessageBox.Show("Vui lòng nhập mã danh mục cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string result = danhMucService.DeleteCategory(maDanhMuc);
            MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ReloadData(); // Làm mới danh sách sau khi xóa
        }

        private void TimKiem()
        {
            string tenDanhMuc = txtsearchdanhmuc.Text.Trim(); // Lấy tên danh mục từ textbox

            if (string.IsNullOrEmpty(tenDanhMuc))
            {
                // Nếu ô tìm kiếm rỗng, hiển thị lại toàn bộ danh sách
                ReloadData(); // Gọi hàm ReloadData để lấy lại tất cả danh mục
                MessageBox.Show("Đã hiển thị lại tất cả danh mục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Nếu có nhập tên, thực hiện tìm kiếm
                var result = danhMucService.SearchByName(tenDanhMuc);

                if (result.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy danh mục nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    datagwdanhsachdanhmuc.DataSource = result; // Cập nhật DataGridView với danh sách tìm thấy
                    MessageBox.Show("Tìm kiếm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnsearchdanhmuc_Click(object sender, EventArgs e)
        {
            string tenDanhMuc = txtsearchdanhmuc.Text.Trim(); // Lấy tên danh mục từ textbox

            if (string.IsNullOrEmpty(tenDanhMuc))
            {
                // Nếu ô tìm kiếm rỗng, hiển thị lại toàn bộ danh sách
                ReloadData(); // Gọi hàm ReloadData để lấy lại tất cả danh mục
                MessageBox.Show("Đã hiển thị lại tất cả danh mục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Nếu có nhập tên, thực hiện tìm kiếm
                var result = danhMucService.SearchByName(tenDanhMuc);

                if (result.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy danh mục nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    datagwdanhsachdanhmuc.DataSource = result; // Cập nhật DataGridView với danh sách tìm thấy
                    MessageBox.Show("Tìm kiếm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtTenDanhMuc_TextChanged(object sender, EventArgs e)
        {
            // Lấy giá trị hiện tại trong txtTenDanhMuc
            string input = txtTenDanhMuc.Text;

            // Biểu thức chính quy để chỉ cho phép chữ cái (có dấu), khoảng trắng và không cho phép số hoặc ký tự đặc biệt
            string pattern = @"^[\p{L}\s]*$"; // \p{L} cho phép tất cả các ký tự chữ cái

            // Kiểm tra xem giá trị có phù hợp với biểu thức chính quy không
            if (!System.Text.RegularExpressions.Regex.IsMatch(input, pattern))
            {
                MessageBox.Show("Tên danh mục chỉ được phép chứa chữ cái và khoảng trắng.");
                // Chỉ giữ lại các ký tự hợp lệ
                txtTenDanhMuc.Text = new string(input.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());
                txtTenDanhMuc.SelectionStart = txtTenDanhMuc.Text.Length; // Đặt con trỏ về cuối ô nhập
            }

            // Giới hạn độ dài tối đa là 20 ký tự
            if (txtTenDanhMuc.Text.Length > 20)
            {
                MessageBox.Show("Tên danh mục tối đa chỉ được 20 ký tự.");
                // Cắt chuỗi về 20 ký tự
                txtTenDanhMuc.Text = txtTenDanhMuc.Text.Substring(0, 20);
                txtTenDanhMuc.SelectionStart = txtTenDanhMuc.Text.Length; // Đặt con trỏ về cuối ô nhập
            }
        }

        private void txtsearchdanhmuc_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
