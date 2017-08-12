using O2S_InsuranceExpertise.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace O2S_InsuranceExpertise.Server
{
    public class GlobalStore
    {
        public static TokenDTO tokenSession { get; set; }
        public static string UserName_GDBHYT {get;set;}
        public static string Password_GDBHYT { get; set; }
        public static string Password_GDBHYT_MD5 { get; set; }
    }
}