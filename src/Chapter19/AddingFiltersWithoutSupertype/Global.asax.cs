﻿using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;

namespace AddingFiltersWithoutSupertype
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode,
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : HttpApplication
	{
		protected void Application_Start()
		{
			ObjectFactory.Initialize(x =>
			                         x.Scan(a =>
			                                	{
			                                		a.TheCallingAssembly();
			                                		a.WithDefaultConventions();
			                                		a.AddAllTypesOf<IAutoActionFilter>();
			                                	}));

			RegisterRoutes(RouteTable.Routes);
			ControllerFactory.GetInstance = type => ObjectFactory.GetInstance(type);

			ControllerBuilder.Current.SetControllerFactory(new ControllerFactory());
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new {controller = "Home", action = "Index", id = ""} // Parameter defaults
				);
		}
	}
}