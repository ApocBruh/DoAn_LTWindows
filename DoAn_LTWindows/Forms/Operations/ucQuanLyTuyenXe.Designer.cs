namespace DoAn_LTWindows.Forms.Operations
{
    partial class ucQuanLyTuyenXe
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
            this.dgv_TuyenXe = new System.Windows.Forms.DataGridView();
            this.btn_FindData = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Find = new System.Windows.Forms.Button();
            this.txt_Find = new System.Windows.Forms.TextBox();
            this.lbl_TimKiem = new System.Windows.Forms.Label();
            this.lbl_DiemDen = new System.Windows.Forms.Label();
            this.txt_Start = new System.Windows.Forms.TextBox();
            this.lbl_DiemXuatPhat = new System.Windows.Forms.Label();
            this.lbl_TenTuyen = new System.Windows.Forms.Label();
            this.lbl_MaTuyen = new System.Windows.Forms.Label();
            this.pnl_Import = new System.Windows.Forms.Panel();
            this.lbl_ThoiGianChay = new System.Windows.Forms.Label();
            this.nud_Time = new System.Windows.Forms.NumericUpDown();
            this.lbl_KhoangCach = new System.Windows.Forms.Label();
            this.nud_Distance = new System.Windows.Forms.NumericUpDown();
            this.txt_End = new System.Windows.Forms.TextBox();
            this.txt_TenTuyen = new System.Windows.Forms.TextBox();
            this.txt_MaTuyen = new System.Windows.Forms.TextBox();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.btn_Return = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TuyenXe)).BeginInit();
            this.pnl_Import.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Distance)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_TuyenXe
            // 
            this.dgv_TuyenXe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_TuyenXe.Location = new System.Drawing.Point(44, 323);
            this.dgv_TuyenXe.Name = "dgv_TuyenXe";
            this.dgv_TuyenXe.Size = new System.Drawing.Size(905, 237);
            this.dgv_TuyenXe.TabIndex = 31;
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
            this.btn_FindData.TabIndex = 30;
            this.btn_FindData.Text = "Tìm Kiếm";
            this.btn_FindData.UseVisualStyleBackColor = false;
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
            // txt_Find
            // 
            this.txt_Find.Font = new System.Drawing.Font("Oswald", 16F);
            this.txt_Find.Location = new System.Drawing.Point(258, 80);
            this.txt_Find.Name = "txt_Find";
            this.txt_Find.Size = new System.Drawing.Size(381, 39);
            this.txt_Find.TabIndex = 28;
            // 
            // lbl_TimKiem
            // 
            this.lbl_TimKiem.AutoSize = true;
            this.lbl_TimKiem.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TimKiem.Font = new System.Drawing.Font("Oswald", 18F);
            this.lbl_TimKiem.Location = new System.Drawing.Point(150, 79);
            this.lbl_TimKiem.Name = "lbl_TimKiem";
            this.lbl_TimKiem.Size = new System.Drawing.Size(102, 41);
            this.lbl_TimKiem.TabIndex = 27;
            this.lbl_TimKiem.Text = "Tìm Kiếm:";
            // 
            // lbl_DiemDen
            // 
            this.lbl_DiemDen.AutoSize = true;
            this.lbl_DiemDen.BackColor = System.Drawing.Color.Transparent;
            this.lbl_DiemDen.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_DiemDen.Location = new System.Drawing.Point(452, 56);
            this.lbl_DiemDen.Name = "lbl_DiemDen";
            this.lbl_DiemDen.Size = new System.Drawing.Size(98, 37);
            this.lbl_DiemDen.TabIndex = 22;
            this.lbl_DiemDen.Text = "Điểm Đến:";
            this.lbl_DiemDen.UseMnemonic = false;
            // 
            // txt_Start
            // 
            this.txt_Start.Font = new System.Drawing.Font("Oswald", 14F);
            this.txt_Start.Location = new System.Drawing.Point(181, 54);
            this.txt_Start.Name = "txt_Start";
            this.txt_Start.Size = new System.Drawing.Size(188, 35);
            this.txt_Start.TabIndex = 20;
            // 
            // lbl_DiemXuatPhat
            // 
            this.lbl_DiemXuatPhat.AutoSize = true;
            this.lbl_DiemXuatPhat.BackColor = System.Drawing.Color.Transparent;
            this.lbl_DiemXuatPhat.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_DiemXuatPhat.Location = new System.Drawing.Point(29, 54);
            this.lbl_DiemXuatPhat.Name = "lbl_DiemXuatPhat";
            this.lbl_DiemXuatPhat.Size = new System.Drawing.Size(146, 37);
            this.lbl_DiemXuatPhat.TabIndex = 21;
            this.lbl_DiemXuatPhat.Text = "Điểm Xuất Phát:";
            // 
            // lbl_TenTuyen
            // 
            this.lbl_TenTuyen.AutoSize = true;
            this.lbl_TenTuyen.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TenTuyen.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_TenTuyen.Location = new System.Drawing.Point(452, 15);
            this.lbl_TenTuyen.Name = "lbl_TenTuyen";
            this.lbl_TenTuyen.Size = new System.Drawing.Size(99, 37);
            this.lbl_TenTuyen.TabIndex = 18;
            this.lbl_TenTuyen.Text = "Tên Tuyến:";
            // 
            // lbl_MaTuyen
            // 
            this.lbl_MaTuyen.AutoSize = true;
            this.lbl_MaTuyen.BackColor = System.Drawing.Color.Transparent;
            this.lbl_MaTuyen.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_MaTuyen.Location = new System.Drawing.Point(29, 11);
            this.lbl_MaTuyen.Name = "lbl_MaTuyen";
            this.lbl_MaTuyen.Size = new System.Drawing.Size(96, 37);
            this.lbl_MaTuyen.TabIndex = 16;
            this.lbl_MaTuyen.Text = "Mã Tuyến:";
            // 
            // pnl_Import
            // 
            this.pnl_Import.BackgroundImage = global::DoAn_LTWindows.Properties.Resources.mainbackground;
            this.pnl_Import.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl_Import.Controls.Add(this.lbl_ThoiGianChay);
            this.pnl_Import.Controls.Add(this.nud_Time);
            this.pnl_Import.Controls.Add(this.lbl_KhoangCach);
            this.pnl_Import.Controls.Add(this.nud_Distance);
            this.pnl_Import.Controls.Add(this.txt_End);
            this.pnl_Import.Controls.Add(this.txt_TenTuyen);
            this.pnl_Import.Controls.Add(this.txt_MaTuyen);
            this.pnl_Import.Controls.Add(this.btn_Reset);
            this.pnl_Import.Controls.Add(this.btn_Delete);
            this.pnl_Import.Controls.Add(this.btn_Edit);
            this.pnl_Import.Controls.Add(this.btn_Save);
            this.pnl_Import.Controls.Add(this.btn_Find);
            this.pnl_Import.Controls.Add(this.lbl_DiemDen);
            this.pnl_Import.Controls.Add(this.txt_Start);
            this.pnl_Import.Controls.Add(this.lbl_DiemXuatPhat);
            this.pnl_Import.Controls.Add(this.lbl_TenTuyen);
            this.pnl_Import.Controls.Add(this.lbl_MaTuyen);
            this.pnl_Import.Location = new System.Drawing.Point(88, 127);
            this.pnl_Import.Name = "pnl_Import";
            this.pnl_Import.Size = new System.Drawing.Size(816, 190);
            this.pnl_Import.TabIndex = 29;
            // 
            // lbl_ThoiGianChay
            // 
            this.lbl_ThoiGianChay.AutoSize = true;
            this.lbl_ThoiGianChay.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ThoiGianChay.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_ThoiGianChay.Location = new System.Drawing.Point(452, 98);
            this.lbl_ThoiGianChay.Name = "lbl_ThoiGianChay";
            this.lbl_ThoiGianChay.Size = new System.Drawing.Size(179, 37);
            this.lbl_ThoiGianChay.TabIndex = 36;
            this.lbl_ThoiGianChay.Text = "Thời Gian Chạy (Giờ)";
            // 
            // nud_Time
            // 
            this.nud_Time.Font = new System.Drawing.Font("Oswald", 14F);
            this.nud_Time.Location = new System.Drawing.Point(639, 99);
            this.nud_Time.Name = "nud_Time";
            this.nud_Time.Size = new System.Drawing.Size(141, 35);
            this.nud_Time.TabIndex = 35;
            // 
            // lbl_KhoangCach
            // 
            this.lbl_KhoangCach.AutoSize = true;
            this.lbl_KhoangCach.BackColor = System.Drawing.Color.Transparent;
            this.lbl_KhoangCach.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_KhoangCach.Location = new System.Drawing.Point(29, 93);
            this.lbl_KhoangCach.Name = "lbl_KhoangCach";
            this.lbl_KhoangCach.Size = new System.Drawing.Size(168, 37);
            this.lbl_KhoangCach.TabIndex = 34;
            this.lbl_KhoangCach.Text = "Khoảng Cách (Km):";
            // 
            // nud_Distance
            // 
            this.nud_Distance.Font = new System.Drawing.Font("Oswald", 14F);
            this.nud_Distance.Location = new System.Drawing.Point(203, 94);
            this.nud_Distance.Name = "nud_Distance";
            this.nud_Distance.Size = new System.Drawing.Size(166, 35);
            this.nud_Distance.TabIndex = 33;
            // 
            // txt_End
            // 
            this.txt_End.Font = new System.Drawing.Font("Oswald", 14F);
            this.txt_End.Location = new System.Drawing.Point(557, 56);
            this.txt_End.Name = "txt_End";
            this.txt_End.Size = new System.Drawing.Size(223, 35);
            this.txt_End.TabIndex = 32;
            // 
            // txt_TenTuyen
            // 
            this.txt_TenTuyen.Font = new System.Drawing.Font("Oswald", 14F);
            this.txt_TenTuyen.Location = new System.Drawing.Point(557, 15);
            this.txt_TenTuyen.Name = "txt_TenTuyen";
            this.txt_TenTuyen.Size = new System.Drawing.Size(223, 35);
            this.txt_TenTuyen.TabIndex = 31;
            // 
            // txt_MaTuyen
            // 
            this.txt_MaTuyen.Font = new System.Drawing.Font("Oswald", 14F);
            this.txt_MaTuyen.Location = new System.Drawing.Point(181, 11);
            this.txt_MaTuyen.Name = "txt_MaTuyen";
            this.txt_MaTuyen.Size = new System.Drawing.Size(188, 35);
            this.txt_MaTuyen.TabIndex = 30;
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Title.Font = new System.Drawing.Font("Oswald", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lbl_Title.Location = new System.Drawing.Point(346, 16);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(300, 63);
            this.lbl_Title.TabIndex = 26;
            this.lbl_Title.Text = "QUẢN LÝ TUYẾN XE";
            // 
            // btn_Return
            // 
            this.btn_Return.BackColor = System.Drawing.Color.Transparent;
            this.btn_Return.BackgroundImage = global::DoAn_LTWindows.Properties.Resources._75pxbtn1;
            this.btn_Return.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Return.FlatAppearance.BorderSize = 0;
            this.btn_Return.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Return.Font = new System.Drawing.Font("Oswald", 14F);
            this.btn_Return.Location = new System.Drawing.Point(432, 564);
            this.btn_Return.Name = "btn_Return";
            this.btn_Return.Size = new System.Drawing.Size(129, 41);
            this.btn_Return.TabIndex = 63;
            this.btn_Return.Text = "Quay Lại";
            this.btn_Return.UseVisualStyleBackColor = false;
            // 
            // ucQuanLyTuyenXe
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::DoAn_LTWindows.Properties.Resources.mainbackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btn_Return);
            this.Controls.Add(this.dgv_TuyenXe);
            this.Controls.Add(this.btn_FindData);
            this.Controls.Add(this.txt_Find);
            this.Controls.Add(this.lbl_TimKiem);
            this.Controls.Add(this.pnl_Import);
            this.Controls.Add(this.lbl_Title);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Oswald", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MaximumSize = new System.Drawing.Size(992, 623);
            this.MinimumSize = new System.Drawing.Size(992, 623);
            this.Name = "ucQuanLyTuyenXe";
            this.Size = new System.Drawing.Size(992, 623);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TuyenXe)).EndInit();
            this.pnl_Import.ResumeLayout(false);
            this.pnl_Import.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Distance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_TuyenXe;
        private System.Windows.Forms.Button btn_FindData;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Find;
        private System.Windows.Forms.TextBox txt_Find;
        private System.Windows.Forms.Label lbl_TimKiem;
        private System.Windows.Forms.Label lbl_DiemDen;
        private System.Windows.Forms.TextBox txt_Start;
        private System.Windows.Forms.Label lbl_DiemXuatPhat;
        private System.Windows.Forms.Label lbl_TenTuyen;
        private System.Windows.Forms.Label lbl_MaTuyen;
        private System.Windows.Forms.Panel pnl_Import;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.TextBox txt_TenTuyen;
        private System.Windows.Forms.TextBox txt_MaTuyen;
        private System.Windows.Forms.Label lbl_ThoiGianChay;
        private System.Windows.Forms.NumericUpDown nud_Time;
        private System.Windows.Forms.Label lbl_KhoangCach;
        private System.Windows.Forms.NumericUpDown nud_Distance;
        private System.Windows.Forms.TextBox txt_End;
        private System.Windows.Forms.Button btn_Return;
    }
}
