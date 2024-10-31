using DAL.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NhaCungCapService
    {
        //Phương thức trả về danh sách nhà cung cấp từ database
        public List<NCC> GetAll()
        {
            using(Model1 context = new Model1())
            {
                var nhacungcap = from ncc in context.NHACUNGCAP
                                 select new NCC
                                 {
                                     MANCC = ncc.MANCC,
                                     TENNCC = ncc.TENNCC,
                                     DIACHINCC = ncc.DIACHINCC,
                                     SDTNCC = ncc.SDTNCC,
                                     EMAILNCC = ncc.EMAILNCC
                                 };
                return nhacungcap.ToList();
            }
        }

        // Bỏ dòng này khỏi phương thức Add để mã không bị tạo lại trước khi thêm
        public bool Add(NCC ncc)
        {
            using (Model1 context = new Model1())
            {
                var newNcc = new NHACUNGCAP
                {
                    MANCC = ncc.MANCC,  // MANCC sẽ được truyền từ lớp Form
                    TENNCC = ncc.TENNCC,
                    DIACHINCC = ncc.DIACHINCC,
                    SDTNCC = ncc.SDTNCC,
                    EMAILNCC = ncc.EMAILNCC
                };

                context.NHACUNGCAP.Add(newNcc);
                return context.SaveChanges() > 0;
            }
        }


        // Phương thức cập nhật thông tin nhà cung cấp
        public bool Update(NCC ncc)
        {
            using (Model1 context = new Model1())
            {
                var existingNcc = context.NHACUNGCAP.Find(ncc.MANCC);
                if (existingNcc == null) return false;

                existingNcc.TENNCC = ncc.TENNCC;
                existingNcc.DIACHINCC = ncc.DIACHINCC;
                existingNcc.SDTNCC = ncc.SDTNCC;
                existingNcc.EMAILNCC = ncc.EMAILNCC;

                return context.SaveChanges() > 0;
            }
        }

        // Phương thức xóa nhà cung cấp
        public bool Delete(string mancc)
        {
            using (Model1 context = new Model1())
            {
                var ncc = context.NHACUNGCAP.Find(mancc);
                if (ncc == null) return false;

                context.NHACUNGCAP.Remove(ncc);
                return context.SaveChanges() > 0;
            }
        }

        // Phương thức tạo mã NCC mới
        public string GenerateNewMANCC()
        {
            using (Model1 context = new Model1())
            {
                // Lấy tất cả mã NCC từ cơ sở dữ liệu
                var existingCodes = context.NHACUNGCAP.Select(ncc => ncc.MANCC).ToList();

                // Nếu chưa có mã nào, trả về mã NCC đầu tiên
                if (existingCodes.Count == 0)
                {
                    return "NCC0001"; // Mã đầu tiên
                }

                // Tìm mã NCC lớn nhất hiện tại và tăng lên 1
                var lastCode = existingCodes.OrderBy(code => code).Last();
                int newCodeNumber = int.Parse(lastCode.Substring(3)) + 1; // Lấy phần số sau "NCC" và tăng lên 1

                // Trả về mã mới với định dạng NCCxxxx
                return $"NCC{newCodeNumber:D4}";
            }
        }

        // Phương thức tìm kiếm nhà cung cấp theo tên, mã, địa chỉ hoặc số điện thoại
        public List<NCC> Search(string keyword)
        {
            using (Model1 context = new Model1())
            {
                // Chuyển đổi keyword về dạng không phân biệt chữ hoa chữ thường
                keyword = keyword.ToLower();

                var results = context.NHACUNGCAP
                    .Where(ncc => ncc.MANCC.ToLower().Contains(keyword) || // Tìm theo mã NCC
                                  ncc.TENNCC.ToLower().Contains(keyword) || // Tìm theo tên NCC
                                  ncc.DIACHINCC.ToLower().Contains(keyword) || // Tìm theo địa chỉ NCC
                                  ncc.SDTNCC.Contains(keyword)) // Tìm theo SDT
                    .Select(ncc => new NCC
                    {
                        MANCC = ncc.MANCC,
                        TENNCC = ncc.TENNCC,
                        DIACHINCC = ncc.DIACHINCC,
                        SDTNCC = ncc.SDTNCC,
                        EMAILNCC = ncc.EMAILNCC
                    }).ToList();

                return results;
            }
        }



    }

    public class NCC
    {
        public string MANCC { get; set; }
        public string TENNCC { get; set; }  
        public string DIACHINCC { get; set; }
        public string SDTNCC { get; set; }
        public string EMAILNCC { get; set; }
    }
}
