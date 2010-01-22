using System.Web.Mvc;
using System.Web.Routing;

namespace AjaxExamples
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("get_message.html");


            routes.MapRoute("FriendlySpeakersUrlWithFormat",
                            "speakers/{urlKey}.{format}",
                            new { controller = "Speakers", action = "details", format = "html" }
                );

            routes.MapRoute("FriendlySpeakersUrl",
                           "speakers/{urlKey}",
                           new { controller = "Speakers", action = "details", format = "html" }
               );

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }
    }
}