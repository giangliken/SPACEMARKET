using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceMarket
{
    public partial class TraCuuKhachHang : Form
    {
        private readonly KhachHangService khachHangService = new KhachHangService();
        public TraCuuKhachHang()
        {
            InitializeComponent();
        }

        private void TraCuuKhachHang_Load(object sender, EventArgs e)
        {


        }



        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtMaKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Kiểm tra nếu phím nhấn là Enter
            {
                // Gọi phương thức tìm kiếm
                TimKiemKhachHang();
            }
            if (e.KeyCode == Keys.F4)
            {
                this.Close();
            }
        }
        private void TimKiemKhachHang()
        {
            string input = txtMaKH.Text.Trim();

            // Kiểm tra nếu không có ký tự nào được nhập vào
            if (string.IsNullOrEmpty(input) || input == "Nhập mã khách hàng, hoặc SDT")
            {
                // Nếu không có dữ liệu nhập, làm rỗng các Label và không tìm kiếm
                lblTenChuThe.Text = string.Empty;
                lblHangThe.Text = string.Empty;
                lblDiemTichLuy.Text = string.Empty;
                return; // Kết thúc hàm sớm
            }

            // Xác định loại thông tin: mã thẻ, mã khách hàng hoặc số điện thoại
            string mathe = null;
            string makh = null;
            string sdt = null;

            // Kiểm tra mã thẻ
            if (input.All(char.IsDigit) && input.Length == 12)
            {
                mathe = input; // Mã thẻ 12 số
            }
            // Kiểm tra số điện thoại
            else if (input.All(char.IsDigit) && input.Length == 10)
            {
                sdt = input;
            }
            // Kiểm tra mã khách hàng
            else if (input.StartsWith("KH") && input.Length == 12)
            {
                makh = input;
            }
            else
            {
                // Nếu không đúng định dạng, hiển thị thông báo lỗi
                MessageBox.Show("Mã thẻ phải có 12 chữ số, số điện thoại phải có 10 chữ số, hoặc mã khách hàng phải bắt đầu bằng 'KH' và có 12 ký tự.", "Lỗi Định Dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus(); // Đặt con trỏ vào ô nhập liệu
                txtMaKH.SelectAll(); // Chọn tất cả văn bản trong ô nhập liệu
                return; // Kết thúc hàm sớm
            }

            // Gọi phương thức tìm kiếm với các tham số phù hợp
            List<THETHANHVIENS> ketqua = khachHangService.TimKiemTheThanhVien(mathe, makh, sdt);

            // Hiển thị kết quả vào Label
            if (ketqua != null && ketqua.Count > 0) // Kiểm tra xem có kết quả nào không
            {
                var firstResult = ketqua.First(); // Lấy kết quả đầu tiên
                lblTenChuThe.Text = firstResult.TENKH;
                lblHangThe.Text = firstResult.HANGTHE;
                lblDiemTichLuy.Text = firstResult.DIEMTICHLUY;
            }
            else
            {
                // Nếu không có kết quả, làm rỗng các Label
                lblTenChuThe.Text = string.Empty;
                lblHangThe.Text = string.Empty;
                lblDiemTichLuy.Text = string.Empty;
            }
        }



        private void lblHangThe_Click(object sender, EventArgs e)
        {

        }

        private void lblDiemTichLuy_Click(object sender, EventArgs e)
        {

        }

        private void lblTenChuThe_Click(object sender, EventArgs e)
        {

        }

        private void txtMaKH_Enter(object sender, EventArgs e)
        {
            if (txtMaKH.Text == "Nhập mã khách hàng, hoặc SDT")
            {
                txtMaKH.Text = string.Empty;
                txtMaKH.ForeColor = Color.Red;
            }
        }

        private void txtMaKH_Leave(object sender, EventArgs e)
        {
            if (txtMaKH.Text == string.Empty)
            {
                txtMaKH.Text = "Nhập mã khách hàng, hoặc SDT";
                txtMaKH.ForeColor = Color.Silver;
            }
        }

        private void uiLabel3_Click(object sender, EventArgs e)
        {

        }

        private void TraCuuKhachHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4) 
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }
    }
}
