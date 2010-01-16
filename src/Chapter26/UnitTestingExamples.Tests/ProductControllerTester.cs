using System.Web.Mvc;
using MvcContrib.TestHelper;
using NUnit.Framework;
using Rhino.Mocks;
using UnitTestingExamples.Controllers;
using UnitTestingExamples.Models;
using UnitTestingExamples.Services;

namespace UnitTestingExamples.Tests
{
    [TestFixture]
    public class ProductControllerTester : TestClassBase
    {
        [Test]
        public void Index_should_use_default_view_and_repository_data()
        {
            var products = new[]
                               {
                                   new Product {Name = "Keyboard"},
                                   new Product {Name = "Mouse"}
                               };

            var repository = Stub<IProductRepository>();
            repository.Stub(rep => rep.FindAll()).Return(products);

            var productsController = new ProductsController(repository);

            ViewResult result = productsController.Index();

            Assert.AreEqual("", result.ViewName);
            Assert.AreEqual(products, result.ViewData.Model);
        }

        [Test]
        public void Edit_should_redirect_back_when_model_errors_present()
        {
            var badProduct = new Product {Name = "Bad value"};

            var repository = Stub<IProductRepository>();

            var productsController = new ProductsController(repository);
            productsController.ModelState.AddModelError("Name",
                                                        "Name already exists");

            ActionResult result = productsController.Edit(badProduct);

            Assert.AreEqual("", result.AssertViewRendered().ViewName);
            repository.AssertWasNotCalled(rep => rep.Save(badProduct));
        }
    }

    public class TestClassBase
    {
        protected T Stub<T>() where T : class
        {
            return MockRepository.GenerateStub<T>();
        }
    }
}