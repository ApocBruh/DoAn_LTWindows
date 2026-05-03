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

            // Nối sự kiện STT (Thêm dòng này)a

            dgv_TuyenXe.DefaultCellStyle.ForeColor = Color.Black;

            // Tùy chọn: Ép màu chữ của cột tiêu đề (Header) thành màu đen luôn cho chắc chắn
            dgv_TuyenXe.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            // 1. Ép tiêu đề (Header) căn giữa
            dgv_TuyenXe.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 2. Ép nội dung các ô (Cells) căn trái
            dgv_TuyenXe.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

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
            // Bước 1: Làm mới bảng dữ liệu trước (Nó sẽ tự động bị bỏ chọn dòng nhờ code ở trên)
            LoadTatCaDuLieu();

            // Bước 2: BÂY GIỜ mới tiến hành mở khóa và xóa trắng các ô nhập liệu
            txt_MaTuyen.ReadOnly = false;

            txt_MaTuyen.Clear();
            txt_TenTuyen.Clear();
            txt_Start.Clear();
            txt_End.Clear();
            nud_Distance.Value = 0;
            nud_Time.Value = 0;
            txt_Find.Clear();

            // Đưa con trỏ chuột nháy sẵn ở ô Mã Tuyến để người dùng gõ ngay
            txt_MaTuyen.Focus();
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
        // --- TÌM KIẾM CHUNG CHUNG (THANH TÌM KIẾM TRÊN CÙNG) ---
        private void btn_FindData_Click(object sender, EventArgs e)
        {
            string tuKhoa = txt_Find.Text.Trim();

            // Nếu người dùng xóa sạch thanh tìm kiếm và bấm -> Load lại toàn bộ
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
                    // Dùng CAST để tránh lỗi tìm chữ trong cột số nguyên
                    string query = @"SELECT MaTuyen, TenTuyen, DiemXuatPhat, DiemDen, KhoangCach, ThoiGianChay 
                                     FROM TuyenXe 
                                     WHERE CAST(MaTuyen AS VARCHAR) LIKE @TuKhoa 
                                        OR TenTuyen LIKE @TuKhoa 
                                        OR DiemXuatPhat LIKE @TuKhoa 
                                        OR DiemDen LIKE @TuKhoa";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgv_TuyenXe.DataSource = dt;

                    if (dt.Rows.Count == 0)
                        MessageBox.Show("Không tìm thấy tuyến xe nào khớp với từ khóa!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show("Lỗi tìm kiếm: " + ex.Message); }
            }
        }

        // --- TÌM KIẾM CHI TIẾT (LỌC THEO CÁC Ô NHẬP LIỆU BÊN TRONG PANEL) ---
        private void btn_Find_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem tất cả các ô có đang trống/bằng 0 hay không
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

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Tạo một danh sách chứa các điều kiện lọc
                    List<string> conditions = new List<string>();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    if (!string.IsNullOrWhiteSpace(txt_MaTuyen.Text))
                    {
                        conditions.Add("MaTuyen = @Ma");
                        cmd.Parameters.AddWithValue("@Ma", txt_MaTuyen.Text.Trim());
                    }
                    if (!string.IsNullOrWhiteSpace(txt_TenTuyen.Text))
                    {
                        conditions.Add("TenTuyen LIKE @Ten");
                        cmd.Parameters.AddWithValue("@Ten", "%" + txt_TenTuyen.Text.Trim() + "%");
                    }
                    if (!string.IsNullOrWhiteSpace(txt_Start.Text))
                    {
                        conditions.Add("DiemXuatPhat LIKE @Start");
                        cmd.Parameters.AddWithValue("@Start", "%" + txt_Start.Text.Trim() + "%");
                    }
                    if (!string.IsNullOrWhiteSpace(txt_End.Text))
                    {
                        conditions.Add("DiemDen LIKE @End");
                        cmd.Parameters.AddWithValue("@End", "%" + txt_End.Text.Trim() + "%");
                    }
                    // Với số, chỉ tìm nếu người dùng nhập số lớn hơn 0
                    if (nud_Distance.Value > 0)
                    {
                        conditions.Add("KhoangCach = @KhoangCach");
                        cmd.Parameters.AddWithValue("@KhoangCach", nud_Distance.Value);
                    }
                    if (nud_Time.Value > 0)
                    {
                        conditions.Add("ThoiGianChay = @ThoiGian");
                        cmd.Parameters.AddWithValue("@ThoiGian", nud_Time.Value);
                    }

                    // Ghép các điều kiện lại với chữ AND
                    string query = "SELECT MaTuyen, TenTuyen, DiemXuatPhat, DiemDen, KhoangCach, ThoiGianChay FROM TuyenXe";
                    if (conditions.Count > 0)
                    {
                        query += " WHERE " + string.Join(" AND ", conditions);
                    }

                    cmd.CommandText = query;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv_TuyenXe.DataSource = dt;

                    if (dt.Rows.Count == 0)
                        MessageBox.Show("Không có tuyến xe nào thỏa mãn các tiêu chí lọc này!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lọc chi tiết (Vui lòng nhập đúng số cho Mã Tuyến): " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- TỰ ĐỘNG ĐÁNH SỐ THỨ TỰ CHO BẢNG ---
        private void dgv_TuyenXe_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Lưu ý: Đảm bảo bạn đã đặt tên (thuộc tính Name) cho cột STT trong UI Design là "colSTT"
            if (dgv_TuyenXe.Columns[e.ColumnIndex].Name == "colSTT" && e.RowIndex >= 0)
            {
                e.Value = e.RowIndex + 1;
            }
        }

        // --- NÚT QUAY LẠI MÀN HÌNH CHỌN LỊCH TRÌNH ---
        private void btn_Return_Click(object sender, EventArgs e)
        {
            Panel pnlParent = (Panel)this.Parent;
            if (pnlParent != null)
            {
                pnlParent.Controls.Clear();

                // Gọi User Control Menu Lựa Chọn ra
                ucLuaChonLichTrinh uc = new ucLuaChonLichTrinh();
                uc.Dock = DockStyle.Fill;
                pnlParent.Controls.Add(uc);
            }
        }

        // --- 1. HÀM TẢI TOÀN BỘ DỮ LIỆU ---
        private void LoadTatCaDuLieu()
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

                    // THÊM DÒNG NÀY: Ép bảng không được tự động chọn dòng đầu tiên lúc mới load
                    dgv_TuyenXe.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải toàn bộ dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
