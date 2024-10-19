using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TraCuuHoaDonService
    {
        //Phương thức trả về danh sách sản phẩm trong hóa đơn
        public List<SanPham> GetAll(string mahoadon)
        {
            using (Model1 context = new Model1())
            {
                var hoadon = from cthd in context.CHITIETHOADON
                             join hd in context.HOADON on cthd.MAHD equals hd.MAHD
                             join sp in context.SANPHAM on cthd.MASP equals sp.MASP
                             join dm in context.DANHMUC on sp.MADM equals dm.MADM
                             where cthd.MAHD == mahoadon
                             select new SanPham
                             {
                                 MASP = cthd.MASP,
                                 TENSP = sp.TENSP,
                                 DVT = dm.TENDM,
                                 DONGIA = sp.GIABAN,
                                 SOLUONG = cthd.SOLUONG,
                                 THANHTIEN = sp.GIABAN * cthd.SOLUONG
                             };
                return hoadon.ToList();
            }
        }

        //Phương thức trả về ReportCHITIETHOADON
        public List<ReportCHITIETHOADON> GetReportCTHD(string mahoadon)
        {
            using (Model1 context = new Model1())
            {
                var hoadon = from cthd in context.CHITIETHOADON
                             join hd in context.HOADON on cthd.MAHD equals hd.MAHD
                             join sp in context.SANPHAM on cthd.MASP equals sp.MASP
                             join dm in context.DANHMUC on sp.MADM equals dm.MADM
                             where cthd.MAHD == mahoadon
                             select new ReportCHITIETHOADON
                             {
                                 MASP = cthd.MASP,
                                 TENSP = sp.TENSP,
                                 DVT = dm.TENDM,
                                 DONGIA = sp.GIABAN,
                                 SOLUONG = cthd.SOLUONG,
                                 THANHTIEN = sp.GIABAN * cthd.SOLUONG
                             };
                return hoadon.ToList();
            }
        }

        public string GetNgayTao(string mahoadon)
        {
            using (Model1 context = new Model1())
            {
                // Lấy giá trị DateTime? từ cơ sở dữ liệu trước
                var ngayTao = (from hd in context.HOADON
                               where hd.MAHD == mahoadon
                               select hd.NGAYLAP).FirstOrDefault();

                // Kiểm tra nếu ngayTao có giá trị, sau đó chuyển sang chuỗi với định dạng
                return ngayTao.HasValue ? ngayTao.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }


        public string GetTongTriGia(string mahoadon)
        {
            using (Model1 context = new Model1())
            {
                var tongTriGia = (from hd in context.HOADON
                                  where hd.MAHD == mahoadon
                                  select hd.THANHTIEN.ToString()).FirstOrDefault();
                return tongTriGia;
            }
        }

        public string GetMaNV(string mahoadon)
        {
            using (Model1 context = new Model1())
            {
                var maNV = (from hd in context.HOADON
                            where hd.MAHD == mahoadon
                            select hd.MANV.ToString()).FirstOrDefault();
                return maNV;
            }
        }

        public string GetMaKH(string mahoadon)
        {
            using (Model1 context = new Model1())
            {
                var maKH = (from hd in context.HOADON
                            where hd.MAHD == mahoadon
                            select hd.MAKH.ToString()).FirstOrDefault();
                return maKH;
            }
        }

    }




}
