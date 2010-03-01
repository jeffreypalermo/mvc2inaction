using System;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;

namespace Website.Mvc
{
   public class ControllerFactory : DefaultControllerFactory
   {
      protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
      {
         return (IController) ObjectFactory.GetInstance(controllerType);
      }
   }
}