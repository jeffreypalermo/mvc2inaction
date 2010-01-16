using System.Web.Routing;
using MvcContrib.TestHelper;
using NUnit.Framework;
using Routes.Controllers;

namespace Routes.UnitTests
{
    [TestFixture]
    public class RouteTests
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            MvcApplication.RegisterRoutes(RouteTable.Routes);
        }

        [Test]
        public void Should_map_blank_url_to_home()
        {
            "~/".Route().ShouldMapTo<HomeController>(c => c.Index());
        }

        [Test]
        public void Should_map_home_url_to_home_with_default_action()
        {
            "~/home".Route().ShouldMapTo<HomeController>(c => c.Index());
        }

        [Test]
        public void Should_map_home_about_url_to_home_matching_method_name()
        {
            "~/home/about".Route().ShouldMapTo<HomeController>(c => c.About());
        }

        [Test]
        public void
            Should_map_product_show_with_id_to_product_controller_with_parameter
            ()
        {
            "~/product/show/5".Route().ShouldMapTo<ProductController>(
                c => c.Show(5));
        }

        [Test]
        public void
            Should_map_product_search_to_product_controller_with_parameter()
        {
            "~/product/SomeProductName"
                .Route()
                .ShouldMapTo<ProductController>(
                c => c.Search("SomeProductName"));
        }

        [Test]
        public void Should_map_product_with_no_action_to_index()
        {
            "~/product".Route().ShouldMapTo<ProductController>(c => c.Index());
        }
    }
}