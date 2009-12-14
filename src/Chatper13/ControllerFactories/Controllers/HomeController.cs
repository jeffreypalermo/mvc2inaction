using System.Web.Mvc;
using ControllerFactories.Models;
using Ninject;
using Ninject.Infrastructure;
using Ninject.Web.Mvc;

namespace ControllerFactories.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private IMessageProvider _messageProvider;

        public HomeController(IMessageProvider messageProvider)
        {
            _messageProvider = messageProvider;
        }

        public ActionResult Index()
        {
            ViewData["Message"] = _messageProvider.GetMessage();

            return View();
        }

        [HttpPost]
        public ActionResult SetStructureMap()
        {           
            var structureMapControllerFactory = new StructureMapControllerFactory();            
            ControllerBuilder.Current.SetControllerFactory(structureMapControllerFactory);

            return RedirectToAction("index");
        }
        
        [HttpPost]
        public ActionResult SetNinject()
        {
            //get the kernel
            var application = (INinjectKernelAccessor) ControllerContext.HttpContext.ApplicationInstance;            

            //create the controller factory
            var ninjectControllerFactory = new MyNinjectControllerFactory(application.Kernel);
            ControllerBuilder.Current.SetControllerFactory(ninjectControllerFactory);

            return RedirectToAction("index");
        }
    }
}
