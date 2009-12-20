using System.Web.Mvc;

namespace Roles.Controllers
{
	[Authorize(Roles = DemoRoleProvider.DeveloperRole)]
	public class DeveloperController : Controller
	{
		public ViewResult Index()
		{
			return View();
		}

		[Authorize(Roles=DemoRoleProvider.ReaderRole)]
		public ViewResult Reader()
		{
			return View();
		}
	}
}