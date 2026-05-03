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
        string connectionString = @"Data Source=DESKTOP-QG0J4IU;Initial Catalog=QLBanVeXeBuyt;Integrated Security=True";

        // Biến ngầm lưu trữ Tên Đăng Nhập đang chọn
        private string taiKhoanDangChon = "";

        public ucQuanLyTaiKhoan()
        {
            InitializeComponent();

            dgv_Account.AutoGenerateColumns = false;
            dgv_Account.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Account.ReadOnly = true;

            // Xử lý 2 Checkbox hất văng nhau (Chọn cái này thì bỏ cái kia)
            chk_Active.CheckedChanged += (s, e) => { if (chk_Active.Checked) chk_Lock.Checked = false; };
            chk_Lock.CheckedChanged += (s, e) => { if (chk_Lock.Checked) chk_Active.Checked = false; };

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

        private void ucQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            dgv_Account.DefaultCellStyle.ForeColor = Color.Black;
            dgv_Account.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            LoadTatCaDuLieu();
            btn_Reset_Click(null, null); // Set trạng thái mặc định
        }

        // --- 1. TẢI DỮ LIỆU ---
        private void LoadTatCaDuLieu()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Tạo cột ảo TrangThaiText để hiển thị lên DataGridView cho đẹp
                    string query = @"SELECT TenDangNhap, MatKhau, TenNhanVien, VaiTro, TrangThai,
                                     CASE WHEN TrangThai = 1 THEN N'Kích Hoạt' ELSE N'Khóa' END AS TrangThaiText
                                     FROM TaiKhoan";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgv_Account.DataSource = dt;
                    dgv_Account.ClearSelection();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
            }
        }

        // --- 2. HIỂN THỊ DỮ LIỆU LÊN FORM ---
        private void dgv_Account_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_Account.SelectedRows.Count > 0)
            {
                DataRowView drv = dgv_Account.SelectedRows[0].DataBoundItem as DataRowView;
                if (drv == null) return;

                taiKhoanDangChon = drv["TenDangNhap"].ToString();

                txt_Username.Text = taiKhoanDangChon;
                txt_Password.Text = drv["MatKhau"].ToString();
                txt_TenNhanVien.Text = drv["TenNhanVien"].ToString();
                cmb_Role.Text = drv["VaiTro"].ToString();

                bool isActive = Convert.ToBoolean(drv["TrangThai"]);
                chk_Active.Checked = isActive;
                chk_Lock.Checked = !isActive;

                // KHÓA TÊN ĐĂNG NHẬP (Không cho sửa Primary Key)
                txt_Username.ReadOnly = true;
            }
        }

        // --- 3. STT VÀ MÀU TRẠNG THÁI ---
        private void dgv_Account_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_Account.Columns[e.ColumnIndex].Name == "colSTT" && e.RowIndex >= 0)
            {
                e.Value = e.RowIndex + 1;
            }

            // Nhuộm màu trạng thái
            if (dgv_Account.Columns[e.ColumnIndex].DataPropertyName == "TrangThaiText" && e.Value != null)
            {
                if (e.Value.ToString() == "Kích Hoạt") e.CellStyle.ForeColor = Color.Green;
                else e.CellStyle.ForeColor = Color.Red;
            }
        }

        // --- 4. ĐẶT LẠI ---
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            LoadTatCaDuLieu();

            taiKhoanDangChon = "";
            txt_Username.Clear();
            txt_Password.Clear();
            txt_TenNhanVien.Clear();
            txt_Find.Clear();
            cmb_Role.SelectedIndex = -1;

            chk_Active.Checked = true; // Mặc định tạo tài khoản mới là kích hoạt
            chk_Lock.Checked = false;

            txt_Username.ReadOnly = false; // Mở khóa để thêm mới
            txt_Username.Focus();
        }

        // --- 5. LƯU (THÊM MỚI) ---
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Username.Text) || string.IsNullOrWhiteSpace(txt_Password.Text) ||
                string.IsNullOrWhiteSpace(txt_TenNhanVien.Text) || cmb_Role.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Check trùng lặp Tên Đăng Nhập
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @User", conn);
                    checkCmd.Parameters.AddWithValue("@User", txt_Username.Text.Trim());
                    if ((int)checkCmd.ExecuteScalar() > 0)
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    string query = @"INSERT INTO TaiKhoan (TenDangNhap, MatKhau, TenNhanVien, VaiTro, TrangThai) 
                                     VALUES (@User, @Pass, @Name, @Role, @Status)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@User", txt_Username.Text.Trim());
                    cmd.Parameters.AddWithValue("@Pass", txt_Password.Text.Trim());
                    cmd.Parameters.AddWithValue("@Name", txt_TenNhanVien.Text.Trim());
                    cmd.Parameters.AddWithValue("@Role", cmb_Role.Text);
                    cmd.Parameters.AddWithValue("@Status", chk_Active.Checked ? 1 : 0);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tạo tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_Reset_Click(null, null);
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        // --- 6. SỬA ---
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(taiKhoanDangChon))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txt_Password.Text) || string.IsNullOrWhiteSpace(txt_TenNhanVien.Text)) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Không cho sửa Username (khóa chính)
                    string query = @"UPDATE TaiKhoan 
                                     SET MatKhau = @Pass, TenNhanVien = @Name, VaiTro = @Role, TrangThai = @Status 
                                     WHERE TenDangNhap = @User";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@User", taiKhoanDangChon);
                    cmd.Parameters.AddWithValue("@Pass", txt_Password.Text.Trim());
                    cmd.Parameters.AddWithValue("@Name", txt_TenNhanVien.Text.Trim());
                    cmd.Parameters.AddWithValue("@Role", cmb_Role.Text);
                    cmd.Parameters.AddWithValue("@Status", chk_Active.Checked ? 1 : 0);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTatCaDuLieu();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        // --- 7. XÓA ---
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(taiKhoanDangChon)) return;

            if (taiKhoanDangChon.ToLower() == "admin")
            {
                MessageBox.Show("Bạn không thể xóa tài khoản Admin gốc của hệ thống!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show($"Chắc chắn xóa tài khoản '{taiKhoanDangChon}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM TaiKhoan WHERE TenDangNhap = @User", conn);
                        cmd.Parameters.AddWithValue("@User", taiKhoanDangChon);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Đã xóa tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btn_Reset_Click(null, null);
                    }
                    catch (Exception ex) { MessageBox.Show("Lỗi CSDL: " + ex.Message); }
                }
            }
        }

        // --- 8. TÌM KIẾM CHUNG ---
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
                    string query = @"SELECT TenDangNhap, MatKhau, TenNhanVien, VaiTro, TrangThai,
                                     CASE WHEN TrangThai = 1 THEN N'Kích Hoạt' ELSE N'Khóa' END AS TrangThaiText
                                     FROM TaiKhoan 
                                     WHERE TenDangNhap LIKE @TuKhoa OR TenNhanVien LIKE @TuKhoa";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv_Account.DataSource = dt;
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        // --- 9. TÌM KIẾM CHI TIẾT ---
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

                    if (!string.IsNullOrWhiteSpace(txt_Username.Text))
                    {
                        conditions.Add("TenDangNhap LIKE @User");
                        cmd.Parameters.AddWithValue("@User", "%" + txt_Username.Text.Trim() + "%");
                    }
                    if (!string.IsNullOrWhiteSpace(txt_TenNhanVien.Text))
                    {
                        conditions.Add("TenNhanVien LIKE @Name");
                        cmd.Parameters.AddWithValue("@Name", "%" + txt_TenNhanVien.Text.Trim() + "%");
                    }
                    if (cmb_Role.SelectedIndex != -1)
                    {
                        conditions.Add("VaiTro = @Role");
                        cmd.Parameters.AddWithValue("@Role", cmb_Role.Text);
                    }
                    // Lọc theo trạng thái Checkbox
                    conditions.Add("TrangThai = @Status");
                    cmd.Parameters.AddWithValue("@Status", chk_Active.Checked ? 1 : 0);

                    string query = @"SELECT TenDangNhap, MatKhau, TenNhanVien, VaiTro, TrangThai,
                                     CASE WHEN TrangThai = 1 THEN N'Kích Hoạt' ELSE N'Khóa' END AS TrangThaiText 
                                     FROM TaiKhoan WHERE " + string.Join(" AND ", conditions);

                    cmd.CommandText = query;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv_Account.DataSource = dt;

                    if (dt.Rows.Count == 0) MessageBox.Show("Không tìm thấy kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        // --- 10. QUAY LẠI ---
        private void btn_Return_Click(object sender, EventArgs e)
        {
            Panel pnlParent = (Panel)this.Parent;
            if (pnlParent != null)
            {
                pnlParent.Controls.Clear();
                // Giả định bạn có ucLuaChonHeThong hoặc quay lại màn hình chính
                // ucLuaChonHeThong uc = new ucLuaChonHeThong();
                // uc.Dock = DockStyle.Fill;
                // pnlParent.Controls.Add(uc);
            }
        }
    }
}
