using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace O2S_InsuranceExpertise.Server.Models
{
    public class Error
    {
        public int ID { set; get; }
        public string Message { set; get; }
        public string StackTrace { set; get; }
        public DateTime CreatedDate { set; get; }
    }
}