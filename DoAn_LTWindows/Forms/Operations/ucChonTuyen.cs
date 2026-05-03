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

            btn_TXNoiThanh.MouseDown += (s, e) => {
                btn_TXNoiThanh.BackgroundImage = Properties.Resources.choosebutton1_c;
            };

            btn_TXNoiThanh.MouseUp += (s, e) => {
                btn_TXNoiThanh.BackgroundImage = Properties.Resources.choosebutton1;
            };

            btn_TXNgoaiThanh.MouseDown += (s, e) => {
                btn_TXNgoaiThanh.BackgroundImage = Properties.Resources.choosebutton2_c;
            };

            btn_TXNgoaiThanh.MouseUp += (s, e) => {
                btn_TXNgoaiThanh.BackgroundImage = Properties.Resources.choosebutton2;
            };
            btn_Return.MouseDown += (s, e) => {
                btn_Return.BackgroundImage = Properties.Resources._75pxbtn1_c;
            };

            btn_Return.MouseUp += (s, e) => {
                btn_Return.BackgroundImage = Properties.Resources._75pxbtn1;
            };
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
