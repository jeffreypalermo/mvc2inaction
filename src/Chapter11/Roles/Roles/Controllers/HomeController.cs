using System.Web.Mvc;

namespace Roles.Controllers
{
	[HandleError]
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewData["Message"] = "Welcome to ASP.NET MVC!";

			return View();
		}

		[Authorize]
		public ActionResult About()
		{
			return View();
		}

		[Authorize(Roles = "admins, developers")]
		public ActionResult Developers()
		{
			return View();
		}

		[Authorize(Users = "admin")]
		public ActionResult Admins()
		{
			return View();
		}
	}
}