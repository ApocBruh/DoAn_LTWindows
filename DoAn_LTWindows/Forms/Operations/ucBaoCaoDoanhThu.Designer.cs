namespace DoAn_LTWindows.Forms.Operations
{
    partial class ucBaoCaoDoanhThu
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
            this.dtp_FromDate = new System.Windows.Forms.DateTimePicker();
            this.lbl_FromDate = new System.Windows.Forms.Label();
            this.lbl_ToDate = new System.Windows.Forms.Label();
            this.dtp_ToDate = new System.Windows.Forms.DateTimePicker();
            this.btn_ThongKe = new System.Windows.Forms.Button();
            this.dgv_DoanhThu = new System.Windows.Forms.DataGridView();
            this.btn_TongSoLieuThongKe = new System.Windows.Forms.Button();
            this.btn_ExportExcel = new System.Windows.Forms.Button();
            this.btn_Return = new System.Windows.Forms.Button();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaSoVe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaiVe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaVe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayGiaoDich = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DoanhThu)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Title.Font = new System.Drawing.Font("Oswald", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lbl_Title.Location = new System.Drawing.Point(321, 16);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(350, 63);
            this.lbl_Title.TabIndex = 1;
            this.lbl_Title.Text = "BÁO CÁO DOANH THU";
            // 
            // dtp_FromDate
            // 
            this.dtp_FromDate.Font = new System.Drawing.Font("Oswald", 14F);
            this.dtp_FromDate.Location = new System.Drawing.Point(219, 97);
            this.dtp_FromDate.Name = "dtp_FromDate";
            this.dtp_FromDate.Size = new System.Drawing.Size(204, 35);
            this.dtp_FromDate.TabIndex = 2;
            this.dtp_FromDate.ValueChanged += new System.EventHandler(this.KiemTraNgayHopLe);
            // 
            // lbl_FromDate
            // 
            this.lbl_FromDate.AutoSize = true;
            this.lbl_FromDate.BackColor = System.Drawing.Color.Transparent;
            this.lbl_FromDate.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_FromDate.Location = new System.Drawing.Point(130, 97);
            this.lbl_FromDate.Name = "lbl_FromDate";
            this.lbl_FromDate.Size = new System.Drawing.Size(83, 37);
            this.lbl_FromDate.TabIndex = 51;
            this.lbl_FromDate.Text = "Từ Ngày:";
            // 
            // lbl_ToDate
            // 
            this.lbl_ToDate.AutoSize = true;
            this.lbl_ToDate.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ToDate.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_ToDate.Location = new System.Drawing.Point(557, 97);
            this.lbl_ToDate.Name = "lbl_ToDate";
            this.lbl_ToDate.Size = new System.Drawing.Size(96, 37);
            this.lbl_ToDate.TabIndex = 52;
            this.lbl_ToDate.Text = "Đến Ngày:";
            // 
            // dtp_ToDate
            // 
            this.dtp_ToDate.Font = new System.Drawing.Font("Oswald", 14F);
            this.dtp_ToDate.Location = new System.Drawing.Point(659, 97);
            this.dtp_ToDate.Name = "dtp_ToDate";
            this.dtp_ToDate.Size = new System.Drawing.Size(204, 35);
            this.dtp_ToDate.TabIndex = 53;
            this.dtp_ToDate.ValueChanged += new System.EventHandler(this.KiemTraNgayHopLe);
            // 
            // btn_ThongKe
            // 
            this.btn_ThongKe.BackColor = System.Drawing.Color.Transparent;
            this.btn_ThongKe.BackgroundImage = global::DoAn_LTWindows.Properties.Resources._75pxbtn1;
            this.btn_ThongKe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_ThongKe.FlatAppearance.BorderSize = 0;
            this.btn_ThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ThongKe.Font = new System.Drawing.Font("Oswald", 14F);
            this.btn_ThongKe.Location = new System.Drawing.Point(432, 149);
            this.btn_ThongKe.Name = "btn_ThongKe";
            this.btn_ThongKe.Size = new System.Drawing.Size(129, 41);
            this.btn_ThongKe.TabIndex = 54;
            this.btn_ThongKe.Text = "Thống Kê";
            this.btn_ThongKe.UseVisualStyleBackColor = false;
            this.btn_ThongKe.Click += new System.EventHandler(this.btn_ThongKe_Click);
            // 
            // dgv_DoanhThu
            // 
            this.dgv_DoanhThu.AllowUserToAddRows = false;
            this.dgv_DoanhThu.AllowUserToDeleteRows = false;
            this.dgv_DoanhThu.AllowUserToResizeColumns = false;
            this.dgv_DoanhThu.AllowUserToResizeRows = false;
            this.dgv_DoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DoanhThu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colMaSoVe,
            this.colLoaiVe,
            this.colGiaVe,
            this.colNgayGiaoDich});
            this.dgv_DoanhThu.Location = new System.Drawing.Point(65, 196);
            this.dgv_DoanhThu.Name = "dgv_DoanhThu";
            this.dgv_DoanhThu.RowHeadersVisible = false;
            this.dgv_DoanhThu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_DoanhThu.Size = new System.Drawing.Size(862, 354);
            this.dgv_DoanhThu.TabIndex = 55;
            this.dgv_DoanhThu.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_DoanhThu_CellFormatting);
            // 
            // btn_TongSoLieuThongKe
            // 
            this.btn_TongSoLieuThongKe.BackColor = System.Drawing.Color.Transparent;
            this.btn_TongSoLieuThongKe.BackgroundImage = global::DoAn_LTWindows.Properties.Resources._75pxbtn1;
            this.btn_TongSoLieuThongKe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_TongSoLieuThongKe.FlatAppearance.BorderSize = 0;
            this.btn_TongSoLieuThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TongSoLieuThongKe.Font = new System.Drawing.Font("Oswald", 14F);
            this.btn_TongSoLieuThongKe.Location = new System.Drawing.Point(446, 556);
            this.btn_TongSoLieuThongKe.Name = "btn_TongSoLieuThongKe";
            this.btn_TongSoLieuThongKe.Size = new System.Drawing.Size(190, 41);
            this.btn_TongSoLieuThongKe.TabIndex = 56;
            this.btn_TongSoLieuThongKe.Text = "Tổng Số Liệu Thống Kê";
            this.btn_TongSoLieuThongKe.UseVisualStyleBackColor = false;
            this.btn_TongSoLieuThongKe.Click += new System.EventHandler(this.btn_TongSoLieuThongKe_Click);
            // 
            // btn_ExportExcel
            // 
            this.btn_ExportExcel.BackColor = System.Drawing.Color.Transparent;
            this.btn_ExportExcel.BackgroundImage = global::DoAn_LTWindows.Properties.Resources._75pxbtn1;
            this.btn_ExportExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_ExportExcel.FlatAppearance.BorderSize = 0;
            this.btn_ExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ExportExcel.Font = new System.Drawing.Font("Oswald", 14F);
            this.btn_ExportExcel.Location = new System.Drawing.Point(642, 556);
            this.btn_ExportExcel.Name = "btn_ExportExcel";
            this.btn_ExportExcel.Size = new System.Drawing.Size(150, 41);
            this.btn_ExportExcel.TabIndex = 57;
            this.btn_ExportExcel.Text = "Xuất File Excel";
            this.btn_ExportExcel.UseVisualStyleBackColor = false;
            this.btn_ExportExcel.Click += new System.EventHandler(this.btn_ExportExcel_Click);
            // 
            // btn_Return
            // 
            this.btn_Return.BackColor = System.Drawing.Color.Transparent;
            this.btn_Return.BackgroundImage = global::DoAn_LTWindows.Properties.Resources._75pxbtn1;
            this.btn_Return.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Return.FlatAppearance.BorderSize = 0;
            this.btn_Return.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Return.Font = new System.Drawing.Font("Oswald", 14F);
            this.btn_Return.Location = new System.Drawing.Point(798, 556);
            this.btn_Return.Name = "btn_Return";
            this.btn_Return.Size = new System.Drawing.Size(129, 41);
            this.btn_Return.TabIndex = 58;
            this.btn_Return.Text = "Quay Lại";
            this.btn_Return.UseVisualStyleBackColor = false;
            this.btn_Return.Click += new System.EventHandler(this.btn_Return_Click);
            // 
            // colSTT
            // 
            this.colSTT.HeaderText = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.ReadOnly = true;
            this.colSTT.Width = 50;
            // 
            // colMaSoVe
            // 
            this.colMaSoVe.DataPropertyName = "MaSoVe";
            this.colMaSoVe.HeaderText = "Mã Số Vé";
            this.colMaSoVe.Name = "colMaSoVe";
            this.colMaSoVe.ReadOnly = true;
            this.colMaSoVe.Width = 200;
            // 
            // colLoaiVe
            // 
            this.colLoaiVe.DataPropertyName = "LoaiVe";
            this.colLoaiVe.HeaderText = "Loại Vé";
            this.colLoaiVe.Name = "colLoaiVe";
            this.colLoaiVe.ReadOnly = true;
            this.colLoaiVe.Width = 150;
            // 
            // colGiaVe
            // 
            this.colGiaVe.DataPropertyName = "GiaVe";
            this.colGiaVe.HeaderText = "Giá Vé";
            this.colGiaVe.Name = "colGiaVe";
            this.colGiaVe.ReadOnly = true;
            this.colGiaVe.Width = 150;
            // 
            // colNgayGiaoDich
            // 
            this.colNgayGiaoDich.DataPropertyName = "NgayGiaoDich";
            this.colNgayGiaoDich.HeaderText = "Thời Gian Bán";
            this.colNgayGiaoDich.Name = "colNgayGiaoDich";
            this.colNgayGiaoDich.ReadOnly = true;
            this.colNgayGiaoDich.Width = 309;
            // 
            // ucBaoCaoDoanhThu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::DoAn_LTWindows.Properties.Resources.mainbackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btn_Return);
            this.Controls.Add(this.btn_ExportExcel);
            this.Controls.Add(this.btn_TongSoLieuThongKe);
            this.Controls.Add(this.dgv_DoanhThu);
            this.Controls.Add(this.btn_ThongKe);
            this.Controls.Add(this.dtp_ToDate);
            this.Controls.Add(this.lbl_ToDate);
            this.Controls.Add(this.lbl_FromDate);
            this.Controls.Add(this.dtp_FromDate);
            this.Controls.Add(this.lbl_Title);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Oswald", 14F);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MaximumSize = new System.Drawing.Size(992, 623);
            this.MinimumSize = new System.Drawing.Size(992, 623);
            this.Name = "ucBaoCaoDoanhThu";
            this.Size = new System.Drawing.Size(992, 623);
            this.Load += new System.EventHandler(this.ucBaoCaoDoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DoanhThu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.DateTimePicker dtp_FromDate;
        private System.Windows.Forms.Label lbl_FromDate;
        private System.Windows.Forms.Label lbl_ToDate;
        private System.Windows.Forms.DateTimePicker dtp_ToDate;
        private System.Windows.Forms.Button btn_ThongKe;
        private System.Windows.Forms.DataGridView dgv_DoanhThu;
        private System.Windows.Forms.Button btn_TongSoLieuThongKe;
        private System.Windows.Forms.Button btn_ExportExcel;
        private System.Windows.Forms.Button btn_Return;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSoVe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiVe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiaVe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayGiaoDich;
    }
}
