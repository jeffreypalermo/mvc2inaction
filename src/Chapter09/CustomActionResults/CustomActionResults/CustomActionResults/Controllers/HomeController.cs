using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace CustomActionResults.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Export()
        {
            
            return View();
        }

        public ActionResult ExportUsers()
        {
            IEnumerable<User> model = UserRepository.GetUsers();
            return new CsvActionResult(model);
        }

        public ActionResult Logout()
        {
            return new LogoutActionResult(RedirectToAction("Index","Home"));
        }
    }
}
