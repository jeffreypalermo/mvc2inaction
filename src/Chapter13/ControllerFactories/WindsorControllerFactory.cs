using System;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;

namespace ControllerFactories
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IWindsorContainer _container;

        public WindsorControllerFactory(IWindsorContainer container)
        {
            _container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            var name = controllerType.Name;
            return _container.Resolve<IController>(name);            
        }
    }
}