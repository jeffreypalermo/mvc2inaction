using System.Web.Mvc;
using Core;

namespace UI
{
	public class VisitorAdditionFilter : ActionFilterAttribute
	{
		private readonly IVisitorRepository _repository;

		public VisitorAdditionFilter(IVisitorRepository repository)
		{
			_repository = repository;
		}

		public VisitorAdditionFilter() :
			this(new VisitorRepositoryFactory().BuildRepository())
		{
		}

		public override void OnResultExecuting(ResultExecutingContext filterContext)
		{
			var builder = new VisitorBuilder();
			Visitor visitor = builder.BuildVisitor();
			_repository.Save(visitor);
		}
	}
}