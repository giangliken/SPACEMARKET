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
    public partial class InSanPham : Form
    {
        private readonly ProductService productService=new ProductService();

        public InSanPham()
        {
            InitializeComponent();
        }

        private void InSanPham_Load(object sender, EventArgs e)
        {
            List<SANPHAMS> productList = productService.GetAll();
            DataTable dt = new DataTable();
            dt.Columns.Add("MASP");
            dt.Columns.Add("TENSP");
            dt.Columns.Add("NHACUNGCAP");
            dt.Columns.Add("DANHMUC");
            dt.Columns.Add("GIABAN", typeof(decimal));
            foreach (var product in productList)
            {
                dt.Rows.Add(product.MASP, product.TENSP, product.NCC, product.DM, product.GIA);
            }
            var Insp = productService.GetAll();
            ReportDataSource reportDataSource = new ReportDataSource("DSSanPham", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            // Thiết lập nguồn cho báo cáo
            this.reportViewer1.LocalReport.ReportPath = @"D:\Tai Lieu Hoc Tap\Lap Trinh Tren Moi Truong Windows\Do an\SpaceMarket\SpaceMarket\Bao cao\ReportSanPham.rdlc";
            this.reportViewer1.RefreshReport();
        }
    }
}
