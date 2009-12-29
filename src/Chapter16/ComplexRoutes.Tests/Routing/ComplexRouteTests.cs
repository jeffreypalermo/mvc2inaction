using System.Web.Routing;
using ComplexRoutes.Controllers;
using MvcContrib.TestHelper;
using NUnit.Framework;

namespace ComplexRoutes.Tests.Routing
{
    [TestFixture]
    public class ComplexRouteTests
    {
        /*  Desired URL schema:
         * 1.  example.com/                     home page
         * 2.  example.com/privacy              static page containing privacy policy
         * 3.  example.com/widgets              show a list of the widgets
         * 4.  example.com/<widget code>	    Shows a product detail page for the relevant <widget code>
         * 5.  example.com/<widget code>/buy	Add the relevant widget to the shopping basket
         * 6.  example.com/basket	            Shows the current users shopping basket
         * 7.  example.com/checkout	            Starts the checkout process for the current user
         * 8.  example.com/404                  show a friendly 404 page
         */

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
        public void privacy_should_map_to_home_privacy()
        {
            "~/privacy".ShouldMapTo<HomeController>(x => x.Privacy());
        }

        [Test]
        public void widgets_should_map_to_catalog_index()
        {
            "~/widgets".ShouldMapTo<CatalogController>(x => x.Index());
        }

        [Test]
        public void widget_code_url()
        {
            "~/WDG-0002".ShouldMapTo<CatalogController>(x => x.Show("WDG-0002"));
        }

        [Test]
        public void widget_buy_url()
        {
            "~/WDG-0002/buy".ShouldMapTo<CatalogController>(x => x.Buy("WDG-0002"));
        }

        [Test]
        public void basket_should_map_to_catalog_basket()
        {
            "~/basket".ShouldMapTo<CatalogController>(x => x.Basket());
        }

        [Test]
        public void checkout_should_map_to_catalog_checkout()
        {
            "~/checkout".ShouldMapTo<CatalogController>(x => x.CheckOut());
        }

        [Test]
        public void _404_should_map_to_error_notfound()
        {
            "~/404".ShouldMapTo<ErrorController>(x => x.NotFound());
        }
    }
}