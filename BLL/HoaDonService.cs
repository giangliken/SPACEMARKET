using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public  class HoaDonService
    {
        // Phương thức thêm chi tiết hóa đơn
        public void AddDetail(CHITIETHOADON newDetail)
        {
            using (Model1 context = new Model1())
            {
                // Kiểm tra mã sản phẩm và mã hóa đơn có tồn tại không
                var sanPham = context.SANPHAM.Find(newDetail.MASP);
                var hoaDon = context.HOADON.Find(newDetail.MAHD);

                if (sanPham == null || hoaDon == null)
                {
                    throw new Exception("Mã sản phẩm hoặc mã hóa đơn không tồn tại.");
                }

                // Thêm chi tiết hóa đơn vào cơ sở dữ liệu
                context.CHITIETHOADON.Add(newDetail);
                context.SaveChanges();
            }
        }
    }
}
