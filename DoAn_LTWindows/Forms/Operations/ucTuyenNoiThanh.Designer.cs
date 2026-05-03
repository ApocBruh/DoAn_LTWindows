namespace DoAn_LTWindows.Forms.Operations
{
    partial class ucTuyenNoiThanh
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
            this.lbl_ChonTuyenXe = new System.Windows.Forms.Label();
            this.lbl_SoLuongVe = new System.Windows.Forms.Label();
            this.lbl_ThongTinChiTiet = new System.Windows.Forms.Label();
            this.cmb_TuyenXe = new System.Windows.Forms.ComboBox();
            this.pnl_ThongTinChiTiet = new System.Windows.Forms.Panel();
            this.lbl_TitleChiTiet = new System.Windows.Forms.Label();
            this.lbl_TTData = new System.Windows.Forms.Label();
            this.lbl_HTTTData = new System.Windows.Forms.Label();
            this.lbl_TGData = new System.Windows.Forms.Label();
            this.lbl_SXData = new System.Windows.Forms.Label();
            this.lbl_HinhThucThanhToan = new System.Windows.Forms.Label();
            this.lbl_TenTram = new System.Windows.Forms.Label();
            this.lbl_SoXe = new System.Windows.Forms.Label();
            this.lbl_GVData = new System.Windows.Forms.Label();
            this.lbl_TXData = new System.Windows.Forms.Label();
            this.lbl_MSVData = new System.Windows.Forms.Label();
            this.lbl_GiaVe = new System.Windows.Forms.Label();
            this.lbl_ThoiGian = new System.Windows.Forms.Label();
            this.lbl_TuyenXe = new System.Windows.Forms.Label();
            this.lbl_MaSoVe = new System.Windows.Forms.Label();
            this.btn_PrintTicket = new System.Windows.Forms.Button();
            this.btn_Return = new System.Windows.Forms.Button();
            this.btn_Previous = new System.Windows.Forms.Button();
            this.btn_Next = new System.Windows.Forms.Button();
            this.nud_SoLuongVe = new System.Windows.Forms.NumericUpDown();
            this.pnl_ThongTinChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_SoLuongVe)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Title.Font = new System.Drawing.Font("Oswald", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lbl_Title.Location = new System.Drawing.Point(326, 16);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(341, 63);
            this.lbl_Title.TabIndex = 1;
            this.lbl_Title.Text = "TUYẾN XE NỘI THÀNH";
            // 
            // lbl_ChonTuyenXe
            // 
            this.lbl_ChonTuyenXe.AutoSize = true;
            this.lbl_ChonTuyenXe.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ChonTuyenXe.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_ChonTuyenXe.Location = new System.Drawing.Point(71, 81);
            this.lbl_ChonTuyenXe.Name = "lbl_ChonTuyenXe";
            this.lbl_ChonTuyenXe.Size = new System.Drawing.Size(137, 37);
            this.lbl_ChonTuyenXe.TabIndex = 2;
            this.lbl_ChonTuyenXe.Text = "Chọn Tuyến Xe:";
            // 
            // lbl_SoLuongVe
            // 
            this.lbl_SoLuongVe.AutoSize = true;
            this.lbl_SoLuongVe.BackColor = System.Drawing.Color.Transparent;
            this.lbl_SoLuongVe.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_SoLuongVe.Location = new System.Drawing.Point(696, 84);
            this.lbl_SoLuongVe.Name = "lbl_SoLuongVe";
            this.lbl_SoLuongVe.Size = new System.Drawing.Size(117, 37);
            this.lbl_SoLuongVe.TabIndex = 3;
            this.lbl_SoLuongVe.Text = "Số Lượng Vé:";
            // 
            // lbl_ThongTinChiTiet
            // 
            this.lbl_ThongTinChiTiet.AutoSize = true;
            this.lbl_ThongTinChiTiet.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ThongTinChiTiet.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_ThongTinChiTiet.Location = new System.Drawing.Point(414, 125);
            this.lbl_ThongTinChiTiet.Name = "lbl_ThongTinChiTiet";
            this.lbl_ThongTinChiTiet.Size = new System.Drawing.Size(164, 37);
            this.lbl_ThongTinChiTiet.TabIndex = 4;
            this.lbl_ThongTinChiTiet.Text = "Thông Tin Chi Tiết:";
            // 
            // cmb_TuyenXe
            // 
            this.cmb_TuyenXe.Font = new System.Drawing.Font("Oswald", 14F);
            this.cmb_TuyenXe.FormattingEnabled = true;
            this.cmb_TuyenXe.Location = new System.Drawing.Point(214, 81);
            this.cmb_TuyenXe.Name = "cmb_TuyenXe";
            this.cmb_TuyenXe.Size = new System.Drawing.Size(458, 40);
            this.cmb_TuyenXe.TabIndex = 5;
            this.cmb_TuyenXe.SelectedIndexChanged += new System.EventHandler(this.cmb_TuyenXe_SelectedIndexChanged);
            // 
            // pnl_ThongTinChiTiet
            // 
            this.pnl_ThongTinChiTiet.BackgroundImage = global::DoAn_LTWindows.Properties.Resources.mainbackground;
            this.pnl_ThongTinChiTiet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl_ThongTinChiTiet.Controls.Add(this.lbl_TitleChiTiet);
            this.pnl_ThongTinChiTiet.Controls.Add(this.lbl_TTData);
            this.pnl_ThongTinChiTiet.Controls.Add(this.lbl_HTTTData);
            this.pnl_ThongTinChiTiet.Controls.Add(this.lbl_TGData);
            this.pnl_ThongTinChiTiet.Controls.Add(this.lbl_SXData);
            this.pnl_ThongTinChiTiet.Controls.Add(this.lbl_HinhThucThanhToan);
            this.pnl_ThongTinChiTiet.Controls.Add(this.lbl_TenTram);
            this.pnl_ThongTinChiTiet.Controls.Add(this.lbl_SoXe);
            this.pnl_ThongTinChiTiet.Controls.Add(this.lbl_GVData);
            this.pnl_ThongTinChiTiet.Controls.Add(this.lbl_TXData);
            this.pnl_ThongTinChiTiet.Controls.Add(this.lbl_MSVData);
            this.pnl_ThongTinChiTiet.Controls.Add(this.lbl_GiaVe);
            this.pnl_ThongTinChiTiet.Controls.Add(this.lbl_ThoiGian);
            this.pnl_ThongTinChiTiet.Controls.Add(this.lbl_TuyenXe);
            this.pnl_ThongTinChiTiet.Controls.Add(this.lbl_MaSoVe);
            this.pnl_ThongTinChiTiet.Location = new System.Drawing.Point(268, 165);
            this.pnl_ThongTinChiTiet.Name = "pnl_ThongTinChiTiet";
            this.pnl_ThongTinChiTiet.Size = new System.Drawing.Size(456, 341);
            this.pnl_ThongTinChiTiet.TabIndex = 7;
            // 
            // lbl_TitleChiTiet
            // 
            this.lbl_TitleChiTiet.AutoSize = true;
            this.lbl_TitleChiTiet.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TitleChiTiet.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_TitleChiTiet.Location = new System.Drawing.Point(147, 14);
            this.lbl_TitleChiTiet.Name = "lbl_TitleChiTiet";
            this.lbl_TitleChiTiet.Size = new System.Drawing.Size(162, 37);
            this.lbl_TitleChiTiet.TabIndex = 13;
            this.lbl_TitleChiTiet.Text = "PHIẾU ĐI XE BUÝT";
            // 
            // lbl_TTData
            // 
            this.lbl_TTData.AutoSize = true;
            this.lbl_TTData.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TTData.Font = new System.Drawing.Font("Oswald", 18F);
            this.lbl_TTData.Location = new System.Drawing.Point(120, 293);
            this.lbl_TTData.Name = "lbl_TTData";
            this.lbl_TTData.Size = new System.Drawing.Size(38, 41);
            this.lbl_TTData.TabIndex = 27;
            this.lbl_TTData.Text = "TT";
            // 
            // lbl_HTTTData
            // 
            this.lbl_HTTTData.AutoSize = true;
            this.lbl_HTTTData.BackColor = System.Drawing.Color.Transparent;
            this.lbl_HTTTData.Font = new System.Drawing.Font("Oswald", 18F);
            this.lbl_HTTTData.Location = new System.Drawing.Point(232, 90);
            this.lbl_HTTTData.Name = "lbl_HTTTData";
            this.lbl_HTTTData.Size = new System.Drawing.Size(61, 41);
            this.lbl_HTTTData.TabIndex = 26;
            this.lbl_HTTTData.Text = "HTTT";
            // 
            // lbl_TGData
            // 
            this.lbl_TGData.AutoSize = true;
            this.lbl_TGData.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TGData.Font = new System.Drawing.Font("Oswald", 18F);
            this.lbl_TGData.Location = new System.Drawing.Point(123, 131);
            this.lbl_TGData.Name = "lbl_TGData";
            this.lbl_TGData.Size = new System.Drawing.Size(41, 41);
            this.lbl_TGData.TabIndex = 25;
            this.lbl_TGData.Text = "TG";
            // 
            // lbl_SXData
            // 
            this.lbl_SXData.AutoSize = true;
            this.lbl_SXData.BackColor = System.Drawing.Color.Transparent;
            this.lbl_SXData.Font = new System.Drawing.Font("Oswald", 18F);
            this.lbl_SXData.Location = new System.Drawing.Point(91, 211);
            this.lbl_SXData.Name = "lbl_SXData";
            this.lbl_SXData.Size = new System.Drawing.Size(41, 41);
            this.lbl_SXData.TabIndex = 24;
            this.lbl_SXData.Text = "SX";
            // 
            // lbl_HinhThucThanhToan
            // 
            this.lbl_HinhThucThanhToan.AutoSize = true;
            this.lbl_HinhThucThanhToan.BackColor = System.Drawing.Color.Transparent;
            this.lbl_HinhThucThanhToan.Font = new System.Drawing.Font("Oswald", 18F);
            this.lbl_HinhThucThanhToan.Location = new System.Drawing.Point(14, 90);
            this.lbl_HinhThucThanhToan.Name = "lbl_HinhThucThanhToan";
            this.lbl_HinhThucThanhToan.Size = new System.Drawing.Size(212, 41);
            this.lbl_HinhThucThanhToan.TabIndex = 23;
            this.lbl_HinhThucThanhToan.Text = "Hình Thức Thanh Toán:";
            // 
            // lbl_TenTram
            // 
            this.lbl_TenTram.AutoSize = true;
            this.lbl_TenTram.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TenTram.Font = new System.Drawing.Font("Oswald", 18F);
            this.lbl_TenTram.Location = new System.Drawing.Point(14, 293);
            this.lbl_TenTram.Name = "lbl_TenTram";
            this.lbl_TenTram.Size = new System.Drawing.Size(100, 41);
            this.lbl_TenTram.TabIndex = 22;
            this.lbl_TenTram.Text = "Tên Trạm:";
            // 
            // lbl_SoXe
            // 
            this.lbl_SoXe.AutoSize = true;
            this.lbl_SoXe.BackColor = System.Drawing.Color.Transparent;
            this.lbl_SoXe.Font = new System.Drawing.Font("Oswald", 18F);
            this.lbl_SoXe.Location = new System.Drawing.Point(14, 211);
            this.lbl_SoXe.Name = "lbl_SoXe";
            this.lbl_SoXe.Size = new System.Drawing.Size(71, 41);
            this.lbl_SoXe.TabIndex = 21;
            this.lbl_SoXe.Text = "Số Xe:";
            // 
            // lbl_GVData
            // 
            this.lbl_GVData.AutoSize = true;
            this.lbl_GVData.BackColor = System.Drawing.Color.Transparent;
            this.lbl_GVData.Font = new System.Drawing.Font("Oswald", 18F);
            this.lbl_GVData.Location = new System.Drawing.Point(97, 252);
            this.lbl_GVData.Name = "lbl_GVData";
            this.lbl_GVData.Size = new System.Drawing.Size(43, 41);
            this.lbl_GVData.TabIndex = 20;
            this.lbl_GVData.Text = "GV";
            // 
            // lbl_TXData
            // 
            this.lbl_TXData.AutoSize = true;
            this.lbl_TXData.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TXData.Font = new System.Drawing.Font("Oswald", 18F);
            this.lbl_TXData.Location = new System.Drawing.Point(120, 172);
            this.lbl_TXData.Name = "lbl_TXData";
            this.lbl_TXData.Size = new System.Drawing.Size(40, 41);
            this.lbl_TXData.TabIndex = 18;
            this.lbl_TXData.Text = "TX";
            // 
            // lbl_MSVData
            // 
            this.lbl_MSVData.AutoSize = true;
            this.lbl_MSVData.BackColor = System.Drawing.Color.Transparent;
            this.lbl_MSVData.Font = new System.Drawing.Font("Oswald", 18F);
            this.lbl_MSVData.Location = new System.Drawing.Point(121, 47);
            this.lbl_MSVData.Name = "lbl_MSVData";
            this.lbl_MSVData.Size = new System.Drawing.Size(57, 41);
            this.lbl_MSVData.TabIndex = 17;
            this.lbl_MSVData.Text = "MSV";
            // 
            // lbl_GiaVe
            // 
            this.lbl_GiaVe.AutoSize = true;
            this.lbl_GiaVe.BackColor = System.Drawing.Color.Transparent;
            this.lbl_GiaVe.Font = new System.Drawing.Font("Oswald", 18F);
            this.lbl_GiaVe.Location = new System.Drawing.Point(14, 252);
            this.lbl_GiaVe.Name = "lbl_GiaVe";
            this.lbl_GiaVe.Size = new System.Drawing.Size(77, 41);
            this.lbl_GiaVe.TabIndex = 16;
            this.lbl_GiaVe.Text = "Giá Vé:";
            // 
            // lbl_ThoiGian
            // 
            this.lbl_ThoiGian.AutoSize = true;
            this.lbl_ThoiGian.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ThoiGian.Font = new System.Drawing.Font("Oswald", 18F);
            this.lbl_ThoiGian.Location = new System.Drawing.Point(14, 131);
            this.lbl_ThoiGian.Name = "lbl_ThoiGian";
            this.lbl_ThoiGian.Size = new System.Drawing.Size(103, 41);
            this.lbl_ThoiGian.TabIndex = 15;
            this.lbl_ThoiGian.Text = "Thời Gian:";
            // 
            // lbl_TuyenXe
            // 
            this.lbl_TuyenXe.AutoSize = true;
            this.lbl_TuyenXe.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TuyenXe.Font = new System.Drawing.Font("Oswald", 18F);
            this.lbl_TuyenXe.Location = new System.Drawing.Point(14, 172);
            this.lbl_TuyenXe.Name = "lbl_TuyenXe";
            this.lbl_TuyenXe.Size = new System.Drawing.Size(100, 41);
            this.lbl_TuyenXe.TabIndex = 14;
            this.lbl_TuyenXe.Text = "Tuyến Xe:";
            // 
            // lbl_MaSoVe
            // 
            this.lbl_MaSoVe.AutoSize = true;
            this.lbl_MaSoVe.BackColor = System.Drawing.Color.Transparent;
            this.lbl_MaSoVe.Font = new System.Drawing.Font("Oswald", 18F);
            this.lbl_MaSoVe.Location = new System.Drawing.Point(14, 47);
            this.lbl_MaSoVe.Name = "lbl_MaSoVe";
            this.lbl_MaSoVe.Size = new System.Drawing.Size(101, 41);
            this.lbl_MaSoVe.TabIndex = 13;
            this.lbl_MaSoVe.Text = "Mã Số Vé:";
            // 
            // btn_PrintTicket
            // 
            this.btn_PrintTicket.BackColor = System.Drawing.Color.Transparent;
            this.btn_PrintTicket.BackgroundImage = global::DoAn_LTWindows.Properties.Resources._75pxbtn1;
            this.btn_PrintTicket.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_PrintTicket.FlatAppearance.BorderSize = 0;
            this.btn_PrintTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PrintTicket.Font = new System.Drawing.Font("Oswald", 18F);
            this.btn_PrintTicket.Location = new System.Drawing.Point(298, 530);
            this.btn_PrintTicket.Name = "btn_PrintTicket";
            this.btn_PrintTicket.Size = new System.Drawing.Size(185, 49);
            this.btn_PrintTicket.TabIndex = 8;
            this.btn_PrintTicket.Text = "In Vé";
            this.btn_PrintTicket.UseVisualStyleBackColor = false;
            this.btn_PrintTicket.Click += new System.EventHandler(this.btn_PrintTicket_Click);
            // 
            // btn_Return
            // 
            this.btn_Return.BackColor = System.Drawing.Color.Transparent;
            this.btn_Return.BackgroundImage = global::DoAn_LTWindows.Properties.Resources._75pxbtn1;
            this.btn_Return.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Return.FlatAppearance.BorderSize = 0;
            this.btn_Return.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Return.Font = new System.Drawing.Font("Oswald", 18F);
            this.btn_Return.Location = new System.Drawing.Point(509, 530);
            this.btn_Return.Name = "btn_Return";
            this.btn_Return.Size = new System.Drawing.Size(185, 49);
            this.btn_Return.TabIndex = 9;
            this.btn_Return.Text = "Quay Lại";
            this.btn_Return.UseVisualStyleBackColor = false;
            this.btn_Return.Click += new System.EventHandler(this.btn_Return_Click);
            // 
            // btn_Previous
            // 
            this.btn_Previous.BackgroundImage = global::DoAn_LTWindows.Properties.Resources._75pxbtn1;
            this.btn_Previous.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Previous.Font = new System.Drawing.Font("XNA CnCNet Client", 40.25F);
            this.btn_Previous.Location = new System.Drawing.Point(170, 297);
            this.btn_Previous.Name = "btn_Previous";
            this.btn_Previous.Size = new System.Drawing.Size(77, 77);
            this.btn_Previous.TabIndex = 10;
            this.btn_Previous.Text = "◀";
            this.btn_Previous.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Previous.UseVisualStyleBackColor = true;
            this.btn_Previous.Click += new System.EventHandler(this.btn_Previous_Click);
            // 
            // btn_Next
            // 
            this.btn_Next.BackgroundImage = global::DoAn_LTWindows.Properties.Resources._75pxbtn1;
            this.btn_Next.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Next.Font = new System.Drawing.Font("XNA CnCNet Client", 40.25F);
            this.btn_Next.Location = new System.Drawing.Point(745, 297);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(77, 77);
            this.btn_Next.TabIndex = 11;
            this.btn_Next.Text = "▶";
            this.btn_Next.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // nud_SoLuongVe
            // 
            this.nud_SoLuongVe.Font = new System.Drawing.Font("Oswald", 14F);
            this.nud_SoLuongVe.Location = new System.Drawing.Point(819, 86);
            this.nud_SoLuongVe.Name = "nud_SoLuongVe";
            this.nud_SoLuongVe.Size = new System.Drawing.Size(102, 35);
            this.nud_SoLuongVe.TabIndex = 12;
            this.nud_SoLuongVe.ValueChanged += new System.EventHandler(this.nud_SoLuongVe_ValueChanged_1);
            // 
            // ucTuyenNoiThanh
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::DoAn_LTWindows.Properties.Resources.mainbackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.nud_SoLuongVe);
            this.Controls.Add(this.btn_Next);
            this.Controls.Add(this.btn_Previous);
            this.Controls.Add(this.btn_Return);
            this.Controls.Add(this.btn_PrintTicket);
            this.Controls.Add(this.pnl_ThongTinChiTiet);
            this.Controls.Add(this.cmb_TuyenXe);
            this.Controls.Add(this.lbl_ThongTinChiTiet);
            this.Controls.Add(this.lbl_SoLuongVe);
            this.Controls.Add(this.lbl_ChonTuyenXe);
            this.Controls.Add(this.lbl_Title);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Oswald", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MaximumSize = new System.Drawing.Size(992, 623);
            this.MinimumSize = new System.Drawing.Size(992, 623);
            this.Name = "ucTuyenNoiThanh";
            this.Size = new System.Drawing.Size(992, 623);
            this.Load += new System.EventHandler(this.ucTuyenNoiThanh_Load);
            this.pnl_ThongTinChiTiet.ResumeLayout(false);
            this.pnl_ThongTinChiTiet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_SoLuongVe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Label lbl_ChonTuyenXe;
        private System.Windows.Forms.Label lbl_SoLuongVe;
        private System.Windows.Forms.Label lbl_ThongTinChiTiet;
        private System.Windows.Forms.ComboBox cmb_TuyenXe;
        private System.Windows.Forms.Panel pnl_ThongTinChiTiet;
        private System.Windows.Forms.Button btn_PrintTicket;
        private System.Windows.Forms.Button btn_Return;
        private System.Windows.Forms.Button btn_Previous;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.NumericUpDown nud_SoLuongVe;
        private System.Windows.Forms.Label lbl_GiaVe;
        private System.Windows.Forms.Label lbl_ThoiGian;
        private System.Windows.Forms.Label lbl_TuyenXe;
        private System.Windows.Forms.Label lbl_MaSoVe;
        private System.Windows.Forms.Label lbl_GVData;
        private System.Windows.Forms.Label lbl_TXData;
        private System.Windows.Forms.Label lbl_MSVData;
        private System.Windows.Forms.Label lbl_TenTram;
        private System.Windows.Forms.Label lbl_SoXe;
        private System.Windows.Forms.Label lbl_TTData;
        private System.Windows.Forms.Label lbl_HTTTData;
        private System.Windows.Forms.Label lbl_TGData;
        private System.Windows.Forms.Label lbl_SXData;
        private System.Windows.Forms.Label lbl_HinhThucThanhToan;
        private System.Windows.Forms.Label lbl_TitleChiTiet;
    }
}
