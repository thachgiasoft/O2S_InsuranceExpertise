using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_InsuranceExpertise.Model.Models.GiamDinh
{
    public class GiamDinhLoiDTO
    {
        public List<GiamDinhLoi_XML1DTO> lstGiamDinhLoiXML1 { get; set; }
        public List<GiamDinhLoi_DVKTDTO> lstGiamDinhLoiDVKT { get; set; }

    }
}
