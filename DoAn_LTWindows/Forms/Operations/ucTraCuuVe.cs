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
    public partial class ucTraCuuVe : UserControl
    {
        private TraCuuVeBUS traCuuVeBUS = new TraCuuVeBUS();

        public ucTraCuuVe()
        {
            InitializeComponent();
            dgv_Ve.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Ve.AutoGenerateColumns = false;
            dgv_Ve.SelectionChanged += dgv_Ve_SelectionChanged;

            // Hiệu ứng nút bấm (Giữ nguyên)
            btn_FindMaSoVe.MouseDown += (s, e) => { btn_FindMaSoVe.BackgroundImage = Properties.Resources._75pxbtn1_c; };
            btn_FindMaSoVe.MouseUp += (s, e) => { btn_FindMaSoVe.BackgroundImage = Properties.Resources._75pxbtn1; };
            btn_FindSoDienThoai.MouseDown += (s, e) => { btn_FindSoDienThoai.BackgroundImage = Properties.Resources._75pxbtn1_c; };
            btn_FindSoDienThoai.MouseUp += (s, e) => { btn_FindSoDienThoai.BackgroundImage = Properties.Resources._75pxbtn1; };
            btn_Refund.MouseDown += (s, e) => { btn_Refund.BackgroundImage = Properties.Resources._75pxbtnd_c; };
            btn_Refund.MouseUp += (s, e) => { btn_Refund.BackgroundImage = Properties.Resources._75pxbtnd; };
            btn_Return.MouseDown += (s, e) => { btn_Return.BackgroundImage = Properties.Resources._75pxbtn1_c; };
            btn_Return.MouseUp += (s, e) => { btn_Return.BackgroundImage = Properties.Resources._75pxbtn1; };
        }

        private void ucTraCuuVe_Load(object sender, EventArgs e)
        {
            chk_MaVe.Checked = true;
            chk_SoDienThoai.Checked = false;
            lbl_Data.Text = "...";

            dgv_Ve.DefaultCellStyle.ForeColor = Color.Black;
            dgv_Ve.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv_Ve.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            LoadTatCaDuLieu();
        }

        private void chk_MaVe_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_MaVe.Checked)
            {
                chk_SoDienThoai.Checked = false;
                txt_MaSoVe.Enabled = true;
                btn_FindMaSoVe.Enabled = true;
                txt_SoDienThoai.Enabled = false;
                btn_FindSoDienThoai.Enabled = false;
                txt_SoDienThoai.Clear();
            }
        }

        private void chk_SoDienThoai_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_SoDienThoai.Checked)
            {
                chk_MaVe.Checked = false;
                txt_SoDienThoai.Enabled = true;
                btn_FindSoDienThoai.Enabled = true;
                txt_MaSoVe.Enabled = false;
                btn_FindMaSoVe.Enabled = false;
                txt_MaSoVe.Clear();
            }
        }

        private void LoadTatCaDuLieu()
        {
            try
            {
                List<VeXeDTO> listVe = traCuuVeBUS.LayDanhSachVe();
                dgv_Ve.DataSource = listVe;

                if (listVe.Count > 0)
                {
                    lbl_Data.Text = "Vui lòng chọn một vé trên lưới để xem chi tiết.";
                }
                else
                {
                    lbl_Data.Text = "...";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải toàn bộ dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TimKiem(string tuKhoa, bool timTheoMaVe)
        {
            try
            {
                List<VeXeDTO> listVe = traCuuVeBUS.LayDanhSachVe(tuKhoa, timTheoMaVe);
                dgv_Ve.DataSource = listVe;

                if (listVe.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy vé!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lbl_Data.Text = "...";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_FindMaSoVe_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_MaSoVe.Text))
            {
                LoadTatCaDuLieu();
                return;
            }
            TimKiem(txt_MaSoVe.Text.Trim(), true);
        }

        private void btn_FindSoDienThoai_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_SoDienThoai.Text))
            {
                LoadTatCaDuLieu();
                return;
            }
            TimKiem(txt_SoDienThoai.Text.Trim(), false);
        }

        private void dgv_Ve_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_Ve.SelectedRows.Count > 0)
            {
                // Thay vì dùng DataRowView khó hiểu, ta lấy luôn Object DTO ra
                VeXeDTO ve = dgv_Ve.SelectedRows[0].DataBoundItem as VeXeDTO;
                if (ve == null) return;

                try
                {
                    string strTrangThai = ve.TrangThai == 1 ? "HỢP LỆ" : "ĐÃ HỦY";
                    string sdt = string.IsNullOrEmpty(ve.SoDienThoai) ? "Không Có" : ve.SoDienThoai;

                    lbl_Data.Text = $"Mã Vé: {ve.MaSoVe} | SĐT: {sdt} | Trạng Thái: {strTrangThai}\n" +
                                    $"Loại: {ve.LoaiVe}  -  Tuyến xe: {ve.TuyenXe}\n" +
                                    $"Khởi hành: {ve.NgayDi:dd/MM/yyyy HH:mm} - Số tiền thanh toán: {ve.GiaVe:N0} VNĐ";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hiển thị dữ liệu: " + ex.Message, "Phát hiện lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Refund_Click(object sender, EventArgs e)
        {
            if (dgv_Ve.SelectedRows.Count == 0) return;

            VeXeDTO ve = dgv_Ve.SelectedRows[0].DataBoundItem as VeXeDTO;
            if (ve == null) return;

            if (MessageBox.Show($"Xác nhận hủy vé {ve.MaSoVe}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Lớp BUS sẽ lo việc kiểm tra ngoại lệ và gửi xuống DAL
                    traCuuVeBUS.HuyVe(ve);

                    MessageBox.Show("Hủy vé thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (chk_MaVe.Checked) btn_FindMaSoVe_Click(null, null);
                    else btn_FindSoDienThoai_Click(null, null);
                }
                catch (Exception ex)
                {
                    // Hứng lỗi báo về từ lớp BUS (Vé đã hủy, Chuyến đã khởi hành...)
                    MessageBox.Show(ex.Message, "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void dgv_Ve_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_Ve.Columns[e.ColumnIndex].Name == "colSTT" && e.RowIndex >= 0)
            {
                e.Value = e.RowIndex + 1;
            }

            if (dgv_Ve.Columns[e.ColumnIndex].DataPropertyName == "TrangThai" && e.Value != null)
            {
                int trangThai = Convert.ToInt32(e.Value);
                if (trangThai == 1)
                {
                    e.Value = "HỢP LỆ";
                    e.CellStyle.ForeColor = Color.Green;
                    e.CellStyle.Font = new Font(dgv_Ve.Font, FontStyle.Bold);
                }
                else
                {
                    e.Value = "ĐÃ HỦY";
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new Font(dgv_Ve.Font, FontStyle.Strikeout);
                }
                e.FormattingApplied = true;
            }
        }

        private void btn_Return_Click(object sender, EventArgs e)
        {
            frmMain.Instance.BackToDashboard();
        }
    }
}