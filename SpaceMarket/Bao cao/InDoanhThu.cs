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

namespace SpaceMarket
{
    public partial class InDoanhThu : Form
    {

        private readonly SaleService saleService = new SaleService();
        public InDoanhThu()
        {
            InitializeComponent();
        }
        public string TENNV { get; set; }
        public string CHUCVU { get; set; }
        public DateTime? NGAYSINH { get; set; }
        private void InDoanhThu_Load(object sender, EventArgs e)
        {

            var doanhThu = saleService.GetDoanhThu();

            if (doanhThu != null && doanhThu.Any())
            {
                // Thiết lập ReportDataSource với tên dataset chính xác
                ReportDataSource reportDataSource = new ReportDataSource("ReportDOANHTHU", doanhThu);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                


                // Thiết lập nguồn cho báo cáo
                this.reportViewer1.LocalReport.ReportPath = @"Bao cao\\ReportDoanhThu.rdlc";

                // Thiết lập tham số MANV
                ReportParameter[] parameters = new ReportParameter[]
                {
                    new ReportParameter("TENNV", TENNV),
                    new ReportParameter("NGAYSINH", NGAYSINH.HasValue? NGAYSINH.Value.Date.ToString("dd/MM/yyyy") : ""),
                    new ReportParameter("CHUCVU", CHUCVU)
                };

                this.reportViewer1.LocalReport.SetParameters(parameters);

                // Refresh lại ReportViewer để hiển thị dữ liệu
                this.reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu hóa đơn để hiển thị.");
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
