using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace O2S_InsuranceExpertise.Model.Models.Xml_917.XMLChiTiet
{
    [Serializable]
    public class XML5_DienBien
    {
        [XmlElement(Order = 1)]
        public string MA_LK { get; set; }
        [XmlElement(Order = 2)]
        public long STT { get; set; }
        [XmlElement(Order = 3)]
        public string DIEN_BIEN { get; set; }
        [XmlElement(Order = 4)]
        public string HOI_CHAN { get; set; }
        [XmlElement(Order = 5)]
        public string PHAU_THUAT { get; set; }
        [XmlElement(Order = 6)]
        public string NGAY_YL { get; set; }

        public XML5_DienBien()
        {
        }

        public XML5_DienBien(XMLDTO.XML5DTO dataXML5)
        {
            this.MA_LK = dataXML5.MA_LK;
            this.STT = dataXML5.STT;
            this.DIEN_BIEN = dataXML5.DIEN_BIEN;
            this.HOI_CHAN = dataXML5.HOI_CHAN;
            this.PHAU_THUAT = dataXML5.PHAU_THUAT;
            this.NGAY_YL = dataXML5.NGAY_YL;

        }
    }
}
