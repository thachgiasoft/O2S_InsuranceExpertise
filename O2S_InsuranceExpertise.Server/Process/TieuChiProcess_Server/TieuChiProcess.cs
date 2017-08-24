using AutoMapper;
using O2S_InsuranceExpertise.Model.Models;
using O2S_InsuranceExpertise.Model.Models.GiamDinh;
using O2S_InsuranceExpertise.Model.Models.Xml_917.XMLDTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_InsuranceExpertise.Server.Process.TieuChiProcess_Server
{
    public class TieuChiProcess
    {
        public GiamDinhLoiDTO TieuChiProcess_HSBA(XML_HOSODTO _XMLHoSo_KiemTra)
        {
            GiamDinhLoiDTO result = new GiamDinhLoiDTO();
            try
            {
                //khai bao
                List<GiamDinhLoi_XML1DTO> lstLoi_XML1 = new List<GiamDinhLoi_XML1DTO>();
                List<GiamDinhLoi_DVKTDTO> lstLoi_DVKT = new List<GiamDinhLoi_DVKTDTO>();
                TieuChiProcess_XML1 process_xml1 = new TieuChiProcess_XML1();
                TieuChiProcess_DVKT process_dvkt = new TieuChiProcess_DVKT();

                //XMl1
                foreach (var item_xml1 in GlobalStore.lstTheFileXML1Global)
                {
                    Mapper.Initialize(cfg => cfg.CreateMap<Model.Models.TheFileXMLDTO, GiamDinhLoi_XML1DTO>());
                    GiamDinhLoi_XML1DTO _xmloi_XML1 = AutoMapper.Mapper.Map<Model.Models.TheFileXMLDTO, GiamDinhLoi_XML1DTO>(item_xml1);
                    _xmloi_XML1.LOAI_XML = "XML1";
                    lstLoi_XML1.Add(_xmloi_XML1);
                }
                //Check Thong tuyen
                TheBHYTCheckThongTuyenDTO _checkThongTuyenFilter = new TheBHYTCheckThongTuyenDTO();
                _checkThongTuyenFilter.maThe = _XMLHoSo_KiemTra.MA_THE;
                _checkThongTuyenFilter.hoTen = _XMLHoSo_KiemTra.HO_TEN;
                _checkThongTuyenFilter.ngaySinh = _XMLHoSo_KiemTra.NGAY_SINH_DATE;
                _checkThongTuyenFilter.gioiTinh = _XMLHoSo_KiemTra.GIOI_TINH ?? 1;
                _checkThongTuyenFilter.ngayBD = _XMLHoSo_KiemTra.GT_THE_TU_DATE;//DD/MM/YYYY
                _checkThongTuyenFilter.ngayKT = _XMLHoSo_KiemTra.GT_THE_DEN_DATE;
                _checkThongTuyenFilter.maCSKCB = _XMLHoSo_KiemTra.MA_THE;

                TieuChiGiamDinhLoi_XML1DTO _ketquaThongtuyen = process_xml1.TCGop8_KiemTraThongTuyen(_checkThongTuyenFilter);

                foreach (var item_loixml1 in lstLoi_XML1)
                {
                    switch (item_loixml1.MA_THE)
                    {
                        case "MA_LK":
                            {
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.MA_LK;
                                break;
                            }
                        case "STT":
                            {
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.STT;
                                break;
                            }
                        case "MA_BN":
                            {
                                //TODO: Check độ dài, kiểu dữ liệu, trường bắt buộc, giá trị trong phạm vi
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.MA_BN;
                                break;
                            }
                        case "HO_TEN":
                            {
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.HO_TEN;
                                if (_ketquaThongtuyen.MA_THE == "HO_TEN")
                                {
                                    item_loixml1.LYDO_VIPHAM = _ketquaThongtuyen.LYDO_VIPHAM;
                                    item_loixml1.LOAI_CANH_BAO = _ketquaThongtuyen.LOAI_CANH_BAO;
                                    item_loixml1.GHI_CHU = _ketquaThongtuyen.GHI_CHU;
                                }
                                break;
                            }
                        case "NGAY_SINH":
                            {
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.NGAY_SINH_DATE;
                                if (_ketquaThongtuyen.MA_THE == "NGAY_SINH")
                                {
                                    item_loixml1.LYDO_VIPHAM = _ketquaThongtuyen.LYDO_VIPHAM;
                                    item_loixml1.LOAI_CANH_BAO = _ketquaThongtuyen.LOAI_CANH_BAO;
                                    item_loixml1.GHI_CHU = _ketquaThongtuyen.GHI_CHU;
                                }
                                break;
                            }
                        case "GIOI_TINH":
                            {
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.GIOI_TINH_TEN;
                                if (_ketquaThongtuyen.MA_THE == "GIOI_TINH")
                                {
                                    item_loixml1.LYDO_VIPHAM = _ketquaThongtuyen.LYDO_VIPHAM;
                                    item_loixml1.LOAI_CANH_BAO = _ketquaThongtuyen.LOAI_CANH_BAO;
                                    item_loixml1.GHI_CHU = _ketquaThongtuyen.GHI_CHU;
                                }
                                break;
                            }
                        case "DIA_CHI":
                            {
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.DIA_CHI;
                                break;
                            }
                        case "MA_THE":
                            {
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.MA_THE;
                                if (_ketquaThongtuyen.MA_THE == "MA_THE")
                                {
                                    item_loixml1.LYDO_VIPHAM = _ketquaThongtuyen.LYDO_VIPHAM;
                                    item_loixml1.LOAI_CANH_BAO = _ketquaThongtuyen.LOAI_CANH_BAO;
                                    item_loixml1.GHI_CHU = _ketquaThongtuyen.GHI_CHU;
                                }
                                break;
                            }
                        case "MA_DKBD":
                            {
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.MA_DKBD;
                                if (_ketquaThongtuyen.MA_THE == "MA_DKBD")
                                {
                                    item_loixml1.LYDO_VIPHAM = _ketquaThongtuyen.LYDO_VIPHAM;
                                    item_loixml1.LOAI_CANH_BAO = _ketquaThongtuyen.LOAI_CANH_BAO;
                                    item_loixml1.GHI_CHU = _ketquaThongtuyen.GHI_CHU;
                                }
                                break;
                            }
                        case "GT_THE_TU":
                            {
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.GT_THE_TU_DATE;
                                if (_ketquaThongtuyen.MA_THE == "GT_THE_TU")
                                {
                                    item_loixml1.LYDO_VIPHAM = _ketquaThongtuyen.LYDO_VIPHAM;
                                    item_loixml1.LOAI_CANH_BAO = _ketquaThongtuyen.LOAI_CANH_BAO;
                                    item_loixml1.GHI_CHU = _ketquaThongtuyen.GHI_CHU;
                                }
                                break;
                            }
                        case "GT_THE_DEN":
                            {
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.GT_THE_DEN_DATE;
                                if (_ketquaThongtuyen.MA_THE == "GT_THE_DEN")
                                {
                                    item_loixml1.LYDO_VIPHAM = _ketquaThongtuyen.LYDO_VIPHAM;
                                    item_loixml1.LOAI_CANH_BAO = _ketquaThongtuyen.LOAI_CANH_BAO;
                                    item_loixml1.GHI_CHU = _ketquaThongtuyen.GHI_CHU;
                                }
                                break;
                            }
                        case "TEN_BENH":
                            {
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.TEN_BENH;
                                break;
                            }
                        case "MA_BENH":
                            {
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.MA_BENH;
                                break;
                            }
                        case "MA_BENHKHAC":
                            {
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.MA_BENHKHAC;
                                break;
                            }
                        case "MA_LYDO_VVIEN":
                            {
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.LYDO_VVIEN_TEN;
                                TieuChiGiamDinhLoi_XML1DTO _ketqua = process_xml1.TC1_SaiLyDoVaoVien(_XMLHoSo_KiemTra.MA_LYDO_VVIEN ?? 0);
                                item_loixml1.LYDO_VIPHAM = _ketqua.LYDO_VIPHAM;
                                item_loixml1.LOAI_CANH_BAO = _ketqua.LOAI_CANH_BAO;
                                item_loixml1.GHI_CHU = _ketqua.GHI_CHU;
                                break;
                            }
                        case "MA_NOI_CHUYEN":
                            {
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.MA_NOI_CHUYEN;
                                break;
                            }
                        case "MA_TAI_NAN":
                            {
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.TAI_NAN_TEN;
                                break;
                            }
                        case "NGAY_VAO":
                            {
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.NGAY_VAO_DATE;
                                TieuChiGiamDinhLoi_XML1DTO _ketqua_tc1416 = process_xml1.TC16_KCBKhiChuaDenHanThe(_XMLHoSo_KiemTra.NGAY_VAO, _XMLHoSo_KiemTra.NGAY_RA, _XMLHoSo_KiemTra.GT_THE_TU, _XMLHoSo_KiemTra.GT_THE_DEN);

                                item_loixml1.LYDO_VIPHAM = _ketqua_tc1416.LYDO_VIPHAM;
                                item_loixml1.LOAI_CANH_BAO = _ketqua_tc1416.LOAI_CANH_BAO;
                                item_loixml1.GHI_CHU = _ketqua_tc1416.GHI_CHU;
                                break;
                            }
                        case "NGAY_RA":
                            {
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.NGAY_RA_DATE;
                                TieuChiGiamDinhLoi_XML1DTO _ketqua_tcrv = process_xml1.TCRV_TGDTKhongNamTrongHanThe(_XMLHoSo_KiemTra.NGAY_VAO, _XMLHoSo_KiemTra.NGAY_RA, _XMLHoSo_KiemTra.GT_THE_TU, _XMLHoSo_KiemTra.GT_THE_DEN);

                                item_loixml1.LYDO_VIPHAM = _ketqua_tcrv.LYDO_VIPHAM;
                                item_loixml1.LOAI_CANH_BAO = _ketqua_tcrv.LOAI_CANH_BAO;
                                item_loixml1.GHI_CHU = _ketqua_tcrv.GHI_CHU;
                                break;
                            }
                        case "SO_NGAY_DTRI":
                            {
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.SO_NGAY_DTRI.ToString();
                                break;
                            }
                        case "KET_QUA_DTRI":
                            {
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.KET_QUA_DTRI_TEN;
                                break;
                            }
                        case "TINH_TRANG_RV":
                            {
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.TINH_TRANG_RV_TEN;
                                break;
                            }
                        case "NGAY_TTOAN":
                            {
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.NGAY_TTOAN_DATE;
                                break;
                            }
                        case "MUC_HUONG":
                            {
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.MUC_HUONG.ToString();
                                TieuChiGiamDinhLoi_XML1DTO _ketqua = process_xml1.TC42_MucHuongBangKhong(_XMLHoSo_KiemTra.MUC_HUONG ?? 0);
                                item_loixml1.LYDO_VIPHAM = _ketqua.LYDO_VIPHAM;
                                item_loixml1.LOAI_CANH_BAO = _ketqua.LOAI_CANH_BAO;
                                item_loixml1.GHI_CHU = _ketqua.GHI_CHU;
                                break;
                            }
                        case "T_THUOC":
                            {
                                item_loixml1.GIA_TRI = Common.Number.NumberConvert.NumberToString(_XMLHoSo_KiemTra.T_THUOC ?? 0, 2);
                                break;
                            }
                        case "T_VTYT":
                            {
                                item_loixml1.GIA_TRI = Common.Number.NumberConvert.NumberToString(_XMLHoSo_KiemTra.T_VTYT ?? 0, 2);
                                break;
                            }
                        case "T_TONGCHI":
                            {
                                item_loixml1.GIA_TRI = Common.Number.NumberConvert.NumberToString(_XMLHoSo_KiemTra.T_TONGCHI ?? 0, 2);
                                TinhMucHuongBHYTDTO _TINH_MUC_HUONG = new TinhMucHuongBHYTDTO();
                                //TODO
                                TieuChiGiamDinhLoi_XML1DTO _ketqua = process_xml1.TC24_TC41_TheCoGiaTriSauNgayVaoVien(_TINH_MUC_HUONG);
                                item_loixml1.LYDO_VIPHAM = _ketqua.LYDO_VIPHAM;
                                item_loixml1.LOAI_CANH_BAO = _ketqua.LOAI_CANH_BAO;
                                item_loixml1.GHI_CHU = _ketqua.GHI_CHU;
                                break;
                            }
                        case "T_BNTT":
                            {
                                item_loixml1.GIA_TRI = Common.Number.NumberConvert.NumberToString(_XMLHoSo_KiemTra.T_BNTT ?? 0, 2);
                                break;
                            }
                        case "T_BHTT":
                            {
                                item_loixml1.GIA_TRI = Common.Number.NumberConvert.NumberToString(_XMLHoSo_KiemTra.T_BHTT ?? 0, 2);
                                break;
                            }
                        case "T_NGUONKHAC":
                            {
                                item_loixml1.GIA_TRI = Common.Number.NumberConvert.NumberToString(_XMLHoSo_KiemTra.T_NGUONKHAC ?? 0, 2);
                                break;
                            }
                        case "T_NGOAIDS":
                            {
                                item_loixml1.GIA_TRI = Common.Number.NumberConvert.NumberToString(_XMLHoSo_KiemTra.T_NGOAIDS ?? 0, 2);
                                break;
                            }
                        case "NAM_QT":
                            {
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.NAM_QT.ToString();
                                break;
                            }
                        case "THANG_QT":
                            {
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.THANG_QT.ToString();
                                break;
                            }
                        case "MA_LOAI_KCB":
                            {
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.LOAI_KCB_TEN;
                                break;
                            }
                        case "MA_KHOA":
                            {
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.MA_KHOA;
                                break;
                            }
                        case "MA_CSKCB":
                            {
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.MA_CSKCB.ToString();
                                break;
                            }
                        case "MA_KHUVUC":
                            {
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.MA_KHUVUC;
                                break;
                            }
                        case "MA_PTTT_QT":
                            {
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.MA_PTTT_QT;
                                break;
                            }
                        case "CAN_NANG":
                            {
                                item_loixml1.GIA_TRI = _XMLHoSo_KiemTra.CAN_NANG;
                                break;
                            }
                        default:
                            break;
                    }
                }

                //XML2,3 _ Dich vu ky thuat = Thuoc
                foreach (var item_xml2 in _XMLHoSo_KiemTra.lstXML2)
                {
                    GiamDinhLoi_DVKTDTO _gdloithuoc = process_dvkt.GiamDinhLoi_XML2(item_xml2);
                    lstLoi_DVKT.Add(_gdloithuoc);
                }
                foreach (var item_xml3 in _XMLHoSo_KiemTra.lstXML3)
                {
                    GiamDinhLoi_DVKTDTO _gdloidv = process_dvkt.GiamDinhLoi_XML3(item_xml3);
                    lstLoi_DVKT.Add(_gdloidv);
                }

                //Gan vao result
                result.lstGiamDinhLoiXML1 = new List<GiamDinhLoi_XML1DTO>();
                result.lstGiamDinhLoiXML1 = lstLoi_XML1;
                result.lstGiamDinhLoiDVKT = new List<GiamDinhLoi_DVKTDTO>();
                result.lstGiamDinhLoiDVKT = lstLoi_DVKT;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }
    }
}
