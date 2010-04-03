using System.Linq;
using System.Web.Mvc;
using ControllerFactories.Controllers;
using ControllerFactories.Models;
using Ninject.Modules;

namespace ControllerFactories
{
    public class MyNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMessageProvider>().To<NinjectMessageProvider>();
        }
    }
}