using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace O2S_InsuranceExpertise.Model.Models.Xml_917.XMLTag
{
    [XmlRootAttribute("DSACH_CHI_TIET_DVKT", Namespace = "", IsNullable = false)]
    public class XML3_TagDTO
    {
        [XmlElement("CHI_TIET_DVKT", typeof(XMLDTO.XML3PlusDTO), Order = 1)]
        public List<XMLDTO.XML3PlusDTO> lstXML3 { get; set; }
    }
}
