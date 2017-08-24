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
    public partial class ucMenuCauHinh : UserControl
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
        public ucMenuCauHinh()
        {
            InitializeComponent();
        }
        public ucMenuCauHinh(bool _hienthi_btnTroVe)
        {
            InitializeComponent();
        }

        #region Load
        private void ucHoSoBenhAn_Load(object sender, EventArgs e)
        {
            try
            {
                KiemTraEnable_ChucNang();
                //LoadControl_KiemTraThongTuyen();
                MyGetData("Cấu hình - Cấu hình danh mục");
                //EnableAndDisableControl();
                //CongCuKhac_LoadDanhSachBaoCao();
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
                xtraTab_CHDanhMuc.Visible = O2S_InsuranceExpertise.Base.CheckPermission.ChkPerModule("TOOL_01");
                xtraTab_CHTieuChiGiamDinh.PageVisible = O2S_InsuranceExpertise.Base.CheckPermission.ChkPerModule("TOOL_02");
                xtraTab_CHTheXML.PageVisible = O2S_InsuranceExpertise.Base.CheckPermission.ChkPerModule("TOOL_03");
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
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


        #region TAB Danh Muc
        private void navBarItemDM_DVKT_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                panelCauHinhNoiDung.Controls.Clear();
                GUI.MenuCauHinh.ucCauHinhDM_DVKT uchienthi = new MenuCauHinh.ucCauHinhDM_DVKT();
                uchienthi.Dock = System.Windows.Forms.DockStyle.Fill;
                panelCauHinhNoiDung.Controls.Add(uchienthi);
                MyGetData("Cấu hình - Danh mục dịch vụ kỹ thuật");
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void navBarItemDM_Thuoc_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                panelCauHinhNoiDung.Controls.Clear();
                GUI.MenuCauHinh.ucCauHinhDM_Thuoc uchienthi = new MenuCauHinh.ucCauHinhDM_Thuoc();
                uchienthi.Dock = System.Windows.Forms.DockStyle.Fill;
                panelCauHinhNoiDung.Controls.Add(uchienthi);
                MyGetData("Cấu hình - Danh mục thuốc");
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void navBarItemDM_VatTu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                panelCauHinhNoiDung.Controls.Clear();
                GUI.MenuCauHinh.ucCauHinhDM_VatTu uchienthi = new MenuCauHinh.ucCauHinhDM_VatTu();
                uchienthi.Dock = System.Windows.Forms.DockStyle.Fill;
                panelCauHinhNoiDung.Controls.Add(uchienthi);
                MyGetData("Cấu hình - Danh mục vật tư");
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void navBarItemDM_NgayGiuong_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                panelCauHinhNoiDung.Controls.Clear();
                GUI.MenuCauHinh.ucCauHinhDM_Giuong uchienthi = new MenuCauHinh.ucCauHinhDM_Giuong();
                uchienthi.Dock = System.Windows.Forms.DockStyle.Fill;
                panelCauHinhNoiDung.Controls.Add(uchienthi);
                MyGetData("Cấu hình - Danh mục ngày giường");
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

        #region TAB The XML
        private void navBarItemTheXML_XML1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                panelControlTheFileXML.Controls.Clear();
                GUI.MenuCauHinh.ucCauHinhTheXML_XML uchienthi = new MenuCauHinh.ucCauHinhTheXML_XML(1);
                uchienthi.Dock = System.Windows.Forms.DockStyle.Fill;
                panelControlTheFileXML.Controls.Add(uchienthi);
                MyGetData("Thẻ file XML - XML1 (tổng hợp)");
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void navBarItemTheXML_XML2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelControlTheFileXML.Controls.Clear();
            GUI.MenuCauHinh.ucCauHinhTheXML_XML uchienthi = new MenuCauHinh.ucCauHinhTheXML_XML(2);
            uchienthi.Dock = System.Windows.Forms.DockStyle.Fill;
            panelControlTheFileXML.Controls.Add(uchienthi);
            MyGetData("Thẻ file XML - XML2 (thuốc)");
        }

        private void navBarItemTheXML_XML3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelControlTheFileXML.Controls.Clear();
            GUI.MenuCauHinh.ucCauHinhTheXML_XML uchienthi = new MenuCauHinh.ucCauHinhTheXML_XML(3);
            uchienthi.Dock = System.Windows.Forms.DockStyle.Fill;
            panelControlTheFileXML.Controls.Add(uchienthi);
            MyGetData("Thẻ file XML - XML3 (DVKT + vật tư)");
        }
        private void navBarItemTheXML_XML4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelControlTheFileXML.Controls.Clear();
            GUI.MenuCauHinh.ucCauHinhTheXML_XML uchienthi = new MenuCauHinh.ucCauHinhTheXML_XML(4);
            uchienthi.Dock = System.Windows.Forms.DockStyle.Fill;
            panelControlTheFileXML.Controls.Add(uchienthi);
            MyGetData("Thẻ file XML - XML4 (cận lâm sàng)");
        }

        private void navBarItemTheXML_XML5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelControlTheFileXML.Controls.Clear();
            GUI.MenuCauHinh.ucCauHinhTheXML_XML uchienthi = new MenuCauHinh.ucCauHinhTheXML_XML(5);
            uchienthi.Dock = System.Windows.Forms.DockStyle.Fill;
            panelControlTheFileXML.Controls.Add(uchienthi);
            MyGetData("Thẻ file XML - XML5 (chi tiết diễn biến)");
        }
        #endregion


    }
}
