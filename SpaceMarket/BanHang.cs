﻿using Newtonsoft.Json;
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
using Sunny.UI;
using SpaceMarket.Bao_cao;
using System.Threading.Tasks;

namespace SpaceMarket
{
    public partial class BanHang : Form
    {
        public string MANV { get; set; }
        public int tienkhachdua = 0;
        public int tienkhachchuyenkhoan = 0;
        public int tienthoi = 0;
        private readonly SaleService saleService = new SaleService();
        private readonly KhachHangService khachHangService = new KhachHangService();
        private readonly HoaDonService hoaDonService = new HoaDonService();
        private readonly PhieuQuaTangService phieuQuaTangService = new PhieuQuaTangService();
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




        private void uiPanel5_Click(object sender, EventArgs e)
        {

        }

        private void txtTruDiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu ký tự không phải là số và không phải là phím Backspace thì chặn lại
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void BanHang_Load(object sender, EventArgs e)
        {
            lblMaThe.Text = string.Empty;
            lblSDT.Text = string.Empty;
            lblDiemTichLuy.Text = string.Empty;
            lblTenKhachHang.Text = "Khách vãng lai";
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
            this.KeyPreview = true; // Bắt sự kiện phím trước khi gửi đến điều khiển khác
            this.KeyDown += new KeyEventHandler(BanHang_KeyDown);

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
            //MessageBox.Show("Tong tien: " + TongCong);
            if(TongCong > 0)
            {
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
                tienkhachchuyenkhoan = TongCong;
            }
            else
            {
                MessageBox.Show("Không thể tạo mã QR chuyển khoản!. Vui lòng xem lại hóa đơn!","Lỗi!",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
            if (dgvDanhSachSanPham != null && dgvDanhSachSanPham.Rows.Count > 0)
            {
                int tienKhachDua;

                // Kiểm tra xem giá trị trong txtTienKhachDua có thể chuyển đổi sang int không
                if (int.TryParse(txtTienKhachDua.Text, out tienKhachDua))
                {
                    // Kiểm tra xem tiền khách đưa có nhỏ hơn tổng công không
                    if (tienKhachDua < TongCong)
                    {
                        MessageBox.Show("Số tiền khách đưa không đủ để thanh toán. Vui lòng nhập lại mệnh giá!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTienKhachDua.Focus(); // Đưa con trỏ về textbox để nhập lại
                        txtTienKhachDua.SelectAll(); // Chọn tất cả văn bản trong textbox để nhập lại
                        return; // Dừng thực hiện các bước tiếp theo
                    }

                    // Tính số tiền thối lại
                    tienthoi = tienKhachDua - TongCong;
                    MessageBox.Show("Thối lại khách: " + tienthoi.ToString(), "Tiền thối lại", MessageBoxButtons.OK);
                }
                else
                {
                    //MessageBox.Show("Vui lòng nhập một số hợp lệ vào ô Tiền Khách Đưa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //txtTienKhachDua.Focus(); // Đưa con trỏ về textbox để nhập lại
                    //txtTienKhachDua.SelectAll(); // Chọn tất cả văn bản trong textbox để nhập lại
                    //return; // Dừng thực hiện các bước tiếp theo
                }

                string maKhachHang;

                // Kiểm tra xem lblMaThe có trống hay không
                if (string.IsNullOrEmpty(lblMaThe.Text))
                {
                    // Nếu lblMaThe trống, sử dụng "None" cho mã khách hàng
                    maKhachHang = "None";
                }
                else
                {
                    // Nếu lblMaThe không trống, lấy mã khách hàng từ mã thẻ
                    maKhachHang = khachHangService.GetCustomerIdByCardNumber(lblMaThe.Text);
                }

                if(tienKhachDua > 0)
                {
                    // Gọi phương thức LuuHoaDon với các giá trị từ textbox
                    saleService.LuuHoaDon(txtSoHoaDon.Text, MANV, maKhachHang, "Tien mat", DateTime.Now, TongCong, discountUsed);

                }
                else
                {
                    if (tienkhachchuyenkhoan > 0)
                    {
                        // Gọi phương thức LuuHoaDon với các giá trị từ textbox
                        saleService.LuuHoaDon(txtSoHoaDon.Text, MANV, maKhachHang, "Chuyen tien", DateTime.Now, TongCong, discountUsed);
                    }
                    else
                    {
                        MessageBox.Show("Vui long chọn hình thức thanh toán!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Giả sử bạn đã có một danh sách các sản phẩm trong DataGridView
                // và mỗi dòng chứa MASP, MAHD và SOLUONG.

                string maHD = txtSoHoaDon.Text; // Lấy mã hóa đơn từ textbox

                foreach (DataGridViewRow row in dgvDanhSachSanPham.Rows)
                {
                    // Kiểm tra xem dòng có hợp lệ không
                    if (row.IsNewRow) continue; // Bỏ qua dòng mới

                    // Lấy dữ liệu từ từng cột
                    string maSP = row.Cells["MASP"].Value.ToString();
                    int soLuong = Convert.ToInt32(row.Cells["SOLUONG"].Value);

                    // Tạo một đối tượng CHITIETHOADON mới
                    var chiTietHoaDon = new CHITIETHOADON
                    {
                        MASP = maSP,
                        MAHD = maHD,
                        SOLUONG = soLuong
                    };


                    // Gọi hàm AddDetail để thêm vào cơ sở dữ liệu
                    try
                    {
                        hoaDonService.AddDetail(chiTietHoaDon);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                InHoaDon inHoaDon = new InHoaDon();
                inHoaDon.MaHoaDon = txtSoHoaDon.Text;
                inHoaDon.TienThoi = tienthoi;
                inHoaDon.TienKhachDua = tienKhachDua;
                inHoaDon.TienKhachChuyenKhoan = tienkhachchuyenkhoan;
                inHoaDon.ShowDialog();

                //Hỏi nhân viên có yêu cầu in phiếu giao hàng không
                DialogResult dr =  MessageBox.Show("Khách hàng yêu cầu giao hàng ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dr == DialogResult.Yes)
                {
                    GiaoHang giaoHang = new GiaoHang();
                    giaoHang.MaDonHang = txtSoHoaDon.Text;
                    giaoHang.ShowDialog();
                }

                if (TongCong >= 2000000)
                {
                    // Gọi phương thức để thêm phiếu quà tặng
                    bool result = phieuQuaTangService.AddPhieuQuaTang(txtSoHoaDon.Text,10, "Dùng cho hóa đơn trên 2 triệu", "Mua tại các quầy");

                    // Thông báo cho người dùng
                    if (result)
                    {
                        InPhieuQuaTang inPhieuQuaTang = new InPhieuQuaTang();
                        inPhieuQuaTang.maHD = txtSoHoaDon.Text;
                        inPhieuQuaTang.ShowDialog();
                    }
                    else
                    {
                        //MessageBox.Show("Không đủ điều kiện để thêm phiếu quà tặng hoặc hóa đơn không tồn tại.");
                    }
                }
                else if (TongCong >= 1000000 && TongCong < 2000000)
                {
                    // Gọi phương thức để thêm phiếu quà tặng
                    bool result = phieuQuaTangService.AddPhieuQuaTang(txtSoHoaDon.Text, 5, "Dùng cho hóa đơn dưới 2 triệu", "Mua tại các quầy");

                    // Thông báo cho người dùng
                    if (result)
                    {
                        InPhieuQuaTang inPhieuQuaTang = new InPhieuQuaTang();
                        inPhieuQuaTang.maHD = txtSoHoaDon.Text;
                        inPhieuQuaTang.ShowDialog();
                    }
                    else
                    {
                        //MessageBox.Show("Không đủ điều kiện để thêm phiếu quà tặng hoặc hóa đơn không tồn tại.");
                    }

                }

                // Thông báo thành công hoặc xử lý thêm nếu cần
                MessageBox.Show("Hóa đơn đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                pictureBox2.Image = Image.FromFile("D:\\Tai Lieu Hoc Tap\\HP - DA HOAN THANH\\Lap Trinh Tren Moi Truong Windows\\Do an\\Image\\TOWKTEAM.png");

                // Giả sử bạn muốn làm trống dgvDanhSachSanPham
                dgvDanhSachSanPham.DataSource = null; // Gán lại DataSource là null
                dgvDanhSachSanPham.Rows.Clear(); // Xóa tất cả các dòng trong DataGridView
                txtTienKhachDua.Text = string.Empty;
                tienkhachchuyenkhoan = 0;
                tienthoi = 0;
                lblThanhTien.Text = string.Empty;
                lblTongCong.Text = string.Empty;
                pictureBox2.Image = Image.FromFile("D:\\Tai Lieu Hoc Tap\\HP - DA HOAN THANH\\Lap Trinh Tren Moi Truong Windows\\Do an\\Image\\TOWKTEAM.png");


                // Tải lại form để làm mới dữ liệu
                BanHang_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Hóa đơn trống!. Không thể lưu!","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtONhapMaVach_TextChanged_1(object sender, EventArgs e)
        {
            string maVach = txtONhapMaVach.Text; // Giả sử đây là ô nhập mã vạch

            // Kiểm tra xem mã vạch có đúng 13 ký tự không
            if (maVach.Length == 13)
            {
                // Kiểm tra ký tự đầu tiên
                if (char.IsDigit(maVach[0]))
                {
                    // Nếu ký tự đầu tiên là số, gọi phương thức để lấy sản phẩm dựa vào mã vạch
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
                else if (maVach[0] == 'K') // Kiểm tra ký tự đầu tiên là 'K'
                {
                    // Hiển thị thông báo cho khách hàng
                    MessageBox.Show("Khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Xóa ký tự 'K' và truyền tham số vào hàm
                    var customerDetails = khachHangService.GetCustomerDetails(maVach.Substring(1)); // Xóa ký tự 'K'
                    // Hiển thị thông tin ra GUI
                    if (customerDetails.MATHE != null)
                    {
                        lblMaThe.Text = customerDetails.MATHE;
                        lblTenKhachHang.Text = customerDetails.TENKH;
                        lblSDT.Text = customerDetails.SDTKH;
                        lblDiemTichLuy.Text = customerDetails.DIEMTICHLUY.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng với mã đã cho.");
                    }
                    // Nếu cần, bạn có thể làm thêm điều gì đó khác cho trường hợp khách hàng ở đây
                    txtONhapMaVach.Text = string.Empty; // Xóa ô nhập mã vạch
                }
            }
        }




        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu ký tự không phải là số hoặc là phím điều khiển (như Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho ký tự được nhập
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu độ dài của chuỗi trong TextBox lớn hơn 4
            if (txtSoLuong.Text.Length > 4)
            {
                // Lưu lại vị trí con trỏ chuột
                int cursorPosition = txtSoLuong.SelectionStart;

                // Cắt chuỗi để chỉ giữ lại 4 ký tự đầu tiên
                txtSoLuong.Text = txtSoLuong.Text.Substring(0, 4);

                // Đặt lại vị trí con trỏ chuột
                txtSoLuong.SelectionStart = cursorPosition > txtSoLuong.Text.Length ? txtSoLuong.Text.Length : cursorPosition;
            }
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

            // Khai báo biến để lưu giá trị trừ từ txtTruDiem
            decimal discountFromTxt = 0;

            // Kiểm tra xem txtTruDiem có giá trị hay không
            if (!string.IsNullOrEmpty(txtTruDiem.Text))
            {
                // Chuyển đổi giá trị trong txtTruDiem sang decimal
                discountFromTxt = Convert.ToDecimal(txtTruDiem.Text);
            }

            // Kiểm tra xem lblDiemTichLuy có giá trị hay không và điểm trừ có hợp lệ không
            decimal diemTichLuy = 0;
            if (!string.IsNullOrEmpty(lblDiemTichLuy.Text))
            {
                diemTichLuy = Convert.ToDecimal(lblDiemTichLuy.Text);
            }

            // Kiểm tra xem điểm trừ có lớn hơn điểm tích lũy không
            if (discountFromTxt > diemTichLuy)
            {
                MessageBox.Show("Điểm trừ không được lớn hơn điểm tích lũy!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                discountFromTxt = 0; // Đặt lại điểm trừ về 0 nếu không hợp lệ
                txtTruDiem.Text = ""; // Xóa nội dung trong ô txtTruDiem
            }

            // Kiểm tra xem lblThanhTien có lớn hơn điểm trừ không
            if (totalAmount < discountFromTxt)
            {
                MessageBox.Show("Thành tiền không đủ để trừ điểm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                discountFromTxt = 0; // Đặt lại điểm trừ về 0 nếu không hợp lệ
                txtTruDiem.Text = ""; // Xóa nội dung trong ô txtTruDiem
            }

            // Cập nhật biến discountUsed
            discountUsed = discountFromTxt; // Lưu điểm trừ vào biến

            // Cập nhật giá trị TongCong
            TongCong = (int)(totalAmount - totalDiscount - discountFromTxt); // Lưu ý: phần thập phân sẽ bị mất
            lblTongCong.Text = TongCong.ToString("C2"); // Cập nhật lblTongCong mà không cần ép kiểu
            if(TongCong >= 2000000)
            {
                lblUuDai.Text = "Khách hàng nhận được phiếu ưu đãi 10%";
            }
            else if (TongCong >= 1000000 && TongCong < 2000000)
            {
                lblUuDai.Text = "Khách hàng nhận được phiếu ưu đãi 5%";

            }
            else
            {
                lblUuDai.Text = "";
            }
        }



        public int TongCong;
        private decimal discountUsed = 0; // Biến để lưu giá trị điểm trừ

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

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLySanPham quanLySanPham = new QuanLySanPham();
            quanLySanPham.DisableAddButton();
            quanLySanPham.ShowDialog();
        }

        private void txtTruDiem_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalAmount();
        }

        private void btnHuyHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachSanPham != null && dgvDanhSachSanPham.Rows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Xác nhận hủy hóa đơn ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    // Làm trống DataGridView bằng cách đặt DataSource thành null
                    dgvDanhSachSanPham.DataSource = null;

                    // Xóa tất cả các dòng trong DataGridView
                    dgvDanhSachSanPham.Rows.Clear();
                    lblThanhTien.Text = string.Empty;
                    lblTongCong.Text = string.Empty;
                    TongCong = 0;
                    tienthoi = 0;
                    tienkhachdua = 0;
                    tienkhachchuyenkhoan = 0;
                    //pictureBox2.Image = null;
                    // Đặt hình ảnh mặc định cho PictureBox từ file
                    //pictureBox2.Image = Image.FromFile("..\\Do an\\Image\\TOWKTEAM.png");
                    string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Image\TOWKTEAM.png");
                    imagePath = Path.GetFullPath(imagePath); // Chuyển thành đường dẫn tuyệt đối

                    if (File.Exists(imagePath))
                    {
                        pictureBox2.Image = Image.FromFile(imagePath);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tệp: " + imagePath);
                    }

                }
            }
        }

        private void dgvDanhSachSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void đơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDon hoaDon = new HoaDon();
            hoaDon.ShowDialog();
        }

        private void txtONhapMaVach_Enter(object sender, EventArgs e)
        {
            if (txtONhapMaVach.Text == "Nhập mã vạch sản phẩm hoặc thẻ khách hàng")
            {
                txtONhapMaVach.Text = string.Empty;
                txtONhapMaVach.ForeColor = Color.Black;
            }
        }

        private void txtONhapMaVach_Leave(object sender, EventArgs e)
        {
            if(txtONhapMaVach.Text == string.Empty)
            {
                txtONhapMaVach.Text = "Nhập mã vạch sản phẩm hoặc thẻ khách hàng";
                txtONhapMaVach.ForeColor = Color.Silver;
            }
        }

        private void txtSoLuong_Enter(object sender, EventArgs e)
        {
            if (txtSoLuong.Text == "Số lượng")
            {
                txtSoLuong.Text = string.Empty;
                txtSoLuong.ForeColor = Color.Black;
            }
        }

        private void txtSoLuong_Leave(object sender, EventArgs e)
        {
            if (txtSoLuong.Text == string.Empty)
            {
                txtSoLuong.Text = "Số lượng";
                txtSoLuong.ForeColor= Color.Silver;
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Xác nhận đăng xuất ?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            btnLuuHoaDon_Click(sender, e);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void hỗTrợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void BanHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10) // Gán phím F1
            {
                btnLuuHoaDon.PerformClick(); // Kích hoạt button btnSave
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnHuyHoaDon.PerformClick();
            }
            else if (e.KeyCode == Keys.F12) // Gán phím 12
            {
                đăngXuấtToolStripMenuItem.PerformClick();
            }
            // Bạn có thể thêm các phím F khác tương tự
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TraCuuKhachHang traCuuKhachHang = new TraCuuKhachHang();
            traCuuKhachHang.ShowDialog();
        }

        private void txtTienKhachDua_Leave(object sender, EventArgs e)
        {
            if(txtTienKhachDua.Text == string.Empty)
            {
                txtTienKhachDua.Text = "Nhập số tiền khách đưa";
                txtTienKhachDua.ForeColor = Color.Silver;
            }
        }


        private void txtTienKhachDua_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTienKhachDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập các ký tự số và phím điều khiển (như Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho ký tự không hợp lệ xuất hiện
            }
        }


        private void txtTienKhachDua_Enter(object sender, EventArgs e)
        {
            if (txtTienKhachDua.Text == "Nhập số tiền khách đưa")
            {
                txtTienKhachDua.Text = string.Empty;
                txtTienKhachDua.ForeColor = Color.Black;
            }
        }
    }
}
