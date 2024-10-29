using BLL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceMarket
{
    public partial class Main : Form
    {
        public string MANV {  get; set; }  
        public Main()
        {
            InitializeComponent();
        }


        
        private void HệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //BanHang bh = new BanHang();
            //bh.MANV = MANV;
            //bh.ShowDialog();
            ////this.Hide();
            ///
            // Ẩn Form hiện tại trước khi mở Form Bán Hàng
            this.Hide();

            // Tạo và hiển thị Form Bán Hàng
            BanHang bh = new BanHang();
            bh.MANV = MANV;

            // Đăng ký sự kiện FormClosed
            bh.FormClosed += (s, args) => this.Show(); // Khi Form Bán Hàng bị đóng, mở lại Form hiện tại

            bh.Show(); // Sử dụng Show thay vì ShowDialog
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLySanPham ql = new QuanLySanPham();
            ql.ShowDialog();
        }

        private void quảnLíToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tiệnÍchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bảoMậtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void SetUserRole(string chucVu)
        {
            if (chucVu == "Nhân Viên")
            {
                //HệThốngToolStripMenuItem.Visible = false;
                quảnLíToolStripMenuItem.Visible = false;
                //bánHàngToolStripMenuItem.Visible = false;
                sảnPhẩmToolStripMenuItem.Visible = false;
                bảoMậtToolStripMenuItem.Visible = false;
                kháchHàngToolStripMenuItem.Visible = false;
                báoCáoToolStripMenuItem.Visible = false;
                hỗTrợToolStripMenuItem.Visible = false;


            }
        }

        private void Main_Load(object sender, EventArgs e)
        {

            Progress_Form progress = new Progress_Form();
            progress.StartPosition = FormStartPosition.Manual;
            progress.BackColor = this.BackColor;
            progress.Location = new Point(this.Location.X + (this.Width - progress.Width) / 2, this.Location.Y + (this.Height - progress.Height) / 2);
            progress.ShowDialog();
        }


        //Nhận tham số mã NV truyền từ các hàm khác
        public string GetMaNV(string ID)
        {
            MessageBox.Show("Form main da nhan voi ma NV la: " + ID);
            return ID;
        }

        private void fToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn đăng xuất ?","Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if(dr == DialogResult.OK)
            {
                Login login = new Login();
                login.Show();
                this.Hide();
            }
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Account_Management ac = new Account_Management();
            ac.ShowDialog();
            //this.Hide();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Staff_Management staff_Management = new Staff_Management();
            staff_Management.ShowDialog();
        }

        private void quảnLíKháchHàndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer_Management customer_Management = new Customer_Management();
            customer_Management.ShowDialog();
        }

        private void càiĐặtHệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void danhMụcSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhMucSanPham danhMucSanPham = new DanhMucSanPham();
            danhMucSanPham.ShowDialog();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KhoHang khoHang = new KhoHang();
            khoHang.ShowDialog();
        }

        private void sảnPhẩmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            QuanLySanPham ql = new QuanLySanPham();
            ql.ShowDialog();
        }

        public string TENNV { get; set; }
        public string CHUCVU { get; set; }
        public DateTime? NGAYSINH { get; set; }
        private void báoCáoDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InDoanhThu formInDoanhThu = new InDoanhThu();
            var username = StaffService.Instance.GetCurrentUsername(MANV); // lấy thông tin username từ bảng NHANVIEN
            var staff = StaffService.Instance.GetStaffByUsername(username); // sử dụng username của nhân viên đang truy cập
            if (staff != null)
            {
                formInDoanhThu.TENNV = staff.TENNV;
                formInDoanhThu.CHUCVU = staff.CV;
                formInDoanhThu.NGAYSINH = staff.NGAYSINH;
            }
            formInDoanhThu.ShowDialog();


        }

        private void hỗTrợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void quảnLýGiaoHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GiaoHang giaoHang = new GiaoHang();
            giaoHang.ShowDialog();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var username = StaffService.Instance.GetCurrentUsername(MANV);

            if (!string.IsNullOrEmpty(username))
            {
                // Tạo một instance của DoiMatKhau và truyền username vào
                DoiMatKhau doiMatKhauForm = new DoiMatKhau(username);

                // Mở form DoiMatKhauForm dưới dạng dialog
                doiMatKhauForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Không thể lấy thông tin username cho nhân viên này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void traCứuThôngTinKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TraCuuKhachHang traCuuKhachHang = new TraCuuKhachHang();
            traCuuKhachHang.ShowDialog();   
        }
    }
}
