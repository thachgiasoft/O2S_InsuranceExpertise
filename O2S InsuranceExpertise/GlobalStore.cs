using O2S_InsuranceExpertise.DTO;
using O2S_InsuranceExpertise.Model.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_InsuranceExpertise
{
    public class GlobalStore
    {
        public static List<MrdServicerefDTO> GlobalLst_MrdServiceref { get; set; }
        public static List<MrdHsbaTemplateDTO> GlobalLst_MrdHsbaTemplate { get; set; }

        public static TokenDTO tokenSession { get; set; }

    }
}
