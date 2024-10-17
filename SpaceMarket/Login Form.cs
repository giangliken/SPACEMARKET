
using BLL;
using System;
using System.Windows.Forms;

namespace SpaceMarket
{
    public partial class Login : Form
    {
        private readonly LoginService loginService = new LoginService();
        public Login()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text.Trim();
            string pass = txtpass.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Tên đăng nhập không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtusername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Mật khẩu không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtpass.Focus();
                return;
            }

            // Gọi phương thức từ LoginService để kiểm tra đăng nhập
            NhanVien cv = loginService.KiemTraDangNhap(username, pass);
            if (cv != null)
            {
                Main main = new Main();
                main.SetUserRole(cv.ChucVu);
                main.MANV = cv.Id;
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
          
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát màn hình đăng nhập!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
