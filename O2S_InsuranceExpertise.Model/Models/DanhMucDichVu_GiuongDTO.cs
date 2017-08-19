using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_InsuranceExpertise.Model.Models
{
  public  class DanhMucDichVu_GiuongDTO
    {
        public long danhmucgiuongid { get; set; }
        public long STT { get; set; }
        public string MA_DVKT { get; set; }
        public string MA_AX { get; set; }
        public string TEN_DVKT { get; set; }
        public string TEN_AX { get; set; }
        public string MA_GIA { get; set; }
        public decimal DON_GIA { get; set; }
        public decimal GIA_AX { get; set; }
        public string QUYET_DINH { get; set; }
        public long CONG_BO { get; set; }
        public long MA_COSOKCB { get; set; }
        public long MANHOM_9324 { get; set; }
        public string HIEULUC { get; set; }
        public int HIEULUC_ID { get; set; }
        public string KETQUA { get; set; }
        public int KETQUA_ID { get; set; }
        public string LYDOTUCHOI { get; set; }
        public int is_look { get; set; }

    }
}
