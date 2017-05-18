using Khuluma_Server.QuartzJobs;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace Khuluma_Server
{
    public class MvcApplication : System.Web.HttpApplication
    {
        JobScheduler jobScheduler;
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            jobScheduler = new JobScheduler();
            jobScheduler.Start();
           
        }
    }
}
