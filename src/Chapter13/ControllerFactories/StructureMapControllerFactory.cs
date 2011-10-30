using System;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;

namespace ControllerFactories
{
    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return ObjectFactory.GetInstance(controllerType) as IController;
        }
    }
}