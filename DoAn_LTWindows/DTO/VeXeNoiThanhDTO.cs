using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWindows.DTO
{
    internal class VeXeNoiThanhDTO
    {
        public string MaSoVe { get; set; }
        public int MaTuyen { get; set; }
        public string HinhThucThanhToan { get; set; }
        public DateTime ThoiGian { get; set; }
        public decimal GiaVe { get; set; }

        // Các thuộc tính dùng để hiển thị trên UI, không nhất thiết lưu CSDL
        public string TuyenXe { get; set; }
        public string SoXe { get; set; }
        public string TenTram { get; set; }
    }
}
