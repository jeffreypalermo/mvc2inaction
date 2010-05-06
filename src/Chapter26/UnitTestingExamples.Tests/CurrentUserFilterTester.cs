using System.Web.Mvc;
using MvcContrib;
using NUnit.Framework;
using Rhino.Mocks;
using UnitTestingExamples.Helpers.Filters;
using UnitTestingExamples.Models;
using UnitTestingExamples.Services;

namespace UnitTestingExamples.Tests
{
    [TestFixture]
    public class CurrentUserFilterTester
    {
        [Test]
        public void Should_pass_current_user_when_user_is_logged_in()
        {
            var loggedInUser = new User();

            var userSession =
                MockRepository.GenerateStub<IUserSession>();
            userSession.Stub(session => session.GetCurrentUser())
                .Return(loggedInUser);

            var filterContext =
                new ActionExecutingContext
                    {
                        Controller =
                            MockRepository.GenerateStub<ControllerBase>()
                    };

            var currentUserFilter = new CurrentUserFilter(userSession);
            currentUserFilter.OnActionExecuting(filterContext);

            var user = filterContext.Controller.ViewData.Get<User>();
            Assert.AreEqual(loggedInUser, user);
        }
    }
}