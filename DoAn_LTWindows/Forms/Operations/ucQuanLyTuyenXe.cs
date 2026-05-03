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
        string connectionString = @"Data Source=DESKTOP-QG0J4IU;Initial Catalog=QLBanVeXeBuyt;Integrated Security=True";

        public ucQuanLyTuyenXe()
        {
            InitializeComponent();

            // Ép dgv_TuyenXe chọn nguyên dòng và chỉ đọc
            dgv_TuyenXe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_TuyenXe.ReadOnly = true;
            dgv_TuyenXe.AutoGenerateColumns = false; // Ngăn SQL tự đẻ cột

            // Cài đặt DataGridView (Gọi hàm nối dây sự kiện bằng code cho chắc chắn)
            dgv_TuyenXe.SelectionChanged += dgv_TuyenXe_SelectionChanged;
        }

        private void ucQuanLyTuyenXe_Load(object sender, EventArgs e)
        {
            // Tùy chỉnh màu sắc lưới
            dgv_TuyenXe.DefaultCellStyle.ForeColor = Color.Black;
            dgv_TuyenXe.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            LoadData();
        }

        // --- 1. HÀM TẢI DỮ LIỆU ---
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT MaTuyen, TenTuyen, DiemXuatPhat, DiemDen, KhoangCach, ThoiGianChay FROM TuyenXe";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv_TuyenXe.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- 2. HIỂN THỊ DỮ LIỆU TỪ BẢNG LÊN TEXTBOX ---
        private void dgv_TuyenXe_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_TuyenXe.SelectedRows.Count > 0)
            {
                DataRowView drv = dgv_TuyenXe.SelectedRows[0].DataBoundItem as DataRowView;
                if (drv == null) return;

                txt_MaTuyen.Text = drv["MaTuyen"].ToString();
                txt_TenTuyen.Text = drv["TenTuyen"].ToString();
                txt_Start.Text = drv["DiemXuatPhat"].ToString();
                txt_End.Text = drv["DiemDen"].ToString();

                // Gán giá trị cho NumericUpDown (cần ép kiểu an toàn)
                decimal distance, time;
                decimal.TryParse(drv["KhoangCach"].ToString(), out distance);
                decimal.TryParse(drv["ThoiGianChay"].ToString(), out time);

                nud_Distance.Value = distance;
                nud_Time.Value = time;

                // Khóa Mã Tuyến lại không cho sửa khi đang chọn dòng (Tránh lỗi Key)
                txt_MaTuyen.ReadOnly = true;
            }
        }

        // --- 3. NÚT ĐẶT LẠI (RESET FORM) ---
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            txt_MaTuyen.Clear();
            txt_TenTuyen.Clear();
            txt_Start.Clear();
            txt_End.Clear();
            nud_Distance.Value = 0;
            nud_Time.Value = 0;
            txt_Find.Clear();

            txt_MaTuyen.ReadOnly = false; // Mở khóa để thêm mới
            txt_MaTuyen.Focus();

            LoadData(); // Tải lại toàn bộ dữ liệu
        }

        // --- 4. NÚT LƯU (THÊM MỚI) ---
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_MaTuyen.Text) || string.IsNullOrWhiteSpace(txt_TenTuyen.Text))
            {
                MessageBox.Show("Mã Tuyến và Tên Tuyến không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Kiểm tra xem mã tuyến đã tồn tại chưa
                    string checkQuery = "SELECT COUNT(*) FROM TuyenXe WHERE MaTuyen = @MaTuyen";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@MaTuyen", txt_MaTuyen.Text.Trim());
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Mã Tuyến này đã tồn tại! Nếu muốn cập nhật, vui lòng dùng nút SỬA.", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    string query = @"INSERT INTO TuyenXe (MaTuyen, TenTuyen, DiemXuatPhat, DiemDen, KhoangCach, ThoiGianChay) 
                                     VALUES (@Ma, @Ten, @BatDau, @KetThuc, @KhoangCach, @ThoiGian)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Ma", txt_MaTuyen.Text.Trim());
                    cmd.Parameters.AddWithValue("@Ten", txt_TenTuyen.Text.Trim());
                    cmd.Parameters.AddWithValue("@BatDau", txt_Start.Text.Trim());
                    cmd.Parameters.AddWithValue("@KetThuc", txt_End.Text.Trim());
                    cmd.Parameters.AddWithValue("@KhoangCach", nud_Distance.Value);
                    cmd.Parameters.AddWithValue("@ThoiGian", nud_Time.Value);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm tuyến xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_Reset_Click(null, null); // Load lại bảng và làm sạch form
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        // --- 5. NÚT SỬA (CẬP NHẬT) ---
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_MaTuyen.Text)) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE TuyenXe 
                                     SET TenTuyen = @Ten, DiemXuatPhat = @BatDau, DiemDen = @KetThuc, KhoangCach = @KhoangCach, ThoiGianChay = @ThoiGian 
                                     WHERE MaTuyen = @Ma";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Ma", txt_MaTuyen.Text.Trim());
                    cmd.Parameters.AddWithValue("@Ten", txt_TenTuyen.Text.Trim());
                    cmd.Parameters.AddWithValue("@BatDau", txt_Start.Text.Trim());
                    cmd.Parameters.AddWithValue("@KetThuc", txt_End.Text.Trim());
                    cmd.Parameters.AddWithValue("@KhoangCach", nud_Distance.Value);
                    cmd.Parameters.AddWithValue("@ThoiGian", nud_Time.Value);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        // --- 6. NÚT XÓA ---
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_MaTuyen.Text)) return;

            if (MessageBox.Show($"Bạn có chắc chắn muốn XÓA tuyến: {txt_TenTuyen.Text}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM TuyenXe WHERE MaTuyen = @Ma";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Ma", txt_MaTuyen.Text.Trim());

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đã xóa tuyến xe khỏi hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btn_Reset_Click(null, null);
                    }
                    catch (SqlException ex)
                    {
                        // Bắt lỗi khóa ngoại nếu tuyến xe này đã có chuyến xe hoặc vé đang tham chiếu tới
                        if (ex.Number == 547)
                            MessageBox.Show("Không thể xóa tuyến xe này vì đang có dữ liệu (Chuyến xe/Vé) liên kết với nó!", "Lỗi khóa ngoại", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        else
                            MessageBox.Show("Lỗi CSDL: " + ex.Message);
                    }
                }
            }
        }

        // --- 7. NÚT TÌM KIẾM (TRÊN THANH TÌM KIẾM) ---
        private void btn_FindData_Click(object sender, EventArgs e)
        {
            string tuKhoa = txt_Find.Text.Trim();
            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                LoadData();
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Tìm kiếm tương đối (%LIKE%) theo Mã Tuyến HOẶC Tên Tuyến
                    string query = @"SELECT MaTuyen, TenTuyen, DiemXuatPhat, DiemDen, KhoangCach, ThoiGianChay 
                                     FROM TuyenXe 
                                     WHERE MaTuyen LIKE @TuKhoa OR TenTuyen LIKE @TuKhoa";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv_TuyenXe.DataSource = dt;

                    if (dt.Rows.Count == 0)
                        MessageBox.Show("Không tìm thấy dữ liệu khớp với từ khóa!", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }
    }
}
