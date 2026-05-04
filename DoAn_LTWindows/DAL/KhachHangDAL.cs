using DoAn_LTWindows.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWindows.DAL
{
    internal class KhachHangDAL
    {
        public List<KhachHangDTO> LayDanhSachKhachHang()
        {
            List<KhachHangDTO> list = new List<KhachHangDTO>();
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                // Subquery đếm số lượng vé hợp lệ (Trạng Thái = 1) bên bảng VeXeNgoaiThanh
                string query = @"
                    SELECT 
                        kh.SoDienThoai, 
                        kh.TenKhachHang, 
                        kh.DiaChi, 
                        ISNULL((SELECT COUNT(*) FROM VeXeNgoaiThanh v WHERE v.SoDienThoai = kh.SoDienThoai AND v.TrangThai = 1), 0) AS TongSoVe
                    FROM KhachHang kh";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new KhachHangDTO
                        {
                            SoDienThoai = reader["SoDienThoai"].ToString(),
                            TenKhachHang = reader["TenKhachHang"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            TongSoVeDaMua = Convert.ToInt32(reader["TongSoVe"])
                        });
                    }
                }
            }
            return list;
        }

        public bool KiemTraTonTai(string sdt)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM KhachHang WHERE SoDienThoai = @SDT", conn);
                cmd.Parameters.AddWithValue("@SDT", sdt);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public void ThemKhachHang(KhachHangDTO kh)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO KhachHang (SoDienThoai, TenKhachHang, DiaChi) VALUES (@SDT, @Ten, @DiaChi)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SDT", kh.SoDienThoai);
                    cmd.Parameters.AddWithValue("@Ten", kh.TenKhachHang);
                    cmd.Parameters.AddWithValue("@DiaChi", string.IsNullOrEmpty(kh.DiaChi) ? (object)DBNull.Value : kh.DiaChi);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void SuaKhachHang(KhachHangDTO kh)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE KhachHang SET TenKhachHang = @Ten, DiaChi = @DiaChi WHERE SoDienThoai = @SDT";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SDT", kh.SoDienThoai);
                    cmd.Parameters.AddWithValue("@Ten", kh.TenKhachHang);
                    cmd.Parameters.AddWithValue("@DiaChi", string.IsNullOrEmpty(kh.DiaChi) ? (object)DBNull.Value : kh.DiaChi);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void XoaKhachHang(string sdt)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM KhachHang WHERE SoDienThoai = @SDT", conn);
                    cmd.Parameters.AddWithValue("@SDT", sdt);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                        throw new Exception("Không thể xóa khách hàng này vì họ đang có lịch sử mua vé trong hệ thống!");
                    else
                        throw new Exception("Lỗi CSDL: " + ex.Message);
                }
            }
        }

        public List<KhachHangDTO> TimKiemChung(string tuKhoa)
        {
            List<KhachHangDTO> list = new List<KhachHangDTO>();
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT 
                        kh.SoDienThoai, kh.TenKhachHang, kh.DiaChi, 
                        ISNULL((SELECT COUNT(*) FROM VeXeNgoaiThanh v WHERE v.SoDienThoai = kh.SoDienThoai AND v.TrangThai = 1), 0) AS TongSoVe
                    FROM KhachHang kh
                    WHERE kh.SoDienThoai LIKE @TuKhoa OR kh.TenKhachHang LIKE @TuKhoa OR kh.DiaChi LIKE @TuKhoa";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new KhachHangDTO
                            {
                                SoDienThoai = reader["SoDienThoai"].ToString(),
                                TenKhachHang = reader["TenKhachHang"].ToString(),
                                DiaChi = reader["DiaChi"].ToString(),
                                TongSoVeDaMua = Convert.ToInt32(reader["TongSoVe"])
                            });
                        }
                    }
                }
            }
            return list;
        }

        public List<KhachHangDTO> TimKiemChiTiet(KhachHangDTO dieuKien)
        {
            List<KhachHangDTO> list = new List<KhachHangDTO>();
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                List<string> conditions = new List<string>();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if (!string.IsNullOrWhiteSpace(dieuKien.SoDienThoai))
                {
                    conditions.Add("kh.SoDienThoai LIKE @SDT");
                    cmd.Parameters.AddWithValue("@SDT", "%" + dieuKien.SoDienThoai + "%");
                }
                if (!string.IsNullOrWhiteSpace(dieuKien.TenKhachHang))
                {
                    conditions.Add("kh.TenKhachHang LIKE @Ten");
                    cmd.Parameters.AddWithValue("@Ten", "%" + dieuKien.TenKhachHang + "%");
                }
                if (!string.IsNullOrWhiteSpace(dieuKien.DiaChi))
                {
                    conditions.Add("kh.DiaChi LIKE @DiaChi");
                    cmd.Parameters.AddWithValue("@DiaChi", "%" + dieuKien.DiaChi + "%");
                }

                string query = @"
                    SELECT 
                        kh.SoDienThoai, kh.TenKhachHang, kh.DiaChi, 
                        ISNULL((SELECT COUNT(*) FROM VeXeNgoaiThanh v WHERE v.SoDienThoai = kh.SoDienThoai AND v.TrangThai = 1), 0) AS TongSoVe
                    FROM KhachHang kh";

                if (conditions.Count > 0)
                {
                    query += " WHERE " + string.Join(" AND ", conditions);
                }

                cmd.CommandText = query;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new KhachHangDTO
                        {
                            SoDienThoai = reader["SoDienThoai"].ToString(),
                            TenKhachHang = reader["TenKhachHang"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            TongSoVeDaMua = Convert.ToInt32(reader["TongSoVe"])
                        });
                    }
                }
            }
            return list;
        }
    }
}
