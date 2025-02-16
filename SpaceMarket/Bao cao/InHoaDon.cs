using BLL;
using DAL.Database;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceMarket.Bao_cao
{
    public partial class InHoaDon : Form
    {
        public string MaHoaDon {  get; set; }
        public int TienThoi { get; set; }
        public int TienKhachChuyenKhoan { get; set; }
        public int TienKhachDua { get; set; }
        private readonly TraCuuHoaDonService traCuuHoaDonService = new TraCuuHoaDonService();   
        public InHoaDon()
        {
            InitializeComponent();
        }


        private void InHoaDon_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Tien Khach Dua: " + TienKhachDua + "Tien Thoi: " + TienThoi + "Tien Khach CK: "+ TienKhachChuyenKhoan);
            //Model1 context = new Model1();
            List<ReportCHITIETHOADON> ListCHITIETHOADON = traCuuHoaDonService.GetReportCTHD(MaHoaDon);
            reportCHITIETHOADON.LocalReport.ReportPath = "Bao cao\\ReportHoaDon.rdlc";
            //MaHoaDon = "2024100017";
            var source = new ReportDataSource("ReportCHITIETHOADON", ListCHITIETHOADON);
            //Làm mới dữ liệu
            reportCHITIETHOADON.LocalReport.DataSources.Clear();
            reportCHITIETHOADON.LocalReport.DataSources.Add(source);

            //TENNV = ;
            // Lấy mã nhân viên dựa trên mã hóa đơn
            //MessageBox.Show("Ma hoa don" +MaHoaDon);
            // Thiết lập tham số MANV
            ReportParameter[] parameters = new ReportParameter[]
            {
                    new ReportParameter("MAHD",MaHoaDon.ToString()),
                    new ReportParameter("NGAYLAP",traCuuHoaDonService.GetNgayTao(MaHoaDon)),
                    new ReportParameter("MANV", traCuuHoaDonService.GetMaNV(MaHoaDon)),
                    new ReportParameter("TIENKHACHDUA",TienKhachDua.ToString("#,0'₫';(#,0'₫')")),
                    new ReportParameter("TIENKHACHCHUYENKHOAN",TienKhachChuyenKhoan.ToString("#,0'₫';(#,0'₫')")),
                    new ReportParameter("TIENTHOI",TienThoi.ToString("#,0'₫';(#,0'₫')")),
                    //new ReportParameter("CHUCVU", CHUCVU)
            };
            // Thiết lập tham số cho LocalReport
            reportCHITIETHOADON.LocalReport.SetParameters(parameters);

            this.reportCHITIETHOADON.RefreshReport();
        }
    }
}
