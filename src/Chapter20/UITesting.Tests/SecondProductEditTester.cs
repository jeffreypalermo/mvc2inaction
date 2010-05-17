using MbUnit.Framework;
using Should.Extensions.AssertExtensions;
using WatiN.Core;

namespace UITesting.Tests
{
    // Listing 20.2
    [TestFixture]
    public class SecondProductEditTester : WebTestBase
    {
        [Test]
        public void Should_update_product_price_successfully()
        {
            Browser.Link(Find.ByText("Products")).Click();

            Browser.Link(Find.ByText("Edit")).Click();

            TextField priceField = Browser.TextField(Find.ByName("Price"));

            priceField.Value = "389.99";

            Browser.Button(Find.ByValue("Save")).Click();

            Browser.Url.ShouldEqual("http://localhost:8084/Product");

            Browser.ContainsText("389.99").ShouldBeTrue();
        }
    }
}