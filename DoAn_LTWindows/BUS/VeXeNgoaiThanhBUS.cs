using DoAn_LTWindows.DAL;
using DoAn_LTWindows.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWindows.BUS
{
    internal class VeXeNgoaiThanhBUS
    {
        private VeXeNgoaiThanhDAL dal = new VeXeNgoaiThanhDAL();

        public void LuuDanhSachVe(List<VeXeNgoaiThanhDTO> danhSachVe)
        {
            if (danhSachVe == null || danhSachVe.Count == 0)
                throw new Exception("Danh sách vé trống!");

            dal.LuuDanhSachVe(danhSachVe);
        }
    }
}
