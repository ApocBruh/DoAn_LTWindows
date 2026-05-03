using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DoAn_LTWindows.Forms.Systems
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

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
        }

        private void lbl_ForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Hiển thị hộp thoại thông báo
            MessageBox.Show("Vui lòng liên hệ với quản trị viên để giải quyết", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string user = txt_Username.Text.Trim();
            string pass = txt_Password.Text.Trim();

            if (user == "" || pass == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Chuỗi kết nối đến SQL Server của bạn (Bạn cần sửa lại Tên Server cho đúng với máy bạn)
            string connectionString = @"Data Source=DESKTOP-QG0J4IU;Initial Catalog=QLBanVeXeBuyt;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Truy vấn kiểm tra tài khoản và lấy ra Tên, Vai Trò
                    string query = "SELECT TenNhanVien, VaiTro FROM NhanVien WHERE TenDangNhap = @user AND MatKhau = @pass AND TrangThai = 1";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@pass", pass);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read()) // Nếu tìm thấy (Đăng nhập đúng)
                    {
                        string tenNV = reader["TenNhanVien"].ToString();
                        string vaiTro = reader["VaiTro"].ToString();

                        MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Khởi tạo frmMain và truyền dữ liệu sang
                        frmMain mainForm = new frmMain(tenNV, vaiTro);
                        this.Hide(); // Ẩn form login
                        mainForm.ShowDialog(); // Mở form main
                        this.Close(); // Đóng hẳn form login khi thoát form main
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản, mật khẩu hoặc tài khoản đã bị khóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối Cơ sở dữ liệu: " + ex.Message);
                }
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát phần mềm?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Thoát toàn bộ ứng dụng
            }
        }
    }
}
