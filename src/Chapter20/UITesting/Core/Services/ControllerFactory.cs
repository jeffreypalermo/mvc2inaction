using System;
using System.Web.Mvc;
using StructureMap;

namespace UITesting.Core.Services
{
	public class ControllerFactory : DefaultControllerFactory
	{
		protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
		{
			if (controllerType == null)
				return null;

			var controller = ObjectFactory.GetInstance(controllerType);

			return (IController)controller;
		}
	}
}