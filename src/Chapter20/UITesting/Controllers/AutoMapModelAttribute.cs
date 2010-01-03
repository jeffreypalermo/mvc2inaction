using System;
using System.Web.Mvc;
using AutoMapper;

namespace UITesting.Controllers
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class AutoMapModelAttribute : ActionFilterAttribute
	{
		private readonly Type _modelType;
		private readonly Type _dtoType;

		public AutoMapModelAttribute(Type modelType, Type dtoType)
		{
			_modelType = modelType;
			_dtoType = dtoType;
		}

		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			var filter = new AutoMapModelFilter(ModelType, DtoType);

			filter.OnActionExecuted(filterContext);
		}

		public Type ModelType
		{
			get { return _modelType; }
		}

		public Type DtoType
		{
			get { return _dtoType; }
		}
	}

	public abstract class BaseActionFilter : IActionFilter, IResultFilter
	{
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

	public class AutoMapModelFilter : BaseActionFilter
	{
		private readonly Type _modelType;
		private readonly Type _dtoType;

		public AutoMapModelFilter(Type modelType, Type dtoType)
		{
			_modelType = modelType;
			_dtoType = dtoType;
		}

		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			var model = filterContext.Controller.ViewData.Model;

			object dto = Mapper.Map(model, _modelType, _dtoType);

			filterContext.Controller.ViewData.Model = dto;
		}
	}
}