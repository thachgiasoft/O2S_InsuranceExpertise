using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace O2S_InsuranceExpertise.Model.Models.Xml_917.XMLTag
{
    [Serializable]
    public class XML_THONGTINDONVI
    {
        [XmlElement(Order = 1)]
        public string MACSKCB { get; set; }

        public XML_THONGTINDONVI()
        {
        }

        public XML_THONGTINDONVI(string MACSKCB)
        {
            this.MACSKCB = MACSKCB;
        }
    }
}
