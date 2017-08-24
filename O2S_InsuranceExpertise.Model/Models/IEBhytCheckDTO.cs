using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace O2S_InsuranceExpertise.Model.Models
{
    public class IEBhytCheckDTO
    {
        public long stt { get; set; }
        public long bhytcheckid { get; set; }
        public long bhytid { get; set; }
        public long hosobenhanid { get; set; }
        public long vienphiid { get; set; }
        public long patientid { get; set; }
        public string patientname { get; set; }
        public object birthday { get; set; }
        public string birthday_year { get; set; }
        public string gioitinhcode { get; set; }
        public string gioitinhname { get; set; }
        public string bhytcode { get; set; }
        public string macskcbbd { get; set; }
        public object bhytdate { get; set; }
        public object bhytfromdate { get; set; }
        public object bhytutildate { get; set; }
        public long bhyt_loaiid { get; set; }
        public string noisinhsong { get; set; }
        public long du5nam6thangluongcoban { get; set; }
        public long dtcbh_luyke6thang { get; set; }
        public long bhytcheckstatus { get; set; }
        public object bhytchecksdate { get; set; }
        public long departmentgroupid { get; set; }
        public long departmentid { get; set; }
        public string departmentgroupname { get; set; }
        public string departmentname { get; set; }
        public object hosobenhandate { get; set; }
        public object hosobenhandate_ravien { get; set; }
        public object lastupdatedate_hsba { get; set; }
        public object lastupdatedate_bhyt { get; set; }
        public string bhytchecknote { get; set; }
        public string usercheck { get; set; }
    }
}