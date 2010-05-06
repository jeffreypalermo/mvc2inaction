using System.Threading;
using MbUnit.Framework;
using NBehave.Spec.MbUnit;
using WatiN.Core;

namespace UITesting.Tests
{
    // Listing 20.1
    [TestFixture]
    [ApartmentState(ApartmentState.STA)]
    public class FirstProductEditTester
    {
        [Test]
        public void Should_update_product_price_successfully()
        {
            using (var ie = new IE("http://localhost:8084/"))
            {
                ie.Link(Find.ByText("Products")).Click();

                ie.Link(Find.ByText("Edit")).Click();

                var priceField = ie.TextField(Find.ByName("Price"));

                priceField.Value = "389.99";

                ie.Button(Find.ByValue("Save")).Click();

                ie.Url.ShouldEqual("http://localhost:8084/Product");

                ie.ContainsText("389.99").ShouldBeTrue();
            }
        }
    }
}