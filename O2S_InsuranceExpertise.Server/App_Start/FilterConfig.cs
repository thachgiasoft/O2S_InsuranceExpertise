using System.Web;
using System.Web.Mvc;

namespace O2S_InsuranceExpertise.Server
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
