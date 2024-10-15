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

        }

        private void txtChucVu_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaNVSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFullNameSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCCCDSearch_TextChanged(object sender, EventArgs e)
        {

        }


        private void btnSearchNV_Click(object sender, EventArgs e)
        {
            // Gọi hàm tìm kiếm và lấy kết quả
            var result = staffService.SearchStaff(txtMaNVSearch.Text, txtFullNameSearch.Text, txtCCCDSearch.Text);
            // Cập nhật lại DataGridView
            datagwdanhsachnhanvien.DataSource = result;
            // Kiểm tra kết quả tìm kiếm
            if (result.Count == 0)
            {
                MessageBox.Show("Không tìm thấy nhân viên nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Tìm kiếm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            string tennv = txtFullName.Text;
            string cv = txtChucVu.Text;
            string sdt = txtPhone.Text;
            string email = txtEmail.Text;
            string cccd = txtcccd.Text; // Thêm dòng này để lấy CCCD
            DateTime ngaysinh = dtpNgaySinh.Value; // Giả sử bạn có một DateTimePicker cho ngày sinh

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


    }
}
