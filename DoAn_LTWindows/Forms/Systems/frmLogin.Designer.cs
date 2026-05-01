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
            this.button1 = new System.Windows.Forms.Button();
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
            this.pnl_Login.Controls.Add(this.button1);
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
            // button1
            // 
            this.button1.BackgroundImage = global::DoAn_LTWindows.Properties.Resources._75pxbtn_c;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(298, 394);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(308, 60);
            this.button1.TabIndex = 5;
            this.button1.Text = "Đăng Nhập";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lbl_ForgotPassword
            // 
            this.lbl_ForgotPassword.AutoSize = true;
            this.lbl_ForgotPassword.Location = new System.Drawing.Point(362, 334);
            this.lbl_ForgotPassword.Name = "lbl_ForgotPassword";
            this.lbl_ForgotPassword.Size = new System.Drawing.Size(180, 46);
            this.lbl_ForgotPassword.TabIndex = 4;
            this.lbl_ForgotPassword.TabStop = true;
            this.lbl_ForgotPassword.Text = "Quên Mật Khẩu?";
            // 
            // pnl_Password
            // 
            this.pnl_Password.BackgroundImage = global::DoAn_LTWindows.Properties.Resources._160pxtab;
            this.pnl_Password.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl_Password.Controls.Add(this.txt_Password);
            this.pnl_Password.Location = new System.Drawing.Point(101, 245);
            this.pnl_Password.Name = "pnl_Password";
            this.pnl_Password.Size = new System.Drawing.Size(570, 51);
            this.pnl_Password.TabIndex = 3;
            // 
            // txt_Password
            // 
            this.txt_Password.BackColor = System.Drawing.SystemColors.MenuText;
            this.txt_Password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Password.Font = new System.Drawing.Font("Oswald", 18F);
            this.txt_Password.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_Password.Location = new System.Drawing.Point(21, 6);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(533, 36);
            this.txt_Password.TabIndex = 0;
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_Password.Location = new System.Drawing.Point(102, 196);
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
            this.pnl_Usename.Location = new System.Drawing.Point(101, 122);
            this.pnl_Usename.Name = "pnl_Usename";
            this.pnl_Usename.Size = new System.Drawing.Size(570, 51);
            this.pnl_Usename.TabIndex = 1;
            // 
            // txt_Username
            // 
            this.txt_Username.BackColor = System.Drawing.SystemColors.MenuText;
            this.txt_Username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Username.Font = new System.Drawing.Font("Oswald", 18F);
            this.txt_Username.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_Username.Location = new System.Drawing.Point(21, 6);
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.Size = new System.Drawing.Size(533, 36);
            this.txt_Username.TabIndex = 0;
            // 
            // lbl_Usename
            // 
            this.lbl_Usename.AutoSize = true;
            this.lbl_Usename.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_Usename.Location = new System.Drawing.Point(102, 73);
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
        private System.Windows.Forms.Button button1;
    }
}