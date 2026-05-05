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
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string query = @"INSERT INTO VeXeNgoaiThanh 
                                         (MaSoVe, MaTuyen, HinhThucThanhToan, ThoiGian, NgayDi, SoGhe, GiaVe, SoDienThoai) 
                                         VALUES (@MaVe, @MaTuyen, @HTTT, @ThoiGian, @NgayDi, @SoGhe, @GiaVe, @SoDienThoai)";

                        using (SqlCommand cmd = new SqlCommand(query, conn, trans))
                        {
                            foreach (var ve in danhSachVe)
                            {
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@MaVe", ve.MaSoVe);
                                cmd.Parameters.AddWithValue("@MaTuyen", ve.MaTuyen);
                                cmd.Parameters.AddWithValue("@HTTT", ve.HinhThucThanhToan);
                                cmd.Parameters.AddWithValue("@ThoiGian", ve.ThoiGian);
                                cmd.Parameters.AddWithValue("@NgayDi", ve.NgayDi.Date);
                                cmd.Parameters.AddWithValue("@SoGhe", ve.SoGhe);
                                cmd.Parameters.AddWithValue("@GiaVe", ve.GiaVe);
                                cmd.Parameters.AddWithValue("@SoDienThoai", string.IsNullOrEmpty(ve.SoDienThoai) ? (object)DBNull.Value : ve.SoDienThoai);

                                cmd.ExecuteNonQuery();
                            }
                        }
                        trans.Commit();
                    }
                    catch
                    {
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
