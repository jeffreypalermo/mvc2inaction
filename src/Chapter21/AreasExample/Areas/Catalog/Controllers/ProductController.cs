using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AreasExample.Areas.Catalog.Controllers
{
    public partial class ProductController : Controller
    {
        //
        // GET: /Catalog/Product/

        public virtual ActionResult Index()
        {
            return View();
        }

    }
}
