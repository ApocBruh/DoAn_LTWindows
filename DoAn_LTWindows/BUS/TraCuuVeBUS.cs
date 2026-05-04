using DoAn_LTWindows.DAL;
using DoAn_LTWindows.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWindows.BUS
{
    internal class TraCuuVeBUS
    {
        private TraCuuVeDAL dal = new TraCuuVeDAL();

        public List<VeXeDTO> LayDanhSachVe(string tuKhoa = "", bool timTheoMaVe = true)
        {
            return dal.LayDanhSachVe(tuKhoa, timTheoMaVe);
        }

        public void HuyVe(VeXeDTO ve)
        {
            // Các Validation được đưa vào BUS
            if (ve.TrangThai == 0)
            {
                throw new Exception("Vé đã hủy trước đó!");
            }

            if (ve.NgayDi < DateTime.Now)
            {
                throw new Exception("Chuyến xe đã khởi hành, không thể hủy!");
            }

            // Đủ điều kiện thì tiến hành xuống DAL
            dal.HuyVe(ve.MaSoVe, ve.LoaiVe);
        }
    }
}
