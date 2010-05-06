using System.Web.Mvc;

namespace AddingFiltersWithoutSupertype.Controllers
{
	[HandleError]
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewData["Message"] = "Welcome to ASP.NET MVC!";
			return View();
		}

[SubtitleData]
public ActionResult About()
{
	return View();
}
	}
}