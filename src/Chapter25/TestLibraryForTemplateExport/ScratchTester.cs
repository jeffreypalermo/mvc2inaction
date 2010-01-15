using System.Web.Routing;
using NUnit.Framework;
using MvcContrib.TestHelper;
using T4Templates;
using T4Templates.Controllers;

namespace TestLibraryForTemplateExport
{
    [TestFixture]
    public class ScratchTester
    {
        [Test]
        public void Home_route_should_work()
        {
            MvcApplication.RegisterRoutes(RouteTable.Routes);
            "~/".ShouldMapTo<HomeController>(x => x.Index());
        }
    }
}