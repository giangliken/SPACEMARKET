using DAL.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StaffService
    {
        Model1 context = new Model1();
        public StaffService() { }

        //Hàm lấy danh sách Nhân viên từ database
        public List<NHANVIEN> GetAll()
        {
            using (var context = new Model1())
            {
                return context.NHANVIEN.ToList(); // Đảm bảo dữ liệu mới nhất được lấy từ cơ sở dữ liệu
            }
        }


        //Hàm tìm kiếm nhân viên theo Mã NV, Họ tên, CCCD
        public List<NHANVIEN> SearchStaff(string maNV, string tenNV, string cccd)
        {
            using (Model1 context = new Model1())
            {
                var result = context.NHANVIEN.ToList();

                // Tìm kiếm theo mã nhân viên
                if (!string.IsNullOrEmpty(maNV))
                {
                    result = result.Where(x => x.MANV.ToLower().Contains(maNV.ToLower())).ToList();
                }

                // Tìm kiếm theo tên nhân viên
                if (!string.IsNullOrEmpty(tenNV))
                {
                    result = result.Where(x => x.TENNV.ToLower().Contains(tenNV.ToLower())).ToList();
                }

                // Tìm kiếm theo CCCD
                if (!string.IsNullOrEmpty(cccd))
                {
                    result = result.Where(x => x.CCCD.ToLower().Contains(cccd.ToLower())).ToList();
                }

                return result;
            }
        }

        //Hàm thêm nhân viên mới
        public string AddStaff(string tennv, string cv, string sdt, string email, string cccd, DateTime ngaysinh)
        {
            using (Model1 context = new Model1())
            {
                // Kiểm tra Email và SDT đã có trong database
                var emailExist = context.NHANVIEN.Any(x => x.EMAILNV == email);
                var sdtExist = context.NHANVIEN.Any(x => x.SDTNV == sdt);

                if (emailExist)
                {
                    return "Email đã có trong database!";
                }

                if (sdtExist)
                {
                    return "Số điện thoại đã có trong database!";
                }

                // Tạo mã nhân viên mới
                string manv = "SPACE0407";
                var maxManv = context.NHANVIEN.Max(x => x.MANV);
                if (maxManv != null)
                {
                    manv = maxManv.Substring(0, 8) + (int.Parse(maxManv.Substring(8)) + 1).ToString("D2");
                }

                // Tạo tên đăng nhập mới
                string username = manv;

                // Tạo mật khẩu mới
                string password = GeneratePassword(tennv); // Tạo một phương thức GeneratePassword riêng

                // Tạo mới một đối tượng NHANVIEN
                NHANVIEN nhanVien = new NHANVIEN
                {
                    MANV = manv,
                    TENNV = tennv,
                    CV = cv,
                    EMAILNV = email,
                    SDTNV = sdt,
                    CCCD = cccd, // Thêm CCCD vào nhanVien
                    NGAYSINH = ngaysinh, // Thêm ngày sinh
                    USERNAME = username,
                    PASSWORD = password
                };

                // Thêm nhân viên mới vào bảng NHANVIEN
                context.NHANVIEN.Add(nhanVien);
                context.SaveChanges();

                return "Thêm nhân viên mới thành công!";
            }
        }

        // Hàm tạo mật khẩu cho nhân viên
        private string GeneratePassword(string fullName)
        {
            // Loại bỏ dấu từ tên
            string fullNameWithoutDiacritics = RemoveDiacritics(fullName);

            string[] hoTen = fullNameWithoutDiacritics.Split(' ');
            string password;

            // Kiểm tra độ dài của tên sau khi loại bỏ dấu
            if (hoTen.Length > 1)
            {
                // Tạo mật khẩu từ chữ cái đầu tiên của họ, chữ cái đầu của tên đệm (nếu có), và phần cuối cùng của tên
                password = (hoTen[0].Substring(0, 1) + hoTen[1].Substring(0, 1) + hoTen[hoTen.Length - 1]).ToLower();
            }
            else
            {
                // Nếu không có tên đệm, lấy chữ cái đầu của họ và tên
                password = (hoTen[0].Substring(0, 1) + hoTen[0]).ToLower();
            }

            return password;
        }

        // Phương thức loại bỏ dấu
        private string RemoveDiacritics(string text)
        {
            // Normalize văn bản để loại bỏ dấu
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            // Duyệt qua từng ký tự và loại bỏ những ký tự thuộc loại NonSpacingMark (dấu)
            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            // Trả về chuỗi không có dấu
            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        //Hàm sửa thông tin cho nhân viên
        public string UpdateEmployee(string manv, string tennv, string cv, string sdt, string email, string cccd, DateTime ngaysinh)
        {
            // Tìm nhân viên cần sửa
            NHANVIEN nhanVien = context.NHANVIEN.FirstOrDefault(x => x.MANV == manv);
            if (nhanVien == null)
            {
                return "Nhân viên không tồn tại!";
            }

            // Kiểm tra email hoặc số điện thoại có trùng với nhân viên khác
            bool emailExist = context.NHANVIEN.Any(x => x.EMAILNV == email && x.MANV != manv);
            bool sdtExist = context.NHANVIEN.Any(x => x.SDTNV == sdt && x.MANV != manv);

            if (emailExist || sdtExist)
            {
                return "Email hoặc số điện thoại đã tồn tại. Có phải bạn muốn sửa thông tin của nhân viên có mã này không?";
            }

            // Cập nhật thông tin nhân viên
            nhanVien.TENNV = tennv;
            nhanVien.CV = cv;
            nhanVien.SDTNV = sdt;
            nhanVien.EMAILNV = email;
            nhanVien.CCCD = cccd;
            nhanVien.NGAYSINH = ngaysinh;

            context.SaveChanges();

            return "Cập nhật nhân viên thành công!";
        }

        //Xóa nhân viên
        public string DeleteEmployee(string manv)
        {
            // Tìm nhân viên cần xóa
            NHANVIEN nhanVien = context.NHANVIEN.FirstOrDefault(x => x.MANV == manv);
            if (nhanVien == null)
            {
                return "Nhân viên không tồn tại!";
            }

            // Xóa nhân viên khỏi cơ sở dữ liệu
            context.NHANVIEN.Remove(nhanVien);
            context.SaveChanges();

            return "Xóa nhân viên thành công!";
        }

        // Phương thức sửa thông tin tài khoản
        public string UpdateAccount(string username, string newPassword)
        {
            using (var context = new Model1())
            {
                // Tìm kiếm nhân viên cần sửa
                NHANVIEN nhanVien = context.NHANVIEN.FirstOrDefault(x => x.USERNAME == username);

                // Nếu nhân viên không tồn tại, trả về thông báo lỗi
                if (nhanVien == null)
                {
                    return "Nhân viên không tồn tại!";
                }

                // Cập nhật thông tin tài khoản
                nhanVien.PASSWORD = newPassword;

                // Lưu thay đổi vào database
                context.Entry(nhanVien).State = EntityState.Modified;
                context.SaveChanges();

                return "Sửa thông tin tài khoản thành công!";
            }
        }

        //Xóa tài khoản nhân viên dựa vào username
        public string DeleteAccount(string username)
        {
            using (var context = new Model1())
            {
                var accountToDelete = context.NHANVIEN.SingleOrDefault(a => a.USERNAME == username);
                if (accountToDelete == null)
                {
                    return "Tài khoản không tồn tại!";
                }

                context.NHANVIEN.Remove(accountToDelete);
                context.SaveChanges();
                return "Xóa tài khoản thành công!";
            }
        }

    }
}
