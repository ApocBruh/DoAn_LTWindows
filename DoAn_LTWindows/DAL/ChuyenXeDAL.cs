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
                conn.Open();

                // BƯỚC 1: Lấy Mã Tuyến và Ngày Xuất Bến của chuyến xe chuẩn bị xóa
                int maTuyen = 0;
                DateTime ngayXuatBen = DateTime.Now;

                string queryGetInfo = "SELECT MaTuyen, ThoiGianXuatBen FROM ChuyenXe WHERE MaChuyen = @MaChuyen";
                using (SqlCommand cmdGet = new SqlCommand(queryGetInfo, conn))
                {
                    cmdGet.Parameters.AddWithValue("@MaChuyen", maChuyen);
                    using (SqlDataReader reader = cmdGet.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            maTuyen = Convert.ToInt32(reader["MaTuyen"]);
                            ngayXuatBen = Convert.ToDateTime(reader["ThoiGianXuatBen"]);
                        }
                        else
                        {
                            throw new Exception("Không tìm thấy chuyến xe trong hệ thống!");
                        }
                    }
                }

                // BƯỚC 2: QUAN TRỌNG NHẤT - Kiểm tra xem Tuyến này, Ngày này đã có khách đặt vé chưa?
                string queryCheck = @"SELECT COUNT(*) FROM VeXeNgoaiThanh 
                              WHERE MaTuyen = @MaTuyen 
                                AND CAST(NgayDi AS DATE) = CAST(@Ngay AS DATE)";
                using (SqlCommand cmdCheck = new SqlCommand(queryCheck, conn))
                {
                    cmdCheck.Parameters.AddWithValue("@MaTuyen", maTuyen);
                    cmdCheck.Parameters.AddWithValue("@Ngay", ngayXuatBen.Date);

                    int soVeDaBan = (int)cmdCheck.ExecuteScalar();

                    // Ràng buộc toàn vẹn dữ liệu: Nếu đã có vé, CHẶN LỆNH XÓA và ném lỗi
                    if (soVeDaBan > 0)
                    {
                        throw new Exception($"Vi phạm ràng buộc toàn vẹn dữ liệu (Error 547)!\nKhông thể xóa chuyến xe vì đã có {soVeDaBan} vé được bán thuộc lịch trình này.");
                    }
                }

                // BƯỚC 3: Nếu qua được vòng kiểm tra (chưa có vé nào bán), tiến hành Xóa an toàn
                string queryDelete = "DELETE FROM ChuyenXe WHERE MaChuyen = @MaChuyen";
                using (SqlCommand cmdDelete = new SqlCommand(queryDelete, conn))
                {
                    cmdDelete.Parameters.AddWithValue("@MaChuyen", maChuyen);
                    cmdDelete.ExecuteNonQuery();
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

        // TỰ ĐỘNG ĐỒNG BỘ VÀ TẠO CHUYẾN XE KHI BÁN VÉ
        public void TaoChuyenXeTuDong(int maTuyen, string tenTuyen, string bienSoXe, decimal giaVe, DateTime ngayXuatBen)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();

                // 1. ĐỒNG BỘ TUYẾN XE (Xử lý dứt điểm lỗi Khóa Ngoại và NOT NULL)
                string checkTuyen = "SELECT COUNT(*) FROM TuyenXe WHERE MaTuyen = @MaTuyen";
                using (SqlCommand cmdTuyen = new SqlCommand(checkTuyen, conn))
                {
                    cmdTuyen.Parameters.AddWithValue("@MaTuyen", maTuyen);
                    int countTuyen = (int)cmdTuyen.ExecuteScalar();

                    if (countTuyen == 0) // Nếu chưa có tuyến này bên bảng TuyenXe
                    {
                        // Bật IDENTITY_INSERT và chèn ĐẦY ĐỦ các cột để không bị dính lỗi NOT NULL
                        string insertTuyen = @"SET IDENTITY_INSERT TuyenXe ON; 
                               INSERT INTO TuyenXe (MaTuyen, TenTuyen, DiemXuatPhat, DiemDen, KhoangCach, ThoiGianChay, LoaiTuyen, GiaVe) 
                               VALUES (@MaTuyen, @TenTuyen, N'Chưa rõ', N'Chưa rõ', 0, 0, 1, @GiaVe); 
                               SET IDENTITY_INSERT TuyenXe OFF;";

                        using (SqlCommand cmdInsert = new SqlCommand(insertTuyen, conn))
                        {
                            cmdInsert.Parameters.AddWithValue("@MaTuyen", maTuyen);
                            cmdInsert.Parameters.AddWithValue("@TenTuyen", tenTuyen);
                            cmdInsert.Parameters.AddWithValue("@GiaVe", giaVe);

                            cmdInsert.ExecuteNonQuery(); // Thực thi một phát ăn ngay!
                        }
                    }
                }

                // 2. KIỂM TRA CHUYẾN XE (Tránh tạo trùng lịch)
                string checkChuyen = @"SELECT COUNT(*) FROM ChuyenXe 
                                       WHERE MaTuyen = @MaTuyen AND CAST(ThoiGianXuatBen AS DATE) = CAST(@Ngay AS DATE)";
                using (SqlCommand cmdCheck = new SqlCommand(checkChuyen, conn))
                {
                    cmdCheck.Parameters.AddWithValue("@MaTuyen", maTuyen);
                    cmdCheck.Parameters.AddWithValue("@Ngay", ngayXuatBen.Date);
                    if ((int)cmdCheck.ExecuteScalar() > 0) return; // Đã có chuyến thì bỏ qua
                }

                // 3. TÌM ID XE (Dựa vào Biển Số)
                int maXe = 1;
                using (SqlCommand cmdGetXe = new SqlCommand("SELECT TOP 1 MaXe FROM Xe WHERE BienSo = @BienSo", conn))
                {
                    cmdGetXe.Parameters.AddWithValue("@BienSo", bienSoXe);
                    object result = cmdGetXe.ExecuteScalar();
                    if (result != null) maXe = Convert.ToInt32(result);
                    else
                    {
                        // Lấy xe mặc định nếu biển số sai
                        using (SqlCommand cmdFb = new SqlCommand("SELECT TOP 1 MaXe FROM Xe", conn))
                        {
                            object fb = cmdFb.ExecuteScalar();
                            if (fb != null) maXe = Convert.ToInt32(fb);
                        }
                    }
                }

                // 4. TẠO CHUYẾN XE MỚI
                string insertChuyen = @"INSERT INTO ChuyenXe (MaTuyen, MaXe, GiaVe, ThoiGianXuatBen) 
                                        VALUES (@MaTuyen, @MaXe, @GiaVe, @ThoiGian)";
                using (SqlCommand cmdInsertChuyen = new SqlCommand(insertChuyen, conn))
                {
                    cmdInsertChuyen.Parameters.AddWithValue("@MaTuyen", maTuyen);
                    cmdInsertChuyen.Parameters.AddWithValue("@MaXe", maXe);
                    cmdInsertChuyen.Parameters.AddWithValue("@GiaVe", giaVe);
                    cmdInsertChuyen.Parameters.AddWithValue("@ThoiGian", ngayXuatBen);
                    cmdInsertChuyen.ExecuteNonQuery();
                }
            }
        }
    }
}
