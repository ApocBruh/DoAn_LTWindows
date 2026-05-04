using DoAn_LTWindows.DAL;
using DoAn_LTWindows.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWindows.BUS
{
    internal class TuyenXeBUS
    {
        private TuyenXeDAL dal = new TuyenXeDAL();

        public List<TuyenXeDTO> LayDanhSachTuyen()
        {
            return dal.LayDanhSachTuyen();
        }

        public void ThemTuyenXe(TuyenXeDTO tuyen)
        {
            if (tuyen.MaTuyen <= 0)
                throw new Exception("Mã Tuyến phải là một số lớn hơn 0!");
            if (string.IsNullOrWhiteSpace(tuyen.TenTuyen))
                throw new Exception("Tên Tuyến không được để trống!");
            if (dal.KiemTraTonTai(tuyen.MaTuyen))
                throw new Exception("Mã Tuyến này đã tồn tại! Nếu muốn cập nhật, vui lòng dùng nút SỬA.");

            dal.ThemTuyenXe(tuyen);
        }

        public void SuaTuyenXe(TuyenXeDTO tuyen)
        {
            if (tuyen.MaTuyen <= 0)
                throw new Exception("Vui lòng chọn một tuyến xe hợp lệ để sửa!");
            if (string.IsNullOrWhiteSpace(tuyen.TenTuyen))
                throw new Exception("Tên Tuyến không được để trống!");

            dal.SuaTuyenXe(tuyen);
        }

        public void XoaTuyenXe(int maTuyen)
        {
            if (maTuyen <= 0)
                throw new Exception("Vui lòng chọn một tuyến xe để xóa!");

            dal.XoaTuyenXe(maTuyen);
        }

        public List<TuyenXeDTO> TimKiemChung(string tuKhoa)
        {
            return dal.TimKiemChung(tuKhoa);
        }

        public List<TuyenXeDTO> TimKiemChiTiet(TuyenXeDTO dieuKien)
        {
            return dal.TimKiemChiTiet(dieuKien);
        }
    }
}
