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
        string connectionString = @"Data Source=DESKTOP-QG0J4IU;Initial Catalog=QLBanVeXeBuyt;Integrated Security=True";

        private int maXeDangChon = -1;

        public ucQuanLyXe()
        {
            InitializeComponent();

            dgv_Xe.AutoGenerateColumns = false;
            dgv_Xe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Xe.ReadOnly = true;

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

        private void ucQuanLyXe_Load(object sender, EventArgs e)
        {
            dgv_Xe.DefaultCellStyle.ForeColor = Color.Black;
            dgv_Xe.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            // Nạp dữ liệu cứng cho 2 ComboBox
            cmb_LoaiXe.Items.AddRange(new string[] { "Ghế Ngồi", "Giường Nằm", "Limousine", "Xe Bus Đứng" });
            cmb_TinhTrang.Items.AddRange(new string[] { "Hoạt động", "Đang bảo trì", "Ngừng hoạt động" });

            LoadTatCaDuLieu();
        }

        // --- 1. TẢI DỮ LIỆU ---
        private void LoadTatCaDuLieu()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT MaXe, BienSo, LoaiXe, SoGhe, TinhTrang FROM Xe";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgv_Xe.DataSource = dt;
                    dgv_Xe.ClearSelection(); // Tránh bốc dữ liệu dòng đầu tiên lên Form
                }
                catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
            }
        }

        // --- 2. HIỂN THỊ DỮ LIỆU LÊN FORM ---
        private void dgv_Xe_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_Xe.SelectedRows.Count > 0)
            {
                DataRowView drv = dgv_Xe.SelectedRows[0].DataBoundItem as DataRowView;
                if (drv == null) return;

                maXeDangChon = Convert.ToInt32(drv["MaXe"]);
                txt_BienSoXe.Text = drv["BienSo"].ToString();
                cmb_LoaiXe.Text = drv["LoaiXe"].ToString();
                nud_SoGhe.Value = Convert.ToDecimal(drv["SoGhe"]);
                cmb_TinhTrang.Text = drv["TinhTrang"].ToString();
            }
        }

        // --- 3. ĐÁNH SỐ THỨ TỰ ---
        private void dgv_Xe_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_Xe.Columns[e.ColumnIndex].Name == "colSTT" && e.RowIndex >= 0)
            {
                e.Value = e.RowIndex + 1;
            }
        }

        // --- 4. ĐẶT LẠI FORM ---
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            LoadTatCaDuLieu();

            maXeDangChon = -1;
            txt_BienSoXe.Clear();
            cmb_LoaiXe.SelectedIndex = -1;
            cmb_TinhTrang.SelectedIndex = -1;
            nud_SoGhe.Value = 1; // Default
            txt_Find.Clear();

            txt_BienSoXe.Focus();
        }

        // --- 5. KIỂM TRA TRÙNG BIỂN SỐ ---
        private bool KiemTraTrungBienSo(string bienSo, int maXeKiemTra)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Tìm xem có xe nào khác mang biển số này không
                string query = "SELECT COUNT(*) FROM Xe WHERE BienSo = @BienSo AND MaXe != @MaXe";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BienSo", bienSo);
                cmd.Parameters.AddWithValue("@MaXe", maXeKiemTra);
                return (int)cmd.ExecuteScalar() > 0; // Trả về true nếu bị trùng
            }
        }

        // --- 6. LƯU (THÊM MỚI) ---
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_BienSoXe.Text) || cmb_LoaiXe.SelectedIndex == -1 || cmb_TinhTrang.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng điền đầy đủ Biển số, Loại xe và Tình trạng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (KiemTraTrungBienSo(txt_BienSoXe.Text.Trim(), -1))
            {
                MessageBox.Show("Biển số xe này đã tồn tại trong hệ thống!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO Xe (BienSo, LoaiXe, SoGhe, TinhTrang) 
                                     VALUES (@BienSo, @LoaiXe, @SoGhe, @TinhTrang)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BienSo", txt_BienSoXe.Text.Trim());
                    cmd.Parameters.AddWithValue("@LoaiXe", cmb_LoaiXe.Text);
                    cmd.Parameters.AddWithValue("@SoGhe", nud_SoGhe.Value);
                    cmd.Parameters.AddWithValue("@TinhTrang", cmb_TinhTrang.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm xe mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_Reset_Click(null, null);
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        // --- 7. SỬA (CẬP NHẬT) ---
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (maXeDangChon == -1)
            {
                MessageBox.Show("Vui lòng chọn một xe trên lưới để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (KiemTraTrungBienSo(txt_BienSoXe.Text.Trim(), maXeDangChon))
            {
                MessageBox.Show("Biển số xe này đang bị trùng với một xe khác trong hệ thống!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE Xe 
                                     SET BienSo = @BienSo, LoaiXe = @LoaiXe, SoGhe = @SoGhe, TinhTrang = @TinhTrang 
                                     WHERE MaXe = @MaXe";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaXe", maXeDangChon);
                    cmd.Parameters.AddWithValue("@BienSo", txt_BienSoXe.Text.Trim());
                    cmd.Parameters.AddWithValue("@LoaiXe", cmb_LoaiXe.Text);
                    cmd.Parameters.AddWithValue("@SoGhe", nud_SoGhe.Value);
                    cmd.Parameters.AddWithValue("@TinhTrang", cmb_TinhTrang.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thông tin xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTatCaDuLieu();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        // --- 8. XÓA ---
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (maXeDangChon == -1) return;

            if (MessageBox.Show($"Bạn có chắc muốn xóa xe {txt_BienSoXe.Text}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Xe WHERE MaXe = @MaXe", conn);
                        cmd.Parameters.AddWithValue("@MaXe", maXeDangChon);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Đã xóa xe khỏi hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btn_Reset_Click(null, null);
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 547)
                            MessageBox.Show("Không thể xóa xe này vì nó đang được xếp vào các chuyến xe!", "Lỗi khóa ngoại", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                    string query = @"SELECT MaXe, BienSo, LoaiXe, SoGhe, TinhTrang 
                                     FROM Xe 
                                     WHERE BienSo LIKE @TuKhoa 
                                        OR LoaiXe LIKE @TuKhoa 
                                        OR TinhTrang LIKE @TuKhoa";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv_Xe.DataSource = dt;
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        // --- 10. TÌM KIẾM CHI TIẾT (TRONG PANEL) ---
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

                    if (!string.IsNullOrWhiteSpace(txt_BienSoXe.Text))
                    {
                        conditions.Add("BienSo LIKE @BienSo");
                        cmd.Parameters.AddWithValue("@BienSo", "%" + txt_BienSoXe.Text.Trim() + "%");
                    }
                    if (cmb_LoaiXe.SelectedIndex != -1)
                    {
                        conditions.Add("LoaiXe = @LoaiXe");
                        cmd.Parameters.AddWithValue("@LoaiXe", cmb_LoaiXe.Text);
                    }
                    if (cmb_TinhTrang.SelectedIndex != -1)
                    {
                        conditions.Add("TinhTrang = @TinhTrang");
                        cmd.Parameters.AddWithValue("@TinhTrang", cmb_TinhTrang.Text);
                    }
                    if (nud_SoGhe.Value > 0)
                    {
                        conditions.Add("SoGhe = @SoGhe");
                        cmd.Parameters.AddWithValue("@SoGhe", nud_SoGhe.Value);
                    }

                    string query = "SELECT MaXe, BienSo, LoaiXe, SoGhe, TinhTrang FROM Xe";

                    if (conditions.Count > 0)
                    {
                        query += " WHERE " + string.Join(" AND ", conditions);
                    }

                    cmd.CommandText = query;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv_Xe.DataSource = dt;

                    if (dt.Rows.Count == 0)
                        MessageBox.Show("Không tìm thấy xe phù hợp tiêu chí!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        // --- 11. NÚT QUAY LẠI ---
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
