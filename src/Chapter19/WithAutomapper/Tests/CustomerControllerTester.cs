using NUnit.Framework;
using WithAutomapper.Controllers;
using WithAutomapper.Models;

namespace WithAutomapper.Tests
{
	public class CustomerControllerTester
	{
		[Test]
		public void Should_put_auto_mapped_customer_in_view_data()
		{
			var controller = new CustomerController();
			var result = controller.Index();
			Assert.That(result.DesinationType, Is.EqualTo(typeof (CustomerInfo)));
			Assert.That(result.ViewData.Model, Is.TypeOf<Customer>());
		}
	}
}