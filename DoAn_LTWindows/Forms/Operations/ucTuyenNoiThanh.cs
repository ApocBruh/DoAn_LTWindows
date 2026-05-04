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
    public partial class ucTuyenNoiThanh : UserControl
    {
        // Gọi 2 lớp BUS để xử lý nghiệp vụ
        private TuyenXeNoiThanhBUS tuyenXeBUS = new TuyenXeNoiThanhBUS();
        private VeXeNoiThanhBUS veXeBUS = new VeXeNoiThanhBUS();

        // Thay mảng VeXeTemp cũ bằng List DTO chuẩn
        private List<VeXeNoiThanhDTO> danhSachVeNhap;
        private int viTriHienTai = 0;

        public ucTuyenNoiThanh()
        {
            InitializeComponent();
        }

        private void ucTuyenNoiThanh_Load(object sender, EventArgs e)
        {
            nud_SoLuongVe.Minimum = 0;
            nud_SoLuongVe.Value = 0;

            ClearLabels();

            try
            {
                // Gọi BUS lấy dữ liệu (Không còn dòng SQL nào ở đây)
                List<TuyenXeNoiThanhDTO> danhSachTuyen = tuyenXeBUS.LayDanhSachTuyen();

                cmb_TuyenXe.DataSource = danhSachTuyen;
                cmb_TuyenXe.DisplayMember = "TenTuyen";
                cmb_TuyenXe.ValueMember = "MaTuyen";
                cmb_TuyenXe.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Tạo danh sách vé nháp
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

            // Nhờ dùng List<DTO>, ép kiểu thẳng ra Object thay vì DataRowView
            TuyenXeNoiThanhDTO tuyenChon = (TuyenXeNoiThanhDTO)cmb_TuyenXe.SelectedItem;
            int soLuong = (int)nud_SoLuongVe.Value;

            danhSachVeNhap = new List<VeXeNoiThanhDTO>();
            DateTime thoiGianHienTai = DateTime.Now;

            for (int i = 0; i < soLuong; i++)
            {
                danhSachVeNhap.Add(new VeXeNoiThanhDTO
                {
                    MaSoVe = $"NT{thoiGianHienTai:HHmmss}-{i + 1:D2}",
                    MaTuyen = tuyenChon.MaTuyen,
                    HinhThucThanhToan = "Tiền Mặt",
                    ThoiGian = thoiGianHienTai,
                    GiaVe = tuyenChon.GiaVe,
                    TuyenXe = tuyenChon.TenTuyen,
                    SoXe = tuyenChon.SoXe,
                    TenTram = tuyenChon.TenTram
                });
            }

            viTriHienTai = 0;
            CapNhatGiaoDienVe();
        }

        private void CapNhatGiaoDienVe()
        {
            if (danhSachVeNhap == null || danhSachVeNhap.Count == 0) return;

            VeXeNoiThanhDTO ve = danhSachVeNhap[viTriHienTai];

            lbl_MSVData.Text = ve.MaSoVe;
            lbl_HTTTData.Text = ve.HinhThucThanhToan;
            lbl_TGData.Text = ve.ThoiGian.ToString("dd/MM/yyyy HH:mm:ss");
            lbl_TXData.Text = ve.TuyenXe;
            lbl_SXData.Text = ve.SoXe;
            lbl_GVData.Text = ve.GiaVe.ToString("N0") + " VNĐ";
            lbl_TTData.Text = ve.TenTram;

            btn_Previous.Enabled = (viTriHienTai > 0);
            btn_Next.Enabled = (viTriHienTai < danhSachVeNhap.Count - 1);
        }

        private void cmb_TuyenXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_TuyenXe.SelectedValue is int)
            {
                SinhDuLieuVeNhap();
            }
        }

        private void nud_SoLuongVe_ValueChanged(object sender, EventArgs e)
        {
            SinhDuLieuVeNhap();
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (danhSachVeNhap != null && viTriHienTai < danhSachVeNhap.Count - 1)
            {
                viTriHienTai++;
                CapNhatGiaoDienVe();
            }
        }

        private void btn_Previous_Click(object sender, EventArgs e)
        {
            if (viTriHienTai > 0)
            {
                viTriHienTai--;
                CapNhatGiaoDienVe();
            }
        }

        // Nút In Vé 
        private void btn_PrintTicket_Click(object sender, EventArgs e)
        {
            if (danhSachVeNhap == null || danhSachVeNhap.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tuyến và số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Ném mảng vé sang cho lớp BUS lo liệu
                veXeBUS.LuuDanhSachVe(danhSachVeNhap);

                decimal tongTien = danhSachVeNhap[0].GiaVe * danhSachVeNhap.Count;
                MessageBox.Show($"Đã in thành công {danhSachVeNhap.Count} vé!\n\nTổng thu: {tongTien:N0} VNĐ",
                                "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cmb_TuyenXe.SelectedIndex = -1;
                nud_SoLuongVe.Value = 0;
                ClearLabels();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Return_Click(object sender, EventArgs e)
        {
            Panel pnlParent = (Panel)this.Parent;
            pnlParent.Controls.Clear();
            ucChonTuyen uc = new ucChonTuyen();
            uc.Dock = DockStyle.Fill;
            pnlParent.Controls.Add(uc);
        }
    }
}
