using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_InsuranceExpertise.Model.Models
{
    public class DanhSachBenhVienDTO
    {
        public long stt { get; set; }
        public long benhvienid { get; set; }
        public string benhvienkcbbd { get; set; }
        public string benhviencode { get; set; }
        public string benhvienname { get; set; }
        public string benhvienname_khongdau { get; set; }
        public string benhvienaddress { get; set; }
        public string benhvienaddress_khongdau { get; set; }
        public string benhvienhang { get; set; }
        public string benhvientuyen { get; set; }
        public string ghichu { get; set; }
    }
}
