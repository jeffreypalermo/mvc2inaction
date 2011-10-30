using System.Web.Mvc;

namespace AjaxExamples.Controllers
{
    public class SimpleAjaxController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetMessage()
        {
            return Content("<h1>This is a custom message returned from an action.</h1>");
        }
    }
}
