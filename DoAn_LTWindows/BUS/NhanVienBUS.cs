using DoAn_LTWindows.DAL;
using DoAn_LTWindows.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DoAn_LTWindows.BUS
{
    internal class NhanVienBUS
    {
        private NhanVienDAL dal = new NhanVienDAL();

        public NhanVienDTO KiemTraDangNhap(string user, string pass)
        {
            // 1. Kiểm tra rỗng
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                throw new Exception("Tài khoản và mật khẩu không được để trống!");
            }

            // 2. Kiểm tra ký tự đặc biệt
            if (!Regex.IsMatch(user, @"^[a-zA-Z0-9]+$"))
            {
                throw new Exception("Tên đăng nhập chứa ký tự không hợp lệ!");
            }

            // 3. Gọi đúng tên biến "dal" đã khai báo
            return dal.KiemTraDangNhap(user, pass);
        }
    }
}
