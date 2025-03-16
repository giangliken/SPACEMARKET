using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class KhoHangService
    {
        //Lấy danh sách kho hàng hiện có trên database
        public List<KHOHANGS> GetAll()
        {
            using(Model1 context = new Model1())
            {
                var khohang = from kh in context.KHOHANG
                              select new KHOHANGS
                              {
                                  MAKHO = kh.MAKHO,
                                  TENKHO = kh.TENKHO,
                                  DIACHIKHO = kh.DIACHIKHO,
                              };
                return khohang.ToList();
            }
        }

        //Thêm kho hàng mới
        public bool AddKhoHang(KHOHANGS khoHang)
        {
            using (Model1 context = new Model1())
            {
                try
                {
                    var newKhoHang = new KHOHANG
                    {
                        MAKHO = khoHang.MAKHO,
                        TENKHO = khoHang.TENKHO,
                        DIACHIKHO = khoHang.DIACHIKHO
                    };

                    context.KHOHANG.Add(newKhoHang);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    // Log exception nếu cần
                    return false;
                }
            }
        }

        //Cập nhật thông tin cho kho hàng
        public bool UpdateKhoHang(KHOHANGS khoHang)
        {
            using (Model1 context = new Model1())
            {
                try
                {
                    var existingKhoHang = context.KHOHANG.FirstOrDefault(kh => kh.MAKHO == khoHang.MAKHO);
                    if (existingKhoHang != null)
                    {
                        existingKhoHang.TENKHO = khoHang.TENKHO;
                        existingKhoHang.DIACHIKHO = khoHang.DIACHIKHO;

                        context.SaveChanges();
                        return true;
                    }
                    return false; // Không tìm thấy kho hàng
                }
                catch (Exception ex)
                {
                    // Log exception nếu cần
                    return false;
                }
            }
        }


        //Xóa kho hàng khỏi database
        public bool DeleteKhoHang(string maKho)
        {
            using (Model1 context = new Model1())
            {
                try
                {
                    var existingKhoHang = context.KHOHANG.FirstOrDefault(kh => kh.MAKHO == maKho);
                    if (existingKhoHang != null)
                    {
                        context.KHOHANG.Remove(existingKhoHang);
                        context.SaveChanges();
                        return true;
                    }
                    return false; // Không tìm thấy kho hàng
                }
                catch (Exception ex)
                {
                    // Log exception nếu cần
                    return false;
                }
            }
        }


        //Tìm kiếm thông tin kho dựa vào MAKHO,TENKHO,DIACHIKHO
        public List<KHOHANGS> SearchKhoHang(string maKho, string tenKho, string diaChiKho)
        {
            using (Model1 context = new Model1())
            {
                var query = from kh in context.KHOHANG
                            where (string.IsNullOrEmpty(maKho) || kh.MAKHO.Contains(maKho))
                               && (string.IsNullOrEmpty(tenKho) || kh.TENKHO.Contains(tenKho))
                               && (string.IsNullOrEmpty(diaChiKho) || kh.DIACHIKHO.Contains(diaChiKho))
                            select new KHOHANGS
                            {
                                MAKHO = kh.MAKHO,
                                TENKHO = kh.TENKHO,
                                DIACHIKHO = kh.DIACHIKHO
                            };
                return query.ToList();
            }
        }

        //Tạo mã kho
        public string GenerateNewMaKho()
        {
            using (Model1 context = new Model1())
            {
                // Lấy mã kho lớn nhất trong database
                var lastKho = context.KHOHANG
                                    .OrderByDescending(kh => kh.MAKHO)
                                    .FirstOrDefault();

                // Nếu database trống, bắt đầu từ KHO0001
                if (lastKho == null)
                {
                    return "KHO0001";
                }

                // Lấy phần số từ mã kho cuối cùng, bỏ phần "KHO" và chuyển thành số nguyên
                string lastMaKho = lastKho.MAKHO.Substring(3); // Bỏ "KHO"
                int nextNumber = int.Parse(lastMaKho) + 1;

                // Tạo mã kho mới, định dạng số thành 4 chữ số
                return "KHO" + nextNumber.ToString("D4");
            }
        }

        //Lấy danh sách CHITIETKHO
        public List<NHAPKHO> LayDanhSachChiTietKhoHang()
        {
            using (Model1 context = new Model1())
            {
                var chitietkhohang = from ctkh in context.CHITIETKHOHANG
                                     join kh in context.KHOHANG on ctkh.MAKHO equals kh.MAKHO
                                     join sp in context.SANPHAM on ctkh.MASP equals sp.MASP
                                     select new NHAPKHO
                                     {
                                         TENKHONHAP = kh.TENKHO,
                                         TENSANPHAMNHAP = sp.TENSP,
                                         SOLUONGTON = ctkh.SLTON
                                     };
                return chitietkhohang.ToList();
            }
        }

        public List<XUATKHO> LayDanhSachXuatKho()
        {
            using (Model1 context = new Model1())
            {
                var query = from ct in context.CHITIETKHOHANG
                            join sp in context.SANPHAM on ct.MASP equals sp.MASP
                            join kh in context.KHOHANG on ct.MAKHO equals kh.MAKHO
                            select new XUATKHO
                            {
                                //  MAKHO = ct.MAKHO,
                                TENSP = sp.TENSP,
                                MASP = ct.MASP,
                                SOLUONGTON = ct.SLTON,
                                TENKHO = kh.TENKHO
                            };
                return query.ToList();
            }
        }

        //Lấy danh sách tên kho
        public List<KHOHANG> LayDanhSachKhoHang()
        {
            using (Model1 context = new Model1())
            {
                return context.KHOHANG.ToList();
            }
        }

        //Lấy danh sách sản phẩm
        public List<SANPHAM> LayDanhSachSanPham()
        {
            using (Model1 context = new Model1())
            {
                return context.SANPHAM.ToList();
            }
        }

        //Phương thức nhập kho
        // Phương thức nhập kho
        public bool NhapKho(string maSP, string maKho, int soLuong)
        {
            using (Model1 context = new Model1())
            {
                // Tìm kiếm chi tiết kho hàng theo mã sản phẩm và mã kho
                var chiTietKhoHang = context.CHITIETKHOHANG
                    .FirstOrDefault(ct => ct.MASP == maSP && ct.MAKHO == maKho);

                if (chiTietKhoHang != null)
                {
                    // Nếu tồn tại, cộng dồn số lượng
                    chiTietKhoHang.SLTON += soLuong;
                }
                else
                {
                    // Nếu không tồn tại, tạo mới chi tiết kho hàng
                    chiTietKhoHang = new CHITIETKHOHANG
                    {
                        MASP = maSP,
                        MAKHO = maKho,
                        SLTON = soLuong
                    };
                    context.CHITIETKHOHANG.Add(chiTietKhoHang);
                }

                // Lưu thay đổi vào cơ sở dữ liệu
                context.SaveChanges();
            }

            return true; // Trả về true nếu nhập kho thành công
        }

    }

    public class KHOHANGS
    {
        public string MAKHO { get; set; }
        public string TENKHO { get; set; }
        public string DIACHIKHO { get; set; }
    }   

    public class NHAPKHO
    {
        public string TENKHONHAP { get; set; }
        public string TENSANPHAMNHAP { get; set; }
        public int SOLUONGTON { get; set; }
    }
    public class XUATKHO
    {
        public string TENSP { get; set; }
        public string MASP { get; set; }
        public int SOLUONGTON { get; set; }
       
        public string TENKHO { get; set; } // Thêm nếu cần hiển thị tên kho
    }


}
