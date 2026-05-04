using DoAn_LTWindows.BUS;
using DoAn_LTWindows.DTO;
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
    public partial class ucQuanLyTuyenXe : UserControl
    {
        private TuyenXeBUS tuyenXeBUS = new TuyenXeBUS();

        public ucQuanLyTuyenXe()
        {
            InitializeComponent();

            dgv_TuyenXe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_TuyenXe.ReadOnly = true;
            dgv_TuyenXe.AutoGenerateColumns = false;

            dgv_TuyenXe.DefaultCellStyle.ForeColor = Color.Black;
            dgv_TuyenXe.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv_TuyenXe.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_TuyenXe.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Hiệu ứng click chuột
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

        private void ucQuanLyTuyenXe_Load(object sender, EventArgs e)
        {
            dgv_TuyenXe.DefaultCellStyle.ForeColor = Color.Black;
            dgv_TuyenXe.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            LoadTatCaDuLieu();
        }

        private void LoadTatCaDuLieu()
        {
            try
            {
                List<TuyenXeDTO> list = tuyenXeBUS.LayDanhSachTuyen();
                dgv_TuyenXe.DataSource = list;
                dgv_TuyenXe.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải toàn bộ dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_TuyenXe_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_TuyenXe.SelectedRows.Count > 0)
            {
                TuyenXeDTO tuyen = dgv_TuyenXe.SelectedRows[0].DataBoundItem as TuyenXeDTO;
                if (tuyen == null) return;

                txt_MaTuyen.Text = tuyen.MaTuyen.ToString();
                txt_TenTuyen.Text = tuyen.TenTuyen;
                txt_Start.Text = tuyen.DiemXuatPhat;
                txt_End.Text = tuyen.DiemDen;
                nud_Distance.Value = tuyen.KhoangCach;
                nud_Time.Value = tuyen.ThoiGianChay;

                txt_MaTuyen.ReadOnly = true;
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            LoadTatCaDuLieu();

            txt_MaTuyen.ReadOnly = false;
            txt_MaTuyen.Clear();
            txt_TenTuyen.Clear();
            txt_Start.Clear();
            txt_End.Clear();
            nud_Distance.Value = 0;
            nud_Time.Value = 0;
            txt_Find.Clear();

            txt_MaTuyen.Focus();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                int maTuyen = 0;
                if (!int.TryParse(txt_MaTuyen.Text.Trim(), out maTuyen))
                {
                    MessageBox.Show("Mã Tuyến phải là một số nguyên hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                TuyenXeDTO tuyen = new TuyenXeDTO
                {
                    MaTuyen = maTuyen,
                    TenTuyen = txt_TenTuyen.Text.Trim(),
                    DiemXuatPhat = txt_Start.Text.Trim(),
                    DiemDen = txt_End.Text.Trim(),
                    KhoangCach = nud_Distance.Value,
                    ThoiGianChay = nud_Time.Value
                };

                tuyenXeBUS.ThemTuyenXe(tuyen);
                MessageBox.Show("Thêm tuyến xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_Reset_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                int maTuyen = 0;
                int.TryParse(txt_MaTuyen.Text.Trim(), out maTuyen);

                TuyenXeDTO tuyen = new TuyenXeDTO
                {
                    MaTuyen = maTuyen,
                    TenTuyen = txt_TenTuyen.Text.Trim(),
                    DiemXuatPhat = txt_Start.Text.Trim(),
                    DiemDen = txt_End.Text.Trim(),
                    KhoangCach = nud_Distance.Value,
                    ThoiGianChay = nud_Time.Value
                };

                tuyenXeBUS.SuaTuyenXe(tuyen);
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTatCaDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                int maTuyen = 0;
                if (!int.TryParse(txt_MaTuyen.Text.Trim(), out maTuyen) || maTuyen <= 0) return;

                if (MessageBox.Show($"Bạn có chắc chắn muốn XÓA tuyến: {txt_TenTuyen.Text}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    tuyenXeBUS.XoaTuyenXe(maTuyen);
                    MessageBox.Show("Đã xóa tuyến xe khỏi hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_Reset_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                List<TuyenXeDTO> list = tuyenXeBUS.TimKiemChung(tuKhoa);
                dgv_TuyenXe.DataSource = list;

                if (list.Count == 0)
                    MessageBox.Show("Không tìm thấy tuyến xe nào khớp với từ khóa!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Find_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_MaTuyen.Text) &&
                string.IsNullOrWhiteSpace(txt_TenTuyen.Text) &&
                string.IsNullOrWhiteSpace(txt_Start.Text) &&
                string.IsNullOrWhiteSpace(txt_End.Text) &&
                nud_Distance.Value == 0 &&
                nud_Time.Value == 0)
            {
                LoadTatCaDuLieu();
                return;
            }

            try
            {
                int maTuyen = 0;
                int.TryParse(txt_MaTuyen.Text.Trim(), out maTuyen);

                TuyenXeDTO dieuKien = new TuyenXeDTO
                {
                    MaTuyen = maTuyen,
                    TenTuyen = txt_TenTuyen.Text.Trim(),
                    DiemXuatPhat = txt_Start.Text.Trim(),
                    DiemDen = txt_End.Text.Trim(),
                    KhoangCach = nud_Distance.Value,
                    ThoiGianChay = nud_Time.Value
                };

                List<TuyenXeDTO> list = tuyenXeBUS.TimKiemChiTiet(dieuKien);
                dgv_TuyenXe.DataSource = list;

                if (list.Count == 0)
                    MessageBox.Show("Không có tuyến xe nào thỏa mãn các tiêu chí lọc này!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lọc chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_TuyenXe_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_TuyenXe.Columns[e.ColumnIndex].Name == "colSTT" && e.RowIndex >= 0)
            {
                e.Value = e.RowIndex + 1;
            }
        }

        private void btn_Return_Click(object sender, EventArgs e)
        {
            Panel pnlParent = (Panel)this.Parent;
            if (pnlParent != null)
            {
                pnlParent.Controls.Clear();
                // Thay ucLuaChonLichTrinh nếu file đó tồn tại, hoặc gọi frmMain điều hướng
                ucLuaChonLichTrinh uc = new ucLuaChonLichTrinh();
                uc.Dock = DockStyle.Fill;
                pnlParent.Controls.Add(uc);
            }
        }
    }
}
