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
    public partial class ucQuanLyChuyenXe : UserControl
    {
        private ChuyenXeBUS chuyenXeBUS = new ChuyenXeBUS();
        private int maChuyenDangChon = -1;

        public ucQuanLyChuyenXe()
        {
            InitializeComponent();

            dgv_ChuyenXe.AutoGenerateColumns = false;
            dgv_ChuyenXe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ChuyenXe.ReadOnly = true;

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

        private void ucQuanLyChuyenXe_Load(object sender, EventArgs e)
        {
            dgv_ChuyenXe.DefaultCellStyle.ForeColor = Color.Black;
            dgv_ChuyenXe.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            LoadComboBoxes();
            LoadTatCaDuLieu();
        }

        private void LoadComboBoxes()
        {
            try
            {
                cmb_Tuyen.DataSource = chuyenXeBUS.LayDanhSachTuyen();
                cmb_Tuyen.DisplayMember = "TenTuyen";
                cmb_Tuyen.ValueMember = "MaTuyen";
                cmb_Tuyen.SelectedIndex = -1;

                cmb_Xe.DataSource = chuyenXeBUS.LayDanhSachXe();
                cmb_Xe.DisplayMember = "ThongTinXe";
                cmb_Xe.ValueMember = "MaXe";
                cmb_Xe.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTatCaDuLieu()
        {
            try
            {
                List<ChuyenXeDTO> list = chuyenXeBUS.LayTatCaChuyenXe();
                dgv_ChuyenXe.DataSource = list;
                dgv_ChuyenXe.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_ChuyenXe_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ChuyenXe.SelectedRows.Count > 0)
            {
                ChuyenXeDTO chuyen = dgv_ChuyenXe.SelectedRows[0].DataBoundItem as ChuyenXeDTO;
                if (chuyen == null) return;

                maChuyenDangChon = chuyen.MaChuyen;
                cmb_Tuyen.SelectedValue = chuyen.MaTuyen;
                cmb_Xe.SelectedValue = chuyen.MaXe;
                txt_Price.Text = chuyen.GiaVe.ToString("0");
                dtp_DateTime.Value = chuyen.ThoiGianXuatBen;
            }
        }

        private void dgv_ChuyenXe_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_ChuyenXe.Columns[e.ColumnIndex].Name == "colSTT" && e.RowIndex >= 0)
            {
                e.Value = e.RowIndex + 1;
            }
            if (dgv_ChuyenXe.Columns[e.ColumnIndex].DataPropertyName == "GiaVe" && e.Value != null)
            {
                e.Value = Convert.ToDecimal(e.Value).ToString("N0") + " VNĐ";
                e.FormattingApplied = true;
            }
            if (dgv_ChuyenXe.Columns[e.ColumnIndex].DataPropertyName == "ThoiGianXuatBen" && e.Value != null)
            {
                e.Value = Convert.ToDateTime(e.Value).ToString("dd/MM/yyyy HH:mm");
                e.FormattingApplied = true;
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            LoadTatCaDuLieu();
            maChuyenDangChon = -1;
            cmb_Tuyen.SelectedIndex = -1;
            cmb_Xe.SelectedIndex = -1;
            txt_Price.Clear();
            dtp_DateTime.Value = DateTime.Now;
            txt_Find.Clear();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                decimal giaVe;
                decimal.TryParse(txt_Price.Text.Trim(), out giaVe);

                ChuyenXeDTO chuyen = new ChuyenXeDTO
                {
                    MaTuyen = cmb_Tuyen.SelectedIndex != -1 ? (int)cmb_Tuyen.SelectedValue : 0,
                    MaXe = cmb_Xe.SelectedIndex != -1 ? (int)cmb_Xe.SelectedValue : 0,
                    GiaVe = giaVe,
                    ThoiGianXuatBen = dtp_DateTime.Value
                };

                chuyenXeBUS.ThemChuyenXe(chuyen);
                MessageBox.Show("Thêm chuyến xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_Reset_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                decimal giaVe;
                decimal.TryParse(txt_Price.Text.Trim(), out giaVe);

                ChuyenXeDTO chuyen = new ChuyenXeDTO
                {
                    MaChuyen = maChuyenDangChon,
                    MaTuyen = cmb_Tuyen.SelectedIndex != -1 ? (int)cmb_Tuyen.SelectedValue : 0,
                    MaXe = cmb_Xe.SelectedIndex != -1 ? (int)cmb_Xe.SelectedValue : 0,
                    GiaVe = giaVe,
                    ThoiGianXuatBen = dtp_DateTime.Value
                };

                chuyenXeBUS.SuaChuyenXe(chuyen);
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTatCaDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (maChuyenDangChon == -1) return;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa chuyến xe này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    chuyenXeBUS.XoaChuyenXe(maChuyenDangChon);
                    MessageBox.Show("Đã xóa chuyến xe!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_Reset_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                List<ChuyenXeDTO> list = chuyenXeBUS.TimKiemChung(tuKhoa);
                dgv_ChuyenXe.DataSource = list;
                if (list.Count == 0)
                    MessageBox.Show("Không tìm thấy chuyến xe phù hợp!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                decimal giaVe;
                decimal.TryParse(txt_Price.Text.Trim(), out giaVe);

                ChuyenXeDTO dieuKien = new ChuyenXeDTO
                {
                    MaTuyen = cmb_Tuyen.SelectedIndex != -1 ? (int)cmb_Tuyen.SelectedValue : 0,
                    MaXe = cmb_Xe.SelectedIndex != -1 ? (int)cmb_Xe.SelectedValue : 0,
                    GiaVe = giaVe,
                    ThoiGianXuatBen = dtp_DateTime.Value
                };

                List<ChuyenXeDTO> list = chuyenXeBUS.TimKiemChiTiet(dieuKien);
                dgv_ChuyenXe.DataSource = list;

                if (list.Count == 0)
                    MessageBox.Show("Không tìm thấy chuyến xe phù hợp!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                ucLuaChonLichTrinh uc = new ucLuaChonLichTrinh();
                uc.Dock = DockStyle.Fill;
                pnlParent.Controls.Add(uc);
            }
        }
    }
}
