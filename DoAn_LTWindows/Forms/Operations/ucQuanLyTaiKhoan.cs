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
    public partial class ucQuanLyTaiKhoan : UserControl
    {
        private TaiKhoanBUS taiKhoanBUS = new TaiKhoanBUS();
        private string taiKhoanDangChon = "";

        public ucQuanLyTaiKhoan()
        {
            InitializeComponent();

            dgv_Account.AutoGenerateColumns = false;
            dgv_Account.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Account.ReadOnly = true;

            chk_Active.CheckedChanged += (s, e) => { if (chk_Active.Checked) chk_Lock.Checked = false; };
            chk_Lock.CheckedChanged += (s, e) => { if (chk_Lock.Checked) chk_Active.Checked = false; };

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

        private void ucQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            dgv_Account.DefaultCellStyle.ForeColor = Color.Black;
            dgv_Account.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            LoadTatCaDuLieu();
            btn_Reset_Click(null, null);
        }

        private void LoadTatCaDuLieu()
        {
            try
            {
                List<TaiKhoanDTO> list = taiKhoanBUS.LayTatCaTaiKhoan();
                dgv_Account.DataSource = list;
                dgv_Account.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_Account_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_Account.SelectedRows.Count > 0)
            {
                TaiKhoanDTO tk = dgv_Account.SelectedRows[0].DataBoundItem as TaiKhoanDTO;
                if (tk == null) return;

                taiKhoanDangChon = tk.TenDangNhap;

                txt_Username.Text = tk.TenDangNhap;
                txt_Password.Text = tk.MatKhau;
                txt_TenNhanVien.Text = tk.TenNhanVien;
                cmb_Role.Text = tk.VaiTro;

                bool isActive = tk.TrangThai == 1;
                chk_Active.Checked = isActive;
                chk_Lock.Checked = !isActive;

                txt_Username.ReadOnly = true;
            }
        }

        private void dgv_Account_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_Account.Columns[e.ColumnIndex].Name == "colSTT" && e.RowIndex >= 0)
            {
                e.Value = e.RowIndex + 1;
            }

            if (dgv_Account.Columns[e.ColumnIndex].DataPropertyName == "TrangThaiText" && e.Value != null)
            {
                if (e.Value.ToString() == "Kích Hoạt") e.CellStyle.ForeColor = Color.Green;
                else e.CellStyle.ForeColor = Color.Red;
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            LoadTatCaDuLieu();

            taiKhoanDangChon = "";
            txt_Username.Clear();
            txt_Password.Clear();
            txt_TenNhanVien.Clear();
            txt_Find.Clear();
            cmb_Role.SelectedIndex = -1;

            chk_Active.Checked = true;
            chk_Lock.Checked = false;

            txt_Username.ReadOnly = false;
            txt_Username.Focus();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                TaiKhoanDTO tk = new TaiKhoanDTO
                {
                    TenDangNhap = txt_Username.Text.Trim(),
                    MatKhau = txt_Password.Text.Trim(),
                    TenNhanVien = txt_TenNhanVien.Text.Trim(),
                    VaiTro = cmb_Role.Text,
                    TrangThai = chk_Active.Checked ? 1 : 0
                };

                taiKhoanBUS.ThemTaiKhoan(tk);
                MessageBox.Show("Tạo tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                TaiKhoanDTO tk = new TaiKhoanDTO
                {
                    TenDangNhap = taiKhoanDangChon,
                    MatKhau = txt_Password.Text.Trim(),
                    TenNhanVien = txt_TenNhanVien.Text.Trim(),
                    VaiTro = cmb_Role.Text,
                    TrangThai = chk_Active.Checked ? 1 : 0
                };

                taiKhoanBUS.SuaTaiKhoan(tk);
                MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTatCaDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Chắc chắn xóa tài khoản '{taiKhoanDangChon}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    taiKhoanBUS.XoaTaiKhoan(taiKhoanDangChon);
                    MessageBox.Show("Đã xóa tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                List<TaiKhoanDTO> list = taiKhoanBUS.TimKiemChung(tuKhoa);
                dgv_Account.DataSource = list;
                if (list.Count == 0)
                    MessageBox.Show("Không tìm thấy kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                TaiKhoanDTO dieuKien = new TaiKhoanDTO
                {
                    TenDangNhap = txt_Username.Text.Trim(),
                    TenNhanVien = txt_TenNhanVien.Text.Trim(),
                    VaiTro = cmb_Role.Text,
                    TrangThai = chk_Active.Checked ? 1 : 0
                };

                List<TaiKhoanDTO> list = taiKhoanBUS.TimKiemChiTiet(dieuKien);
                dgv_Account.DataSource = list;

                if (list.Count == 0)
                    MessageBox.Show("Không tìm thấy kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                // Giả định bạn có ucLuaChonHeThong hoặc quay lại màn hình chính
            }
        }
    }
}
