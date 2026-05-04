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
    public partial class ucQuanLyXe : UserControl
    {
        private XeBUS xeBUS = new XeBUS();
        private int maXeDangChon = -1;

        public ucQuanLyXe()
        {
            InitializeComponent();

            dgv_Xe.AutoGenerateColumns = false;
            dgv_Xe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Xe.ReadOnly = true;

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

        private void ucQuanLyXe_Load(object sender, EventArgs e)
        {
            dgv_Xe.DefaultCellStyle.ForeColor = Color.Black;
            dgv_Xe.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            cmb_LoaiXe.Items.AddRange(new string[] { "Ghế Ngồi", "Giường Nằm", "Limousine", "Xe Bus Đứng" });
            cmb_TinhTrang.Items.AddRange(new string[] { "Hoạt động", "Đang bảo trì", "Ngừng hoạt động" });

            LoadTatCaDuLieu();
        }

        private void LoadTatCaDuLieu()
        {
            try
            {
                List<XeDTO> list = xeBUS.LayDanhSachXe();
                dgv_Xe.DataSource = list;
                dgv_Xe.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_Xe_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_Xe.SelectedRows.Count > 0)
            {
                XeDTO xe = dgv_Xe.SelectedRows[0].DataBoundItem as XeDTO;
                if (xe == null) return;

                maXeDangChon = xe.MaXe;
                txt_BienSoXe.Text = xe.BienSo;
                cmb_LoaiXe.Text = xe.LoaiXe;
                nud_SoGhe.Value = xe.SoGhe;
                cmb_TinhTrang.Text = xe.TinhTrang;
            }
        }

        private void dgv_Xe_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_Xe.Columns[e.ColumnIndex].Name == "colSTT" && e.RowIndex >= 0)
            {
                e.Value = e.RowIndex + 1;
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            LoadTatCaDuLieu();

            maXeDangChon = -1;
            txt_BienSoXe.Clear();
            cmb_LoaiXe.SelectedIndex = -1;
            cmb_TinhTrang.SelectedIndex = -1;
            nud_SoGhe.Value = 1;
            txt_Find.Clear();

            txt_BienSoXe.Focus();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                XeDTO xe = new XeDTO
                {
                    BienSo = txt_BienSoXe.Text.Trim(),
                    LoaiXe = cmb_LoaiXe.Text,
                    SoGhe = (int)nud_SoGhe.Value,
                    TinhTrang = cmb_TinhTrang.Text
                };

                xeBUS.ThemXe(xe);
                MessageBox.Show("Thêm xe mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                XeDTO xe = new XeDTO
                {
                    MaXe = maXeDangChon,
                    BienSo = txt_BienSoXe.Text.Trim(),
                    LoaiXe = cmb_LoaiXe.Text,
                    SoGhe = (int)nud_SoGhe.Value,
                    TinhTrang = cmb_TinhTrang.Text
                };

                xeBUS.SuaXe(xe);
                MessageBox.Show("Cập nhật thông tin xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTatCaDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (maXeDangChon == -1) return;

            if (MessageBox.Show($"Bạn có chắc muốn xóa xe {txt_BienSoXe.Text}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    xeBUS.XoaXe(maXeDangChon);
                    MessageBox.Show("Đã xóa xe khỏi hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_Reset_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi khóa ngoại", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                List<XeDTO> list = xeBUS.TimKiemChung(tuKhoa);
                dgv_Xe.DataSource = list;
                if (list.Count == 0)
                    MessageBox.Show("Không tìm thấy xe phù hợp tiêu chí!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                XeDTO dieuKien = new XeDTO
                {
                    BienSo = txt_BienSoXe.Text.Trim(),
                    LoaiXe = cmb_LoaiXe.Text,
                    SoGhe = (int)nud_SoGhe.Value,
                    TinhTrang = cmb_TinhTrang.Text
                };

                List<XeDTO> list = xeBUS.TimKiemChiTiet(dieuKien);
                dgv_Xe.DataSource = list;

                if (list.Count == 0)
                    MessageBox.Show("Không tìm thấy xe phù hợp tiêu chí!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
