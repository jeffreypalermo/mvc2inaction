using System;
using System.Web;
using System.Web.Mvc;
using MvcContrib;
using MvcContrib.UI.InputBuilder;

namespace WebApplication2
{
	public class Global : HttpApplication
	{
		protected void Application_Start(object sender, EventArgs e)
		{
			//MVC 2 standard areas registration
			AreaRegistration.RegisterAllAreas();

			//Portable Areas configuration for handling messages sent
			//to the app from the portable area.
			InputBuilder.BootStrap();
			Bus.AddMessageHandler(typeof (LoginHandler));
			Bus.AddMessageHandler(typeof (ForgotPasswordHandler));
		}
	}
}