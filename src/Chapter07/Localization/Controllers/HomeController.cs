using System.Threading;
using System.Web.Mvc;


namespace Localization.Controllers
{
    #region Listing 8.11
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {            
            ViewData["Title"] = Resource("PageTitle");
            ViewData["Message"] = Resource("WelcomeMessage");

            return View();
        }

        private string Resource(string key)
        {
            var httpContext = ControllerContext.HttpContext;
            var culture = Thread.CurrentThread.CurrentUICulture;
            return (string)httpContext.GetGlobalResourceObject("Site", key, culture);
        }

        public ActionResult About()
        {
            ViewData["Title"] = "About Page";

            return View();
        }
    }

    #endregion
}
