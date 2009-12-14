using System.Web.Mvc;

namespace MvcApplication17.Controllers
{
	public class PostController : Controller
	{
		[HttpGet]
		public JsonResult GetInsecureJson()
		{
			object data = GetData();

			return Json(data, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public JsonResult GetSecureJsonPost()
		{
			object data = GetData();

			return Json(data);
		}

		[HttpGet]
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