using System.Web.Routing;
using NUnit.Framework;
using MvcContrib.TestHelper;
using StandardRoutes.Controllers;

namespace StandardRoutes.Tests.Routing
{
    [TestFixture]
    public class StandardRouteTests
    {
        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            RouteTable.Routes.Clear();
            MvcApplication.RegisterRoutes(RouteTable.Routes);
        }

        [Test]
        public void root_maps_to_home_index()
        {
            "~/".ShouldMapTo<HomeController>(x => x.Index());
        }

        [Test]
        public void default_action_is_set_to_index()
        {
            "~/home".ShouldMapTo<HomeController>(x => x.Index());
        }

        [Test]
        public void id_is_appended_as_3rd_segment()
        {
            "~/customers/show/512".ShouldMapTo<CustomersController>(x => x.Show(512));
        }
    }
}