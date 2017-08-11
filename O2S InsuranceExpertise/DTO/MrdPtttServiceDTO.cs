﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_InsuranceExpertise.DTO
{
    public class MrdPtttServiceDTO
    {
        public long ie_pttt_serviceid { get; set; }
        public long servicepriceid { get; set; }
        public string servicepricecode { get; set; }
        public long maubenhphamid { get; set; }
        public long patientid { get; set; }
        public long vienphiid { get; set; }
        public long hosobenhanid { get; set; }
        public long InsuranceExpertiseid { get; set; }
        public long ie_pttttemid { get; set; }
        public long departmentgroupid { get; set; }
        public long departmentid { get; set; }
        public string ie_pttt_servicedata { get; set; }
        public string ie_pttt_servicedata_nd { get; set; }
        public long ie_pttt_servicestatus { get; set; }
        public long create_userid { get; set; }
        public long create_mrduserid { get; set; }
        public long create_hisuserid { get; set; }
        public string create_hisusercode { get; set; }
        public DateTime create_date { get; set; }
        public long modify_userid { get; set; }
        public DateTime modify_date { get; set; }
        public string note { get; set; }
        public bool file_readonly { get; set; }
    }
}
