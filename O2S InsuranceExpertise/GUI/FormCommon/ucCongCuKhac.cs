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
using O2S_InsuranceExpertise.GUI.CheckThongTuyen;

namespace O2S_InsuranceExpertise.GUI.FormCommon
{
    public partial class ucCongCuKhac : UserControl
    {
        #region Declaration
        public string CurrentTabPage { get; set; }
        public int SelectedTabPageIndex { get; set; }
        internal frmMain frmMain;

        // khai báo 1 hàm delegate
        public delegate void GetString(string thoigian);
        // khai báo 1 kiểu hàm delegate
        public GetString MyGetData;

        #endregion
        public ucCongCuKhac()
        {
            InitializeComponent();
        }

        #region Load
        private void ucHoSoBenhAn_Load(object sender, EventArgs e)
        {
            try
            {
                KiemTraEnable_ChucNang();
                LoadControl_KiemTraThongTuyen();
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
            }
        }

        private void KiemTraEnable_ChucNang()
        {
            try
            {
               // xtraTab_KiemTraThongTuyen.Visible = Base.CheckPermission.ChkPerModule("TOOL_10");
                //xtraTab_BaoCao.Visible = Base.CheckPermission.ChkPerModule("DASHBOARD_02");
            }
            catch (Exception ex)
            {
                Base.Logging.Warn(ex);
            }
        }

        private void LoadControl_KiemTraThongTuyen()
        {
            try
            {
                if (xtraTab_KiemTraThongTuyen.Visible)
                {
                    xtraTab_KiemTraThongTuyen.Controls.Clear();
                    ucCheckThongTuyenThuCong uchienthi = new ucCheckThongTuyenThuCong();
                    uchienthi.Dock = System.Windows.Forms.DockStyle.Fill;
                    xtraTab_KiemTraThongTuyen.Controls.Add(uchienthi);
                }
            }
            catch (Exception ex)
            {
                O2S_InsuranceExpertise.Base.Logging.Warn(ex);
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
                Base.Logging.Warn(ex);
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
                Base.Logging.Warn(ex);
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
                Base.Logging.Warn(ex);
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
                Base.Logging.Warn(ex);
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
                Base.Logging.Error(ex);
            }
        }

        #endregion


    }
}
