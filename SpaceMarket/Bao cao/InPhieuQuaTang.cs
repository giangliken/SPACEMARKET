using BLL;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace SpaceMarket.Bao_cao
{
    public partial class InPhieuQuaTang : Form
    {
        private readonly PhieuQuaTangService phieuQuaTangService = new PhieuQuaTangService();

        public string maHD { get; set; }
        public string maPhieu { get; set; }

        public InPhieuQuaTang()
        {
            InitializeComponent();
        }

        private void InPhieuQuaTang_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maHD) && string.IsNullOrWhiteSpace(maPhieu))
            {
                MessageBox.Show("Cần cung cấp mã hóa đơn hoặc mã phiếu quà tặng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Lấy phiếu quà tặng theo mã HD hoặc mã phiếu
            PQT phieu = null;
            if (!string.IsNullOrWhiteSpace(maHD))
            {
                phieu = phieuQuaTangService.GetByMaHD(maHD);
            }
            else if (!string.IsNullOrWhiteSpace(maPhieu))
            {
                phieu = phieuQuaTangService.GetByMaPhieu(maPhieu);
            }

            if (phieu == null)
            {
                MessageBox.Show("Không tìm thấy phiếu quà tặng với mã đã cung cấp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Thiết lập DataTable và thêm dữ liệu phiếu quà tặng vào DataTable
            DataTable dt = CreateDataTable(phieu);

            // Thiết lập ReportDataSource với DataTable
            ReportDataSource reportDataSource = new ReportDataSource("DSPhieuQuaTang", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            // Thiết lập đường dẫn tới file RDLC
            this.reportViewer1.LocalReport.ReportPath = @"D:\Tai Lieu Hoc Tap\Lap Trinh Tren Moi Truong Windows\Do an\SpaceMarket\SpaceMarket\Bao cao\ReportPhieuQuaTang.rdlc";

            // Refresh để hiển thị báo cáo
            this.reportViewer1.RefreshReport();
        }

        private DataTable CreateDataTable(PQT phieu)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MAPHIEU");
            dt.Columns.Add("PTGIAM");
            dt.Columns.Add("THOIGIANBD", typeof(DateTime));
            dt.Columns.Add("THOIGIANKT", typeof(DateTime));
            dt.Columns.Add("DKAPDUNG");

            // Thêm dữ liệu phiếu quà tặng vào DataTable
            dt.Rows.Add(phieu.MAPHIEU, phieu.PTGIAM, phieu.THOIGIANBD, phieu.THOIGIANKT, phieu.DKAPDUNG);
            return dt;
        }
    }
}
