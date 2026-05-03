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
        private string currentUser;
        private string currentRole;

        public frmMain(string tenNguoiDung, string vaiTro)
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
            this.currentUser = tenNguoiDung;
            this.currentRole = vaiTro;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lbl_Username.Text = this.currentUser;
            lbl_RoleName.Text = this.currentRole;

            if (this.currentRole != "Admin")
            {
                // Khóa Quản Lý Tài Khoản
                lbl_HeThong.ForeColor = Color.Gray;
                btn_QuanLyTaiKhoan.Enabled = false;
                btn_QuanLyTaiKhoan.ForeColor = Color.Gray;

                // THÊM: Khóa Báo Cáo Doanh Thu
                btn_BaoCaoDoanhThu.Enabled = false;
                btn_BaoCaoDoanhThu.ForeColor = Color.Gray;
            }
            else
            {
                lbl_HeThong.ForeColor = Color.White;
                btn_QuanLyTaiKhoan.Enabled = true;
                btn_QuanLyTaiKhoan.ForeColor = Color.White;

                // Mở khóa Báo Cáo Doanh Thu
                btn_BaoCaoDoanhThu.Enabled = true;
                btn_BaoCaoDoanhThu.ForeColor = Color.White;
            }
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
            ucLuaChonLichTrinh uc = new ucLuaChonLichTrinh();
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

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Lấy thời gian hiện tại của hệ thống
            DateTime now = DateTime.Now;

            // Cập nhật ngày theo định dạng DD/MM/YYYY                                                           
            lbl_Date.Text = now.ToString("dd/MM/yyyy");

            // Cập nhật giờ theo định dạng HH:mm:ss (24 giờ)
            lbl_Time.Text = now.ToString("HH:mm:ss");
        }

        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Restart();
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
