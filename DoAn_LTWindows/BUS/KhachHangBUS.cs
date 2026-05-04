using DoAn_LTWindows.DAL;
using DoAn_LTWindows.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWindows.BUS
{
    internal class KhachHangBUS
    {
        private KhachHangDAL dal = new KhachHangDAL();

        public List<KhachHangDTO> LayDanhSachKhachHang() => dal.LayDanhSachKhachHang();

        private void ValidateSoDienThoai(string sdt)
        {
            if (string.IsNullOrWhiteSpace(sdt))
                throw new Exception("Vui lòng nhập Số điện thoại!");

            if (sdt.Length != 10 || !sdt.All(char.IsDigit))
                throw new Exception("Số điện thoại không hợp lệ!\nVui lòng nhập chính xác 10 chữ số.");

            string[] dauSoHopLe = {
                "032", "033", "034", "035", "036", "037", "038", "039", "086", "096", "097", "098",
                "081", "082", "083", "084", "085", "088", "091", "094",
                "070", "076", "077", "078", "079", "089", "090", "093",
                "052", "056", "058", "092", "059", "099", "087", "055"
            };

            string prefix = sdt.Substring(0, 3);
            if (!dauSoHopLe.Contains(prefix))
                throw new Exception("Đầu số điện thoại không tồn tại!\nVui lòng kiểm tra lại nhà mạng.");
        }

        public void ThemKhachHang(KhachHangDTO kh)
        {
            if (string.IsNullOrWhiteSpace(kh.TenKhachHang))
                throw new Exception("Tên khách hàng không được để trống!");

            ValidateSoDienThoai(kh.SoDienThoai);

            if (dal.KiemTraTonTai(kh.SoDienThoai))
                throw new Exception("Khách hàng với số điện thoại này đã tồn tại trong hệ thống!");

            dal.ThemKhachHang(kh);
        }

        public void SuaKhachHang(KhachHangDTO kh)
        {
            if (string.IsNullOrWhiteSpace(kh.SoDienThoai))
                throw new Exception("Vui lòng chọn một khách hàng trên lưới để sửa!");

            if (string.IsNullOrWhiteSpace(kh.TenKhachHang))
                throw new Exception("Tên khách hàng không được để trống!");

            dal.SuaKhachHang(kh);
        }

        public void XoaKhachHang(string sdt)
        {
            if (string.IsNullOrWhiteSpace(sdt))
                throw new Exception("Vui lòng chọn một khách hàng để xóa!");

            dal.XoaKhachHang(sdt);
        }

        public List<KhachHangDTO> TimKiemChung(string tuKhoa) => dal.TimKiemChung(tuKhoa);

        public List<KhachHangDTO> TimKiemChiTiet(KhachHangDTO dieuKien) => dal.TimKiemChiTiet(dieuKien);
    }
}
