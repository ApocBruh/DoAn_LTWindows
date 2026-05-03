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
    public partial class ucTuyenNoiThanh : UserControl
    {
        string connectionString = @"Data Source=DESKTOP-QG0J4IU;Initial Catalog=QLBanVeXeBuyt;Integrated Security=True";
        // 2. CẤU TRÚC LƯU VÉ NHÁP VÀ BIẾN TOÀN CỤC
        private struct VeXeTemp
        {
            public string MaSoVe;
            public int MaTuyen;
            public string HinhThucThanhToan;
            public DateTime ThoiGian;
            public string TuyenXe;
            public string SoXe;
            public decimal GiaVe;
            public string TenTram;
        }

        private VeXeTemp[] danhSachVeNhap; // Mảng chứa các vé chưa in
        private int viTriHienTai = 0;      // Index của vé đang xem trên màn hình

        public ucTuyenNoiThanh()
        {
            InitializeComponent();
        }

        private void ucTuyenNoiThanh_Load(object sender, EventArgs e)
        {
            // Thiết lập NumericUpDown
            nud_SoLuongVe.Minimum = 0;
            nud_SoLuongVe.Value = 0;

            // Xóa rỗng các Label lúc mới vào
            ClearLabels();

            // Load ComboBox
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Lấy tất cả cột cần thiết lên
                    string query = "SELECT MaTuyen, TenTuyen, SoXe, TenTram, GiaVe FROM TuyenXeNoiThanh";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmb_TuyenXe.DataSource = dt;
                    cmb_TuyenXe.DisplayMember = "TenTuyen";
                    cmb_TuyenXe.ValueMember = "MaTuyen";
                    cmb_TuyenXe.SelectedIndex = -1; // Để trống
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi CSDL: " + ex.Message);
                }
            }
        }

        private void ClearLabels()
        {
            lbl_MSVData.Text = "...";
            lbl_HTTTData.Text = "...";
            lbl_TGData.Text = "...";
            lbl_TXData.Text = "...";
            lbl_SXData.Text = "...";
            lbl_GVData.Text = "...";
            lbl_TTData.Text = "...";
        }

        // HÀM QUAN TRỌNG: Tạo Mảng Vé Nháp
        private void SinhDuLieuVeNhap()
        {
            if (cmb_TuyenXe.SelectedIndex == -1 || nud_SoLuongVe.Value == 0)
            {
                ClearLabels();
                danhSachVeNhap = null;
                btn_Previous.Enabled = false;
                btn_Next.Enabled = false;
                return;
            }

            // Lấy dòng dữ liệu đang chọn
            DataRowView row = (DataRowView)cmb_TuyenXe.SelectedItem;
            int soLuong = (int)nud_SoLuongVe.Value;

            // Khởi tạo mảng vừa đúng với số lượng vé
            danhSachVeNhap = new VeXeTemp[soLuong];
            DateTime thoiGianHienTai = DateTime.Now;

            for (int i = 0; i < soLuong; i++)
            {
                danhSachVeNhap[i].MaSoVe = $"NT{thoiGianHienTai:HHmmss}-{i + 1:D2}";
                danhSachVeNhap[i].MaTuyen = Convert.ToInt32(row["MaTuyen"]);
                danhSachVeNhap[i].HinhThucThanhToan = "Tiền Mặt";
                danhSachVeNhap[i].ThoiGian = thoiGianHienTai;
                danhSachVeNhap[i].TuyenXe = row["TenTuyen"].ToString();
                danhSachVeNhap[i].SoXe = row["SoXe"].ToString();
                danhSachVeNhap[i].GiaVe = Convert.ToDecimal(row["GiaVe"]);
                danhSachVeNhap[i].TenTram = row["TenTram"].ToString();
            }

            viTriHienTai = 0; // Quay về vé đầu tiên
            CapNhatGiaoDienVe();
        }

        // HÀM HIỂN THỊ LÊN CÁC LABEL
        private void CapNhatGiaoDienVe()
        {
            if (danhSachVeNhap == null || danhSachVeNhap.Length == 0) return;

            VeXeTemp ve = danhSachVeNhap[viTriHienTai];

            lbl_MSVData.Text = ve.MaSoVe;
            lbl_HTTTData.Text = ve.HinhThucThanhToan;
            lbl_TGData.Text = ve.ThoiGian.ToString("dd/MM/yyyy HH:mm:ss");
            lbl_TXData.Text = ve.TuyenXe;
            lbl_SXData.Text = ve.SoXe;
            lbl_GVData.Text = ve.GiaVe.ToString("N0") + " VNĐ";
            lbl_TTData.Text = ve.TenTram;

            // Bật tắt nút lướt
            btn_Previous.Enabled = (viTriHienTai > 0);
            btn_Next.Enabled = (viTriHienTai < danhSachVeNhap.Length - 1);
        }

        // 1. Khi đổi Tuyến Xe
        private void cmb_TuyenXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra tránh lỗi ép kiểu lúc form load
            if (cmb_TuyenXe.SelectedValue is int)
            {
                SinhDuLieuVeNhap();
            }
        }

        // 2. Khi tăng giảm Số Lượng
        private void nud_SoLuongVe_ValueChanged(object sender, EventArgs e)
        {
            SinhDuLieuVeNhap();
        }

        // 3. Nút Next (>)
        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (danhSachVeNhap != null && viTriHienTai < danhSachVeNhap.Length - 1)
            {
                viTriHienTai++;
                CapNhatGiaoDienVe();
            }
        }

        // 4. Nút Previous (<)
        private void btn_Previous_Click(object sender, EventArgs e)
        {
            if (viTriHienTai > 0)
            {
                viTriHienTai--;
                CapNhatGiaoDienVe();
            }
        }

        // 5. Nút In Vé (Lưu vào CSDL)
        private void btn_PrintTicket_Click(object sender, EventArgs e)
        {
            if (danhSachVeNhap == null || danhSachVeNhap.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn tuyến và số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Duyệt qua cái Mảng và Insert từng dòng
                    for (int i = 0; i < danhSachVeNhap.Length; i++)
                    {
                        string query = @"INSERT INTO VeXeNoiThanh 
                                         (MaSoVe, MaTuyen, HinhThucThanhToan, ThoiGian, GiaVe) 
                                         VALUES (@MaSoVe, @MaTuyen, @HTTT, @ThoiGian, @GiaVe)";

                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@MaSoVe", danhSachVeNhap[i].MaSoVe);
                        cmd.Parameters.AddWithValue("@MaTuyen", danhSachVeNhap[i].MaTuyen);
                        cmd.Parameters.AddWithValue("@HTTT", danhSachVeNhap[i].HinhThucThanhToan);
                        cmd.Parameters.AddWithValue("@ThoiGian", danhSachVeNhap[i].ThoiGian);
                        cmd.Parameters.AddWithValue("@GiaVe", danhSachVeNhap[i].GiaVe);

                        cmd.ExecuteNonQuery();
                    }

                    decimal tongTien = danhSachVeNhap[0].GiaVe * danhSachVeNhap.Length;
                    MessageBox.Show($"Đã in thành công {danhSachVeNhap.Length} vé!\n\nTổng thu: {tongTien:N0} VNĐ",
                                    "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset UI
                    cmb_TuyenXe.SelectedIndex = -1;
                    nud_SoLuongVe.Value = 0;
                    ClearLabels();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lưu CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 6. Nút Quay Lại
        private void btn_Return_Click(object sender, EventArgs e)
        {
            Panel pnlParent = (Panel)this.Parent;
            pnlParent.Controls.Clear();
            ucChonTuyen uc = new ucChonTuyen();
            uc.Dock = DockStyle.Fill;
            pnlParent.Controls.Add(uc);
        }

        private void nud_SoLuongVe_ValueChanged_1(object sender, EventArgs e)
        {
            SinhDuLieuVeNhap();
        }
    }
}
