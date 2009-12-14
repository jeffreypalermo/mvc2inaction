using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using StructureMap;

namespace ControllerFactories
{
    public class MvcApplication : HttpApplication, INinjectKernelAccessor
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("favicon.ico");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );
        }
        
        protected void Application_Start()
        {            
            InitializeStructureMap();            
            InitializeWindsor();
            InitializeNinject();

            //we'll start with StructureMap as the controller factory
            //ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
            ControllerBuilder.Current.SetControllerFactory(new MyNinjectControllerFactory(_kernel));

            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
        }

        #region Castle Windsor stuff

        private void InitializeWindsor()
        {
        }

        #endregion

        #region StructureMap stuff

        private void InitializeStructureMap()
        {
            ObjectFactory.Initialize(x=>x.AddRegistry(new MyStructureMapApplicationRegistry()));
        }

        #endregion
        
        #region Ninject stuff

        private static IKernel _kernel;

        private void InitializeNinject()
        {
            _kernel = new StandardKernel(new MyNinjectModule());            
        }

        #endregion

        public IKernel Kernel
        {
            get { return _kernel; }
        }
    }

    public class MyNinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel _kernel;

        public MyNinjectControllerFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            var controller = _kernel.Get<IController>(controllerType.Name.Replace("Controller", "").ToLowerInvariant());
            return controller;            
        }
    }
}