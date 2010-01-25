using System;
using System.Web.Mvc;
using System.Web.Routing;
using AccountProfile.Models;

namespace AccountProfile
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

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

			var repository = new ProfileRepository();

			var firstNames = new[]
			{
				"Jacob", "Michael", "Ethan", "Joshua", "Daniel", "Alexander", "Anthony", "William", "Chris", "Matthew", "Emma",
				"Isabella", "Emily", "Madison", "Ava", "Olivia", "Sofia", "Abigail", "Elizabeth", "Chloe"
			};
			var lastNames = new[]
			{
				"Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor", "Anderson",
				"Thomas", "Jackson", "White", "Harris", "Martin", "Thompson", "Robinson", "Clark", "Lewis", "Lee", "Walker"
			};

			var rand = new Random((int) DateTime.Now.Ticks);

			for (int i = 0; i < 100; i++)
			{
				var firstName = firstNames[rand.Next(firstNames.Length)];
				var lastName = lastNames[rand.Next(lastNames.Length)];
				var username = Guid.NewGuid().ToString().Substring(0, 8);
				var profile = new Profile(username) {FirstName = firstName, LastName = lastName};

				repository.Add(profile);
			}

		}
	}
}