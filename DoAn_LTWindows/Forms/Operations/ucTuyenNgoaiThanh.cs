using DoAn_LTWindows.Forms.Systems;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_LTWindows.Forms.Operations
{
    public partial class ucTuyenNgoaiThanh : UserControl
    {
        private struct VeNgoaiThanhTemp
        {
            public string MaSoVe;
            public string SoDienThoai;
            public int MaTuyen;
            public string HinhThucThanhToan;
            public DateTime ThoiGian;
            public DateTime NgayDi;
            public string TuyenXe;
            public string SoXe;
            public string SoGhe;
            public decimal GiaVe;
            public string TenTram;
        }

        private VeNgoaiThanhTemp[] danhSachVePopup;
        private int viTriPopupHienTai = 0;

        public ucTuyenNgoaiThanh()
        {
            InitializeComponent();

            btn_Confirm.MouseDown += (s, e) => {
                btn_Confirm.BackgroundImage = Properties.Resources._75pxbtn1_c;
            };

            btn_Confirm.MouseUp += (s, e) => {
                btn_Confirm.BackgroundImage = Properties.Resources._75pxbtn1;
            };

            btn_Load.MouseDown += (s, e) => {
                btn_Load.BackgroundImage = Properties.Resources._75pxbtn1_c;
            };

            btn_Load.MouseUp += (s, e) => {
                btn_Load.BackgroundImage = Properties.Resources._75pxbtn1;
            };
            btn_PopupNext.MouseDown += (s, e) => {
                btn_PopupNext.BackgroundImage = Properties.Resources._75pxbtn1_c;
            };

            btn_PopupNext.MouseUp += (s, e) => {
                btn_PopupNext.BackgroundImage = Properties.Resources._75pxbtn1;
            };

            btn_PopupPrevious.MouseDown += (s, e) => {
                btn_PopupPrevious.BackgroundImage = Properties.Resources._75pxbtn1_c;
            };

            btn_PopupPrevious.MouseUp += (s, e) => {
                btn_PopupPrevious.BackgroundImage = Properties.Resources._75pxbtn1;
            };
            btn_PopupPrintTicket.MouseDown += (s, e) => {
                btn_PopupPrintTicket.BackgroundImage = Properties.Resources._75pxbtn1_c;
            };

            btn_PopupPrintTicket.MouseUp += (s, e) => {
                btn_PopupPrintTicket.BackgroundImage = Properties.Resources._75pxbtn1;
            };

            btn_PopupReturn.MouseDown += (s, e) => {
                btn_PopupReturn.BackgroundImage = Properties.Resources._75pxbtn1_c;
            };

            btn_PopupReturn.MouseUp += (s, e) => {
                btn_PopupReturn.BackgroundImage = Properties.Resources._75pxbtn1;
            };
            btn_Reset.MouseDown += (s, e) => {
                btn_Reset.BackgroundImage = Properties.Resources._75pxbtn1_c;
            };

            btn_Reset.MouseUp += (s, e) => {
                btn_Reset.BackgroundImage = Properties.Resources._75pxbtn1;
            };

            btn_Return.MouseDown += (s, e) => {
                btn_Return.BackgroundImage = Properties.Resources._75pxbtn1_c;
            };

            btn_Return.MouseUp += (s, e) => {
                btn_Return.BackgroundImage = Properties.Resources._75pxbtn1;
            };
        }

        string connectionString = @"Data Source=DESKTOP-QG0J4IU;Initial Catalog=QLBanVeXeBuyt;Integrated Security=True";

        // Biến lưu trữ danh sách các ghế khách đã click chọn
        private List<string> danhSachGheDaChon = new List<string>();
        private int soLuongVeChoPhep = 0;
        private decimal giaVeHienTai = 0;

        // --- 1. KHI FORM VỪA LOAD ---
        private void ucTuyenNgoaiThanh_Load(object sender, EventArgs e)
        {
            // KHÓA NÚT XÁC NHẬN MẶC ĐỊNH
            btn_Confirm.Enabled = false;

            dtp_NgayDi.MinDate = DateTime.Today;
            nud_SoLuongVe.Minimum = 1;
            nud_SoLuongVe.Value = 1;

            pnl_PopupXacNhan.Visible = false;
            LoadComboBoxTuyen();
            // CHẶN CHỌN NGÀY QUÁ KHỨ (Yêu cầu quan trọng)
            dtp_NgayDi.MinDate = DateTime.Today;

            nud_SoLuongVe.Minimum = 1;
            nud_SoLuongVe.Value = 1;
            pnl_Data.AutoScroll = true; // Bật thanh cuộn nếu xe quá nhiều ghế

            LoadComboBoxTuyen();
        }

        private void LoadComboBoxTuyen()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT MaTuyen, TenTuyen, SoGheTieuChuan, SoXe, TenTram, GiaVe FROM TuyenXeNgoaiThanh";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmb_TuyenXe.DataSource = dt;
                    cmb_TuyenXe.DisplayMember = "TenTuyen";
                    cmb_TuyenXe.ValueMember = "MaTuyen";
                    cmb_TuyenXe.SelectedIndex = -1;
                }
                catch (Exception ex) { MessageBox.Show("Lỗi CSDL: " + ex.Message); }
            }
        }

        // --- 2. NÚT TẢI SƠ ĐỒ (VẼ GHẾ ĐỘNG) ---
        private void btn_Load_Click(object sender, EventArgs e)
        {
                if (cmb_TuyenXe.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn tuyến xe!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 1. ĐÓNG BĂNG GIAO DIỆN ĐỂ TĂNG TỐC ĐỘ VẼ (Chống giật lag)
                pnl_Data.SuspendLayout();
                pnl_Data.Controls.Clear();

                danhSachGheDaChon.Clear();
                soLuongVeChoPhep = (int)nud_SoLuongVe.Value;

                DataRowView row = (DataRowView)cmb_TuyenXe.SelectedItem;
                int soGhe = Convert.ToInt32(row["SoGheTieuChuan"]);
                giaVeHienTai = Convert.ToDecimal(row["GiaVe"]);

                int btnWidth = 50, btnHeight = 45;
                int spacing = 10;
                int aisle = 40; // Lối đi giữa xe

                // 2. TOÁN HỌC: TÍNH TOÁN KÍCH THƯỚC ĐỂ CANH GIỮA
                int soCot = (int)Math.Ceiling((double)soGhe / 4);
                int totalWidth = soCot * btnWidth + (soCot - 1) * spacing;
                int totalHeight = 4 * btnHeight + 3 * spacing + aisle;

                // Tính tọa độ X, Y để nguyên khối sơ đồ nằm ngay giữa Panel
                int startX = (pnl_Data.Width - totalWidth) / 2;
                if (startX < 20) startX = 20; // Nếu xe quá dài, ép về sát mép trái để dùng thanh cuộn

                int startY = (pnl_Data.Height - totalHeight) / 2;
                if (startY < 20) startY = 20;

                pnl_Data.AutoScroll = true;

            // (Đoạn code tính startX, startY ở trên giữ nguyên)
            // ...

            for (int i = 0; i < soGhe; i++)
            {
                Button btnGhe = new Button();
                btnGhe.Text = (i + 1).ToString("D2");
                btnGhe.Name = "Ghe_" + btnGhe.Text;
                btnGhe.Size = new Size(btnWidth, btnHeight);
                btnGhe.BackColor = Color.White;
                btnGhe.FlatStyle = FlatStyle.Flat;
                btnGhe.Cursor = Cursors.Hand;

                btnGhe.Font = new Font("Oswald", 11F, FontStyle.Bold);
                btnGhe.ForeColor = Color.Black;
                btnGhe.Padding = new Padding(0);
                btnGhe.TextAlign = ContentAlignment.MiddleCenter;

                btnGhe.Click += BtnGhe_Click;

                int cotIdx = i / 4;  // Thứ tự cột theo logic (0, 1, 2...)
                int hangIdx = i % 4;

                // --- ĐIỂM THAY ĐỔI MẤU CHỐT ---
                // Lật ngược cột: Lấy tổng số cột trừ đi 1, sau đó trừ đi cột hiện tại
                // Ví dụ có 8 cột: Cột 0 sẽ thành cột 7 (Nằm tít bên phải)
                int cotVeTrenUI = (soCot - 1) - cotIdx;

                int currentAisle = (hangIdx >= 2) ? aisle : 0;

                // Tính tọa độ X dựa trên cột đã lật ngược (cotVeTrenUI)
                int xPos = startX + cotVeTrenUI * (btnWidth + spacing);
                int yPos = startY + hangIdx * (btnHeight + spacing) + currentAisle;

                btnGhe.Location = new Point(xPos, yPos);
                pnl_Data.Controls.Add(btnGhe);
            }

            pnl_Data.ResumeLayout();

            // MỞ KHÓA NÚT XÁC NHẬN SAU KHI TẢI XONG
            btn_Confirm.Enabled = true;
        }

        // --- 3. SỰ KIỆN CLICK CHỌN GHẾ ---
        private void BtnGhe_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string tenGhe = btn.Text;

            // Nếu ghế đang trắng (chưa chọn)
            if (btn.BackColor == Color.White)
            {
                if (danhSachGheDaChon.Count < soLuongVeChoPhep)
                {
                    btn.BackColor = Color.LimeGreen; // Đổi màu xanh Neon
                    danhSachGheDaChon.Add(tenGhe);
                }
                else
                {
                    MessageBox.Show($"Bạn chỉ được chọn tối đa {soLuongVeChoPhep} ghế!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            // Nếu ghế đang xanh (muốn bỏ chọn)
            else if (btn.BackColor == Color.LimeGreen)
            {
                btn.BackColor = Color.White;
                danhSachGheDaChon.Remove(tenGhe);
            }
        }

        // --- 4. NÚT ĐẶT LẠI ---
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            // Tương tự, đóng băng UI khi xóa số lượng lớn Control
            pnl_Data.SuspendLayout();
            pnl_Data.Controls.Clear();
            pnl_Data.ResumeLayout();

            cmb_TuyenXe.SelectedIndex = -1;
            dtp_NgayDi.Value = DateTime.Today;
            nud_SoLuongVe.Value = 1;
            danhSachGheDaChon.Clear();
        }

        // --- 5. NÚT QUAY LẠI ---
        private void btn_Return_Click(object sender, EventArgs e)
        {
            Panel pnlParent = (Panel)this.Parent;
            pnlParent.Controls.Clear();
            ucChonTuyen uc = new ucChonTuyen();
            uc.Dock = DockStyle.Fill;
            pnlParent.Controls.Add(uc);
        }

        // --- 6. NÚT XÁC NHẬN (MỞ POPUP IN VÉ) ---
        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (danhSachGheDaChon.Count < soLuongVeChoPhep)
            {
                MessageBox.Show($"Vui lòng chọn đủ {soLuongVeChoPhep} ghế trên sơ đồ!", "Chưa đủ ghế", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- BẮT ĐẦU KIỂM TRA SỐ ĐIỆN THOẠI ---
            string sdtKhachHang = txt_SoDienThoai.Text.Trim();

            // 1. Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(sdtKhachHang))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại của khách hàng!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SoDienThoai.Focus();
                return;
            }

            // 2. Kiểm tra độ dài chuẩn 10 số và chỉ chứa chữ số (Không chứa chữ cái/kí tự đặc biệt)
            if (sdtKhachHang.Length != 10 || !sdtKhachHang.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!\nVui lòng nhập chính xác 10 chữ số.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SoDienThoai.Focus();
                return;
            }

            // 3. Kiểm tra đầu số hợp lệ của các nhà mạng Việt Nam
            string[] dauSoHopLe = {
                "032", "033", "034", "035", "036", "037", "038", "039", "086", "096", "097", "098", // Viettel
                "081", "082", "083", "084", "085", "088", "091", "094",                             // Vinaphone
                "070", "076", "077", "078", "079", "089", "090", "093",                             // Mobifone
                "052", "056", "058", "092", "059", "099", "087", "055"                              // Khác (Vietnamobile, Gmobile, Wintel, ITel)
            };

            string prefix = sdtKhachHang.Substring(0, 3); // Cắt lấy 3 số đầu tiên
            if (!dauSoHopLe.Contains(prefix))
            {
                MessageBox.Show("Đầu số điện thoại không tồn tại!\nVui lòng kiểm tra lại nhà mạng.", "Sai đầu số", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SoDienThoai.Focus();
                return;
            }
            // --- KẾT THÚC KIỂM TRA ---

            DataRowView row = (DataRowView)cmb_TuyenXe.SelectedItem;
            DateTime thoiGianHienTai = DateTime.Now;
            DateTime ngayDi = dtp_NgayDi.Value;

            // Khởi tạo mảng vé nháp dựa trên số ghế đã chọn
            danhSachVePopup = new VeNgoaiThanhTemp[danhSachGheDaChon.Count];

            for (int i = 0; i < danhSachGheDaChon.Count; i++)
            {
                danhSachVePopup[i].MaSoVe = $"NGT{thoiGianHienTai:HHmmss}-{i + 1:D2}";
                danhSachVePopup[i].MaTuyen = Convert.ToInt32(row["MaTuyen"]);
                danhSachVePopup[i].HinhThucThanhToan = "Tiền Mặt";
                danhSachVePopup[i].ThoiGian = thoiGianHienTai;
                danhSachVePopup[i].NgayDi = ngayDi;
                danhSachVePopup[i].TuyenXe = row["TenTuyen"].ToString();
                danhSachVePopup[i].SoXe = row["SoXe"].ToString();
                danhSachVePopup[i].SoGhe = danhSachGheDaChon[i];
                danhSachVePopup[i].GiaVe = Convert.ToDecimal(row["GiaVe"]);
                danhSachVePopup[i].TenTram = row["TenTram"].ToString();

                // Lưu SĐT hợp lệ vào mảng nháp
                danhSachVePopup[i].SoDienThoai = sdtKhachHang;
            }

            viTriPopupHienTai = 0;
            CapNhatGiaoDienPopup();

            // Hiển thị Popup
            pnl_PopupXacNhan.BringToFront();
            pnl_PopupXacNhan.Visible = true;
        }

        private void CapNhatGiaoDienPopup()
        {
            if (danhSachVePopup == null || danhSachVePopup.Length == 0) return;

            VeNgoaiThanhTemp ve = danhSachVePopup[viTriPopupHienTai];

            lbl_PopupMSVData.Text = ve.MaSoVe;
            lbl_PopupHTTTData.Text = ve.HinhThucThanhToan;
            lbl_PopupTGData.Text = ve.ThoiGian.ToString("dd/MM/yyyy HH:mm:ss");
            lbl_PopupNDData.Text = ve.NgayDi.ToString("dd/MM/yyyy");
            lbl_PopupTXData.Text = ve.TuyenXe;
            lbl_PopupSXData.Text = ve.SoXe;
            lbl_PopupSGData.Text = ve.SoGhe;
            lbl_PopupGVData.Text = ve.GiaVe.ToString("N0") + " VNĐ";
            lbl_PopupTTData.Text = ve.TenTram;

            // HIỂN THỊ SĐT LÊN POPUP
            lbl_PopupSDTData.Text = string.IsNullOrEmpty(ve.SoDienThoai) ? "Không có" : ve.SoDienThoai;

            // Bật tắt nút lướt trong Popup
            btn_PopupPrevious.Enabled = (viTriPopupHienTai > 0);
            btn_PopupNext.Enabled = (viTriPopupHienTai < danhSachVePopup.Length - 1);
        }

        // Nút >
        private void btn_PopupNext_Click(object sender, EventArgs e)
        {
            if (viTriPopupHienTai < danhSachVePopup.Length - 1)
            {
                viTriPopupHienTai++;
                CapNhatGiaoDienPopup();
            }
        }

        // Nút <
        private void btn_PopupPrevious_Click(object sender, EventArgs e)
        {
            if (viTriPopupHienTai > 0)
            {
                viTriPopupHienTai--;
                CapNhatGiaoDienPopup();
            }
        }

        // Nút Quay Lại
        private void btn_PopupReturn_Click(object sender, EventArgs e)
        {
            pnl_PopupXacNhan.Visible = false; // Chỉ cần giấu Panel đi là xong
        }

        // Nút In Vé
        private void btn_PopupPrintTicket_Click(object sender, EventArgs e)
        {
            // Lấy SĐT từ TextBox mà nhân viên vừa nhập
            string sdtKhachHang = txt_SoDienThoai.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    DateTime thoiGianIn = DateTime.Now;
                    int maTuyen = Convert.ToInt32(cmb_TuyenXe.SelectedValue);

                    for (int i = 0; i < danhSachGheDaChon.Count; i++)
                    {
                        string maVe = $"NGT{thoiGianIn:ddHHmmss}-{i + 1:D2}";

                        // THÊM CỘT SoDienThoai VÀO CÂU LỆNH INSERT
                        string query = @"INSERT INTO VeXeNgoaiThanh (MaSoVe, MaTuyen, HinhThucThanhToan, ThoiGian, NgayDi, SoGhe, GiaVe, SoDienThoai) 
                                         VALUES (@MaVe, @MaTuyen, @HTTT, @ThoiGian, @NgayDi, @SoGhe, @GiaVe, @SoDienThoai)";

                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@MaVe", maVe);
                        cmd.Parameters.AddWithValue("@MaTuyen", maTuyen);
                        cmd.Parameters.AddWithValue("@HTTT", "Tiền Mặt");
                        cmd.Parameters.AddWithValue("@ThoiGian", thoiGianIn);
                        cmd.Parameters.AddWithValue("@NgayDi", dtp_NgayDi.Value.Date);
                        cmd.Parameters.AddWithValue("@SoGhe", danhSachGheDaChon[i]);
                        cmd.Parameters.AddWithValue("@GiaVe", giaVeHienTai);

                        // TRUYỀN THAM SỐ SĐT VÀO ĐÂY (Nếu TextBox trống thì truyền chuỗi rỗng để khỏi bị lỗi)
                        cmd.Parameters.AddWithValue("@SoDienThoai", string.IsNullOrEmpty(sdtKhachHang) ? (object)DBNull.Value : sdtKhachHang);

                        cmd.ExecuteNonQuery();
                    }

                    decimal tongTien = giaVeHienTai * danhSachGheDaChon.Count;
                    MessageBox.Show($"Đã in thành công {danhSachGheDaChon.Count} vé!\n\nTổng thu: {tongTien:N0} VNĐ",
                                    "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Ẩn Popup, xóa SĐT và reset màn hình
                    txt_SoDienThoai.Clear();
                    pnl_PopupXacNhan.Visible = false;
                    btn_Reset_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lưu CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
