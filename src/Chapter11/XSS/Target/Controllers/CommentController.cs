using System.Web.Mvc;

namespace Target.Controllers
{
	public class CommentController : Controller
	{
		public ViewResult New()
		{
			return View();
		}

		public ViewResult Save(CommentInput form)
		{
			return View(form);
		}
	}
}