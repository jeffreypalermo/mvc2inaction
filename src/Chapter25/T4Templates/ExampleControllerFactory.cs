using System;
using System.Web.Mvc;
using System.Web.Routing;
using T4Templates.Controllers;
using T4Templates.Models;

namespace T4Templates
{
    public class ExampleControllerFactory :
        DefaultControllerFactory
    {
        protected override IController GetControllerInstance(
            RequestContext requestContext, Type controllerType)
        {
            if (typeof (ProductController)
                .IsAssignableFrom(controllerType))
            {
                return new ProductController(
                    new ProductRepository());
            }

            return base.GetControllerInstance(requestContext,
                                              controllerType);
        }
    }
}