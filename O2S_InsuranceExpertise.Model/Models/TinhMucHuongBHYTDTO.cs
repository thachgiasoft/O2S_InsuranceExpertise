using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_InsuranceExpertise.Model.Models
{
 public   class TinhMucHuongBHYTDTO
    {
        public decimal TONG_CHIPHI_KCB { get; set; }
        public int TUYEN_BENH_VIEN { get; set; } // 1=huyen; 2=tinh; 3=TW
        public decimal LUONG_CO_BAN { get; set; }
        public string BHYT_CODE { get; set; }
        public int BHYT_LOAI { get; set; } //=1 đúng tuyến; =2: đúng tuyến giới thiệu; =3 đúng tuyến cấp cứu; =4 trái tuyến
        public int LOAI_VIEN_PHI { get; set; }//0=nội trú; 1=ngoại trú
        public int DU_5NAM_6THANG { get; set; }
        public int DU_5NAM { get; set; }
        public int KHU_VUC_SONG { get; set; } //1=K1; 2=K2; 3=K3



    }
}
