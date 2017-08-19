using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace O2S_InsuranceExpertise.Model.Models.Xml_917.XMLTag
{
    [Serializable]
    public class XML_THONGTINHOSO
    {
        [XmlElement("NGAYLAP", typeof(string), Order = 1)]
        public string NGAYLAP { get; set; }

        [XmlElement("SOLUONGHOSO", typeof(string), Order = 2)]
        public string SOLUONGHOSO { get; set; }

        [XmlElement("DANHSACHHOSO", typeof(XML_TTHS_DANHSACHHOSO), Order = 3)]
        public XML_TTHS_DANHSACHHOSO DANHSACHHOSO { get; set; }
    }
}
