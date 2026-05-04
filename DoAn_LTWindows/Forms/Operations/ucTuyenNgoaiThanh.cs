using DoAn_LTWindows.BUS;
using DoAn_LTWindows.DTO;
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
        private TuyenXeNgoaiThanhBUS tuyenXeBUS = new TuyenXeNgoaiThanhBUS();
        private VeXeNgoaiThanhBUS veXeBUS = new VeXeNgoaiThanhBUS();

        private List<VeXeNgoaiThanhDTO> danhSachVePopup;
        private int viTriPopupHienTai = 0;

        private List<string> danhSachGheDaChon = new List<string>();
        private int soLuongVeChoPhep = 0;
        private decimal giaVeHienTai = 0;

        public ucTuyenNgoaiThanh()
        {
            InitializeComponent();

            // Hiệu ứng nút bấm (Giữ nguyên của bạn)
            btn_Confirm.MouseDown += (s, e) => { btn_Confirm.BackgroundImage = Properties.Resources._75pxbtn1_c; };
            btn_Confirm.MouseUp += (s, e) => { btn_Confirm.BackgroundImage = Properties.Resources._75pxbtn1; };
            btn_Load.MouseDown += (s, e) => { btn_Load.BackgroundImage = Properties.Resources._75pxbtn1_c; };
            btn_Load.MouseUp += (s, e) => { btn_Load.BackgroundImage = Properties.Resources._75pxbtn1; };
            btn_PopupNext.MouseDown += (s, e) => { btn_PopupNext.BackgroundImage = Properties.Resources._75pxbtn1_c; };
            btn_PopupNext.MouseUp += (s, e) => { btn_PopupNext.BackgroundImage = Properties.Resources._75pxbtn1; };
            btn_PopupPrevious.MouseDown += (s, e) => { btn_PopupPrevious.BackgroundImage = Properties.Resources._75pxbtn1_c; };
            btn_PopupPrevious.MouseUp += (s, e) => { btn_PopupPrevious.BackgroundImage = Properties.Resources._75pxbtn1; };
            btn_PopupPrintTicket.MouseDown += (s, e) => { btn_PopupPrintTicket.BackgroundImage = Properties.Resources._75pxbtn1_c; };
            btn_PopupPrintTicket.MouseUp += (s, e) => { btn_PopupPrintTicket.BackgroundImage = Properties.Resources._75pxbtn1; };
            btn_PopupReturn.MouseDown += (s, e) => { btn_PopupReturn.BackgroundImage = Properties.Resources._75pxbtn1_c; };
            btn_PopupReturn.MouseUp += (s, e) => { btn_PopupReturn.BackgroundImage = Properties.Resources._75pxbtn1; };
            btn_Reset.MouseDown += (s, e) => { btn_Reset.BackgroundImage = Properties.Resources._75pxbtn1_c; };
            btn_Reset.MouseUp += (s, e) => { btn_Reset.BackgroundImage = Properties.Resources._75pxbtn1; };
            btn_Return.MouseDown += (s, e) => { btn_Return.BackgroundImage = Properties.Resources._75pxbtn1_c; };
            btn_Return.MouseUp += (s, e) => { btn_Return.BackgroundImage = Properties.Resources._75pxbtn1; };
        }

        private void ucTuyenNgoaiThanh_Load(object sender, EventArgs e)
        {
            btn_Confirm.Enabled = false;
            dtp_NgayDi.MinDate = DateTime.Today;
            nud_SoLuongVe.Minimum = 1;
            nud_SoLuongVe.Value = 1;
            pnl_PopupXacNhan.Visible = false;
            pnl_Data.AutoScroll = true;

            LoadComboBoxTuyen();
        }

        private void LoadComboBoxTuyen()
        {
            try
            {
                List<TuyenXeNgoaiThanhDTO> listTuyen = tuyenXeBUS.LayDanhSachTuyen();
                cmb_TuyenXe.DataSource = listTuyen;
                cmb_TuyenXe.DisplayMember = "TenTuyen";
                cmb_TuyenXe.ValueMember = "MaTuyen";
                cmb_TuyenXe.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- 2. NÚT TẢI SƠ ĐỒ GHẾ ---
        private void btn_Load_Click(object sender, EventArgs e)
        {
            if (cmb_TuyenXe.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn tuyến xe!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            pnl_Data.SuspendLayout();
            pnl_Data.Controls.Clear();
            danhSachGheDaChon.Clear();
            soLuongVeChoPhep = (int)nud_SoLuongVe.Value;

            TuyenXeNgoaiThanhDTO tuyenChon = (TuyenXeNgoaiThanhDTO)cmb_TuyenXe.SelectedItem;
            int soGhe = tuyenChon.SoGheTieuChuan;
            giaVeHienTai = tuyenChon.GiaVe;

            int btnWidth = 50, btnHeight = 45, spacing = 10, aisle = 40;
            int soCot = (int)Math.Ceiling((double)soGhe / 4);
            int totalWidth = soCot * btnWidth + (soCot - 1) * spacing;
            int totalHeight = 4 * btnHeight + 3 * spacing + aisle;

            int startX = (pnl_Data.Width - totalWidth) / 2;
            if (startX < 20) startX = 20;

            int startY = (pnl_Data.Height - totalHeight) / 2;
            if (startY < 20) startY = 20;

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

                int cotIdx = i / 4;
                int hangIdx = i % 4;
                int cotVeTrenUI = (soCot - 1) - cotIdx;
                int currentAisle = (hangIdx >= 2) ? aisle : 0;

                int xPos = startX + cotVeTrenUI * (btnWidth + spacing);
                int yPos = startY + hangIdx * (btnHeight + spacing) + currentAisle;

                btnGhe.Location = new Point(xPos, yPos);
                pnl_Data.Controls.Add(btnGhe);
            }

            pnl_Data.ResumeLayout();
            btn_Confirm.Enabled = true;
        }

        private void BtnGhe_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string tenGhe = btn.Text;

            if (btn.BackColor == Color.White)
            {
                if (danhSachGheDaChon.Count < soLuongVeChoPhep)
                {
                    btn.BackColor = Color.LimeGreen;
                    danhSachGheDaChon.Add(tenGhe);
                }
                else
                {
                    MessageBox.Show($"Bạn chỉ được chọn tối đa {soLuongVeChoPhep} ghế!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (btn.BackColor == Color.LimeGreen)
            {
                btn.BackColor = Color.White;
                danhSachGheDaChon.Remove(tenGhe);
            }
        }

        // --- 4. NÚT ĐẶT LẠI ---
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            pnl_Data.SuspendLayout();
            pnl_Data.Controls.Clear();
            pnl_Data.ResumeLayout();

            cmb_TuyenXe.SelectedIndex = -1;
            dtp_NgayDi.Value = DateTime.Today;
            nud_SoLuongVe.Value = 1;
            danhSachGheDaChon.Clear();
            btn_Confirm.Enabled = false;
        }

        private void btn_Return_Click(object sender, EventArgs e)
        {
            Panel pnlParent = (Panel)this.Parent;
            pnlParent.Controls.Clear();
            ucChonTuyen uc = new ucChonTuyen();
            uc.Dock = DockStyle.Fill;
            pnlParent.Controls.Add(uc);
        }

        // --- 6. NÚT XÁC NHẬN ---
        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (danhSachGheDaChon.Count < soLuongVeChoPhep)
            {
                MessageBox.Show($"Vui lòng chọn đủ {soLuongVeChoPhep} ghế trên sơ đồ!", "Chưa đủ ghế", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sdtKhachHang = txt_SoDienThoai.Text.Trim();

            if (string.IsNullOrWhiteSpace(sdtKhachHang))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại của khách hàng!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SoDienThoai.Focus();
                return;
            }

            if (sdtKhachHang.Length != 10 || !sdtKhachHang.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!\nVui lòng nhập chính xác 10 chữ số.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SoDienThoai.Focus();
                return;
            }

            string[] dauSoHopLe = {
                "032", "033", "034", "035", "036", "037", "038", "039", "086", "096", "097", "098",
                "081", "082", "083", "084", "085", "088", "091", "094",
                "070", "076", "077", "078", "079", "089", "090", "093",
                "052", "056", "058", "092", "059", "099", "087", "055"
            };

            string prefix = sdtKhachHang.Substring(0, 3);
            if (!dauSoHopLe.Contains(prefix))
            {
                MessageBox.Show("Đầu số điện thoại không tồn tại!\nVui lòng kiểm tra lại nhà mạng.", "Sai đầu số", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SoDienThoai.Focus();
                return;
            }

            TuyenXeNgoaiThanhDTO tuyenChon = (TuyenXeNgoaiThanhDTO)cmb_TuyenXe.SelectedItem;
            DateTime thoiGianHienTai = DateTime.Now;
            DateTime ngayDi = dtp_NgayDi.Value;

            danhSachVePopup = new List<VeXeNgoaiThanhDTO>();

            for (int i = 0; i < danhSachGheDaChon.Count; i++)
            {
                danhSachVePopup.Add(new VeXeNgoaiThanhDTO
                {
                    MaSoVe = $"NGT{thoiGianHienTai:HHmmss}-{i + 1:D2}",
                    MaTuyen = tuyenChon.MaTuyen,
                    HinhThucThanhToan = "Tiền Mặt",
                    ThoiGian = thoiGianHienTai,
                    NgayDi = ngayDi,
                    TuyenXe = tuyenChon.TenTuyen,
                    SoXe = tuyenChon.SoXe,
                    SoGhe = danhSachGheDaChon[i],
                    GiaVe = tuyenChon.GiaVe,
                    TenTram = tuyenChon.TenTram,
                    SoDienThoai = sdtKhachHang
                });
            }

            viTriPopupHienTai = 0;
            CapNhatGiaoDienPopup();

            pnl_PopupXacNhan.BringToFront();
            pnl_PopupXacNhan.Visible = true;
        }

        private void CapNhatGiaoDienPopup()
        {
            if (danhSachVePopup == null || danhSachVePopup.Count == 0) return;

            VeXeNgoaiThanhDTO ve = danhSachVePopup[viTriPopupHienTai];

            lbl_PopupMSVData.Text = ve.MaSoVe;
            lbl_PopupHTTTData.Text = ve.HinhThucThanhToan;
            lbl_PopupTGData.Text = ve.ThoiGian.ToString("dd/MM/yyyy HH:mm:ss");
            lbl_PopupNDData.Text = ve.NgayDi.ToString("dd/MM/yyyy");
            lbl_PopupTXData.Text = ve.TuyenXe;
            lbl_PopupSXData.Text = ve.SoXe;
            lbl_PopupSGData.Text = ve.SoGhe;
            lbl_PopupGVData.Text = ve.GiaVe.ToString("N0") + " VNĐ";
            lbl_PopupTTData.Text = ve.TenTram;
            lbl_PopupSDTData.Text = string.IsNullOrEmpty(ve.SoDienThoai) ? "Không có" : ve.SoDienThoai;

            btn_PopupPrevious.Enabled = (viTriPopupHienTai > 0);
            btn_PopupNext.Enabled = (viTriPopupHienTai < danhSachVePopup.Count - 1);
        }

        private void btn_PopupNext_Click(object sender, EventArgs e)
        {
            if (viTriPopupHienTai < danhSachVePopup.Count - 1)
            {
                viTriPopupHienTai++;
                CapNhatGiaoDienPopup();
            }
        }

        private void btn_PopupPrevious_Click(object sender, EventArgs e)
        {
            if (viTriPopupHienTai > 0)
            {
                viTriPopupHienTai--;
                CapNhatGiaoDienPopup();
            }
        }

        private void btn_PopupReturn_Click(object sender, EventArgs e)
        {
            pnl_PopupXacNhan.Visible = false;
        }

        // --- 7. NÚT IN VÉ (LƯU XUỐNG DB) ---
        private void btn_PopupPrintTicket_Click(object sender, EventArgs e)
        {
            try
            {
                // Ném list vé sang lớp BUS để thực hiện Insert
                veXeBUS.LuuDanhSachVe(danhSachVePopup);

                decimal tongTien = giaVeHienTai * danhSachGheDaChon.Count;
                MessageBox.Show($"Đã in thành công {danhSachGheDaChon.Count} vé!\n\nTổng thu: {tongTien:N0} VNĐ",
                                "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
