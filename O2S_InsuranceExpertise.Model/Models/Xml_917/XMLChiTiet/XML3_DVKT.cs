using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace O2S_InsuranceExpertise.Model.Models.Xml_917.XMLChiTiet
{
    [Serializable]
    public class XML3_DVKT
    {
        [XmlElement(Order = 1)]
        public string MA_LK { get; set; }
        [XmlElement(Order = 2)]
        public string STT { get; set; }
        [XmlElement(Order = 3)]
        public string MA_DICH_VU { get; set; }
        [XmlElement(Order = 4)]
        public string MA_VAT_TU { get; set; }
        [XmlElement(Order = 5)]
        public string MA_NHOM { get; set; }
        [XmlElement(Order = 6)]
        public string TEN_DICH_VU { get; set; }
        [XmlElement(Order = 7)]
        public string DON_VI_TINH { get; set; }
        [XmlElement(Order = 8)]
        public decimal? SO_LUONG { get; set; }
        [XmlElement(Order = 9)]
        public decimal? DON_GIA { get; set; }
        [XmlElement(Order = 10)]
        public int? TYLE_TT { get; set; }
        [XmlElement(Order = 11)]
        public decimal? THANH_TIEN { get; set; }
        [XmlElement(Order = 12)]
        public string MA_KHOA { get; set; }
        [XmlElement(Order = 13)]
        public string MA_BAC_SI { get; set; }
        [XmlElement(Order = 14)]
        public string MA_BENH { get; set; }
        [XmlElement(Order = 15)]
        public string NGAY_YL { get; set; }
        [XmlElement(Order = 16)]
        public string NGAY_KQ { get; set; }
        [XmlElement(Order = 17)]
        public string MA_PTTT { get; set; }


        public XML3_DVKT()
        {
        }

        public XML3_DVKT(XMLDTO.XML3DTO dataXML3)
        {
            this.MA_LK = dataXML3.MA_LK;
            this.STT = dataXML3.STT;
            this.MA_DICH_VU = dataXML3.MA_DICH_VU;
            this.MA_VAT_TU = dataXML3.MA_VAT_TU;
            this.MA_NHOM = dataXML3.MA_NHOM;
            this.TEN_DICH_VU = dataXML3.TEN_DICH_VU;
            this.DON_VI_TINH = dataXML3.DON_VI_TINH;
            this.SO_LUONG = dataXML3.SO_LUONG;
            this.DON_GIA = dataXML3.DON_GIA;
            this.TYLE_TT = dataXML3.TYLE_TT;
            this.THANH_TIEN = dataXML3.THANH_TIEN;
            this.MA_KHOA = dataXML3.MA_KHOA;
            this.MA_BAC_SI = dataXML3.MA_BAC_SI;
            this.MA_BENH = dataXML3.MA_BENH;
            this.NGAY_YL = dataXML3.NGAY_YL;
            this.NGAY_KQ = dataXML3.NGAY_KQ;
            this.MA_PTTT = dataXML3.MA_PTTT;

        }
    }
}
