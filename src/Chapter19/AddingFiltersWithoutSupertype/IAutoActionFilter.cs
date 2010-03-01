using System.Web.Mvc;

namespace AddingFiltersWithoutSupertype
{
public interface IAutoActionFilter :
	IActionFilter, IResultFilter
{
}

public abstract class BaseAutoActionFilter :
	IAutoActionFilter
{
	public virtual void OnActionExecuting
		(ActionExecutingContext filterContext)
	{
	}

	public virtual void OnActionExecuted
		(ActionExecutedContext filterContext)
	{
	}

	public virtual void OnResultExecuting
		(ResultExecutingContext filterContext)
	{
	}

	public virtual void OnResultExecuted
		(ResultExecutedContext filterContext)
	{
	}
}
}