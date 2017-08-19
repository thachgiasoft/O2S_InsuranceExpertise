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
    public class XML_TTHS_DANHSACHHOSO
    {
        //[XmlArray("HOSO"), XmlArrayItem("FILEHOSO", typeof(XML_TTHS_DSHS_HS_FILEHOSO))]
        //public ArrayList DANHSACHHOSO_HOSO_FILEHOSO = new ArrayList();

        [XmlElement("HOSO", typeof(XML_TTHS_DSHS_HOSO), Order = 1)]
        public List<XML_TTHS_DSHS_HOSO> HOSOs { get; set; }

    }
}
