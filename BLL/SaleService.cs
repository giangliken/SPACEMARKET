using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class SaleService
    {
        // Phương thức lấy mã hóa đơn
        public List<HoaDon> GetAll()
        {
            using (Model1 context = new Model1())
            {
                var hoaDon = from hoadon in context.HOADON
                             join cthd in context.CHITIETHOADON on hoadon.MAHD equals cthd.MAHD
                             join sanpham in context.SANPHAM on cthd.MASP equals sanpham.MASP
                             join danhmuc in context.DANHMUC on sanpham.MADM equals danhmuc.MADM
                             select new HoaDon
                             {
                                 MASP = cthd.MASP,
                                 TENSP = sanpham.TENSP,
                                 DVT = danhmuc.TENDM,
                                 DONGIA = sanpham.GIABAN,
                                 SOLUONG = cthd.SOLUONG,
                                 THANHTIEN = (decimal)hoadon.THANHTIEN
                             };
                return hoaDon.ToList();
            }
        }

        //Phương thức lấy sản phẩm dựa vào mã vạch
        // Phương thức lấy sản phẩm dựa vào mã vạch
        public SanPham GetProductByCode(string maVach)
        {
            using (Model1 context = new Model1())
            {
                var product = (from sanpham in context.SANPHAM
                               join danhmuc in context.DANHMUC on sanpham.MADM equals danhmuc.MADM
                               where sanpham.MASP == maVach
                               select new SanPham
                               {
                                   MASP = sanpham.MASP,
                                   TENSP = sanpham.TENSP,
                                   DVT = danhmuc.TENDM,
                                   DONGIA = sanpham.GIABAN,
                               }).FirstOrDefault();

                if (product != null)
                {
                    // Gán số lượng và thành tiền khi trả về
                    product.SOLUONG = 1; // Mặc định là 1 khi thêm mới
                    product.THANHTIEN = product.DONGIA * product.SOLUONG; // Thành tiền sẽ được tính toán ở đây
                }

                return product;
            }
        }




        // Phương thức tạo hóa đơn 
        public HOADON LuuHoaDon(string MAHD, string MANV, string MAKH, string PTTT, DateTime dateTime,decimal THANHTIEN)
        {
            using (Model1 context = new Model1())
            {
                // Tạo đối tượng HOADON với các giá trị từ tham số truyền vào
                HOADON hoaDonMoi = new HOADON
                {
                    MAHD = MAHD,
                    MANV = string.IsNullOrEmpty(MANV) ? null : MANV,
                    MAKH = string.IsNullOrEmpty(MAKH) ? null : MAKH,
                    PTTHANHTOAN = string.IsNullOrEmpty(PTTT) ? null : PTTT,
                    NGAYLAP = dateTime,
                    THANHTIEN = THANHTIEN
                };

                // Thêm đối tượng hóa đơn mới vào DbSet HOADON
                context.HOADON.Add(hoaDonMoi);

                // Lưu thay đổi vào cơ sở dữ liệu
                context.SaveChanges();

                // Trả về hóa đơn vừa được lưu
                return hoaDonMoi;
            }
        }

        public string GenerateNewInvoiceID()
        {
            // Lấy năm và tháng hiện tại
            string year = DateTime.Now.ToString("yyyy");
            string month = DateTime.Now.ToString("MM");

            // Kết hợp year và month
            string yearMonth = $"{year}{month}";

            // Lấy số thứ tự hóa đơn tiếp theo từ cơ sở dữ liệu
            int soHoaDon = GetNextInvoiceNumber();

            // Ghép năm, tháng và số thứ tự thành mã hóa đơn
            string maHoaDon = $"{yearMonth}{soHoaDon:D4}"; // D4 đảm bảo STT có 4 chữ số

            return maHoaDon;
        }

        private int GetNextInvoiceNumber()
        {
            using (Model1 context = new Model1())
            {
                // Lấy năm và tháng hiện tại để so sánh
                string currentYearMonth = DateTime.Now.ToString("yyyyMM");

                // Tính toán số lượng hóa đơn hiện có từ cơ sở dữ liệu
                int currentCount = context.HOADON
                    .Count(h => h.MAHD.StartsWith(currentYearMonth)); // Chỉ sử dụng biểu thức chuỗi đơn giản

                return currentCount > 0 ? currentCount + 1 : 1; // Nếu không có hóa đơn thì mặc định STT là 1
            }
        }



    }

    public class HoaDon
    {
        public string MASP { get; set; }
        public string TENSP { get; set; }
        public string DVT { get; set; }
        public decimal DONGIA { get; set; }
        public int SOLUONG { get; set; }
        public decimal THANHTIEN { get; set; }
    }

    public class SanPham
    {
        public string MASP { get; set; }
        public string TENSP { get; set; }
        public string DVT { get; set; }
        public decimal DONGIA { get; set; }
        public int SOLUONG { get; set; }
        public decimal THANHTIEN { get; set; }
    }

}
