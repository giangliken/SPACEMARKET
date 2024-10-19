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

        private string MaHoaDon;
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
    }
}
