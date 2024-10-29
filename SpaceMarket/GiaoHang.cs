using BLL;
using DAL.Database;
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
    public partial class GiaoHang : Form
    {
        private readonly GiaoHangService giaoHangService = new GiaoHangService();
        private Model1 context = new Model1();
        public string MaDonHang { get; set; }
        public GiaoHang()
        {
            InitializeComponent();
        }

        private void GiaoHang_Load(object sender, EventArgs e)
        {
            // Định dạng DateTimePicker
            dateTimePicker1.Format = DateTimePickerFormat.Custom; // dateTimePicker1 là tên của DateTimePicker
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            LoadData();

            // Tìm hóa đơn trong database
            var hoaDon = context.HOADON.FirstOrDefault(hd => hd.MAHD == MaDonHang);

            if (hoaDon != null)
            {
                // Kiểm tra xem hóa đơn có còn hạn không (tối đa 10 ngày kể từ ngày lập hóa đơn)
                if (hoaDon.NGAYLAP.HasValue && (DateTime.Now - hoaDon.NGAYLAP.Value).TotalDays <= 10)
                {
                    // Gọi hàm tạo mã phiếu giao hàng
                    string maPGH = giaoHangService.GenerateMaPGH(hoaDon.MAHD); // Giả định bạn đã có phương thức này trong service

                    // Cập nhật txtMaPhieu với mã PGH
                    txtMaPhieu.Text = maPGH;

                    // Tùy chọn: Đặt con trỏ ở cuối textbox
                    txtMaPhieu.SelectionStart = txtMaPhieu.Text.Length;
                    txtMaPhieu.SelectionLength = 0;

                    MessageBox.Show($"Mã phiếu giao hàng được tạo: {maPGH}");
                }
                else
                {
                    MessageBox.Show("Hóa đơn đã hết hạn hoặc không có ngày lập hóa đơn.");
                }
            }
            else
            {
                //MessageBox.Show("Mã hóa đơn không tồn tại trong hệ thống.");
            }

        }

        //Hàm load
        private void LoadData()
        {
            dgvDanhSachPhieuGiaoHang.AutoGenerateColumns = false;
            dgvDanhSachPhieuGiaoHang.DataSource = giaoHangService.GetAll();
            //MaDonHang = "2024100033";
            // Định dạng cột ngày giao
            dgvDanhSachPhieuGiaoHang.Columns["NGAYDUKIENGH"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }


        private void btnHuyPhieu_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có mã phiếu giao hàng nào được chọn không
            if (string.IsNullOrWhiteSpace(txtMaPhieu.Text))
            {
                MessageBox.Show("Vui lòng chọn phiếu giao hàng cần hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận việc hủy phiếu giao hàng
            var result = MessageBox.Show("Bạn có chắc chắn muốn hủy phiếu giao hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Gọi phương thức hủy phiếu giao hàng
                bool isDeleted = giaoHangService.XoaPhieuGiaoHang(txtMaPhieu.Text);

                // Thông báo kết quả
                if (isDeleted)
                {
                    MessageBox.Show("Hủy phiếu giao hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Tải lại dữ liệu sau khi hủy phiếu
                }
                else
                {
                    MessageBox.Show("Hủy phiếu giao hàng thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem các trường cần thiết đã được điền chưa
            if (string.IsNullOrWhiteSpace(txtMaPhieu.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChiGiao.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) ||
                string.IsNullOrWhiteSpace(txtMoTa.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm phiếu giao hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã phiếu giao hàng từ textbox
            string maPhieuGiaoHang = txtMaPhieu.Text;

            // Kiểm tra xem phiếu giao hàng đã tồn tại trong database chưa
            var existingPhieuGiaoHang = giaoHangService.GetPhieuGiaoHangByMa(maPhieuGiaoHang);
            if (existingPhieuGiaoHang != null)
            {
                // Nếu đã tồn tại, xóa phiếu giao hàng cũ mà không cần xác nhận
                bool isDeleted = giaoHangService.XoaPhieuGiaoHang(maPhieuGiaoHang);
                if (!isDeleted)
                {
                    MessageBox.Show("Không thể xóa phiếu giao hàng cũ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Tạo đối tượng PHIEUGIAOHANG
            var phieuGiaoHang = new PHIEUGIAOHANG
            {
                MAPGH = maPhieuGiaoHang,
                MAHD = maPhieuGiaoHang.Substring(3),
                NGAYDUKIENGH = dateTimePicker1.Value,
                DIACHIGIAOHANG = txtDiaChiGiao.Text,
                SDTNGUOINHANHANG = txtSDT.Text,
                MOTA = txtMoTa.Text
            };

            // Gọi phương thức thêm phiếu giao hàng
            bool isAdded = giaoHangService.ThemPhieuGiaoHang(phieuGiaoHang);

            // Thông báo kết quả
            if (isAdded)
            {
                // Khởi tạo form InPhieuGiaoHang và truyền mã phiếu giao hàng
                InPhieuGiaoHang inPhieuForm = new InPhieuGiaoHang(maPhieuGiaoHang);
                inPhieuForm.ShowDialog();
                MessageBox.Show("Thêm phiếu giao hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                LoadData();
            }
            else
            {
                MessageBox.Show("Thêm phiếu giao hàng thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void txtMaPhieu_TextChanged(object sender, EventArgs e)
        {
            string maHD = txtMaPhieu.Text;

            // Kiểm tra độ dài và định dạng của MAHD (10 ký tự số)
            if (maHD.Length == 10 && long.TryParse(maHD, out _))
            {
                using (Model1 context = new Model1())
                {
                    // Tìm hóa đơn trong database
                    var hoaDon = context.HOADON.FirstOrDefault(hd => hd.MAHD == maHD);

                    if (hoaDon != null)
                    {
                        // Kiểm tra xem hóa đơn có còn hạn không (tối đa 10 ngày kể từ ngày lập hóa đơn)
                        if (hoaDon.NGAYLAP.HasValue && (DateTime.Now - hoaDon.NGAYLAP.Value).TotalDays <= 10)
                        {
                            // Gọi hàm tạo mã phiếu giao hàng
                            string maPGH = giaoHangService.GenerateMaPGH(hoaDon.MAHD); // Giả định bạn đã có phương thức này trong service

                            // Cập nhật txtMaPhieu với mã PGH
                            txtMaPhieu.Text = maPGH;

                            // Tùy chọn: Xóa nội dung cũ (nếu cần)
                            txtMaPhieu.SelectionStart = txtMaPhieu.Text.Length; // Đặt con trỏ ở cuối textbox
                            txtMaPhieu.SelectionLength = 0; // Không cần xóa nữa, vì đã gán mới vào

                            MessageBox.Show($"Mã phiếu giao hàng được tạo: {maPGH}");
                        }
                        else
                        {
                            MessageBox.Show("Hóa đơn đã hết hạn hoặc không có ngày lập hóa đơn.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã hóa đơn không tồn tại trong hệ thống.");
                    }
                }
            }
            else
            {
                //MessageBox.Show("Mã hóa đơn phải có 10 ký tự số.");
            }
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtDiaChiGiao_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMoTa_TextChanged(object sender, EventArgs e)
        {

        }

        private void DgvDanhSachPhieuGiaoHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng có nhấp vào một dòng hợp lệ không
            if (e.RowIndex >= 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow row = dgvDanhSachPhieuGiaoHang.Rows[e.RowIndex];

                // Cập nhật các TextBox với dữ liệu từ dòng được chọn
                txtMaPhieu.Text = row.Cells["MAPGH"].Value?.ToString(); // Thay "MAPGH" bằng tên cột thực tế
                //MaDonHang = row.Cells["MAHD"].Value?.ToString(); // Thay "MAHD" bằng tên cột thực tế
                txtDiaChiGiao.Text = row.Cells["DIACHIGIAO"].Value?.ToString(); // Thay "DIACHIGIAOHANG" bằng tên cột thực tế
                txtSDT.Text = row.Cells["SDTNGUOINHANHANG"].Value?.ToString(); // Thay "SDTNGUOINHANHANG" bằng tên cột thực tế
                txtMoTa.Text = row.Cells["MOTA"].Value?.ToString(); // Thay "MOTA" bằng tên cột thực tế

                // Cập nhật ngày dự kiến giao hàng
                if (row.Cells["NGAYDUKIENGH"].Value != null)
                {
                    dateTimePicker1.Value = Convert.ToDateTime(row.Cells["NGAYDUKIENGH"].Value);
                }
            }
        }
    }
}
