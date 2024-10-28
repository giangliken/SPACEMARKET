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
    public partial class HoaDon : Form
    {
        private readonly TraCuuHoaDonService traCuuHoaDonService = new TraCuuHoaDonService();
        public HoaDon()
        {
            InitializeComponent();
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {

        }

        private void txtMaHoaDon_TextChanged(object sender, EventArgs e)
        {
            LoadChiTietHoaDon(txtMaHoaDon.Text);
        }

        private void LoadChiTietHoaDon(string MaHoaDon)
        {
            dataChiTietHoaDon.DataSource = traCuuHoaDonService.GetAll(MaHoaDon);
            lblNgayTao.Text = traCuuHoaDonService.GetNgayTao(MaHoaDon);
            lblThongTriGia.Text = traCuuHoaDonService.GetTongTriGia(MaHoaDon);
            lblMaNhanVien.Text = traCuuHoaDonService.GetMaNV(MaHoaDon);
            lblMaKhachHang.Text = traCuuHoaDonService.GetMaKH(MaHoaDon);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (dataChiTietHoaDon != null && dataChiTietHoaDon.Rows.Count > 0)
            {
                InHoaDon inHoaDon = new InHoaDon();
                inHoaDon.MaHoaDon = txtMaHoaDon.Text;
                inHoaDon.MaHoaDon = txtMaHoaDon.Text.Trim();
                inHoaDon.ShowDialog();
            }
            else
            {
                MessageBox.Show("Thông tin hóa đơn bị trống! Vui lòng thử lại sau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMaHoaDon_Enter(object sender, EventArgs e)
        {
            if (txtMaHoaDon.Text == "Nhập mã hóa đơn")
            {
                txtMaHoaDon.Text = string.Empty;
                txtMaHoaDon.ForeColor = Color.Black;
            }
        }

        private void txtMaHoaDon_Leave(object sender, EventArgs e)
        {
            if (txtMaHoaDon.Text == string.Empty)
            {
                txtMaHoaDon.Text = "Nhập mã hóa đơn";
                txtMaHoaDon.ForeColor = Color.Silver;
            }
        }

        private void lblMaNhanVien_Click(object sender, EventArgs e)
        {

        }
    }
}
