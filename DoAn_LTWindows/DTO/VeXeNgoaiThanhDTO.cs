using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWindows.DTO
{
    internal class VeXeNgoaiThanhDTO
    {
        public string MaSoVe { get; set; }
        public string SoDienThoai { get; set; }
        public int MaTuyen { get; set; }
        public string HinhThucThanhToan { get; set; }
        public DateTime ThoiGian { get; set; }
        public DateTime NgayDi { get; set; }
        public string SoGhe { get; set; }
        public decimal GiaVe { get; set; }

        // Các thuộc tính phụ để hiển thị lên UI Popup (Không lưu vào DB)
        public string TuyenXe { get; set; }
        public string SoXe { get; set; }
        public string TenTram { get; set; }
    }
}
