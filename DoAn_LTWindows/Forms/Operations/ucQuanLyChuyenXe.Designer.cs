namespace DoAn_LTWindows.Forms.Operations
{
    partial class ucQuanLyChuyenXe
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
            this.lbl_TimKiem = new System.Windows.Forms.Label();
            this.txt_Find = new System.Windows.Forms.TextBox();
            this.pnl_Import = new System.Windows.Forms.Panel();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Find = new System.Windows.Forms.Button();
            this.lbl_ChonNgayGioXuatBen = new System.Windows.Forms.Label();
            this.txt_Price = new System.Windows.Forms.TextBox();
            this.lbl_NhapGiaVe = new System.Windows.Forms.Label();
            this.lbl_ChonXe = new System.Windows.Forms.Label();
            this.cmb_Xe = new System.Windows.Forms.ComboBox();
            this.lbl_ChonTuyen = new System.Windows.Forms.Label();
            this.cmb_Tuyen = new System.Windows.Forms.ComboBox();
            this.btn_FindData = new System.Windows.Forms.Button();
            this.dgv_ChuyenXe = new System.Windows.Forms.DataGridView();
            this.btn_Return = new System.Windows.Forms.Button();
            this.dtp_DateTime = new System.Windows.Forms.DateTimePicker();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenTuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBienSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaVe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThoiGianXuatBen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnl_Import.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ChuyenXe)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Title.Font = new System.Drawing.Font("Oswald", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lbl_Title.Location = new System.Drawing.Point(332, 16);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(328, 63);
            this.lbl_Title.TabIndex = 1;
            this.lbl_Title.Text = "QUẢN LÝ CHUYẾN XE";
            // 
            // lbl_TimKiem
            // 
            this.lbl_TimKiem.AutoSize = true;
            this.lbl_TimKiem.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TimKiem.Font = new System.Drawing.Font("Oswald", 18F);
            this.lbl_TimKiem.Location = new System.Drawing.Point(150, 79);
            this.lbl_TimKiem.Name = "lbl_TimKiem";
            this.lbl_TimKiem.Size = new System.Drawing.Size(102, 41);
            this.lbl_TimKiem.TabIndex = 8;
            this.lbl_TimKiem.Text = "Tìm Kiếm:";
            // 
            // txt_Find
            // 
            this.txt_Find.Font = new System.Drawing.Font("Oswald", 16F);
            this.txt_Find.Location = new System.Drawing.Point(258, 80);
            this.txt_Find.Name = "txt_Find";
            this.txt_Find.Size = new System.Drawing.Size(381, 39);
            this.txt_Find.TabIndex = 9;
            // 
            // pnl_Import
            // 
            this.pnl_Import.BackgroundImage = global::DoAn_LTWindows.Properties.Resources.mainbackground;
            this.pnl_Import.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl_Import.Controls.Add(this.dtp_DateTime);
            this.pnl_Import.Controls.Add(this.btn_Reset);
            this.pnl_Import.Controls.Add(this.btn_Delete);
            this.pnl_Import.Controls.Add(this.btn_Edit);
            this.pnl_Import.Controls.Add(this.btn_Save);
            this.pnl_Import.Controls.Add(this.btn_Find);
            this.pnl_Import.Controls.Add(this.lbl_ChonNgayGioXuatBen);
            this.pnl_Import.Controls.Add(this.txt_Price);
            this.pnl_Import.Controls.Add(this.lbl_NhapGiaVe);
            this.pnl_Import.Controls.Add(this.lbl_ChonXe);
            this.pnl_Import.Controls.Add(this.cmb_Xe);
            this.pnl_Import.Controls.Add(this.lbl_ChonTuyen);
            this.pnl_Import.Controls.Add(this.cmb_Tuyen);
            this.pnl_Import.Location = new System.Drawing.Point(88, 127);
            this.pnl_Import.Name = "pnl_Import";
            this.pnl_Import.Size = new System.Drawing.Size(816, 190);
            this.pnl_Import.TabIndex = 15;
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
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
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
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
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
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
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
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
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
            this.btn_Find.Click += new System.EventHandler(this.btn_Find_Click);
            // 
            // lbl_ChonNgayGioXuatBen
            // 
            this.lbl_ChonNgayGioXuatBen.AutoSize = true;
            this.lbl_ChonNgayGioXuatBen.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ChonNgayGioXuatBen.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_ChonNgayGioXuatBen.Location = new System.Drawing.Point(50, 98);
            this.lbl_ChonNgayGioXuatBen.Name = "lbl_ChonNgayGioXuatBen";
            this.lbl_ChonNgayGioXuatBen.Size = new System.Drawing.Size(232, 37);
            this.lbl_ChonNgayGioXuatBen.TabIndex = 22;
            this.lbl_ChonNgayGioXuatBen.Text = "Chọn Ngày & Giờ Xuất Bến:";
            this.lbl_ChonNgayGioXuatBen.UseMnemonic = false;
            // 
            // txt_Price
            // 
            this.txt_Price.Font = new System.Drawing.Font("Oswald", 14F);
            this.txt_Price.Location = new System.Drawing.Point(578, 51);
            this.txt_Price.Name = "txt_Price";
            this.txt_Price.Size = new System.Drawing.Size(188, 35);
            this.txt_Price.TabIndex = 20;
            // 
            // lbl_NhapGiaVe
            // 
            this.lbl_NhapGiaVe.AutoSize = true;
            this.lbl_NhapGiaVe.BackColor = System.Drawing.Color.Transparent;
            this.lbl_NhapGiaVe.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_NhapGiaVe.Location = new System.Drawing.Point(455, 51);
            this.lbl_NhapGiaVe.Name = "lbl_NhapGiaVe";
            this.lbl_NhapGiaVe.Size = new System.Drawing.Size(117, 37);
            this.lbl_NhapGiaVe.TabIndex = 21;
            this.lbl_NhapGiaVe.Text = "Nhập Giá Vé:";
            // 
            // lbl_ChonXe
            // 
            this.lbl_ChonXe.AutoSize = true;
            this.lbl_ChonXe.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ChonXe.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_ChonXe.Location = new System.Drawing.Point(50, 51);
            this.lbl_ChonXe.Name = "lbl_ChonXe";
            this.lbl_ChonXe.Size = new System.Drawing.Size(86, 37);
            this.lbl_ChonXe.TabIndex = 18;
            this.lbl_ChonXe.Text = "Chọn Xe:";
            // 
            // cmb_Xe
            // 
            this.cmb_Xe.Font = new System.Drawing.Font("Oswald", 14F);
            this.cmb_Xe.FormattingEnabled = true;
            this.cmb_Xe.Location = new System.Drawing.Point(168, 51);
            this.cmb_Xe.Name = "cmb_Xe";
            this.cmb_Xe.Size = new System.Drawing.Size(269, 40);
            this.cmb_Xe.TabIndex = 19;
            // 
            // lbl_ChonTuyen
            // 
            this.lbl_ChonTuyen.AutoSize = true;
            this.lbl_ChonTuyen.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ChonTuyen.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_ChonTuyen.Location = new System.Drawing.Point(50, 11);
            this.lbl_ChonTuyen.Name = "lbl_ChonTuyen";
            this.lbl_ChonTuyen.Size = new System.Drawing.Size(112, 37);
            this.lbl_ChonTuyen.TabIndex = 16;
            this.lbl_ChonTuyen.Text = "Chọn Tuyến:";
            // 
            // cmb_Tuyen
            // 
            this.cmb_Tuyen.Font = new System.Drawing.Font("Oswald", 14F);
            this.cmb_Tuyen.FormattingEnabled = true;
            this.cmb_Tuyen.Location = new System.Drawing.Point(168, 6);
            this.cmb_Tuyen.Name = "cmb_Tuyen";
            this.cmb_Tuyen.Size = new System.Drawing.Size(598, 40);
            this.cmb_Tuyen.TabIndex = 17;
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
            this.btn_FindData.TabIndex = 24;
            this.btn_FindData.Text = "Tìm Kiếm";
            this.btn_FindData.UseVisualStyleBackColor = false;
            this.btn_FindData.Click += new System.EventHandler(this.btn_FindData_Click);
            // 
            // dgv_ChuyenXe
            // 
            this.dgv_ChuyenXe.AllowUserToAddRows = false;
            this.dgv_ChuyenXe.AllowUserToDeleteRows = false;
            this.dgv_ChuyenXe.AllowUserToResizeColumns = false;
            this.dgv_ChuyenXe.AllowUserToResizeRows = false;
            this.dgv_ChuyenXe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ChuyenXe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colTenTuyen,
            this.colBienSo,
            this.colGiaVe,
            this.colThoiGianXuatBen});
            this.dgv_ChuyenXe.Location = new System.Drawing.Point(44, 323);
            this.dgv_ChuyenXe.Name = "dgv_ChuyenXe";
            this.dgv_ChuyenXe.ReadOnly = true;
            this.dgv_ChuyenXe.RowHeadersVisible = false;
            this.dgv_ChuyenXe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ChuyenXe.Size = new System.Drawing.Size(905, 237);
            this.dgv_ChuyenXe.TabIndex = 25;
            this.dgv_ChuyenXe.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_ChuyenXe_CellFormatting);
            this.dgv_ChuyenXe.SelectionChanged += new System.EventHandler(this.dgv_ChuyenXe_SelectionChanged);
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
            this.btn_Return.TabIndex = 64;
            this.btn_Return.Text = "Quay Lại";
            this.btn_Return.UseVisualStyleBackColor = false;
            this.btn_Return.Click += new System.EventHandler(this.btn_Return_Click);
            // 
            // dtp_DateTime
            // 
            this.dtp_DateTime.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtp_DateTime.Font = new System.Drawing.Font("Oswald", 14F);
            this.dtp_DateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_DateTime.Location = new System.Drawing.Point(288, 98);
            this.dtp_DateTime.Name = "dtp_DateTime";
            this.dtp_DateTime.Size = new System.Drawing.Size(257, 35);
            this.dtp_DateTime.TabIndex = 30;
            // 
            // colSTT
            // 
            this.colSTT.HeaderText = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.ReadOnly = true;
            this.colSTT.Width = 50;
            // 
            // colTenTuyen
            // 
            this.colTenTuyen.DataPropertyName = "TenTuyen";
            this.colTenTuyen.HeaderText = "Tên Tuyến";
            this.colTenTuyen.Name = "colTenTuyen";
            this.colTenTuyen.ReadOnly = true;
            this.colTenTuyen.Width = 350;
            // 
            // colBienSo
            // 
            this.colBienSo.DataPropertyName = "BienSo";
            this.colBienSo.HeaderText = "Biển Số";
            this.colBienSo.Name = "colBienSo";
            this.colBienSo.ReadOnly = true;
            this.colBienSo.Width = 160;
            // 
            // colGiaVe
            // 
            this.colGiaVe.DataPropertyName = "GiaVe";
            this.colGiaVe.HeaderText = "Giá Vé";
            this.colGiaVe.Name = "colGiaVe";
            this.colGiaVe.ReadOnly = true;
            this.colGiaVe.Width = 120;
            // 
            // colThoiGianXuatBen
            // 
            this.colThoiGianXuatBen.DataPropertyName = "ThoiGianXuatBen";
            this.colThoiGianXuatBen.HeaderText = "Thời Gian Xuất Bến";
            this.colThoiGianXuatBen.Name = "colThoiGianXuatBen";
            this.colThoiGianXuatBen.ReadOnly = true;
            this.colThoiGianXuatBen.Width = 222;
            // 
            // ucQuanLyChuyenXe
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::DoAn_LTWindows.Properties.Resources.mainbackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btn_Return);
            this.Controls.Add(this.dgv_ChuyenXe);
            this.Controls.Add(this.btn_FindData);
            this.Controls.Add(this.pnl_Import);
            this.Controls.Add(this.txt_Find);
            this.Controls.Add(this.lbl_TimKiem);
            this.Controls.Add(this.lbl_Title);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Oswald", 14F);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MaximumSize = new System.Drawing.Size(992, 623);
            this.MinimumSize = new System.Drawing.Size(992, 623);
            this.Name = "ucQuanLyChuyenXe";
            this.Size = new System.Drawing.Size(992, 623);
            this.Load += new System.EventHandler(this.ucQuanLyChuyenXe_Load);
            this.pnl_Import.ResumeLayout(false);
            this.pnl_Import.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ChuyenXe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Label lbl_TimKiem;
        private System.Windows.Forms.TextBox txt_Find;
        private System.Windows.Forms.Panel pnl_Import;
        private System.Windows.Forms.Label lbl_ChonTuyen;
        private System.Windows.Forms.ComboBox cmb_Tuyen;
        private System.Windows.Forms.Label lbl_ChonXe;
        private System.Windows.Forms.ComboBox cmb_Xe;
        private System.Windows.Forms.Label lbl_ChonNgayGioXuatBen;
        private System.Windows.Forms.TextBox txt_Price;
        private System.Windows.Forms.Label lbl_NhapGiaVe;
        private System.Windows.Forms.Button btn_FindData;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Find;
        private System.Windows.Forms.DataGridView dgv_ChuyenXe;
        private System.Windows.Forms.Button btn_Return;
        private System.Windows.Forms.DateTimePicker dtp_DateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenTuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBienSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiaVe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThoiGianXuatBen;
    }
}
