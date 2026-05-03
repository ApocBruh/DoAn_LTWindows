namespace DoAn_LTWindows.Forms.Operations
{
    partial class ucLuaChonLichTrinh
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
            this.btn_QLTuyenXe = new System.Windows.Forms.Button();
            this.btn_QLChuyenXe = new System.Windows.Forms.Button();
            this.btn_QLXe = new System.Windows.Forms.Button();
            this.btn_Return = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Title.Font = new System.Drawing.Font("Oswald", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lbl_Title.Location = new System.Drawing.Point(137, 16);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(718, 63);
            this.lbl_Title.TabIndex = 1;
            this.lbl_Title.Text = "CHỌN LOẠI LỊCH TRÌNH BẠN MUỐN THỰC HIỆN";
            // 
            // btn_QLTuyenXe
            // 
            this.btn_QLTuyenXe.BackgroundImage = global::DoAn_LTWindows.Properties.Resources.choosebutton03;
            this.btn_QLTuyenXe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_QLTuyenXe.Font = new System.Drawing.Font("Oswald", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QLTuyenXe.Location = new System.Drawing.Point(46, 149);
            this.btn_QLTuyenXe.Name = "btn_QLTuyenXe";
            this.btn_QLTuyenXe.Size = new System.Drawing.Size(280, 280);
            this.btn_QLTuyenXe.TabIndex = 3;
            this.btn_QLTuyenXe.Text = "Quản Lý\r\nTuyến Xe";
            this.btn_QLTuyenXe.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_QLTuyenXe.UseVisualStyleBackColor = true;
            this.btn_QLTuyenXe.Click += new System.EventHandler(this.btn_QLTuyenXe_Click);
            // 
            // btn_QLChuyenXe
            // 
            this.btn_QLChuyenXe.BackgroundImage = global::DoAn_LTWindows.Properties.Resources.choosebutton02;
            this.btn_QLChuyenXe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_QLChuyenXe.Font = new System.Drawing.Font("Oswald", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QLChuyenXe.Location = new System.Drawing.Point(356, 149);
            this.btn_QLChuyenXe.Name = "btn_QLChuyenXe";
            this.btn_QLChuyenXe.Size = new System.Drawing.Size(280, 280);
            this.btn_QLChuyenXe.TabIndex = 4;
            this.btn_QLChuyenXe.Text = "Quản Lý\r\nChuyến Xe";
            this.btn_QLChuyenXe.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_QLChuyenXe.UseVisualStyleBackColor = true;
            this.btn_QLChuyenXe.Click += new System.EventHandler(this.btn_QLChuyenXe_Click);
            // 
            // btn_QLXe
            // 
            this.btn_QLXe.BackgroundImage = global::DoAn_LTWindows.Properties.Resources.choosebutton01;
            this.btn_QLXe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_QLXe.Font = new System.Drawing.Font("Oswald", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QLXe.Location = new System.Drawing.Point(666, 149);
            this.btn_QLXe.Name = "btn_QLXe";
            this.btn_QLXe.Size = new System.Drawing.Size(280, 280);
            this.btn_QLXe.TabIndex = 5;
            this.btn_QLXe.Text = "Quản Lý Xe";
            this.btn_QLXe.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_QLXe.UseVisualStyleBackColor = true;
            this.btn_QLXe.Click += new System.EventHandler(this.btn_QLXe_Click);
            // 
            // btn_Return
            // 
            this.btn_Return.BackColor = System.Drawing.Color.Transparent;
            this.btn_Return.BackgroundImage = global::DoAn_LTWindows.Properties.Resources._75pxbtn1;
            this.btn_Return.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Return.FlatAppearance.BorderSize = 0;
            this.btn_Return.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Return.Location = new System.Drawing.Point(348, 476);
            this.btn_Return.Name = "btn_Return";
            this.btn_Return.Size = new System.Drawing.Size(297, 70);
            this.btn_Return.TabIndex = 6;
            this.btn_Return.Text = "Quay Lại";
            this.btn_Return.UseVisualStyleBackColor = false;
            this.btn_Return.Click += new System.EventHandler(this.btn_Return_Click);
            // 
            // ucLuaChonLichTrinh
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::DoAn_LTWindows.Properties.Resources.mainbackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btn_Return);
            this.Controls.Add(this.btn_QLXe);
            this.Controls.Add(this.btn_QLChuyenXe);
            this.Controls.Add(this.btn_QLTuyenXe);
            this.Controls.Add(this.lbl_Title);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Oswald", 16F);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MaximumSize = new System.Drawing.Size(992, 623);
            this.MinimumSize = new System.Drawing.Size(992, 623);
            this.Name = "ucLuaChonLichTrinh";
            this.Size = new System.Drawing.Size(992, 623);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Button btn_QLTuyenXe;
        private System.Windows.Forms.Button btn_QLChuyenXe;
        private System.Windows.Forms.Button btn_QLXe;
        private System.Windows.Forms.Button btn_Return;
    }
}
