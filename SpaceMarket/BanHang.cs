using System;
using System.Windows.Forms;

namespace SpaceMarket
{
    public partial class BanHang : Form
    {
        public BanHang()
        {
            InitializeComponent();
        }


        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void txtTime_TextChanged(object sender, EventArgs e)
        {
           // this.txtTime.Text = string.Format(DateTime.Now.ToString("HH:mm:ss"));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
             this.txtTime.Text = string.Format(DateTime.Now.ToString("HH:mm:ss"));
            CheckCaLamViec();
            this.txtDate.Text = string.Format(DateTime.Now.ToString("dd/MM/yyyy"));
            this.txtSoHoaDon.Text = GenerateSoHoaDon();
            this.txtNhanVien.Text = "Trường Giang";
        }

        private void CheckCaLamViec()
        {
            // Lấy thời gian hiện tại
            DateTime currentTime = DateTime.Now;
            
            // Xác định ca làm việc dựa trên thời gian hiện tại
            string ca;
            if (currentTime.Hour >= 7 && currentTime.Hour < 12)
            {
                ca = "1"; // Từ 07:00 đến 12:00
            }
            else if (currentTime.Hour == 12 && currentTime.Minute >= 1 || (currentTime.Hour < 17))
            {
                ca = "2"; // Từ 12:01 đến 17:00
            }
            else if (currentTime.Hour >= 17 && currentTime.Hour < 23)
            {
                ca = "3"; // Từ 17:01 đến 23:00
            }
            else
            {
                ca = "Ngoài giờ làm"; // Nếu không thuộc bất kỳ ca nào
            }

            
            // Cập nhật giá trị vào TextBox
            txtCa.Text = ca;

            // Đưa con trỏ về cuối TextBox để người dùng không bị mất vị trí
            //txtCa.SelectionStart = txtCa.Text.Length;
            //txtCa.Text = ca;
        }


        private void txtCa_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtONhapMaVach_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu số ký tự trong txtONhapMaVach là 13
            if (txtONhapMaVach.Text.Length == 13)
            {
                // Gọi phương thức để thêm vào DataGridView
                ThemSanPhamVaoDataGrid(txtONhapMaVach.Text);

                // Xóa nội dung của TextBox sau khi thêm
                txtONhapMaVach.Clear();
            }
        }

        private void ThemSanPhamVaoDataGrid(string maVach)
        {
            dataDanhSachSanPham.Rows.Add(maVach);
        }

        private void dataDanhSachSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSoHoaDon_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem dataDanhSachSanPham có dòng nào không
            if (dataDanhSachSanPham.Rows.Count == 0)
            {
                // Nếu bảng trống, thông báo rằng chưa tạo số hóa đơn
                MessageBox.Show("Chưa tạo số hóa đơn. Vui lòng thêm sản phẩm trước.");
                txtSoHoaDon.Clear(); // Xóa số hóa đơn nếu chưa có sản phẩm
            }
            else if (dataDanhSachSanPham.Rows.Count == 1)
            {
                // Nếu chỉ có 1 dòng, tạo số hóa đơn
                string soHoaDon = GenerateSoHoaDon(); // Gọi phương thức để tạo số hóa đơn
                txtSoHoaDon.Text = soHoaDon; // Gán số hóa đơn vào TextBox

                // Xóa dữ liệu trong bảng sản phẩm
                dataDanhSachSanPham.Rows.Clear();
            }
            // Bạn có thể thêm điều kiện xử lý cho trường hợp nhiều hơn 1 dòng nếu cần
        }

        // Phương thức để tạo số hóa đơn (có thể tùy chỉnh theo logic của bạn)
        private string GenerateSoHoaDon()
        {
            // Tạo số hóa đơn theo cách mà bạn muốn
            // Ví dụ: số hóa đơn là một chuỗi ngẫu nhiên hoặc số tự tăng
            return DateTime.Now.ToString("yyyyMMddHHmmss"); // Ví dụ tạo số hóa đơn theo định dạng ngày giờ
        }

        private void txtNhanVien_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
