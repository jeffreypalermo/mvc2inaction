using CustomActionResults.Controllers;
using NUnit.Framework;
using MvcContrib.TestHelper;
namespace CustomActionResults.Tests
{
    [TestFixture]
    public class HomeControllerTester
    {
        [Test]
        public void The_Logout_should_redirect_to_the_index_after_logout()
        {
            var controller = new HomeController();
            LogoutActionResult result = (LogoutActionResult) controller.Logout();
            result.ActionAfterLogout.AssertActionRedirect().ToAction<HomeController>(c => c.Index());
        }

    }
}