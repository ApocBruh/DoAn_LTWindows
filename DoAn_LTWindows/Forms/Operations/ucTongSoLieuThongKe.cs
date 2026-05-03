using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_LTWindows.Forms.Operations
{
    public partial class ucTongSoLieuThongKe : UserControl
    {
        string connectionString = @"Data Source=DESKTOP-QG0J4IU;Initial Catalog=QLBanVeXeBuyt;Integrated Security=True";
        DateTime fromDate;
        DateTime toDate;

        public ucTongSoLieuThongKe(DateTime tuNgay, DateTime denNgay)
        {
            InitializeComponent();

            this.fromDate = tuNgay;
            this.toDate = denNgay;

            btn_ExportData.MouseDown += (s, e) => {
                btn_ExportData.BackgroundImage = Properties.Resources._75pxbtn1_c;
            };

            btn_ExportData.MouseUp += (s, e) => {
                btn_ExportData.BackgroundImage = Properties.Resources._75pxbtn1;
            };

            btn_Return.MouseDown += (s, e) => {
                btn_Return.BackgroundImage = Properties.Resources._75pxbtn1_c;
            };

            btn_Return.MouseUp += (s, e) => {
                btn_Return.BackgroundImage = Properties.Resources._75pxbtn1;
            };
        }

        private void ucTongSoLieuThongKe_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // 1. Tính Vé Bán / Vé Hủy / Tiền Hoàn (Trong kỳ)
                    string qVe = @"
                        SELECT 
                            SUM(CASE WHEN TrangThai = 1 THEN 1 ELSE 0 END) AS VeBan,
                            SUM(CASE WHEN TrangThai = 0 THEN 1 ELSE 0 END) AS VeHuy,
                            SUM(CASE WHEN TrangThai = 0 THEN GiaVe ELSE 0 END) AS TienHoan
                        FROM (
                            SELECT TrangThai, GiaVe, ThoiGian FROM VeXeNoiThanh
                            UNION ALL
                            SELECT TrangThai, GiaVe, ThoiGian FROM VeXeNgoaiThanh
                        ) AS TongVe
                        WHERE CAST(ThoiGian AS DATE) BETWEEN @TuNgay AND @DenNgay";
                    SqlCommand cmdVe = new SqlCommand(qVe, conn);
                    cmdVe.Parameters.AddWithValue("@TuNgay", fromDate);
                    cmdVe.Parameters.AddWithValue("@DenNgay", toDate);
                    SqlDataReader drVe = cmdVe.ExecuteReader();
                    if (drVe.Read())
                    {
                        lbl_TSVDBData.Text = (drVe["VeBan"] != DBNull.Value ? Convert.ToInt32(drVe["VeBan"]) : 0).ToString("N0");
                        lbl_TSVDHData.Text = (drVe["VeHuy"] != DBNull.Value ? Convert.ToInt32(drVe["VeHuy"]) : 0).ToString("N0");
                        lbl_TSTDHTData.Text = (drVe["TienHoan"] != DBNull.Value ? Convert.ToDecimal(drVe["TienHoan"]) : 0).ToString("N0") + " đ";
                    }
                    drVe.Close();

                    // 2. Tính Chuyến Thực Hiện / Hủy (Trong kỳ)
                    string qChuyen = @"
                        SELECT 
                            SUM(CASE WHEN TrangThai = 1 THEN 1 ELSE 0 END) AS ChuyenThucHien,
                            SUM(CASE WHEN TrangThai = 0 THEN 1 ELSE 0 END) AS ChuyenHuy
                        FROM ChuyenXe WHERE CAST(ThoiGianXuatBen AS DATE) BETWEEN @TuNgay AND @DenNgay";
                    SqlCommand cmdChuyen = new SqlCommand(qChuyen, conn);
                    cmdChuyen.Parameters.AddWithValue("@TuNgay", fromDate);
                    cmdChuyen.Parameters.AddWithValue("@DenNgay", toDate);
                    SqlDataReader drChuyen = cmdChuyen.ExecuteReader();
                    if (drChuyen.Read())
                    {
                        lbl_TSCDTHData.Text = (drChuyen["ChuyenThucHien"] != DBNull.Value ? Convert.ToInt32(drChuyen["ChuyenThucHien"]) : 0).ToString("N0");
                        lbl_TSCDHData.Text = (drChuyen["ChuyenHuy"] != DBNull.Value ? Convert.ToInt32(drChuyen["ChuyenHuy"]) : 0).ToString("N0");
                    }
                    drChuyen.Close();

                    // 3. Tính Doanh Thu Tháng, Quý, Năm (Tính theo thời gian thực tại của hệ thống)
                    string qDoanhThu = @"
                        SELECT 
                            SUM(CASE WHEN MONTH(ThoiGian) = MONTH(GETDATE()) AND YEAR(ThoiGian) = YEAR(GETDATE()) THEN GiaVe ELSE 0 END) AS TienThang,
                            SUM(CASE WHEN DATEPART(qq, ThoiGian) = DATEPART(qq, GETDATE()) AND YEAR(ThoiGian) = YEAR(GETDATE()) THEN GiaVe ELSE 0 END) AS TienQuy,
                            SUM(CASE WHEN YEAR(ThoiGian) = YEAR(GETDATE()) THEN GiaVe ELSE 0 END) AS TienNam,
                            SUM(CASE WHEN CAST(ThoiGian AS DATE) BETWEEN @TuNgay AND @DenNgay THEN GiaVe ELSE 0 END) AS TongThuKy
                        FROM (
                            SELECT ThoiGian, GiaVe FROM VeXeNoiThanh WHERE TrangThai = 1
                            UNION ALL
                            SELECT ThoiGian, GiaVe FROM VeXeNgoaiThanh WHERE TrangThai = 1
                        ) AS AllVe";
                    SqlCommand cmdDT = new SqlCommand(qDoanhThu, conn);
                    cmdDT.Parameters.AddWithValue("@TuNgay", fromDate);
                    cmdDT.Parameters.AddWithValue("@DenNgay", toDate);
                    SqlDataReader drDT = cmdDT.ExecuteReader();

                    decimal tongThuKy = 0;
                    if (drDT.Read())
                    {
                        lbl_TSTTTData.Text = (drDT["TienThang"] != DBNull.Value ? Convert.ToDecimal(drDT["TienThang"]) : 0).ToString("N0") + " đ";
                        lbl_TSTTQData.Text = (drDT["TienQuy"] != DBNull.Value ? Convert.ToDecimal(drDT["TienQuy"]) : 0).ToString("N0") + " đ";
                        lbl_TSTTNData.Text = (drDT["TienNam"] != DBNull.Value ? Convert.ToDecimal(drDT["TienNam"]) : 0).ToString("N0") + " đ";
                        tongThuKy = drDT["TongThuKy"] != DBNull.Value ? Convert.ToDecimal(drDT["TongThuKy"]) : 0;
                    }
                    drDT.Close();

                    // 4. Chi Phí Bảo Trì (Trong kỳ)
                    string qBaoTri = "SELECT SUM(SoTien) FROM ChiPhiBaoTri WHERE NgayBaoTri BETWEEN @TuNgay AND @DenNgay";
                    SqlCommand cmdBT = new SqlCommand(qBaoTri, conn);
                    cmdBT.Parameters.AddWithValue("@TuNgay", fromDate);
                    cmdBT.Parameters.AddWithValue("@DenNgay", toDate);
                    object btResult = cmdBT.ExecuteScalar();
                    decimal tongBaoTri = (btResult != DBNull.Value) ? Convert.ToDecimal(btResult) : 0;
                    lbl_TSTCPBTData.Text = tongBaoTri.ToString("N0") + " đ";

                    // 5. TỔNG DOANH THU = Tổng Thu Kỳ - Tổng Bảo Trì
                    lbl_TDTData.Text = (tongThuKy - tongBaoTri).ToString("N0") + " đ";
                }
                catch (Exception ex) { MessageBox.Show("Lỗi thống kê: " + ex.Message); }
            }
        }

        // XUẤT FILE ẢNH BÁO CÁO (PNG)
        private void btn_ExportData_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG Image|*.png";
            sfd.Title = "Lưu báo cáo thống kê";
            sfd.FileName = "BaoCaoThongKe_" + DateTime.Now.ToString("ddMMyyyy") + ".png";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // Chụp ảnh lại User Control hiện tại
                Bitmap bmp = new Bitmap(this.Width, this.Height);
                this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));
                bmp.Save(sfd.FileName, ImageFormat.Png);
                MessageBox.Show("Đã xuất ảnh báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Return_Click(object sender, EventArgs e)
        {
            Panel pnlParent = (Panel)this.Parent;
            pnlParent.Controls.Clear();
            ucBaoCaoDoanhThu uc = new ucBaoCaoDoanhThu();
            uc.Dock = DockStyle.Fill;
            pnlParent.Controls.Add(uc);
        }
    }
}
