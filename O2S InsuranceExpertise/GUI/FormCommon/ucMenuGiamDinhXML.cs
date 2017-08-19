using System;
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
                    string[] filePahts = System.IO.Directory.GetFiles(ConfigurationManager.AppSettings["DuongDanDocFileXML"].ToString(), "*.xml");
                    foreach (var item in filePahts)
                    {
                        //toto Read file XML

                    }
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

        #region mMo file
        private void btnMoFileXML_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialogSelect.ShowDialog() == DialogResult.OK)
                {
                    this.lstXMLHoSo = new List<XML_HOSODTO>();
                    foreach (var item_file in openFileDialogSelect.FileNames)
                    {
                        XML_HOSODTO _xmlHoSo = ConvertXMLFileToObject(item_file);
                        this.lstXMLHoSo.Add(_xmlHoSo);
                    }
                }
                if (this.lstXMLHoSo.Count > 0)
                {
                    gridControlNoiDung.DataSource = this.lstXMLHoSo;
                }

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private XML_HOSODTO ConvertXMLFileToObject(string filePath)
        {
            XML_HOSODTO _xmlHoSo = new XML_HOSODTO();
            try
            {
                XML_GIAMDINHHS _giamDinhHS = Common.Xml.ObjectXMLSerializer<XML_GIAMDINHHS>.Load(filePath);

                foreach (var item_hoso in _giamDinhHS.THONGTINHOSO.DANHSACHHOSO.HOSOs)
                {
                    foreach (var item_loaiHS in item_hoso.FILEHOSOs)
                    {
                        if (item_loaiHS.LOAIHOSO == "XML1")
                        {
                            XML1_TagDTO _xml1_TagDto = Common.Xml.XmlConvert.DeserializeObject<XML1_TagDTO>(Common.EncryptAndDecrypt.Base64.Base64Decode(item_loaiHS.NOIDUNGFILE));

                            //-------Gan vao DTO
                            Mapper.Initialize(cfg => cfg.CreateMap<XML1_TagDTO, XML_HOSODTO>());
                            _xmlHoSo = AutoMapper.Mapper.Map<XML1_TagDTO, XML_HOSODTO>(_xml1_TagDto);
                        }
                        else if (item_loaiHS.LOAIHOSO == "XML2")
                        {
                            XML2_TagDTO _xml2_TagDto = Common.Xml.XmlConvert.DeserializeObject<XML2_TagDTO>(Common.EncryptAndDecrypt.Base64.Base64Decode(item_loaiHS.NOIDUNGFILE));
                            //
                            _xmlHoSo.lstXML2 = new List<XML2DTO>();
                            _xmlHoSo.lstXML2.AddRange(_xml2_TagDto.lstXML2);
                        }
                        else if (item_loaiHS.LOAIHOSO == "XML3")
                        {
                            XML3_TagDTO _xml3_TagDto = Common.Xml.XmlConvert.DeserializeObject<XML3_TagDTO>(Common.EncryptAndDecrypt.Base64.Base64Decode(item_loaiHS.NOIDUNGFILE));
                            //
                            _xmlHoSo.lstXML3 = new List<XML3DTO>();
                            _xmlHoSo.lstXML3.AddRange(_xml3_TagDto.lstXML3);
                        }
                        else if (item_loaiHS.LOAIHOSO == "XML4")
                        {
                            XML4_TagDTO _xml4_TagDto = Common.Xml.XmlConvert.DeserializeObject<XML4_TagDTO>(Common.EncryptAndDecrypt.Base64.Base64Decode(item_loaiHS.NOIDUNGFILE));
                            //
                            _xmlHoSo.lstXML4 = new List<XML4DTO>();
                            _xmlHoSo.lstXML4.AddRange(_xml4_TagDto.lstXML4);
                        }
                        else if (item_loaiHS.LOAIHOSO == "XML5")
                        {
                            //TODO
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return _xmlHoSo;
        }
        #endregion

    }
}
