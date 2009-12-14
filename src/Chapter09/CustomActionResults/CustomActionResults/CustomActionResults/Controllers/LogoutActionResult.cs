using System.Web.Mvc;
using System.Web.Security;

namespace CustomActionResults.Controllers
{
    public class LogoutActionResult : ActionResult
    {
        public RedirectToRouteResult ActionAfterLogout { get; set; }

        public LogoutActionResult(RedirectToRouteResult actionAfterLogout)
        {
            ActionAfterLogout = actionAfterLogout;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            FormsAuthentication.SignOut();
            ActionAfterLogout.ExecuteResult(context);
        }
    }
}