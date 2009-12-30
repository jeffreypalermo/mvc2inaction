using System.Web.Mvc;
using AutoMapper;
using NUnit.Framework;

namespace WithAutomapper.Tests
{
	[TestFixture]
	public class AutoMapResultTester
	{
		public class TestResult : ActionResult
		{
			public bool Executed { get; private set; }

			public override void ExecuteResult(ControllerContext context)
			{
				Executed = true;
			}
		}

		[Test]
		public void Should_be_an_action_result()
		{
			var result = new AutoMapResult<string>(new ViewResult());
			Assert.That(result, Is.InstanceOf<ActionResult>());
		}

		[Test]
		public void Should_decorate_an_action_result()
		{
			var viewResult = new ViewResult();

			var result = new AutoMapResult<string>(viewResult);

			Assert.That(result.Inner, Is.SameAs(viewResult));
		}

		[Test]
		public void Should_invoke_execution_of_inner()
		{
			var inner = new TestResult();
			var result = new AutoMapResult<string>(inner);
			result.ExecuteResult(null);
			Assert.That(inner.Executed);
		}
	}

	public class AutoMapResult<TModel> : ActionResult
	{
		public AutoMapResult(ActionResult inner)
		{
			Inner = inner;
		}

		public ActionResult Inner { get; private set; }

		public override void ExecuteResult(ControllerContext context)
		{
			object source = context.Controller.ViewData.Model;
			// blarg
			object map = Mapper.Map(source, source.GetType(), typeof (TModel));
			context.Controller.ViewData.Model = map;

			Inner.ExecuteResult(context);
		}
	}
}