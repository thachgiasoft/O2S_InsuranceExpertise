using O2S_InsuranceExpertise.Model.Models;
using O2S_InsuranceExpertise.Model.Models.Xml_917.XMLDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_InsuranceExpertise.GUI.MenuGiamDinhXML.TieuChiProcess_Server
{
    public class TieuChiProcess_DVKT
    {
        //TC43 - Giá thuốc thanh toán > giá kê khai, kê khai lại
        public TieuChiGiamDinhLoi_DVKTDTO TC43_GiaThuocTTLonHonGiaKeKhai(decimal _DON_GIA)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC44 - Giá thuốc thanh toán > giá thuốc được phê duyệt
        public TieuChiGiamDinhLoi_DVKTDTO TC44_GiaThuocTTLonHonGiaPheDuyet(decimal _DON_GIA)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC45 - Thuốc ngoài danh mục TT40, TT05
        public TieuChiGiamDinhLoi_DVKTDTO TC45_ThuocNgoaDMTT40TT05(string _MA_THUOC)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC46 - Thuốc ngoài danh mục sử dụng tại BV
        public TieuChiGiamDinhLoi_DVKTDTO TC46_ThuocNgoaiDMSDTaiBV(string _TEN_THUOC, string _DON_VI_TINH, string _HAM_LUONG, string _DUONG_DUNG, string _LIEU_DUNG, string _SO_DANG_KY, decimal _DON_GIA)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC47 - VTYT không thanh toán riêng (TT27)
        public TieuChiGiamDinhLoi_DVKTDTO TC47_VTYTKhongThanhToanRieng(string _MA_VAT_TU, string _TEN_DICH_VU, string _DON_VI_TINH, decimal _DON_GIA)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC48 - VTYT ngoài danh mục sử dụng tại BV
        public TieuChiGiamDinhLoi_DVKTDTO TC48_VTYTNgoaiDMSDTaiBV(string _MA_VAT_TU, string _TEN_DICH_VU, string _DON_VI_TINH, decimal _DON_GIA)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC49 - Thuốc sai tên so với danh mục sử dụng tại BV
        public TieuChiGiamDinhLoi_DVKTDTO TC49_ThuocSaiTenVoiDMTaiBV(string _MA_THUOC, string _TEN_THUOC)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC50 - Thuốc sai đường dùng so với danh mục sử dụng tại BV
        public TieuChiGiamDinhLoi_DVKTDTO TC50_ThuocSaiDuongDungVoiDMTaiBV(string _MA_THUOC, string _DUONG_DUNG)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC51 - VTYT sai tên so với danh mục được thực hiện
        public TieuChiGiamDinhLoi_DVKTDTO TC51_VTYTSaiTenVoiDMTaiBV(string _MA_VAT_TU, string _TEN_DICH_VU)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC52 - Thuốc sai hàm lượng so với danh mục sử dụng tại BV
        public TieuChiGiamDinhLoi_DVKTDTO TC52_ThuocSaiHamLuongVoiDMTaiBV(string _MA_THUOC, string _HAM_LUONG)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC53 - Máu có Mã sai quy định
        public TieuChiGiamDinhLoi_DVKTDTO TC53_MauSaiMaVoiTT05(string _MA_THUOC, string _TEN_THUOC)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC55 - Máu vượt quá giá tối đa
        public TieuChiGiamDinhLoi_DVKTDTO TC55_MauVuotQuaGiaToiDa(string _MA_THUOC, decimal _DON_GIA)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC60 - Thuốc sai mã nhóm với danh mục sử dụng tại BV
        public TieuChiGiamDinhLoi_DVKTDTO TC60_ThuocSaiMaNhomVoiDMTaiBV(string _MA_THUOC, string _MA_NHOM)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC61 - VTYT sai mã nhóm với danh mục sử dụng tại BV
        public TieuChiGiamDinhLoi_DVKTDTO TC61_VTYTSaiMaNhomVoiDMTaiBV(string _MA_VAT_TU, string _MA_NHOM)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC62 - DVKT sai tên so với danh mục được thực hiện
        public TieuChiGiamDinhLoi_DVKTDTO TC62_DVKTSaiTenVoiDM(string _MA_DICH_VU, string _TEN_DICH_VU)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC63 - DVKT không nằm trong bảng giá được phê duyệt
        public TieuChiGiamDinhLoi_DVKTDTO TC63_DVKTKhongNamTrongBangGiaPheDuyet(string _MA_DICH_VU, decimal _DON_GIA)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC64 - DVKT không nằm trong danh mục được thực hiện
        public TieuChiGiamDinhLoi_DVKTDTO TC64_DVKTKhongNamTrongDMThucHien(string _MA_DICH_VU, string _TEN_DICH_VU)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC65 - DVKT giá cao hơn giá được phê duyệt
        public TieuChiGiamDinhLoi_DVKTDTO TC65_DVKTGiaCaohonGiaPheDuyet(string _MA_DICH_VU, decimal _DON_GIA)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC66 - DVKT có mã không nằm trong danh mục tương đương
        public TieuChiGiamDinhLoi_DVKTDTO TC66_DVKTMaKhongNamTrongDMTuongDuong(string _MA_DICH_VU)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC67 - DVKT có tên không nằm trong danh mục quy định (TT43,50)
        public TieuChiGiamDinhLoi_DVKTDTO TC67_DVKTTenKhongNamTrongDMTT43TT50(string _MA_DICH_VU, string _TEN_DICH_VU)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC68 - DVKT sai mã nhóm với danh mục được thực hiện
        public TieuChiGiamDinhLoi_DVKTDTO TC68_DVKTSaiMaNhomVoiDMThucHien(string _MA_DICH_VU, string _MA_NHOM)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC69 - Sử dụng Thuốc đã có trong cơ cấu giá DVKT(thuốc tê, mê, chỉ định cùng thời gian thực hiện PTTT)
        public TieuChiGiamDinhLoi_DVKTDTO TC69_DVKTSaiMaNhomVoiDMThucHien(string _MA_THUOC,string _TEN_THUOC, string _DON_VI_TINH, string _HAM_LUONG, string _DUONG_DUNG, string _LIEU_DUNG, string _SO_DANG_KY, string _DON_GIA)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC71 - Sử dụng thuốc thanh toán sai tỷ lệ
        public TieuChiGiamDinhLoi_DVKTDTO TC71_ThuocThanhToanSaiTyLe(string _MA_THUOC, string _TYLE_TT)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC72 - Sử dụng VTYT toán sai tỷ lệ
        public TieuChiGiamDinhLoi_DVKTDTO TC72_VTYTThanhToanSaiTyLe(string _MA_VAT_TU, string _TYLE_TT)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC74 - Thanh toán tiền giường vượt quá số ngày quy định
        public TieuChiGiamDinhLoi_DVKTDTO TC74_GiuongVuotQuaSoNgayQuyDinh(string _SO_NGAY_DTRI_XML1, string _SO_NGAY_DTRI_XML3)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC75 - Hồ sơ nội trú thanh toán trên 1 lần tiền khám
        public TieuChiGiamDinhLoi_DVKTDTO TC75_ThanhToanTren1LanTienKham(string _MA_LOAI_KCB, string _SO_LUONG_KHAMBENH)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC76 - Khám bệnh đề nghị tiền khám trên 1 chuyên khoa sai quy định
        public TieuChiGiamDinhLoi_DVKTDTO TC76_KBDeNghiTienKhamTren1CKSaiQD(List<XML3PlusDTO> _lstXML3)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC77 - VTYT tính toán tỷ lệ áp trần
        public TieuChiGiamDinhLoi_DVKTDTO TC77_VTYTTinhToanTyLeApTran(string _MA_VAT_TU, string _DON_GIA)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC78 -VTYT đi kèm DVKT không tồn tại
        public TieuChiGiamDinhLoi_DVKTDTO TC78_VTYTDemDVKTKhongTonTai(string _MA_DICH_VU, string _MA_VAT_TU)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }





    }
}
