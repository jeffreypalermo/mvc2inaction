using System.Web.Mvc;

namespace MvcApplication17.Controllers
{
	[HandleError]
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewData["Message"] = "Welcome to ASP.NET MVC!";

			return View();
		}

		public ActionResult Vulnerable()
		{
			return View();
		}

		public ActionResult SecurePost()
		{
			return View();
		}

		public ActionResult Secure()
		{
			return View();
		}
	}
}