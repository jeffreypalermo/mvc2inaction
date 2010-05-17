using System.Threading;
using MbUnit.Framework;
using Should.Extensions.AssertExtensions;
using WatiN.Core;

namespace UITesting.Tests
{
    [TestFixture]
    [ApartmentState(ApartmentState.STA)]
    public class WebTestBase
    {
        private IE _ie;

        [SetUp]
        public virtual void SetUp()
        {
            _ie = new IE("http://localhost:8084/");
        }

        [TearDown]
        public virtual void TearDown()
        {
            if (_ie != null)
            {
                _ie.Dispose();
                _ie = null;
            }
        }

        protected IE Browser
        {
            get { return _ie; }
        }

        protected virtual void NavigateLink(string rel)
        {
            Link link = Browser.Link(Find.By("rel", rel));

            link.Click();
        }

        protected FluentForm<TForm> ForForm<TForm>()
        {
            return new FluentForm<TForm>(Browser);
        }

        protected void CurrentPageShouldBe(string pageId)
        {
            Browser.TextField(Find.ByName("pageId")).Value.ShouldEqual(pageId);
        }
    }
}