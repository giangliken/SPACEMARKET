using DAL.Database;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Oauth2.v2;
using Google.Apis.Oauth2.v2.Data;
using Google.Apis.Services;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Google.Apis.Util.Store;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

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
                    if (taiKhoan != null && taiKhoan.PASSWORD == Sha256Encrypt(password))
                    {
                        // Trả về đối tượng NhanVien với thông tin cần thiết
                        return new NhanVien
                        {
                            Id = taiKhoan.MANV,
                            Fullname = taiKhoan.TENNV,
                            ChucVu = taiKhoan.MAQUYENHAN // Giả sử CV là trường chức vụ trong NHANVIEN
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

        //Hàm mã hóa mật khẩu
        private string Sha256Encrypt(string text)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        //Phương thức kiểm tra thông tin của người dùng khi đăng nhập bằng Google
        public NhanVien KiemTraDangNhapGoogle(string ID, string Name, string email)
        {
            try
            {
                using (Model1 context = new Model1())
                {
                    // Tìm tài khoản theo email 
                    var taiKhoan = context.NHANVIEN.FirstOrDefault(x => x.EMAILNV == email);

                    // Kiểm tra nếu tài khoản tồn tại và mật khẩu trùng khớp
                    if (taiKhoan != null)
                    {
                        // Trả về đối tượng NhanVien với thông tin cần thiết
                        return new NhanVien
                        {
                            Id = taiKhoan.MANV,
                            Fullname = taiKhoan.TENNV,
                            ChucVu = taiKhoan.MAQUYENHAN // Giả sử CV là trường chức vụ trong NHANVIEN
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

        

        public async Task<UserInfo> LoginWithGoogleAsync()
        {
            try
            {
                // Lấy biến môi trường
                string clientId = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_ID", EnvironmentVariableTarget.Machine);
                string clientSecret = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_SECRET", EnvironmentVariableTarget.Machine);

                // Kiểm tra nếu biến môi trường bị null hoặc rỗng
                if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret))
                {
                    throw new Exception("Google Client ID hoặc Client Secret không được tìm thấy trong biến môi trường.");
                }

                var secrets = new ClientSecrets
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret
                };

                string[] scopes = { "openid", "profile", "email" };

                //string[] scopes = { "https://www.googleapis.com/auth/userinfo.profile", "https://www.googleapis.com/auth/userinfo.email" };

                // Không sử dụng FileDataStore để luôn yêu cầu đăng nhập lại
                var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    secrets,
                    scopes,
                    "user",
                    CancellationToken.None
                );

                var service = new Oauth2Service(new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "SpaceMarket"
                });

                // Lấy thông tin người dùng từ API
                var googleUserInfo = await service.Userinfo.Get().ExecuteAsync();

                // Chỉ trả về các thông tin cần thiết
                return new UserInfo
                {
                    Id = googleUserInfo.Id,
                    Name = googleUserInfo.Name,
                    Email = googleUserInfo.Email
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Google login failed: " + ex.Message);
            }
        }
    }




    public class UserInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
    public class NhanVien
    {
        public string Id { get; set; }
        public string Fullname { get; set; }
        public string ChucVu { get; set; }
    }
}
