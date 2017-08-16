using O2S_InsuranceExpertise.GUI.FormCommon.TabCaiDat;
using O2S_InsuranceExpertise.GUI.FormCommon.TabTrangChu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O2S_InsuranceExpertise.GUI.FormCommon
{
    public partial class ucTrangChu : UserControl
    {
        private void navBarItemLicense_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                panelCaiDatChiTiet.Controls.Clear();
                ucSettingLicense frm = new ucSettingLicense();
                frm.Dock = System.Windows.Forms.DockStyle.Fill;
                panelCaiDatChiTiet.Controls.Add(frm);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void navBarItemConnectDB_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                panelCaiDatChiTiet.Controls.Clear();
                ucSettingDatabase uchienthi = new ucSettingDatabase();
                uchienthi.Dock = System.Windows.Forms.DockStyle.Fill;
                panelCaiDatChiTiet.Controls.Add(uchienthi);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void navBarItemListNguoiDung_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                panelCaiDatChiTiet.Controls.Clear();
                ucQuanLyNguoiDung ucchon = new ucQuanLyNguoiDung();
                ucchon.Dock = System.Windows.Forms.DockStyle.Fill;
                panelCaiDatChiTiet.Controls.Add(ucchon);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void navBarItemListNhanVien_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                panelCaiDatChiTiet.Controls.Clear();
                ucDanhSachNhanVien ucchon = new ucDanhSachNhanVien();
                ucchon.Dock = System.Windows.Forms.DockStyle.Fill;
                panelCaiDatChiTiet.Controls.Add(ucchon);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void navBarItemListOption_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                panelCaiDatChiTiet.Controls.Clear();
                ucCauHinhHeThong ucchon = new ucCauHinhHeThong();
                ucchon.Dock = System.Windows.Forms.DockStyle.Fill;
                panelCaiDatChiTiet.Controls.Add(ucchon);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void navBarItemMaHoaGiaiMa_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                panelCaiDatChiTiet.Controls.Clear();
                ucMaHoaVaGiaiMa frmResult = new ucMaHoaVaGiaiMa();
                frmResult.Dock = System.Windows.Forms.DockStyle.Fill;
                panelCaiDatChiTiet.Controls.Add(frmResult);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void navBarItemNhatKySuKien_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                panelCaiDatChiTiet.Controls.Clear();
                ucMaHoaVaGiaiMa frmResult = new ucMaHoaVaGiaiMa();
                frmResult.Dock = System.Windows.Forms.DockStyle.Fill;
                panelCaiDatChiTiet.Controls.Add(frmResult);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void navBarItemQLMayTram_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                panelCaiDatChiTiet.Controls.Clear();
                ucMaHoaVaGiaiMa frmResult = new ucMaHoaVaGiaiMa();
                frmResult.Dock = System.Windows.Forms.DockStyle.Fill;
                panelCaiDatChiTiet.Controls.Add(frmResult);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void navBarItemListDVPTTT_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                panelCaiDatChiTiet.Controls.Clear();
                ucUpdateTemplateDVPTTT frmResult = new ucUpdateTemplateDVPTTT();
                frmResult.Dock = System.Windows.Forms.DockStyle.Fill;
                panelCaiDatChiTiet.Controls.Add(frmResult);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void navBarItemListDMBenhVien_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                panelCaiDatChiTiet.Controls.Clear();
                ucDanhSachBenhVien frmResult = new ucDanhSachBenhVien();
                frmResult.Dock = System.Windows.Forms.DockStyle.Fill;
                panelCaiDatChiTiet.Controls.Add(frmResult);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void navBarItemDMThuocHoiChan_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                //panelCaiDatChiTiet.Controls.Clear();
                //ucDanhMucHoiChanThuoc frmResult = new ucDanhMucHoiChanThuoc();
                //frmResult.Dock = System.Windows.Forms.DockStyle.Fill;
                //panelCaiDatChiTiet.Controls.Add(frmResult);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void navBarItemHoiChanPTTT_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                //panelCaiDatChiTiet.Controls.Clear();
                //ucDanhMucHoiChanPTTT frmResult = new ucDanhMucHoiChanPTTT();
                //frmResult.Dock = System.Windows.Forms.DockStyle.Fill;
                //panelCaiDatChiTiet.Controls.Add(frmResult);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void navBarItemHoiChanChuyenVien_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                //panelCaiDatChiTiet.Controls.Clear();
                //ucDanhMucBenhAn frmResult = new ucDanhMucBenhAn();
                //frmResult.Dock = System.Windows.Forms.DockStyle.Fill;
                //panelCaiDatChiTiet.Controls.Add(frmResult);
       

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void navBarItemDMDungChung_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                panelCaiDatChiTiet.Controls.Clear();
                ucDanhMucDungChung frmResult = new ucDanhMucDungChung();
                frmResult.Dock = System.Windows.Forms.DockStyle.Fill;
                panelCaiDatChiTiet.Controls.Add(frmResult);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void navBarItemTaoTemplateWord_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                FormCommon.frmTaoTemplateWord ffrmrom = new frmTaoTemplateWord();
                ffrmrom.ShowDialog();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
    }
}
