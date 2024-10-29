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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SpaceMarket
{
    public partial class DoiMatKhau : Form
    {
        private string currentUsername;
        public DoiMatKhau(string username)
        {
            InitializeComponent();
            currentUsername = username;
        }

        private void btnxacnhan_Click(object sender, EventArgs e)
        {
            string oldPassword = txtmkcu.Text;
            string newPassword = txtmkmoi.Text;
            string confirmPassword = txtmklai.Text;

            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu mới và nhập lại không khớp.");
                return;
            }

            // Gọi phương thức đổi mật khẩu từ StaffService
            string result = StaffService.Instance.ChangePassword(currentUsername, oldPassword, newPassword);

            MessageBox.Show(result);
            if (result == "Đổi mật khẩu thành công!")
            {
                this.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            btnxacnhan_Click(sender, e);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Hủy tác vụ thay đổi mật khẩu ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult.OK == dr)
            {
                this.Close();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            btnHuy_Click(sender, e);
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {

        }
    }
}
