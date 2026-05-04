using DoAn_LTWindows.DAL;
using DoAn_LTWindows.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWindows.BUS
{
    internal class TuyenXeNgoaiThanhBUS
    {
        private TuyenXeNgoaiThanhDAL dal = new TuyenXeNgoaiThanhDAL();

        public List<TuyenXeNgoaiThanhDTO> LayDanhSachTuyen()
        {
            return dal.LayDanhSachTuyen();
        }
    }
}
