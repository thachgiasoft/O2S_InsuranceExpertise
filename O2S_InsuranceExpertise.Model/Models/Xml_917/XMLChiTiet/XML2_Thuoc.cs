using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace O2S_InsuranceExpertise.Model.Models.Xml_917.XMLChiTiet
{
    [Serializable]
    public class XML2_Thuoc
    {
        [XmlElement(Order = 1)]
        public string MA_LK { get; set; }
        [XmlElement(Order = 2)]
        public long STT { get; set; }
        [XmlElement(Order = 3)]
        public string MA_THUOC { get; set; }
        [XmlElement(Order = 4)]
        public string MA_NHOM { get; set; }
        [XmlElement(Order = 5)]
        public string TEN_THUOC { get; set; }
        [XmlElement(Order = 6)]
        public string DON_VI_TINH { get; set; }
        [XmlElement(Order = 7)]
        public string HAM_LUONG { get; set; }
        [XmlElement(Order = 8)]
        public string DUONG_DUNG { get; set; }
        [XmlElement(Order = 9)]
        public string LIEU_DUNG { get; set; }
        [XmlElement(Order = 10)]
        public string SO_DANG_KY { get; set; }
        [XmlElement(Order = 11)]
        public decimal SO_LUONG { get; set; }
        [XmlElement(Order = 12)]
        public decimal DON_GIA { get; set; }
        [XmlElement(Order = 13)]
        public int TYLE_TT { get; set; }
        [XmlElement(Order = 14)]
        public decimal THANH_TIEN { get; set; }
        [XmlElement(Order = 15)]
        public string MA_KHOA { get; set; }
        [XmlElement(Order = 16)]
        public string MA_BAC_SI { get; set; }
        [XmlElement(Order = 17)]
        public string MA_BENH { get; set; }
        [XmlElement(Order = 18)]
        public string NGAY_YL { get; set; }
        [XmlElement(Order = 19)]
        public int MA_PTTT { get; set; }

        public XML2_Thuoc()
        {
        }

        public XML2_Thuoc(XMLDTO.XML2DTO dataXML2)
        {
            this.MA_LK = dataXML2.MA_LK;
            this.STT = dataXML2.STT;
            this.MA_THUOC = dataXML2.MA_THUOC;
            this.MA_NHOM = dataXML2.MA_NHOM;
            this.TEN_THUOC = dataXML2.TEN_THUOC;
            this.DON_VI_TINH = dataXML2.DON_VI_TINH;
            this.HAM_LUONG = dataXML2.HAM_LUONG;
            this.DUONG_DUNG = dataXML2.DUONG_DUNG;
            this.LIEU_DUNG = dataXML2.LIEU_DUNG;
            this.SO_DANG_KY = dataXML2.SO_DANG_KY;
            this.SO_LUONG = dataXML2.SO_LUONG;
            this.DON_GIA = dataXML2.DON_GIA;
            this.TYLE_TT = dataXML2.TYLE_TT;
            this.THANH_TIEN = dataXML2.THANH_TIEN;
            this.MA_KHOA = dataXML2.MA_KHOA;
            this.MA_BAC_SI = dataXML2.MA_BAC_SI;
            this.MA_BENH = dataXML2.MA_BENH;
            this.NGAY_YL = dataXML2.NGAY_YL;
            this.MA_PTTT = dataXML2.MA_PTTT;
        }
    }
}
