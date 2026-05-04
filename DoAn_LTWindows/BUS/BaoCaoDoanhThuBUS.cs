using DoAn_LTWindows.DAL;
using DoAn_LTWindows.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWindows.BUS
{
    internal class BaoCaoDoanhThuBUS
    {
        private BaoCaoDoanhThuDAL dal = new BaoCaoDoanhThuDAL();

        public List<BaoCaoDoanhThuDTO> LayBaoCaoDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            if (tuNgay > denNgay)
            {
                throw new Exception("Khoảng thời gian không hợp lệ!\nNgày bắt đầu (Từ Ngày) không thể lớn hơn ngày kết thúc (Đến Ngày).");
            }

            return dal.LayBaoCaoDoanhThu(tuNgay, denNgay);
        }
    }
}
