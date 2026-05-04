using DoAn_LTWindows.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWindows.DAL
{
    internal class BaoCaoDoanhThuDAL
    {
        public List<BaoCaoDoanhThuDTO> LayBaoCaoDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            List<BaoCaoDoanhThuDTO> list = new List<BaoCaoDoanhThuDTO>();
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT MaSoVe, N'Nội Thành' AS LoaiVe, GiaVe, ThoiGian AS NgayGiaoDich 
                    FROM VeXeNoiThanh WHERE CAST(ThoiGian AS DATE) BETWEEN @TuNgay AND @DenNgay AND TrangThai = 1
                    
                    UNION ALL
                    
                    SELECT MaSoVe, N'Ngoại Thành' AS LoaiVe, GiaVe, ThoiGian AS NgayGiaoDich 
                    FROM VeXeNgoaiThanh WHERE CAST(ThoiGian AS DATE) BETWEEN @TuNgay AND @DenNgay AND TrangThai = 1
                    
                    ORDER BY NgayGiaoDich DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cmd.Parameters.AddWithValue("@DenNgay", denNgay);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new BaoCaoDoanhThuDTO
                            {
                                MaSoVe = reader["MaSoVe"].ToString(),
                                LoaiVe = reader["LoaiVe"].ToString(),
                                GiaVe = Convert.ToDecimal(reader["GiaVe"]),
                                NgayGiaoDich = Convert.ToDateTime(reader["NgayGiaoDich"])
                            });
                        }
                    }
                }
            }
            return list;
        }
    }
}
