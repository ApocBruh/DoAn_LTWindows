using DoAn_LTWindows.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWindows.DAL
{
    internal class VeXeNoiThanhDAL
    {
        public void LuuDanhSachVe(List<VeXeNoiThanhDTO> danhSachVe)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                // Dùng Transaction để đảm bảo nếu lỗi giữa chừng thì hủy toàn bộ
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string query = @"INSERT INTO VeXeNoiThanh 
                                         (MaSoVe, MaTuyen, HinhThucThanhToan, ThoiGian, GiaVe) 
                                         VALUES (@MaSoVe, @MaTuyen, @HTTT, @ThoiGian, @GiaVe)";

                        using (SqlCommand cmd = new SqlCommand(query, conn, trans))
                        {
                            foreach (var ve in danhSachVe)
                            {
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@MaSoVe", ve.MaSoVe);
                                cmd.Parameters.AddWithValue("@MaTuyen", ve.MaTuyen);
                                cmd.Parameters.AddWithValue("@HTTT", ve.HinhThucThanhToan);
                                cmd.Parameters.AddWithValue("@ThoiGian", ve.ThoiGian);
                                cmd.Parameters.AddWithValue("@GiaVe", ve.GiaVe);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw; // Ném lỗi ngược lên BUS xử lý
                    }
                }
            }
        }
    }
}
