using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_InsuranceExpertise.Model.Models.Xml_917.XMLDTO
{
    public class XML_HOSODTO : XML1DTO
    {
        public List<XML2DTO> lstXML2 { get; set; }
        public List<XML3DTO> lstXML3 { get; set; }
        public List<XML4DTO> lstXML4 { get; set; }
        public List<XML5DTO> lstXML5 { get; set; }

    }
}
