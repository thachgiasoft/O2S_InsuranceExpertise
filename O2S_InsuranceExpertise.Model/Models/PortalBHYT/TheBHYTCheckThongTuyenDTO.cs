using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_InsuranceExpertise.Model.Models
{
   public class TheBHYTCheckThongTuyenDTO
    {
        public string maThe { get; set; }
        public string hoTen { get; set; }
        public string ngaySinh { get; set; } //DD/MM/YYYY
        public int gioiTinh { get; set; }//1: Nam ; 2: Nữ
        public string ngayBD { get; set; }//DD/MM/YYYY
        public string ngayKT { get; set; }//DD/MM/YYYY
        public string maCSKCB { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string token { get; set; }
        public string id_token { get; set; }

    }
}
