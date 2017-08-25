using AutoMapper;
using O2S_InsuranceExpertise.Model.Models;
using O2S_InsuranceExpertise.Model.Models.Xml_917.XMLDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_InsuranceExpertise.Server.Process.TieuChiProcess_Server
{
    public class TieuChiProcess_XML2
    {
        public GiamDinhLoi_DVKTDTO GiamDinhLoi_XML2(XML2PlusDTO _xml2Filter)
        {
            GiamDinhLoi_DVKTDTO result_LoiThuoc = new GiamDinhLoi_DVKTDTO();
            try
            {
                Mapper.Initialize(cfg => cfg.CreateMap<XML2PlusDTO, GiamDinhLoi_DVKTDTO>());
                result_LoiThuoc = AutoMapper.Mapper.Map<XML2PlusDTO, GiamDinhLoi_DVKTDTO>(_xml2Filter);
                result_LoiThuoc.LOAI_XML = "XML2";
                result_LoiThuoc.MA_DVKT = _xml2Filter.MA_THUOC;
                result_LoiThuoc.TEN_DVKT = _xml2Filter.TEN_THUOC;

                TieuChiGiamDinhLoi_DVKTDTO _ketqua_TC43 = TC43_GiaThuocTTLonHonGiaKeKhai(_xml2Filter);
                if (_ketqua_TC43.TRANG_THAI == 1)
                {
                    result_LoiThuoc.LYDO_VIPHAM += _ketqua_TC43;
                    result_LoiThuoc.DIEN_GIAI += _ketqua_TC43.DIEN_GIAI;
                    result_LoiThuoc.LOAI_CANH_BAO += _ketqua_TC43.LOAI_CANH_BAO;
                }
                TieuChiGiamDinhLoi_DVKTDTO _ketqua_TC44 = TC44_GiaThuocTTLonHonGiaPheDuyet(_xml2Filter);
                if (_ketqua_TC44.TRANG_THAI == 1)
                {
                    result_LoiThuoc.LYDO_VIPHAM += "\n" + _ketqua_TC44.LYDO_VIPHAM;
                    result_LoiThuoc.DIEN_GIAI += "\n" + _ketqua_TC44.DIEN_GIAI;
                    result_LoiThuoc.LOAI_CANH_BAO += _ketqua_TC44.LOAI_CANH_BAO;
                }
                TieuChiGiamDinhLoi_DVKTDTO _ketqua_TC45 = TC45_ThuocNgoaDMTT40TT05(_xml2Filter);
                if (_ketqua_TC45.TRANG_THAI == 1)
                {
                    result_LoiThuoc.LYDO_VIPHAM += "\n" + _ketqua_TC45.LYDO_VIPHAM;
                    result_LoiThuoc.DIEN_GIAI += "\n" + _ketqua_TC45.DIEN_GIAI;
                    result_LoiThuoc.LOAI_CANH_BAO += "\n" + _ketqua_TC45.LOAI_CANH_BAO;
                }
                TieuChiGiamDinhLoi_DVKTDTO _ketqua_TC46 = TC46_ThuocNgoaiDMSDTaiBV(_xml2Filter);
                if (_ketqua_TC46.TRANG_THAI == 1)
                {
                    result_LoiThuoc.LYDO_VIPHAM += "\n" + _ketqua_TC46.LYDO_VIPHAM;
                    result_LoiThuoc.DIEN_GIAI += "\n" + _ketqua_TC46.DIEN_GIAI;
                    result_LoiThuoc.LOAI_CANH_BAO += "\n" + _ketqua_TC46.LOAI_CANH_BAO;
                }
                TieuChiGiamDinhLoi_DVKTDTO _ketqua_TC49 = TC49_ThuocSaiTenVoiDMTaiBV(_xml2Filter);
                if (_ketqua_TC49.TRANG_THAI == 1)
                {
                    result_LoiThuoc.LYDO_VIPHAM += "\n" + _ketqua_TC49.LYDO_VIPHAM;
                    result_LoiThuoc.DIEN_GIAI += "\n" + _ketqua_TC49.DIEN_GIAI;
                    result_LoiThuoc.LOAI_CANH_BAO += "\n" + _ketqua_TC49.LOAI_CANH_BAO;
                }
                TieuChiGiamDinhLoi_DVKTDTO _ketqua_TC50 = TC50_ThuocSaiDuongDungVoiDMTaiBV(_xml2Filter);
                if (_ketqua_TC50.TRANG_THAI == 1)
                {
                    result_LoiThuoc.LYDO_VIPHAM += "\n" + _ketqua_TC50.LYDO_VIPHAM;
                    result_LoiThuoc.DIEN_GIAI += "\n" + _ketqua_TC50.DIEN_GIAI;
                    result_LoiThuoc.LOAI_CANH_BAO += "\n" + _ketqua_TC50.LOAI_CANH_BAO;
                }
                TieuChiGiamDinhLoi_DVKTDTO _ketqua_TC52 = TC52_ThuocSaiHamLuongVoiDMTaiBV(_xml2Filter);
                if (_ketqua_TC52.TRANG_THAI == 1)
                {
                    result_LoiThuoc.LYDO_VIPHAM += "\n" + _ketqua_TC52.LYDO_VIPHAM;
                    result_LoiThuoc.DIEN_GIAI += "\n" + _ketqua_TC52.DIEN_GIAI;
                    result_LoiThuoc.LOAI_CANH_BAO += "\n" + _ketqua_TC52.LOAI_CANH_BAO;
                }
                TieuChiGiamDinhLoi_DVKTDTO _ketqua_TC53 = TC53_MauSaiMaVoiTT05(_xml2Filter);
                if (_ketqua_TC53.TRANG_THAI == 1)
                {
                    result_LoiThuoc.LYDO_VIPHAM += "\n" + _ketqua_TC53.LYDO_VIPHAM;
                    result_LoiThuoc.DIEN_GIAI += "\n" + _ketqua_TC53.DIEN_GIAI;
                    result_LoiThuoc.LOAI_CANH_BAO += "\n" + _ketqua_TC53.LOAI_CANH_BAO;
                }
                TieuChiGiamDinhLoi_DVKTDTO _ketqua_TC55 = TC55_MauVuotQuaGiaToiDa(_xml2Filter);
                if (_ketqua_TC55.TRANG_THAI == 1)
                {
                    result_LoiThuoc.LYDO_VIPHAM += "\n" + _ketqua_TC55.LYDO_VIPHAM;
                    result_LoiThuoc.DIEN_GIAI += "\n" + _ketqua_TC55.DIEN_GIAI;
                    result_LoiThuoc.LOAI_CANH_BAO += "\n" + _ketqua_TC55.LOAI_CANH_BAO;
                }
                TieuChiGiamDinhLoi_DVKTDTO _ketqua_TC60 = TC60_ThuocSaiMaNhomVoiDMTaiBV(_xml2Filter);
                if (_ketqua_TC60.TRANG_THAI == 1)
                {
                    result_LoiThuoc.LYDO_VIPHAM += "\n" + _ketqua_TC60.LYDO_VIPHAM;
                    result_LoiThuoc.DIEN_GIAI += "\n" + _ketqua_TC60.DIEN_GIAI;
                    result_LoiThuoc.LOAI_CANH_BAO += "\n" + _ketqua_TC60.LOAI_CANH_BAO;
                }
                TieuChiGiamDinhLoi_DVKTDTO _ketqua_TC71 = TC71_ThuocThanhToanSaiTyLe(_xml2Filter);
                if (_ketqua_TC71.TRANG_THAI == 1)
                {
                    result_LoiThuoc.LYDO_VIPHAM += "\n" + _ketqua_TC71.LYDO_VIPHAM;
                    result_LoiThuoc.DIEN_GIAI += "\n" + _ketqua_TC71.DIEN_GIAI;
                    result_LoiThuoc.LOAI_CANH_BAO += "\n" + _ketqua_TC71.LOAI_CANH_BAO;
                }

                //--khong thay doi
                if (result_LoiThuoc.LOAI_CANH_BAO != null && result_LoiThuoc.LOAI_CANH_BAO.Contains(DanhSachThongBao.XUAT_TOAN))
                {
                    result_LoiThuoc.LOAI_CANH_BAO = DanhSachThongBao.XUAT_TOAN;
                }
                else if (result_LoiThuoc.LOAI_CANH_BAO != "" && result_LoiThuoc.LOAI_CANH_BAO != null && !result_LoiThuoc.LOAI_CANH_BAO.Contains(DanhSachThongBao.XUAT_TOAN))
                {
                    result_LoiThuoc.LOAI_CANH_BAO = DanhSachThongBao.CANH_BAO;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result_LoiThuoc;
        }

        #region Giam dinh tung tieu chi XML2

        //TC43 - Giá thuốc thanh toán > giá kê khai, kê khai lại
        private TieuChiGiamDinhLoi_DVKTDTO TC43_GiaThuocTTLonHonGiaKeKhai(XML2PlusDTO _xml2Filter)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {
                var _thuocTimKiem = GlobalStore.lstBenhVienPheDuyet_Thuoc.Where(o => o.MANHOM_9324.ToString() == _xml2Filter.MA_NHOM && o.MA_AX == _xml2Filter.MA_THUOC).ToList().OrderByDescending(p => p.DON_GIA).FirstOrDefault();
                if (_thuocTimKiem != null)
                {
                    if (_xml2Filter.DON_GIA > _thuocTimKiem.DON_GIA)
                    {
                        result.TRANG_THAI = 1;
                        result.LYDO_VIPHAM = "Giá thuốc thanh toán > giá kê khai, kê khai lại";
                        result.LOAI_CANH_BAO = DanhSachThongBao.XUAT_TOAN;
                        result.DIEN_GIAI = "Giá thuốc trong danh mục được phê duyệt là: " + _thuocTimKiem.DON_GIA;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC44 - Giá thuốc thanh toán > giá thuốc được phê duyệt
        private TieuChiGiamDinhLoi_DVKTDTO TC44_GiaThuocTTLonHonGiaPheDuyet(XML2PlusDTO _xml2Filter)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {
                var _thuocTimKiem = GlobalStore.lstBenhVienPheDuyet_Thuoc.Where(o => o.MANHOM_9324.ToString() == _xml2Filter.MA_NHOM && o.MA_AX == _xml2Filter.MA_THUOC).ToList().OrderByDescending(p => p.DON_GIA_TT).FirstOrDefault();
                if (_thuocTimKiem != null)
                {
                    if (_xml2Filter.DON_GIA > _thuocTimKiem.DON_GIA_TT)
                    {
                        result.TRANG_THAI = 1;
                        result.LYDO_VIPHAM = "Giá thuốc thanh toán > giá thuốc được phê duyệt";
                        result.LOAI_CANH_BAO = DanhSachThongBao.XUAT_TOAN;
                        result.DIEN_GIAI = "Giá thuốc trong danh mục được phê duyệt là: " + _thuocTimKiem.DON_GIA_TT;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC45 - Thuốc ngoài danh mục TT40, TT05
        private TieuChiGiamDinhLoi_DVKTDTO TC45_ThuocNgoaDMTT40TT05(XML2PlusDTO _xml2Filter)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {
                var _thuocTimKiem = GlobalStore.lstBenhVienPheDuyet_Thuoc.Where(o => o.MANHOM_9324.ToString() == _xml2Filter.MA_NHOM && o.MA_HOAT_CHAT == _xml2Filter.MA_THUOC).ToList();
                if (_thuocTimKiem == null || _thuocTimKiem.Count <= 0)
                {
                    result.TRANG_THAI = 1;
                    result.LYDO_VIPHAM = "Thuốc ngoài danh mục TT40, TT05";
                    result.LOAI_CANH_BAO = DanhSachThongBao.XUAT_TOAN;
                    result.DIEN_GIAI = "";
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC46 - Thuốc ngoài danh mục sử dụng tại BV
        private TieuChiGiamDinhLoi_DVKTDTO TC46_ThuocNgoaiDMSDTaiBV(XML2PlusDTO _xml2Filter)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {
                var _thuocTimKiem = GlobalStore.lstBenhVienPheDuyet_Thuoc.Where(o => o.MANHOM_9324.ToString() == _xml2Filter.MA_NHOM && o.MA_AX == _xml2Filter.MA_THUOC && o.TEN_THUOC.ToUpper().Trim() == _xml2Filter.TEN_THUOC.ToUpper().Trim() && o.DON_VI_TINH.ToUpper().Trim() == _xml2Filter.DON_VI_TINH.ToUpper().Trim() && o.HAM_LUONG.ToUpper().Trim() == _xml2Filter.HAM_LUONG.ToUpper().Trim() && o.MA_DUONG_DUNG.ToUpper().Trim() == _xml2Filter.DUONG_DUNG.ToUpper().Trim() && o.SO_DANG_KY.ToUpper().Trim() == _xml2Filter.SO_DANG_KY.ToUpper().Trim() && o.DON_GIA == _xml2Filter.DON_GIA).ToList();
                if (_thuocTimKiem == null || _thuocTimKiem.Count <= 0)
                {
                    result.TRANG_THAI = 1;
                    result.LYDO_VIPHAM = "Thuốc ngoài danh mục sử dụng tại BV";
                    result.LOAI_CANH_BAO = DanhSachThongBao.XUAT_TOAN;
                    result.DIEN_GIAI = "";
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC49 - Thuốc sai tên so với danh mục sử dụng tại BV
        private TieuChiGiamDinhLoi_DVKTDTO TC49_ThuocSaiTenVoiDMTaiBV(XML2PlusDTO _xml2Filter)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {
                var _thuocTimKiem = GlobalStore.lstBenhVienPheDuyet_Thuoc.Where(o => o.MANHOM_9324.ToString() == _xml2Filter.MA_NHOM && o.MA_AX == _xml2Filter.MA_THUOC && o.TEN_THUOC.ToUpper().Trim() == _xml2Filter.TEN_THUOC.ToUpper().Trim()).ToList();
                if (_thuocTimKiem == null || _thuocTimKiem.Count <= 0)
                {
                    result.TRANG_THAI = 1;
                    result.LYDO_VIPHAM = "Thuốc sai tên so với danh mục sử dụng tại BV";
                    result.LOAI_CANH_BAO = DanhSachThongBao.CANH_BAO;
                    result.DIEN_GIAI = "";
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC50 - Thuốc sai đường dùng so với danh mục sử dụng tại BV
        private TieuChiGiamDinhLoi_DVKTDTO TC50_ThuocSaiDuongDungVoiDMTaiBV(XML2PlusDTO _xml2Filter)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {
                var _thuocTimKiem = GlobalStore.lstBenhVienPheDuyet_Thuoc.Where(o => o.MANHOM_9324.ToString() == _xml2Filter.MA_NHOM && o.MA_AX == _xml2Filter.MA_THUOC && o.MA_DUONG_DUNG == _xml2Filter.DUONG_DUNG).ToList();
                if (_thuocTimKiem == null || _thuocTimKiem.Count <= 0)
                {
                    result.TRANG_THAI = 1;
                    result.LYDO_VIPHAM = "Thuốc sai đường dùng so với danh mục sử dụng tại BV";
                    result.LOAI_CANH_BAO = DanhSachThongBao.CANH_BAO;
                    result.DIEN_GIAI = "";
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC52 - Thuốc sai hàm lượng so với danh mục sử dụng tại BV
        private TieuChiGiamDinhLoi_DVKTDTO TC52_ThuocSaiHamLuongVoiDMTaiBV(XML2PlusDTO _xml2Filter)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {
                var _thuocTimKiem = GlobalStore.lstBenhVienPheDuyet_Thuoc.Where(o => o.MANHOM_9324.ToString() == _xml2Filter.MA_NHOM && o.MA_AX == _xml2Filter.MA_THUOC && o.HAM_LUONG.ToUpper().Trim() == _xml2Filter.HAM_LUONG.ToUpper().Trim()).ToList();
                if (_thuocTimKiem == null || _thuocTimKiem.Count <= 0)
                {
                    result.TRANG_THAI = 1;
                    result.LYDO_VIPHAM = "Thuốc sai hàm lượng so với danh mục sử dụng tại BV";
                    result.LOAI_CANH_BAO = DanhSachThongBao.CANH_BAO;
                    result.DIEN_GIAI = "";
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC53 - Máu có Mã sai quy định
        private TieuChiGiamDinhLoi_DVKTDTO TC53_MauSaiMaVoiTT05(XML2PlusDTO _xml2Filter)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {
                var _thuocTimKiem = GlobalStore.lstBenhVienPheDuyet_Thuoc.Where(o => o.MANHOM_9324.ToString() == _xml2Filter.MA_NHOM && o.MA_HOAT_CHAT == _xml2Filter.MA_THUOC).ToList();
                if (_thuocTimKiem == null || _thuocTimKiem.Count <= 0)
                {
                    result.TRANG_THAI = 1;
                    result.LYDO_VIPHAM = "Máu có Mã sai quy định";
                    result.LOAI_CANH_BAO = DanhSachThongBao.XUAT_TOAN;
                    result.DIEN_GIAI = "";
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC55 - Máu vượt quá giá tối đa
        private TieuChiGiamDinhLoi_DVKTDTO TC55_MauVuotQuaGiaToiDa(XML2PlusDTO _xml2Filter)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {
                var _thuocTimKiem = GlobalStore.lstBenhVienPheDuyet_Thuoc.Where(o => o.MANHOM_9324.ToString() == _xml2Filter.MA_NHOM && o.MA_HOAT_CHAT == _xml2Filter.MA_THUOC).ToList().OrderByDescending(p => p.DON_GIA).FirstOrDefault();
                if (_thuocTimKiem != null)
                {
                    if (_xml2Filter.DON_GIA > _thuocTimKiem.DON_GIA)
                    {
                        result.TRANG_THAI = 1;
                        result.LYDO_VIPHAM = "Máu vượt quá giá tối đa";
                        result.LOAI_CANH_BAO = DanhSachThongBao.XUAT_TOAN;
                        result.DIEN_GIAI = "Giá máu tối đa trong danh mục được phê duyệt là: " + _thuocTimKiem.DON_GIA;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC60 - Thuốc sai mã nhóm với danh mục sử dụng tại BV
        private TieuChiGiamDinhLoi_DVKTDTO TC60_ThuocSaiMaNhomVoiDMTaiBV(XML2PlusDTO _xml2Filter)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {
                var _thuocTimKiem = GlobalStore.lstBenhVienPheDuyet_Thuoc.Where(o => o.MA_HOAT_CHAT == _xml2Filter.MA_THUOC && o.TEN_THUOC.ToUpper().Trim() == _xml2Filter.TEN_THUOC.ToUpper().Trim()).FirstOrDefault();
                if (_thuocTimKiem != null)
                {
                    if (_thuocTimKiem.MANHOM_9324.ToString() != _xml2Filter.MA_NHOM)
                    {
                        result.TRANG_THAI = 1;
                        result.LYDO_VIPHAM = "Thuốc sai mã nhóm với danh mục sử dụng tại BV";
                        result.LOAI_CANH_BAO = DanhSachThongBao.XUAT_TOAN;
                        result.DIEN_GIAI = "Mã nhóm của thuốc trong danh mục phê duyệt là: " + _thuocTimKiem.MANHOM_9324;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC69 - Sử dụng Thuốc đã có trong cơ cấu giá DVKT(thuốc tê, mê, chỉ định cùng thời gian thực hiện PTTT)
        private TieuChiGiamDinhLoi_DVKTDTO TC69_DVKTSaiMaNhomVoiDMThucHien(XML2PlusDTO _xml2Filter)
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
        private TieuChiGiamDinhLoi_DVKTDTO TC71_ThuocThanhToanSaiTyLe(XML2PlusDTO _xml2Filter)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {
                var _thuocTimKiem = GlobalStore.lstBenhVienPheDuyet_Thuoc.Where(o => o.MANHOM_9324 == 6 && o.MA_HOAT_CHAT == _xml2Filter.MA_THUOC && o.TEN_THUOC.ToUpper().Trim() == _xml2Filter.TEN_THUOC.ToUpper().Trim()).FirstOrDefault();
                if (_thuocTimKiem != null)
                {
                    if (_xml2Filter.TYLE_TT == 100)
                    {
                        result.TRANG_THAI = 1;
                        result.LYDO_VIPHAM = "Sử dụng thuốc thanh toán sai tỷ lệ";
                        result.LOAI_CANH_BAO = DanhSachThongBao.XUAT_TOAN;
                        result.DIEN_GIAI = "";
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }
        #endregion


    }
}