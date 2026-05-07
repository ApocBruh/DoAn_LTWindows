using DoAn_LTWindows.BUS;
using DoAn_LTWindows.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel; // Khai báo thư viện Excel

namespace DoAn_LTWindows.Forms.Operations
{
    public partial class ucBaoCaoDoanhThu : UserControl
    {
        private BaoCaoDoanhThuBUS baoCaoBUS = new BaoCaoDoanhThuBUS();

        public ucBaoCaoDoanhThu()
        {
            InitializeComponent();

            dgv_DoanhThu.AutoGenerateColumns = false;

            // Hiệu ứng nút bấm (Giữ nguyên của bạn)
            btn_ExportExcel.MouseDown += (s, e) => { btn_ExportExcel.BackgroundImage = Properties.Resources._75pxbtn1_c; };
            btn_ExportExcel.MouseUp += (s, e) => { btn_ExportExcel.BackgroundImage = Properties.Resources._75pxbtn1; };
            btn_ThongKe.MouseDown += (s, e) => { btn_ThongKe.BackgroundImage = Properties.Resources._75pxbtn1_c; };
            btn_ThongKe.MouseUp += (s, e) => { btn_ThongKe.BackgroundImage = Properties.Resources._75pxbtn1; };
            btn_TongSoLieuThongKe.MouseDown += (s, e) => { btn_TongSoLieuThongKe.BackgroundImage = Properties.Resources._75pxbtn1_c; };
            btn_TongSoLieuThongKe.MouseUp += (s, e) => { btn_TongSoLieuThongKe.BackgroundImage = Properties.Resources._75pxbtn1; };
            btn_Return.MouseDown += (s, e) => { btn_Return.BackgroundImage = Properties.Resources._75pxbtn1_c; };
            btn_Return.MouseUp += (s, e) => { btn_Return.BackgroundImage = Properties.Resources._75pxbtn1; };
        }

        private void ucBaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            dtp_FromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtp_ToDate.Value = today;

            // THÊM
            LoadComboBoxTuyen();

            btn_ThongKe_Click(null, null);

            dgv_DoanhThu.DefaultCellStyle.ForeColor = Color.Black;
            dgv_DoanhThu.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                // THÊM
                int maTuyen = 0; // Mặc định là 0 (Tất cả)
                if (cmb_Tuyem.SelectedValue != null)
                {
                    int.TryParse(cmb_Tuyem.SelectedValue.ToString(), out maTuyen);
                }

                // Gọi BUS để lấy dữ liệu (BUS sẽ tự động kiểm tra lỗi ngày tháng)
                List<BaoCaoDoanhThuDTO> list = baoCaoBUS.LayBaoCaoDoanhThu(dtp_FromDate.Value.Date, dtp_ToDate.Value.Date, maTuyen);

                dgv_DoanhThu.DataSource = list;
                dgv_DoanhThu.ClearSelection();
            }
            catch (Exception ex)
            {
                // Hứng lỗi (ví dụ như chọn ngày sai) từ BUS gửi lên
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgv_DoanhThu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_DoanhThu.Columns[e.ColumnIndex].Name == "colSTT" && e.RowIndex >= 0)
            {
                e.Value = e.RowIndex + 1;
            }
            if (dgv_DoanhThu.Columns[e.ColumnIndex].DataPropertyName == "GiaVe" && e.Value != null)
            {
                e.Value = Convert.ToDecimal(e.Value).ToString("N0") + " đ";
                e.FormattingApplied = true;
            }
            if (dgv_DoanhThu.Columns[e.ColumnIndex].DataPropertyName == "NgayGiaoDich" && e.Value != null)
            {
                e.Value = Convert.ToDateTime(e.Value).ToString("dd/MM/yyyy HH:mm");
                e.FormattingApplied = true;
            }
        }

        private void btn_TongSoLieuThongKe_Click(object sender, EventArgs e)
        {
            Panel pnlParent = (Panel)this.Parent;
            if (pnlParent != null)
            {
                pnlParent.Controls.Clear();
                ucTongSoLieuThongKe uc = new ucTongSoLieuThongKe(dtp_FromDate.Value.Date, dtp_ToDate.Value.Date);
                uc.Dock = DockStyle.Fill;
                pnlParent.Controls.Add(uc);
            }
        }

        private void btn_ExportExcel_Click(object sender, EventArgs e)
        {
            if (dgv_DoanhThu.Rows.Count == 0) return;
            try
            {
                Excel.Application excelApp = new Excel.Application();
                excelApp.Workbooks.Add();
                Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

                // Lấy Header
                for (int i = 1; i < dgv_DoanhThu.Columns.Count + 1; i++)
                {
                    workSheet.Cells[1, i] = dgv_DoanhThu.Columns[i - 1].HeaderText;
                }

                // Lấy Dữ liệu
                for (int i = 0; i < dgv_DoanhThu.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv_DoanhThu.Columns.Count; j++)
                    {
                        workSheet.Cells[i + 2, j + 1] = dgv_DoanhThu.Rows[i].Cells[j].Value?.ToString();
                    }
                }
                excelApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KiemTraNgayHopLe(object sender, EventArgs e)
        {
            if (dtp_FromDate.Value.Date > dtp_ToDate.Value.Date)
            {
                MessageBox.Show("Bạn không thể chọn 'Từ Ngày' lớn hơn 'Đến Ngày'!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtp_ToDate.Value = dtp_FromDate.Value;
            }
        }

        private void btn_Return_Click(object sender, EventArgs e)
        {
            Panel pnlParent = (Panel)this.Parent;
            if (pnlParent != null)
            {
                pnlParent.Controls.Clear();
            }
        }

        // THÊM
        private void LoadComboBoxTuyen()
        {
            try
            {
                DoAn_LTWindows.BUS.TuyenXeBUS tuyenBus = new DoAn_LTWindows.BUS.TuyenXeBUS();
                var listTuyen = tuyenBus.LayDanhSachTuyen(); 

                DoAn_LTWindows.DTO.TuyenXeDTO tatCa = new DoAn_LTWindows.DTO.TuyenXeDTO();
                tatCa.MaTuyen = 0; 
                tatCa.TenTuyen = "Tất cả";

                listTuyen.Insert(0, tatCa);

                cmb_Tuyem.DataSource = listTuyen;
                cmb_Tuyem.DisplayMember = "TenTuyen";
                cmb_Tuyem.ValueMember = "MaTuyen";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách tuyến: " + ex.Message);
            }
        }
    }
}
