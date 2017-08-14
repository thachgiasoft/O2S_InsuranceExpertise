using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace O2S_InsuranceExpertise.Server
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure();
                Newtonsoft.Json.JsonConvert.DefaultSettings = () => new Newtonsoft.Json.JsonSerializerSettings
                {
                    Formatting = Newtonsoft.Json.Formatting.None,
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                };
                AreaRegistration.RegisterAllAreas();
                GlobalConfiguration.Configure(WebApiConfig.Register);
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);

                Common.Logging.LogSystem.Info("API services InsuranceExpertise Start. Time=" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Info("API services InsuranceExpertise Start error: " + ex.Message + ". Time=" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            }
        }
        protected void Application_End()
        {
            Common.Logging.LogSystem.Info("API services InsuranceExpertise End. Time=" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
        }
    }
}
