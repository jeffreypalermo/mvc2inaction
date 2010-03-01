using System.Web.Mvc;

namespace Personalization.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Title"] = "Home Page";
            ViewData["Message"] = "Welcome to ASP.NET MVC!";            

            return View();
        }        

        public ActionResult About()
        {
            ViewData["Title"] = "About Page";

            return View();
        }
    }
}
