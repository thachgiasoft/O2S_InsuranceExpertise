using O2S_InsuranceExpertise.Model.Models;
using O2S_InsuranceExpertise.Model.Models.Xml_917.XMLDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_InsuranceExpertise.Server.Process.TieuChiProcess_Server
{
    public class TieuChiProcess_XML1
    {
        //TC1 - Sai lý do vào viện
        public TieuChiGiamDinhLoi_XML1DTO TC1_SaiLyDoVaoVien(int _MA_LYDO_VVIEN)
        {
            TieuChiGiamDinhLoi_XML1DTO result = new TieuChiGiamDinhLoi_XML1DTO();
            try
            {
                if (_MA_LYDO_VVIEN != 1 && _MA_LYDO_VVIEN != 2 && _MA_LYDO_VVIEN != 3)
                {
                    result.LYDO_VIPHAM = "Sai lý do vào viện";
                    result.LOAI_CANH_BAO = DanhSachThongBao.CANH_BAO;
                }
                else if (_MA_LYDO_VVIEN == 0)
                {
                    result.LYDO_VIPHAM = DanhSachThongBao.THIEU_TRUONG_DU_LIEU_BAT_BUOC;
                    result.GHI_CHU = "Thiếu lý do vào viện";
                    result.LOAI_CANH_BAO = DanhSachThongBao.CANH_BAO;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC10;TC11;TC12;TC12;TC15;TC16;TC19;TC20;TC21;TC22;TC23
        /*TC10 - Thẻ hết giá trị sử dụng
         * TC11 - Thẻ hết giá trị sử dụng (so với dữ liệu TST)
         * TC13 - Thẻ hết hạn khi chưa ra viện (so với dữ liệu TST)
         * TC15 - Thời gian điều trị không nằm trong hạn thẻ (so với dữ liệu TST)
         * TC16 - KCB khi chưa đến hạn thẻ (so với dữ liệu xml)
         * TC12 - KCB khi chưa đến hạn thẻ (so với dữ liệu TST)
         * TC19 -  Mã thẻ không có dữ liệu thẻ
         * TC20 - Thẻ sai họ tên
         * TC21 - Thẻ sai ngày sinh
         * TC22 - Thẻ sai giới tính
         * TC23 - Thẻ sai nơi đăng ký khám chữa bệnh ban đầu
         */
        public TieuChiGiamDinhLoi_XML1DTO TCGop8_KiemTraThongTuyen(TheBHYTCheckThongTuyenDTO _checkThongTuyenFilter)
        {
            TieuChiGiamDinhLoi_XML1DTO result = new TieuChiGiamDinhLoi_XML1DTO();
            try
            {           
                LayThongTinChoPortal laythongtin = new LayThongTinChoPortal();
                laythongtin.GetTaiKhoanvaTokenPortal();
                _checkThongTuyenFilter.username = GlobalStore.UserName_GDBHYT;
                _checkThongTuyenFilter.password = GlobalStore.Password_GDBHYT;
                _checkThongTuyenFilter.token = GlobalStore.tokenSession.APIKey.access_token;
                _checkThongTuyenFilter.id_token = GlobalStore.tokenSession.APIKey.id_token;
                KetQuaCheckThongTuyen_ExtendDTO ketquaCheck = new KetQuaCheckThongTuyen_ExtendDTO();

                CheckThongTuyenProcess checkthongtuyen = new CheckThongTuyenProcess();
                ketquaCheck = checkthongtuyen.CheckTungTheBHYT_CongBHYT(_checkThongTuyenFilter);
                result.LYDO_VIPHAM = ketquaCheck.tenKetQua;
                switch (ketquaCheck.maKetQua)
                {
                    case "01":
                        {
                            result.LYDO_VIPHAM = "Thẻ hết giá trị sử dụng";
                            result.LOAI_CANH_BAO = DanhSachThongBao.XUAT_TOAN;
                            result.MA_THE = "GT_THE_DEN";
                            break;
                        }
                    case "02":
                        {
                            result.LYDO_VIPHAM = "KCB khi chưa đến hạn thẻ (so với dữ liệu TST)";
                            result.LOAI_CANH_BAO = DanhSachThongBao.CANH_BAO;
                            result.MA_THE = "NGAY_VAO";
                            break;
                        }
                    case "03":
                        {
                            result.LYDO_VIPHAM = "Hết hạn thẻ khi chưa ra viện (so với dữ liệu TST)";
                            result.LOAI_CANH_BAO = DanhSachThongBao.XUAT_TOAN;
                            result.MA_THE = "GT_THE_DEN";
                            break;
                        }
                    case "04":
                        {
                            result.LYDO_VIPHAM = "Thẻ có giá trị khi đang nằm viện";
                            result.LOAI_CANH_BAO = DanhSachThongBao.CANH_BAO;
                            result.MA_THE = "GT_THE_TU";
                            break;
                        }
                    case "05":
                        {
                            result.LYDO_VIPHAM = "Mã thẻ không có trong dữ liệu thẻ";
                            result.LOAI_CANH_BAO = DanhSachThongBao.CANH_BAO;
                            result.MA_THE = "MA_THE";
                            break;
                        }
                    case "06":
                        {
                            result.LYDO_VIPHAM = "Thẻ sai họ tên";
                            result.LOAI_CANH_BAO = DanhSachThongBao.CANH_BAO;
                            result.MA_THE = "HO_TEN";
                            break;
                        }
                    case "07":
                        {
                            result.LYDO_VIPHAM = "Thẻ sai ngày sinh";
                            result.LOAI_CANH_BAO = DanhSachThongBao.CANH_BAO;
                            result.MA_THE = "NGAY_SINH";
                            break;
                        }
                    case "08":
                        {
                            result.LYDO_VIPHAM = "Thẻ sai giới tính";
                            result.LOAI_CANH_BAO = DanhSachThongBao.CANH_BAO;
                            result.MA_THE = "GIOI_TINH";
                            break;
                        }
                    case "09":
                        {
                            result.LYDO_VIPHAM = "Thẻ sai nơi đăng ký KCB ban đầu";
                            result.LOAI_CANH_BAO = DanhSachThongBao.CANH_BAO;
                            result.MA_THE = "MA_DKBD";
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC17 - Thẻ hết hạn khi chưa ra viện
        //TC18 - Thẻ có giá trị sau ngày vào viện
        public TieuChiGiamDinhLoi_XML1DTO TCRV_TGDTKhongNamTrongHanThe(long _NGAY_VAO, long _NGAY_RA, long _GT_THE_TU, long _GT_THE_DEN)
        {
            TieuChiGiamDinhLoi_XML1DTO result = new TieuChiGiamDinhLoi_XML1DTO();
            try
            {
                long _ngayvao = Common.TypeConvert.TypeConvertParse.ToInt64(_NGAY_VAO.ToString().Substring(0, 8));
                long _ngayra = Common.TypeConvert.TypeConvertParse.ToInt64(_NGAY_RA.ToString().Substring(0, 8));
                if (_ngayra > _GT_THE_DEN)
                {
                    result.LYDO_VIPHAM = "Thẻ hết hạn khi chưa ra viện";
                    result.LOAI_CANH_BAO = DanhSachThongBao.CANH_BAO;
                }
                if (_ngayvao < _GT_THE_TU)
                {
                    result.LYDO_VIPHAM = "Thẻ có giá trị sau ngày vào viện";
                    result.LOAI_CANH_BAO = DanhSachThongBao.XUAT_TOAN;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC24  TC41 - Ve ty le thanh toan
        public TieuChiGiamDinhLoi_XML1DTO TC24_TC41_TheCoGiaTriSauNgayVaoVien(TinhMucHuongBHYTDTO _TINH_MUC_HUONG)
        {
            TieuChiGiamDinhLoi_XML1DTO result = new TieuChiGiamDinhLoi_XML1DTO();
            try
            {
                //TODO
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC42 - Mức hưởng bằng 0 (Không được thanh toán BHYT)
        public TieuChiGiamDinhLoi_XML1DTO TC42_MucHuongBangKhong(int _MUC_HUONG)
        {
            TieuChiGiamDinhLoi_XML1DTO result = new TieuChiGiamDinhLoi_XML1DTO();
            try
            {
                if (_MUC_HUONG == 0)
                {
                    result.LYDO_VIPHAM = "Mức hưởng bằng 0 (Không được thanh toán BHYT)";
                    result.LOAI_CANH_BAO = DanhSachThongBao.XUAT_TOAN;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC74 - Thanh toán tiền giường vượt quá số ngày quy định
        public TieuChiGiamDinhLoi_XML1DTO TC74_GiuongVuotQuaSoNgayQuyDinh(decimal _SO_NGAY_DTRI, List<XML3PlusDTO> _lstXML3)
        {
            TieuChiGiamDinhLoi_XML1DTO result = new TieuChiGiamDinhLoi_XML1DTO();
            try
            {
                decimal _tongngaygiuong = 0;
                foreach (var item in _lstXML3)
                {
                    _tongngaygiuong += item.SO_LUONG ?? 0;
                }
                if (_tongngaygiuong > _SO_NGAY_DTRI)
                {
                    result.LYDO_VIPHAM = "Thanh toán tiền giường vượt quá số ngày quy định";
                    result.LOAI_CANH_BAO = DanhSachThongBao.CANH_BAO;
                    result.GHI_CHU = "Số lượng ngày giường chỉ định cho bệnh nhân là: "+_tongngaygiuong;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }
    }
}
