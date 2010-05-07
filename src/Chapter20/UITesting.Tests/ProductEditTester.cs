using MbUnit.Framework;
using UITesting.Models;
using WatiN.Core;

namespace UITesting.Tests
{
    [TestFixture]
    public class ProductEditTester : WebTestBase
    {
        [Test]
        public void Should_update_product_price_successfully()
        {
            NavigateLink(LocalSiteMap.Nav.Products);

            Browser.Link(Find.ByText("Edit")).Click();

            ForForm<ProductForm>()
                .WithTextBox(form => form.Price, 389.99m)
                .Save();

            CurrentPageShouldBe(LocalSiteMap.Screen.Product.Index);

            ForPage<ProductListModel[]>()
                .FindText(products => products[0].Price, "389.99");
        }

        private FluentPage<TForm> ForPage<TForm>()
        {
            return new FluentPage<TForm>(Browser);
        }
    }
}