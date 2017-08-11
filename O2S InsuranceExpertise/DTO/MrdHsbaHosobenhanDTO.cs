﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_InsuranceExpertise.DTO
{
    public class MrdHsbaHosobenhanDTO
    {
        public long ie_hsba_hosobenhanid { get; set; }
        public long hosobenhanid { get; set; }
        public long InsuranceExpertiseid { get; set; }
        public long patientid { get; set; }
        public long vienphiid { get; set; }
        public long ie_hsbatemid { get; set; }
        public long departmentgroupid { get; set; }
        public long departmentid { get; set; }
        public string ie_hsba_hosobenhandata { get; set; }
        public string ie_hsba_hosobenhandata_nd { get; set; }
        public long ie_hsba_hosobenhanstatus { get; set; }
        public long create_mrduserid { get; set; }
        public string create_mrdusercode { get; set; }
        public long create_hisuserid { get; set; }
        public string create_hisusercode { get; set; }
        public DateTime create_date { get; set; }
        public long modify_mrduserid { get; set; }
        public string modify_mrdusercode { get; set; }
        public DateTime modify_date { get; set; }
        public string note { get; set; }
        public bool file_readonly { get; set; }

    }
}
