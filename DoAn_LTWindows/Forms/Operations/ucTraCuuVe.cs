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
        // Chuỗi kết nối (Hãy đảm bảo tên Server đúng với máy bạn)
        string connectionString = @"Data Source=DESKTOP-QG0J4IU;Initial Catalog=QLBanVeXeBuyt;Integrated Security=True";

        public ucTraCuuVe()
        {
            InitializeComponent();
            // Vẫn nên giữ dòng này để tránh SQL tự sinh thêm cột ngoài ý muốn
            dgv_Ve.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Ve.AutoGenerateColumns = false;
            dgv_Ve.SelectionChanged += dgv_Ve_SelectionChanged;

            btn_FindMaSoVe.MouseDown += (s, e) => {
                btn_FindMaSoVe.BackgroundImage = Properties.Resources._75pxbtn1_c;
            };

            btn_FindMaSoVe.MouseUp += (s, e) => {
                btn_FindMaSoVe.BackgroundImage = Properties.Resources._75pxbtn1;
            };

            btn_FindSoDienThoai.MouseDown += (s, e) => {
                btn_FindSoDienThoai.BackgroundImage = Properties.Resources._75pxbtn1_c;
            };

            btn_FindSoDienThoai.MouseUp += (s, e) => {
                btn_FindSoDienThoai.BackgroundImage = Properties.Resources._75pxbtn1;
            };

            btn_Refund.MouseDown += (s, e) => {
                btn_Refund.BackgroundImage = Properties.Resources._75pxbtnd_c;
            };

            btn_Refund.MouseUp += (s, e) => {
                btn_Refund.BackgroundImage = Properties.Resources._75pxbtnd;
            };

            btn_Return.MouseDown += (s, e) => {
                btn_Return.BackgroundImage = Properties.Resources._75pxbtn1_c;
            };

            btn_Return.MouseUp += (s, e) => {
                btn_Return.BackgroundImage = Properties.Resources._75pxbtn1;
            };
        }

        private void ucTraCuuVe_Load(object sender, EventArgs e)
        {
            // Thiết lập mặc định: Mới vào cho phép tìm theo Mã Vé trước
            chk_MaVe.Checked = true;
            chk_SoDienThoai.Checked = false;

            // Xóa rỗng Label thông tin
            lbl_Data.Text = "...";

            dgv_Ve.DefaultCellStyle.ForeColor = Color.Black;

            // Tùy chọn: Ép màu chữ của cột tiêu đề (Header) thành màu đen luôn cho chắc chắn
            dgv_Ve.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            // 2. Ép nội dung các ô (Cells) căn trái
            dgv_Ve.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            chk_MaVe.Checked = true;
            chk_SoDienThoai.Checked = false;

            // GỌI HÀM LOAD TOÀN BỘ DỮ LIỆU LÚC MỚI VÀO
            LoadTatCaDuLieu();
        }

        // --- CÁC HÀM XỬ LÝ GIAO DIỆN CHECKBOX ---

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

        // --- LOGIC TÌM KIẾM DỮ LIỆU ---

        private void TimKiem(string tuKhoa, bool timTheoMaVe)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string condition = timTheoMaVe ? "v.MaSoVe = @TuKhoa" : "v.SoDienThoai = @TuKhoa";

                    // ĐOẠN SQL CẦN THAY THẾ TRONG HÀM LoadTatCaDuLieu
                    string query = @"
                        -- BÊN NỘI THÀNH
                        SELECT 
                            v.MaSoVe, N'Nội Thành' AS LoaiVe, t.TenTuyen AS TuyenXe, 
                            
                            -- Cột này map lên DataGridView để hiển thị cho khách xem
                            v.ThoiGian AS NgayDi, 
                            
                            -- Cột ẩn này lưu thời gian bấm nút mua vé để đẩy lên dòng 1
                            v.ThoiGian AS ThoiGianGiaoDich, 
                            
                            N'-' AS SoGhe, v.GiaVe, v.TrangThai, v.SoDienThoai
                        FROM VeXeNoiThanh v
                        JOIN TuyenXeNoiThanh t ON v.MaTuyen = t.MaTuyen
                        
                        UNION ALL

                        -- BÊN NGOẠI THÀNH
                        SELECT 
                            v.MaSoVe, N'Ngoại Thành' AS LoaiVe, t.TenTuyen AS TuyenXe, 
                            
                            -- TRẢ LẠI ĐÚNG NGÀY ĐI TRONG TƯƠNG LAI LÊN MÀN HÌNH
                            v.NgayDi AS NgayDi, 
                            
                            -- Giữ lại thời gian mua vé để sắp xếp nổi lên đầu
                            v.ThoiGian AS ThoiGianGiaoDich, 
                            
                            v.SoGhe, v.GiaVe, v.TrangThai, v.SoDienThoai 
                        FROM VeXeNgoaiThanh v
                        JOIN TuyenXeNgoaiThanh t ON v.MaTuyen = t.MaTuyen

                        -- Sắp xếp ngầm dựa trên thời gian thực hiện giao dịch
                        ORDER BY ThoiGianGiaoDich DESC 
                    ";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TuKhoa", tuKhoa);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgv_Ve.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy vé!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lbl_Data.Text = "...";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi CSDL: " + ex.Message);
                }
            }
        }

        private void LoadTatCaDuLieu()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Lệnh UNION ALL gom 2 bảng NHƯNG KHÔNG CÓ WHERE
                    // ĐOẠN SQL CẦN THAY THẾ TRONG HÀM LoadTatCaDuLieu
                    string query = @"
                        -- BÊN NỘI THÀNH
                        SELECT 
                            v.MaSoVe, N'Nội Thành' AS LoaiVe, t.TenTuyen AS TuyenXe, 
                            
                            -- Cột này map lên DataGridView để hiển thị cho khách xem
                            v.ThoiGian AS NgayDi, 
                            
                            -- Cột ẩn này lưu thời gian bấm nút mua vé để đẩy lên dòng 1
                            v.ThoiGian AS ThoiGianGiaoDich, 
                            
                            N'-' AS SoGhe, v.GiaVe, v.TrangThai, v.SoDienThoai
                        FROM VeXeNoiThanh v
                        JOIN TuyenXeNoiThanh t ON v.MaTuyen = t.MaTuyen
                        
                        UNION ALL

                        -- BÊN NGOẠI THÀNH
                        SELECT 
                            v.MaSoVe, N'Ngoại Thành' AS LoaiVe, t.TenTuyen AS TuyenXe, 
                            
                            -- TRẢ LẠI ĐÚNG NGÀY ĐI TRONG TƯƠNG LAI LÊN MÀN HÌNH
                            v.NgayDi AS NgayDi, 
                            
                            -- Giữ lại thời gian mua vé để sắp xếp nổi lên đầu
                            v.ThoiGian AS ThoiGianGiaoDich, 
                            
                            v.SoGhe, v.GiaVe, v.TrangThai, v.SoDienThoai 
                        FROM VeXeNgoaiThanh v
                        JOIN TuyenXeNgoaiThanh t ON v.MaTuyen = t.MaTuyen

                        -- Sắp xếp ngầm dựa trên thời gian thực hiện giao dịch
                        ORDER BY ThoiGianGiaoDich DESC 
                    ";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgv_Ve.DataSource = dt;

                    // Nếu bảng có dữ liệu, xóa dòng trắng của lbl_Data
                    if (dt.Rows.Count > 0)
                    {
                        lbl_Data.Text = "Vui lòng chọn một vé trên lưới để xem chi tiết.";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải toàn bộ dữ liệu: " + ex.Message);
                }
            }
        }

        private void btn_FindMaSoVe_Click(object sender, EventArgs e)
        {
            // Nếu người dùng xóa hết chữ và bấm tìm kiếm -> Tải lại toàn bộ vé
            if (string.IsNullOrWhiteSpace(txt_MaSoVe.Text))
            {
                LoadTatCaDuLieu();
                return;
            }
            TimKiem(txt_MaSoVe.Text.Trim(), true);
        }

        private void btn_FindSoDienThoai_Click(object sender, EventArgs e)
        {
            // Nếu người dùng xóa hết chữ và bấm tìm kiếm -> Tải lại toàn bộ vé
            if (string.IsNullOrWhiteSpace(txt_SoDienThoai.Text))
            {
                LoadTatCaDuLieu();
                return;
            }
            TimKiem(txt_SoDienThoai.Text.Trim(), false);
        }

        // --- HIỂN THỊ CHI TIẾT KHI CHỌN DÒNG ---

        private void dgv_Ve_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_Ve.SelectedRows.Count > 0)
            {
                // Lấy chùm dữ liệu gốc (DataRowView) ẩn dưới dòng đang chọn
                DataRowView drv = dgv_Ve.SelectedRows[0].DataBoundItem as DataRowView;

                // Nếu drv null (VD: click vào dòng trắng chưa có data) thì bỏ qua
                if (drv == null) return;

                try
                {
                    // Lấy dữ liệu an toàn từ gốc SQL
                    string maVe = drv["MaSoVe"].ToString();
                    string loaiVe = drv["LoaiVe"].ToString();
                    string tuyenXe = drv["TuyenXe"].ToString();

                    DateTime dtNgayDi;
                    string ngayDi = DateTime.TryParse(drv["NgayDi"].ToString(), out dtNgayDi) ? dtNgayDi.ToString("dd/MM/yyyy HH:mm") : "...";

                    string giaVe = Convert.ToDecimal(drv["GiaVe"]).ToString("N0");
                    string sdt = drv["SoDienThoai"] != DBNull.Value ? drv["SoDienThoai"].ToString() : "Không Có";

                    int trangThai = Convert.ToInt32(drv["TrangThai"]);
                    string strTrangThai = trangThai == 1 ? "HỢP LỆ" : "ĐÃ HỦY";

                    // In ra màn hình
                    lbl_Data.Text = $"Mã Vé: {maVe} | SĐT: {sdt} | Trạng Thái: {strTrangThai}\n" +
                                    $"Loại: {loaiVe}  -  Tuyến xe: {tuyenXe}\n" +
                                    $"Khởi hành: {ngayDi} - Số tiền thanh toán: {giaVe} VNĐ";
                }
                catch (Exception ex)
                {
                    // Thay vì in ra lbl_Data, ta cho nó nổ hẳn MessageBox để dễ nhìn
                    MessageBox.Show("Lỗi lấy dữ liệu từ dòng: " + ex.Message, "Phát hiện lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- XỬ LÝ HỦY VÉ / HOÀN TIỀN ---

        private void btn_Refund_Click(object sender, EventArgs e)
        {
            if (dgv_Ve.SelectedRows.Count == 0) return;

            // Dùng DataBoundItem để lấy dữ liệu gốc an toàn tuyệt đối
            DataRowView drv = dgv_Ve.SelectedRows[0].DataBoundItem as DataRowView;
            if (drv == null) return;

            int trangThai = Convert.ToInt32(drv["TrangThai"]);
            DateTime ngayDi = Convert.ToDateTime(drv["NgayDi"]);
            string maVe = drv["MaSoVe"].ToString();
            string loaiVe = drv["LoaiVe"].ToString();

            if (trangThai == 0)
            {
                MessageBox.Show("Vé đã hủy trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (ngayDi < DateTime.Now)
            {
                MessageBox.Show("Chuyến xe đã khởi hành, không thể hủy!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            string tableName = (loaiVe == "Nội Thành") ? "VeXeNoiThanh" : "VeXeNgoaiThanh";

            if (MessageBox.Show($"Xác nhận hủy vé {maVe}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = $"UPDATE {tableName} SET TrangThai = 0 WHERE MaSoVe = @MaSoVe";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@MaSoVe", maVe);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Hủy vé thành công!");

                        // Load lại bảng
                        if (chk_MaVe.Checked) btn_FindMaSoVe_Click(null, null);
                        else btn_FindSoDienThoai_Click(null, null);
                    }
                    catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
                }
            }
        }

        private void dgv_Ve_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // 1. Tự động đánh số thứ tự cho cột colSTT
            if (dgv_Ve.Columns[e.ColumnIndex].Name == "colSTT" && e.RowIndex >= 0)
            {
                e.Value = e.RowIndex + 1;
            }

            // 2. Chuyển đổi Trạng Thái 1/0 thành Text và Nhuộm màu
            // Lưu ý: Đảm bảo DataPropertyName của cột này trong Design là "TrangThai"
            if (dgv_Ve.Columns[e.ColumnIndex].DataPropertyName == "TrangThai" && e.Value != null)
            {
                int trangThai = Convert.ToInt32(e.Value);
                if (trangThai == 1)
                {
                    e.Value = "HỢP LỆ";
                    e.CellStyle.ForeColor = Color.Green; // Chữ xanh lá
                    e.CellStyle.Font = new Font(dgv_Ve.Font, FontStyle.Bold);
                }
                else
                {
                    e.Value = "ĐÃ HỦY";
                    e.CellStyle.ForeColor = Color.Red; // Chữ đỏ
                    e.CellStyle.Font = new Font(dgv_Ve.Font, FontStyle.Strikeout); // Gạch ngang chữ
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