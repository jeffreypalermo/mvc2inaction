using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AjaxExamples.Controllers
{
    public class AjaxHelpersController : Controller
    {
        private IList<string> _comments = new List<string>();

        public ActionResult Index()
        {
            return View(_comments);
        }

        [HttpPost]
        public ActionResult AddComment(string comment)
        {
            _comments.Add("<li>" + comment + "</li>");
            return Content(string.Join("\n", _comments.ToArray()));
        }

        public ActionResult PrivacyPolicy()
        {
            const string privacyText = @"
                <h2>Our Commitment To Privacy</h2>
                Your privacy is important to us. To better protect your privacy we provide this notice explaining our online
                information practices and the choices you can make about the way your information is collected and used.
                To make this notice easy to find, we make it available on our homepage and at every point where personally
                identifiable information may be requested.";

            return Content(privacyText, "text/html");
        }
    }
}