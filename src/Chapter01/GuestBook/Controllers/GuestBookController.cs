using System.Web.Mvc;

namespace GuestBook.Controllers
{
    public class GuestBookController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sign(string name, string email, string comments)
        {
            //do something with the values, such as send an email

            ViewData["name"] = name;
            ViewData["email"] = email;
            ViewData["comments"] = comments;

            return View("ThankYou");
        }
    }
}
