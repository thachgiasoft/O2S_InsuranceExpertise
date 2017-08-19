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
    public class XML_TTHS_DSHS_HOSO
    {
        [XmlElement("FILEHOSO", typeof(XML_TTHS_DSHS_HS_FILEHOSO), Order = 1)]
        public List<XML_TTHS_DSHS_HS_FILEHOSO> FILEHOSOs { set; get; }

        //[XmlElement("FILEHOSO", typeof(XML_TTHS_DSHS_HS_FILEHOSO), Order = 1)]
        //public ArrayList FILEHOSOs = new ArrayList();
    }
}
