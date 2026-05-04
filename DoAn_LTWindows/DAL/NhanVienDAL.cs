using DoAn_LTWindows.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWindows.DAL
{
    internal class NhanVienDAL
    {
        public NhanVienDTO KiemTraDangNhap(string user, string pass)
        {
            // Sử dụng DBConnection đã tạo từ module trước
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT TenNhanVien, VaiTro FROM NhanVien WHERE TenDangNhap = @user AND MatKhau = @pass AND TrangThai = 1";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@pass", pass);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // Nếu tìm thấy user
                        {
                            return new NhanVienDTO
                            {
                                TenNhanVien = reader["TenNhanVien"].ToString(),
                                VaiTro = reader["VaiTro"].ToString()
                            };
                        }
                    }
                }
            }
            return null; // Trả về null nếu sai tài khoản/mật khẩu
        }
    }
}
