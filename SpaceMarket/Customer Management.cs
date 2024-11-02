using BLL;
using DAL.Database;
using SpaceMarket.Bao_cao;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SpaceMarket
{
    public partial class Customer_Management : Form
    {
        private readonly KhachHangService khachHangService = new KhachHangService();
        public Customer_Management()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Customer_Management_Load(object sender, EventArgs e)
        {
            txtMaKH.Text = khachHangService.GenerateCustomerID();
            LoadData();
        }

        private void LoadData()
        {
            datadanhsachkhachhang.DataSource = khachHangService.GetAll();
            // Định dạng cột NGAYSINH
            if (datadanhsachkhachhang.Columns["NGAYSINH"] != null)
            {
                datadanhsachkhachhang.Columns["NGAYSINH"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu độ dài của chuỗi nhập vào lớn hơn 20 ký tự
            if (txtMaKH.Text.Length > 20)
            {
                // Nếu quá 20 ký tự, cắt chuỗi về 20 ký tự
                txtMaKH.Text = txtMaKH.Text.Substring(0, 20);
                // Đưa con trỏ về cuối ô nhập liệu
                txtMaKH.SelectionStart = txtMaKH.Text.Length;
                MessageBox.Show("Mã khách hàng không được quá 20 ký tự!");
            }

        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu độ dài của chuỗi nhập vào lớn hơn 100 ký tự
            if (txtTenKH.Text.Length > 100)
            {
                // Nếu quá 100 ký tự, cắt chuỗi về 100 ký tự
                txtTenKH.Text = txtTenKH.Text.Substring(0, 100);
                // Đưa con trỏ về cuối ô nhập liệu
                txtTenKH.SelectionStart = txtTenKH.Text.Length;
                MessageBox.Show("Tên khách hàng không được quá 100 ký tự!");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, DateTime value)
        {

        }

        private void txtCCCD_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu độ dài của chuỗi nhập vào lớn hơn 12 ký tự
            if (txtCCCD.Text.Length > 12)
            {
                // Nếu quá 12 ký tự, cắt chuỗi về 12 ký tự
                txtCCCD.Text = txtCCCD.Text.Substring(0, 12);
                // Đưa con trỏ về cuối ô nhập liệu
                txtCCCD.SelectionStart = txtCCCD.Text.Length;
                MessageBox.Show("CCCD không được quá 12 ký tự!");
            }
        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu độ dài của chuỗi nhập vào lớn hơn 200 ký tự
            if (txtDiaChi.Text.Length > 200)
            {
                // Nếu quá 200 ký tự, cắt chuỗi về 200 ký tự
                txtDiaChi.Text = txtDiaChi.Text.Substring(0, 200);
                // Đưa con trỏ về cuối ô nhập liệu
                txtDiaChi.SelectionStart = txtDiaChi.Text.Length;
                MessageBox.Show("Địa chỉ không được quá 200 ký tự!");
            }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu độ dài của chuỗi nhập vào lớn hơn 11 ký tự
            if (txtSDT.Text.Length > 11)
            {
                // Nếu quá 11 ký tự, cắt chuỗi về 11 ký tự
                txtSDT.Text = txtSDT.Text.Substring(0, 11);
                // Đưa con trỏ về cuối ô nhập liệu
                txtSDT.SelectionStart = txtSDT.Text.Length;
                MessageBox.Show("Số điện thoại không được quá 11 ký tự!");
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu nhập vào
            if (string.IsNullOrWhiteSpace(txtMaKH.Text) ||
                string.IsNullOrWhiteSpace(txtTenKH.Text) ||
                string.IsNullOrWhiteSpace(txtCCCD.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng thực hiện nếu dữ liệu không hợp lệ
            }

            // Tạo đối tượng KHACHHANGS từ dữ liệu trong ô nhập liệu
            KHACHHANGS newKhachHang = new KHACHHANGS
            {
                MAKH = txtMaKH.Text,
                TENKH = txtTenKH.Text,
                NGAYSINH = dateTimePicker1.Value, // Lấy giá trị từ DateTimePicker
                CCCD = txtCCCD.Text,
                DIACHI = txtDiaChi.Text,
                SDTKH = txtSDT.Text,
                EMAILKH = txtEmail.Text
            };

            // Tạo đối tượng KhachHangService để gọi phương thức thêm
            KhachHangService khachHangService = new KhachHangService();
            khachHangService.Add(newKhachHang);

            // Thông báo thêm thành công
            MessageBox.Show("Thêm khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            LoadData();
            Customer_Management_Load(sender, e);
            
        }

        private void ClearFields()
        {
            // Làm mới các ô nhập liệu sau khi thêm
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtCCCD.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            dateTimePicker1.Value = DateTime.Now; // Đặt lại giá trị DateTimePicker
        }

        // Sự kiện CellClick cho DataGridView
        private void datadanhsachkhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu nhấp vào hàng dữ liệu hợp lệ
            if (e.RowIndex >= 0)
            {
                // Lấy dòng đã chọn
                DataGridViewRow selectedRow = datadanhsachkhachhang.Rows[e.RowIndex];

                // Điền dữ liệu vào các ô nhập liệu
                txtMaKH.Text = selectedRow.Cells["MAKH"].Value.ToString();
                txtTenKH.Text = selectedRow.Cells["TENKH"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(selectedRow.Cells["NGAYSINH"].Value);
                txtCCCD.Text = selectedRow.Cells["CCCD"].Value.ToString();
                txtDiaChi.Text = selectedRow.Cells["DIACHI"].Value.ToString();
                txtSDT.Text = selectedRow.Cells["SDTKH"].Value.ToString();
                txtEmail.Text = selectedRow.Cells["EMAILKH"].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu nhập vào
            if (string.IsNullOrWhiteSpace(txtMaKH.Text) ||
                string.IsNullOrWhiteSpace(txtTenKH.Text) ||
                string.IsNullOrWhiteSpace(txtCCCD.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng thực hiện nếu dữ liệu không hợp lệ
            }

            // Tạo đối tượng KHACHHANGS từ dữ liệu trong ô nhập liệu
            KHACHHANGS updatedKhachHang = new KHACHHANGS
            {
                MAKH = txtMaKH.Text,
                TENKH = txtTenKH.Text,
                NGAYSINH = dateTimePicker1.Value,
                CCCD = txtCCCD.Text,
                DIACHI = txtDiaChi.Text,
                SDTKH = txtSDT.Text,
                EMAILKH = txtEmail.Text
            };

            // Gọi phương thức cập nhật trong KhachHangService
            khachHangService.Update(updatedKhachHang);

            // Thông báo sửa thành công
            MessageBox.Show("Sửa thông tin khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            LoadData();
            Customer_Management_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu người dùng đã chọn một hàng trong DataGridView
            if (datadanhsachkhachhang.SelectedRows.Count > 0)
            {
                // Lấy mã khách hàng từ ô nhập liệu
                //string maKhachHang = txtMaKH.Text;
                // Lấy mã khách hàng từ hàng được chọn
                string maKhachHang = datadanhsachkhachhang.SelectedRows[0].Cells["MAKH"].Value.ToString();

                // Gọi phương thức xóa trong KhachHangService
                khachHangService.Delete(maKhachHang);

                // Thông báo xóa thành công
                MessageBox.Show("Xóa khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadData();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ClearFields();
            Customer_Management_Load(sender, e);
           
        }

        private void SearchCustomers()
        {
            string maKhachHang = txtSearchMAKH.Text.Trim();
            string tenKhachHang = txtSearchTenKH.Text.Trim();

            // Tìm kiếm khách hàng dựa trên mã hoặc tên
            var results = khachHangService.SearchCustomers(maKhachHang, tenKhachHang);

            // Cập nhật DataGridView với kết quả tìm kiếm
            datadanhsachkhachhang.DataSource = results;

            // Kiểm tra kết quả tìm kiếm
            if (results == null || results.Count == 0)
            {
                MessageBox.Show("Không tìm thấy khách hàng nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void txtSearchMAKH_Enter(object sender, EventArgs e)
        {
            if (txtSearchMAKH.Text == "Tìm kiếm theo mã")
            {
                txtSearchMAKH.Text = string.Empty;
                txtSearchMAKH.ForeColor = Color.Black;
            }
        }

        private void txtSearchMAKH_Leave(object sender, EventArgs e)
        {
            if (txtSearchMAKH.Text == string.Empty)
            {
                txtSearchMAKH.Text = "Tìm kiếm theo mã";
                txtSearchMAKH.ForeColor = Color.Silver;
            }
            LoadData();
        }

        private void txtSearchTenKH_Enter(object sender, EventArgs e)
        {
            if(txtSearchTenKH.Text == "Tìm kiếm theo tên")
            {
                txtSearchTenKH.Text= string.Empty;
                txtSearchTenKH.ForeColor = Color.Black;

            }
        }

        private void txtSearchTenKH_Leave(object sender, EventArgs e)
        {
            if(txtSearchTenKH.Text== string.Empty)
            {
                txtSearchTenKH.Text = "Tìm kiếm theo tên";
                txtSearchTenKH.ForeColor= Color.Silver;
            }
            LoadData();
        }

        private void txtSearchMAKH_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSearchTenKH_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void SearchByMaKH()
        {
            string maKhachHang = txtSearchMAKH.Text.Trim();

            // Tìm kiếm khách hàng dựa trên mã
            var results = khachHangService.SearchCustomers(maKhachHang, null);

            // Kiểm tra kết quả tìm kiếm
            if (results == null || results.Count == 0)
            {
                MessageBox.Show("Không tìm thấy khách hàng nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Cập nhật DataGridView với kết quả tìm kiếm
                datadanhsachkhachhang.DataSource = results;
            }
        }

        private void SearchByTenKH()
        {
            string tenKhachHang = txtSearchTenKH.Text.Trim();

            // Tìm kiếm khách hàng dựa trên tên
            var results = khachHangService.SearchCustomers(null, tenKhachHang);

            // Kiểm tra kết quả tìm kiếm
            if (results == null || results.Count == 0)
            {
                MessageBox.Show("Không tìm thấy khách hàng nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Cập nhật DataGridView với kết quả tìm kiếm
                datadanhsachkhachhang.DataSource = results;
            }
        }

        private void txtSearchMAKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchByMaKH();
            }
        }

        private void txtSearchTenKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchByTenKH();
            }
        }

        private void Customer_Management_MouseClick(object sender, MouseEventArgs e)
        {
            LoadData();
            ClearFields();
            txtMaKH.Text = khachHangService.GenerateCustomerID();


        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            InKhachHang inKhachHang = new InKhachHang();
            inKhachHang.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            btnThem_Click(sender, e);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            btnXoa_Click(sender, e);
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_Leave(object sender, EventArgs e)
        {
            // Lấy ngày hiện tại
            DateTime today = DateTime.Today;

            // Kiểm tra nếu ngày được chọn lớn hơn ngày hiện tại
            if (dateTimePicker1.Value > today)
            {
                // Nếu lớn hơn, đặt lại giá trị của DateTimePicker về ngày hiện tại
                dateTimePicker1.Value = today;
                MessageBox.Show("Ngày không được lớn hơn ngày hiện tại!");
            }
        }

        private void txtCCCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu ký tự nhập vào không phải là số và không phải phím xóa
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Không cho phép nhập ký tự khác
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu ký tự nhập vào không phải là số và không phải phím xóa
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Không cho phép nhập ký tự khác
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            // Kiểm tra nếu độ dài của chuỗi nhập vào lớn hơn 200 ký tự
            if (txtEmail.Text.Length > 200)
            {
                // Nếu quá 200 ký tự, cắt chuỗi về 200 ký tự
                txtEmail.Text = txtEmail.Text.Substring(0, 200);
                // Đưa con trỏ về cuối ô nhập liệu
                txtEmail.SelectionStart = txtEmail.Text.Length;
                MessageBox.Show("Địa chỉ email không được quá 200 ký tự!");
            }

            // Kiểm tra định dạng email
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Địa chỉ email không hợp lệ!");
            }
        }

        // Phương thức kiểm tra định dạng email
        private bool IsValidEmail(string email)
        {
            // Sử dụng biểu thức chính quy để kiểm tra định dạng email
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }
    }
}
