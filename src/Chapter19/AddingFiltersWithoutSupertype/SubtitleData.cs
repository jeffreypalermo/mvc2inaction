using System.Web.Mvc;

namespace AddingFiltersWithoutSupertype
{
	public class SubtitleData : ContainerBaseActionFilter, IConventionActionFilter
	{
		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			filterContext.Controller.ViewData["subtitle"] = "Set from automatically applied filter";
		}
	}

	public class SubtitleDataAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			filterContext.Controller.ViewData["subtitle"] = "Set from attribute";
		}
	}

}