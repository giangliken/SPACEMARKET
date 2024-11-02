using BLL;
using DAL.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpaceMarket
{
    public partial class Staff_Management : Form
    {
        StaffService staffService = new StaffService();
        public Staff_Management()
        {
            InitializeComponent();
        }

        private void Staff_Management_Load(object sender, EventArgs e)
        {
            // Đặt định dạng cho DateTimePicker
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";





            // Thiết lập AutoGenerateColumns thành false
            datagwdanhsachnhanvien.AutoGenerateColumns = false;

            // Tạo cột theo ý muốn
            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã NV",
                DataPropertyName = "MANV",
                Name = "MANV"
            };
            datagwdanhsachnhanvien.Columns.Add(column1);

            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên NV",
                DataPropertyName = "TENNV",
                Name = "TENNV"
            };
            datagwdanhsachnhanvien.Columns.Add(column2);

            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn
            {
                HeaderText = "CMND / CCCD",
                DataPropertyName = "CCCD",
                Name = "CCCD"
            };
            datagwdanhsachnhanvien.Columns.Add(column3);

            DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn
            {
                HeaderText = "Ngày sinh",
                DataPropertyName = "NGAYSINH",
                Name = "NGAYSINH"
            };
            datagwdanhsachnhanvien.Columns.Add(column4);

            DataGridViewTextBoxColumn column5 = new DataGridViewTextBoxColumn
            {
                HeaderText = "Chức Vụ",
                DataPropertyName = "CV",
                Name = "CV"
            };
            datagwdanhsachnhanvien.Columns.Add(column5);

            DataGridViewTextBoxColumn column6 = new DataGridViewTextBoxColumn
            {
                HeaderText = "SĐT",
                DataPropertyName = "SDTNV",
                Name = "SDTNV"
            };
            datagwdanhsachnhanvien.Columns.Add(column6);

            DataGridViewTextBoxColumn column7 = new DataGridViewTextBoxColumn
            {
                HeaderText = "Email",
                DataPropertyName = "EMAILNV",
                Name = "EMAILNV"
            };
            datagwdanhsachnhanvien.Columns.Add(column7);

            // Đổ dữ liệu vào DataGridView
            datagwdanhsachnhanvien.DataSource = staffService.GetAll();

            // Định dạng cột Ngày sinh
            datagwdanhsachnhanvien.Columns["NGAYSINH"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }


        private void txtFullName_TextChanged(object sender, EventArgs e)
        {
            // Lấy giá trị hiện tại trong txtFullName
            string input = txtFullName.Text;

            // Biểu thức chính quy để chỉ cho phép chữ cái (A-Z, a-z, và các ký tự tiếng Việt) cùng với khoảng trắng
            string pattern = @"^[\p{L}\s]*$"; // \p{L} cho phép tất cả các ký tự chữ

            // Kiểm tra xem giá trị có phù hợp với biểu thức chính quy không
            if (!System.Text.RegularExpressions.Regex.IsMatch(input, pattern))
            {
                MessageBox.Show("Họ tên chỉ được phép chứa chữ cái và khoảng trắng.");
                // Chỉ giữ lại các ký tự hợp lệ
                txtFullName.Text = new string(input.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());
                txtFullName.SelectionStart = txtFullName.Text.Length; // Đặt con trỏ về cuối ô nhập
            }

            // Giới hạn độ dài tối đa là 100 ký tự
            if (txtFullName.Text.Length > 100)
            {
                MessageBox.Show("Họ tên tối đa chỉ được 100 ký tự.");
                txtFullName.Text = txtFullName.Text.Substring(0, 100); // Cắt chuỗi về 100 ký tự
                txtFullName.SelectionStart = txtFullName.Text.Length; // Đặt con trỏ về cuối ô nhập
            }
        }




        private void txtChucVu_TextChanged(object sender, EventArgs e)
        {
            // Lấy giá trị hiện tại trong txtChucVu
            string input = txtChucVu.Text;

            string pattern = @"^[\p{L}\s]*$";

            // Kiểm tra xem giá trị có phù hợp với biểu thức chính quy không
            if (!System.Text.RegularExpressions.Regex.IsMatch(input, pattern))
            {
                MessageBox.Show("Chức vụ chỉ được phép chứa chữ cái và khoảng trắng.");
                // Chỉ giữ lại các ký tự hợp lệ
                txtChucVu.Text = new string(input.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());
                txtChucVu.SelectionStart = txtChucVu.Text.Length; // Đặt con trỏ về cuối ô nhập
            }

            // Giới hạn độ dài tối đa là 50 ký tự
            if (txtChucVu.Text.Length > 50)
            {
                MessageBox.Show("Chức vụ tối đa chỉ được 50 ký tự.");
                txtChucVu.Text = txtChucVu.Text.Substring(0, 50); // Cắt chuỗi về 50 ký tự
                txtChucVu.SelectionStart = txtChucVu.Text.Length; // Đặt con trỏ về cuối ô nhập
            }
        }


        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            
        }



        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            // Lấy giá trị hiện tại trong txtPhone
            string input = txtPhone.Text;

            // Kiểm tra xem giá trị có chứa ký tự không phải là số hay không
            if (!input.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại chỉ được phép chứa các ký tự số.");

                // Chỉ giữ lại các ký tự số
                txtPhone.Text = new string(input.Where(char.IsDigit).ToArray());
                txtPhone.SelectionStart = txtPhone.Text.Length; // Đặt con trỏ về cuối ô nhập
            }

            // Giới hạn độ dài tối đa là 11 ký tự
            if (txtPhone.Text.Length > 11)
            {
                MessageBox.Show("Số điện thoại tối đa chỉ được 11 ký tự.");
                txtPhone.Text = txtPhone.Text.Substring(0, 11); // Cắt chuỗi về 11 ký tự
                txtPhone.SelectionStart = txtPhone.Text.Length; // Đặt con trỏ về cuối ô nhập
            }
        }


        private void txtMaNVSearch_TextChanged(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void txtFullNameSearch_TextChanged(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void txtCCCDSearch_TextChanged(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void TimKiem()
        {
            // Gọi hàm tìm kiếm và lấy kết quả
            var result = staffService.SearchStaff(txtMaNVSearch.Text, txtFullNameSearch.Text, txtCCCDSearch.Text);

            // Cập nhật lại DataGridView
            datagwdanhsachnhanvien.DataSource = result;

            //// Kiểm tra kết quả tìm kiếm
            //if (result.Count == 0)
            //{
            //    MessageBox.Show("Không tìm thấy nhân viên nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else
            //{
            //    MessageBox.Show("Tìm kiếm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }



        private void datagwdanhsachnhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có ô nào được chọn hay không
            if (e.RowIndex >= 0)
            {
                // Lấy dữ liệu từ DataGridView
                int rowIndex = e.RowIndex;
                //string manv = datagwdanhsachnhanvien.Rows[rowIndex].Cells["MANV"].Value.ToString();
                string tennv = datagwdanhsachnhanvien.Rows[rowIndex].Cells["TENNV"].Value.ToString();
                string cv = datagwdanhsachnhanvien.Rows[rowIndex].Cells["CV"].Value.ToString();
                string sdt = datagwdanhsachnhanvien.Rows[rowIndex].Cells["SDTNV"].Value.ToString();
                string email = datagwdanhsachnhanvien.Rows[rowIndex].Cells["EMAILNV"].Value.ToString();
                string cccd = datagwdanhsachnhanvien.Rows[rowIndex].Cells["CCCD"].Value.ToString();
                DateTime ngaysinh = (DateTime)datagwdanhsachnhanvien.Rows[rowIndex].Cells["NGAYSINH"].Value; // Lấy ngày sinh

                // Đổ dữ liệu ngược vào các ô nhập liệu
                //txtm.Text = manv; // Đảm bảo bạn có txtMaNV để hiển thị Mã NV
                txtFullName.Text = tennv;
                txtChucVu.Text = cv;
                txtPhone.Text = sdt;
                txtEmail.Text = email;
                txtcccd.Text = cccd; // Thêm ô nhập liệu cho CCCD
                dtpNgaySinh.Value = ngaysinh; // Đổ ngày sinh vào DateTimePicker
            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các ô nhập liệu
            string tennv = txtFullName.Text.Trim(); // Loại bỏ khoảng trắng ở đầu và cuối
            string cv = txtChucVu.Text.Trim();
            string sdt = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string cccd = txtcccd.Text.Trim(); // Thêm dòng này để lấy CCCD
            DateTime ngaysinh = dtpNgaySinh.Value; // Giả sử bạn có một DateTimePicker cho ngày sinh

            // Ràng buộc kiểm tra các trường không được để trống
            if (string.IsNullOrEmpty(tennv) || string.IsNullOrEmpty(cv) || string.IsNullOrEmpty(sdt) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(cccd))
            {
                MessageBox.Show("Tất cả các trường không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Thoát khỏi hàm nếu có trường trống
            }

            // Gọi hàm thêm nhân viên
            string result = staffService.AddStaff(tennv, cv, sdt, email, cccd, ngaysinh);

            // Kiểm tra kết quả trả về
            if (result == "Thêm nhân viên mới thành công!")
            {
                // Cập nhật lại DataGridView
                Model1 context = new Model1(); // Có thể chuyển logic này vào BLL nếu cần
                datagwdanhsachnhanvien.DataSource = context.NHANVIEN.ToList();

                MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }







        private void Staff_Management_MouseClick(object sender, MouseEventArgs e)
        {
            txtFullName.Text = "";
            txtChucVu.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtcccd.Text = "";

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có ô nào được chọn trong DataGridView hay không
            if (datagwdanhsachnhanvien.CurrentCell == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu từ DataGridView
            int rowIndex = datagwdanhsachnhanvien.CurrentCell.RowIndex;
            string manv = datagwdanhsachnhanvien.Rows[rowIndex].Cells["MANV"].Value.ToString();

            // Lấy dữ liệu từ các ô nhập liệu
            string tennv = txtFullName.Text;
            string cv = txtChucVu.Text;
            string sdt = txtPhone.Text;
            string email = txtEmail.Text;
            string cccd = txtcccd.Text;
            DateTime ngaysinh = dtpNgaySinh.Value;

            // Gọi BLL để sửa nhân viên
            string result = staffService.UpdateEmployee(manv, tennv, cv, sdt, email, cccd, ngaysinh);

            // Kiểm tra kết quả từ BLL
            if (result == "Cập nhật nhân viên thành công!")
            {
                datagwdanhsachnhanvien.DataSource = staffService.GetAll();
            }

            MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có ô nào được chọn trong DataGridView hay không
            if (datagwdanhsachnhanvien.CurrentCell == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu từ DataGridView
            int rowIndex = datagwdanhsachnhanvien.CurrentCell.RowIndex;
            string manv = datagwdanhsachnhanvien.Rows[rowIndex].Cells["MANV"].Value.ToString();
            string tennv = datagwdanhsachnhanvien.Rows[rowIndex].Cells["TENNV"].Value.ToString(); // Lấy tên nhân viên

            // Hỏi người dùng xem có chắc chắn muốn xóa nhân viên với thông tin chi tiết
            var confirmResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên:\n {tennv}\n (Mã NV: {manv}) ?",
                                                "Xác nhận xóa",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.No)
            {
                return;
            }


            string result = staffService.DeleteEmployee(manv);

            // Kiểm tra kết quả từ BLL
            if (result == "Xóa nhân viên thành công!")
            {
                datagwdanhsachnhanvien.DataSource = staffService.GetAll();
            }

            MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {
            
        }


        private void btnIn_Click(object sender, EventArgs e)
        {
            InNhanVien inNhanVien = new InNhanVien();
            inNhanVien.ShowDialog();
        }

        private void txtcccd_TextChanged(object sender, EventArgs e)
        {
            // Lấy giá trị hiện tại trong txtcccd
            string input = txtcccd.Text;

            // Kiểm tra xem có ký tự không phải là số không
            if (!string.IsNullOrEmpty(input) && !input.All(char.IsDigit))
            {
                MessageBox.Show("Số CCCD chỉ được phép chứa chữ số.");
                // Xóa ký tự không hợp lệ
                txtcccd.Text = new string(input.Where(char.IsDigit).ToArray());
                txtcccd.SelectionStart = txtcccd.Text.Length; // Đặt con trỏ về cuối ô nhập
            }

            // Đảm bảo độ dài không vượt quá 12
            if (txtcccd.Text.Length > 12)
            {
                MessageBox.Show("Số CCCD tối đa là 12 chữ số.");
                // Cắt chuỗi về 12 ký tự
                txtcccd.Text = txtcccd.Text.Substring(0, 12);
                txtcccd.SelectionStart = txtcccd.Text.Length; // Đặt con trỏ về cuối ô nhập
            }
        }


        private void txtcccd_Leave(object sender, EventArgs e)
        {
            
        }

        private void dtpNgaySinh_Leave(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpNgaySinh.Value;
            DateTime currentDate = DateTime.Now;

            // Kiểm tra xem ngày chọn có lớn hơn ngày hiện tại không
            if (selectedDate > currentDate)
            {
                MessageBox.Show("Ngày sinh không được lớn hơn ngày hiện tại.");
                // Đặt lại giá trị về ngày hiện tại hoặc một giá trị mặc định
                dtpNgaySinh.Value = currentDate;
            }

            // Kiểm tra xem người dùng có đủ 18 tuổi không
            DateTime eighteenYearsAgo = currentDate.AddYears(-18);
            if (selectedDate > eighteenYearsAgo)
            {
                MessageBox.Show("Bạn phải từ đủ 18 tuổi.");
                // Đặt lại giá trị về 18 năm trước ngày hiện tại
                dtpNgaySinh.Value = eighteenYearsAgo;
            }
        }


        private void txtPhone_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            // Kiểm tra chiều dài của chuỗi nhập vào
            if (txtEmail.Text.Length > 200)
            {
                // Nếu chiều dài vượt quá 200 ký tự, giữ lại chỉ 200 ký tự đầu
                txtEmail.Text = txtEmail.Text.Substring(0, 200);
                txtEmail.SelectionStart = txtEmail.Text.Length; // Đặt con trỏ về cuối ô nhập
            }

            // Kiểm tra định dạng email chỉ khi có ít nhất một ký tự
            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                // Biểu thức chính quy để kiểm tra định dạng email
                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, pattern))
                {
                    // Nếu định dạng không hợp lệ, có thể xóa hoặc hiển thị thông báo
                    MessageBox.Show("Email không hợp lệ.");
                }
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
