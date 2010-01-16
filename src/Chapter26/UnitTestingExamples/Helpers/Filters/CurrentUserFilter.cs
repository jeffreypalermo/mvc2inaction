using System.Web.Mvc;
using MvcContrib;
using UnitTestingExamples.Models;
using UnitTestingExamples.Services;

namespace UnitTestingExamples.Helpers.Filters
{
    public class CurrentUserFilter : IActionFilter
    {
        private readonly IUserSession _session;

        public CurrentUserFilter(IUserSession session)
        {
            _session = session;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ControllerBase controller = filterContext.Controller;
            User user = _session.GetCurrentUser();
            if (user != null)
            {
                controller.ViewData.Add(user);
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // no-op
        }
    }
}