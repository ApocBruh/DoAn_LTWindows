using DoAn_LTWindows.DAL;
using DoAn_LTWindows.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWindows.BUS
{
    internal class NhanVienBUS
    {
        private NhanVienDAL dal = new NhanVienDAL();

        public NhanVienDTO KiemTraDangNhap(string user, string pass)
        {
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                throw new Exception("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu!");
            }

            return dal.KiemTraDangNhap(user, pass);
        }
    }
}
