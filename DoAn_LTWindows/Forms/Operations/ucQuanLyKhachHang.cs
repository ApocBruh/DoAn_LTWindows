using DoAn_LTWindows.BUS;
using DoAn_LTWindows.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_LTWindows.Forms.Operations
{
    public partial class ucQuanLyKhachHang : UserControl
    {
        private KhachHangBUS khachHangBUS = new KhachHangBUS();
        private string sdtDangChon = "";

        public ucQuanLyKhachHang()
        {
            InitializeComponent();

            dgv_KhachHang.AutoGenerateColumns = false;
            dgv_KhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_KhachHang.ReadOnly = true;

            // Khóa ô Tổng số vé (Chỉ dùng để hiển thị)
            txt_TongSoVeDaMua.ReadOnly = true;

            // Hiệu ứng chuột (Mapped theo UI tên bạn gửi)
            btn_Delete.MouseDown += (s, e) => { btn_Delete.BackgroundImage = Properties.Resources._75pxbtn1_c; };
            btn_Delete.MouseUp += (s, e) => { btn_Delete.BackgroundImage = Properties.Resources._75pxbtn1; };
            btn_Edit.MouseDown += (s, e) => { btn_Edit.BackgroundImage = Properties.Resources._75pxbtn1_c; };
            btn_Edit.MouseUp += (s, e) => { btn_Edit.BackgroundImage = Properties.Resources._75pxbtn1; };
            btn_Find.MouseDown += (s, e) => { btn_Find.BackgroundImage = Properties.Resources._75pxbtn1_c; };
            btn_Find.MouseUp += (s, e) => { btn_Find.BackgroundImage = Properties.Resources._75pxbtn1; };
            btn_FindData.MouseDown += (s, e) => { btn_FindData.BackgroundImage = Properties.Resources._75pxbtn1_c; };
            btn_FindData.MouseUp += (s, e) => { btn_FindData.BackgroundImage = Properties.Resources._75pxbtn1; };
            btn_Reset.MouseDown += (s, e) => { btn_Reset.BackgroundImage = Properties.Resources._75pxbtn1_c; };
            btn_Reset.MouseUp += (s, e) => { btn_Reset.BackgroundImage = Properties.Resources._75pxbtn1; };
            btn_Return.MouseDown += (s, e) => { btn_Return.BackgroundImage = Properties.Resources._75pxbtn1_c; };
            btn_Return.MouseUp += (s, e) => { btn_Return.BackgroundImage = Properties.Resources._75pxbtn1; };
            btn_Save.MouseDown += (s, e) => { btn_Save.BackgroundImage = Properties.Resources._75pxbtn1_c; };
            btn_Save.MouseUp += (s, e) => { btn_Save.BackgroundImage = Properties.Resources._75pxbtn1; };
        }

        private void ucQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            dgv_KhachHang.DefaultCellStyle.ForeColor = Color.Black;
            dgv_KhachHang.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            LoadTatCaDuLieu();
        }

        private void LoadTatCaDuLieu()
        {
            try
            {
                List<KhachHangDTO> list = khachHangBUS.LayDanhSachKhachHang();
                dgv_KhachHang.DataSource = list;
                dgv_KhachHang.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_KhachHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_KhachHang.SelectedRows.Count > 0)
            {
                KhachHangDTO kh = dgv_KhachHang.SelectedRows[0].DataBoundItem as KhachHangDTO;
                if (kh == null) return;

                sdtDangChon = kh.SoDienThoai;
                txt_SoDienThoai.Text = kh.SoDienThoai;
                txt_TenKhachHang.Text = kh.TenKhachHang;
                txt_DiaChi.Text = kh.DiaChi;
                txt_TongSoVeDaMua.Text = kh.TongSoVeDaMua.ToString();

                // Khóa SĐT không cho người dùng tự ý đổi khi đang cập nhật
                txt_SoDienThoai.ReadOnly = true;
            }
        }

        private void dgv_KhachHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_KhachHang.Columns[e.ColumnIndex].Name == "colSTT" && e.RowIndex >= 0)
            {
                e.Value = e.RowIndex + 1;
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            LoadTatCaDuLieu();

            sdtDangChon = "";
            txt_SoDienThoai.ReadOnly = false;
            txt_SoDienThoai.Clear();
            txt_TenKhachHang.Clear();
            txt_DiaChi.Clear();
            txt_TongSoVeDaMua.Clear();
            txt_Find.Clear();

            txt_TenKhachHang.Focus();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                KhachHangDTO kh = new KhachHangDTO
                {
                    SoDienThoai = txt_SoDienThoai.Text.Trim(),
                    TenKhachHang = txt_TenKhachHang.Text.Trim(),
                    DiaChi = txt_DiaChi.Text.Trim()
                };

                khachHangBUS.ThemKhachHang(kh);
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_Reset_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                KhachHangDTO kh = new KhachHangDTO
                {
                    SoDienThoai = sdtDangChon, // Lấy từ biến ngầm
                    TenKhachHang = txt_TenKhachHang.Text.Trim(),
                    DiaChi = txt_DiaChi.Text.Trim()
                };

                khachHangBUS.SuaKhachHang(kh);
                MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTatCaDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(sdtDangChon)) return;

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng: {txt_TenKhachHang.Text}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    khachHangBUS.XoaKhachHang(sdtDangChon);
                    MessageBox.Show("Đã xóa khách hàng khỏi hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_Reset_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_FindData_Click(object sender, EventArgs e)
        {
            string tuKhoa = txt_Find.Text.Trim();
            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                LoadTatCaDuLieu();
                return;
            }

            try
            {
                List<KhachHangDTO> list = khachHangBUS.TimKiemChung(tuKhoa);
                dgv_KhachHang.DataSource = list;
                if (list.Count == 0)
                    MessageBox.Show("Không tìm thấy khách hàng phù hợp!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Find_Click(object sender, EventArgs e)
        {
            try
            {
                KhachHangDTO dieuKien = new KhachHangDTO
                {
                    SoDienThoai = txt_SoDienThoai.Text.Trim(),
                    TenKhachHang = txt_TenKhachHang.Text.Trim(),
                    DiaChi = txt_DiaChi.Text.Trim()
                };

                List<KhachHangDTO> list = khachHangBUS.TimKiemChiTiet(dieuKien);
                dgv_KhachHang.DataSource = list;

                if (list.Count == 0)
                    MessageBox.Show("Không tìm thấy khách hàng phù hợp!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Return_Click(object sender, EventArgs e)
        {
            Panel pnlParent = (Panel)this.Parent;
            if (pnlParent != null)
            {
                pnlParent.Controls.Clear();
                // ucLuaChonHethong uc = new ucLuaChonHeThong();
                // uc.Dock = DockStyle.Fill;
                // pnlParent.Controls.Add(uc);
            }
        }
    }
}
