using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ComplexRoutes.Models;

namespace ComplexRoutes.Controllers
{
    [HandleError]
    public class CatalogController : Controller
    {
        private IList<Widget> _widgets = new List<Widget>
                                             {
                                                 new Widget("WDG-0001") {Name="Cool Widget"},
                                                 new Widget("WDG-0002") {Name="Funky Widget"}
                                             };

        public ActionResult Index()
        {
            return View(_widgets);
        }

        public ActionResult Show(string widgetCode)
        {
            //get the widget from the database...
            var widget = _widgets.Where(w => w.Code == widgetCode).SingleOrDefault();

            if (widget == null)
            {
                //if the widget doesn't exist, we can return a 404 indicating that this resource
                //isn't valid
                return RedirectToAction("NotFound", "Error");
            }

            //render a view
            return View(widget);
        }

        [HttpPost]
        public ActionResult Buy(string widgetCode)
        {
            return RedirectToAction("index");
        }

        public ActionResult Basket()
        {
            return View();
        }

        public ActionResult CheckOut()
        {
            return View();
        }
    }
}
