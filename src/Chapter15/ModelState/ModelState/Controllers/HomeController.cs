using System.Web.Mvc;

namespace ModelState.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View(new CompanyInput());
        }

        [HttpGet]
        public ActionResult ClientValidation()
        {
            return View(new CompanyInput());
        }


        [HttpGet]
        public ActionResult CustomMetaDataProvider()
        {
            return View("Edit", new CompanyInput());
        }

[HttpPost]
public ActionResult Edit(CompanyInput input)
{
    if (ModelState.IsValid)
    {
        return View("Success");
    }
    return View(new CompanyInput());
}
    }
}