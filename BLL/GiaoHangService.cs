using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GiaoHangService
    {
        //Lấy danh sách các phiếu giao hàng hiện có trong database
        public List<PHIEUGIAOHANGS> GetAll()
        {
            using (Model1 context = new Model1())
            {
                var phieugiao = from pgh in context.PHIEUGIAOHANG
                                join hd in context.HOADON on pgh.MAHD equals hd.MAHD
                                select new PHIEUGIAOHANGS
                                {
                                    MAPGH = pgh.MAPGH,
                                    MADH = pgh.MAHD,
                                    NGAYDUKIENGH = pgh.NGAYDUKIENGH,
                                    DIACHIGIAO = pgh.DIACHIGIAOHANG,
                                    SDTNGUOINHANHANG = pgh.SDTNGUOINHANHANG,
                                    MOTA = pgh.MOTA
                                };
                return phieugiao.ToList();

            }
        }

        // Phương thức tự động tạo mã phiếu giao hàng
        public string GenerateMaPGH(string maHD)
        {
            return $"PGH{maHD}";
        }

        // Thêm phiếu giao hàng
        public bool ThemPhieuGiaoHang(PHIEUGIAOHANG phieuGiaoHang)
        {
            if (!CheckHoaDonExists(phieuGiaoHang.MAHD))
            {
                Console.WriteLine("Mã hóa đơn không tồn tại.");
                return false; // Hoặc có thể ném ra ngoại lệ tùy theo cách bạn muốn xử lý lỗi
            }

            using (Model1 context = new Model1())
            {
                try
                {
                    // Tạo mã phiếu giao hàng tự động theo MAHD
                    phieuGiaoHang.MAPGH = GenerateMaPGH(phieuGiaoHang.MAHD);
                    context.PHIEUGIAOHANG.Add(phieuGiaoHang);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }


        // Sửa phiếu giao hàng
        public bool SuaPhieuGiaoHang(PHIEUGIAOHANG phieuGiaoHang)
        {
            using (Model1 context = new Model1())
            {
                try
                {
                    var existingPhieuGiaoHang = context.PHIEUGIAOHANG.Find(phieuGiaoHang.MAPGH);
                    if (existingPhieuGiaoHang == null) return false;

                    existingPhieuGiaoHang.NGAYDUKIENGH = phieuGiaoHang.NGAYDUKIENGH;
                    existingPhieuGiaoHang.DIACHIGIAOHANG = phieuGiaoHang.DIACHIGIAOHANG;
                    existingPhieuGiaoHang.SDTNGUOINHANHANG = phieuGiaoHang.SDTNGUOINHANHANG;
                    existingPhieuGiaoHang.MOTA = phieuGiaoHang.MOTA;
                    existingPhieuGiaoHang.MAHD = phieuGiaoHang.MAHD;

                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        // Xóa phiếu giao hàng
        public bool XoaPhieuGiaoHang(string maPgh)
        {
            using (Model1 context = new Model1())
            {
                try
                {
                    var phieuGiaoHang = context.PHIEUGIAOHANG.Find(maPgh);
                    if (phieuGiaoHang == null) return false;

                    context.PHIEUGIAOHANG.Remove(phieuGiaoHang);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public bool CheckHoaDonExists(string maHD)
        {
            using (Model1 context = new Model1())
            {
                return context.HOADON.Any(hd => hd.MAHD == maHD);
            }
        }

        public PHIEUGIAOHANG GetPhieuGiaoHangByMa(string maPhieu)
        {
            using (var context = new Model1())
            {
                return context.PHIEUGIAOHANG.FirstOrDefault(p => p.MAPGH == maPhieu);
            }
        }

    }
    public class PHIEUGIAOHANGS
    {
        public string MAPGH { get; set; }
        public string MADH { get; set; }
        public DateTime NGAYDUKIENGH { get; set; }
        public string DIACHIGIAO { get; set; }
        public string SDTNGUOINHANHANG { get; set; }
        public string MOTA { get; set; }
    }

}
