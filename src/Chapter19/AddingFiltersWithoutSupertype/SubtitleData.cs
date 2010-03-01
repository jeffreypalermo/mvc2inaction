using System.Web.Mvc;

namespace AddingFiltersWithoutSupertype
{
	public class SubtitleData : BaseAutoActionFilter
	{
		readonly ISubtitleBuilder _builder;

		public SubtitleData(ISubtitleBuilder builder)
		{
			_builder = builder;
		}

		public override void OnActionExecuted(
			ActionExecutedContext filterContext)
		{
			filterContext.Controller.ViewData["subtitle"] =
				_builder.AutoSubtitle();
		}
	}

	public class SubtitleDataAttribute : ActionFilterAttribute
	{
		public override void
			OnActionExecuted(ActionExecutedContext filterContext)
		{
			var subtitle = new SubtitleBuilder();
			filterContext.Controller.ViewData["subtitle"]
				= subtitle.Subtitle();
		}
	}

	public class SubtitleBuilder : ISubtitleBuilder
	{
		public string AutoSubtitle()
		{
			return "Set from automatically applied filter";
		}

		public string Subtitle()
		{
			return "Set from attribute";
		}
	}

	public interface ISubtitleBuilder
	{
		string AutoSubtitle();
		string Subtitle();
	}
}