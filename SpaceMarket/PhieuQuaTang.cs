using BLL;
using SpaceMarket.Bao_cao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceMarket
{
    public partial class PhieuQuaTang : Form
    {
        private readonly PhieuQuaTangService phieuQuaTangService = new PhieuQuaTangService();
        public PhieuQuaTang()
        {
            InitializeComponent();
        }

        private void PhieuQuaTang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvDanhSachPQT.DataSource = phieuQuaTangService.GetAll();
            // Đặt định dạng cho DateTimePicker
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;

            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
        }

        private void txtMaPhieu_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPTGiam_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtDieuKienApDung_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvDanhSachPQT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng đã chọn một hàng (không phải header)
            if (e.RowIndex >= 0)
            {
                // Lấy hàng đã chọn
                DataGridViewRow row = dgvDanhSachPQT.Rows[e.RowIndex];

                // Cập nhật các TextBox với dữ liệu từ hàng đã chọn
                txtMaPhieu.Text = row.Cells["MAPHIEU"].Value.ToString();
                txtPTGiam.Text = row.Cells["PTGIAM"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["THOIGIANBD"].Value);
                dateTimePicker2.Value = Convert.ToDateTime(row.Cells["THOIGIANKT"].Value);
                txtDieuKienApDung.Text = row.Cells["DKAPDUNG"].Value?.ToString() ?? string.Empty;
            }
        }

        private void uiCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (uiCheckBox1.Checked)
            {
                // Ngày hiện tại
                DateTime currentDate = DateTime.Now;

                // Lọc dữ liệu
                var filteredData = phieuQuaTangService.GetAll()
                    .Where(p => p.THOIGIANKT > currentDate)
                    .ToList();

                // Cập nhật DataGridView với dữ liệu đã lọc
                dgvDanhSachPQT.DataSource = filteredData;
            }
            else
            {
                // Khi không kiểm tra, tải lại tất cả dữ liệu
                LoadData();
            }
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            InPhieuQuaTang inPhieuQuaTang = new InPhieuQuaTang();
            inPhieuQuaTang.maPhieu = txtMaPhieu.Text;
            inPhieuQuaTang.ShowDialog();
        }
    }
}
