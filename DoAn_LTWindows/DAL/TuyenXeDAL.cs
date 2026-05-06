
using DoAn_LTWindows.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWindows.DAL
{
    internal class TuyenXeDAL
    {
        // 1. Lấy toàn bộ danh sách tuyến xe
        public List<TuyenXeDTO> LayDanhSachTuyen()
        {
            List<TuyenXeDTO> list = new List<TuyenXeDTO>();
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT MaTuyen, TenTuyen, DiemXuatPhat, DiemDen, KhoangCach, ThoiGianChay FROM TuyenXe";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TuyenXeDTO
                        {
                            MaTuyen = Convert.ToInt32(reader["MaTuyen"]),
                            TenTuyen = reader["TenTuyen"].ToString(),
                            DiemXuatPhat = reader["DiemXuatPhat"].ToString(),
                            DiemDen = reader["DiemDen"].ToString(),
                            KhoangCach = Convert.ToDecimal(reader["KhoangCach"]),
                            ThoiGianChay = Convert.ToDecimal(reader["ThoiGianChay"])
                        });
                    }
                }
            }
            return list;
        }

        // 2. Kiểm tra mã tuyến đã tồn tại chưa
        public bool KiemTraTonTai(int maTuyen)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM TuyenXe WHERE MaTuyen = @MaTuyen";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaTuyen", maTuyen);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        // 3. Thêm mới
        public void ThemTuyenXe(TuyenXeDTO tuyen)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();

                // BỔ SUNG THÊM CỘT 'GiaVe' VÀO CÂU LỆNH INSERT
                string query = @"INSERT INTO TuyenXe (TenTuyen, DiemXuatPhat, DiemDen, KhoangCach, ThoiGianChay, LoaiTuyen, GiaVe) 
                         VALUES (@TenTuyen, @DiemXuatPhat, @DiemDen, @KhoangCach, @ThoiGianChay, @LoaiTuyen, @GiaVe)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenTuyen", tuyen.TenTuyen);
                    cmd.Parameters.AddWithValue("@DiemXuatPhat", string.IsNullOrEmpty(tuyen.DiemXuatPhat) ? (object)DBNull.Value : tuyen.DiemXuatPhat);
                    cmd.Parameters.AddWithValue("@DiemDen", string.IsNullOrEmpty(tuyen.DiemDen) ? (object)DBNull.Value : tuyen.DiemDen);
                    cmd.Parameters.AddWithValue("@KhoangCach", tuyen.KhoangCach);
                    cmd.Parameters.AddWithValue("@ThoiGianChay", tuyen.ThoiGianChay);
                    cmd.Parameters.AddWithValue("@LoaiTuyen", 1); // Xử lý lỗi Loại tuyến lúc nãy

                    // THÊM DÒNG NÀY ĐỂ XỬ LÝ LỖI GIAVE: Truyền mặc định là 0
                    cmd.Parameters.AddWithValue("@GiaVe", 0);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 4. Cập nhật
        public void SuaTuyenXe(TuyenXeDTO tuyen)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE TuyenXe 
                                 SET TenTuyen = @Ten, DiemXuatPhat = @BatDau, DiemDen = @KetThuc, KhoangCach = @KhoangCach, ThoiGianChay = @ThoiGian 
                                 WHERE MaTuyen = @Ma";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Ma", tuyen.MaTuyen);
                    cmd.Parameters.AddWithValue("@Ten", tuyen.TenTuyen);
                    cmd.Parameters.AddWithValue("@BatDau", tuyen.DiemXuatPhat);
                    cmd.Parameters.AddWithValue("@KetThuc", tuyen.DiemDen);
                    cmd.Parameters.AddWithValue("@KhoangCach", tuyen.KhoangCach);
                    cmd.Parameters.AddWithValue("@ThoiGian", tuyen.ThoiGianChay);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 5. Xóa
        public void XoaTuyenXe(int maTuyen)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM TuyenXe WHERE MaTuyen = @Ma";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ma", maTuyen);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    // Quăng lỗi Khóa Ngoại lên cho BUS
                    if (ex.Number == 547)
                        throw new Exception("Không thể xóa tuyến xe này vì đang có dữ liệu (Chuyến xe/Vé) liên kết với nó!");
                    else
                        throw new Exception("Lỗi CSDL: " + ex.Message);
                }
            }
        }

        // 6. Tìm kiếm chung (Thanh search trên cùng)
        public List<TuyenXeDTO> TimKiemChung(string tuKhoa)
        {
            List<TuyenXeDTO> list = new List<TuyenXeDTO>();
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT MaTuyen, TenTuyen, DiemXuatPhat, DiemDen, KhoangCach, ThoiGianChay 
                                 FROM TuyenXe 
                                 WHERE CAST(MaTuyen AS VARCHAR) LIKE @TuKhoa 
                                    OR TenTuyen LIKE @TuKhoa 
                                    OR DiemXuatPhat LIKE @TuKhoa 
                                    OR DiemDen LIKE @TuKhoa";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new TuyenXeDTO
                            {
                                MaTuyen = Convert.ToInt32(reader["MaTuyen"]),
                                TenTuyen = reader["TenTuyen"].ToString(),
                                DiemXuatPhat = reader["DiemXuatPhat"].ToString(),
                                DiemDen = reader["DiemDen"].ToString(),
                                KhoangCach = Convert.ToDecimal(reader["KhoangCach"]),
                                ThoiGianChay = Convert.ToDecimal(reader["ThoiGianChay"])
                            });
                        }
                    }
                }
            }
            return list;
        }

        // 7. Tìm kiếm chi tiết
        public List<TuyenXeDTO> TimKiemChiTiet(TuyenXeDTO dieuKien)
        {
            List<TuyenXeDTO> list = new List<TuyenXeDTO>();
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                List<string> conditions = new List<string>();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if (dieuKien.MaTuyen > 0)
                {
                    conditions.Add("MaTuyen = @Ma");
                    cmd.Parameters.AddWithValue("@Ma", dieuKien.MaTuyen);
                }
                if (!string.IsNullOrWhiteSpace(dieuKien.TenTuyen))
                {
                    conditions.Add("TenTuyen LIKE @Ten");
                    cmd.Parameters.AddWithValue("@Ten", "%" + dieuKien.TenTuyen + "%");
                }
                if (!string.IsNullOrWhiteSpace(dieuKien.DiemXuatPhat))
                {
                    conditions.Add("DiemXuatPhat LIKE @Start");
                    cmd.Parameters.AddWithValue("@Start", "%" + dieuKien.DiemXuatPhat + "%");
                }
                if (!string.IsNullOrWhiteSpace(dieuKien.DiemDen))
                {
                    conditions.Add("DiemDen LIKE @End");
                    cmd.Parameters.AddWithValue("@End", "%" + dieuKien.DiemDen + "%");
                }
                if (dieuKien.KhoangCach > 0)
                {
                    conditions.Add("KhoangCach = @KhoangCach");
                    cmd.Parameters.AddWithValue("@KhoangCach", dieuKien.KhoangCach);
                }
                if (dieuKien.ThoiGianChay > 0)
                {
                    conditions.Add("ThoiGianChay = @ThoiGian");
                    cmd.Parameters.AddWithValue("@ThoiGian", dieuKien.ThoiGianChay);
                }

                string query = "SELECT MaTuyen, TenTuyen, DiemXuatPhat, DiemDen, KhoangCach, ThoiGianChay FROM TuyenXe";
                if (conditions.Count > 0)
                {
                    query += " WHERE " + string.Join(" AND ", conditions);
                }
                cmd.CommandText = query;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TuyenXeDTO
                        {
                            MaTuyen = Convert.ToInt32(reader["MaTuyen"]),
                            TenTuyen = reader["TenTuyen"].ToString(),
                            DiemXuatPhat = reader["DiemXuatPhat"].ToString(),
                            DiemDen = reader["DiemDen"].ToString(),
                            KhoangCach = Convert.ToDecimal(reader["KhoangCach"]),
                            ThoiGianChay = Convert.ToDecimal(reader["ThoiGianChay"])
                        });
                    }
                }
            }
            return list;
        }
    }
}
