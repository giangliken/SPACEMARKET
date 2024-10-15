using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DanhMucService
    {
        public List<DANHMUC> GetAll()
        {
            using (Model1 context = new Model1())
            {
                return context.DANHMUC.ToList();
            }
        }

        public string GenerateNewCategoryCode()
        {
            using (Model1 context = new Model1())
            {
                // Lấy tất cả mã danh mục
                var existingCodes = context.DANHMUC.Select(dm => dm.MADM).ToList();

                // Tạo mã mới DMxxx
                if (existingCodes.Count == 0)
                {
                    return "DM001"; // Nếu không có danh mục nào, tạo mã đầu tiên
                }

                // Tìm mã lớn nhất và tăng lên 1
                var lastCode = existingCodes.OrderBy(code => code).Last();
                int newCodeNumber = int.Parse(lastCode.Substring(2)) + 1; // Lấy số sau "DM" và tăng lên 1

                return $"DM{newCodeNumber:D3}"; // Trả về mã mới với định dạng DMxxx
            }
        }

        //Thêm danh mục
        public string AddCategory(string tenDM)
        {
            using (Model1 context = new Model1())
            {
                // Tạo đối tượng mới
                var newCategory = new DANHMUC
                {
                    MADM = GenerateNewCategoryCode(), // Tạo mã mới
                    TENDM = tenDM
                };

                // Thêm vào cơ sở dữ liệu
                context.DANHMUC.Add(newCategory);
                context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu

                return $"Đã thêm danh mục mới với mã: {newCategory.MADM}";
            }
        }

        //Cập nhật danh mục
        public string UpdateCategory(string maDanhMuc, string tenDanhMuc)
        {
            using (Model1 context = new Model1())
            {
                // Tìm danh mục dựa trên MADM
                var category = context.DANHMUC.SingleOrDefault(dm => dm.MADM == maDanhMuc);
                if (category == null)
                {
                    return "Danh mục không tồn tại!";
                }

                // Cập nhật thông tin
                category.TENDM = tenDanhMuc;

                // Lưu thay đổi vào cơ sở dữ liệu
                context.SaveChanges();

                return "Cập nhật danh mục thành công!";
            }
        }

        //Xóa danh mục
        public string DeleteCategory(string maDanhMuc)
        {
            using (Model1 context = new Model1())
            {
                var category = context.DANHMUC.SingleOrDefault(dm => dm.MADM == maDanhMuc);
                if (category == null)
                {
                    return "Danh mục không tồn tại!";
                }

                context.DANHMUC.Remove(category); // Xóa danh mục
                context.SaveChanges(); // Lưu thay đổi
                return "Xóa danh mục thành công!";
            }
        }

        //Tìm kiếm theo tên danh mục
        public List<DANHMUC> SearchByName(string tenDanhMuc)
        {
            using (Model1 context = new Model1())
            {
                // Sử dụng ToLower để tìm kiếm không phân biệt chữ hoa chữ thường
                return context.DANHMUC
                    .Where(dm => dm.TENDM.ToLower().Contains(tenDanhMuc.ToLower()))
                    .ToList();
            }
        }
    }
}



