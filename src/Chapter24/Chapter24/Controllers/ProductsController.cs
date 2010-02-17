using System;
using System.Web;
using System.Web.Mvc;

namespace Chapter24.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index(string category)
        {
            if(!CategoryExists(category))
            {
                throw new HttpException(404, "Not found");
            }

            ViewData["category"] = category;
            return View();
        }

        private bool CategoryExists(string category)
        {
            foreach(string validCategory in new[] {"food", "apparel", "supplies"})
            {
                if(category == validCategory)
                    return true;
            }

            return false;
        }
    }
}