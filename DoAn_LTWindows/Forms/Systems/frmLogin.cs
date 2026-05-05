using DoAn_LTWindows.BUS;
using DoAn_LTWindows.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_LTWindows.Forms.Systems
{
    public partial class frmLogin : Form
    {
        private NhanVienBUS nhanVienBUS = new NhanVienBUS();

        public frmLogin()
        {
            InitializeComponent();

            this.AcceptButton = btn_Login;
            this.CancelButton = btn_Exit;

            btn_Login.MouseDown += (s, e) => {
                btn_Login.BackgroundImage = Properties.Resources.c_button1;
            };

            btn_Login.MouseUp += (s, e) => {
                btn_Login.BackgroundImage = Properties.Resources.button1;
            };

            btn_Exit.MouseDown += (s, e) => {
                btn_Exit.BackgroundImage = Properties.Resources.c_button1;
            };

            btn_Exit.MouseUp += (s, e) => {
                btn_Exit.BackgroundImage = Properties.Resources.button1;
            };

            chk_HienMatKhau.CheckedChanged += (s, e) =>
            {
                txt_Password.PasswordChar = chk_HienMatKhau.Checked ? '\0' : '*';
            };
        }

        private void lbl_ForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Vui lòng liên hệ với quản trị viên để giải quyết", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string user = txt_Username.Text.Trim();
            string pass = txt_Password.Text.Trim();

            string pattern = @"^[a-zA-Z0-9]+$";

            if (!Regex.IsMatch(user, pattern))
            {
                MessageBox.Show("Tên đăng nhập không được chứa ký tự đặc biệt hoặc khoảng trắng!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Gọi BUS kiểm tra đăng nhập (đã bao gồm check rỗng và check database)
                NhanVienDTO nv = nhanVienBUS.KiemTraDangNhap(user, pass);

                if (nv != null)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Khởi tạo frmMain và truyền dữ liệu DTO sang
                    frmMain mainForm = new frmMain(nv.TenNhanVien, nv.VaiTro);
                    this.Hide();
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản, mật khẩu hoặc tài khoản đã bị khóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Bắt lỗi rỗng từ BUS hoặc lỗi kết nối DB
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát phần mềm?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void chk_HienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_HienMatKhau.Checked)
            {
                txt_Password.PasswordChar = '\0';
            }
            else
            {
                txt_Password.PasswordChar = '*';
            }
        }
    }
}
