using System.Web.Mvc;
using ControllerFactories.Models;

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
            StructureMapBootstrapper.SetControllerFactory();
            return RedirectToAction("index");
        }
        
        [HttpPost]
        public ActionResult SetNinject()
        {
            NinjectBootstrapper.SetControllerFactory();
            return RedirectToAction("index");
        }

        [HttpPost]
        public ActionResult SetWindsor()
        {
            WindsorBootstrapper.SetControllerFactory();
            return RedirectToAction("index");
        }

        [HttpPost]
        public ActionResult SetDefault()
        {
            ControllerBuilder.Current.SetControllerFactory(new DefaultControllerFactory());
            return RedirectToAction("index");
        }
    }
}
