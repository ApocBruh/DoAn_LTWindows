using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWindows.DTO
{
    internal class TaiKhoanDTO
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string TenNhanVien { get; set; }
        public string VaiTro { get; set; }
        public int TrangThai { get; set; }

        // Trường ảo dùng để hiển thị chữ "Kích Hoạt" / "Khóa" trên GridView
        public string TrangThaiText
        {
            get { return TrangThai == 1 ? "Kích Hoạt" : "Khóa"; }
        }
    }
}
