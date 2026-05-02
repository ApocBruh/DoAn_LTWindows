using DoAn_LTWindows.Forms.Systems;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_LTWindows.Forms.Operations
{
    public partial class ucChonTuyen : UserControl
    {
        public ucChonTuyen()
        {
            InitializeComponent();
        }

        private void btn_NoiThanh_Click(object sender, EventArgs e)
        {
            ucTuyenNoiThanh uc = new ucTuyenNoiThanh();
            frmMain.Instance.NavigationControl(uc);
        }

        private void btn_NgoaiThanh_Click(object sender, EventArgs e)
        {
            ucTuyenNgoaiThanh uc = new ucTuyenNgoaiThanh();
            frmMain.Instance.NavigationControl(uc);
        }

        private void btn_Return_Click(object sender, EventArgs e)
        {
            frmMain.Instance.BackToDashboard();
        }
    }
}
