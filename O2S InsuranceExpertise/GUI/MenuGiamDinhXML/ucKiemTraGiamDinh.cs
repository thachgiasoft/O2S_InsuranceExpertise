using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using O2S_InsuranceExpertise.Model.Models.Xml_917.XMLDTO;
using O2S_InsuranceExpertise.Model.Models.Xml_917.XMLTag;
using AutoMapper;
using O2S_InsuranceExpertise.Model.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using DevExpress.XtraSplashScreen;

namespace O2S_InsuranceExpertise.GUI.MenuGiamDinhXML
{
    public partial class ucKiemTraGiamDinh : UserControl
    {
        #region Khai bao
        private List<XML_HOSODTO> lstXMLHoSo_KiemTra { get; set; }
        private List<HoSo_CheckLoiDTO> lstXML1_KiemTra { get; set; }
        private HttpClient client_chek = new HttpClient();

        // khai báo 1 hàm delegate
        public delegate void GetString(List<XML_HOSODTO> _lstXMLHoSo_KiemTra);
        // khai báo 1 kiểu hàm delegate
        public GetString MyGetData;


        #endregion
        public ucKiemTraGiamDinh()
        {
            InitializeComponent();
        }
        public ucKiemTraGiamDinh(List<XML_HOSODTO> _lstXMLHoSo_KiemTra)
        {
            InitializeComponent();
            this.lstXMLHoSo_KiemTra = _lstXMLHoSo_KiemTra;
        }
        //public void Init()
        //{
        //    ResetDuLieuVeMacDinh();
        //    LoadThongTinTongHop();
        //}

        #region Load
        private void ucKiemTraGiamDinh_Load(object sender, EventArgs e)
        {
            try
            {
                ResetDuLieuVeMacDinh();
                LoadThongTinTongHop();
                //Init();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void ResetDuLieuVeMacDinh()
        {
            try
            {
                lblHS_Tong.Text = "";
                lblHS_NgoaiTru.Text = "";
                lblNoiTru.Text = "";
                lblHSLoi_Tong.Text = "0";
                lblLoi_Tong.Text = "0";
                lblLoi_XuatToan.Text = "0";
                lblLoi_CanhBao.Text = "0";
                lblChiPhi_Tong.Text = "";
                lblChiPhi_BHYT.Text = "";
                lblChiPhi_BN.Text = "";
                lblChiPhi_Khac.Text = "";
                lblChiPhi_XML1.Text = "";
                lblChiPhi_XML23.Text = "";
                lblChiPhi_Chenh.Text = "";
                lblThuoc_XML1.Text = "";
                lblThuoc_XML2.Text = "";
                lblThuoc_Chenh.Text = "";
                lblVatTu_XML1.Text = "";
                lblVatTu_XML3.Text = "";
                lblVatTu_Chenh.Text = "";

                lblDaKiemTra.Text = "0";
                lblConLai.Text = "";
                lblThoiGianKiemTra.Text = "00:00";
                lblPhanTramXuLy.Text = "0%";

                gridControlDSHoSo.DataSource = null;
                gridControlDSLoi.DataSource = null;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadThongTinTongHop()
        {
            try
            {
                lblHS_Tong.Text = this.lstXMLHoSo_KiemTra.Count.ToString();
                lblHS_NgoaiTru.Text = this.lstXMLHoSo_KiemTra.Where(o => o.MA_LOAI_KCB == 1 || o.MA_LOAI_KCB == 2).ToList().Count.ToString();
                lblNoiTru.Text = this.lstXMLHoSo_KiemTra.Where(o => o.MA_LOAI_KCB == 3).ToList().Count.ToString();
                //lblHSLoi_Tong.Text = "";
                //lblLoi_Tong.Text = "";
                //lblLoi_XuatToan.Text = "";
                //lblLoi_CanhBao.Text = "";
                //chi phi
                decimal _lblChiPhi_Tong = 0;
                decimal _lblChiPhi_BHYT = 0;
                decimal _lblChiPhi_BN = 0;
                decimal _lblChiPhi_Khac = 0;
                decimal _lblChiPhi_XML23 = 0;
                decimal _lblThuoc_XML1 = 0;
                decimal _lblThuoc_XML2 = 0;
                decimal _lblVatTu_XML1 = 0;
                decimal _lblVatTu_XML3 = 0;
                this.lstXML1_KiemTra = new List<HoSo_CheckLoiDTO>();
                foreach (var item_hs in this.lstXMLHoSo_KiemTra)
                {
                    _lblChiPhi_Tong += item_hs.T_TONGCHI ?? 0;
                    _lblChiPhi_BHYT += item_hs.T_BHTT ?? 0;
                    _lblChiPhi_BN += item_hs.T_BNTT ?? 0;
                    _lblChiPhi_Khac += item_hs.T_NGUONKHAC ?? 0;
                    _lblThuoc_XML1 += item_hs.T_THUOC ?? 0;
                    _lblVatTu_XML1 += item_hs.T_VTYT ?? 0;

                    if (item_hs.lstXML2 != null)
                    {
                        foreach (var item_xml2 in item_hs.lstXML2)
                        {
                            _lblChiPhi_XML23 += item_xml2.THANH_TIEN ?? 0;
                            _lblThuoc_XML2 += item_xml2.THANH_TIEN ?? 0;
                        }
                    }
                    if (item_hs.lstXML3 != null)
                    {
                        foreach (var item_xml3 in item_hs.lstXML3)
                        {
                            _lblChiPhi_XML23 += item_xml3.THANH_TIEN ?? 0;
                            if (item_xml3.MA_VAT_TU != "")
                            {
                                _lblVatTu_XML3 += item_xml3.THANH_TIEN ?? 0;
                            }
                        }
                    }

                    Mapper.Initialize(cfg => cfg.CreateMap<XML_HOSODTO, HoSo_CheckLoiDTO>());
                    HoSo_CheckLoiDTO _XML1_KiemTra = AutoMapper.Mapper.Map<XML_HOSODTO, HoSo_CheckLoiDTO>(item_hs);
                    this.lstXML1_KiemTra.Add(_XML1_KiemTra);
                }
                lblChiPhi_Tong.Text = Common.Number.NumberConvert.NumberToString(_lblChiPhi_Tong, 2);
                lblChiPhi_BHYT.Text = Common.Number.NumberConvert.NumberToString(_lblChiPhi_BHYT, 2);
                lblChiPhi_BN.Text = Common.Number.NumberConvert.NumberToString(_lblChiPhi_BN, 2);
                lblChiPhi_Khac.Text = Common.Number.NumberConvert.NumberToString(_lblChiPhi_Khac, 2);
                lblChiPhi_XML1.Text = Common.Number.NumberConvert.NumberToString(_lblChiPhi_Tong, 2);
                lblChiPhi_XML23.Text = Common.Number.NumberConvert.NumberToString(_lblChiPhi_XML23, 2);
                lblChiPhi_Chenh.Text = Common.Number.NumberConvert.NumberToString((_lblChiPhi_Tong - _lblChiPhi_XML23), 2);
                lblThuoc_XML1.Text = Common.Number.NumberConvert.NumberToString(_lblThuoc_XML1, 2);
                lblThuoc_XML2.Text = Common.Number.NumberConvert.NumberToString(_lblThuoc_XML2, 2);
                lblThuoc_Chenh.Text = Common.Number.NumberConvert.NumberToString((_lblThuoc_XML1 - _lblThuoc_XML2), 2);
                lblVatTu_XML1.Text = Common.Number.NumberConvert.NumberToString(_lblVatTu_XML1, 2);
                lblVatTu_XML3.Text = Common.Number.NumberConvert.NumberToString(_lblVatTu_XML3, 2);
                lblVatTu_Chenh.Text = Common.Number.NumberConvert.NumberToString((_lblVatTu_XML1 - _lblVatTu_XML3), 2);

                lblDaKiemTra.Text = "0";
                lblConLai.Text = "";
                lblThoiGianKiemTra.Text = "00:00";
                lblPhanTramXuLy.Text = "0%";

                gridControlDSHoSo.DataSource = this.lstXML1_KiemTra;
                gridControlDSLoi.DataSource = null;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion


        #region Custom
        private void gridViewHoSo_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (e.RowHandle == view.FocusedRowHandle)
                {
                    e.Appearance.BackColor = Color.LightGreen;
                    //Neu co loi thi Hien thi text mau do
                    //long _soloi = Common.TypeConvert.TypeConvertParse.ToInt64(gridViewDSHoSo.GetRowCellValue(e.RowHandle, "TONG_SO_LOI").ToString());
                    //if (_soloi > 0)
                    //{
                    //    e.Appearance.ForeColor = Color.Red;
                    //}
                    //else
                    //{
                    //    e.Appearance.ForeColor = Color.Black;
                    //}
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        #endregion

        #region Events
        private void gridViewHoSo_Click(object sender, EventArgs e)
        {
            try
            {
                //hien thi len Loi o Grid DS Loi
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void gridViewHoSo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //TOTO hien thi form Loi chi tiet
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }


        #endregion

        #region Chay Kiem Tra
        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            try
            {
                btnDung.Visible = true;
                btnKiemTra.Visible = false;
                KiemTraGiamDinh_Start();
                btnDung.Visible = false;
                btnKiemTra.Visible = true;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnDung_Click(object sender, EventArgs e)
        {
            try
            {
                btnDung.Visible = false;
                btnKiemTra.Visible = true;
                KiemTraGiamDinh_Stop();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void KiemTraGiamDinh_Start()
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
                List<LoiGiamDinh> lstLoiGiamDinh = new List<LoiGiamDinh>();

                if (this.lstXML1_KiemTra != null && this.lstXML1_KiemTra.Count > 0)
                {
                    foreach (var item_xml in this.lstXML1_KiemTra)
                    {
                        client_chek = new HttpClient();
                        client_chek.BaseAddress = new Uri(Base.SessionLogin.UrlFullServer);
                        client_chek.DefaultRequestHeaders.Accept.Clear();
                        client_chek.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        FileInfo f = new FileInfo(item_xml.filePath);
                        byte[] buffer = null;
                        using (FileStream fs = f.OpenRead())
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                fs.CopyTo(memoryStream);
                                buffer = memoryStream.ToArray();
                            }
                        }
                        HttpResponseMessage response = client_chek.PostAsJsonAsync("api/GiamDinhHoSoPorttal/GuiHoSoGiamDinh", buffer).Result;

                        NhanChiTietLoiHoSoPortalDTO _chiTietLoi = new NhanChiTietLoiHoSoPortalDTO();
                        if (response.IsSuccessStatusCode)
                        {
                            _chiTietLoi = response.Content.ReadAsAsync<NhanChiTietLoiHoSoPortalDTO>().Result;
                            lstLoiGiamDinh.AddRange(_chiTietLoi.dsLoi);
                        }
                    }
                }
                MessageBox.Show("Chay xong","OK");
                gridControlDSLoi.DataSource = lstLoiGiamDinh;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
            SplashScreenManager.CloseForm();
        }
        private void KiemTraGiamDinh_Stop()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }


        #endregion

        #region Lable Click envents
        private void lblHSLoi_Tong_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void lblLoi_Tong_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void lblLoi_XuatToan_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void lblLoi_CanhBao_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        #endregion


    }
}
