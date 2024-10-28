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

namespace SpaceMarket
{
    public partial class InNhanVien : Form
    {
        private readonly StaffService staffService=new StaffService();
        public InNhanVien()
        {
            InitializeComponent();
        }
        
        private void InNhanVien_Load(object sender, EventArgs e)
        {
            var inNV = staffService.GetAll() ;
            if (inNV != null && inNV.Any())
            {
                ReportDataSource reportDataSource = new ReportDataSource("DSNhanVien", inNV);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                // Thiết lập nguồn cho báo cáo
                this.reportViewer1.LocalReport.ReportPath = @"D:\Tai Lieu Hoc Tap\Lap Trinh Tren Moi Truong Windows\Do an\SpaceMarket\SpaceMarket\Bao cao\ReportNhanVien.rdlc";
                

                this.reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu hóa đơn để hiển thị.");
            }
        }
        
    }
}
