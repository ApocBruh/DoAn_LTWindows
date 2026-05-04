using DoAn_LTWindows.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWindows.DAL
{
    internal class TuyenXeNoiThanhDAL
    {
        public List<TuyenXeNoiThanhDTO> LayDanhSachTuyen()
        {
            List<TuyenXeNoiThanhDTO> listTuyen = new List<TuyenXeNoiThanhDTO>();
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT MaTuyen, TenTuyen, SoXe, TenTram, GiaVe FROM TuyenXeNoiThanh";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listTuyen.Add(new TuyenXeNoiThanhDTO
                        {
                            MaTuyen = Convert.ToInt32(reader["MaTuyen"]),
                            TenTuyen = reader["TenTuyen"].ToString(),
                            SoXe = reader["SoXe"].ToString(),
                            TenTram = reader["TenTram"].ToString(),
                            GiaVe = Convert.ToDecimal(reader["GiaVe"])
                        });
                    }
                }
            }
            return listTuyen;
        }
    }
}
