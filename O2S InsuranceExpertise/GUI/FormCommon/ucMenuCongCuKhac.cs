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
    public partial class ucMenuCongCuKhac : UserControl
    {
        #region Declaration
        public string CurrentTabPage { get; set; }
        public int SelectedTabPageIndex { get; set; }
        internal frmMain frmMain;

        // khai báo 1 hàm delegate
        public delegate void GetString(string thoigian);
        // khai báo 1 kiểu hàm delegate
        public GetString MyGetData;

        //Delegate Thoat khoi Cua so Main
        public delegate void ExitFormMain(bool exit_frmmain);
        // khai báo 1 kiểu hàm delegate
        public ExitFormMain ExitFormMain_Data;
        private bool hienthi_btnTroVe = false;


        #endregion
        public ucMenuCongCuKhac()
        {
            InitializeComponent();
        }
        public ucMenuCongCuKhac(bool _hienthi_btnTroVe)
        {
            InitializeComponent();
            this.hienthi_btnTroVe = _hienthi_btnTroVe;
        }

        #region Load
        private void ucHoSoBenhAn_Load(object sender, EventArgs e)
        {
            try
            {
                KiemTraEnable_ChucNang();
                LoadControl_KiemTraThongTuyen();
                MyGetData("Công cụ khác - Kiểm tra thông tuyến");
                EnableAndDisableControl();
                CongCuKhac_LoadDanhSachBaoCao();
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
                xtraTab_KiemTraThongTuyen.Visible = Base.CheckPermission.ChkPerModule("TOOL_10");
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void LoadControl_KiemTraThongTuyen()
        {
            try
            {
                if (xtraTab_KiemTraThongTuyen.Visible)
                {
                    panel_NoiDung.Controls.Clear();
                    ucCheckThongTuyenThuCong uchienthi = new ucCheckThongTuyenThuCong();
                    uchienthi.Dock = System.Windows.Forms.DockStyle.Fill;
                    panel_NoiDung.Controls.Add(uchienthi);
                }
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
                panel_btnTroVe.Visible = hienthi_btnTroVe;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void CongCuKhac_LoadDanhSachBaoCao()
        {
            try
            {
                List<DTO.classPermission> lstBaoCao_CongCuKhac = Base.SessionLogin.SessionLstPhanQuyenNguoiDung.Where(o=>o.permissiontype==3 && o.tabMenuId==5).OrderBy(u=>u.permissioncode).ToList();
                gridControlDSBaoCao.DataSource = lstBaoCao_CongCuKhac;
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
                    TabControlProcess.TabCreating(xtraTabControlCongCuKhac, code, name, note, ucControlActive);
                    ucControlActive.Show();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }


        #endregion

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            try
            {
                frmMain = new frmMain();
                ExitFormMain_Data(false);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
