using DoAn_LTWindows.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWindows.DAL
{
    internal class TuyenXeNgoaiThanhDAL
    {
        public List<TuyenXeNgoaiThanhDTO> LayDanhSachTuyen()
        {
            List<TuyenXeNgoaiThanhDTO> list = new List<TuyenXeNgoaiThanhDTO>();
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT MaTuyen, TenTuyen, SoGheTieuChuan, SoXe, TenTram, GiaVe FROM TuyenXeNgoaiThanh";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TuyenXeNgoaiThanhDTO
                        {
                            MaTuyen = Convert.ToInt32(reader["MaTuyen"]),
                            TenTuyen = reader["TenTuyen"].ToString(),
                            SoGheTieuChuan = Convert.ToInt32(reader["SoGheTieuChuan"]),
                            SoXe = reader["SoXe"].ToString(),
                            TenTram = reader["TenTram"].ToString(),
                            GiaVe = Convert.ToDecimal(reader["GiaVe"])
                        });
                    }
                }
            }
            return list;
        }
    }
}
