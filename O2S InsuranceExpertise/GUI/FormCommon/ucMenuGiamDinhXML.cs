﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DevExpress.XtraGrid.Views.Grid;
using O2S_InsuranceExpertise.Base;
using O2S_InsuranceExpertise.BUS;
using O2S_InsuranceExpertise.GUI.MenuCongCuKhac;
using System.Configuration;
using O2S_InsuranceExpertise.Model.Models.Xml_917;
using O2S_InsuranceExpertise.Model.Models.Xml_917.XMLTag;
using O2S_InsuranceExpertise.Model.Models.Xml_917.XMLDTO;
using AutoMapper;
using DevExpress.Utils.Menu;
using DevExpress.XtraSplashScreen;
using System.Globalization;

namespace O2S_InsuranceExpertise.GUI.FormCommon
{
    public partial class ucMenuGiamDinhXML : UserControl
    {
        #region Declaration
        private DAL.ConnectDatabase condb = new DAL.ConnectDatabase();
        public string CurrentTabPage { get; set; }
        public int SelectedTabPageIndex { get; set; }
        internal frmMain frmMain;

        // khai báo 1 hàm delegate
        public delegate void GetString(string thoigian);
        // khai báo 1 kiểu hàm delegate
        public GetString MyGetData;

        List<XML_HOSODTO> lstXMLHoSo { get; set; }
        //List<XML1DTO> lstXML1_Current { get; set; }
        //List<XML2DTO> lstXML2_Current { get; set; }
        //List<XML3DTO> lstXML3_Current { get; set; }
        //List<XML4DTO> lstXML4_Current { get; set; }
        //List<XML5DTO> lstXML5_Current { get; set; }






        #endregion
        public ucMenuGiamDinhXML()
        {
            InitializeComponent();
        }
        public ucMenuGiamDinhXML(bool _hienthi_btnTroVe)
        {
            InitializeComponent();
        }

        #region Load
        private void ucMenuGiamDinhXML_Load(object sender, EventArgs e)
        {
            try
            {
                KiemTraEnable_ChucNang();
                MyGetData("Giám định XML - Tổng hợp dữ liệu");
                LoadFileXMLThuMucCauHinhSan();
                LoadDuLieuCanThietChoGiamDinh();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void KiemTraEnable_ChucNang()
        {
            try
            {
                xtraTab_GDXMLTongHop.Visible = O2S_InsuranceExpertise.Base.CheckPermission.ChkPerModule("TOOL_04");
                //xtraTab_CHTieuChiGiamDinh.PageVisible = O2S_InsuranceExpertise.Base.CheckPermission.ChkPerModule("TOOL_02");
                //xtraTab_CHTheXML.PageVisible = O2S_InsuranceExpertise.Base.CheckPermission.ChkPerModule("TOOL_03");
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void LoadFileXMLThuMucCauHinhSan()
        {
            try
            {
                if (ConfigurationManager.AppSettings["DuongDanDocFileXML"].ToString() != "")
                {
                    chkGhiNhoDuongDan.Checked = true;
                    this.lstXMLHoSo = new List<XML_HOSODTO>();

                    string[] filePahts = System.IO.Directory.GetFiles(ConfigurationManager.AppSettings["DuongDanDocFileXML"].ToString(), "*.xml");
                    foreach (var item_file in filePahts)
                    {
                        List<XML_HOSODTO> _lstxmlHoSo = ConvertXMLFileToObject(item_file);
                        this.lstXMLHoSo.AddRange(_lstxmlHoSo);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadDuLieuCanThietChoGiamDinh()
        {
            try
            {
                if (GlobalStore.lstBang6CV9324 == null || GlobalStore.lstBang6CV9324.Count == 0)
                {
                    GlobalStore.lstBang6CV9324 = new List<Model.Models.Bang6CV9324DTO>();
                    GlobalStore.lstBang6CV9324.Add(new Model.Models.Bang6CV9324DTO { MA_NHOM = 1, TEN_NHOM = "01-Xét nghiệm" });
                    GlobalStore.lstBang6CV9324.Add(new Model.Models.Bang6CV9324DTO { MA_NHOM = 2, TEN_NHOM = "02-Chẩn đoán hình ảnh" });
                    GlobalStore.lstBang6CV9324.Add(new Model.Models.Bang6CV9324DTO { MA_NHOM = 3, TEN_NHOM = "03-Thăm dò chức năng" });
                    GlobalStore.lstBang6CV9324.Add(new Model.Models.Bang6CV9324DTO { MA_NHOM = 4, TEN_NHOM = "04-Thuốc trong danh mục BHYT" });
                    GlobalStore.lstBang6CV9324.Add(new Model.Models.Bang6CV9324DTO { MA_NHOM = 5, TEN_NHOM = "05-Thuốc điều trị ung thư, chống thải ghép ngoài danh mục" });
                    GlobalStore.lstBang6CV9324.Add(new Model.Models.Bang6CV9324DTO { MA_NHOM = 6, TEN_NHOM = "06-Thuốc thanh toán theo tỷ lệ" });
                    GlobalStore.lstBang6CV9324.Add(new Model.Models.Bang6CV9324DTO { MA_NHOM = 7, TEN_NHOM = "07-Máu và chế phẩm máu" });
                    GlobalStore.lstBang6CV9324.Add(new Model.Models.Bang6CV9324DTO { MA_NHOM = 8, TEN_NHOM = "08-Thủ thuật, phẫu thuật" });
                    GlobalStore.lstBang6CV9324.Add(new Model.Models.Bang6CV9324DTO { MA_NHOM = 9, TEN_NHOM = "09-DVKT thanh toán theo tỷ lệ" });
                    GlobalStore.lstBang6CV9324.Add(new Model.Models.Bang6CV9324DTO { MA_NHOM = 10, TEN_NHOM = "10-Vật tư y tế trong danh mục BHYT" });
                    GlobalStore.lstBang6CV9324.Add(new Model.Models.Bang6CV9324DTO { MA_NHOM = 11, TEN_NHOM = "11-VTYT thanh toán theo tỷ lệ" });
                    GlobalStore.lstBang6CV9324.Add(new Model.Models.Bang6CV9324DTO { MA_NHOM = 12, TEN_NHOM = "12-Vận chuyển" });
                    GlobalStore.lstBang6CV9324.Add(new Model.Models.Bang6CV9324DTO { MA_NHOM = 13, TEN_NHOM = "13-Khám bệnh" });
                    GlobalStore.lstBang6CV9324.Add(new Model.Models.Bang6CV9324DTO { MA_NHOM = 14, TEN_NHOM = "14-Giường điều trị ngoại trú" });
                    GlobalStore.lstBang6CV9324.Add(new Model.Models.Bang6CV9324DTO { MA_NHOM = 15, TEN_NHOM = "15-Giường điều trị nội trú" });
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        #endregion

        #region Tabcontrol function
        //Dong tab
        private void xtraTabControlCongCuKhac_CloseButtonClick(object sender, EventArgs e)
        {
            try
            {
                XtraTabControl xtab = (XtraTabControl)sender;
                int i = xtab.SelectedTabPageIndex;
                DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs arg = e as DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs;
                xtab.TabPages.Remove((arg.Page as XtraTabPage));
                xtab.SelectedTabPageIndex = i - 1;
                //(arg.Page as XtraTabPage).PageVisible = false;
                System.GC.Collect();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void xtraTabControlCongCuKhac_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            try
            {
                frmMain = new frmMain();
                this.CurrentTabPage = e.Page.Name;
                XtraTabControl xtab = new XtraTabControl();
                xtab = (XtraTabControl)sender;
                if (xtab != null)
                {
                    this.SelectedTabPageIndex = xtab.SelectedTabPageIndex;
                    //delegate - thong tin chuc nang
                    if (MyGetData != null)
                    {// tại đây gọi nó
                        MyGetData(xtab.TabPages[xtab.SelectedTabPageIndex].Tooltip);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        #endregion

        #region Custom
        private void gridViewDichVu_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (e.RowHandle == view.FocusedRowHandle)
                {
                    e.Appearance.BackColor = Color.LightGreen;
                    e.Appearance.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }


        #endregion

        #region Mo file
        private void btnMoFileXML_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialogSelect.ShowDialog() == DialogResult.OK)
                {
                    SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
                    this.lstXMLHoSo = new List<XML_HOSODTO>();
                    foreach (var item_file in openFileDialogSelect.FileNames)
                    {
                        List<XML_HOSODTO> _lstXmlHoSo = ConvertXMLFileToObject(item_file);
                        this.lstXMLHoSo.AddRange(_lstXmlHoSo);
                    }
                    SplashScreenManager.CloseForm();
                    if (this.lstXMLHoSo.Count > 0)
                    {
                        gridControlNoiDung.DataSource = this.lstXMLHoSo;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
                //SplashScreenManager.CloseForm();
            }
        }

        private List<XML_HOSODTO> ConvertXMLFileToObject(string filePath)
        {
            List<XML_HOSODTO> lstXmlHoSo = new List<XML_HOSODTO>();
            try
            {
                XML_GIAMDINHHS _giamDinhHS = Common.Xml.ObjectXMLSerializer<XML_GIAMDINHHS>.Load(filePath);

                foreach (var item_hoso in _giamDinhHS.THONGTINHOSO.DANHSACHHOSO.HOSOs)
                {
                    XML_HOSODTO _xmlHoSo = new XML_HOSODTO();
                    foreach (var item_loaiHS in item_hoso.FILEHOSOs)
                    {
                        if (item_loaiHS.LOAIHOSO == "XML1")
                        {
                            XML1_TagDTO _xml1_TagDto = Common.Xml.XmlConvert.DeserializeObject<XML1_TagDTO>(Common.EncryptAndDecrypt.Base64.Base64Decode(item_loaiHS.NOIDUNGFILE));

                            //-------Gan vao DTO
                            Mapper.Initialize(cfg => cfg.CreateMap<XML1_TagDTO, XML_HOSODTO>());
                            _xmlHoSo = AutoMapper.Mapper.Map<XML1_TagDTO, XML_HOSODTO>(_xml1_TagDto);

                            if (_xmlHoSo.NGAY_SINH.ToString().Length == 8)
                            {
                                _xmlHoSo.NGAY_SINH_DATE = DateTime.ParseExact(_xmlHoSo.NGAY_SINH, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                _xmlHoSo.NGAY_SINH_DATE = _xmlHoSo.NGAY_SINH;
                            }

                            switch (_xmlHoSo.GIOI_TINH)
                            {
                                case 1:
                                    _xmlHoSo.GIOI_TINH_TEN = "Nam";
                                    break;
                                case 2:
                                    _xmlHoSo.GIOI_TINH_TEN = "Nữ";
                                    break;
                                default:
                                    break;
                            }
                            if (_xmlHoSo.GT_THE_TU.ToString().Length == 8)
                            {
                                _xmlHoSo.GT_THE_TU_DATE = DateTime.ParseExact(_xmlHoSo.GT_THE_TU.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
                            }
                            if (_xmlHoSo.GT_THE_TU.ToString().Length == 8)
                            {
                                _xmlHoSo.GT_THE_DEN_DATE = DateTime.ParseExact(_xmlHoSo.GT_THE_DEN.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
                            }
                            switch (_xmlHoSo.MA_LYDO_VVIEN)
                            {
                                case 1:
                                    _xmlHoSo.LYDO_VVIEN_TEN = "Đúng tuyến";
                                    break;
                                case 2:
                                    _xmlHoSo.LYDO_VVIEN_TEN = "Cấp cứu";
                                    break;
                                case 3:
                                    _xmlHoSo.LYDO_VVIEN_TEN = "Trái tuyến";
                                    break;
                                default:
                                    break;
                            }
                            switch (_xmlHoSo.MA_TAI_NAN)
                            {
                                case "1":
                                    _xmlHoSo.TAI_NAN_TEN = "Tai nạn giao thông";
                                    break;
                                case "2":
                                    _xmlHoSo.TAI_NAN_TEN = "Tai nạn lao động";
                                    break;
                                case "3":
                                    _xmlHoSo.TAI_NAN_TEN = "Tai nạn dưới nước";
                                    break;
                                case "4":
                                    _xmlHoSo.TAI_NAN_TEN = "Bỏng";
                                    break;
                                case "5":
                                    _xmlHoSo.TAI_NAN_TEN = "Bạo lực, xung đột";
                                    break;
                                case "6":
                                    _xmlHoSo.TAI_NAN_TEN = "Tự tử";
                                    break;
                                case "7":
                                    _xmlHoSo.TAI_NAN_TEN = "Ngộ độc các loại";
                                    break;
                                case "8":
                                    _xmlHoSo.TAI_NAN_TEN = "Khác";
                                    break;
                                default:
                                    break;
                            }
                            if (_xmlHoSo.NGAY_VAO.ToString().Length == 12)
                            {
                                _xmlHoSo.NGAY_VAO_DATE = DateTime.ParseExact(_xmlHoSo.NGAY_VAO.ToString(), "yyyyMMddHHmm", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");
                            }
                            if (_xmlHoSo.NGAY_RA.ToString().Length == 12)
                            {
                                _xmlHoSo.NGAY_RA_DATE = DateTime.ParseExact(_xmlHoSo.NGAY_RA.ToString(), "yyyyMMddHHmm", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");
                            }
                            switch (_xmlHoSo.KET_QUA_DTRI)
                            {
                                case "1":
                                    _xmlHoSo.KET_QUA_DTRI_TEN = "Khỏi";
                                    break;
                                case "2":
                                    _xmlHoSo.KET_QUA_DTRI_TEN = "Đỡ";
                                    break;
                                case "3":
                                    _xmlHoSo.KET_QUA_DTRI_TEN = "Không thay đổi";
                                    break;
                                case "4":
                                    _xmlHoSo.KET_QUA_DTRI_TEN = "Nặng hơn";
                                    break;
                                case "5":
                                    _xmlHoSo.KET_QUA_DTRI_TEN = "Tử vong";
                                    break;
                                default:
                                    break;
                            }
                            switch (_xmlHoSo.TINH_TRANG_RV)
                            {
                                case "1":
                                    _xmlHoSo.TINH_TRANG_RV_TEN = "Ra viện";
                                    break;
                                case "2":
                                    _xmlHoSo.TINH_TRANG_RV_TEN = "Chuyển viện";
                                    break;
                                case "3":
                                    _xmlHoSo.TINH_TRANG_RV_TEN = "Trốn viện";
                                    break;
                                case "4":
                                    _xmlHoSo.TINH_TRANG_RV_TEN = "Xin ra viện";
                                    break;
                                default:
                                    break;
                            }
                            if (_xmlHoSo.NGAY_TTOAN.Length == 12)
                            {
                                _xmlHoSo.NGAY_TTOAN_DATE = DateTime.ParseExact(_xmlHoSo.NGAY_TTOAN, "yyyyMMddHHmm", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");
                            }
                            switch (_xmlHoSo.MA_LOAI_KCB)
                            {
                                case 1:
                                    _xmlHoSo.LOAI_KCB_TEN = "Khám bệnh";
                                    break;
                                case 2:
                                    _xmlHoSo.LOAI_KCB_TEN = "Điều trị ngoại trú";
                                    break;
                                case 3:
                                    _xmlHoSo.LOAI_KCB_TEN = "Điều trị nội trú";
                                    break;
                                default:
                                    break;
                            }

                        }
                        else if (item_loaiHS.LOAIHOSO == "XML2")
                        {
                            XML2_TagDTO _xml2_TagDto = Common.Xml.XmlConvert.DeserializeObject<XML2_TagDTO>(Common.EncryptAndDecrypt.Base64.Base64Decode(item_loaiHS.NOIDUNGFILE));
                            //
                            _xmlHoSo.lstXML2 = new List<XML2PlusDTO>();
                            _xmlHoSo.lstXML2.AddRange(_xml2_TagDto.lstXML2);

                            foreach (var item_xml2 in _xmlHoSo.lstXML2)
                            {
                                if (item_xml2.MA_NHOM != null && item_xml2.MA_NHOM != "")
                                {
                                    item_xml2.TEN_NHOM = GlobalStore.lstBang6CV9324.Where(o => o.MA_NHOM.ToString() == item_xml2.MA_NHOM).FirstOrDefault().TEN_NHOM;
                                }

                                if (item_xml2.NGAY_YL.ToString().Length == 12)
                                {
                                    item_xml2.NGAY_YL_DATE = DateTime.ParseExact(item_xml2.NGAY_YL, "yyyyMMddHHmm", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");
                                }

                                if (item_xml2.MA_PTTT == "0")
                                {
                                    item_xml2.PTTT_TEN = "Phí dịch vụ";
                                }
                                else if (item_xml2.MA_PTTT == "1")
                                {
                                    item_xml2.PTTT_TEN = "Định suất";
                                }
                                else if (item_xml2.MA_PTTT == "2")
                                {
                                    item_xml2.PTTT_TEN = "Ngoài định suất";
                                }
                                else if (item_xml2.MA_PTTT == "3")
                                {
                                    item_xml2.PTTT_TEN = "DRG";
                                }
                            }
                        }
                        else if (item_loaiHS.LOAIHOSO == "XML3")
                        {
                            XML3_TagDTO _xml3_TagDto = Common.Xml.XmlConvert.DeserializeObject<XML3_TagDTO>(Common.EncryptAndDecrypt.Base64.Base64Decode(item_loaiHS.NOIDUNGFILE));
                            //
                            _xmlHoSo.lstXML3 = new List<XML3PlusDTO>();
                            _xmlHoSo.lstXML3.AddRange(_xml3_TagDto.lstXML3);

                            foreach (var item_xml3 in _xmlHoSo.lstXML3)
                            {
                                if (item_xml3.MA_NHOM != null && item_xml3.MA_NHOM != "")
                                {
                                    item_xml3.TEN_NHOM = GlobalStore.lstBang6CV9324.Where(o => o.MA_NHOM.ToString() == item_xml3.MA_NHOM).FirstOrDefault().TEN_NHOM;
                                }

                                if (item_xml3.NGAY_YL.ToString().Length == 12)
                                {
                                    item_xml3.NGAY_YL_DATE = DateTime.ParseExact(item_xml3.NGAY_YL, "yyyyMMddHHmm", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");
                                }
                                if (item_xml3.NGAY_KQ.ToString().Length == 12)
                                {
                                    item_xml3.NGAY_KQ_DATE = DateTime.ParseExact(item_xml3.NGAY_KQ, "yyyyMMddHHmm", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");
                                }

                                if (item_xml3.MA_PTTT == "0")
                                {
                                    item_xml3.PTTT_TEN = "Phí dịch vụ";
                                }
                                else if (item_xml3.MA_PTTT == "1")
                                {
                                    item_xml3.PTTT_TEN = "Định suất";
                                }
                                else if (item_xml3.MA_PTTT == "2")
                                {
                                    item_xml3.PTTT_TEN = "Ngoài định suất";
                                }
                                else if (item_xml3.MA_PTTT == "3")
                                {
                                    item_xml3.PTTT_TEN = "DRG";
                                }
                            }
                        }
                        else if (item_loaiHS.LOAIHOSO == "XML4")
                        {
                            XML4_TagDTO _xml4_TagDto = Common.Xml.XmlConvert.DeserializeObject<XML4_TagDTO>(Common.EncryptAndDecrypt.Base64.Base64Decode(item_loaiHS.NOIDUNGFILE));
                            //
                            _xmlHoSo.lstXML4 = new List<XML4PlusDTO>();
                            _xmlHoSo.lstXML4.AddRange(_xml4_TagDto.lstXML4);
                        }
                        else if (item_loaiHS.LOAIHOSO == "XML5")
                        {
                            //TODO
                        }
                    }
                    _xmlHoSo.filePath = filePath;
                    lstXmlHoSo.Add(_xmlHoSo);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return lstXmlHoSo;
        }
        #endregion

        #region Events
        private void gridViewNoiDung_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
                {
                    //GridView view = sender as GridView;
                    e.Menu.Items.Clear();
                    DXMenuItem itemKiemHoSo = new DXMenuItem("Kiểm tra hồ sơ"); // caption menu
                    itemKiemHoSo.Image = imageCollectionDSBN.Images[0]; // icon cho menu
                    itemKiemHoSo.Click += new EventHandler(KiemTraMotHoSo_Click);// thêm sự kiện click
                    e.Menu.Items.Add(itemKiemHoSo);

                    DXMenuItem itemKiemTraDaChon = new DXMenuItem("Kiểm tra hồ sơ đã chọn"); // caption menu
                    itemKiemTraDaChon.Image = imageCollectionDSBN.Images[1]; // icon cho menu
                    itemKiemTraDaChon.Click += new EventHandler(KiemTraDaChon_Click);// thêm sự kiện click
                    e.Menu.Items.Add(itemKiemTraDaChon);
                    itemKiemTraDaChon.BeginGroup = true;

                    DXMenuItem itemKiemTraTatCa = new DXMenuItem("Kiểm tra tất cả hồ sơ"); // caption menu
                    itemKiemTraTatCa.Image = imageCollectionDSBN.Images[2]; // icon cho menu
                    itemKiemTraTatCa.Click += new EventHandler(KiemTraTatCa_Click);// thêm sự kiện click
                    e.Menu.Items.Add(itemKiemTraTatCa);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        //Kiem tra 01 ho so thi hien thi Check loi luon
        private void KiemTraMotHoSo_Click(object sender, EventArgs e)
        {
            try
            {
                CheckThongTuyenMotRow();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void KiemTraDaChon_Click(object sender, EventArgs e)
        {
            try
            {
                CheckThongTuyenRowDangChon();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void KiemTraTatCa_Click(object sender, EventArgs e)
        {
            try
            {
                CheckThongTuyenTatCaRowDangChon();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void btnKiemTraTatCa_Click(object sender, EventArgs e)
        {
            try
            {
                CheckThongTuyenTatCaRowDangChon();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        #endregion

        private void chkGhiNhoDuongDan_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkGhiNhoDuongDan.Checked)
                {
                    Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    _config.AppSettings.Settings["DuongDanDocFileXML"].Value = "";
                    _config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
                else
                {
                    Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    _config.AppSettings.Settings["DuongDanDocFileXML"].Value = "";
                    _config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void gridControlNoiDung_ViewRegistered(object sender, DevExpress.XtraGrid.ViewOperationEventArgs e)
        {
            try
            {
                (e.View as GridView).ColumnPanelRowHeight = 25;
                (e.View as GridView).RowHeight = 25;
                (e.View as GridView).OptionsView.ShowIndicator = false;
                (e.View as GridView).OptionsBehavior.Editable = false;

                //(e.View as GridView).Columns["MA_LK"].Caption = "Mã liên kết";
                //(e.View as GridView).Columns["STT"].Caption = "STT";
                //(e.View as GridView).Columns["MA_THUOC"].Caption = "Mã thuốc";
                //(e.View as GridView).Columns["TEN_NHOM"].Caption = "Tên nhóm";
                //(e.View as GridView).Columns["TEN_THUOC"].Caption = "Tên thuốc";
                //(e.View as GridView).Columns["DON_VI_TINH"].Caption = "ĐVT";
                //(e.View as GridView).Columns["HAM_LUONG"].Caption = "Hàm lượng";
                //(e.View as GridView).Columns["DUONG_DUNG"].Caption = "Đường dùng";
                //(e.View as GridView).Columns["LIEU_DUNG"].Caption = "Liều dùng";
                //(e.View as GridView).Columns["SO_DANG_KY"].Caption = "Số đăng ký";
                //(e.View as GridView).Columns["SO_LUONG"].Caption = "Số lượng";
                //(e.View as GridView).Columns["DON_GIA"].Caption = "Đơn giá";
                //(e.View as GridView).Columns["TYLE_TT"].Caption = "Tỷ lệ thanh toán";
                //(e.View as GridView).Columns["THANH_TIEN"].Caption = "Thành tiền";
                //(e.View as GridView).Columns["MA_KHOA"].Caption = "Mã khoa";
                //(e.View as GridView).Columns["MA_BAC_SI"].Caption = "Mã bác sĩ";
                //(e.View as GridView).Columns["MA_BENH"].Caption = "Mã bệnh";
                //(e.View as GridView).Columns["NGAY_YL_DATE"].Caption = "Ngày y lệnh";
                //(e.View as GridView).Columns["PTTT_TEN"].Caption = "Phương thức thanh toán";

                // (e.View as GridView).Columns["TEN_DICH_VU"].Caption = "Tên dịch vụ";

                (e.View as GridView).Columns["TEN_NHOM"].Visible = false;
                (e.View as GridView).Columns["NGAY_YL_DATE"].Visible = false;
                (e.View as GridView).Columns["PTTT_TEN"].Visible = false;
                //(e.View as GridView).Columns["MA_NHOM"].Visible = false;
                //(e.View as GridView).Columns["NGAY_YL"].Visible = false;
                //(e.View as GridView).Columns["MA_PTTT"].Visible = false;




                //(e.View as GridView).Columns["TEN_THUOC"].Width = 200;
                //(e.View as GridView).Columns["HAM_LUONG"].Width = 120;
                //(e.View as GridView).Columns["SO_DANG_KY"].Width = 120;
                //(e.View as GridView).Columns["NGAY_YL_DATE"].Width = 120;
                //(e.View as GridView).Columns["THANH_TIEN"].Width = 120;

                //(e.View as GridView).Columns["TEN_DICH_VU"].Width = 200;

                //(e.View as GridView).Columns["stt_lichsu"].OptionsColumn.AllowEdit = false;

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
    }
}
