using System.Web.Mvc;
using Ninject;
using Ninject.Web.Mvc;

namespace ControllerFactories
{
    public static class NinjectBootstrapper
    {
        public static IKernel Kernel { get; private set; }

        public static void Initialize()
        {
            Kernel = new StandardKernel(
                new MyNinjectModule()
                );
        }

        public static void SetControllerFactory()
        {
            var controllerFactory = new MyNinjectControllerFactory(Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
