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
        // THÊM: Bổ sung tham số int maTuyen vào hàm
        public List<BaoCaoDoanhThuDTO> LayBaoCaoDoanhThu(DateTime tuNgay, DateTime denNgay, int maTuyen)
        {
            List<BaoCaoDoanhThuDTO> list = new List<BaoCaoDoanhThuDTO>();
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT MaSoVe, N'Nội Thành' AS LoaiVe, GiaVe, ThoiGian AS NgayGiaoDich 
                    FROM VeXeNoiThanh 
                    WHERE CAST(ThoiGian AS DATE) BETWEEN @TuNgay AND @DenNgay AND TrangThai = 1
                    AND (@MaTuyen = 0 OR MaTuyen = @MaTuyen) -- THÊM: Lọc theo tuyến nội thành
                    
                    UNION ALL
                    
                    SELECT MaSoVe, N'Ngoại Thành' AS LoaiVe, GiaVe, ThoiGian AS NgayGiaoDich 
                    FROM VeXeNgoaiThanh 
                    WHERE CAST(ThoiGian AS DATE) BETWEEN @TuNgay AND @DenNgay AND TrangThai = 1
                    AND (@MaTuyen = 0 OR MaTuyen = @MaTuyen) -- THÊM: Lọc theo tuyến ngoại thành
                    
                    ORDER BY NgayGiaoDich DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cmd.Parameters.AddWithValue("@DenNgay", denNgay);

                    // THÊM
                    cmd.Parameters.AddWithValue("@MaTuyen", maTuyen);

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