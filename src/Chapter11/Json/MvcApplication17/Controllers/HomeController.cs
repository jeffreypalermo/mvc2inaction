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

		public ActionResult About()
		{
			return View();
		}


		public JsonResult GetInsecureJson()
		{
			object data = GetData();

			return Json(data, JsonRequestBehavior.AllowGet);
		}


		public JsonResult GetSecureJsonPost()
		{
			object data = GetData();

			return Json(data);
		}

		public SecureJsonResult GetSecureJson()
		{
			object data = GetData();

			var result = new SecureJsonResult {Data = data};
			return result;
		}

		private static object GetData()
		{
			return new[]
			       	{
			       		new
			       			{
			       				Title = "ASP.NET MVC In Action",
			       				Id = "1",
			       			},
			       		new
			       			{
			       				Title = "jQuery In Action",
			       				Id = "2"
			       			},
			       	};
		}
	}
}