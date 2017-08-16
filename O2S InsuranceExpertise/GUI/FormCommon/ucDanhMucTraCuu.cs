using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DevExpress.XtraGrid.Views.Grid;
using O2S_InsuranceExpertise.Base;
using O2S_InsuranceExpertise.BUS;
using O2S_InsuranceExpertise.GUI.MenuCongCuKhac;

namespace O2S_InsuranceExpertise.GUI.FormCommon
{
    public partial class ucDanhMucTraCuu : UserControl
    {
        #region Declaration
        public string CurrentTabPage { get; set; }
        public int SelectedTabPageIndex { get; set; }
        internal frmMain frmMain;

        // khai báo 1 hàm delegate
        public delegate void GetString(string thoigian);
        // khai báo 1 kiểu hàm delegate
        public GetString MyGetData;

        ////Delegate Thoat khoi Cua so Main
        //public delegate void ExitFormMain(bool exit_frmmain);
        //// khai báo 1 kiểu hàm delegate
        //public ExitFormMain ExitFormMain_Data;


        #endregion
        public ucDanhMucTraCuu()
        {
            InitializeComponent();
        }
        public ucDanhMucTraCuu(bool _hienthi_btnTroVe)
        {
            InitializeComponent();
        }

        #region Load
        private void ucHoSoBenhAn_Load(object sender, EventArgs e)
        {
            try
            {
                //KiemTraEnable_ChucNang();
                MyGetData("Danh mục tra cứu - Danh sách");
                DanhMucTraCuu_LoadDanhSach();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void KiemTraEnable_ChucNang()
        {
            try
            {
                xtraTab_DanhMuc.Visible = Base.CheckPermission.ChkPerModule("TOOL_10");
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void DanhMucTraCuu_LoadDanhSach()
        {
            try
            {
                List<DTO.classPermission> lstBaoCao_DanhMucTraCuu = Base.SessionLogin.SessionLstPhanQuyenNguoiDung.Where(o=>o.permissiontype==3 && o.tabMenuId==6).OrderBy(u=>u.permissioncode).ToList();
                gridControlDSBaoCao.DataSource = lstBaoCao_DanhMucTraCuu;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

        #region Tabcontrol function
        //Dong tab
        private void xtraTabControlCongCuKhac_CloseButtonClick(object sender, EventArgs e)
        {
            try
            {
                XtraTabControl xtab = (XtraTabControl)sender;
                int i = xtab.SelectedTabPageIndex;
                DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs arg = e as DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs;
                xtab.TabPages.Remove((arg.Page as XtraTabPage));
                xtab.SelectedTabPageIndex = i - 1;
                //(arg.Page as XtraTabPage).PageVisible = false;
                System.GC.Collect();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void xtraTabControlCongCuKhac_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            try
            {
                frmMain = new frmMain();
                this.CurrentTabPage = e.Page.Name;
                XtraTabControl xtab = new XtraTabControl();
                xtab = (XtraTabControl)sender;
                if (xtab != null)
                {
                    this.SelectedTabPageIndex = xtab.SelectedTabPageIndex;
                    //delegate - thong tin chuc nang
                    if (MyGetData != null)
                    {// tại đây gọi nó
                        MyGetData(xtab.TabPages[xtab.SelectedTabPageIndex].Tooltip);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        #endregion

        #region Bao Cao
        private void gridViewDSBaoCao_RowCellStyle(object sender, RowCellStyleEventArgs e)
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
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void gridViewDSBaoCao_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column == gridDSBCColumeStt)
                {
                    e.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void gridViewDSBaoCao_DoubleClick(object sender, EventArgs e)
        {
            UserControl ucControlActive = new UserControl();
            try
            {
                if (gridViewDSBaoCao.RowCount > 0)
                {
                    var rowHandle = gridViewDSBaoCao.FocusedRowHandle;
                    string code = gridViewDSBaoCao.GetRowCellValue(rowHandle, "permissioncode").ToString();
                    string name = gridViewDSBaoCao.GetRowCellValue(rowHandle, "permissionname").ToString();
                    string note = gridViewDSBaoCao.GetRowCellValue(rowHandle, "permissionnote").ToString();

                    //Chon ucControl
                    ucControlActive = TabControlProcess.SelectUCControlActive(code);
                    TabControlProcess.TabCreating(xtraTabControlDMTraCuu, code, name, note, ucControlActive);
                    ucControlActive.Show();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }


        #endregion

    }
}
