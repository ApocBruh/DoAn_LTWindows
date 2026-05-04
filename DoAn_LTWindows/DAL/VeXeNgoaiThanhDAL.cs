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
    }
}
