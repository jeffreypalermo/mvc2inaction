using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AreasExample.Areas.Catalog.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Catalog/Product/

        public ActionResult Index()
        {
            return View();
        }

    }
}
