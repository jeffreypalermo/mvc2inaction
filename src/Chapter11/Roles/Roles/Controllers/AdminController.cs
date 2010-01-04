using System.Web.Mvc;

namespace Roles.Controllers
{
	[Authorize(Roles = DemoRoleProvider.AdminRole)]
	public class AdminController : Controller
	{
		public ViewResult Index()
		{
			return View();
		}

		[Authorize(Roles = DemoRoleProvider.ReaderRole)]
		public ViewResult Reader()
		{
			return View();
		}
	}
}