using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_InsuranceExpertise.Model.Models.Xml_917.XMLDTO
{
    public class XML_HOSODTO : XML1PlusDTO
    {
        public List<XML2PlusDTO> lstXML2 { get; set; }
        public List<XML3PlusDTO> lstXML3 { get; set; }
        public List<XML4PlusDTO> lstXML4 { get; set; }
        public List<XML5DTO> lstXML5 { get; set; }
        public string filePath { get; set; }
    }
}
