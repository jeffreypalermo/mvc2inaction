using System.Web.Mvc;
using StructureMap;

namespace ControllerFactories
{
    public static class StructureMapBootstrapper
    {
        public static void Initialize()
        {
            ObjectFactory.Initialize(x => x.AddRegistry(new MyStructureMapApplicationRegistry()));    
        }

        public static void SetControllerFactory()
        {
            var controllerFactory = new StructureMapControllerFactory();
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}