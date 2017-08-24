using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_InsuranceExpertise.Model.Models
{
    public class TheFileXMLDTO
    {
        public long thefilexmlid { get; set; }
        public long STT { get; set; }
        public string MA_THE { get; set; }
        public string TEN_THE { get; set; }
        public string KIEU_DU_LIEU { get; set; }
        public long KT_TOIDA { get; set; }
        public int BAT_BUOC { get; set; }
        public string DIEN_GIAI { get; set; }
        public string GHI_CHU { get; set; }
    }
}
