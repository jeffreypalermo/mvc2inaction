using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ControllerFactories
{
    public class MvcApplication : HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("favicon.ico");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );
        }
        
        protected void Application_Start()
        {
            StructureMapBootstrapper.Initialize();
            NinjectBootstrapper.Initialize();
            WindsorBootstrapper.Initialize();

            //we'll start with StructureMap as the controller factory
            //ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
            ControllerBuilder.Current.SetControllerFactory(new MyNinjectControllerFactory(NinjectBootstrapper.Kernel));

            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
        }
    }
}