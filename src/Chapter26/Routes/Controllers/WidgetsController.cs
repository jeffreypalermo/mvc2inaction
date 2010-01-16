using System.Web.Mvc;
using Routes.Models;

namespace Routes.Controllers
{
    public class WidgetsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Show(int id)
        {
            return View();
        }

        public ActionResult New()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult New(WidgetForm widget)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(WidgetForm widget)
        {
            return RedirectToAction("Index");
        }
    }
}