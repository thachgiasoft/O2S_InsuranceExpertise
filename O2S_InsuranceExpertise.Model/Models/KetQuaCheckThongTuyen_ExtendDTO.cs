using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_InsuranceExpertise.Model.Models
{
    public class KetQuaCheckThongTuyen_ExtendDTO : IEBhytCheckDTO
    {
        public string maKetQua { get; set; }
        public string tenKetQua { get; set; }
        public string maLoi_CongGDBHYT { get; set; }
        public string tenLoi_CongGDBHYT { get; set; }
        public List<LichSuKCBDTO> dsLichSuKCB { get; set; }
    }


}
