using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace UITesting
{
	public static class HtmlHelperExtensions
	{
		public static string Span<TModel>(this HtmlHelper<TModel> helper,
			Expression<Func<TModel, object>> field)
			where TModel : class
		{
			var id = UINameHelper.BuildIdFrom(field);

			var func = field.Compile();

			var value = func(helper.ViewData.Model);

			return string.Format("<span id='{0}'>{1}</span>", id, value);
		}
	}
}
