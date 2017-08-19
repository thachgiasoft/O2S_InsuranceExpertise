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
    public class XML_TTHS_DSHS_HS_FILEHOSO
    {
        [XmlElement(Order = 1)]
        public string LOAIHOSO { get; set; }
        [XmlElement(Order = 2)]
        public string NOIDUNGFILE { get; set; }
        public XML_TTHS_DSHS_HS_FILEHOSO()
        {
        }

        public XML_TTHS_DSHS_HS_FILEHOSO(string LOAIHOSO, string NOIDUNGFILE) 
        {
            this.LOAIHOSO = LOAIHOSO;
            this.NOIDUNGFILE = NOIDUNGFILE;// Noi dung file Ma Hoa Base 64
        }
    }
}
