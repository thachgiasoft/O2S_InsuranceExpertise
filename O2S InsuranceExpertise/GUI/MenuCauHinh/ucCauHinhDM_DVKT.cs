using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using Aspose.Cells;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace O2S_InsuranceExpertise.GUI.MenuCauHinh
{
    public partial class ucCauHinhDM_DVKT : UserControl
    {
        private DAL.ConnectDatabase condb = new DAL.ConnectDatabase();
        private string worksheetName = "Sheet";

        public ucCauHinhDM_DVKT()
        {
            InitializeComponent();
        }

        #region Load
        private void ucCauHinhDM_DVKT_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDanhMucDichVu();
                EnableAndDisableControl();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadDanhMucDichVu()
        {
            try
            {
                string sql_getdmdv = "";
                DataTable dataDMDV = condb.GetDataTable_HSBA(sql_getdmdv);
                gridControlDichVu.DataSource = dataDMDV;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void EnableAndDisableControl()
        {
            try
            {
                btnLuuLai.Enabled = false;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }


        #endregion

        private void btnNhapTuExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialogSelect.ShowDialog() == DialogResult.OK)
                {
                    SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
                    Workbook workbook = new Workbook(openFileDialogSelect.FileName);
                    Worksheet worksheet = workbook.Worksheets[worksheetName];
                    DataTable data_Excel = worksheet.Cells.ExportDataTable(0, 0, worksheet.Cells.MaxDataRow, worksheet.Cells.MaxDataColumn + 1, true);
                    if (data_Excel != null)
                    {
                        gridViewDichVu.BestFitColumns();
                        gridControlDichVu.DataSource = data_Excel;
                    }
                    else
                    {
                        gridControlDichVu.DataSource = null;

                        Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao("File excel sai định dạng cấu trúc!");
                        frmthongbao.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
                //SplashScreenManager.CloseForm();
            }
            SplashScreenManager.CloseForm();
        }

        private void gridViewDichVu_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (e.RowHandle == view.FocusedRowHandle)
                {
                    e.Appearance.BackColor = Color.LightGreen;
                    e.Appearance.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
    }
}
