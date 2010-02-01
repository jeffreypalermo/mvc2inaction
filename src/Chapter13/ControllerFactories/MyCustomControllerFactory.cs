using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace ControllerFactories
{
    public class MyCustomControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            /* implement controller creation logic */
            return base.GetControllerInstance(requestContext, controllerType);
        }
    }
}