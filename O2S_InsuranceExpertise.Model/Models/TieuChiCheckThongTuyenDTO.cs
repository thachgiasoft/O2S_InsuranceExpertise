using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace O2S_InsuranceExpertise.Model.Models
{
    public class TieuChiCheckThongTuyenDTO
    {
        public DateTime tuNgay { get; set; }
        public DateTime denNgay { get; set; }
        public long departmentgroupid { get; set; }
        public string usercheck { get; set; }
    }
}