using System;
using System.Reflection;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ControllerFactories.Models;

namespace ControllerFactories
{
	using Castle.Core;

	public static class WindsorBootstrapper
    {
        public static IWindsorContainer Container { get; private set; }

        public static void Initialize()
        {
            Container = new WindsorContainer();


            RegisterControllers();

            Container.AddComponent<IMessageProvider, WindsorMessageProvider>();
        }

        private static void RegisterControllers()
        {
            //register all controllers with their Type name
            Container.Register(AllTypes.Of<IController>()
                                   .FromAssembly(Assembly.GetExecutingAssembly())
                                   .Configure(c => c.LifeStyle.Is(LifestyleType.Transient)));
        }

        public static void SetControllerFactory()
        {
            var controllerFactory = new WindsorControllerFactory(Container);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}