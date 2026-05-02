using DoAn_LTWindows.Forms.Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_LTWindows.Forms.Systems
{
    public partial class frmMain : Form
    {
        public static frmMain Instance;

        public frmMain()
        {
            InitializeComponent();

            btn_LogOut.MouseDown += (s, e) => {
                btn_LogOut.BackgroundImage = Properties.Resources.button_c;
            };

            btn_LogOut.MouseUp += (s, e) => {
                btn_LogOut.BackgroundImage = Properties.Resources.button;
            };

            btn_Exit.MouseDown += (s, e) =>
            {
                btn_Exit.BackgroundImage = Properties.Resources.button_c;
            };

            btn_Exit.MouseUp += (s, e) => {
                btn_Exit.BackgroundImage = Properties.Resources.button;
            };

            Instance = this;
        }

        public void NavigationControl(UserControl uc)
        {
            pnl_DashBoard.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnl_DashBoard.Controls.Add(uc);
        }

        public void BackToDashboard()
        {
            pnl_DashBoard.Controls.Clear();
        }

        private void btn_BanVe_Click(object sender, EventArgs e)
        {
            ucChonTuyen uc = new ucChonTuyen();
            NavigationControl(uc);
        }

        private void btn_LichTrinh_Click(object sender, EventArgs e)
        {
            ucQuanLyChuyenXe uc = new ucQuanLyChuyenXe();
            NavigationControl(uc);
        }

        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            ucQuanLyKhachHang uc = new ucQuanLyKhachHang();
            NavigationControl(uc);
        }

        private void btn_BaoCaoDoanhThu_Click(object sender, EventArgs e)
        {
            ucBaoCaoDoanhThu uc = new ucBaoCaoDoanhThu();
            NavigationControl(uc);
        }

        private void btn_QuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            ucQuanLyTaiKhoan uc = new ucQuanLyTaiKhoan();
            NavigationControl(uc);
        }

        private void btn_TraCuuVe_Click(object sender, EventArgs e)
        {
            ucTraCuuVe uc = new ucTraCuuVe();
            NavigationControl(uc);
        }

        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
