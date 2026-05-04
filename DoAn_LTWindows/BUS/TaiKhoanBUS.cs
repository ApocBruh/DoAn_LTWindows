using DoAn_LTWindows.DAL;
using DoAn_LTWindows.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWindows.BUS
{
    internal class TaiKhoanBUS
    {
        private TaiKhoanDAL dal = new TaiKhoanDAL();

        public List<TaiKhoanDTO> LayTatCaTaiKhoan() => dal.LayTatCaTaiKhoan();

        public void ThemTaiKhoan(TaiKhoanDTO tk)
        {
            if (string.IsNullOrWhiteSpace(tk.TenDangNhap) || string.IsNullOrWhiteSpace(tk.MatKhau) ||
                string.IsNullOrWhiteSpace(tk.TenNhanVien) || string.IsNullOrWhiteSpace(tk.VaiTro))
            {
                throw new Exception("Vui lòng điền đầy đủ thông tin!");
            }

            if (dal.KiemTraTonTai(tk.TenDangNhap))
            {
                throw new Exception("Tên đăng nhập đã tồn tại!");
            }

            dal.ThemTaiKhoan(tk);
        }

        public void SuaTaiKhoan(TaiKhoanDTO tk)
        {
            if (string.IsNullOrWhiteSpace(tk.TenDangNhap))
                throw new Exception("Vui lòng chọn tài khoản cần sửa!");

            if (string.IsNullOrWhiteSpace(tk.MatKhau) || string.IsNullOrWhiteSpace(tk.TenNhanVien) || string.IsNullOrWhiteSpace(tk.VaiTro))
                throw new Exception("Vui lòng điền đầy đủ thông tin!");

            dal.SuaTaiKhoan(tk);
        }

        public void XoaTaiKhoan(string tenDangNhap)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap))
                throw new Exception("Vui lòng chọn tài khoản cần xóa!");

            if (tenDangNhap.ToLower() == "admin")
                throw new Exception("Bạn không thể xóa tài khoản Admin gốc của hệ thống!");

            dal.XoaTaiKhoan(tenDangNhap);
        }

        public List<TaiKhoanDTO> TimKiemChung(string tuKhoa) => dal.TimKiemChung(tuKhoa);

        public List<TaiKhoanDTO> TimKiemChiTiet(TaiKhoanDTO dieuKien) => dal.TimKiemChiTiet(dieuKien);
    }
}
