using System.Linq;
using System.Web.Mvc;
using ControllerFactories.Controllers;
using ControllerFactories.Models;
using Ninject.Modules;

namespace ControllerFactories
{
    internal class MyNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMessageProvider>().To<NinjectMessageProvider>();
            Bind<IController>().To<HomeController>().InRequestScope()
                .Named("home");

//            //register all controllers
//            var controllerTypes = from t in GetType().Assembly.GetTypes()
//                                  where !t.IsAbstract && typeof (IController).IsAssignableFrom(t)
//                                  select t;
//
//            foreach(var controllerType in controllerTypes)
//            {
//                string name = controllerType.Name.Replace("Controller", "").ToLowerInvariant();
//                Bind<IController>().To(controllerType).InTransientScope().Named(name);
//            }
        }
    }
}