using DoAn_LTWindows.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWindows.DAL
{
    internal class XeDAL
    {
        public List<XeDTO> LayDanhSachXe()
        {
            List<XeDTO> list = new List<XeDTO>();
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT MaXe, BienSo, LoaiXe, SoGhe, TinhTrang FROM Xe";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new XeDTO
                        {
                            MaXe = Convert.ToInt32(reader["MaXe"]),
                            BienSo = reader["BienSo"].ToString(),
                            LoaiXe = reader["LoaiXe"].ToString(),
                            SoGhe = Convert.ToInt32(reader["SoGhe"]),
                            TinhTrang = reader["TinhTrang"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public bool KiemTraTrungBienSo(string bienSo, int maXeKiemTra)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Xe WHERE BienSo = @BienSo AND MaXe != @MaXe";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BienSo", bienSo);
                    cmd.Parameters.AddWithValue("@MaXe", maXeKiemTra);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        public void ThemXe(XeDTO xe)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO Xe (BienSo, LoaiXe, SoGhe, TinhTrang) 
                                 VALUES (@BienSo, @LoaiXe, @SoGhe, @TinhTrang)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BienSo", xe.BienSo);
                    cmd.Parameters.AddWithValue("@LoaiXe", xe.LoaiXe);
                    cmd.Parameters.AddWithValue("@SoGhe", xe.SoGhe);
                    cmd.Parameters.AddWithValue("@TinhTrang", xe.TinhTrang);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void SuaXe(XeDTO xe)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE Xe 
                                 SET BienSo = @BienSo, LoaiXe = @LoaiXe, SoGhe = @SoGhe, TinhTrang = @TinhTrang 
                                 WHERE MaXe = @MaXe";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaXe", xe.MaXe);
                    cmd.Parameters.AddWithValue("@BienSo", xe.BienSo);
                    cmd.Parameters.AddWithValue("@LoaiXe", xe.LoaiXe);
                    cmd.Parameters.AddWithValue("@SoGhe", xe.SoGhe);
                    cmd.Parameters.AddWithValue("@TinhTrang", xe.TinhTrang);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void XoaXe(int maXe)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Xe WHERE MaXe = @MaXe", conn))
                    {
                        cmd.Parameters.AddWithValue("@MaXe", maXe);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    // Lỗi 547 là lỗi vi phạm khóa ngoại (Xe này đã được ghép vào Tuyến/Chuyến)
                    if (ex.Number == 547)
                        throw new Exception("Không thể xóa xe này vì nó đang được xếp vào các chuyến xe!");
                    else
                        throw new Exception("Lỗi CSDL: " + ex.Message);
                }
            }
        }

        public List<XeDTO> TimKiemChung(string tuKhoa)
        {
            List<XeDTO> list = new List<XeDTO>();
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT MaXe, BienSo, LoaiXe, SoGhe, TinhTrang 
                                 FROM Xe 
                                 WHERE BienSo LIKE @TuKhoa 
                                    OR LoaiXe LIKE @TuKhoa 
                                    OR TinhTrang LIKE @TuKhoa";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new XeDTO
                            {
                                MaXe = Convert.ToInt32(reader["MaXe"]),
                                BienSo = reader["BienSo"].ToString(),
                                LoaiXe = reader["LoaiXe"].ToString(),
                                SoGhe = Convert.ToInt32(reader["SoGhe"]),
                                TinhTrang = reader["TinhTrang"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }

        public List<XeDTO> TimKiemChiTiet(XeDTO dieuKien)
        {
            List<XeDTO> list = new List<XeDTO>();
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                List<string> conditions = new List<string>();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if (!string.IsNullOrWhiteSpace(dieuKien.BienSo))
                {
                    conditions.Add("BienSo LIKE @BienSo");
                    cmd.Parameters.AddWithValue("@BienSo", "%" + dieuKien.BienSo + "%");
                }
                if (!string.IsNullOrWhiteSpace(dieuKien.LoaiXe))
                {
                    conditions.Add("LoaiXe = @LoaiXe");
                    cmd.Parameters.AddWithValue("@LoaiXe", dieuKien.LoaiXe);
                }
                if (!string.IsNullOrWhiteSpace(dieuKien.TinhTrang))
                {
                    conditions.Add("TinhTrang = @TinhTrang");
                    cmd.Parameters.AddWithValue("@TinhTrang", dieuKien.TinhTrang);
                }
                if (dieuKien.SoGhe > 0)
                {
                    conditions.Add("SoGhe = @SoGhe");
                    cmd.Parameters.AddWithValue("@SoGhe", dieuKien.SoGhe);
                }

                string query = "SELECT MaXe, BienSo, LoaiXe, SoGhe, TinhTrang FROM Xe";
                if (conditions.Count > 0)
                {
                    query += " WHERE " + string.Join(" AND ", conditions);
                }
                cmd.CommandText = query;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new XeDTO
                        {
                            MaXe = Convert.ToInt32(reader["MaXe"]),
                            BienSo = reader["BienSo"].ToString(),
                            LoaiXe = reader["LoaiXe"].ToString(),
                            SoGhe = Convert.ToInt32(reader["SoGhe"]),
                            TinhTrang = reader["TinhTrang"].ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}
