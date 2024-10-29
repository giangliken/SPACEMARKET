using BLL;
using DAL.Database;
using SpaceMarket.Bao_cao;
using System;
using System.Drawing;
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

        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, DateTime value)
        {

        }

        private void txtCCCD_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

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
                string maKhachHang = txtMaKH.Text;

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
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            InKhachHang inKhachHang = new InKhachHang();
            inKhachHang.ShowDialog();
        }
    }
}
