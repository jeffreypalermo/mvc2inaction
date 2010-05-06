using System.Web.Mvc;
using MvcContrib.PortableAreas;

namespace PortableArea
{
	public class AreaRegistration : PortableAreaRegistration
	{
		public override string AreaName
		{
			get { return "login"; }
		}

		public override void RegisterArea(AreaRegistrationContext context, IApplicationBus bus)
		{
			context.MapRoute(
				"login",
				"login/{controller}/{action}",
            new { controller = "Account", action = "index" });

			base.RegisterTheViewsInTheEmbeddedViewEngine(GetType());
		}
	}
}