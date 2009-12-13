using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AntiForgery.Controllers
{
	[HandleError]
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			return View();
		}

		[ValidateAntiForgeryToken]
		public ViewResult Save(InputModel form)
		{
			return View(form);
		}
	}

	public class InputModel
	{
		public string Name { get; set; }
	}
}
