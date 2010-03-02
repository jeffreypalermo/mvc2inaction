using System.Web.Mvc;

namespace Target.Controllers
{
	public class CommentController : Controller
	{
		public ViewResult New()
		{
			return View();
		}

		[ValidateInput(false)] //Input validation explicitly disabled.
		public ViewResult Save(CommentInput form)
		{
			return View(form);
		}
	}
}