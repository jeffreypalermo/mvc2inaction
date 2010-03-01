using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Website.Mvc;
using Website.System;

namespace Website
{
   // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
   // visit http://go.microsoft.com/?LinkId=9394801

   public class MvcApplication : HttpApplication
   {
      public static void RegisterRoutes(RouteCollection routes)
      {
         routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
         routes.IgnoreRoute("{resource}.gif/{*pathInfo}");
         routes.IgnoreRoute("{resource}.ico/{*pathInfo}");


         routes.MapRoute(
            "Default", // Route name
            "{controller}/{action}/{id}", // URL with parameters
            new {controller = "Customer", action = "Index", id = UrlParameter.Optional} // Parameter defaults
            );
      }

      protected void Application_Start()
      {
         WebsiteConfiguration.Initialize();
         AreaRegistration.RegisterAllAreas();
         ControllerBuilder.Current.SetControllerFactory(new ControllerFactory());
         RegisterRoutes(RouteTable.Routes);
      }

      protected void Application_Disposed()
      {
         WebsiteConfiguration.CleanUp();
      }
   }
}