
using BLL;
using System;
using System.Drawing;
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

        private void txtusername_Enter(object sender, EventArgs e)
        {
            if (txtusername.Text == "Username")
            {
                txtusername.Text = string.Empty;
                txtusername.ForeColor = Color.Black;
            }
        }

        private void txtusername_Leave(object sender, EventArgs e)
        {
            if(txtusername.Text == string.Empty)
            {
                txtusername.Text = "Username";
                txtusername.ForeColor = Color.Silver;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if(txtpass.Text == "Password")
            {
                txtpass.Text = string.Empty;
                txtpass.ForeColor = Color.Black;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if(txtpass.Text == string.Empty)
            {
                txtpass.Text = "Password";
                txtpass.ForeColor= Color.Silver;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            btnDangNhap_Click(sender, e);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            btnBoQua_Click(sender, e);
        }
    }
}
