namespace DoAn_LTWindows.Forms.Operations
{
    partial class ucTraCuuVe
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
            this.chk_SoDienThoai = new System.Windows.Forms.CheckBox();
            this.chk_MaVe = new System.Windows.Forms.CheckBox();
            this.lbl_TimKiem = new System.Windows.Forms.Label();
            this.lbl_TraCuuTheo = new System.Windows.Forms.Label();
            this.lbl_SoDienThoai = new System.Windows.Forms.Label();
            this.txt_SoDienThoai = new System.Windows.Forms.TextBox();
            this.btn_FindSoDienThoai = new System.Windows.Forms.Button();
            this.btn_FindMaSoVe = new System.Windows.Forms.Button();
            this.txt_MaSoVe = new System.Windows.Forms.TextBox();
            this.lbl_MaSoVe = new System.Windows.Forms.Label();
            this.dgv_Ve = new System.Windows.Forms.DataGridView();
            this.lbl_ThongTinVe = new System.Windows.Forms.Label();
            this.btn_Refund = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Ve)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Title.Font = new System.Drawing.Font("Oswald", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lbl_Title.Location = new System.Drawing.Point(394, 16);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(204, 63);
            this.lbl_Title.TabIndex = 39;
            this.lbl_Title.Text = "TRA CỨU VÉ";
            // 
            // chk_SoDienThoai
            // 
            this.chk_SoDienThoai.AutoSize = true;
            this.chk_SoDienThoai.BackColor = System.Drawing.Color.Transparent;
            this.chk_SoDienThoai.Font = new System.Drawing.Font("Oswald", 18F);
            this.chk_SoDienThoai.Location = new System.Drawing.Point(53, 101);
            this.chk_SoDienThoai.Name = "chk_SoDienThoai";
            this.chk_SoDienThoai.Size = new System.Drawing.Size(199, 45);
            this.chk_SoDienThoai.TabIndex = 47;
            this.chk_SoDienThoai.Text = "Theo Số Điện Thoại";
            this.chk_SoDienThoai.UseVisualStyleBackColor = false;
            // 
            // chk_MaVe
            // 
            this.chk_MaVe.AutoSize = true;
            this.chk_MaVe.BackColor = System.Drawing.Color.Transparent;
            this.chk_MaVe.Font = new System.Drawing.Font("Oswald", 18F);
            this.chk_MaVe.Location = new System.Drawing.Point(53, 142);
            this.chk_MaVe.Name = "chk_MaVe";
            this.chk_MaVe.Size = new System.Drawing.Size(135, 45);
            this.chk_MaVe.TabIndex = 48;
            this.chk_MaVe.Text = "Theo Mã Vé";
            this.chk_MaVe.UseVisualStyleBackColor = false;
            // 
            // lbl_TimKiem
            // 
            this.lbl_TimKiem.AutoSize = true;
            this.lbl_TimKiem.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TimKiem.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_TimKiem.Location = new System.Drawing.Point(26, 190);
            this.lbl_TimKiem.Name = "lbl_TimKiem";
            this.lbl_TimKiem.Size = new System.Drawing.Size(204, 37);
            this.lbl_TimKiem.TabIndex = 49;
            this.lbl_TimKiem.Text = "Tìm Kiếm Theo Từ Khóa:";
            // 
            // lbl_TraCuuTheo
            // 
            this.lbl_TraCuuTheo.AutoSize = true;
            this.lbl_TraCuuTheo.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TraCuuTheo.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_TraCuuTheo.Location = new System.Drawing.Point(26, 71);
            this.lbl_TraCuuTheo.Name = "lbl_TraCuuTheo";
            this.lbl_TraCuuTheo.Size = new System.Drawing.Size(123, 37);
            this.lbl_TraCuuTheo.TabIndex = 50;
            this.lbl_TraCuuTheo.Text = "Tra Cứu Theo:";
            // 
            // lbl_SoDienThoai
            // 
            this.lbl_SoDienThoai.AutoSize = true;
            this.lbl_SoDienThoai.BackColor = System.Drawing.Color.Transparent;
            this.lbl_SoDienThoai.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_SoDienThoai.Location = new System.Drawing.Point(76, 230);
            this.lbl_SoDienThoai.Name = "lbl_SoDienThoai";
            this.lbl_SoDienThoai.Size = new System.Drawing.Size(128, 37);
            this.lbl_SoDienThoai.TabIndex = 51;
            this.lbl_SoDienThoai.Text = "Số Điện Thoại:";
            // 
            // txt_SoDienThoai
            // 
            this.txt_SoDienThoai.Font = new System.Drawing.Font("Oswald", 16F);
            this.txt_SoDienThoai.Location = new System.Drawing.Point(210, 230);
            this.txt_SoDienThoai.Name = "txt_SoDienThoai";
            this.txt_SoDienThoai.Size = new System.Drawing.Size(258, 39);
            this.txt_SoDienThoai.TabIndex = 52;
            // 
            // btn_FindSoDienThoai
            // 
            this.btn_FindSoDienThoai.BackColor = System.Drawing.Color.Transparent;
            this.btn_FindSoDienThoai.BackgroundImage = global::DoAn_LTWindows.Properties.Resources._75pxbtn1;
            this.btn_FindSoDienThoai.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_FindSoDienThoai.FlatAppearance.BorderSize = 0;
            this.btn_FindSoDienThoai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_FindSoDienThoai.Font = new System.Drawing.Font("Oswald", 14F);
            this.btn_FindSoDienThoai.Location = new System.Drawing.Point(489, 229);
            this.btn_FindSoDienThoai.Name = "btn_FindSoDienThoai";
            this.btn_FindSoDienThoai.Size = new System.Drawing.Size(129, 41);
            this.btn_FindSoDienThoai.TabIndex = 53;
            this.btn_FindSoDienThoai.Text = "Tìm Kiếm";
            this.btn_FindSoDienThoai.UseVisualStyleBackColor = false;
            // 
            // btn_FindMaSoVe
            // 
            this.btn_FindMaSoVe.BackColor = System.Drawing.Color.Transparent;
            this.btn_FindMaSoVe.BackgroundImage = global::DoAn_LTWindows.Properties.Resources._75pxbtn1;
            this.btn_FindMaSoVe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_FindMaSoVe.FlatAppearance.BorderSize = 0;
            this.btn_FindMaSoVe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_FindMaSoVe.Font = new System.Drawing.Font("Oswald", 14F);
            this.btn_FindMaSoVe.Location = new System.Drawing.Point(489, 274);
            this.btn_FindMaSoVe.Name = "btn_FindMaSoVe";
            this.btn_FindMaSoVe.Size = new System.Drawing.Size(129, 41);
            this.btn_FindMaSoVe.TabIndex = 56;
            this.btn_FindMaSoVe.Text = "Tìm Kiếm";
            this.btn_FindMaSoVe.UseVisualStyleBackColor = false;
            // 
            // txt_MaSoVe
            // 
            this.txt_MaSoVe.Font = new System.Drawing.Font("Oswald", 16F);
            this.txt_MaSoVe.Location = new System.Drawing.Point(210, 275);
            this.txt_MaSoVe.Name = "txt_MaSoVe";
            this.txt_MaSoVe.Size = new System.Drawing.Size(258, 39);
            this.txt_MaSoVe.TabIndex = 55;
            // 
            // lbl_MaSoVe
            // 
            this.lbl_MaSoVe.AutoSize = true;
            this.lbl_MaSoVe.BackColor = System.Drawing.Color.Transparent;
            this.lbl_MaSoVe.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_MaSoVe.Location = new System.Drawing.Point(76, 275);
            this.lbl_MaSoVe.Name = "lbl_MaSoVe";
            this.lbl_MaSoVe.Size = new System.Drawing.Size(93, 37);
            this.lbl_MaSoVe.TabIndex = 54;
            this.lbl_MaSoVe.Text = "Mã Số Vé:";
            // 
            // dgv_Ve
            // 
            this.dgv_Ve.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Ve.Location = new System.Drawing.Point(29, 321);
            this.dgv_Ve.Name = "dgv_Ve";
            this.dgv_Ve.Size = new System.Drawing.Size(927, 232);
            this.dgv_Ve.TabIndex = 57;
            // 
            // lbl_ThongTinVe
            // 
            this.lbl_ThongTinVe.AutoSize = true;
            this.lbl_ThongTinVe.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ThongTinVe.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_ThongTinVe.Location = new System.Drawing.Point(27, 560);
            this.lbl_ThongTinVe.Name = "lbl_ThongTinVe";
            this.lbl_ThongTinVe.Size = new System.Drawing.Size(122, 37);
            this.lbl_ThongTinVe.TabIndex = 58;
            this.lbl_ThongTinVe.Text = "Thông Tin Vé:";
            // 
            // btn_Refund
            // 
            this.btn_Refund.BackColor = System.Drawing.Color.Transparent;
            this.btn_Refund.BackgroundImage = global::DoAn_LTWindows.Properties.Resources._75pxbtnd;
            this.btn_Refund.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Refund.FlatAppearance.BorderSize = 0;
            this.btn_Refund.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Refund.Font = new System.Drawing.Font("Oswald", 14F);
            this.btn_Refund.Location = new System.Drawing.Point(793, 559);
            this.btn_Refund.Name = "btn_Refund";
            this.btn_Refund.Size = new System.Drawing.Size(163, 41);
            this.btn_Refund.TabIndex = 59;
            this.btn_Refund.Text = "Hủy Vé / Hoàn Tiền";
            this.btn_Refund.UseVisualStyleBackColor = false;
            // 
            // ucTraCuuVe
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::DoAn_LTWindows.Properties.Resources.mainbackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btn_Refund);
            this.Controls.Add(this.lbl_ThongTinVe);
            this.Controls.Add(this.dgv_Ve);
            this.Controls.Add(this.btn_FindMaSoVe);
            this.Controls.Add(this.txt_MaSoVe);
            this.Controls.Add(this.lbl_MaSoVe);
            this.Controls.Add(this.btn_FindSoDienThoai);
            this.Controls.Add(this.txt_SoDienThoai);
            this.Controls.Add(this.lbl_SoDienThoai);
            this.Controls.Add(this.lbl_TraCuuTheo);
            this.Controls.Add(this.lbl_TimKiem);
            this.Controls.Add(this.chk_MaVe);
            this.Controls.Add(this.chk_SoDienThoai);
            this.Controls.Add(this.lbl_Title);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Oswald", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MaximumSize = new System.Drawing.Size(992, 623);
            this.MinimumSize = new System.Drawing.Size(992, 623);
            this.Name = "ucTraCuuVe";
            this.Size = new System.Drawing.Size(992, 623);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Ve)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.CheckBox chk_SoDienThoai;
        private System.Windows.Forms.CheckBox chk_MaVe;
        private System.Windows.Forms.Label lbl_TimKiem;
        private System.Windows.Forms.Label lbl_TraCuuTheo;
        private System.Windows.Forms.Label lbl_SoDienThoai;
        private System.Windows.Forms.TextBox txt_SoDienThoai;
        private System.Windows.Forms.Button btn_FindSoDienThoai;
        private System.Windows.Forms.Button btn_FindMaSoVe;
        private System.Windows.Forms.TextBox txt_MaSoVe;
        private System.Windows.Forms.Label lbl_MaSoVe;
        private System.Windows.Forms.DataGridView dgv_Ve;
        private System.Windows.Forms.Label lbl_ThongTinVe;
        private System.Windows.Forms.Button btn_Refund;
    }
}
