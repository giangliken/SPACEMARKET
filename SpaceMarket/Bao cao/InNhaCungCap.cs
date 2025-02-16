using BLL;
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
    public partial class InNhaCungCap : Form
    {
        private readonly ProductService productService=new ProductService();
        public InNhaCungCap()
        {
            InitializeComponent();
        }

        private void InNhaCungCap_Load(object sender, EventArgs e)
        {
            var inNCC= productService.GetNCC();
            if (inNCC != null && inNCC.Any())
            {
                ReportDataSource reportDataSource = new ReportDataSource("DSNhaCungCap", inNCC);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                // Thiết lập nguồn cho báo cáo
                this.reportViewer1.LocalReport.ReportPath = @"Bao cao\ReportNhaCungCap.rdlc";


                this.reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu hóa đơn để hiển thị.");
            }
            this.reportViewer1.RefreshReport();
            
        }
    }
}
