using System.Data;
using DoAn_LTWindows.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWindows.DAL
{
    internal class ChuyenXeDAL
    {
        // 1. TẢI COMBOBOX TUYẾN
        public DataTable LayDanhSachTuyen()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaTuyen, TenTuyen FROM TuyenXe", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // 2. TẢI COMBOBOX XE
        public DataTable LayDanhSachXe()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaXe, BienSo + ' (' + LoaiXe + ')' AS ThongTinXe FROM Xe", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // 3. TẢI TẤT CẢ DỮ LIỆU CHUYẾN XE (KÈM JOIN)
        public List<ChuyenXeDTO> LayTatCaChuyenXe()
        {
            List<ChuyenXeDTO> list = new List<ChuyenXeDTO>();
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                        SELECT c.MaChuyen, c.MaTuyen, c.MaXe, t.TenTuyen, x.BienSo, c.GiaVe, c.ThoiGianXuatBen 
                        FROM ChuyenXe c
                        JOIN TuyenXe t ON c.MaTuyen = t.MaTuyen
                        JOIN Xe x ON c.MaXe = x.MaXe
                        ORDER BY c.ThoiGianXuatBen DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ChuyenXeDTO
                        {
                            MaChuyen = Convert.ToInt32(reader["MaChuyen"]),
                            MaTuyen = Convert.ToInt32(reader["MaTuyen"]),
                            MaXe = Convert.ToInt32(reader["MaXe"]),
                            TenTuyen = reader["TenTuyen"].ToString(),
                            BienSo = reader["BienSo"].ToString(),
                            GiaVe = Convert.ToDecimal(reader["GiaVe"]),
                            ThoiGianXuatBen = Convert.ToDateTime(reader["ThoiGianXuatBen"])
                        });
                    }
                }
            }
            return list;
        }

        // 4. THÊM
        public void ThemChuyenXe(ChuyenXeDTO chuyen)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO ChuyenXe (MaTuyen, MaXe, GiaVe, ThoiGianXuatBen) 
                                 VALUES (@MaTuyen, @MaXe, @GiaVe, @ThoiGian)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaTuyen", chuyen.MaTuyen);
                    cmd.Parameters.AddWithValue("@MaXe", chuyen.MaXe);
                    cmd.Parameters.AddWithValue("@GiaVe", chuyen.GiaVe);
                    cmd.Parameters.AddWithValue("@ThoiGian", chuyen.ThoiGianXuatBen);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 5. SỬA
        public void SuaChuyenXe(ChuyenXeDTO chuyen)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE ChuyenXe 
                                 SET MaTuyen = @MaTuyen, MaXe = @MaXe, GiaVe = @GiaVe, ThoiGianXuatBen = @ThoiGian 
                                 WHERE MaChuyen = @MaChuyen";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaChuyen", chuyen.MaChuyen);
                    cmd.Parameters.AddWithValue("@MaTuyen", chuyen.MaTuyen);
                    cmd.Parameters.AddWithValue("@MaXe", chuyen.MaXe);
                    cmd.Parameters.AddWithValue("@GiaVe", chuyen.GiaVe);
                    cmd.Parameters.AddWithValue("@ThoiGian", chuyen.ThoiGianXuatBen);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 6. XÓA
        public void XoaChuyenXe(int maChuyen)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM ChuyenXe WHERE MaChuyen = @MaChuyen", conn))
                    {
                        cmd.Parameters.AddWithValue("@MaChuyen", maChuyen);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                        throw new Exception("Không thể xóa chuyến xe vì đã có vé được bán thuộc chuyến này!");
                    else
                        throw new Exception("Lỗi CSDL: " + ex.Message);
                }
            }
        }

        // 7. TÌM KIẾM CHUNG
        public List<ChuyenXeDTO> TimKiemChung(string tuKhoa)
        {
            List<ChuyenXeDTO> list = new List<ChuyenXeDTO>();
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                        SELECT c.MaChuyen, c.MaTuyen, c.MaXe, t.TenTuyen, x.BienSo, c.GiaVe, c.ThoiGianXuatBen 
                        FROM ChuyenXe c
                        JOIN TuyenXe t ON c.MaTuyen = t.MaTuyen
                        JOIN Xe x ON c.MaXe = x.MaXe
                        WHERE t.TenTuyen LIKE @TuKhoa OR x.BienSo LIKE @TuKhoa";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ChuyenXeDTO
                            {
                                MaChuyen = Convert.ToInt32(reader["MaChuyen"]),
                                MaTuyen = Convert.ToInt32(reader["MaTuyen"]),
                                MaXe = Convert.ToInt32(reader["MaXe"]),
                                TenTuyen = reader["TenTuyen"].ToString(),
                                BienSo = reader["BienSo"].ToString(),
                                GiaVe = Convert.ToDecimal(reader["GiaVe"]),
                                ThoiGianXuatBen = Convert.ToDateTime(reader["ThoiGianXuatBen"])
                            });
                        }
                    }
                }
            }
            return list;
        }

        // 8. TÌM KIẾM CHI TIẾT
        public List<ChuyenXeDTO> TimKiemChiTiet(ChuyenXeDTO dieuKien)
        {
            List<ChuyenXeDTO> list = new List<ChuyenXeDTO>();
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                List<string> conditions = new List<string>();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if (dieuKien.MaTuyen > 0)
                {
                    conditions.Add("c.MaTuyen = @MaTuyen");
                    cmd.Parameters.AddWithValue("@MaTuyen", dieuKien.MaTuyen);
                }
                if (dieuKien.MaXe > 0)
                {
                    conditions.Add("c.MaXe = @MaXe");
                    cmd.Parameters.AddWithValue("@MaXe", dieuKien.MaXe);
                }
                if (dieuKien.GiaVe > 0)
                {
                    conditions.Add("c.GiaVe = @GiaVe");
                    cmd.Parameters.AddWithValue("@GiaVe", dieuKien.GiaVe);
                }

                // Chỉ lọc theo "Ngày" xuất bến (bỏ qua Giờ)
                conditions.Add("CAST(c.ThoiGianXuatBen AS DATE) = @NgayXuatBen");
                cmd.Parameters.AddWithValue("@NgayXuatBen", dieuKien.ThoiGianXuatBen.Date);

                string query = @"
                        SELECT c.MaChuyen, c.MaTuyen, c.MaXe, t.TenTuyen, x.BienSo, c.GiaVe, c.ThoiGianXuatBen 
                        FROM ChuyenXe c
                        JOIN TuyenXe t ON c.MaTuyen = t.MaTuyen
                        JOIN Xe x ON c.MaXe = x.MaXe";

                if (conditions.Count > 0)
                {
                    query += " WHERE " + string.Join(" AND ", conditions);
                }

                cmd.CommandText = query;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ChuyenXeDTO
                        {
                            MaChuyen = Convert.ToInt32(reader["MaChuyen"]),
                            MaTuyen = Convert.ToInt32(reader["MaTuyen"]),
                            MaXe = Convert.ToInt32(reader["MaXe"]),
                            TenTuyen = reader["TenTuyen"].ToString(),
                            BienSo = reader["BienSo"].ToString(),
                            GiaVe = Convert.ToDecimal(reader["GiaVe"]),
                            ThoiGianXuatBen = Convert.ToDateTime(reader["ThoiGianXuatBen"])
                        });
                    }
                }
            }
            return list;
        }
    }
}
