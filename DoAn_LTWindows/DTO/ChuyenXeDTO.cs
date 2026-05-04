using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWindows.DTO
{
    internal class ChuyenXeDTO
    {
        public int MaChuyen { get; set; }
        public int MaTuyen { get; set; }
        public int MaXe { get; set; }
        public decimal GiaVe { get; set; }
        public DateTime ThoiGianXuatBen { get; set; }

        // --- CÁC TRƯỜNG PHỤ DÙNG ĐỂ HIỂN THỊ (Sẽ được lấy lên qua lệnh JOIN) ---
        public string TenTuyen { get; set; }
        public string BienSo { get; set; }
    }
}
