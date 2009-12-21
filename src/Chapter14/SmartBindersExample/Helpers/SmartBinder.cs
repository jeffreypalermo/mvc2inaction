using System;
using System.Web.Mvc;
using SmartBindersExample.Models;

namespace SmartBindersExample.Helpers
{
	public class EntityModelBinder : IFilteredModelBinder
	{
		public bool IsMatch(Type modelType)
		{
			return typeof(Entity).IsAssignableFrom(modelType);
		}

		public object BindModel(
			ControllerContext controllerContext,
			ModelBindingContext bindingContext)
		{
			ValueProviderResult value = bindingContext.ValueProvider.GetValue(controllerContext, bindingContext.ModelName);

			if (value == null)
				return null;

			if (string.IsNullOrEmpty(value.AttemptedValue))
				return null;

			var entityId = int.Parse(value.AttemptedValue);

			Type repositoryType = typeof(IRepository<>).MakeGenericType(bindingContext.ModelType);
			var repository = (IRepository)IoC.Resolve(repositoryType);

			Entity entity = repository.GetById(entityId);

			return entity;
		}
	}

	public interface IFilteredModelBinder : IModelBinder
	{
		bool IsMatch(Type modelType);
	}

	public class SmartBinder : DefaultModelBinder
	{
		private readonly IFilteredModelBinder[] _filteredModelBinders;

		public SmartBinder(params IFilteredModelBinder[] filteredModelBinders)
		{
			_filteredModelBinders = filteredModelBinders;
		}

		public override object BindModel(
			ControllerContext controllerContext,
			ModelBindingContext bindingContext)
		{
			foreach (var modelBinder in _filteredModelBinders)
			{
				if (modelBinder.IsMatch(bindingContext.ModelType))
				{
					return modelBinder.BindModel(controllerContext, bindingContext);
				}
			}

			return base.BindModel(controllerContext, bindingContext);
		}
	}
}