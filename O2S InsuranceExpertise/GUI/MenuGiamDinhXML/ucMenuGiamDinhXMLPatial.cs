using O2S_InsuranceExpertise.Model.Models.Xml_917.XMLDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O2S_InsuranceExpertise.GUI.FormCommon
{
    public partial class ucMenuGiamDinhXML : UserControl
    {
        #region Check Kiem tra

        private void CheckThongTuyenMotRow()
        {
            try
            {
                if (gridViewNoiDung.RowCount > 0)
                {
                    var rowHandle = gridViewNoiDung.FocusedRowHandle;
                    string _ma_lk = gridViewNoiDung.GetRowCellValue(rowHandle, "MA_LK").ToString();
                    XML_HOSODTO _XMLHoSo_KiemTra = this.lstXMLHoSo.Where(o => o.MA_LK == _ma_lk).FirstOrDefault();
                    Goi_KiemTraGiamDinh_ChiTiet(_XMLHoSo_KiemTra);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void CheckThongTuyenRowDangChon()
        {
            try
            {
                if (gridViewNoiDung.RowCount > 0)
                {
                    List<XML_HOSODTO> lstXMLHoSo_KiemTra = new List<XML_HOSODTO>();

                    foreach (var item_index in gridViewNoiDung.GetSelectedRows())
                    {
                        string _ma_lk = gridViewNoiDung.GetRowCellValue(item_index, "MA_LK").ToString();
                        var _xmlhoso = this.lstXMLHoSo.Where(o => o.MA_LK == _ma_lk).ToList();
                        lstXMLHoSo_KiemTra.AddRange(_xmlhoso);
                    }
                    Goi_KiemTraGiamDinh(lstXMLHoSo_KiemTra);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void CheckThongTuyenTatCaRowDangChon()
        {
            try
            {
                if (gridViewNoiDung.RowCount > 0)
                {
                    Goi_KiemTraGiamDinh(this.lstXMLHoSo);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void Goi_KiemTraGiamDinh(List<XML_HOSODTO> _lstXMLHoSo_KiemTra)
        {
            try
            {
                //Goi ucControl ucKiemTraGiamDinh
                //UserControl ucControlActive = new O2S_InsuranceExpertise.GUI.MenuGiamDinhXML.ucKiemTraGiamDinh(_lstXMLHoSo_KiemTra);
                O2S_InsuranceExpertise.GUI.MenuGiamDinhXML.ucKiemTraGiamDinh ucControlActive = new MenuGiamDinhXML.ucKiemTraGiamDinh(_lstXMLHoSo_KiemTra);
                BUS.TabControlProcess.TabCreatingRefresh(xtraTabControlGiamDinhXML, "GD_KTGD", "Kiểm tra giám định BHYT", "Giám định XML - Kiểm tra giám định BHYT", ucControlActive);
                ucControlActive.Show();
                //ucControlActive.Init();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void Goi_KiemTraGiamDinh_ChiTiet(XML_HOSODTO _XMLHoSo_KiemTra)
        {
            try
            {
                O2S_InsuranceExpertise.GUI.MenuGiamDinhXML.ucKiemTraGiamDinh_ChiTiet ucControlActive = new MenuGiamDinhXML.ucKiemTraGiamDinh_ChiTiet(_XMLHoSo_KiemTra);
                BUS.TabControlProcess.TabCreatingRefresh(xtraTabControlGiamDinhXML, "GD_KTGDCT", "Kiểm tra giám định chi tiết", "Giám định XML - Kiểm tra giám định BHYT chi tiết", ucControlActive);
                ucControlActive.Show();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        #endregion




    }
}
