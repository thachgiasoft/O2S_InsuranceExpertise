using O2S_InsuranceExpertise.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_InsuranceExpertise.GUI.MenuGiamDinhXML.TieuChiProcess_Server
{
    public class TieuChiProcess_XML1
    {
        //TC1 - Sai lý do vào viện
        public TieuChiGiamDinhLoi_XML1DTO TC1_SaiLyDoVaoVien(string _MA_LYDO_VVIEN)
        {
            TieuChiGiamDinhLoi_XML1DTO result = new TieuChiGiamDinhLoi_XML1DTO();
            try
            {
                if (_MA_LYDO_VVIEN != "1" && _MA_LYDO_VVIEN != "2" && _MA_LYDO_VVIEN != "3")
                {
                    result.LYDO_VIPHAM = "Sai lý do vào viện";
                    result.LOAI_CANH_BAO = DanhSachThongBao.CANH_BAO;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC10;TC11;TC12;TC12;TC15;TC19;TC20;TC21;TC22;TC23
        /*TC10 - Thẻ hết giá trị sử dụng
         * TC11 - Thẻ hết giá trị sử dụng (so với dữ liệu TST)
         * TC13 - Thẻ hết hạn khi chưa ra viện (so với dữ liệu TST)
         * TC15 - Thời gian điều trị không nằm trong hạn thẻ (so với dữ liệu TST)
         * TC12 - KCB khi chưa đến hạn thẻ (so với dữ liệu TST)
         * TC19 -  Mã thẻ không có dữ liệu thẻ
         * TC20 - Thẻ sai họ tên
         * TC21 - Thẻ sai ngày sinh
         * TC22 - Thẻ sai giới tính
         * TC23 - Thẻ sai nơi đăng ký khám chữa bệnh ban đầu
         */
        public List<TieuChiGiamDinhLoi_XML1DTO> TCGop8_KiemTraThongTuyen(TheBHYTCheckThongTuyenDTO _checkThongTuyenFilter)
        {
            List<TieuChiGiamDinhLoi_XML1DTO> result = new List<TieuChiGiamDinhLoi_XML1DTO>();
            try
            {
                //Check thong tuyen
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
                long _ngayra =Common.TypeConvert.TypeConvertParse.ToInt64( _NGAY_RA.ToString().Substring(0,8));
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

        //TC16 - KCB khi chưa đến hạn thẻ (so với dữ liệu xml)
        public TieuChiGiamDinhLoi_XML1DTO TC16_KCBKhiChuaDenHanThe(long _NGAY_VAO, long _NGAY_RA, long _GT_THE_TU, long _GT_THE_DEN)
        {
            TieuChiGiamDinhLoi_XML1DTO result = new TieuChiGiamDinhLoi_XML1DTO();
            try
            {
                long _ngayvao = Common.TypeConvert.TypeConvertParse.ToInt64(_NGAY_VAO.ToString().Substring(0, 8));
                if (_GT_THE_TU > _ngayvao)
                {
                    result.LYDO_VIPHAM = "KCB khi chưa đến hạn thẻ";
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
                //Check thong tuyen
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

    }
}
