using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using webMobileShop.App_Start;

namespace webMobileShop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            UnityConfig.RegisterComponents(); //Method call to Complete the Component Registration
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
