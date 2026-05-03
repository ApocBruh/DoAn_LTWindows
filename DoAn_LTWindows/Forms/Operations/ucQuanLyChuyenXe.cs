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
        string connectionString = @"Data Source=DESKTOP-QG0J4IU;Initial Catalog=QLBanVeXeBuyt;Integrated Security=True";

        private int maChuyenDangChon = -1;

        public ucQuanLyChuyenXe()
        {
            InitializeComponent();

            dgv_ChuyenXe.AutoGenerateColumns = false;
            dgv_ChuyenXe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ChuyenXe.ReadOnly = true;

            btn_Delete.MouseDown += (s, e) => {
                btn_Delete.BackgroundImage = Properties.Resources._75pxbtn1_c;
            };

            btn_Delete.MouseUp += (s, e) => {
                btn_Delete.BackgroundImage = Properties.Resources._75pxbtn1;
            };

            btn_Edit.MouseDown += (s, e) => {
                btn_Edit.BackgroundImage = Properties.Resources._75pxbtn1_c;
            };

            btn_Edit.MouseUp += (s, e) => {
                btn_Edit.BackgroundImage = Properties.Resources._75pxbtn1;
            };

            btn_Find.MouseDown += (s, e) => {
                btn_Find.BackgroundImage = Properties.Resources._75pxbtn1_c;
            };

            btn_Find.MouseUp += (s, e) => {
                btn_Find.BackgroundImage = Properties.Resources._75pxbtn1;
            };

            btn_FindData.MouseDown += (s, e) => {
                btn_FindData.BackgroundImage = Properties.Resources._75pxbtn1_c;
            };

            btn_FindData.MouseUp += (s, e) => {
                btn_FindData.BackgroundImage = Properties.Resources._75pxbtn1;
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

            btn_Save.MouseDown += (s, e) => {
                btn_Save.BackgroundImage = Properties.Resources._75pxbtn1_c;
            };

            btn_Save.MouseUp += (s, e) => {
                btn_Save.BackgroundImage = Properties.Resources._75pxbtn1;
            };
        }

        private void ucQuanLyChuyenXe_Load(object sender, EventArgs e)
        {
            dgv_ChuyenXe.DefaultCellStyle.ForeColor = Color.Black;
            dgv_ChuyenXe.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            LoadComboBoxes();
            LoadTatCaDuLieu();
        }

        // --- 1. TẢI COMBOBOX (TUYẾN & XE) ---
        private void LoadComboBoxes()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Load ComboBox Tuyến
                    SqlDataAdapter daTuyen = new SqlDataAdapter("SELECT MaTuyen, TenTuyen FROM TuyenXe", conn);
                    DataTable dtTuyen = new DataTable();
                    daTuyen.Fill(dtTuyen);
                    cmb_Tuyen.DataSource = dtTuyen;
                    cmb_Tuyen.DisplayMember = "TenTuyen";
                    cmb_Tuyen.ValueMember = "MaTuyen";
                    cmb_Tuyen.SelectedIndex = -1;

                    // Load ComboBox Xe
                    SqlDataAdapter daXe = new SqlDataAdapter("SELECT MaXe, BienSo + ' (' + LoaiXe + ')' AS ThongTinXe FROM Xe", conn);
                    DataTable dtXe = new DataTable();
                    daXe.Fill(dtXe);
                    cmb_Xe.DataSource = dtXe;
                    cmb_Xe.DisplayMember = "ThongTinXe";
                    cmb_Xe.ValueMember = "MaXe";
                    cmb_Xe.SelectedIndex = -1;
                }
                catch (Exception ex) { MessageBox.Show("Lỗi tải danh mục: " + ex.Message); }
            }
        }

        // --- 2. TẢI DỮ LIỆU LÊN BẢNG ---
        private void LoadTatCaDuLieu()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // JOIN 3 Bảng để lấy Tên Tuyến và Biển Số Xe thay vì chỉ hiển thị ID
                    string query = @"
                        SELECT c.MaChuyen, c.MaTuyen, c.MaXe, t.TenTuyen, x.BienSo, c.GiaVe, c.ThoiGianXuatBen 
                        FROM ChuyenXe c
                        JOIN TuyenXe t ON c.MaTuyen = t.MaTuyen
                        JOIN Xe x ON c.MaXe = x.MaXe
                        ORDER BY c.ThoiGianXuatBen DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgv_ChuyenXe.DataSource = dt;
                    dgv_ChuyenXe.ClearSelection();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
            }
        }

        // --- 3. HIỂN THỊ CHI TIẾT KHI CLICK ---
        private void dgv_ChuyenXe_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ChuyenXe.SelectedRows.Count > 0)
            {
                DataRowView drv = dgv_ChuyenXe.SelectedRows[0].DataBoundItem as DataRowView;
                if (drv == null) return;

                // Lưu lại Mã Chuyến vào biến ngầm để dùng cho Update/Delete
                maChuyenDangChon = Convert.ToInt32(drv["MaChuyen"]);

                cmb_Tuyen.SelectedValue = drv["MaTuyen"];
                cmb_Xe.SelectedValue = drv["MaXe"];

                // Format giá vé bỏ đuôi thập phân .00
                txt_Price.Text = Convert.ToDecimal(drv["GiaVe"]).ToString("0");
                dtp_DateTime.Value = Convert.ToDateTime(drv["ThoiGianXuatBen"]);
            }
        }

        // --- 4. FORMAT STT VÀ GIÁ VÉ ---
        private void dgv_ChuyenXe_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_ChuyenXe.Columns[e.ColumnIndex].Name == "colSTT" && e.RowIndex >= 0)
            {
                e.Value = e.RowIndex + 1;
            }
            // Thêm phẩy phân cách hàng nghìn cho Giá Vé (Tùy chọn)
            if (dgv_ChuyenXe.Columns[e.ColumnIndex].DataPropertyName == "GiaVe" && e.Value != null)
            {
                e.Value = Convert.ToDecimal(e.Value).ToString("N0") + " VNĐ";
                e.FormattingApplied = true;
            }
            // Format ngày giờ hiển thị trên lưới
            if (dgv_ChuyenXe.Columns[e.ColumnIndex].DataPropertyName == "ThoiGianXuatBen" && e.Value != null)
            {
                e.Value = Convert.ToDateTime(e.Value).ToString("dd/MM/yyyy HH:mm");
                e.FormattingApplied = true;
            }
        }

        // --- 5. NÚT ĐẶT LẠI ---
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            LoadTatCaDuLieu();

            maChuyenDangChon = -1; // Xóa biến ngầm
            cmb_Tuyen.SelectedIndex = -1;
            cmb_Xe.SelectedIndex = -1;
            txt_Price.Clear();
            dtp_DateTime.Value = DateTime.Now;
            txt_Find.Clear();
        }

        // --- 6. NÚT LƯU (THÊM MỚI) ---
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (cmb_Tuyen.SelectedIndex == -1 || cmb_Xe.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Tuyến Xe và Xe!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal giaVe;
            if (!decimal.TryParse(txt_Price.Text.Trim(), out giaVe))
            {
                MessageBox.Show("Giá vé không hợp lệ! Vui lòng chỉ nhập số.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO ChuyenXe (MaTuyen, MaXe, GiaVe, ThoiGianXuatBen) 
                                     VALUES (@MaTuyen, @MaXe, @GiaVe, @ThoiGian)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaTuyen", cmb_Tuyen.SelectedValue);
                    cmd.Parameters.AddWithValue("@MaXe", cmb_Xe.SelectedValue);
                    cmd.Parameters.AddWithValue("@GiaVe", giaVe);
                    cmd.Parameters.AddWithValue("@ThoiGian", dtp_DateTime.Value);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm chuyến xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_Reset_Click(null, null);
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        // --- 7. NÚT SỬA ---
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (maChuyenDangChon == -1)
            {
                MessageBox.Show("Vui lòng chọn một chuyến xe trên lưới để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal giaVe;
            if (!decimal.TryParse(txt_Price.Text.Trim(), out giaVe)) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE ChuyenXe 
                                     SET MaTuyen = @MaTuyen, MaXe = @MaXe, GiaVe = @GiaVe, ThoiGianXuatBen = @ThoiGian 
                                     WHERE MaChuyen = @MaChuyen";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaChuyen", maChuyenDangChon);
                    cmd.Parameters.AddWithValue("@MaTuyen", cmb_Tuyen.SelectedValue);
                    cmd.Parameters.AddWithValue("@MaXe", cmb_Xe.SelectedValue);
                    cmd.Parameters.AddWithValue("@GiaVe", giaVe);
                    cmd.Parameters.AddWithValue("@ThoiGian", dtp_DateTime.Value);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTatCaDuLieu();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        // --- 8. NÚT XÓA ---
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (maChuyenDangChon == -1) return;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa chuyến xe này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM ChuyenXe WHERE MaChuyen = @MaChuyen", conn);
                        cmd.Parameters.AddWithValue("@MaChuyen", maChuyenDangChon);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Đã xóa chuyến xe!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btn_Reset_Click(null, null);
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 547)
                            MessageBox.Show("Không thể xóa chuyến xe vì đã có vé được bán thuộc chuyến này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        else
                            MessageBox.Show("Lỗi CSDL: " + ex.Message);
                    }
                }
            }
        }

        // --- 9. TÌM KIẾM CHUNG (Ô TRÊN CÙNG) ---
        private void btn_FindData_Click(object sender, EventArgs e)
        {
            string tuKhoa = txt_Find.Text.Trim();
            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                LoadTatCaDuLieu();
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT c.MaChuyen, c.MaTuyen, c.MaXe, t.TenTuyen, x.BienSo, c.GiaVe, c.ThoiGianXuatBen 
                        FROM ChuyenXe c
                        JOIN TuyenXe t ON c.MaTuyen = t.MaTuyen
                        JOIN Xe x ON c.MaXe = x.MaXe
                        WHERE t.TenTuyen LIKE @TuKhoa OR x.BienSo LIKE @TuKhoa";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv_ChuyenXe.DataSource = dt;
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        // --- 10. TÌM KIẾM CHI TIẾT (LỌC TRONG PANEL) ---
        private void btn_Find_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    List<string> conditions = new List<string>();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    if (cmb_Tuyen.SelectedIndex != -1)
                    {
                        conditions.Add("c.MaTuyen = @MaTuyen");
                        cmd.Parameters.AddWithValue("@MaTuyen", cmb_Tuyen.SelectedValue);
                    }
                    if (cmb_Xe.SelectedIndex != -1)
                    {
                        conditions.Add("c.MaXe = @MaXe");
                        cmd.Parameters.AddWithValue("@MaXe", cmb_Xe.SelectedValue);
                    }

                    decimal giaVe;
                    if (decimal.TryParse(txt_Price.Text.Trim(), out giaVe))
                    {
                        conditions.Add("c.GiaVe = @GiaVe");
                        cmd.Parameters.AddWithValue("@GiaVe", giaVe);
                    }

                    // Chỉ lọc theo "Ngày" xuất bến (bỏ qua Giờ để dễ tìm)
                    conditions.Add("CAST(c.ThoiGianXuatBen AS DATE) = @NgayXuatBen");
                    cmd.Parameters.AddWithValue("@NgayXuatBen", dtp_DateTime.Value.Date);

                    string query = @"
                        SELECT c.MaChuyen, c.MaTuyen, c.MaXe, t.TenTuyen, x.BienSo, c.GiaVe, c.ThoiGianXuatBen 
                        FROM ChuyenXe c
                        JOIN TuyenXe t ON c.MaTuyen = t.MaTuyen
                        JOIN Xe x ON c.MaXe = x.MaXe";

                    if (conditions.Count > 0)
                    {
                        query += " WHERE " + string.Join(" AND ", conditions);
                    }

                    cmd.CommandText = query;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv_ChuyenXe.DataSource = dt;

                    if (dt.Rows.Count == 0)
                        MessageBox.Show("Không tìm thấy chuyến xe phù hợp!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        // --- 11. QUAY LẠI ---
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
