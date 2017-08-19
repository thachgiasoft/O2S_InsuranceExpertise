using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace O2S_InsuranceExpertise.Model.Models.Xml_917.XMLChiTiet
{
    [Serializable]
    public class XML4_CLS
    {
        [XmlElement(Order = 1)]
        public string MA_LK { get; set; }
        [XmlElement(Order = 2)]
        public long STT { get; set; }
        [XmlElement(Order = 3)]
        public string MA_DICH_VU { get; set; }
        [XmlElement(Order = 4)]
        public string MA_CHI_SO { get; set; }
        [XmlElement(Order = 5)]
        public string TEN_CHI_SO { get; set; }
        [XmlElement(Order = 6)]
        public string GIA_TRI { get; set; }
        [XmlElement(Order = 7)]
        public string MA_MAY { get; set; }
        [XmlElement(Order = 8)]
        public string MO_TA { get; set; }
        [XmlElement(Order = 9)]
        public string KET_LUAN { get; set; }
        [XmlElement(Order = 10)]
        public string NGAY_KQ { get; set; }

        public XML4_CLS()
        {
        }

        public XML4_CLS(XMLDTO.XML4DTO dataXML4)
        {
            this.MA_LK = dataXML4.MA_LK;
            this.STT = dataXML4.STT;
            this.MA_DICH_VU = dataXML4.MA_DICH_VU;
            this.MA_CHI_SO = dataXML4.MA_CHI_SO;
            this.TEN_CHI_SO = dataXML4.TEN_CHI_SO;
            this.GIA_TRI = dataXML4.GIA_TRI;
            this.MA_MAY = dataXML4.MA_MAY;
            this.MO_TA = dataXML4.MO_TA;
            this.KET_LUAN = dataXML4.KET_LUAN;
            this.NGAY_KQ = dataXML4.NGAY_KQ;

        }
    }
}
