using System;
using System.Linq;
using System.Web.Mvc;

namespace Target.Controllers
{
	public class CommentController : Controller
	{
		public ViewResult New()
		{
			return View();
		}

		[ValidateInput(false)]
		public ViewResult Save(CommentInput form)
		{
			return View(form);
		}
	}

	public class CommentInput
	{
		public string Name { get; set; }
		public string Comment { get; set; }
	}
}