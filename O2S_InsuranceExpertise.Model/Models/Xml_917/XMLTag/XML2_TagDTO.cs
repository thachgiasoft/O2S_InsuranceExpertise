using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace O2S_InsuranceExpertise.Model.Models.Xml_917.XMLTag
{
    [XmlRoot("DSACH_CHI_TIET_THUOC", Namespace = "", IsNullable = false)]
    public class XML2_TagDTO
    {
        [XmlElement("CHI_TIET_THUOC", typeof(XMLDTO.XML2PlusDTO))]
        public List<XMLDTO.XML2PlusDTO> lstXML2 { get; set; }
    }
}
