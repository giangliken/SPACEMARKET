using BLL;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceMarket.Bao_cao
{
    public partial class InPhieuGiaoHang : Form
    {
        private readonly GiaoHangService giaoHangService = new GiaoHangService();
        private readonly KhachHangService khachHangService= new KhachHangService();
        private readonly StaffService staffService = new StaffService();

        private string MAPGH { get; set; }

        public InPhieuGiaoHang(string maphieugiaohang)
        {
            InitializeComponent();
            MAPGH = maphieugiaohang;
        }

        private void InPhieuGiaoHang_Load(object sender, EventArgs e)
        {
            // Lấy thông tin phiếu giao hàng theo MAPGH
            var phieuGiaoHang = giaoHangService.GetPhieuGiaoHangByMa(MAPGH);
            if (phieuGiaoHang == null)
            {
                MessageBox.Show("Không tìm thấy phiếu giao hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Tạo DataTable để chứa dữ liệu
            DataTable dt = new DataTable();
            dt.Columns.Add("MAPGH");
            dt.Columns.Add("MAHD");
            dt.Columns.Add("NGAYDUKIENGH", typeof(DateTime));
            dt.Columns.Add("DIACHIGIAOHANG");
            dt.Columns.Add("SDTNGUOINHANHANG");
            dt.Columns.Add("MOTA");

            // Thêm dữ liệu phiếu giao hàng vào DataTable
            dt.Rows.Add(phieuGiaoHang.MAPGH, phieuGiaoHang.MAHD, phieuGiaoHang.NGAYDUKIENGH, phieuGiaoHang.DIACHIGIAOHANG, phieuGiaoHang.SDTNGUOINHANHANG, phieuGiaoHang.MOTA);

            // Thiết lập ReportDataSource với DataTable
            ReportDataSource reportDataSource = new ReportDataSource("DSGiaoHang", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            // Thiết lập đường dẫn tới file RDLC
            this.reportViewer1.LocalReport.ReportPath = @"Bao cao\ReportGiaoHang.rdlc";

            // Lấy tên nhân viên và khách hàng từ MAHD
            string tenNV = staffService.GetStaffNameByInvoiceId(phieuGiaoHang.MAHD);
            string tenKH = khachHangService.GetCustomerNameByInvoiceId(phieuGiaoHang.MAHD);

            // Thiết lập các tham số cho báo cáo
            ReportParameter[] parameters = new ReportParameter[]
            {
                new ReportParameter("TenNV", tenNV ?? "N/A"), // Nếu không tìm thấy tên thì hiển thị "N/A"
                new ReportParameter("TenKH", tenKH ?? "N/A")  // Nếu không tìm thấy tên thì hiển thị "N/A"
            };

            this.reportViewer1.LocalReport.SetParameters(parameters);

            // Refresh để hiển thị báo cáo
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
