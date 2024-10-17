using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using RestSharp;

using BLL;
using DAL.Database;
using System.Linq;
using System.Globalization;

namespace SpaceMarket
{
    public partial class BanHang : Form
    {
        public string MANV { get; set; }
        private readonly SaleService saleService = new SaleService();
        public Image DisplayedImage { get; set; }
        public BanHang()
        {
            InitializeComponent();
            SetupDataGridView(); // Gọi thiết lập DataGridView
        }


        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void txtTime_TextChanged(object sender, EventArgs e)
        {
           // this.txtTime.Text = string.Format(DateTime.Now.ToString("HH:mm:ss"));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.txtTime.Text = string.Format(DateTime.Now.ToString("HH:mm:ss"));
            CheckCaLamViec();
            this.txtDate.Text = string.Format(DateTime.Now.ToString("dd/MM/yyyy"));
            this.txtNhanVien.Text = MANV;
        }

        private void CheckCaLamViec()
        {
            // Lấy thời gian hiện tại
            DateTime currentTime = DateTime.Now;
            
            // Xác định ca làm việc dựa trên thời gian hiện tại
            string ca;
            if (currentTime.Hour >= 7 && currentTime.Hour < 12)
            {
                ca = "1"; // Từ 07:00 đến 12:00
            }
            else if (currentTime.Hour == 12 && currentTime.Minute >= 1 || (currentTime.Hour < 17))
            {
                ca = "2"; // Từ 12:01 đến 17:00
            }
            else if (currentTime.Hour >= 17 && currentTime.Hour < 23)
            {
                ca = "3"; // Từ 17:01 đến 23:00
            }
            else
            {
                ca = "Ngoài giờ làm"; // Nếu không thuộc bất kỳ ca nào
            }

            
            // Cập nhật giá trị vào TextBox
            txtCa.Text = ca;

            // Đưa con trỏ về cuối TextBox để người dùng không bị mất vị trí
            //txtCa.SelectionStart = txtCa.Text.Length;
            //txtCa.Text = ca;
        }


        private void txtCa_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtONhapMaVach_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu số ký tự trong txtONhapMaVach là 13
            if (txtONhapMaVach.Text.Length == 13)
            {
                // Gọi phương thức để thêm vào DataGridView
                ThemSanPhamVaoDataGrid(txtONhapMaVach.Text);

                // Xóa nội dung của TextBox sau khi thêm
                txtONhapMaVach.Clear();
            }
        }

        private void ThemSanPhamVaoDataGrid(string maVach)
        {
            dgvDanhSachSanPham.Rows.Add(maVach);
        }

        private void dataDanhSachSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSoHoaDon_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem dataDanhSachSanPham có dòng nào không
            if (dgvDanhSachSanPham.Rows.Count == 0)
            {
                // Nếu bảng trống, thông báo rằng chưa tạo số hóa đơn
                MessageBox.Show("Chưa tạo số hóa đơn. Vui lòng thêm sản phẩm trước.");
                txtSoHoaDon.Clear(); // Xóa số hóa đơn nếu chưa có sản phẩm
            }
            else if (dgvDanhSachSanPham.Rows.Count == 1)
            {
                // Nếu chỉ có 1 dòng, tạo số hóa đơn
                string soHoaDon = GenerateSoHoaDon(); // Gọi phương thức để tạo số hóa đơn
                txtSoHoaDon.Text = soHoaDon; // Gán số hóa đơn vào TextBox

                // Xóa dữ liệu trong bảng sản phẩm
                dgvDanhSachSanPham.Rows.Clear();
            }
            // Bạn có thể thêm điều kiện xử lý cho trường hợp nhiều hơn 1 dòng nếu cần
        }

        // Phương thức để tạo số hóa đơn (có thể tùy chỉnh theo logic của bạn)
        private string GenerateSoHoaDon()
        {
            // Tạo số hóa đơn theo cách mà bạn muốn
            // Ví dụ: số hóa đơn là một chuỗi ngẫu nhiên hoặc số tự tăng
            return DateTime.Now.ToString("yyyyMMddHHmmss"); // Ví dụ tạo số hóa đơn theo định dạng ngày giờ
        }

        private void txtNhanVien_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

      

        private void uiPanel5_Click(object sender, EventArgs e)
        {

        }

        private void BanHang_Load(object sender, EventArgs e)
        {
            this.txtSoHoaDon.Text = saleService.GenerateNewInvoiceID();
            // Hiển thị hình ảnh nếu có
            if (DisplayedImage != null)
            {
                pictureBox2.Image = DisplayedImage; // Giả sử bạn có pictureBox2 trên Form2
            }

            //Thiết lập tên cho các cột tương ứng
            dgvDanhSachSanPham.Columns[0].DataPropertyName = "MASP";
            dgvDanhSachSanPham.Columns[1].DataPropertyName = "TENSP";
            dgvDanhSachSanPham.Columns[2].DataPropertyName = "DVT";
            dgvDanhSachSanPham.Columns[3].DataPropertyName = "DONGIA";
            dgvDanhSachSanPham.Columns[4].DataPropertyName = "SOLUONG";
            dgvDanhSachSanPham.Columns[5].DataPropertyName = "THANHTIEN";
            //Đổ dữ liệu và datagridview
            //dgvDanhSachSanPham.DataSource = saleService.GetAll();

        }

        // Thiết lập cấu hình DataGridView
        private void SetupDataGridView()
        {
            // Xóa tất cả các cột hiện tại
            dgvDanhSachSanPham.Columns.Clear();

            // Tạo các cột
            dgvDanhSachSanPham.Columns.Add("MASP", "Mã Sản Phẩm");
            dgvDanhSachSanPham.Columns.Add("TENSP", "Tên Sản Phẩm");
            dgvDanhSachSanPham.Columns.Add("DVT", "Đơn Vị Tính");
            dgvDanhSachSanPham.Columns.Add("DONGIA", "Đơn Giá");
            dgvDanhSachSanPham.Columns.Add("SOLUONG", "Số Lượng");
            dgvDanhSachSanPham.Columns.Add("THANHTIEN", "Thành Tiền");

            // Thiết lập tên cho các cột tương ứng
            dgvDanhSachSanPham.Columns[0].DataPropertyName = "MASP";
            dgvDanhSachSanPham.Columns[1].DataPropertyName = "TENSP";
            dgvDanhSachSanPham.Columns[2].DataPropertyName = "DVT";
            dgvDanhSachSanPham.Columns[3].DataPropertyName = "DONGIA";
            dgvDanhSachSanPham.Columns[4].DataPropertyName = "SOLUONG";
            dgvDanhSachSanPham.Columns[5].DataPropertyName = "THANHTIEN";

            // Thay đổi kiểu hiển thị nếu cần (VD: định dạng tiền tệ)
            dgvDanhSachSanPham.Columns[3].DefaultCellStyle.Format = "C2"; // Định dạng tiền tệ cho đơn giá
            dgvDanhSachSanPham.Columns[5].DefaultCellStyle.Format = "C2"; // Định dạng tiền tệ cho thành tiền

            // Cho phép chỉnh sửa, xóa, thêm hàng
            dgvDanhSachSanPham.AllowUserToAddRows = false; // Ngăn không cho người dùng thêm hàng
            dgvDanhSachSanPham.ReadOnly = false; // Cho phép chỉnh sửa
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tong tien: " + TongCong);
            var apiRequest = new ApiRequest();
            apiRequest.acqId = 970418;
            apiRequest.accountNo = 6150556382;
            apiRequest.accountName = "NGUYEN NGOC THANH BA";
            apiRequest.amount = TongCong;
            apiRequest.format = "text";
            apiRequest.template = "qr_only";
            apiRequest.addInfo = "SPACEGO HD:" + txtSoHoaDon.Text; // Thêm mô tả vào đây
            var jsonRequest = JsonConvert.SerializeObject(apiRequest);
            // use restsharp for request api.
            var client = new RestClient("https://api.vietqr.io/v2/generate");
            var request = new RestRequest();

            request.Method = Method.Post;
            request.AddHeader("Accept", "application/json");

            request.AddParameter("application/json", jsonRequest, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;
            var dataResult = JsonConvert.DeserializeObject<ApiResponse>(content);


            var image = Base64ToImage(dataResult.data.qrDataURL.Replace("data:image/png;base64,", ""));
            pictureBox2.Image = image;
        }





        private void GenerateQRCode()
        {
            var apiRequest = new ApiRequest
            {
                acqId = 970423,
                accountNo = 1234,
                accountName = "NGUYEN TRUONG GIANG",
                amount = TongCong, // Lấy số tiền từ textbox
                format = "text",
                template = "qr_only",
                addInfo = "SPACEMARKET HD 0004007" // Thêm mô tả vào đây
            };

            var jsonRequest = JsonConvert.SerializeObject(apiRequest);

            var client = new RestClient("https://api.vietqr.io/v2/generate");
            var request = new RestRequest(Method.Post.ToString());
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", jsonRequest, ParameterType.RequestBody);

            // Gửi yêu cầu và nhận phản hồi
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                var content = response.Content;

                // Phân tích dữ liệu trả về
                var dataResult = JsonConvert.DeserializeObject<ApiResponse>(content);
                if (dataResult?.data?.qrDataURL != null)
                {
                    // Chuyển đổi Base64 sang hình ảnh
                    var image = Base64ToImage(dataResult.data.qrDataURL.Replace("data:image/png;base64,", ""));
                    pictureBox2.Image = image; // Hiển thị hình ảnh trong pictureBox2
                }
                else
                {
                    MessageBox.Show("Không nhận được mã QR từ API.");
                }
            }
            else
            {
                MessageBox.Show("Lỗi trong khi gửi yêu cầu: " + response.ErrorMessage);
            }
        }
        


        public Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                return System.Drawing.Image.FromStream(ms, true);
            }
        }

        private void txtSoHoaDon_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem textbox có trống hay không, nếu trống thì truyền null
            //string maKhachHang = string.IsNullOrEmpty(txtMaKhachHang.Text) ? null : txtMaKhachHang.Text;

            // Gọi phương thức LuuHoaDon với các giá trị từ textbox
            saleService.LuuHoaDon(txtSoHoaDon.Text, "SPACE040701", "KH001","Chuyen tien", DateTime.Now, 0);

            // Thông báo thành công hoặc xử lý thêm nếu cần
            MessageBox.Show("Hóa đơn đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Tải lại form để làm mới dữ liệu
            BanHang_Load(sender, e);
        }

        private void txtONhapMaVach_TextChanged_1(object sender, EventArgs e)
        {
            string maVach = txtONhapMaVach.Text; // Giả sử đây là ô nhập mã vạch

            // Kiểm tra xem mã vạch có đúng 11 ký tự không
            if (maVach.Length == 13)
            {
                // Gọi phương thức để lấy sản phẩm dựa vào mã vạch
                SanPham sanPham = saleService.GetProductByCode(maVach);

                if (sanPham != null)
                {
                    // Kiểm tra số lượng từ txtSoLuong
                    int quantityToAdd;

                    // Nếu txtSoLuong không có giá trị hoặc không hợp lệ, sử dụng giá trị mặc định là 1
                    if (string.IsNullOrWhiteSpace(txtSoLuong.Text) || !int.TryParse(txtSoLuong.Text, out quantityToAdd) || quantityToAdd <= 0)
                    {
                        quantityToAdd = 1; // Giá trị mặc định là 1
                    }

                    // Kiểm tra xem sản phẩm đã có trong DataGridView chưa
                    bool productExists = false;

                    foreach (DataGridViewRow row in dgvDanhSachSanPham.Rows)
                    {
                        // Kiểm tra sự tồn tại của cột "MASP"
                        if (dgvDanhSachSanPham.Columns.Contains("MASP") && row.Cells["MASP"].Value != null)
                        {
                            if (row.Cells["MASP"].Value.ToString() == sanPham.MASP)
                            {
                                // Nếu sản phẩm đã tồn tại, tăng số lượng lên số lượng nhập vào
                                int currentQuantity = Convert.ToInt32(row.Cells["SOLUONG"].Value);
                                row.Cells["SOLUONG"].Value = currentQuantity + quantityToAdd;
                                row.Cells["THANHTIEN"].Value = (currentQuantity + quantityToAdd) * sanPham.DONGIA;
                                productExists = true;
                                break;
                            }
                        }
                    }

                    // Nếu sản phẩm chưa tồn tại, thêm vào DataGridView
                    if (!productExists)
                    {
                        dgvDanhSachSanPham.Rows.Add(
                            sanPham.MASP,
                            sanPham.TENSP,
                            sanPham.DVT,
                            sanPham.DONGIA,
                            quantityToAdd, // Sử dụng số lượng tính toán
                            sanPham.DONGIA * quantityToAdd // Giá trị thành tiền
                        );
                    }

                    // Làm trống ô nhập mã vạch và ô nhập số lượng sau khi thêm sản phẩm
                    txtONhapMaVach.Text = string.Empty;
                    txtSoLuong.Text = string.Empty;
                    CalculateTotalAmount();
                }
                else
                {
                    MessageBox.Show("Sản phẩm không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }




        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvDanhSachSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDanhSachSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng nhấp vào cột số lượng
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvDanhSachSanPham.Columns["SOLUONG"].Index)
            {
                // Hiển thị hộp thoại nhập liệu cho người dùng
                string input = Microsoft.VisualBasic.Interaction.InputBox("Nhập số lượng mới:", "Cập nhật số lượng", dgvDanhSachSanPham.Rows[e.RowIndex].Cells["SOLUONG"].Value.ToString());

                // Kiểm tra nếu người dùng đã nhập dữ liệu
                if (int.TryParse(input, out int newQuantity))
                {
                    // Cập nhật số lượng trong DataGridView
                    dgvDanhSachSanPham.Rows[e.RowIndex].Cells["SOLUONG"].Value = newQuantity;

                    // Kiểm tra số lượng có bằng 0 không
                    if (newQuantity == 0)
                    {
                        // Xóa dòng nếu số lượng bằng 0
                        dgvDanhSachSanPham.Rows.RemoveAt(e.RowIndex);
                        CalculateTotalAmount();
                    }
                    else
                    {
                        // Tính toán lại thành tiền
                        var priceCell = dgvDanhSachSanPham.Rows[e.RowIndex].Cells["DONGIA"];
                        if (priceCell.Value != null)
                        {
                            decimal price = Convert.ToDecimal(priceCell.Value);
                            dgvDanhSachSanPham.Rows[e.RowIndex].Cells["THANHTIEN"].Value = price * newQuantity;
                        }
                        CalculateTotalAmount();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập một số nguyên hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        
        private void CalculateTotalAmount()
        {

            decimal totalAmount = 0;
            // Duyệt qua từng dòng trong DataGridView
            foreach (DataGridViewRow row in dgvDanhSachSanPham.Rows)
            {
                // Kiểm tra sự tồn tại của cột "THANHTIEN"
                if (row.Cells["THANHTIEN"].Value != null)
                {
                    // Cộng dồn giá trị thành tiền vào tổng
                    totalAmount += Convert.ToDecimal(row.Cells["THANHTIEN"].Value);
                }
            }
            // Cập nhật giá trị tổng vào một TextBox hoặc Label
            lblThanhTien.Text = totalAmount.ToString("C2"); // Định dạng tiền tệ

            // Cập nhật giá trị TongCong
            TongCong = (int)(totalAmount - totalDiscount); // Lưu ý: phần thập phân sẽ bị mất
            lblTongCong.Text = TongCong.ToString("C2");// Cập nhật lblTongCong mà không cần ép kiểu
        }

        public int TongCong;
        private void lblThanhTien_Click(object sender, EventArgs e)
        {

        }

        private void lblTongCong_Click(object sender, EventArgs e)
        {
           
        }

        // Khai báo biến toàn cục để lưu giá trị chiết khấu
        private decimal totalDiscount = 0;
        private void btnPhieuChietKhau50_Click(object sender, EventArgs e)
        {
            decimal discountToAdd = 50000; // Giá trị chiết khấu của nút 1
            UpdateTotalDiscount(discountToAdd);
        }

        private void btnPhieuChietKhau100_Click(object sender, EventArgs e)
        {
            decimal discountToAdd = 100000; // Giá trị chiết khấu của nút 2
            UpdateTotalDiscount(discountToAdd);
        }

        private void btnPhieuChietKhau200_Click(object sender, EventArgs e)
        {
            decimal discountToAdd = 200000; // Giá trị chiết khấu của nút 3
            UpdateTotalDiscount(discountToAdd);
        }

        private void btnChietKhau500_Click(object sender, EventArgs e)
        {
            decimal discountToAdd = 500000; // Giá trị chiết khấu của nút 
            UpdateTotalDiscount(discountToAdd);
        }

        // Phương thức để cập nhật tổng chiết khấu
        private void UpdateTotalDiscount(decimal discountToAdd)
        {
            if (discountToAdd > TongCong) 
            {
                MessageBox.Show("Không thể thêm triết khẩu!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            {
                // Cộng dồn giá trị chiết khấu
                totalDiscount += discountToAdd;
                CalculateTotalAmount();
            }

            // Cập nhật lblChietKhau với giá trị tổng chiết khấu
            lblChietKhau.Text = totalDiscount.ToString("C2"); // Định dạng không có phần thập phân
        }

    }
}
