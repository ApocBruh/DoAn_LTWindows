namespace DoAn_LTWindows.Forms.Operations
{
    partial class ucChonTuyen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucChonTuyen));
            this.lbl_Title = new System.Windows.Forms.Label();
            this.btn_TXNoiThanh = new System.Windows.Forms.Button();
            this.btn_TXNgoaiThanh = new System.Windows.Forms.Button();
            this.btn_Return = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Title.Font = new System.Drawing.Font("Oswald", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lbl_Title.Location = new System.Drawing.Point(107, 16);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(779, 82);
            this.lbl_Title.TabIndex = 0;
            this.lbl_Title.Text = "CHỌN TUYẾN XE BẠN MUỐN THỰC HIỆN";
            // 
            // btn_TXNoiThanh
            // 
            this.btn_TXNoiThanh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_TXNoiThanh.BackgroundImage")));
            this.btn_TXNoiThanh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_TXNoiThanh.Font = new System.Drawing.Font("Oswald", 28F);
            this.btn_TXNoiThanh.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_TXNoiThanh.Location = new System.Drawing.Point(134, 130);
            this.btn_TXNoiThanh.Name = "btn_TXNoiThanh";
            this.btn_TXNoiThanh.Size = new System.Drawing.Size(300, 300);
            this.btn_TXNoiThanh.TabIndex = 1;
            this.btn_TXNoiThanh.Text = "TUYẾN XE\r\nNỘI THÀNH";
            this.btn_TXNoiThanh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_TXNoiThanh.UseVisualStyleBackColor = true;
            // 
            // btn_TXNgoaiThanh
            // 
            this.btn_TXNgoaiThanh.BackgroundImage = global::DoAn_LTWindows.Properties.Resources.choosebutton2;
            this.btn_TXNgoaiThanh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_TXNgoaiThanh.Font = new System.Drawing.Font("Oswald", 28F);
            this.btn_TXNgoaiThanh.Location = new System.Drawing.Point(559, 130);
            this.btn_TXNgoaiThanh.Name = "btn_TXNgoaiThanh";
            this.btn_TXNgoaiThanh.Size = new System.Drawing.Size(300, 300);
            this.btn_TXNgoaiThanh.TabIndex = 2;
            this.btn_TXNgoaiThanh.Text = "TUYẾN XE\r\nNGOẠI THÀNH";
            this.btn_TXNgoaiThanh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_TXNgoaiThanh.UseVisualStyleBackColor = true;
            // 
            // btn_Return
            // 
            this.btn_Return.BackColor = System.Drawing.Color.Transparent;
            this.btn_Return.BackgroundImage = global::DoAn_LTWindows.Properties.Resources._75pxbtn1;
            this.btn_Return.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Return.FlatAppearance.BorderSize = 0;
            this.btn_Return.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Return.Location = new System.Drawing.Point(348, 475);
            this.btn_Return.Name = "btn_Return";
            this.btn_Return.Size = new System.Drawing.Size(297, 70);
            this.btn_Return.TabIndex = 3;
            this.btn_Return.Text = "Quay Lại";
            this.btn_Return.UseVisualStyleBackColor = false;
            // 
            // ucChonTuyen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::DoAn_LTWindows.Properties.Resources.mainbackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btn_Return);
            this.Controls.Add(this.btn_TXNgoaiThanh);
            this.Controls.Add(this.btn_TXNoiThanh);
            this.Controls.Add(this.lbl_Title);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Oswald", 20.25F);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MaximumSize = new System.Drawing.Size(992, 623);
            this.MinimumSize = new System.Drawing.Size(992, 623);
            this.Name = "ucChonTuyen";
            this.Size = new System.Drawing.Size(992, 623);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Button btn_TXNoiThanh;
        private System.Windows.Forms.Button btn_TXNgoaiThanh;
        private System.Windows.Forms.Button btn_Return;
    }
}
