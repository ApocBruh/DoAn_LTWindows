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
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Find = new System.Windows.Forms.Button();
            this.lbl_ChonXe = new System.Windows.Forms.Label();
            this.lbl_ChonTuyen = new System.Windows.Forms.Label();
            this.txt_Find = new System.Windows.Forms.TextBox();
            this.lbl_TimKiem = new System.Windows.Forms.Label();
            this.btn_FindData = new System.Windows.Forms.Button();
            this.dgv_ChuyenXe = new System.Windows.Forms.DataGridView();
            this.cmb_Tuyen = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ChuyenXe)).BeginInit();
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
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Oswald", 16F);
            this.textBox4.Location = new System.Drawing.Point(551, 9);
            this.textBox4.Name = "textBox4";
            this.textBox4.PasswordChar = '*';
            this.textBox4.Size = new System.Drawing.Size(235, 39);
            this.textBox4.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Oswald", 16F);
            this.label2.Location = new System.Drawing.Point(448, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 37);
            this.label2.TabIndex = 42;
            this.label2.Text = "Mật Khẩu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Oswald", 16F);
            this.label1.Location = new System.Drawing.Point(448, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 37);
            this.label1.TabIndex = 40;
            this.label1.Text = "Vai Trò:";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Oswald", 16F);
            this.textBox2.Location = new System.Drawing.Point(184, 53);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(258, 39);
            this.textBox2.TabIndex = 39;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Oswald", 16F);
            this.textBox1.Location = new System.Drawing.Point(184, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(258, 39);
            this.textBox1.TabIndex = 38;
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
            // panel1
            // 
            this.panel1.BackgroundImage = global::DoAn_LTWindows.Properties.Resources.mainbackground;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmb_Tuyen);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.btn_Reset);
            this.panel1.Controls.Add(this.btn_Delete);
            this.panel1.Controls.Add(this.btn_Edit);
            this.panel1.Controls.Add(this.btn_Save);
            this.panel1.Controls.Add(this.btn_Find);
            this.panel1.Controls.Add(this.lbl_ChonXe);
            this.panel1.Controls.Add(this.lbl_ChonTuyen);
            this.panel1.Location = new System.Drawing.Point(88, 133);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(816, 190);
            this.panel1.TabIndex = 41;
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
            // lbl_ChonXe
            // 
            this.lbl_ChonXe.AutoSize = true;
            this.lbl_ChonXe.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ChonXe.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_ChonXe.Location = new System.Drawing.Point(30, 55);
            this.lbl_ChonXe.Name = "lbl_ChonXe";
            this.lbl_ChonXe.Size = new System.Drawing.Size(134, 37);
            this.lbl_ChonXe.TabIndex = 18;
            this.lbl_ChonXe.Text = "Tên Nhân Viên:";
            // 
            // lbl_ChonTuyen
            // 
            this.lbl_ChonTuyen.AutoSize = true;
            this.lbl_ChonTuyen.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ChonTuyen.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_ChonTuyen.Location = new System.Drawing.Point(30, 11);
            this.lbl_ChonTuyen.Name = "lbl_ChonTuyen";
            this.lbl_ChonTuyen.Size = new System.Drawing.Size(140, 37);
            this.lbl_ChonTuyen.TabIndex = 16;
            this.lbl_ChonTuyen.Text = "Tên Đăng Nhập:";
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
            // dgv_ChuyenXe
            // 
            this.dgv_ChuyenXe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ChuyenXe.Location = new System.Drawing.Point(44, 329);
            this.dgv_ChuyenXe.Name = "dgv_ChuyenXe";
            this.dgv_ChuyenXe.Size = new System.Drawing.Size(905, 271);
            this.dgv_ChuyenXe.TabIndex = 43;
            // 
            // cmb_Tuyen
            // 
            this.cmb_Tuyen.Font = new System.Drawing.Font("Oswald", 14F);
            this.cmb_Tuyen.FormattingEnabled = true;
            this.cmb_Tuyen.Location = new System.Drawing.Point(551, 52);
            this.cmb_Tuyen.Name = "cmb_Tuyen";
            this.cmb_Tuyen.Size = new System.Drawing.Size(235, 40);
            this.cmb_Tuyen.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Oswald", 16F);
            this.label3.Location = new System.Drawing.Point(30, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 37);
            this.label3.TabIndex = 45;
            this.label3.Text = "Trạng Thái:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Font = new System.Drawing.Font("Oswald", 18F);
            this.checkBox1.Location = new System.Drawing.Point(184, 94);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 45);
            this.checkBox1.TabIndex = 46;
            this.checkBox1.Text = "Khóa";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = System.Drawing.Color.Transparent;
            this.checkBox2.Font = new System.Drawing.Font("Oswald", 18F);
            this.checkBox2.Location = new System.Drawing.Point(295, 94);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(208, 45);
            this.checkBox2.TabIndex = 47;
            this.checkBox2.Text = "Kích Hoạt Tài Khoản";
            this.checkBox2.UseVisualStyleBackColor = false;
            // 
            // ucQuanLyTaiKhoan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::DoAn_LTWindows.Properties.Resources.mainbackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_Find);
            this.Controls.Add(this.lbl_TimKiem);
            this.Controls.Add(this.btn_FindData);
            this.Controls.Add(this.dgv_ChuyenXe);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Oswald", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MaximumSize = new System.Drawing.Size(992, 623);
            this.MinimumSize = new System.Drawing.Size(992, 623);
            this.Name = "ucQuanLyTaiKhoan";
            this.Size = new System.Drawing.Size(992, 623);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ChuyenXe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Find;
        private System.Windows.Forms.Label lbl_ChonXe;
        private System.Windows.Forms.Label lbl_ChonTuyen;
        private System.Windows.Forms.TextBox txt_Find;
        private System.Windows.Forms.Label lbl_TimKiem;
        private System.Windows.Forms.Button btn_FindData;
        private System.Windows.Forms.DataGridView dgv_ChuyenXe;
        private System.Windows.Forms.ComboBox cmb_Tuyen;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
    }
}
