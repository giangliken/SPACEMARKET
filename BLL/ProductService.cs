using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class ProductService
    {
        public List<SANPHAMS> GetAll()
        {
            using(Model1 context = new Model1())
            {
                var sanpham = from sp in context.SANPHAM
                              join ncc in context.NHACUNGCAP on sp.MANCC equals ncc.MANCC
                              join dm in context.DANHMUC on sp.MADM equals dm.MADM
                              select new SANPHAMS
                              {
                                  MASP = sp.MASP,
                                  TENSP = sp.TENSP,
                                  NCC = ncc.TENNCC,
                                  DM = dm.TENDM,
                                  GIA = sp.GIABAN
                              };
                return sanpham.ToList();
            }
        }

        //Lấy danh sách nhà cung cấp
        public List<NHACUNGCAP> GetNCC()
        {
            using(Model1  context = new Model1())
            {
                return context.NHACUNGCAP.ToList();
            }
            
        }
        
        //Lấy danh sách danh mục
        public List<DANHMUC> GetDM()
        {
            using(Model1 context = new Model1())
            {
                return context.DANHMUC.ToList();
            }
        }


        //Hàm thêm sản phẩm 
        public bool AddProduct(string masp, string mancc, string madm, string tensp, decimal giaban)
        {
            using (Model1 context = new Model1())
            {
                try
                {
                    var product = new SANPHAM()
                    {
                        MASP = masp,
                        MANCC = mancc,
                        MADM = madm,
                        TENSP = tensp,
                        GIABAN = giaban
                    };

                    context.SANPHAM.Add(product);
                    context.SaveChanges();
                    return true; // Thêm thành công
                }
                catch (Exception ex)
                {
                    // Ghi log lỗi nếu cần
                    Console.WriteLine(ex.Message);
                    return false; // Thêm thất bại
                }
            }
        }

        // Hàm sửa sản phẩm
        public bool UpdateProduct(string masp, string mancc, string madm, string tensp, decimal giaban)
        {
            using (Model1 context = new Model1())
            {
                try
                {
                    // Tìm sản phẩm cần sửa dựa trên MASP
                    var product = context.SANPHAM.FirstOrDefault(p => p.MASP == masp);

                    if (product == null)
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm!");
                        return false; // Không tìm thấy sản phẩm
                    }

                    // Ghi nhận lịch sử giá nếu giá có thay đổi
                    if (product.GIABAN != giaban)
                    {
                        bool recordSuccess = RecordPriceChange(masp, product.GIABAN, giaban);
                        if (!recordSuccess)
                        {
                            MessageBox.Show("Ghi lịch sử giá thất bại!"); // Thông báo lỗi
                            return false;
                        }
                    }

                   
                    // Cập nhật thông tin sản phẩm
                    product.MANCC = mancc;
                    product.MADM = madm;
                    product.TENSP = tensp;
                    product.GIABAN = giaban;
                    // Lưu thay đổi
                    context.SaveChanges();
                    return true; // Sửa thành công
                }
                catch (Exception ex)
                {
                    // Ghi log lỗi nếu cần
                    Console.WriteLine(ex.Message);
                    return false; // Sửa thất bại
                }
            }
        }

        //Hàm xóa sản phẩm
        public bool DeleteProduct(string masp)
        {
            using (Model1 context = new Model1())
            {
                try
                {
                    // Tìm sản phẩm cần xóa
                    var product = context.SANPHAM.SingleOrDefault(p => p.MASP == masp);

                    if (product != null)
                    {
                        context.SANPHAM.Remove(product);
                        context.SaveChanges();
                        return true; // Xóa thành công
                    }
                    return false; // Không tìm thấy sản phẩm
                }
                catch (Exception ex)
                {
                    // Ghi log lỗi nếu cần
                    Console.WriteLine(ex.Message);
                    return false; // Xóa thất bại
                }
            }
        }

        //Hàm tìm kiếm sản phẩm
        public List<SANPHAMS> SearchProducts(string keyword)
        {
            using (Model1 context = new Model1())
            {
                var sanpham = from sp in context.SANPHAM
                              join ncc in context.NHACUNGCAP on sp.MANCC equals ncc.MANCC
                              join dm in context.DANHMUC on sp.MADM equals dm.MADM
                              where sp.MASP.Contains(keyword) || sp.TENSP.Contains(keyword)
                              select new SANPHAMS
                              {
                                  MASP = sp.MASP,
                                  TENSP = sp.TENSP,
                                  NCC = ncc.TENNCC,
                                  DM = dm.TENDM,
                                  GIA = sp.GIABAN
                              };
                return sanpham.ToList();
            }
        }

        // Phương thức ghi nhận lịch sử giá
        public bool RecordPriceChange(string masp, decimal oldPrice, decimal newPrice)
        {
            using (Model1 context = new Model1())
            {
                try
                {
                    // Tạo một đối tượng LICHSUGIA mới
                    var priceHistory = new LICHSUGIA
                    {
                        MASP = masp,
                        GIACU = oldPrice,
                        GIAMOI = newPrice,
                        NGAYTHAYDOI = DateTime.Now // Ghi lại thời gian thay đổi
                    };

                    context.LICHSUGIA.Add(priceHistory);
                    context.SaveChanges();
                    return true; // Ghi nhận thành công
                }
                catch (Exception ex)
                {
                    // Ghi log lỗi nếu cần
                    Console.WriteLine(ex.Message);
                    return false; // Ghi nhận thất bại
                }
            }
        }
        public List<LICHSUGIAS> GetAllLichSu()
        {
            using (Model1 context = new Model1())
            {
                var lichsugia = from lg in context.LICHSUGIA
                                select new LICHSUGIAS
                                {
                                    MASP = lg.MASP,
                                    GIACU = lg.GIACU,
                                    GIAMOI = lg.GIAMOI,
                                    NGAYTHAYDOI = lg.NGAYTHAYDOI
                                };
                return lichsugia.ToList();
            }
        }

        public List<LICHSUGIAS> SearchLichSu(string keyword)
        {
            using (Model1 context = new Model1())
            {
                var lichsugia = from lg in context.LICHSUGIA
                                where lg.MASP.Contains(keyword) || lg.GIACU.ToString().Contains(keyword) || lg.GIAMOI.ToString().Contains(keyword) || lg.NGAYTHAYDOI.ToString().Contains(keyword)
                                select new LICHSUGIAS
                                {
                                    MASP = lg.MASP,
                                    GIACU = lg.GIACU,
                                    GIAMOI = lg.GIAMOI,
                                    NGAYTHAYDOI = lg.NGAYTHAYDOI
                                };
                return lichsugia.ToList();
            }
        }

        // Lấy MANCC từ TENNCC
        public string GetMaNCCByTen(string tenncc)
        {
            using (Model1 context = new Model1())
            {
                var ncc = context.NHACUNGCAP.FirstOrDefault(n => n.TENNCC == tenncc);
                return ncc?.MANCC; // Trả về null nếu không tìm thấy
            }
        }

        // Lấy MADM từ TENDM
        public string GetMaDMByTen(string tendm)
        {
            using (Model1 context = new Model1())
            {
                var dm = context.DANHMUC.FirstOrDefault(d => d.TENDM == tendm);
                return dm?.MADM; // Trả về null nếu không tìm thấy
            }
        }


    }
    public class SANPHAMS
    {
        public string MASP { get; set; }
        public string TENSP { get; set; }
        public string NCC { get; set; }
        public string DM { get; set; }
        public decimal GIA { get; set; }
    }
    public class LICHSUGIAS
    {
        public string MASP { get; set; }
        public decimal GIACU { get; set; }
        public decimal GIAMOI { get; set; }
        public DateTime NGAYTHAYDOI { get; set; }
    }


}


