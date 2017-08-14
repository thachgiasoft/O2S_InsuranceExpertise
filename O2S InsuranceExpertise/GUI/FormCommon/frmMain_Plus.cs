using O2S_InsuranceExpertise.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;

namespace O2S_InsuranceExpertise.GUI.FormCommon
{
    public partial class frmMain : Form
    {
        private void KiemTraPhanQuyenNguoiDung()
        {
            try
            {
                List<DTO.classPermission> SessionLstPhanQuyen_TabMenuCauHinh = Base.SessionLogin.SessionLstPhanQuyenNguoiDung.Where(o => o.tabMenuId == 2).OrderBy(o => o.permissioncode).ToList();
                List<DTO.classPermission> SessionLstPhanQuyen_TabMenuGDXML = Base.SessionLogin.SessionLstPhanQuyenNguoiDung.Where(o => o.tabMenuId == 3).OrderBy(o => o.permissioncode).ToList();
                List<DTO.classPermission> SessionLstPhanQuyen_TabMenuGDHSBA = Base.SessionLogin.SessionLstPhanQuyenNguoiDung.Where(o => o.tabMenuId == 4).OrderBy(o => o.permissioncode).ToList();
                List<DTO.classPermission> SessionLstPhanQuyen_TabMenuCCKhac = Base.SessionLogin.SessionLstPhanQuyenNguoiDung.Where(o => o.tabMenuId == 5).OrderBy(o => o.permissioncode).ToList();

                if (SessionLstPhanQuyen_TabMenuCauHinh != null && SessionLstPhanQuyen_TabMenuCauHinh.Count > 0)
                {
                    tabMenuCauHinh.PageVisible = true;
                }
                else
                {
                    tabMenuCauHinh.PageVisible = false;
                }

                if (SessionLstPhanQuyen_TabMenuGDXML != null && SessionLstPhanQuyen_TabMenuGDXML.Count > 0)
                {
                    tabMenuGiamDinhXML.PageVisible = true;
                }
                else
                {
                    tabMenuGiamDinhXML.PageVisible = false;
                }

                if (SessionLstPhanQuyen_TabMenuGDHSBA != null && SessionLstPhanQuyen_TabMenuGDHSBA.Count > 0)
                {
                    tabMenuGiamDinhHSBA.PageVisible = true;
                }
                else
                {
                    tabMenuGiamDinhHSBA.PageVisible = false;
                }

                if (SessionLstPhanQuyen_TabMenuCCKhac != null && SessionLstPhanQuyen_TabMenuCCKhac.Count > 0)
                {
                    tabMenuCongCuKhac.PageVisible = true;
                }
                else
                {
                    tabMenuCongCuKhac.PageVisible = false;
                }

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
                throw;
            }
        }

        private void EnableAndDisableTabChucNang(bool enabledisable)
        {
            try
            {
                tabMenuCauHinh.PageVisible = enabledisable;
                tabMenuGiamDinhXML.PageVisible = enabledisable;
                tabMenuGiamDinhHSBA.PageVisible = enabledisable;
                tabMenuCongCuKhac.PageVisible = enabledisable;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
                throw;
            }
        }

    }
}
