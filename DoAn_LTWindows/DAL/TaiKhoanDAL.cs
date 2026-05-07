using DoAn_LTWindows.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWindows.DAL
{
    internal class TaiKhoanDAL
    {
        public List<TaiKhoanDTO> LayTatCaTaiKhoan()
        {
            List<TaiKhoanDTO> list = new List<TaiKhoanDTO>();
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                // Đã sửa 'TaiKhoan' thành 'NhanVien'
                string query = "SELECT TenDangNhap, MatKhau, TenNhanVien, VaiTro, TrangThai FROM NhanVien";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TaiKhoanDTO
                        {
                            TenDangNhap = reader["TenDangNhap"].ToString(),
                            MatKhau = reader["MatKhau"].ToString(),
                            TenNhanVien = reader["TenNhanVien"].ToString(),
                            VaiTro = reader["VaiTro"].ToString(),
                            TrangThai = Convert.ToInt32(reader["TrangThai"])
                        });
                    }
                }
            }
            return list;
        }

        public bool KiemTraTonTai(string tenDangNhap)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                // Đã sửa 'TaiKhoan' thành 'NhanVien'
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM NhanVien WHERE TenDangNhap = @User", conn);
                cmd.Parameters.AddWithValue("@User", tenDangNhap);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public void ThemTaiKhoan(TaiKhoanDTO tk)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                // Đã sửa 'TaiKhoan' thành 'NhanVien'
                string query = @"INSERT INTO NhanVien (TenDangNhap, MatKhau, TenNhanVien, VaiTro, TrangThai) 
                                 VALUES (@User, @Pass, @Name, @Role, @Status)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@User", tk.TenDangNhap);
                    cmd.Parameters.AddWithValue("@Pass", tk.MatKhau);
                    cmd.Parameters.AddWithValue("@Name", tk.TenNhanVien);
                    cmd.Parameters.AddWithValue("@Role", tk.VaiTro);
                    cmd.Parameters.AddWithValue("@Status", tk.TrangThai);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void SuaTaiKhoan(TaiKhoanDTO tk)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                // Đã sửa 'TaiKhoan' thành 'NhanVien'
                string query = @"UPDATE NhanVien 
                                 SET MatKhau = @Pass, TenNhanVien = @Name, VaiTro = @Role, TrangThai = @Status 
                                 WHERE TenDangNhap = @User";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@User", tk.TenDangNhap);
                    cmd.Parameters.AddWithValue("@Pass", tk.MatKhau);
                    cmd.Parameters.AddWithValue("@Name", tk.TenNhanVien);
                    cmd.Parameters.AddWithValue("@Role", tk.VaiTro);
                    cmd.Parameters.AddWithValue("@Status", tk.TrangThai);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void XoaTaiKhoan(string tenDangNhap)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                // Đã sửa 'TaiKhoan' thành 'NhanVien'
                SqlCommand cmd = new SqlCommand("DELETE FROM NhanVien WHERE TenDangNhap = @User", conn);
                cmd.Parameters.AddWithValue("@User", tenDangNhap);
                cmd.ExecuteNonQuery();
            }
        }

        public List<TaiKhoanDTO> TimKiemChung(string tuKhoa)
        {
            List<TaiKhoanDTO> list = new List<TaiKhoanDTO>();
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                // Đã sửa 'TaiKhoan' thành 'NhanVien'
                string query = @"SELECT TenDangNhap, MatKhau, TenNhanVien, VaiTro, TrangThai 
                                 FROM NhanVien 
                                 WHERE TenDangNhap LIKE @TuKhoa OR TenNhanVien LIKE @TuKhoa";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new TaiKhoanDTO
                            {
                                TenDangNhap = reader["TenDangNhap"].ToString(),
                                MatKhau = reader["MatKhau"].ToString(),
                                TenNhanVien = reader["TenNhanVien"].ToString(),
                                VaiTro = reader["VaiTro"].ToString(),
                                TrangThai = Convert.ToInt32(reader["TrangThai"])
                            });
                        }
                    }
                }
            }
            return list;
        }

        public List<TaiKhoanDTO> TimKiemChiTiet(TaiKhoanDTO dieuKien)
        {
            List<TaiKhoanDTO> list = new List<TaiKhoanDTO>();
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                List<string> conditions = new List<string>();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if (!string.IsNullOrWhiteSpace(dieuKien.TenDangNhap))
                {
                    conditions.Add("TenDangNhap LIKE @User");
                    cmd.Parameters.AddWithValue("@User", "%" + dieuKien.TenDangNhap + "%");
                }
                if (!string.IsNullOrWhiteSpace(dieuKien.TenNhanVien))
                {
                    conditions.Add("TenNhanVien LIKE @Name");
                    cmd.Parameters.AddWithValue("@Name", "%" + dieuKien.TenNhanVien + "%");
                }
                if (!string.IsNullOrWhiteSpace(dieuKien.VaiTro))
                {
                    conditions.Add("VaiTro = @Role");
                    cmd.Parameters.AddWithValue("@Role", dieuKien.VaiTro);
                }

                conditions.Add("TrangThai = @Status");
                cmd.Parameters.AddWithValue("@Status", dieuKien.TrangThai);

                // Đã sửa 'TaiKhoan' thành 'NhanVien'
                string query = "SELECT TenDangNhap, MatKhau, TenNhanVien, VaiTro, TrangThai FROM NhanVien";
                if (conditions.Count > 0)
                {
                    query += " WHERE " + string.Join(" AND ", conditions);
                }

                cmd.CommandText = query;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TaiKhoanDTO
                        {
                            TenDangNhap = reader["TenDangNhap"].ToString(),
                            MatKhau = reader["MatKhau"].ToString(),
                            TenNhanVien = reader["TenNhanVien"].ToString(),
                            VaiTro = reader["VaiTro"].ToString(),
                            TrangThai = Convert.ToInt32(reader["TrangThai"])
                        });
                    }
                }
            }
            return list;
        }
    }
}