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
    public partial class ucLuaChonLichTrinh : UserControl
    {
        public ucLuaChonLichTrinh()
        {
            InitializeComponent();

            btn_QLChuyenXe.MouseDown += (s, e) => {
                btn_QLChuyenXe.BackgroundImage = Properties.Resources.choosebutton02_c;
            };

            btn_QLChuyenXe.MouseUp += (s, e) => {
                btn_QLChuyenXe.BackgroundImage = Properties.Resources.choosebutton02;
            };

            btn_QLTuyenXe.MouseDown += (s, e) => {
                btn_QLTuyenXe.BackgroundImage = Properties.Resources.choosebutton03_c;
            };

            btn_QLTuyenXe.MouseUp += (s, e) => {
                btn_QLTuyenXe.BackgroundImage = Properties.Resources.choosebutton03;
            };

            btn_QLXe.MouseDown += (s, e) => {
                btn_QLXe.BackgroundImage = Properties.Resources.choosebutton01_c;
            };

            btn_QLXe.MouseUp += (s, e) => {
                btn_QLXe.BackgroundImage = Properties.Resources.choosebutton01;
            };

            btn_Return.MouseDown += (s, e) => {
                btn_Return.BackgroundImage = Properties.Resources._75pxbtn1_c;
            };

            btn_Return.MouseUp += (s, e) => {
                btn_Return.BackgroundImage = Properties.Resources._75pxbtn1;
            };
        }
        private void btn_QLChuyenXe_Click(object sender, EventArgs e)
        {
            ucQuanLyChuyenXe uc = new ucQuanLyChuyenXe();
            frmMain.Instance.NavigationControl(uc);
        }

        private void btn_QLTuyenXe_Click(object sender, EventArgs e)
        {
            ucQuanLyTuyenXe uc = new ucQuanLyTuyenXe();
            frmMain.Instance.NavigationControl(uc);
        }
        private void btn_QLXe_Click(object sender, EventArgs e)
        {
            ucQuanLyXe uc = new ucQuanLyXe();
            frmMain.Instance.NavigationControl(uc);
        }

        private void btn_Return_Click(object sender, EventArgs e)
        {
            frmMain.Instance.BackToDashboard();
        }
    }
}
