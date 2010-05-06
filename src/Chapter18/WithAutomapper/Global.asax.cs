using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WithAutomapper.Models;

namespace WithAutomapper
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

public class MvcApplication : HttpApplication
{
	protected void Application_Start()
	{
		AutoMapperConfiguration.Configure();
		RegisterRoutes(RouteTable.Routes);
	}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default",                                              // Route name
				"{controller}/{action}/{id}",                           // URL with parameters
				new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
			);

		}
	}
}