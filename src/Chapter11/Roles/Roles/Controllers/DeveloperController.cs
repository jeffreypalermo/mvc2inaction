using System;
using System.Web.Mvc;

namespace Roles.Controllers
{
	[Authorize(Roles = DemoRoleProvider.DeveloperRole)]
	public class DeveloperController : Controller
	{
        public ViewResult Index()
		{
			return View();
		}

		[Authorize(Roles = DemoRoleProvider.ReaderRole)]
		public ViewResult Reader()
		{
			return View();
		}

		
	}

	public class NotFoundFilter : FilterAttribute, IAuthorizationFilter
	{
		public void OnAuthorization(AuthorizationContext filterContext)
		{
			filterContext.Result = new NotFoundResult();
		}

		public class NotFoundResult : ActionResult
		{
			public override void ExecuteResult(ControllerContext context)
			{
				context.HttpContext.Response.StatusCode = 500;
			}
		}
	}

	
}