namespace DoAn_LTWindows.Forms.Operations
{
    partial class ucQuanLyTaiKhoan
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_Title = new System.Windows.Forms.Label();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.lbl_Role = new System.Windows.Forms.Label();
            this.txt_TenNhanVien = new System.Windows.Forms.TextBox();
            this.txt_Username = new System.Windows.Forms.TextBox();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.pnl_Import = new System.Windows.Forms.Panel();
            this.chk_Active = new System.Windows.Forms.CheckBox();
            this.chk_Lock = new System.Windows.Forms.CheckBox();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.cmb_Role = new System.Windows.Forms.ComboBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Find = new System.Windows.Forms.Button();
            this.lbl_TenNhanVien = new System.Windows.Forms.Label();
            this.lbl_Usename = new System.Windows.Forms.Label();
            this.txt_Find = new System.Windows.Forms.TextBox();
            this.lbl_TimKiem = new System.Windows.Forms.Label();
            this.btn_FindData = new System.Windows.Forms.Button();
            this.dgv_Account = new System.Windows.Forms.DataGridView();
            this.pnl_Import.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Account)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Title.Font = new System.Drawing.Font("Oswald", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lbl_Title.Location = new System.Drawing.Point(335, 16);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(322, 63);
            this.lbl_Title.TabIndex = 38;
            this.lbl_Title.Text = "QUẢN LÝ TÀI KHOẢN";
            // 
            // txt_Password
            // 
            this.txt_Password.Font = new System.Drawing.Font("Oswald", 16F);
            this.txt_Password.Location = new System.Drawing.Point(551, 9);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(235, 39);
            this.txt_Password.TabIndex = 43;
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Password.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_Password.Location = new System.Drawing.Point(448, 11);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(97, 37);
            this.lbl_Password.TabIndex = 42;
            this.lbl_Password.Text = "Mật Khẩu:";
            // 
            // lbl_Role
            // 
            this.lbl_Role.AutoSize = true;
            this.lbl_Role.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Role.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_Role.Location = new System.Drawing.Point(448, 55);
            this.lbl_Role.Name = "lbl_Role";
            this.lbl_Role.Size = new System.Drawing.Size(74, 37);
            this.lbl_Role.TabIndex = 40;
            this.lbl_Role.Text = "Vai Trò:";
            // 
            // txt_TenNhanVien
            // 
            this.txt_TenNhanVien.Font = new System.Drawing.Font("Oswald", 16F);
            this.txt_TenNhanVien.Location = new System.Drawing.Point(184, 53);
            this.txt_TenNhanVien.Name = "txt_TenNhanVien";
            this.txt_TenNhanVien.Size = new System.Drawing.Size(258, 39);
            this.txt_TenNhanVien.TabIndex = 39;
            // 
            // txt_Username
            // 
            this.txt_Username.Font = new System.Drawing.Font("Oswald", 16F);
            this.txt_Username.Location = new System.Drawing.Point(184, 8);
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.Size = new System.Drawing.Size(258, 39);
            this.txt_Username.TabIndex = 38;
            // 
            // btn_Reset
            // 
            this.btn_Reset.BackColor = System.Drawing.Color.Transparent;
            this.btn_Reset.BackgroundImage = global::DoAn_LTWindows.Properties.Resources._75pxbtn1;
            this.btn_Reset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Reset.FlatAppearance.BorderSize = 0;
            this.btn_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Reset.Font = new System.Drawing.Font("Oswald", 14F);
            this.btn_Reset.Location = new System.Drawing.Point(614, 138);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(129, 41);
            this.btn_Reset.TabIndex = 29;
            this.btn_Reset.Text = "Đặt Lại";
            this.btn_Reset.UseVisualStyleBackColor = false;
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.Transparent;
            this.btn_Delete.BackgroundImage = global::DoAn_LTWindows.Properties.Resources._75pxbtn1;
            this.btn_Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Delete.FlatAppearance.BorderSize = 0;
            this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delete.Font = new System.Drawing.Font("Oswald", 14F);
            this.btn_Delete.Location = new System.Drawing.Point(479, 138);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(129, 41);
            this.btn_Delete.TabIndex = 28;
            this.btn_Delete.Text = "Xóa";
            this.btn_Delete.UseVisualStyleBackColor = false;
            // 
            // btn_Edit
            // 
            this.btn_Edit.BackColor = System.Drawing.Color.Transparent;
            this.btn_Edit.BackgroundImage = global::DoAn_LTWindows.Properties.Resources._75pxbtn1;
            this.btn_Edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Edit.FlatAppearance.BorderSize = 0;
            this.btn_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Edit.Font = new System.Drawing.Font("Oswald", 14F);
            this.btn_Edit.Location = new System.Drawing.Point(344, 138);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(129, 41);
            this.btn_Edit.TabIndex = 27;
            this.btn_Edit.Text = "Sửa";
            this.btn_Edit.UseVisualStyleBackColor = false;
            // 
            // pnl_Import
            // 
            this.pnl_Import.BackgroundImage = global::DoAn_LTWindows.Properties.Resources.mainbackground;
            this.pnl_Import.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl_Import.Controls.Add(this.chk_Active);
            this.pnl_Import.Controls.Add(this.chk_Lock);
            this.pnl_Import.Controls.Add(this.lbl_Status);
            this.pnl_Import.Controls.Add(this.cmb_Role);
            this.pnl_Import.Controls.Add(this.txt_Password);
            this.pnl_Import.Controls.Add(this.lbl_Password);
            this.pnl_Import.Controls.Add(this.lbl_Role);
            this.pnl_Import.Controls.Add(this.txt_TenNhanVien);
            this.pnl_Import.Controls.Add(this.txt_Username);
            this.pnl_Import.Controls.Add(this.btn_Reset);
            this.pnl_Import.Controls.Add(this.btn_Delete);
            this.pnl_Import.Controls.Add(this.btn_Edit);
            this.pnl_Import.Controls.Add(this.btn_Save);
            this.pnl_Import.Controls.Add(this.btn_Find);
            this.pnl_Import.Controls.Add(this.lbl_TenNhanVien);
            this.pnl_Import.Controls.Add(this.lbl_Usename);
            this.pnl_Import.Location = new System.Drawing.Point(88, 133);
            this.pnl_Import.Name = "pnl_Import";
            this.pnl_Import.Size = new System.Drawing.Size(816, 190);
            this.pnl_Import.TabIndex = 41;
            // 
            // chk_Active
            // 
            this.chk_Active.AutoSize = true;
            this.chk_Active.BackColor = System.Drawing.Color.Transparent;
            this.chk_Active.Font = new System.Drawing.Font("Oswald", 18F);
            this.chk_Active.Location = new System.Drawing.Point(295, 94);
            this.chk_Active.Name = "chk_Active";
            this.chk_Active.Size = new System.Drawing.Size(208, 45);
            this.chk_Active.TabIndex = 47;
            this.chk_Active.Text = "Kích Hoạt Tài Khoản";
            this.chk_Active.UseVisualStyleBackColor = false;
            // 
            // chk_Lock
            // 
            this.chk_Lock.AutoSize = true;
            this.chk_Lock.BackColor = System.Drawing.Color.Transparent;
            this.chk_Lock.Font = new System.Drawing.Font("Oswald", 18F);
            this.chk_Lock.Location = new System.Drawing.Point(184, 94);
            this.chk_Lock.Name = "chk_Lock";
            this.chk_Lock.Size = new System.Drawing.Size(80, 45);
            this.chk_Lock.TabIndex = 46;
            this.chk_Lock.Text = "Khóa";
            this.chk_Lock.UseVisualStyleBackColor = false;
            // 
            // lbl_Status
            // 
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Status.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_Status.Location = new System.Drawing.Point(30, 99);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(103, 37);
            this.lbl_Status.TabIndex = 45;
            this.lbl_Status.Text = "Trạng Thái:";
            // 
            // cmb_Role
            // 
            this.cmb_Role.Font = new System.Drawing.Font("Oswald", 14F);
            this.cmb_Role.FormattingEnabled = true;
            this.cmb_Role.Location = new System.Drawing.Point(551, 52);
            this.cmb_Role.Name = "cmb_Role";
            this.cmb_Role.Size = new System.Drawing.Size(235, 40);
            this.cmb_Role.TabIndex = 44;
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.Transparent;
            this.btn_Save.BackgroundImage = global::DoAn_LTWindows.Properties.Resources._75pxbtn1;
            this.btn_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Save.FlatAppearance.BorderSize = 0;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.Font = new System.Drawing.Font("Oswald", 14F);
            this.btn_Save.Location = new System.Drawing.Point(209, 138);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(129, 41);
            this.btn_Save.TabIndex = 26;
            this.btn_Save.Text = "Lưu";
            this.btn_Save.UseVisualStyleBackColor = false;
            // 
            // btn_Find
            // 
            this.btn_Find.BackColor = System.Drawing.Color.Transparent;
            this.btn_Find.BackgroundImage = global::DoAn_LTWindows.Properties.Resources._75pxbtn1;
            this.btn_Find.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Find.FlatAppearance.BorderSize = 0;
            this.btn_Find.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Find.Font = new System.Drawing.Font("Oswald", 14F);
            this.btn_Find.Location = new System.Drawing.Point(74, 138);
            this.btn_Find.Name = "btn_Find";
            this.btn_Find.Size = new System.Drawing.Size(129, 41);
            this.btn_Find.TabIndex = 25;
            this.btn_Find.Text = "Tìm Kiếm";
            this.btn_Find.UseVisualStyleBackColor = false;
            // 
            // lbl_TenNhanVien
            // 
            this.lbl_TenNhanVien.AutoSize = true;
            this.lbl_TenNhanVien.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TenNhanVien.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_TenNhanVien.Location = new System.Drawing.Point(30, 55);
            this.lbl_TenNhanVien.Name = "lbl_TenNhanVien";
            this.lbl_TenNhanVien.Size = new System.Drawing.Size(134, 37);
            this.lbl_TenNhanVien.TabIndex = 18;
            this.lbl_TenNhanVien.Text = "Tên Nhân Viên:";
            // 
            // lbl_Usename
            // 
            this.lbl_Usename.AutoSize = true;
            this.lbl_Usename.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Usename.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_Usename.Location = new System.Drawing.Point(30, 11);
            this.lbl_Usename.Name = "lbl_Usename";
            this.lbl_Usename.Size = new System.Drawing.Size(140, 37);
            this.lbl_Usename.TabIndex = 16;
            this.lbl_Usename.Text = "Tên Đăng Nhập:";
            // 
            // txt_Find
            // 
            this.txt_Find.Font = new System.Drawing.Font("Oswald", 16F);
            this.txt_Find.Location = new System.Drawing.Point(258, 80);
            this.txt_Find.Name = "txt_Find";
            this.txt_Find.Size = new System.Drawing.Size(381, 39);
            this.txt_Find.TabIndex = 40;
            // 
            // lbl_TimKiem
            // 
            this.lbl_TimKiem.AutoSize = true;
            this.lbl_TimKiem.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TimKiem.Font = new System.Drawing.Font("Oswald", 18F);
            this.lbl_TimKiem.Location = new System.Drawing.Point(150, 79);
            this.lbl_TimKiem.Name = "lbl_TimKiem";
            this.lbl_TimKiem.Size = new System.Drawing.Size(102, 41);
            this.lbl_TimKiem.TabIndex = 39;
            this.lbl_TimKiem.Text = "Tìm Kiếm:";
            // 
            // btn_FindData
            // 
            this.btn_FindData.BackColor = System.Drawing.Color.Transparent;
            this.btn_FindData.BackgroundImage = global::DoAn_LTWindows.Properties.Resources._75pxbtn1;
            this.btn_FindData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_FindData.FlatAppearance.BorderSize = 0;
            this.btn_FindData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_FindData.Font = new System.Drawing.Font("Oswald", 18F);
            this.btn_FindData.Location = new System.Drawing.Point(658, 75);
            this.btn_FindData.Name = "btn_FindData";
            this.btn_FindData.Size = new System.Drawing.Size(185, 49);
            this.btn_FindData.TabIndex = 42;
            this.btn_FindData.Text = "Tìm Kiếm";
            this.btn_FindData.UseVisualStyleBackColor = false;
            // 
            // dgv_Account
            // 
            this.dgv_Account.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Account.Location = new System.Drawing.Point(44, 329);
            this.dgv_Account.Name = "dgv_Account";
            this.dgv_Account.Size = new System.Drawing.Size(905, 271);
            this.dgv_Account.TabIndex = 43;
            // 
            // ucQuanLyTaiKhoan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::DoAn_LTWindows.Properties.Resources.mainbackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.pnl_Import);
            this.Controls.Add(this.txt_Find);
            this.Controls.Add(this.lbl_TimKiem);
            this.Controls.Add(this.btn_FindData);
            this.Controls.Add(this.dgv_Account);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Oswald", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MaximumSize = new System.Drawing.Size(992, 623);
            this.MinimumSize = new System.Drawing.Size(992, 623);
            this.Name = "ucQuanLyTaiKhoan";
            this.Size = new System.Drawing.Size(992, 623);
            this.pnl_Import.ResumeLayout(false);
            this.pnl_Import.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Account)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.Label lbl_Role;
        private System.Windows.Forms.TextBox txt_TenNhanVien;
        private System.Windows.Forms.TextBox txt_Username;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.Panel pnl_Import;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Find;
        private System.Windows.Forms.Label lbl_TenNhanVien;
        private System.Windows.Forms.Label lbl_Usename;
        private System.Windows.Forms.TextBox txt_Find;
        private System.Windows.Forms.Label lbl_TimKiem;
        private System.Windows.Forms.Button btn_FindData;
        private System.Windows.Forms.DataGridView dgv_Account;
        private System.Windows.Forms.ComboBox cmb_Role;
        private System.Windows.Forms.CheckBox chk_Active;
        private System.Windows.Forms.CheckBox chk_Lock;
        private System.Windows.Forms.Label lbl_Status;
    }
}
