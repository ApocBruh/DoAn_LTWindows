using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWindows.DTO
{
    internal class KhachHangDTO
    {
        public string SoDienThoai { get; set; }
        public string TenKhachHang { get; set; }
        public string DiaChi { get; set; }

        // Cột này chỉ dùng để hiển thị (Được tính tự động bằng lệnh SQL)
        public int TongSoVeDaMua { get; set; }
    }
}
