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
        }
    }
}