using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_InsuranceExpertise.Model.Models
{
    public class LichSuKhamChuaBenhDTO: IEBhytCheckDTO
    {
        public string maKetQua { get; set; }
        public string tenKetQua { get; set; }
        public string maLoi_CongGDBHYT { get; set; }
        public List<LichSuKCBDTO> dsLichSuKCB { get; set; }
    }

    public class LichSuKCBDTO
    {
        public long stt_lichsu { get; set; }
        public string maHoSo { get; set; }
        public string maCSKCB { get; set; }
        public string tuNgay { get; set; }
        public string denNgay { get; set; }
        public string tenBenh { get; set; }
        public string tinhTrang { get; set; }
        public string tinhTrang_Ten { get; set; }
        public string kqDieuTri { get; set; }
        public string kqDieuTri_Ten { get; set; }

    }
}
