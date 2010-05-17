using System;
using System.Linq.Expressions;
using Should.Extensions.AssertExtensions;
using WatiN.Core;

namespace UITesting.Tests
{
    public class FluentPage<TModel>
    {
        private readonly IE _browser;

        public FluentPage(IE browser)
        {
            _browser = browser;
        }

        public FluentPage<TModel> FindText<TField>(
            Expression<Func<TModel, TField>> field,
            TField value)
        {
            string name = UINameHelper.BuildIdFrom(field);

            Span span = _browser.Span(Find.ById(name));

            span.Text.ShouldEqual(value.ToString());

            return this;
        }
    }
}