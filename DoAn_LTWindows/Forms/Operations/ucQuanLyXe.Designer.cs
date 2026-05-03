namespace DoAn_LTWindows.Forms.Operations
{
    partial class ucQuanLyXe
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
            this.dgv_Xe = new System.Windows.Forms.DataGridView();
            this.btn_FindData = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Find = new System.Windows.Forms.Button();
            this.cmb_TinhTrang = new System.Windows.Forms.ComboBox();
            this.txt_Find = new System.Windows.Forms.TextBox();
            this.lbl_TimKiem = new System.Windows.Forms.Label();
            this.lbl_TinhTrang = new System.Windows.Forms.Label();
            this.lbl_SoGhe = new System.Windows.Forms.Label();
            this.lbl_LoaiXe = new System.Windows.Forms.Label();
            this.cmb_LoaiXe = new System.Windows.Forms.ComboBox();
            this.lbl_BienSoXe = new System.Windows.Forms.Label();
            this.pnl_Import = new System.Windows.Forms.Panel();
            this.txt_BienSoXe = new System.Windows.Forms.TextBox();
            this.nud_SoGhe = new System.Windows.Forms.NumericUpDown();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.btn_Return = new System.Windows.Forms.Button();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaXe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBienSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaiXe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoGhe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTinhTrang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Xe)).BeginInit();
            this.pnl_Import.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_SoGhe)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Xe
            // 
            this.dgv_Xe.AllowUserToAddRows = false;
            this.dgv_Xe.AllowUserToDeleteRows = false;
            this.dgv_Xe.AllowUserToResizeColumns = false;
            this.dgv_Xe.AllowUserToResizeRows = false;
            this.dgv_Xe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Xe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colMaXe,
            this.colBienSo,
            this.colLoaiXe,
            this.colSoGhe,
            this.colTinhTrang});
            this.dgv_Xe.Location = new System.Drawing.Point(44, 323);
            this.dgv_Xe.Name = "dgv_Xe";
            this.dgv_Xe.RowHeadersVisible = false;
            this.dgv_Xe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Xe.Size = new System.Drawing.Size(905, 237);
            this.dgv_Xe.TabIndex = 31;
            this.dgv_Xe.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_Xe_CellFormatting);
            this.dgv_Xe.SelectionChanged += new System.EventHandler(this.dgv_Xe_SelectionChanged);
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
            this.btn_FindData.Click += new System.EventHandler(this.btn_FindData_Click);
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
            // cmb_TinhTrang
            // 
            this.cmb_TinhTrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_TinhTrang.Font = new System.Drawing.Font("Oswald", 14F);
            this.cmb_TinhTrang.FormattingEnabled = true;
            this.cmb_TinhTrang.Location = new System.Drawing.Point(459, 54);
            this.cmb_TinhTrang.Name = "cmb_TinhTrang";
            this.cmb_TinhTrang.Size = new System.Drawing.Size(329, 40);
            this.cmb_TinhTrang.TabIndex = 23;
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
            // lbl_TinhTrang
            // 
            this.lbl_TinhTrang.AutoSize = true;
            this.lbl_TinhTrang.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TinhTrang.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_TinhTrang.Location = new System.Drawing.Point(349, 57);
            this.lbl_TinhTrang.Name = "lbl_TinhTrang";
            this.lbl_TinhTrang.Size = new System.Drawing.Size(104, 37);
            this.lbl_TinhTrang.TabIndex = 22;
            this.lbl_TinhTrang.Text = "Tình Trạng:";
            this.lbl_TinhTrang.UseMnemonic = false;
            // 
            // lbl_SoGhe
            // 
            this.lbl_SoGhe.AutoSize = true;
            this.lbl_SoGhe.BackColor = System.Drawing.Color.Transparent;
            this.lbl_SoGhe.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_SoGhe.Location = new System.Drawing.Point(29, 57);
            this.lbl_SoGhe.Name = "lbl_SoGhe";
            this.lbl_SoGhe.Size = new System.Drawing.Size(76, 37);
            this.lbl_SoGhe.TabIndex = 21;
            this.lbl_SoGhe.Text = "Số Ghế:";
            // 
            // lbl_LoaiXe
            // 
            this.lbl_LoaiXe.AutoSize = true;
            this.lbl_LoaiXe.BackColor = System.Drawing.Color.Transparent;
            this.lbl_LoaiXe.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_LoaiXe.Location = new System.Drawing.Point(463, 11);
            this.lbl_LoaiXe.Name = "lbl_LoaiXe";
            this.lbl_LoaiXe.Size = new System.Drawing.Size(78, 37);
            this.lbl_LoaiXe.TabIndex = 18;
            this.lbl_LoaiXe.Text = "Loại Xe:";
            // 
            // cmb_LoaiXe
            // 
            this.cmb_LoaiXe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_LoaiXe.Font = new System.Drawing.Font("Oswald", 14F);
            this.cmb_LoaiXe.FormattingEnabled = true;
            this.cmb_LoaiXe.Location = new System.Drawing.Point(547, 8);
            this.cmb_LoaiXe.Name = "cmb_LoaiXe";
            this.cmb_LoaiXe.Size = new System.Drawing.Size(241, 40);
            this.cmb_LoaiXe.TabIndex = 19;
            // 
            // lbl_BienSoXe
            // 
            this.lbl_BienSoXe.AutoSize = true;
            this.lbl_BienSoXe.BackColor = System.Drawing.Color.Transparent;
            this.lbl_BienSoXe.Font = new System.Drawing.Font("Oswald", 16F);
            this.lbl_BienSoXe.Location = new System.Drawing.Point(29, 11);
            this.lbl_BienSoXe.Name = "lbl_BienSoXe";
            this.lbl_BienSoXe.Size = new System.Drawing.Size(106, 37);
            this.lbl_BienSoXe.TabIndex = 16;
            this.lbl_BienSoXe.Text = "Biển Số Xe:";
            // 
            // pnl_Import
            // 
            this.pnl_Import.BackgroundImage = global::DoAn_LTWindows.Properties.Resources.mainbackground;
            this.pnl_Import.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl_Import.Controls.Add(this.txt_BienSoXe);
            this.pnl_Import.Controls.Add(this.nud_SoGhe);
            this.pnl_Import.Controls.Add(this.btn_Reset);
            this.pnl_Import.Controls.Add(this.btn_Delete);
            this.pnl_Import.Controls.Add(this.btn_Edit);
            this.pnl_Import.Controls.Add(this.btn_Save);
            this.pnl_Import.Controls.Add(this.btn_Find);
            this.pnl_Import.Controls.Add(this.cmb_TinhTrang);
            this.pnl_Import.Controls.Add(this.lbl_TinhTrang);
            this.pnl_Import.Controls.Add(this.lbl_SoGhe);
            this.pnl_Import.Controls.Add(this.lbl_LoaiXe);
            this.pnl_Import.Controls.Add(this.cmb_LoaiXe);
            this.pnl_Import.Controls.Add(this.lbl_BienSoXe);
            this.pnl_Import.Location = new System.Drawing.Point(88, 127);
            this.pnl_Import.Name = "pnl_Import";
            this.pnl_Import.Size = new System.Drawing.Size(816, 190);
            this.pnl_Import.TabIndex = 29;
            // 
            // txt_BienSoXe
            // 
            this.txt_BienSoXe.Font = new System.Drawing.Font("Oswald", 16F);
            this.txt_BienSoXe.Location = new System.Drawing.Point(141, 9);
            this.txt_BienSoXe.Name = "txt_BienSoXe";
            this.txt_BienSoXe.Size = new System.Drawing.Size(303, 39);
            this.txt_BienSoXe.TabIndex = 31;
            // 
            // nud_SoGhe
            // 
            this.nud_SoGhe.Font = new System.Drawing.Font("Oswald", 14F);
            this.nud_SoGhe.Location = new System.Drawing.Point(141, 58);
            this.nud_SoGhe.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_SoGhe.Name = "nud_SoGhe";
            this.nud_SoGhe.Size = new System.Drawing.Size(120, 35);
            this.nud_SoGhe.TabIndex = 30;
            this.nud_SoGhe.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Title.Font = new System.Drawing.Font("Oswald", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lbl_Title.Location = new System.Drawing.Point(398, 16);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(197, 63);
            this.lbl_Title.TabIndex = 26;
            this.lbl_Title.Text = "QUẢN LÝ XE";
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
            this.btn_Return.TabIndex = 66;
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
            // colMaXe
            // 
            this.colMaXe.DataPropertyName = "MaXe";
            this.colMaXe.HeaderText = "Mã Xe";
            this.colMaXe.Name = "colMaXe";
            this.colMaXe.ReadOnly = true;
            this.colMaXe.Width = 150;
            // 
            // colBienSo
            // 
            this.colBienSo.DataPropertyName = "BienSo";
            this.colBienSo.HeaderText = "Biển Số Xe";
            this.colBienSo.Name = "colBienSo";
            this.colBienSo.ReadOnly = true;
            this.colBienSo.Width = 170;
            // 
            // colLoaiXe
            // 
            this.colLoaiXe.DataPropertyName = "LoaiXe";
            this.colLoaiXe.HeaderText = "Loại Xe";
            this.colLoaiXe.Name = "colLoaiXe";
            this.colLoaiXe.ReadOnly = true;
            this.colLoaiXe.Width = 150;
            // 
            // colSoGhe
            // 
            this.colSoGhe.DataPropertyName = "SoGhe";
            this.colSoGhe.HeaderText = "Số Ghế";
            this.colSoGhe.Name = "colSoGhe";
            this.colSoGhe.ReadOnly = true;
            // 
            // colTinhTrang
            // 
            this.colTinhTrang.DataPropertyName = "TinhTrang";
            this.colTinhTrang.HeaderText = "Tình Trạng";
            this.colTinhTrang.Name = "colTinhTrang";
            this.colTinhTrang.ReadOnly = true;
            this.colTinhTrang.Width = 282;
            // 
            // ucQuanLyXe
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::DoAn_LTWindows.Properties.Resources.mainbackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btn_Return);
            this.Controls.Add(this.dgv_Xe);
            this.Controls.Add(this.btn_FindData);
            this.Controls.Add(this.txt_Find);
            this.Controls.Add(this.lbl_TimKiem);
            this.Controls.Add(this.pnl_Import);
            this.Controls.Add(this.lbl_Title);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Oswald", 14F);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MaximumSize = new System.Drawing.Size(992, 623);
            this.MinimumSize = new System.Drawing.Size(992, 623);
            this.Name = "ucQuanLyXe";
            this.Size = new System.Drawing.Size(992, 623);
            this.Load += new System.EventHandler(this.ucQuanLyXe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Xe)).EndInit();
            this.pnl_Import.ResumeLayout(false);
            this.pnl_Import.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_SoGhe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Xe;
        private System.Windows.Forms.Button btn_FindData;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Find;
        private System.Windows.Forms.ComboBox cmb_TinhTrang;
        private System.Windows.Forms.TextBox txt_Find;
        private System.Windows.Forms.Label lbl_TimKiem;
        private System.Windows.Forms.Label lbl_TinhTrang;
        private System.Windows.Forms.Label lbl_SoGhe;
        private System.Windows.Forms.Label lbl_LoaiXe;
        private System.Windows.Forms.ComboBox cmb_LoaiXe;
        private System.Windows.Forms.Label lbl_BienSoXe;
        private System.Windows.Forms.Panel pnl_Import;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.NumericUpDown nud_SoGhe;
        private System.Windows.Forms.TextBox txt_BienSoXe;
        private System.Windows.Forms.Button btn_Return;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaXe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBienSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiXe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoGhe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTinhTrang;
    }
}
