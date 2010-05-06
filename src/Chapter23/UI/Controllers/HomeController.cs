using System.Web.Mvc;

namespace UI.Controllers
{
	[HandleError]
	[VisitorAdditionFilter(Order = 0)]
	[VisitorRetrievalFilter(Order = 1)]
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewData["Message"] = "Welcome to ASP.NET MVC!";

			return View();
		}

		public ActionResult About()
		{
			return View();
		}
	}
}