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
    public partial class ucTuyenNoiThanh : UserControl
    {
        public ucTuyenNoiThanh()
        {
            InitializeComponent();
        }

        private void btn_Return_Click(object sender, EventArgs e)
        {
            ucChonTuyen uc = new ucChonTuyen();
            frmMain.Instance.NavigationControl(uc);
        }
    }
}
