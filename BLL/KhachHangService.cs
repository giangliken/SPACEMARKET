using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; // Thêm dòng này ở đầu file


namespace BLL
{
    public class KhachHangService
    {
        public List<KHACHHANGS> GetAll()
        {
            using (Model1 context = new Model1())
            {
                var khachhang = from kh in context.KHACHHANG
                                select new KHACHHANGS
                                {
                                    MAKH = kh.MAKH,
                                    TENKH = kh.TENKH,
                                    NGAYSINH = kh.NGAYSINH,
                                    CCCD = kh.CCCD,
                                    DIACHI = kh.DIACHI,
                                    SDTKH = kh.SDTKH,
                                    EMAILKH = kh.EMAILKH
                                };
                return khachhang.ToList();
            }

        }

        // Phương thức Thêm
        public void Add(KHACHHANGS newKhachHang)
        {
            using (Model1 context = new Model1())
            {
                var khachHang = new KHACHHANG
                {
                    MAKH = newKhachHang.MAKH,
                    TENKH = newKhachHang.TENKH,
                    NGAYSINH = newKhachHang.NGAYSINH,
                    CCCD = newKhachHang.CCCD,
                    DIACHI = newKhachHang.DIACHI,
                    SDTKH = newKhachHang.SDTKH,
                    EMAILKH = newKhachHang.EMAILKH
                };

                // Thêm khách hàng vào cơ sở dữ liệu
                context.KHACHHANG.Add(khachHang);
                context.SaveChanges();

                // Tạo thẻ thành viên cho khách hàng vừa thêm
                var theThanhVien = new THETHANHVIEN
                {
                    MATHE = GenerateMemberCardNumber(), // Gọi hàm tạo số thẻ
                    NGAYCAP = DateTime.Now,
                    HANSUDUNG = DateTime.Now.AddYears(1), // Ví dụ: thẻ có hiệu lực 1 năm
                    DIEMTICHLUY = 0, // Khởi tạo điểm tích lũy
                    BACTHE = "Mới", // Ví dụ: Trạng thái thẻ
                    MAKH = khachHang.MAKH // Liên kết thẻ với khách hàng
                };

                // Thêm thẻ thành viên vào cơ sở dữ liệu
                context.THETHANHVIEN.Add(theThanhVien);
                context.SaveChanges();
            }
        }


        // Phương thức Sửa
        public void Update(KHACHHANGS updatedKhachHang)
        {
            using (Model1 context = new Model1())
            {
                var khachHang = context.KHACHHANG.Find(updatedKhachHang.MAKH);
                if (khachHang != null)
                {
                    // Cập nhật thông tin khách hàng
                    khachHang.TENKH = updatedKhachHang.TENKH;
                    khachHang.NGAYSINH = updatedKhachHang.NGAYSINH;
                    khachHang.CCCD = updatedKhachHang.CCCD;
                    khachHang.DIACHI = updatedKhachHang.DIACHI;
                    khachHang.SDTKH = updatedKhachHang.SDTKH;
                    khachHang.EMAILKH = updatedKhachHang.EMAILKH;

                    // Cập nhật thông tin thẻ thành viên (nếu cần)
                    var theThanhVien = context.THETHANHVIEN.FirstOrDefault(t => t.MAKH == khachHang.MAKH);
                    if (theThanhVien != null)
                    {
                        // Nếu thẻ thành viên đã tồn tại, có thể cập nhật thông tin thẻ nếu cần
                        // Ví dụ: bạn có thể cập nhật trạng thái thẻ
                        theThanhVien.BACTHE = "Cập nhật"; // Ví dụ
                        context.Entry(theThanhVien).State = EntityState.Modified;
                    }
                    else
                    {
                        // Nếu không có thẻ thành viên, có thể tạo mới thẻ thành viên
                        theThanhVien = new THETHANHVIEN
                        {
                            MATHE = GenerateMemberCardNumber(),
                            NGAYCAP = DateTime.Now,
                            HANSUDUNG = DateTime.Now.AddYears(1),
                            DIEMTICHLUY = 0,
                            BACTHE = "Mới",
                            MAKH = khachHang.MAKH
                        };
                        context.THETHANHVIEN.Add(theThanhVien);
                    }

                    context.SaveChanges();
                }
            }
        }

        // Phương thức Xóa
        public void Delete(string maKhachHang)
        {
            using (Model1 context = new Model1())
            {
                var khachHang = context.KHACHHANG.Find(maKhachHang);
                if (khachHang != null)
                {
                    // Xóa thẻ thành viên liên quan
                    var theThanhVien = context.THETHANHVIEN.FirstOrDefault(t => t.MAKH == maKhachHang);
                    if (theThanhVien != null)
                    {
                        context.THETHANHVIEN.Remove(theThanhVien);
                    }

                    // Xóa khách hàng
                    context.KHACHHANG.Remove(khachHang);
                    context.SaveChanges();
                }
            }
        }

        //Phương thức tạo mã thẻ thành viên
        private string GenerateMemberCardNumber()
        {
            using (Model1 context = new Model1())
            {
                // Lấy năm, tháng, ngày hiện tại
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString("D2"); // Đảm bảo 2 chữ số
                string day = DateTime.Now.Day.ToString("D2"); // Đảm bảo 2 chữ số

                // Tạo số thứ tự tăng dần
                int sequenceNumber = context.THETHANHVIEN.Count(t => t.MATHE.StartsWith(year + month + day)) + 1;

                // Đảm bảo số thứ tự có 4 chữ số
                string formattedSequence = sequenceNumber.ToString("D4");

                return $"{year}{month}{day}{formattedSequence}";
            }
        }

        public string GenerateCustomerID()
        {
            using (Model1 context = new Model1())
            {
                // Lấy năm và tháng hiện tại
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString("D2"); // Đảm bảo tháng có 2 chữ số

                // Lấy tất cả mã khách hàng
                var existingIds = context.KHACHHANG.Select(kh => kh.MAKH).ToList();

                // Tạo danh sách số thứ tự
                int maxSequenceNumber = 0;
                foreach (var id in existingIds)
                {
                    // Kiểm tra nếu mã bắt đầu bằng "KH" + năm + tháng
                    if (id.StartsWith($"KH{year}{month}"))
                    {
                        // Lấy phần STT từ mã khách hàng
                        string sequencePart = id.Substring(6); // Bỏ qua "KH" + "năm" + "tháng"
                        if (int.TryParse(sequencePart, out int sequenceNumber))
                        {
                            maxSequenceNumber = Math.Max(maxSequenceNumber, sequenceNumber);
                        }
                    }
                }

                // Tạo mã mới
                int newSequenceNumber = maxSequenceNumber + 1;

                // Đảm bảo số thứ tự có 4 chữ số
                string formattedSequence = newSequenceNumber.ToString("D4");

                string newCustomerID = $"KH{year}{month}{formattedSequence}";

                return newCustomerID;
            }
        }




    }

    public class KHACHHANGS
    {
        public string MAKH { get; set; }
        public string TENKH { get; set; }
        public DateTime NGAYSINH { get; set; }
        public string CCCD { get; set; }  
        public string DIACHI { get; set; }
        public string SDTKH { get; set; }
        public string EMAILKH { get; set; }

    }

}
