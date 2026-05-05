namespace DoAn_LTWindows.Forms.Systems
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.lbl_Title = new System.Windows.Forms.Label();
            this.pnl_Login = new System.Windows.Forms.Panel();
            this.chk_HienMatKhau = new System.Windows.Forms.CheckBox();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Login = new System.Windows.Forms.Button();
            this.lbl_ForgotPassword = new System.Windows.Forms.LinkLabel();
            this.pnl_Password = new System.Windows.Forms.Panel();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.pnl_Usename = new System.Windows.Forms.Panel();
            this.txt_Username = new System.Windows.Forms.TextBox();
            this.lbl_Usename = new System.Windows.Forms.Label();
            this.pnl_Login.SuspendLayout();
            this.pnl_Password.SuspendLayout();
            this.pnl_Usename.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Title.Font = new System.Drawing.Font("Oswald", 60F, System.Drawing.FontStyle.Bold);
            this.lbl_Title.Location = new System.Drawing.Point(56, 19);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(1238, 136);
            this.lbl_Title.TabIndex = 0;
            this.lbl_Title.Text = "PHẦN MỀM QUẢN LÝ BÁN VÉ XE BUÝT";
            // 
            // pnl_Login
            // 
            this.pnl_Login.BackColor = System.Drawing.Color.Transparent;
            this.pnl_Login.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnl_Login.BackgroundImage")));
            this.pnl_Login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl_Login.Controls.Add(this.chk_HienMatKhau);
            this.pnl_Login.Controls.Add(this.btn_Exit);
            this.pnl_Login.Controls.Add(this.btn_Login);
            this.pnl_Login.Controls.Add(this.lbl_ForgotPassword);
            this.pnl_Login.Controls.Add(this.pnl_Password);
            this.pnl_Login.Controls.Add(this.lbl_Password);
            this.pnl_Login.Controls.Add(this.pnl_Usename);
            this.pnl_Login.Controls.Add(this.lbl_Usename);
            this.pnl_Login.Location = new System.Drawing.Point(223, 149);
            this.pnl_Login.Name = "pnl_Login";
            this.pnl_Login.Size = new System.Drawing.Size(904, 577);
            this.pnl_Login.TabIndex = 1;
            // 
            // chk_HienMatKhau
            // 
            this.chk_HienMatKhau.AutoSize = true;
            this.chk_HienMatKhau.Font = new System.Drawing.Font("Oswald", 18F);
            this.chk_HienMatKhau.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chk_HienMatKhau.Location = new System.Drawing.Point(481, 290);
            this.chk_HienMatKhau.Name = "chk_HienMatKhau";
            this.chk_HienMatKhau.Size = new System.Drawing.Size(163, 45);
            this.chk_HienMatKhau.TabIndex = 7;
            this.chk_HienMatKhau.Text = "Hiện Mật Khẩu";
            this.chk_HienMatKhau.UseVisualStyleBackColor = true;
            this.chk_HienMatKhau.CheckedChanged += new System.EventHandler(this.chk_HienMatKhau_CheckedChanged);
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackgroundImage = global::DoAn_LTWindows.Properties.Resources.button1;
            this.btn_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Exit.FlatAppearance.BorderSize = 0;
            this.btn_Exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Exit.Font = new System.Drawing.Font("Oswald", 20.25F, System.Drawing.FontStyle.Bold);
            this.btn_Exit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Exit.Location = new System.Drawing.Point(461, 394);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(217, 67);
            this.btn_Exit.TabIndex = 6;
            this.btn_Exit.Text = "Thoát";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Login
            // 
            this.btn_Login.BackgroundImage = global::DoAn_LTWindows.Properties.Resources.button1;
            this.btn_Login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Login.FlatAppearance.BorderSize = 0;
            this.btn_Login.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Login.Font = new System.Drawing.Font("Oswald", 20.25F, System.Drawing.FontStyle.Bold);
            this.btn_Login.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Login.Location = new System.Drawing.Point(227, 394);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(217, 67);
            this.btn_Login.TabIndex = 5;
            this.btn_Login.Text = "Đăng Nhập";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // lbl_ForgotPassword
            // 
            this.lbl_ForgotPassword.AutoSize = true;
            this.lbl_ForgotPassword.Location = new System.Drawing.Point(365, 334);
            this.lbl_ForgotPassword.Name = "lbl_ForgotPassword";
            this.lbl_ForgotPassword.Size = new System.Drawing.Size(180, 46);
            this.lbl_ForgotPassword.TabIndex = 4;
            this.lbl_ForgotPassword.TabStop = true;
            this.lbl_ForgotPassword.Text = "Quên Mật Khẩu?";
            this.lbl_ForgotPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_ForgotPassword_LinkClicked);
            // 
            // pnl_Password
            // 
            this.pnl_Password.BackgroundImage = global::DoAn_LTWindows.Properties.Resources._160pxtab;
            this.pnl_Password.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl_Password.Controls.Add(this.txt_Password);
            this.pnl_Password.Location = new System.Drawing.Point(260, 235);
            this.pnl_Password.Name = "pnl_Password";
            this.pnl_Password.Size = new System.Drawing.Size(384, 51);
            this.pnl_Password.TabIndex = 3;
            // 
            // txt_Password
            // 
            this.txt_Password.BackColor = System.Drawing.SystemColors.MenuText;
            this.txt_Password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Password.Font = new System.Drawing.Font("Oswald", 17F);
            this.txt_Password.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_Password.Location = new System.Drawing.Point(20, 8);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(343, 34);
            this.txt_Password.TabIndex = 0;
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_Password.Location = new System.Drawing.Point(252, 186);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(111, 46);
            this.lbl_Password.TabIndex = 2;
            this.lbl_Password.Text = "Mật Khẩu";
            // 
            // pnl_Usename
            // 
            this.pnl_Usename.BackgroundImage = global::DoAn_LTWindows.Properties.Resources._160pxtab;
            this.pnl_Usename.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl_Usename.Controls.Add(this.txt_Username);
            this.pnl_Usename.Location = new System.Drawing.Point(260, 122);
            this.pnl_Usename.Name = "pnl_Usename";
            this.pnl_Usename.Size = new System.Drawing.Size(384, 51);
            this.pnl_Usename.TabIndex = 1;
            // 
            // txt_Username
            // 
            this.txt_Username.BackColor = System.Drawing.SystemColors.MenuText;
            this.txt_Username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Username.Font = new System.Drawing.Font("Oswald", 17F);
            this.txt_Username.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_Username.Location = new System.Drawing.Point(20, 8);
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.Size = new System.Drawing.Size(343, 34);
            this.txt_Username.TabIndex = 0;
            // 
            // lbl_Usename
            // 
            this.lbl_Usename.AutoSize = true;
            this.lbl_Usename.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_Usename.Location = new System.Drawing.Point(252, 73);
            this.lbl_Usename.Name = "lbl_Usename";
            this.lbl_Usename.Size = new System.Drawing.Size(162, 46);
            this.lbl_Usename.TabIndex = 0;
            this.lbl_Usename.Text = "Tên Đăng Nhập";
            // 
            // frmLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::DoAn_LTWindows.Properties.Resources.busbackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.pnl_Login);
            this.Controls.Add(this.lbl_Title);
            this.Font = new System.Drawing.Font("Oswald", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1366, 768);
            this.MinimumSize = new System.Drawing.Size(1366, 768);
            this.Name = "frmLogin";
            this.Text = "Quản Lý Bán Vé Xe Buýt Client - Đăng Nhập";
            this.pnl_Login.ResumeLayout(false);
            this.pnl_Login.PerformLayout();
            this.pnl_Password.ResumeLayout(false);
            this.pnl_Password.PerformLayout();
            this.pnl_Usename.ResumeLayout(false);
            this.pnl_Usename.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Panel pnl_Login;
        private System.Windows.Forms.Panel pnl_Usename;
        private System.Windows.Forms.Label lbl_Usename;
        private System.Windows.Forms.TextBox txt_Username;
        private System.Windows.Forms.Panel pnl_Password;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.LinkLabel lbl_ForgotPassword;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.CheckBox chk_HienMatKhau;
    }
}