using System.Web.Mvc;

namespace Personalization.Controllers
{
    public class ProfileController : Controller
    {
        #region 8.10
        public ActionResult My()
        {
            var profile = ControllerContext.HttpContext.Profile;
            return View(profile);
        }
        #endregion

        public ActionResult Edit()
        {
            var profile = ControllerContext.HttpContext.Profile;
            return View(profile);
        }

        public ActionResult Save(string nickName, int age)
        {
            ControllerContext.HttpContext.Profile["NickName"] = nickName;
            ControllerContext.HttpContext.Profile["age"] = age;

            return RedirectToAction("my");
        }
    }
}