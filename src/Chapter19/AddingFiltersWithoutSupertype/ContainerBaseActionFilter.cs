using System;
using System.Web.Mvc;

namespace AddingFiltersWithoutSupertype
{
	public abstract class ContainerBaseActionFilter : IActionFilter, IResultFilter
	{
		public static Func<Type, object> CreateDependencyCallback = (type) => Activator.CreateInstance(type);

		public T CreateDependency<T>()
		{
			return (T)CreateDependencyCallback(typeof(T));
		}

		public virtual void OnActionExecuting(ActionExecutingContext filterContext)
		{
		}

		public virtual void OnActionExecuted(ActionExecutedContext filterContext)
		{
		}

		public virtual void OnResultExecuting(ResultExecutingContext filterContext)
		{
		}

		public virtual void OnResultExecuted(ResultExecutedContext filterContext)
		{
		}
	}
}