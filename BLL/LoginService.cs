using DAL.Database;
using System;
using System.Linq;

namespace BLL
{
    public class LoginService
    {
        public NhanVien KiemTraDangNhap(string username, string password)
        {
            try
            {
                using (Model1 context = new Model1())
                {
                    // Tìm tài khoản theo username
                    var taiKhoan = context.NHANVIEN.FirstOrDefault(x => x.USERNAME == username);

                    // Kiểm tra nếu tài khoản tồn tại và mật khẩu trùng khớp
                    if (taiKhoan != null && taiKhoan.PASSWORD == password)
                    {
                        // Trả về đối tượng NhanVien với thông tin cần thiết
                        return new NhanVien
                        {
                            Id = taiKhoan.MANV,
                            Fullname = taiKhoan.TENNV,
                            ChucVu = taiKhoan.CV // Giả sử CV là trường chức vụ trong NHANVIEN
                        };
                    }
                }
                return null; // Đăng nhập thất bại
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra đăng nhập: " + ex.Message);
            }
        }
    }

    public class NhanVien
    {
        public string Id { get; set; }
        public string Fullname { get; set; }
        public string ChucVu { get; set; }
    }
}
