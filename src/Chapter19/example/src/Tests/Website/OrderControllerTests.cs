using MvcContrib.TestHelper;
using NUnit.Framework;
using Website.Controllers;

namespace Tests.Website
{
   public class OrderControllerTests
   {
      [Test]
      public void Should_send_message_and_direct_storyboard_flow()
      {
         var controller = new OrderController(null);

         var result = controller.Ship(5);

         Assert.That(((ShipOrderMessage) result.Message).OrderId,
                     Is.EqualTo(5));
         result.Success
            .AssertActionRedirect().ToAction("Shipped");
         result.Failure
            .AssertActionRedirect().ToAction("NotShipped");
      }
   }
}