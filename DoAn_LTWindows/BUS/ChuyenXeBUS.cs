using System.Data;
using DoAn_LTWindows.DAL;
using DoAn_LTWindows.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWindows.BUS
{
    internal class ChuyenXeBUS
    {
        private ChuyenXeDAL dal = new ChuyenXeDAL();

        public DataTable LayDanhSachTuyen() => dal.LayDanhSachTuyen();
        public DataTable LayDanhSachXe() => dal.LayDanhSachXe();
        public List<ChuyenXeDTO> LayTatCaChuyenXe() => dal.LayTatCaChuyenXe();

        public void ThemChuyenXe(ChuyenXeDTO chuyen)
        {
            if (chuyen.MaTuyen <= 0 || chuyen.MaXe <= 0)
                throw new Exception("Vui lòng chọn Tuyến Xe và Xe!");
            if (chuyen.GiaVe <= 0)
                throw new Exception("Giá vé không hợp lệ! Vui lòng kiểm tra lại.");

            dal.ThemChuyenXe(chuyen);
        }

        public void SuaChuyenXe(ChuyenXeDTO chuyen)
        {
            if (chuyen.MaChuyen <= 0)
                throw new Exception("Vui lòng chọn một chuyến xe trên lưới để sửa!");
            if (chuyen.MaTuyen <= 0 || chuyen.MaXe <= 0)
                throw new Exception("Vui lòng chọn Tuyến Xe và Xe hợp lệ!");

            dal.SuaChuyenXe(chuyen);
        }

        public void XoaChuyenXe(int maChuyen)
        {
            if (maChuyen <= 0)
                throw new Exception("Vui lòng chọn một chuyến xe để xóa!");

            dal.XoaChuyenXe(maChuyen);
        }

        public List<ChuyenXeDTO> TimKiemChung(string tuKhoa) => dal.TimKiemChung(tuKhoa);

        public List<ChuyenXeDTO> TimKiemChiTiet(ChuyenXeDTO dieuKien) => dal.TimKiemChiTiet(dieuKien);
    }
}
