using System.Collections.Specialized;
using System.Globalization;
using System.Web.Mvc;
using NUnit.Framework;
using UnitTestingExamples.Helpers.Binders;

namespace UnitTestingExamples.Tests
{
    [TestFixture]
    public class EntityModelBinderTester
    {
        [Test]
        public void Should_bind_to_null_when_guid_not_in_correct_format()
        {
            var collection = new NameValueCollection();
            collection.Add("NotAGuid", "NotAGuid");
            var provider = new NameValueCollectionValueProvider(
                collection, CultureInfo.InvariantCulture);

            var bindingContext = new ModelBindingContext
                                     {
                                         ModelName = "ProductId",
                                         ValueProvider = provider
                                     };

            var binder = new EntityModelBinder();
            object model = binder.BindModel(null, bindingContext);

            Assert.IsNull(model);
        }
    }
}