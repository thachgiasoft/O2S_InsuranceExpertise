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
    public class TieuChiProcess_XML3
    {
        public GiamDinhLoi_DVKTDTO GiamDinhLoi_XML3(XML3PlusDTO _xml3Filter)
        {
            GiamDinhLoi_DVKTDTO result_DVKT = new GiamDinhLoi_DVKTDTO();
            try
            {
                Mapper.Initialize(cfg => cfg.CreateMap<XML3PlusDTO, GiamDinhLoi_DVKTDTO>());
                result_DVKT = AutoMapper.Mapper.Map<XML3PlusDTO, GiamDinhLoi_DVKTDTO>(_xml3Filter);
                result_DVKT.LOAI_XML = "XML3";
                result_DVKT.MA_DVKT = _xml3Filter.MA_DICH_VU ?? _xml3Filter.MA_VAT_TU;
                result_DVKT.TEN_DVKT = _xml3Filter.TEN_DICH_VU;

                if (_xml3Filter.MA_VAT_TU != null || _xml3Filter.MA_VAT_TU != "")
                {
                    //TieuChiGiamDinhLoi_DVKTDTO _ketqua_TC47 = TC47_VTYTKhongThanhToanRieng(_xml3Filter);
                    //if (_ketqua_TC47.TRANG_THAI == 1)
                    //{
                    //    result_DVKT.LYDO_VIPHAM += _ketqua_TC47;
                    //    result_DVKT.DIEN_GIAI += _ketqua_TC47.DIEN_GIAI;
                    //    result_DVKT.LOAI_CANH_BAO += _ketqua_TC47.LOAI_CANH_BAO;
                    //}
                    TieuChiGiamDinhLoi_DVKTDTO _ketqua_TC48 = TC48_VTYTNgoaiDMSDTaiBV(_xml3Filter);
                    if (_ketqua_TC48.TRANG_THAI == 1)
                    {
                        result_DVKT.LYDO_VIPHAM += "\n" + _ketqua_TC48;
                        result_DVKT.DIEN_GIAI += "\n" + _ketqua_TC48.DIEN_GIAI;
                        result_DVKT.LOAI_CANH_BAO += "\n" + _ketqua_TC48.LOAI_CANH_BAO;
                    }
                    TieuChiGiamDinhLoi_DVKTDTO _ketqua_TC51 = TC51_VTYTSaiTenVoiDMTaiBV(_xml3Filter);
                    if (_ketqua_TC51.TRANG_THAI == 1)
                    {
                        result_DVKT.LYDO_VIPHAM += "\n" + _ketqua_TC51;
                        result_DVKT.DIEN_GIAI += "\n" + _ketqua_TC51.DIEN_GIAI;
                        result_DVKT.LOAI_CANH_BAO += "\n" + _ketqua_TC51.LOAI_CANH_BAO;
                    }
                    TieuChiGiamDinhLoi_DVKTDTO _ketqua_TC61 = TC61_VTYTSaiMaNhomVoiDMTaiBV(_xml3Filter);
                    if (_ketqua_TC61.TRANG_THAI == 1)
                    {
                        result_DVKT.LYDO_VIPHAM += "\n" + _ketqua_TC61;
                        result_DVKT.DIEN_GIAI += "\n" + _ketqua_TC61.DIEN_GIAI;
                        result_DVKT.LOAI_CANH_BAO += "\n" + _ketqua_TC61.LOAI_CANH_BAO;
                    }
                    TieuChiGiamDinhLoi_DVKTDTO _ketqua_TC72 = TC72_VTYTThanhToanSaiTyLe(_xml3Filter);
                    if (_ketqua_TC72.TRANG_THAI == 1)
                    {
                        result_DVKT.LYDO_VIPHAM += "\n" + _ketqua_TC72;
                        result_DVKT.DIEN_GIAI += "\n" + _ketqua_TC72.DIEN_GIAI;
                        result_DVKT.LOAI_CANH_BAO += "\n" + _ketqua_TC72.LOAI_CANH_BAO;
                    }
                }
                else
                {
                    TieuChiGiamDinhLoi_DVKTDTO _ketqua_TC62 = TC62_DVKTSaiTenVoiDM(_xml3Filter);
                    if (_ketqua_TC62.TRANG_THAI == 1)
                    {
                        result_DVKT.LYDO_VIPHAM += "\n" + _ketqua_TC62;
                        result_DVKT.DIEN_GIAI += "\n" + _ketqua_TC62.DIEN_GIAI;
                        result_DVKT.LOAI_CANH_BAO += "\n" + _ketqua_TC62.LOAI_CANH_BAO;
                    }
                    TieuChiGiamDinhLoi_DVKTDTO _ketqua_TC63 = TC63_DVKTKhongNamTrongBangGiaPheDuyet(_xml3Filter);
                    if (_ketqua_TC63.TRANG_THAI == 1)
                    {
                        result_DVKT.LYDO_VIPHAM += "\n" + _ketqua_TC63;
                        result_DVKT.DIEN_GIAI += "\n" + _ketqua_TC63.DIEN_GIAI;
                        result_DVKT.LOAI_CANH_BAO += "\n" + _ketqua_TC63.LOAI_CANH_BAO;
                    }
                    TieuChiGiamDinhLoi_DVKTDTO _ketqua_TC64 = TC64_DVKTKhongNamTrongDMThucHien(_xml3Filter);
                    if (_ketqua_TC64.TRANG_THAI == 1)
                    {
                        result_DVKT.LYDO_VIPHAM += "\n" + _ketqua_TC64;
                        result_DVKT.DIEN_GIAI += "\n" + _ketqua_TC64.DIEN_GIAI;
                        result_DVKT.LOAI_CANH_BAO += "\n" + _ketqua_TC64.LOAI_CANH_BAO;
                    }
                    TieuChiGiamDinhLoi_DVKTDTO _ketqua_TC65 = TC65_DVKTGiaCaohonGiaPheDuyet(_xml3Filter);
                    if (_ketqua_TC65.TRANG_THAI == 1)
                    {
                        result_DVKT.LYDO_VIPHAM += "\n" + _ketqua_TC65;
                        result_DVKT.DIEN_GIAI += "\n" + _ketqua_TC65.DIEN_GIAI;
                        result_DVKT.LOAI_CANH_BAO += "\n" + _ketqua_TC65.LOAI_CANH_BAO;
                    }
                    TieuChiGiamDinhLoi_DVKTDTO _ketqua_TC66 = TC66_DVKTMaKhongNamTrongDMTuongDuong(_xml3Filter);
                    if (_ketqua_TC66.TRANG_THAI == 1)
                    {
                        result_DVKT.LYDO_VIPHAM += "\n" + _ketqua_TC66;
                        result_DVKT.DIEN_GIAI += "\n" + _ketqua_TC66.DIEN_GIAI;
                        result_DVKT.LOAI_CANH_BAO += "\n" + _ketqua_TC66.LOAI_CANH_BAO;
                    }
                    TieuChiGiamDinhLoi_DVKTDTO _ketqua_TC67 = TC67_DVKTTenKhongNamTrongDMTT43TT50(_xml3Filter);
                    if (_ketqua_TC67.TRANG_THAI == 1)
                    {
                        result_DVKT.LYDO_VIPHAM += "\n" + _ketqua_TC67;
                        result_DVKT.DIEN_GIAI += "\n" + _ketqua_TC67.DIEN_GIAI;
                        result_DVKT.LOAI_CANH_BAO += "\n" + _ketqua_TC67.LOAI_CANH_BAO;
                    }
                    TieuChiGiamDinhLoi_DVKTDTO _ketqua_TC68 = TC68_DVKTSaiMaNhomVoiDMThucHien(_xml3Filter);
                    if (_ketqua_TC68.TRANG_THAI == 1)
                    {
                        result_DVKT.LYDO_VIPHAM += "\n" + _ketqua_TC68;
                        result_DVKT.DIEN_GIAI += "\n" + _ketqua_TC68.DIEN_GIAI;
                        result_DVKT.LOAI_CANH_BAO += "\n" + _ketqua_TC68.LOAI_CANH_BAO;
                    }




                }

                //--khong thay doi
                if (result_DVKT.LOAI_CANH_BAO != null && result_DVKT.LOAI_CANH_BAO.Contains(DanhSachThongBao.XUAT_TOAN))
                {
                    result_DVKT.LOAI_CANH_BAO = DanhSachThongBao.XUAT_TOAN;
                }
                else if (result_DVKT.LOAI_CANH_BAO != "" && result_DVKT.LOAI_CANH_BAO != null && !result_DVKT.LOAI_CANH_BAO.Contains(DanhSachThongBao.XUAT_TOAN))
                {
                    result_DVKT.LOAI_CANH_BAO = DanhSachThongBao.CANH_BAO;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result_DVKT;
        }

        #region Giam dinh tung tieu chi XML3

        #region Vat Tu 
        //TC47 - VTYT không thanh toán riêng (TT27)
        private TieuChiGiamDinhLoi_DVKTDTO TC47_VTYTKhongThanhToanRieng(XML3PlusDTO _xml3Filter)
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
        private TieuChiGiamDinhLoi_DVKTDTO TC48_VTYTNgoaiDMSDTaiBV(XML3PlusDTO _xml3Filter)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {
                var _vattuTimKiem = GlobalStore.lstBenhVienPheDuyet_VatTu.Where(o => o.MA_NHOM_VTYT == _xml3Filter.MA_VAT_TU && o.TEN_VTYT_BV.ToUpper().Trim() == _xml3Filter.TEN_DICH_VU.ToUpper().Trim() && o.DON_VI_TINH.ToUpper().Trim() == _xml3Filter.DON_VI_TINH.ToUpper().Trim() && o.DON_GIA == _xml3Filter.DON_GIA).ToList();
                if (_vattuTimKiem == null || _vattuTimKiem.Count <= 0)
                {
                    result.TRANG_THAI = 1;
                    result.LYDO_VIPHAM = "VTYT ngoài danh mục sử dụng tại BV";
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

        //TC51 - VTYT sai tên so với danh mục được thực hiện
        private TieuChiGiamDinhLoi_DVKTDTO TC51_VTYTSaiTenVoiDMTaiBV(XML3PlusDTO _xml3Filter)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {
                var _vattuTimKiem = GlobalStore.lstBenhVienPheDuyet_VatTu.Where(o => o.MA_NHOM_VTYT == _xml3Filter.MA_VAT_TU).ToList();
                if (_vattuTimKiem != null && _vattuTimKiem.Count > 0)
                {
                    string _tenVTYTTimKiem = "";
                    foreach (var item in _vattuTimKiem)
                    {
                        if (item.TEN_VTYT_BV.ToUpper().Trim() == _xml3Filter.TEN_DICH_VU.ToUpper().Trim())
                        {
                            return result;
                        }
                        else
                        {
                            _tenVTYTTimKiem += item.TEN_VTYT_BV + "\n";
                        }
                    }
                    result.TRANG_THAI = 1;
                    result.LYDO_VIPHAM = "VTYT sai tên so với danh mục được thực hiện";
                    result.LOAI_CANH_BAO = DanhSachThongBao.CANH_BAO;
                    result.DIEN_GIAI = "Tên VTYT trên danh mục là: " + _tenVTYTTimKiem;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC61 - VTYT sai mã nhóm với danh mục sử dụng tại BV
        private TieuChiGiamDinhLoi_DVKTDTO TC61_VTYTSaiMaNhomVoiDMTaiBV(XML3PlusDTO _xml3Filter)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {
                var _vattuTimKiem = GlobalStore.lstBenhVienPheDuyet_VatTu.Where(o => o.MA_NHOM_VTYT == _xml3Filter.MA_VAT_TU && o.TEN_VTYT_BV.ToUpper().Trim() == _xml3Filter.TEN_DICH_VU.ToUpper().Trim()).ToList();
                if (_vattuTimKiem != null && _vattuTimKiem.Count > 0)
                {
                    foreach (var item in _vattuTimKiem)
                    {
                        if (item.MANHOM_9324.ToString() == _xml3Filter.MA_NHOM)
                        {
                            return result;
                        }
                    }
                    result.TRANG_THAI = 1;
                    result.LYDO_VIPHAM = "VTYT sai mã nhóm với danh mục sử dụng tại BV";
                    result.LOAI_CANH_BAO = DanhSachThongBao.XUAT_TOAN;
                    result.DIEN_GIAI = "Mã nhóm vật tư trên danh mục phê duyệt là: " + _vattuTimKiem[0].MANHOM_9324;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC72 - Sử dụng VTYT toán sai tỷ lệ
        private TieuChiGiamDinhLoi_DVKTDTO TC72_VTYTThanhToanSaiTyLe(XML3PlusDTO _xml3Filter)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {
                var _vattuTimKiem = GlobalStore.lstBenhVienPheDuyet_VatTu.Where(o => o.MA_NHOM_VTYT == _xml3Filter.MA_VAT_TU && o.TEN_VTYT_BV.ToUpper().Trim() == _xml3Filter.TEN_DICH_VU.ToUpper().Trim() && o.MANHOM_9324 == 11).ToList();
                if (_vattuTimKiem != null && _vattuTimKiem.Count > 0)
                {
                    foreach (var item in _vattuTimKiem)
                    {
                        if (item.MANHOM_9324.ToString() == _xml3Filter.MA_NHOM)
                        {
                            return result;
                        }
                    }
                    result.TRANG_THAI = 1;
                    result.LYDO_VIPHAM = "Sử dụng VTYT toán sai tỷ lệ";
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

        #endregion

        #region Dich vu
        //TC62 - DVKT sai tên so với danh mục được thực hiện
        private TieuChiGiamDinhLoi_DVKTDTO TC62_DVKTSaiTenVoiDM(XML3PlusDTO _xml3Filter)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {
                var _dvktTimKiem = GlobalStore.lstBenhVienPheDuyet_DVKT.Where(o => o.MA_DVKT == _xml3Filter.MA_DICH_VU).ToList();
                if (_dvktTimKiem != null && _dvktTimKiem.Count > 0)
                {
                    string _tenVTYTTimKiem = "";
                    foreach (var item in _dvktTimKiem)
                    {
                        if (item.TEN_DVKT.ToUpper().Trim() == _xml3Filter.TEN_DICH_VU.ToUpper().Trim())
                        {
                            return result;
                        }
                        else
                        {
                            _tenVTYTTimKiem += item.TEN_DVKT + "\n";
                        }
                    }
                    result.TRANG_THAI = 1;
                    result.LYDO_VIPHAM = "DVKT sai tên so với danh mục được thực hiện";
                    result.LOAI_CANH_BAO = DanhSachThongBao.CANH_BAO;
                    result.DIEN_GIAI = "Tên DVKT trên danh mục là: " + _tenVTYTTimKiem;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC63 - DVKT không nằm trong bảng giá được phê duyệt
        private TieuChiGiamDinhLoi_DVKTDTO TC63_DVKTKhongNamTrongBangGiaPheDuyet(XML3PlusDTO _xml3Filter)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {
                var _dvktTimKiem = GlobalStore.lstBenhVienPheDuyet_DVKT.Where(o => o.MANHOM_9324.ToString() == _xml3Filter.MA_NHOM && o.MA_DVKT == _xml3Filter.MA_DICH_VU && o.TEN_DVKT.ToUpper().Trim() == _xml3Filter.TEN_DICH_VU.ToUpper().Trim() && o.DON_GIA == _xml3Filter.DON_GIA).ToList();
                if (_dvktTimKiem == null || _dvktTimKiem.Count <= 0)
                {
                    result.TRANG_THAI = 1;
                    result.LYDO_VIPHAM = "DVKT không nằm trong bảng giá được phê duyệt";
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

        //TC64 - DVKT không nằm trong danh mục được thực hiện
        private TieuChiGiamDinhLoi_DVKTDTO TC64_DVKTKhongNamTrongDMThucHien(XML3PlusDTO _xml3Filter)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {
                var _dvktTimKiem = GlobalStore.lstBenhVienPheDuyet_DVKT.Where(o => o.MA_DVKT == _xml3Filter.MA_DICH_VU && o.TEN_DVKT.ToUpper().Trim() == _xml3Filter.TEN_DICH_VU.ToUpper().Trim()).ToList();
                if (_dvktTimKiem == null || _dvktTimKiem.Count <= 0)
                {
                    result.TRANG_THAI = 1;
                    result.LYDO_VIPHAM = "DVKT không nằm trong danh mục được thực hiện";
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

        //TC65 - DVKT giá cao hơn giá được phê duyệt
        private TieuChiGiamDinhLoi_DVKTDTO TC65_DVKTGiaCaohonGiaPheDuyet(XML3PlusDTO _xml3Filter)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {
                var _dvktTimKiem = GlobalStore.lstBenhVienPheDuyet_DVKT.Where(o => o.MANHOM_9324.ToString() == _xml3Filter.MA_NHOM && o.MA_DVKT == _xml3Filter.MA_DICH_VU && o.TEN_DVKT.ToUpper().Trim() == _xml3Filter.TEN_DICH_VU.ToUpper().Trim()).ToList().OrderByDescending(d => d.DON_GIA).FirstOrDefault();
                if (_dvktTimKiem.DON_GIA < _xml3Filter.DON_GIA)
                {
                    result.TRANG_THAI = 1;
                    result.LYDO_VIPHAM = "DVKT giá cao hơn giá được phê duyệt";
                    result.LOAI_CANH_BAO = DanhSachThongBao.XUAT_TOAN;
                    result.DIEN_GIAI = "Giá DVKT được phê duyệt lớn nhất là: " + _dvktTimKiem.DON_GIA;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC66 - DVKT có mã không nằm trong danh mục tương đương
        private TieuChiGiamDinhLoi_DVKTDTO TC66_DVKTMaKhongNamTrongDMTuongDuong(XML3PlusDTO _xml3Filter)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {
                var _dvktTimKiem = GlobalStore.lstBenhVienPheDuyet_DVKT.Where(o => o.MANHOM_9324.ToString() == _xml3Filter.MA_NHOM && (o.MA_DVKT == _xml3Filter.MA_DICH_VU || o.MA_AX == _xml3Filter.MA_DICH_VU)).ToList();
                if (_dvktTimKiem == null || _dvktTimKiem.Count <= 0)
                {
                    result.TRANG_THAI = 1;
                    result.LYDO_VIPHAM = "DVKT có mã không nằm trong danh mục tương đương";
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

        //TC67 - DVKT có tên không nằm trong danh mục quy định (TT43,50)
        private TieuChiGiamDinhLoi_DVKTDTO TC67_DVKTTenKhongNamTrongDMTT43TT50(XML3PlusDTO _xml3Filter)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {
                var _dvktTimKiem = GlobalStore.lstBenhVienPheDuyet_DVKT.Where(o => o.MANHOM_9324.ToString() == _xml3Filter.MA_NHOM && o.TEN_AX.ToUpper().Trim()==_xml3Filter.TEN_DICH_VU.ToUpper().Trim()).ToList();
                if (_dvktTimKiem == null || _dvktTimKiem.Count <= 0)
                {
                    result.TRANG_THAI = 1;
                    result.LYDO_VIPHAM = "DVKT có tên không nằm trong danh mục quy định (TT43,50)";
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

        //TC68 - DVKT sai mã nhóm với danh mục được thực hiện
        private TieuChiGiamDinhLoi_DVKTDTO TC68_DVKTSaiMaNhomVoiDMThucHien(XML3PlusDTO _xml3Filter)
        {
            TieuChiGiamDinhLoi_DVKTDTO result = new TieuChiGiamDinhLoi_DVKTDTO();
            try
            {
                var _dvktTimKiem = GlobalStore.lstBenhVienPheDuyet_DVKT.Where(o => o.MA_DVKT == _xml3Filter.MA_DICH_VU && o.TEN_DVKT.ToUpper().Trim() == _xml3Filter.TEN_DICH_VU.ToUpper().Trim()).ToList();
                if (_dvktTimKiem != null && _dvktTimKiem.Count > 0)
                {
                    foreach (var item in _dvktTimKiem)
                    {
                        if (item.MANHOM_9324.ToString() == _xml3Filter.MA_NHOM)
                        {
                            return result;
                        }
                    }
                    result.TRANG_THAI = 1;
                    result.LYDO_VIPHAM = "DVKT sai mã nhóm với danh mục được thực hiện";
                    result.LOAI_CANH_BAO = DanhSachThongBao.XUAT_TOAN;
                    result.DIEN_GIAI = "Mã nhóm DVKT trên danh mục phê duyệt là: " + _dvktTimKiem[0].MANHOM_9324;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        //TC74 - Thanh toán tiền giường vượt quá số ngày quy định
        private TieuChiGiamDinhLoi_DVKTDTO TC74_GiuongVuotQuaSoNgayQuyDinh(string _SO_NGAY_DTRI_XML1, string _SO_NGAY_DTRI_XML3)
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
        private TieuChiGiamDinhLoi_DVKTDTO TC75_ThanhToanTren1LanTienKham(string _MA_LOAI_KCB, string _SO_LUONG_KHAMBENH)
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
        private TieuChiGiamDinhLoi_DVKTDTO TC76_KBDeNghiTienKhamTren1CKSaiQD(List<XML3PlusDTO> _lstXML3)
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
        private TieuChiGiamDinhLoi_DVKTDTO TC77_VTYTTinhToanTyLeApTran(string _MA_VAT_TU, string _DON_GIA)
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
        private TieuChiGiamDinhLoi_DVKTDTO TC78_VTYTDemDVKTKhongTonTai(string _MA_DICH_VU, string _MA_VAT_TU)
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

        #endregion

        #endregion



    }
}
