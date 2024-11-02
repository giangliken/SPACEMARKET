using BLL;
using DAL.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace SpaceMarket
{
    public partial class Account_Management : Form
    {
        public readonly StaffService staffService = new StaffService();
        public Account_Management()
        {
            InitializeComponent();
        }

        private void Account_Management_Load(object sender, EventArgs e)
        {
            
            // Thiết lập AutoGenerateColumns thành false
            datagwdanhsachtaikhoan.AutoGenerateColumns = false;

            // Tạo cột theo ý muốn
            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            column1.HeaderText = "Tên tài khoản";
            column1.DataPropertyName = "USERNAME";
            column1.Name = "USERNAME";
            datagwdanhsachtaikhoan.Columns.Add(column1);

            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            column2.HeaderText = "Mật khẩu";
            column2.DataPropertyName = "PASSWORD";
            column2.Name = "PASSWORD";
            datagwdanhsachtaikhoan.Columns.Add(column2);

            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
            column3.HeaderText = "Tên nhân viên";
            column3.DataPropertyName = "TENNV"; // Thêm DataPropertyName để kết nối với dữ liệu
            column3.Name = "TENNV";
            datagwdanhsachtaikhoan.Columns.Add(column3);

            // Đổ dữ liệu vào DataGridView
            ReloadData();
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu chiều dài văn bản vượt quá 50 ký tự
            if (txtpass.Text.Length > 50)
            {
                MessageBox.Show("Mật khẩu tối đa chỉ được 50 ký tự.");
                // Cắt chuỗi về 50 ký tự
                txtpass.Text = txtpass.Text.Substring(0, 50);
                txtpass.SelectionStart = txtpass.Text.Length; // Đặt con trỏ về cuối ô nhập
            }
        }


        private void txtsearchtk_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            DialogResult dr = MessageBox.Show("Hiện tại bạn chưa thể thêm mới tài khoản!\nĐể thêm mới tài khoản trước tiên bạn cần nhập thông tin cho nhân viên!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                Staff_Management staff_Management = new Staff_Management();
                staff_Management.ShowDialog();
                this.Hide();
            }
        }


        private void btnsearchtk_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ ô txtsearchtk
            string search = txtsearchtk.Text;

            // Kiểm tra xem dữ liệu đã được nhập đầy đủ chưa
            if (string.IsNullOrEmpty(search))
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo mới một đối tượng Model1
            Model1 context = new Model1();

            // Tìm kiếm tài khoản với txtsearchtk được nhập vào
            var result = context.NHANVIEN.Where(x => x.USERNAME.Contains(search) || x.TENNV.Contains(search)).ToList();

            // Kiểm tra xem có kết quả tìm kiếm hay không
            if (result.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Cập nhật lại DataGridView
                datagwdanhsachtaikhoan.DataSource = result;

                // Thông báo thành công
                MessageBox.Show("Tìm kiếm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có ô nào được chọn trong DataGridView hay không
            if (datagwdanhsachtaikhoan.CurrentCell == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu từ DataGridView
            int rowIndex = datagwdanhsachtaikhoan.CurrentCell.RowIndex;
            string username = datagwdanhsachtaikhoan.Rows[rowIndex].Cells["USERNAME"].Value.ToString();

            string result = staffService.UpdateAccount(username, txtpass.Text);

            // Làm mới DataGridView
            ReloadData();


            // Hiển thị thông báo kết quả
            MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void datagwdanhsachtaikhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lấy dữ liệu từ DataGridView
            int rowIndex = e.RowIndex;
            string username = datagwdanhsachtaikhoan.Rows[rowIndex].Cells["USERNAME"].Value.ToString();
            string password = datagwdanhsachtaikhoan.Rows[rowIndex].Cells["PASSWORD"].Value.ToString();

            // Đổ dữ liệu ngược lại vào 2 ô nhập
            txtusername.Text = username;
            txtpass.Text = password;
        }

        private void Account_Management_MouseClick(object sender, MouseEventArgs e)
        {
            txtusername.Text = "";
            txtpass.Text = "";
        }

        private void ReloadData()
        {
            // Đổ dữ liệu vào DataGridView
            datagwdanhsachtaikhoan.DataSource = staffService.GetAll();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có ô nào được chọn trong DataGridView hay không
            if (datagwdanhsachtaikhoan.CurrentCell == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu từ DataGridView
            int rowIndex = datagwdanhsachtaikhoan.CurrentCell.RowIndex;
            string username = datagwdanhsachtaikhoan.Rows[rowIndex].Cells["USERNAME"].Value.ToString();

            // Xác nhận trước khi xóa
            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa tài khoản '{username}'? \nLưu ý việc xóa tài khoản cũng sẽ khiến các dữ liệu liên quan cũng bị xóa!", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                // Gọi phương thức xóa tài khoản
                string result = staffService.DeleteAccount(username);

                // Làm mới DataGridView
                ReloadData();

                // Hiển thị thông báo kết quả
                MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            btnThem_Click(sender, e);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            btnXoa_Click(sender, e);    
        }
    }
}
