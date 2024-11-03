using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PhieuQuaTangService
    {
        public List<PQT> GetAll()
        {
            using(Model1 context = new Model1())
            {
                var phieuquatang = from pqt in context.PHIEUQUATANG
                                   select new PQT
                                   {
                                       MAPHIEU = pqt.MAPQT,
                                       PTGIAM = pqt.PTGIAMGIA.ToString(),
                                       THOIGIANBD = pqt.THOIGIANBATDAU,
                                       THOIGIANKT = pqt.THOIGIANKETTHUC,
                                       DKAPDUNG = pqt.DIEUKIENAPDUNG,
                                   };
                return phieuquatang.ToList();
            }
        }

        public string GenerateNewMaPhieu()
        {
            using (Model1 context = new Model1())
            {
                // Lấy danh sách các MAPHIEU hiện có
                var existingMaPhieu = context.PHIEUQUATANG.Select(p => p.MAPQT).ToList();

                // Tìm STT lớn nhất
                int maxSTT = existingMaPhieu
                    .Where(m => m.StartsWith("PQT")) // Lọc những mã bắt đầu bằng PQT
                    .Select(m => int.Parse(m.Substring(3))) // Lấy số thứ tự từ MAPHIEU
                    .DefaultIfEmpty(0) // Nếu không có mã nào, mặc định là 0
                    .Max();

                // Tạo mã mới
                int newSTT = maxSTT + 1; // Tăng số thứ tự
                string newMaPhieu = $"PQT{newSTT:D4}"; // Định dạng STT thành 4 chữ số

                return newMaPhieu;
            }
        }

        public bool AddPhieuQuaTang(string maHD, decimal ptGiam, string dkApDung, string mota)
        {
            using (Model1 context = new Model1())
            {
                // Tạo mã phiếu quà tặng mới
                string maPhieu = GenerateNewMaPhieu();

                // Tạo đối tượng phiếu quà tặng mới
                var phieuQuaTang = new PHIEUQUATANG
                {
                    MAPQT = maPhieu,
                    PTGIAMGIA = ptGiam, // Giả định là 10% giảm giá hoặc theo quy định
                    THOIGIANBATDAU = DateTime.Now,
                    THOIGIANKETTHUC = DateTime.Now.AddMonths(1), // Thời gian kết thúc sau 1 tháng
                    DIEUKIENAPDUNG = dkApDung,
                    MOTA = mota,
                    MAHD = maHD
                };

               
                
                    context.PHIEUQUATANG.Add(phieuQuaTang);
                    context.SaveChanges(); // Lưu thay đổi
                    return true; // Thêm thành công
                
            }
        }

        public PQT GetByMaPhieu(string maPhieu)
        {
            using (var context = new Model1())
            {
                // Truy vấn trực tiếp từ bảng PHIEUQUATANG
                var pqtEntity = context.PHIEUQUATANG.FirstOrDefault(p => p.MAPQT == maPhieu);

                // Kiểm tra nếu không tìm thấy phiếu quà tặng
                if (pqtEntity == null)
                {
                    return null;
                }

                // Chuyển đổi từ thực thể PHIEUQUATANG sang đối tượng PQT
                return new PQT
                {
                    MAPHIEU = pqtEntity.MAPQT,
                    PTGIAM = pqtEntity.PTGIAMGIA.ToString(),
                    THOIGIANBD = pqtEntity.THOIGIANBATDAU,
                    THOIGIANKT = pqtEntity.THOIGIANKETTHUC,
                    DKAPDUNG = pqtEntity.DIEUKIENAPDUNG
                };
            }
        }

        public PQT GetByMaHD(string maHD)
        {
            using (var context = new Model1())
            {
                // Truy vấn phiếu quà tặng dựa trên MAHD
                var pqtEntity = context.PHIEUQUATANG.FirstOrDefault(p => p.MAHD == maHD);

                // Kiểm tra nếu không tìm thấy phiếu quà tặng
                if (pqtEntity == null)
                {
                    return null;
                }

                // Chuyển đổi từ thực thể PHIEUQUATANG sang đối tượng PQT
                return new PQT
                {
                    MAPHIEU = pqtEntity.MAPQT,
                    PTGIAM = pqtEntity.PTGIAMGIA.ToString(),
                    THOIGIANBD = pqtEntity.THOIGIANBATDAU,
                    THOIGIANKT = pqtEntity.THOIGIANKETTHUC,
                    DKAPDUNG = pqtEntity.DIEUKIENAPDUNG
                };
            }
        }





    }

    public class PQT
    {
        public string MAPHIEU { get; set; }
        public string PTGIAM { get; set; }  
        public DateTime THOIGIANBD { get; set; }
        public DateTime THOIGIANKT { get; set; }
        public string DKAPDUNG { get; set; }

    }
}
