using DoAn_LTWindows.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWindows.DAL
{
    internal class TraCuuVeDAL
    {
        // Hàm dùng chung cho cả Load tất cả và Tìm kiếm
        public List<VeXeDTO> LayDanhSachVe(string tuKhoa = "", bool timTheoMaVe = true)
        {
            List<VeXeDTO> listVe = new List<VeXeDTO>();
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();

                // Gom 2 bảng lại thành 1 bảng tạm tên là DanhSachVe
                string query = @"
                    SELECT * FROM (
                        SELECT 
                            v.MaSoVe, N'Nội Thành' AS LoaiVe, t.TenTuyen AS TuyenXe, 
                            v.ThoiGian AS NgayDi, v.ThoiGian AS ThoiGianGiaoDich, 
                            N'-' AS SoGhe, v.GiaVe, v.TrangThai, v.SoDienThoai
                        FROM VeXeNoiThanh v
                        JOIN TuyenXeNoiThanh t ON v.MaTuyen = t.MaTuyen
                        
                        UNION ALL

                        SELECT 
                            v.MaSoVe, N'Ngoại Thành' AS LoaiVe, t.TenTuyen AS TuyenXe, 
                            v.NgayDi AS NgayDi, v.ThoiGian AS ThoiGianGiaoDich, 
                            v.SoGhe, v.GiaVe, v.TrangThai, v.SoDienThoai 
                        FROM VeXeNgoaiThanh v
                        JOIN TuyenXeNgoaiThanh t ON v.MaTuyen = t.MaTuyen
                    ) AS DanhSachVe
                ";

                // Nếu có từ khóa tìm kiếm thì thêm lệnh WHERE
                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    if (timTheoMaVe) query += " WHERE MaSoVe = @TuKhoa";
                    else query += " WHERE SoDienThoai = @TuKhoa";
                }

                query += " ORDER BY ThoiGianGiaoDich DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrWhiteSpace(tuKhoa))
                    {
                        cmd.Parameters.AddWithValue("@TuKhoa", tuKhoa);
                    }

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listVe.Add(new VeXeDTO
                            {
                                MaSoVe = reader["MaSoVe"].ToString(),
                                LoaiVe = reader["LoaiVe"].ToString(),
                                TuyenXe = reader["TuyenXe"].ToString(),
                                NgayDi = Convert.ToDateTime(reader["NgayDi"]),
                                ThoiGianGiaoDich = Convert.ToDateTime(reader["ThoiGianGiaoDich"]),
                                SoGhe = reader["SoGhe"].ToString(),
                                GiaVe = Convert.ToDecimal(reader["GiaVe"]),
                                TrangThai = Convert.ToInt32(reader["TrangThai"]),
                                SoDienThoai = reader["SoDienThoai"] != DBNull.Value ? reader["SoDienThoai"].ToString() : ""
                            });
                        }
                    }
                }
            }
            return listVe;
        }

        public void HuyVe(string maVe, string loaiVe)
        {
            string tableName = (loaiVe == "Nội Thành") ? "VeXeNoiThanh" : "VeXeNgoaiThanh";
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = $"UPDATE {tableName} SET TrangThai = 0 WHERE MaSoVe = @MaSoVe";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSoVe", maVe);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
