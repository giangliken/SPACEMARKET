
using BLL;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Oauth2.v2.Data;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using UserInfo = BLL.UserInfo;

namespace SpaceMarket
{
    public partial class Login : Form
    {
        private readonly LoginService loginService = new LoginService();
        private UserInfo userInfo;
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

        public void LogoutGoogle()
        {
            try
            {
                var credentialPaths = new string[]
                {
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), ".credentials"),
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Google.Apis.Auth")
                };

                foreach (var credPath in credentialPaths)
                {
                    if (Directory.Exists(credPath))
                    {
                        Directory.Delete(credPath, true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa thông tin xác thực: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Gọi phương thức để hủy xác thực
            LogoutGoogle();

            // Xóa thông tin người dùng đã lưu
            userInfo = null;

            // Hiển thị thông báo đăng xuất thành công
            MessageBox.Show("Đã đăng xuất thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Đưa người dùng trở lại màn hình đăng nhập
            var loginForm = new Login();
            loginForm.Show();
            this.Close();
        }

        private async void btn_LoginWithGoogle_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Hủy xác thực hiện tại và xóa thư mục lưu trữ thông tin xác thực
                LogoutGoogle();
                // Gọi phương thức LoginWithGoogleAsync từ LoginService
                userInfo = await loginService.LoginWithGoogleAsync();

                //userInfo = null;
                if (userInfo != null)
                {
                    // Hiển thị thông tin người dùng (hoặc xử lý logic đăng nhập)
                    //MessageBox.Show($"ID: {userInfo.Id}\nTên: {userInfo.Name}\nEmail: {userInfo.Email}");
                    NhanVien cv = loginService.KiemTraDangNhapGoogle(userInfo.Id, userInfo.Name, userInfo.Email);
                    // Chuyển tới màn hình chính (Main) nếu cần
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
                        MessageBox.Show("Đăng nhập bằng Google thất bại!. ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Đăng nhập bằng Google thất bại!. ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //// Gọi phương thức từ LoginService để kiểm tra đăng nhập
                //NhanVien cv = loginService.KiemTraDangNhap(username, pass);
                //if (cv != null)
                //{
                //    Main main = new Main();
                //    main.SetUserRole(cv.ChucVu);
                //    main.MANV = cv.Id;
                //    main.Show();
                //    this.Hide();
                //}
                //else
                //{
                //    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đăng nhập bằng Google thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            btn_LoginWithGoogle_Click_1(sender, e);
        }
    }
}
