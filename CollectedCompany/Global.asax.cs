using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CollectedCompany.App_Start;
using CollectedCompany.Plugins;

namespace CollectedCompany
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            AutomapperConfig.Register();
            DotLessConfig.Configure();
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new CustomViewEngine());
        }
    }
}
