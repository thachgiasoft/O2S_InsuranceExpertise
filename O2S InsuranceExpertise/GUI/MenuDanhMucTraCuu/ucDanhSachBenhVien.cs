using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;

namespace O2S_InsuranceExpertise.GUI.MenuDanhMucTraCuu
{
    public partial class ucDanhSachBenhVien : UserControl
    {
        DAL.ConnectDatabase condb = new DAL.ConnectDatabase();

        #region Load
        public ucDanhSachBenhVien()
        {
            InitializeComponent();
        }

        private void ucDanhSachBenhVien_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDanhSachBenhVien();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void LoadDanhSachBenhVien()
        {
            try
            {
                string sqldsbv = "select row_number () over (order by benhvienkcbbd) as stt, benhvienid, benhvienkcbbd, benhviencode, benhvienname, benhvienaddress,benhvienhang,benhvientuyen,ghichu from ie_benhvien;";
                DataView dataOption = new DataView(condb.GetDataTable_HSBA(sqldsbv));
                if (dataOption != null && dataOption.Count > 0)
                {
                    gridControlDSBenhVien.DataSource = dataOption;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        #endregion

        private void gridViewDSOption_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.LightGreen;
                e.Appearance.ForeColor = Color.Black;
            }
        }


    }
}
