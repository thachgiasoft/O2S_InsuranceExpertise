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
                UserControl ucControlActive = new O2S_InsuranceExpertise.GUI.MenuGiamDinhXML.ucKiemTraGiamDinh(_lstXMLHoSo_KiemTra);
                //UserControl ucControlActive = BUS.TabControlProcess.SelectUCControlActive("KTGD");
                BUS.TabControlProcess.TabCreating(xtraTabControlGiamDinhXML, "GD_KTGD", "Kiểm tra giám định BHYT", "Kiểm tra giám định BHYT", ucControlActive);
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
