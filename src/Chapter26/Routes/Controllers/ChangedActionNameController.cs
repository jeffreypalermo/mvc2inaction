using System.Web.Mvc;

namespace Routes.Controllers
{
    public class ChangedActionNameController : Controller
    {
        [ActionName("Foo")]
        public ActionResult Index()
        {
            return View();
        }
    }
}