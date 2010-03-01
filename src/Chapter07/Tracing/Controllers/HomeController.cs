using System.Web;
using System.Web.Mvc;

namespace Tracing.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           return View();
        }
    }
}
