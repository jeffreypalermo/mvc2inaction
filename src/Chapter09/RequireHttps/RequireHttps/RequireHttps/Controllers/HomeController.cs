using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RequireHttps.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        [TestableRequireHttps]
        public ActionResult Secure()
        {
            return View();
        }
    }

    public class TestableRequireHttpsAttribute : RequireHttpsAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
             if(filterContext.HttpContext.Request.IsLocal)
                 return;
        }
    }
}
