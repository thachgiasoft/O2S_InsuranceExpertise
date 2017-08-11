using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace O2S_InsuranceExpertise.Model.Models
{
    public class TieuChiCheckDTO
    {
        public DateTime tuNgay { get; set; }
        public DateTime denNgay { get; set; }
        public long departmentgroupid { get; set; }
        public long hosobenhanid { get; set; }
    }
}