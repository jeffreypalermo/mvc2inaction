using System.Web;
using System.Web.Mvc;

namespace Target.Controllers
{
	[HandleError]
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			var cookie = new HttpCookie("mvcinaction", "secret");

			Response.SetCookie(cookie);

			return View();
		}

		public ActionResult About()
		{
			return View();
		}
	}
}