using DoAn_LTWindows.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWindows.DAL
{
    internal class VeXeNgoaiThanhDAL
    {
        public void LuuDanhSachVe(List<VeXeNgoaiThanhDTO> danhSachVe)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                // Bắt đầu Transaction để đảm bảo tính Toàn vẹn dữ liệu
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (var ve in danhSachVe)
                        {
                            // 1. KIỂM TRA VÀ THÊM KHÁCH HÀNG (Tránh lỗi Khóa ngoại 547)
                            if (!string.IsNullOrEmpty(ve.SoDienThoai))
                            {
                                // Kiểm tra xem SĐT này đã có trong CSDL chưa
                                string checkKhach = "SELECT COUNT(*) FROM KhachHang WHERE SoDienThoai = @SDT";
                                using (SqlCommand cmdCheck = new SqlCommand(checkKhach, conn, trans))
                                {
                                    cmdCheck.Parameters.AddWithValue("@SDT", ve.SoDienThoai);
                                    int countKhach = (int)cmdCheck.ExecuteScalar();

                                    // Nếu là khách hàng mới tinh -> Tự động thêm vào bảng KhachHang
                                    if (countKhach == 0)
                                    {
                                        string insertKhach = "INSERT INTO KhachHang (SoDienThoai, TenKhachHang) VALUES (@SDT, N'Khách vãng lai')";
                                        using (SqlCommand cmdInsertKhach = new SqlCommand(insertKhach, conn, trans))
                                        {
                                            cmdInsertKhach.Parameters.AddWithValue("@SDT", ve.SoDienThoai);
                                            cmdInsertKhach.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }

                            // 2. THÊM VÉ XE VÀO BẢNG VeXeNgoaiThanh
                            string query = @"INSERT INTO VeXeNgoaiThanh 
                                     (MaSoVe, MaTuyen, HinhThucThanhToan, ThoiGian, NgayDi, SoGhe, GiaVe, SoDienThoai) 
                                     VALUES (@MaVe, @MaTuyen, @HTTT, @ThoiGian, @NgayDi, @SoGhe, @GiaVe, @SoDienThoai)";

                            using (SqlCommand cmd = new SqlCommand(query, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@MaVe", ve.MaSoVe);
                                cmd.Parameters.AddWithValue("@MaTuyen", ve.MaTuyen);
                                cmd.Parameters.AddWithValue("@HTTT", ve.HinhThucThanhToan);
                                cmd.Parameters.AddWithValue("@ThoiGian", ve.ThoiGian);
                                cmd.Parameters.AddWithValue("@NgayDi", ve.NgayDi.Date);
                                cmd.Parameters.AddWithValue("@SoGhe", ve.SoGhe);
                                cmd.Parameters.AddWithValue("@GiaVe", ve.GiaVe);
                                // Truyền Null nếu khách không có SĐT
                                cmd.Parameters.AddWithValue("@SoDienThoai", string.IsNullOrEmpty(ve.SoDienThoai) ? (object)DBNull.Value : ve.SoDienThoai);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        // Nếu MỌI THỨ đều lọt qua an toàn -> Xác nhận lưu tất cả!
                        trans.Commit();
                    }
                    catch
                    {
                        // Nếu có BẤT KỲ lỗi gì (như trùng mã vé) -> Thu hồi toàn bộ, không lưu gì cả
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<string> LayDanhSachGheDaDat(int maTuyen, DateTime ngayDi)
        {
            List<string> danhSachGhe = new List<string>();
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                // Tìm các ghế trùng MaTuyen, trùng Ngày (bỏ qua Giờ), và trạng thái hợp lệ
                string query = @"SELECT SoGhe FROM VeXeNgoaiThanh 
                                 WHERE MaTuyen = @MaTuyen 
                                   AND CAST(NgayDi AS DATE) = CAST(@NgayDi AS DATE)";
                // Nếu CSDL bạn có cột TrangThai, hãy thêm: AND TrangThai = 1

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaTuyen", maTuyen);
                    cmd.Parameters.AddWithValue("@NgayDi", ngayDi.Date);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            danhSachGhe.Add(reader["SoGhe"].ToString().Trim());
                        }
                    }
                }
            }
            return danhSachGhe;
        }
    }
}
