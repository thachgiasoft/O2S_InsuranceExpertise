using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_InsuranceExpertise.Model.Models
{
   public class TokenDTO
    {
        public string maKetQua { get; set; }
        public APIKeyDTO APIKey { get; set; }
    }

    public class APIKeyDTO
    {
        public string access_token { get; set; }
        public string id_token { get; set; }
        public object expires_in { get; set; }
        public string token_type {get;set;}
    }
}
