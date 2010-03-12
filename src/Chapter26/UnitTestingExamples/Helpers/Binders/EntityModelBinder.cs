using System;
using System.Web.Mvc;
using UnitTestingExamples.Models;
using UnitTestingExamples.Services;

namespace UnitTestingExamples.Helpers.Binders
{
    public class EntityModelBinder : IModelBinder
    {
        public object BindModel(
            ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            ValueProviderResult value =
                bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName);

            if (value == null)
                return null;

            if (string.IsNullOrEmpty(value.AttemptedValue))
                return null;

            Guid entityId;

            try
            {
                entityId = new Guid(value.AttemptedValue);
            }
            catch (FormatException)
            {
                return null;
            }

            Type repositoryType =
                typeof (IRepository<>).MakeGenericType(
                    bindingContext.ModelType);
            var repository = (IRepository) IoC.Resolve(repositoryType);

            PersistentObject entity = repository.GetById(entityId);

            return entity;
        }
    }
}