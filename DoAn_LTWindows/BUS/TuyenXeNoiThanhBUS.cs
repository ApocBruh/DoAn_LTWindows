using DoAn_LTWindows.DAL;
using DoAn_LTWindows.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWindows.BUS
{
    internal class TuyenXeNoiThanhBUS
    {
        private TuyenXeNoiThanhDAL dal = new TuyenXeNoiThanhDAL();

        public List<TuyenXeNoiThanhDTO> LayDanhSachTuyen()
        {
            return dal.LayDanhSachTuyen();
        }
    }
}
