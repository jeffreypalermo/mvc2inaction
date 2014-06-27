using System.Web.Mvc;
using MvcContrib.UI.MenuBuilder;

namespace MvcContrib.Samples.UI.Controllers
{
	[HandleError]
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewData["Message"] = "Welcome to ASP.NET MVC!";
			return View();
		}
	}
}