using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace O2S_InsuranceExpertise.Model.Models.Xml_917.XMLTag
{
    [XmlRootAttribute("DSACH_CHI_TIET_CLS", Namespace = "", IsNullable = false)]
    public class XML4_TagDTO
    {
        [XmlElement("CHI_TIET_CLS", typeof(XMLDTO.XML4DTO), Order = 1)]
        public List<XMLDTO.XML4DTO> lstXML4 { get; set; }
    }
}
