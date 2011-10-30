using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ComplexRoutes
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode,
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            /*  Desired URL schema:
             * 1.  example.com/                     home page
             * 2.  example.com/privacy              static page containing privacy policy
             * 3.  example.com/widgets              show a list of the widgets
             * 4.  example.com/<widget code>	    Shows a product detail page for the relevant <widget code>
             * 5.  example.com/<widget code>/buy	Add the relevant widget to the shopping basket
             * 6.  example.com/basket	            Shows the current users shopping basket
             * 7.  example.com/checkout	            Starts the checkout process for the current user
             * 8.  example.com/404                  show a friendly 404 page
             */


            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("404", "404", new {controller = "Error", action = "NotFound"});

            routes.MapRoute("privacy_policy", "privacy", new { controller = "Home", action = "Privacy" });

            routes.MapRoute("widget", "{widgetCode}/{action}",
                            new { controller = "Catalog", action = "Show" },
                            new { widgetCode = @"WDG-\d{4}" });

            routes.MapRoute("widgets", "widgets", new {controller = "Catalog", action = "index"});

            routes.MapRoute("catalog", "{action}",
                            new { controller = "Catalog" },
                            new { action = @"basket|checkout|index" });

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }  // Parameter defaults
            );

            routes.MapRoute("404-catch-all", "{*catchall}", new {Controller = "Error", Action = "NotFound"});
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }
    }
}