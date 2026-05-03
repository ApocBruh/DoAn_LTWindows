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
using Excel = Microsoft.Office.Interop.Excel; // Khai báo thư viện Excel

namespace DoAn_LTWindows.Forms.Operations
{
    public partial class ucBaoCaoDoanhThu : UserControl
    {
        string connectionString = @"Data Source=DESKTOP-QG0J4IU;Initial Catalog=QLBanVeXeBuyt;Integrated Security=True";
        public ucBaoCaoDoanhThu()
        {
            InitializeComponent();

            dgv_DoanhThu.AutoGenerateColumns = false;

            btn_ExportExcel.MouseDown += (s, e) => {
                btn_ExportExcel.BackgroundImage = Properties.Resources._75pxbtn1_c;
            };

            btn_ExportExcel.MouseUp += (s, e) => {
                btn_ExportExcel.BackgroundImage = Properties.Resources._75pxbtn1;
            };

            btn_ThongKe.MouseDown += (s, e) => {
                btn_ThongKe.BackgroundImage = Properties.Resources._75pxbtn1_c;
            };

            btn_ThongKe.MouseUp += (s, e) => {
                btn_ThongKe.BackgroundImage = Properties.Resources._75pxbtn1;
            };

            btn_TongSoLieuThongKe.MouseDown += (s, e) => {
                btn_TongSoLieuThongKe.BackgroundImage = Properties.Resources._75pxbtn1_c;
            };

            btn_TongSoLieuThongKe.MouseUp += (s, e) => {
                btn_TongSoLieuThongKe.BackgroundImage = Properties.Resources._75pxbtn1;
            };

            btn_Return.MouseDown += (s, e) => {
                btn_Return.BackgroundImage = Properties.Resources._75pxbtn1_c;
            };

            btn_Return.MouseUp += (s, e) => {
                btn_Return.BackgroundImage = Properties.Resources._75pxbtn1;
            };
        }

        private void ucBaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            dtp_FromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtp_ToDate.Value = today;
            btn_ThongKe_Click(null, null);

            dgv_DoanhThu.DefaultCellStyle.ForeColor = Color.Black;

            // Tùy chọn: Ép màu chữ của cột tiêu đề (Header) thành màu đen luôn cho chắc chắn
            dgv_DoanhThu.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            if (dtp_FromDate.Value.Date > dtp_ToDate.Value.Date)
            {
                MessageBox.Show("Khoảng thời gian không hợp lệ!\nNgày bắt đầu (Từ Ngày) không thể lớn hơn ngày kết thúc (Đến Ngày).",
                                "Lỗi chọn ngày",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return; // Dừng lại ngay lập tức, không chạy code truy vấn SQL bên dưới
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT MaSoVe, N'Nội Thành' AS LoaiVe, GiaVe, ThoiGian AS NgayGiaoDich 
                        FROM VeXeNoiThanh WHERE CAST(ThoiGian AS DATE) BETWEEN @TuNgay AND @DenNgay AND TrangThai = 1
                        UNION ALL
                        SELECT MaSoVe, N'Ngoại Thành' AS LoaiVe, GiaVe, ThoiGian AS NgayGiaoDich 
                        FROM VeXeNgoaiThanh WHERE CAST(ThoiGian AS DATE) BETWEEN @TuNgay AND @DenNgay AND TrangThai = 1
                        ORDER BY NgayGiaoDich DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TuNgay", dtp_FromDate.Value.Date);
                    cmd.Parameters.AddWithValue("@DenNgay", dtp_ToDate.Value.Date);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv_DoanhThu.DataSource = dt;
                    dgv_DoanhThu.ClearSelection();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        private void dgv_DoanhThu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_DoanhThu.Columns[e.ColumnIndex].Name == "colSTT" && e.RowIndex >= 0) e.Value = e.RowIndex + 1;
            if (dgv_DoanhThu.Columns[e.ColumnIndex].DataPropertyName == "GiaVe" && e.Value != null)
            {
                e.Value = Convert.ToDecimal(e.Value).ToString("N0") + " đ";
                e.FormattingApplied = true;
            }
            if (dgv_DoanhThu.Columns[e.ColumnIndex].DataPropertyName == "NgayGiaoDich" && e.Value != null)
            {
                e.Value = Convert.ToDateTime(e.Value).ToString("dd/MM/yyyy HH:mm");
                e.FormattingApplied = true;
            }
        }

        // CHUYỂN SANG UC TỔNG SỐ LIỆU THỐNG KÊ (Truyền ngày qua để thống kê đúng kỳ)
        private void btn_TongSoLieuThongKe_Click(object sender, EventArgs e)
        {
            Panel pnlParent = (Panel)this.Parent;
            pnlParent.Controls.Clear();
            ucTongSoLieuThongKe uc = new ucTongSoLieuThongKe(dtp_FromDate.Value.Date, dtp_ToDate.Value.Date);
            uc.Dock = DockStyle.Fill;
            pnlParent.Controls.Add(uc);
        }

        // XUẤT EXCEL
        private void btn_ExportExcel_Click(object sender, EventArgs e)
        {
            if (dgv_DoanhThu.Rows.Count == 0) return;
            try
            {
                Excel.Application excelApp = new Excel.Application();
                excelApp.Workbooks.Add();
                Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

                // Lấy Header
                for (int i = 1; i < dgv_DoanhThu.Columns.Count + 1; i++)
                {
                    workSheet.Cells[1, i] = dgv_DoanhThu.Columns[i - 1].HeaderText;
                }

                // Lấy Dữ liệu
                for (int i = 0; i < dgv_DoanhThu.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv_DoanhThu.Columns.Count; j++)
                    {
                        workSheet.Cells[i + 2, j + 1] = dgv_DoanhThu.Rows[i].Cells[j].Value?.ToString();
                    }
                }
                excelApp.Visible = true; // Mở Excel lên cho người dùng tự Save
            }
            catch (Exception ex) { MessageBox.Show("Lỗi xuất Excel: " + ex.Message); }
        }

        private void KiemTraNgayHopLe(object sender, EventArgs e)
        {
            if (dtp_FromDate.Value.Date > dtp_ToDate.Value.Date)
            {
                MessageBox.Show("Bạn không thể chọn 'Từ Ngày' lớn hơn 'Đến Ngày'!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Tự động đẩy 'Đến Ngày' cho bằng với 'Từ Ngày' để đồng bộ lại
                dtp_ToDate.Value = dtp_FromDate.Value;
            }
        }

        private void btn_Return_Click(object sender, EventArgs e)
        {
            Panel pnlParent = (Panel)this.Parent;
            pnlParent.Controls.Clear(); // Trở về dashboard trống
        }
    }
}
