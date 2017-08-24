using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace O2S_InsuranceExpertise.Model.Models.Xml_917.XMLChiTiet
{
    [Serializable]
    public class XML1_ThongTinBenhNhan
    {
        [XmlElement(Order = 1)]
        public string MA_LK { get; set; }
        [XmlElement(Order = 2)]
        public string STT { get; set; }
        [XmlElement(Order = 3)]
        public string MA_BN { get; set; }
        [XmlElement(Order = 4)]
        public string HO_TEN { get; set; }
        [XmlElement(Order = 5)]
        public string NGAY_SINH { get; set; }
        [XmlElement(Order = 6)]
        public int? GIOI_TINH { get; set; }
        [XmlElement(Order = 7)]
        public string DIA_CHI { get; set; }
        [XmlElement(Order = 8)]
        public string MA_THE { get; set; }
        [XmlElement(Order = 9)]
        public string MA_DKBD { get; set; }
        [XmlElement(Order = 10)]
        public long GT_THE_TU { get; set; }
        [XmlElement(Order = 11)]
        public long GT_THE_DEN { get; set; }
        [XmlElement(Order = 12)]
        public string TEN_BENH { get; set; }
        [XmlElement(Order = 13)]
        public string MA_BENH { get; set; }
        [XmlElement(Order = 14)]
        public string MA_BENHKHAC { get; set; }
        [XmlElement(Order = 15)]
        public int? MA_LYDO_VVIEN { get; set; }
        [XmlElement(Order = 16)]
        public string MA_NOI_CHUYEN { get; set; }
        [XmlElement(Order = 17)]
        public string MA_TAI_NAN { get; set; }
        [XmlElement(Order = 18)]
        public long NGAY_VAO { get; set; }
        [XmlElement(Order = 19)]
        public long NGAY_RA { get; set; }
        [XmlElement(Order = 20)]
        public decimal? SO_NGAY_DTRI { get; set; }
        [XmlElement(Order = 21)]
        public string KET_QUA_DTRI { get; set; }
        [XmlElement(Order = 22)]
        public string TINH_TRANG_RV { get; set; }
        [XmlElement(Order = 23)]
        public string NGAY_TTOAN { get; set; }
        [XmlElement(Order = 24)]
        public int? MUC_HUONG { get; set; }
        [XmlElement(Order = 25)]
        public decimal? T_THUOC { get; set; }
        [XmlElement(Order = 26)]
        public decimal? T_VTYT { get; set; }
        [XmlElement(Order = 27)]
        public decimal? T_TONGCHI { get; set; }
        [XmlElement(Order = 28)]
        public decimal? T_BNTT { get; set; }
        [XmlElement(Order = 29)]
        public decimal? T_BHTT { get; set; }
        [XmlElement(Order = 30)]
        public decimal? T_NGUONKHAC { get; set; }
        [XmlElement(Order = 31)]
        public decimal? T_NGOAIDS { get; set; }
        [XmlElement(Order = 32)]
        public int? NAM_QT { get; set; }
        [XmlElement(Order = 33)]
        public int? THANG_QT { get; set; }
        [XmlElement(Order = 34)]
        public int? MA_LOAI_KCB { get; set; }
        [XmlElement(Order = 35)]
        public string MA_KHOA { get; set; }
        [XmlElement(Order = 36)]
        public int? MA_CSKCB { get; set; }
        [XmlElement(Order = 37)]
        public string MA_KHUVUC { get; set; }
        [XmlElement(Order = 38)]
        public string MA_PTTT_QT { get; set; }
        [XmlElement(Order = 39)]
        public string CAN_NANG { get; set; }

        public XML1_ThongTinBenhNhan()
        {
        }

        public XML1_ThongTinBenhNhan(XMLDTO.XML1DTO dataXML1)
        {
            this.MA_LK = dataXML1.MA_LK;
            this.STT = dataXML1.STT;
            this.MA_BN = dataXML1.MA_BN;
            this.HO_TEN = dataXML1.HO_TEN;
            this.NGAY_SINH = dataXML1.NGAY_SINH;
            this.GIOI_TINH = dataXML1.GIOI_TINH;
            this.DIA_CHI = dataXML1.DIA_CHI;
            this.MA_THE = dataXML1.MA_THE;
            this.MA_DKBD = dataXML1.MA_DKBD;
            this.GT_THE_TU = dataXML1.GT_THE_TU;
            this.GT_THE_DEN = dataXML1.GT_THE_DEN;
            this.TEN_BENH = dataXML1.TEN_BENH;
            this.MA_BENH = dataXML1.MA_BENH;
            this.MA_BENHKHAC = dataXML1.MA_BENHKHAC;
            this.MA_LYDO_VVIEN = dataXML1.MA_LYDO_VVIEN;
            this.MA_NOI_CHUYEN = dataXML1.MA_NOI_CHUYEN;
            this.MA_TAI_NAN = dataXML1.MA_TAI_NAN;
            this.NGAY_VAO = dataXML1.NGAY_VAO;
            this.NGAY_RA = dataXML1.NGAY_RA;
            this.SO_NGAY_DTRI = dataXML1.SO_NGAY_DTRI;
            this.KET_QUA_DTRI = dataXML1.KET_QUA_DTRI;
            this.TINH_TRANG_RV = dataXML1.TINH_TRANG_RV;
            this.NGAY_TTOAN = dataXML1.NGAY_TTOAN;
            this.MUC_HUONG = dataXML1.MUC_HUONG;
            this.T_THUOC = dataXML1.T_THUOC;
            this.T_VTYT = dataXML1.T_VTYT;
            this.T_TONGCHI = dataXML1.T_TONGCHI;
            this.T_BNTT = dataXML1.T_BNTT;
            this.T_BHTT = dataXML1.T_BHTT;
            this.T_NGUONKHAC = dataXML1.T_NGUONKHAC;
            this.T_NGOAIDS = dataXML1.T_NGOAIDS;
            this.NAM_QT = dataXML1.NAM_QT;
            this.THANG_QT = dataXML1.THANG_QT;
            this.MA_LOAI_KCB = dataXML1.MA_LOAI_KCB;
            this.MA_KHOA = dataXML1.MA_KHOA;
            this.MA_CSKCB = dataXML1.MA_CSKCB;
            this.MA_KHUVUC = dataXML1.MA_KHUVUC;
            this.MA_PTTT_QT = dataXML1.MA_PTTT_QT;
            this.CAN_NANG = dataXML1.CAN_NANG;
        }
    }
}
