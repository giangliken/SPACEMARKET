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
    public partial class KhoHang : Form
    {
        private readonly KhoHangService khoHangService = new KhoHangService();
        public KhoHang()
        {
            InitializeComponent();
        }

        private void uiTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void uiTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiButton3_Click(object sender, EventArgs e)
        {

        }

        private void uiButton2_Click(object sender, EventArgs e)
        {

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {

        }

        private void dataDanhSachKhoHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void uiContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void uiTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiLabel5_Click(object sender, EventArgs e)
        {

        }

        private void uiTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiLabel4_Click(object sender, EventArgs e)
        {

        }

        private void uiLabel3_Click(object sender, EventArgs e)
        {

        }

        private void uiLabel2_Click(object sender, EventArgs e)
        {

        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataDanhSachKhoHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem chỉ số hàng có hợp lệ không
            if (e.RowIndex >= 0)
            {
                // Lấy hàng hiện tại
                DataGridViewRow row = dataDanhSachKhoHang.Rows[e.RowIndex];

                // Đổ dữ liệu từ các cột vào các ô txt tương ứng
                txtMakho.Text = row.Cells[0].Value.ToString();
                txtTenKho.Text = row.Cells[1].Value.ToString();
                txtDiaChiKho.Text = row.Cells[2].Value.ToString();
                // Tiếp tục cho các ô txt khác nếu cần
            }
        }

        private void LoadDanhSachKhoHang()
        {
            dataDanhSachKhoHang.DataSource = khoHangService.GetAll();
        }

        //Load dữ liệu trong bảng chi tiết kho hàng bên tab Nhập kho
        private void LoadDanhSachChiTietKhoHang()
        {
            dataDanhSachNhapKho.DataSource = khoHangService.LayDanhSachChiTietKhoHang();
        }

        private void KhoHang_Load(object sender, EventArgs e)
        {
            LoadDanhSachKhoHang();
            txtMakho.Text = khoHangService.GenerateNewMaKho();
            //Tab Nhap kho
            LoadDanhSachChiTietKhoHang();

            cbbKhoCanNhap.DataSource = khoHangService.LayDanhSachKhoHang();
            cbbKhoCanNhap.DisplayMember = "TENKHO";
            cbbKhoCanNhap.ValueMember = "MAKHO";

            cbbHangCanNhap.DataSource = khoHangService.LayDanhSachSanPham();
            cbbHangCanNhap.DisplayMember = "TENSP";
            cbbHangCanNhap.ValueMember = "MASP";


        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra không để trống thông tin
            if (string.IsNullOrEmpty(txtMakho.Text) ||
                string.IsNullOrEmpty(txtTenKho.Text) ||
                string.IsNullOrEmpty(txtDiaChiKho.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            // Tạo đối tượng KHOHANGS để thêm vào database
            KHOHANGS newKhoHang = new KHOHANGS
            {
                MAKHO = txtMakho.Text,
                TENKHO = txtTenKho.Text,
                DIACHIKHO = txtDiaChiKho.Text
            };

            // Gọi hàm thêm kho hàng
            bool result = khoHangService.AddKhoHang(newKhoHang);

            if (result)
            {
                MessageBox.Show("Thêm kho hàng thành công!");
                ClearThongTinKho();
                txtMakho.Text = khoHangService.GenerateNewMaKho();
                LoadDanhSachKhoHang() ;
            }
            else
            {
                MessageBox.Show("Thêm kho hàng thất bại.");
            }
        }

        private void ClearThongTinKho()
        {
            txtMakho.Clear();
            txtTenKho.Clear();
            txtDiaChiKho.Clear();
        }

        private void txtMakho_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenKho_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiaChiKho_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra không để trống thông tin
            if (string.IsNullOrEmpty(txtMakho.Text) ||
                string.IsNullOrEmpty(txtTenKho.Text) ||
                string.IsNullOrEmpty(txtDiaChiKho.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            // Tạo đối tượng KHOHANGS để cập nhật vào database
            KHOHANGS updatedKhoHang = new KHOHANGS
            {
                MAKHO = txtMakho.Text,
                TENKHO = txtTenKho.Text,
                DIACHIKHO = txtDiaChiKho.Text
            };

            // Gọi hàm cập nhật kho hàng
            bool result = khoHangService.UpdateKhoHang(updatedKhoHang);

            if (result)
            {
                MessageBox.Show("Cập nhật kho hàng thành công!");
                ClearThongTinKho();
                //txtMakho.Text = khoHangService.GenerateNewMaKho();
                LoadDanhSachKhoHang();
            }
            else
            {
                MessageBox.Show("Cập nhật kho hàng thất bại.");
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra không để trống mã kho
            if (string.IsNullOrEmpty(txtMakho.Text))
            {
                MessageBox.Show("Vui lòng chọn kho cần xóa.");
                return;
            }

            // Gọi hàm xóa kho hàng
            bool result = khoHangService.DeleteKhoHang(txtMakho.Text);

            if (result)
            {
                MessageBox.Show("Xóa kho hàng thành công!");
                ClearThongTinKho();
                txtMakho.Text = khoHangService.GenerateNewMaKho();
                LoadDanhSachKhoHang();
            }
            else
            {
                MessageBox.Show("Xóa kho hàng thất bại.");
            }
        }

        private void tabPage1_MouseClick(object sender, MouseEventArgs e)
        {
            ClearThongTinKho();
            txtMakho.Text = khoHangService.GenerateNewMaKho();
        }

        private void txtSearchMa_TextChanged(object sender, EventArgs e)
        {
            // Gọi phương thức tìm kiếm dựa trên MAKHO, TENKHO, và DIACHIKHO
            var result = khoHangService.SearchKhoHang(txtSearchMa.Text, txtSearchTen.Text, txtSearchDiaChi.Text);

            // Hiển thị kết quả tìm kiếm trong DataGridView
            dataDanhSachKhoHang.DataSource = result;
        }

        private void txtSearchTen_TextChanged(object sender, EventArgs e)
        {
            // Gọi phương thức tìm kiếm dựa trên MAKHO, TENKHO, và DIACHIKHO
            var result = khoHangService.SearchKhoHang(txtSearchMa.Text, txtSearchTen.Text, txtSearchDiaChi.Text);

            // Hiển thị kết quả tìm kiếm trong DataGridView
            dataDanhSachKhoHang.DataSource = result;
        }

        private void txtSearchDiaChi_TextChanged(object sender, EventArgs e)
        {
            // Gọi phương thức tìm kiếm dựa trên MAKHO, TENKHO, và DIACHIKHO
            var result = khoHangService.SearchKhoHang(txtSearchMa.Text, txtSearchTen.Text, txtSearchDiaChi.Text);

            // Hiển thị kết quả tìm kiếm trong DataGridView
            dataDanhSachKhoHang.DataSource = result;
        }

        private void cbbKhoCanNhap_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbHangCanNhap_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSoLuongNhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            // Kiểm tra không để trống thông tin
            if (cbbKhoCanNhap.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn kho.");
                return;
            }

            if (cbbHangCanNhap.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn hàng.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSoLuongNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập số lượng.");
                return;
            }

            // Lấy thông tin từ các control
            string maKho = cbbKhoCanNhap.SelectedValue?.ToString(); // Giả sử SelectedValue là MAKHO
            string maSP = cbbHangCanNhap.SelectedValue?.ToString(); // Giả sử SelectedValue là MASP
            int soLuong;

            // Kiểm tra nếu soLuong là số hợp lệ
            if (int.TryParse(txtSoLuongNhap.Text, out soLuong) && soLuong > 0)
            {
                // Tạo instance của KhoHangService
                KhoHangService khoHangService = new KhoHangService();

                // Gọi phương thức NhapKho
                bool result = khoHangService.NhapKho(maSP, maKho, soLuong);

                if (result)
                {
                    MessageBox.Show("Nhập kho thành công!");
                    // Có thể gọi lại hàm để làm mới danh sách hoặc cập nhật giao diện
                    LoadDanhSachChiTietKhoHang(); // Giả sử bạn có phương thức này để cập nhật danh sách kho
                    ClearInputFields(); // Gọi phương thức để làm sạch các ô nhập liệu
                }
                else
                {
                    MessageBox.Show("Nhập kho thất bại.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số lượng hợp lệ và lớn hơn 0.");
            }
        }

        private void ClearInputFields()
        {
            // Làm sạch các ô nhập liệu
            txtSoLuongNhap.Clear();
            cbbKhoCanNhap.SelectedIndex = -1; // Đặt lại chỉ số chọn cho ComboBox kho
            cbbHangCanNhap.SelectedIndex = -1; // Đặt lại chỉ số chọn cho ComboBox sản phẩm
        }

        private void dataDanhSachNhapKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng có nhấp vào hàng hợp lệ không
            if (e.RowIndex >= 0) // e.RowIndex là chỉ số hàng được nhấp vào
            {
                // Lấy dữ liệu từ hàng đã chọn
                var selectedRow = dataDanhSachNhapKho.Rows[e.RowIndex];

                // Lấy giá trị MAKHO và MASP từ các cột tương ứng
                string maKho = selectedRow.Cells[0].Value.ToString(); // Giả sử cột 0 là MAKHO
                string maSP = selectedRow.Cells[1].Value.ToString();   // Giả sử cột 1 là MASP
                //int slTon = Convert.ToInt32(selectedRow.Cells[2].Value); // Giả sử cột 2 là SLTON

                // Đưa thông tin vào các ô nhập liệu
                cbbKhoCanNhap.Text = maKho; // Đổ thông tin vào ô cbbKhoCanNhap
                cbbHangCanNhap.Text = maSP;  // Đổ thông tin vào ô cbbHangCanNhap
                //txtSoLuongNhap.Text = slTon.ToString(); // Hiển thị số lượng tồn
            }
        }


    }
}
