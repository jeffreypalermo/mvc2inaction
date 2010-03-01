using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NUnit.Framework;
using Rhino.Mocks;
using StateManagement.Controllers;

namespace StateManagement.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Index()
        {
            // Setup
            HomeController controller = new HomeController();

            // Execute
            ViewResult result = controller.Index() as ViewResult;

            // Verify
            ViewDataDictionary viewData = result.ViewData;
            Assert.AreEqual("Home Page", viewData["Title"]);
            Assert.AreEqual("Welcome to ASP.NET MVC!", viewData["Message"]);
        }

        [Test]
        public void About()
        {
            // Setup
            HomeController controller = new HomeController();

            // Execute
            ViewResult result = controller.About() as ViewResult;

            // Verify
            ViewDataDictionary viewData = result.ViewData;
            Assert.AreEqual("About Page", viewData["Title"]);
        }


        [Test]
        public void CacheTest()
        {            
            //setup controller w/ fake cache
            var fakeCache = MockRepository.GenerateStub<ICache>();
            var controller = new HomeController(fakeCache);

            //set the cache behavior
            fakeCache.Stub(x => x.Exists("test")).Return(false);

            //invoke the action
            controller.CacheTest();            

            //the item should have been added to the cache            
            fakeCache.AssertWasCalled(x => x.Add("test", "value"));

            //the item should be retrieved from the cache
            fakeCache.AssertWasCalled(x => x.Get<string>("test"));
        }



        [Test]
        public void SessionTest()
        {
            var controller = new HomeController();

            //setup fake session
            var httpContext = MockRepository.GenerateStub<HttpContextBase>();
            var mockSession = MockRepository.GenerateStub<HttpSessionStateBase>();
            httpContext.Stub(x => x.Session).Return(mockSession).Repeat.Any();

            //attach fake context/session to controller
            controller.ControllerContext = new ControllerContext(httpContext, new RouteData(), controller);

            //invoke action
            controller.ViewCart();

            //verify methods were called
            mockSession.VerifyAllExpectations();
        }
    }
}
