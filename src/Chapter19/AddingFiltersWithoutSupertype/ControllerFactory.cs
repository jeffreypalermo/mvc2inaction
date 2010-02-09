using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace AddingFiltersWithoutSupertype
{
	public class ControllerFactory : DefaultControllerFactory
	{
		public static Func<Type, object> GetInstance = (type) => Activator.CreateInstance(type);

		protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
		{
			if (controllerType != null)
			{
				var controller = (Controller) GetInstance(controllerType);
				controller.ActionInvoker = (IActionInvoker) GetInstance(typeof (ConventionActionInvoker));
				return controller;
			}
			return null;
		}
	}
}