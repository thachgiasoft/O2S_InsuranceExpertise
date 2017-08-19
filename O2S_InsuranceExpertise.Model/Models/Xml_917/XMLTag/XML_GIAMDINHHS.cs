using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace O2S_InsuranceExpertise.Model.Models.Xml_917.XMLTag
{
    [XmlRootAttribute("GIAMDINHHS", Namespace = "", IsNullable = false)]
    public class XML_GIAMDINHHS
    {
        [XmlElement("THONGTINDONVI", typeof(XML_THONGTINDONVI), Order = 1)]
        public XML_THONGTINDONVI THONGTINDONVI { get; set; }

        [XmlElement("THONGTINHOSO", typeof(XML_THONGTINHOSO), Order = 2)]
        public XML_THONGTINHOSO THONGTINHOSO { get; set; }

        [XmlElement("CHUKYDONVI", typeof(string), Order = 3)]
        public string CHUKYDONVI { get; set; }
    }
}
