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
        //Phương thức trả về danh sách khách hàng
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

                string newMathe;
                do
                {
                    newMathe = GenerateMemberCardNumber(); // Gọi hàm tạo số thẻ
                } while (context.THETHANHVIEN.Any(t => t.MATHE == newMathe)); // Kiểm tra xem mã thẻ đã tồn tại chưa

                // Tạo thẻ thành viên cho khách hàng vừa thêm
                var theThanhVien = new THETHANHVIEN
                {
                    MATHE = newMathe,
                    NGAYCAP = DateTime.Now,
                    HANSUDUNG = DateTime.Now.AddYears(1),
                    DIEMTICHLUY = 0,
                    BACTHE = "Đồng",
                    MAKH = khachHang.MAKH
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
                        // Không cập nhật ngày cấp và hạn sử dụng
                        // Đánh giá hạng thẻ dựa trên điểm tích lũy
                        if (theThanhVien.DIEMTICHLUY < 10000)
                        {
                            theThanhVien.BACTHE = "Đồng";
                        }
                        else if (theThanhVien.DIEMTICHLUY < 50000)
                        {
                            theThanhVien.BACTHE = "Bạc";
                        }
                        else
                        {
                            theThanhVien.BACTHE = "Vàng";
                        }

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
                int maxSequenceNumber = 1; // Bắt đầu từ 0001
                foreach (var id in existingIds)
                {
                    // Kiểm tra nếu mã bắt đầu bằng "KH" + năm + tháng
                    if (id.StartsWith($"KH{year}{month}"))
                    {
                        // Lấy phần STT từ mã khách hàng
                        string sequencePart = id.Substring(10); // Bỏ qua "KH" + "năm" + "tháng"
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

        //Phương thức cập nhật điểm khách hàng
        public void UpdateLoyaltyPoints(string maKhachHang, int pointsChange)
        {
            using (Model1 context = new Model1())
            {
                var theThanhVien = context.THETHANHVIEN.FirstOrDefault(t => t.MAKH == maKhachHang);
                if (theThanhVien != null)
                {
                    // Cập nhật điểm tích lũy
                    theThanhVien.DIEMTICHLUY += pointsChange;

                    // Cập nhật hạng thẻ dựa trên điểm tích lũy
                    if (theThanhVien.DIEMTICHLUY < 10000)
                    {
                        theThanhVien.BACTHE = "Đồng";
                    }
                    else if (theThanhVien.DIEMTICHLUY < 50000)
                    {
                        theThanhVien.BACTHE = "Bạc";
                    }
                    else
                    {
                        theThanhVien.BACTHE = "Vàng";
                    }

                    context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                }
            }
        }

        public List<KHACHHANGS> SearchCustomers(string maKhachHang, string tenKhachHang)
        {
            using (Model1 context = new Model1())
            {
                var query = context.KHACHHANG.AsQueryable();

                // Kiểm tra mã khách hàng
                if (!string.IsNullOrEmpty(maKhachHang))
                {
                    query = query.Where(kh => kh.MAKH.Contains(maKhachHang));
                }

                // Kiểm tra tên khách hàng
                if (!string.IsNullOrEmpty(tenKhachHang))
                {
                    query = query.Where(kh => kh.TENKH.Contains(tenKhachHang));
                }

                // Nếu không có điều kiện tìm kiếm nào, trả về danh sách rỗng
                if (string.IsNullOrEmpty(maKhachHang) && string.IsNullOrEmpty(tenKhachHang))
                {
                    return new List<KHACHHANGS>();
                }

                return query.Select(kh => new KHACHHANGS
                {
                    MAKH = kh.MAKH,
                    TENKH = kh.TENKH,
                    NGAYSINH = kh.NGAYSINH,
                    CCCD = kh.CCCD,
                    DIACHI = kh.DIACHI,
                    SDTKH = kh.SDTKH,
                    EMAILKH = kh.EMAILKH
                }).ToList();
            }
        }



        //Phương thức trả về thông tin thẻ khách hàng khi truyền vào mã KH
        public (string MATHE, string TENKH, string SDTKH, decimal DIEMTICHLUY) GetCustomerDetails(string maKhachHang)
        {
            using (Model1 context = new Model1())
            {
                var query = from kh in context.KHACHHANG
                            join tv in context.THETHANHVIEN on kh.MAKH equals tv.MAKH
                            where kh.MAKH == maKhachHang
                            select new
                            {
                                tv.MATHE,
                                kh.TENKH,
                                kh.SDTKH,
                                tv.DIEMTICHLUY
                            };

                var result = query.FirstOrDefault();

                if (result != null)
                {
                    return (result.MATHE, result.TENKH, result.SDTKH, result.DIEMTICHLUY);
                }
                else
                {
                    return (null, null, null, 0); // Hoặc xử lý theo cách khác nếu không tìm thấy
                }
            }
        }

        // Phương thức trả về MAKH khi truyền vào MATHE
        public string GetCustomerIdByCardNumber(string maThe)
        {
            using (Model1 context = new Model1())
            {
                var customer = context.THETHANHVIEN.FirstOrDefault(tv => tv.MATHE == maThe);

                if (customer != null)
                {
                    return customer.MAKH; // Trả về MAKH tương ứng
                }
                else
                {
                    return null; // Hoặc xử lý theo cách khác nếu không tìm thấy
                }
            }
        }

        //Phương thức tìm kiếm thẻ khách hàng dựa vào mã thẻ, mã khach hang, SDT
        public List<THETHANHVIENS> TimKiemTheThanhVien(string mathe, string makh, string sdt)
        {
            using(Model1 context = new Model1())
            {
                var ketqua = from ttv in context.THETHANHVIEN
                             join kh in context.KHACHHANG on ttv.MAKH equals kh.MAKH
                             where (string.IsNullOrEmpty(mathe) || ttv.MATHE == mathe)
                               && (string.IsNullOrEmpty(makh) || kh.MAKH == makh)
                               && (string.IsNullOrEmpty(sdt) || kh.SDTKH == sdt)
                             select new THETHANHVIENS
                             {
                                 TENKH = kh.TENKH,
                                 HANGTHE = ttv.BACTHE,
                                 DIEMTICHLUY = ttv.DIEMTICHLUY.ToString(),
                             };
                return ketqua.ToList();



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

    public class THETHANHVIENS
    {
        public string TENKH { set; get; }
        public string HANGTHE { set; get; } 
        public string DIEMTICHLUY { set; get; }
    }


}
