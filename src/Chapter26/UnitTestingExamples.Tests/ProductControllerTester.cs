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
    public class ProductControllerTester
    {
        [Test]
        public void Index_should_use_default_view_and_repository_data()
        {
            var products =
                new[]
                    {
                        new Product {Name = "Keyboard"},
                        new Product {Name = "Mouse"}
                    };

            var repository =
                MockRepository.GenerateStub<IProductRepository>();
            repository.Stub(rep => rep.FindAll()).Return(products);

            var controller = new ProductsController(repository);

            ViewResult result = controller.Index();

            Assert.AreEqual("", result.ViewName);
            Assert.AreEqual(products, result.ViewData.Model);
        }

        [Test]
        public void Edit_should_redirect_back_when_model_errors_present()
        {
            var badProduct = new Product {Name = "Bad value"};

            var repository =
                MockRepository.GenerateStub<IProductRepository>();

            var controller = new ProductsController(repository);
            controller.ModelState
                .AddModelError("Name",
                               "Name already exists");

            ActionResult result = controller.Edit(badProduct);

            Assert.AreEqual("", result.AssertViewRendered().ViewName);
            repository.AssertWasNotCalled(rep => rep.Save(badProduct));
        }

        [Test]
        public void
            Edit_should_save_and_redirect_when_no_model_errors_present()
        {
            var goodProduct = new Product {Name = "Good value"};

            var repository =
                MockRepository.GenerateStub<IProductRepository>();

            var productsController = new ProductsController(repository);

            ActionResult result = productsController.Edit(goodProduct);

            repository.AssertWasCalled(rep => rep.Save(goodProduct));
            var redirectResult = result as RedirectToRouteResult;
            Assert.IsNotNull(redirectResult);
            Assert.AreEqual(1, redirectResult.RouteValues.Count);
            Assert.AreEqual("index", redirectResult.RouteValues["action"]);
        }
    }
}