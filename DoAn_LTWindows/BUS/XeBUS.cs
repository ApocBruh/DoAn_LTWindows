using DoAn_LTWindows.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn_LTWindows.DAL;

namespace DoAn_LTWindows.BUS
{
    internal class XeBUS
    {
        private XeDAL dal = new XeDAL();

        public List<XeDTO> LayDanhSachXe() => dal.LayDanhSachXe();

        public void ThemXe(XeDTO xe)
        {
            if (string.IsNullOrWhiteSpace(xe.BienSo) || string.IsNullOrWhiteSpace(xe.LoaiXe) || string.IsNullOrWhiteSpace(xe.TinhTrang))
                throw new Exception("Vui lòng điền đầy đủ Biển số, Loại xe và Tình trạng!");

            if (dal.KiemTraTrungBienSo(xe.BienSo, -1))
                throw new Exception("Biển số xe này đã tồn tại trong hệ thống!");

            dal.ThemXe(xe);
        }

        public void SuaXe(XeDTO xe)
        {
            if (xe.MaXe <= 0)
                throw new Exception("Vui lòng chọn một xe trên lưới để sửa!");

            if (string.IsNullOrWhiteSpace(xe.BienSo) || string.IsNullOrWhiteSpace(xe.LoaiXe) || string.IsNullOrWhiteSpace(xe.TinhTrang))
                throw new Exception("Vui lòng điền đầy đủ Biển số, Loại xe và Tình trạng!");

            if (dal.KiemTraTrungBienSo(xe.BienSo, xe.MaXe))
                throw new Exception("Biển số xe này đang bị trùng với một xe khác trong hệ thống!");

            dal.SuaXe(xe);
        }

        public void XoaXe(int maXe)
        {
            if (maXe <= 0)
                throw new Exception("Vui lòng chọn một xe để xóa!");

            dal.XoaXe(maXe);
        }

        public List<XeDTO> TimKiemChung(string tuKhoa) => dal.TimKiemChung(tuKhoa);

        public List<XeDTO> TimKiemChiTiet(XeDTO dieuKien) => dal.TimKiemChiTiet(dieuKien);
    }
}
