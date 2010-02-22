using System;
using System.Linq.Expressions;
using System.Threading;
using MbUnit.Framework;
using NBehave.Spec.MbUnit;
using UITesting.Models;
using WatiN.Core;

namespace UITesting.Tests
{
    //[TestFixture]
    //public class ProductEditTester : WebTestBase
    //{
    //    [Test]
    //    public void Should_update_product_price_successfully()
    //    {
    //        NavigateLink(LocalSiteMap.Nav.Products);

    //        Browser.Link(Find.ByText("Edit")).Click();

    //        ForForm<ProductForm>()
    //            .WithTextBox(form => form.Price, 389.99m)
    //            .Save();

    //        CurrentPageShouldBe(LocalSiteMap.Screen.Product.Index);

    //        ForPage<ProductListModel[]>()
    //            .FindText(products => products[0].Price, "389.99");
    //    }

    //    private FluentTable<TForm> ForPage<TForm>()
    //    {
    //        return new FluentTable<TForm>(Browser);
    //    }
    //}

    [TestFixture]
    [ApartmentState(ApartmentState.STA)]
    public class ProductEditTester
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

	internal class FluentTable<TForm>
	{
		private readonly IE _browser;

		public FluentTable(IE browser)
		{
			_browser = browser;
		}

		public void FindText<TField>(
			Expression<Func<TForm, TField>> func,
			string expected)
		{
			var spanId = UINameHelper.BuildIdFrom(func);

			var span = _browser.Span(Find.ById(spanId));

			span.Text.ShouldEqual(expected);
		}
	}
}