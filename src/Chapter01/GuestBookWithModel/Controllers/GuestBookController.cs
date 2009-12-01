using System.Web.Mvc;
using GuestBookWithModel.Models;

namespace GuestBookWithModel.Controllers
{
    public class GuestBookController : Controller
    {
        public ActionResult Index()
        {
            var model = new GuestBookEntry();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(GuestBookEntry entry)
        {
            if (!ModelState.IsValid)
                return View(entry);

            TempData["entry"] = entry;
            return RedirectToAction("ThankYou");
        }

        public ActionResult ThankYou()
        {
            if(TempData["entry"] == null)
            {
                //somehow they got here without filling out the form
                return RedirectToAction("index");
            }

            var model = (GuestBookEntry) TempData["entry"];
            return View(model);
        }
    }
}