using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_InsuranceExpertise.Model.Models
{
    public class NhanChiTietLoiHoSoPortalDTO
    {
        public string maKetQua { get; set; }
        public List<LoiGiamDinh> dsLoi { get; set; }
    }

    public class LoiGiamDinh
    {
        public string maLoi { get; set; }
        public string moTaLoi { get; set; }
    }
}
