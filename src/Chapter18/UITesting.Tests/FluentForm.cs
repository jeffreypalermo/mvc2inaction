using System;
using System.Linq.Expressions;
using WatiN.Core;

namespace UITesting.Tests
{
	public class FluentForm<TForm>
	{
		private readonly IE _browser;

		public FluentForm(IE browser)
		{
			_browser = browser;
		}

		public FluentForm<TForm> WithTextBox<TField>(
			Expression<Func<TForm, TField>> field,
			TField value)
		{
			var name = UINameHelper.BuildNameFrom(field);

			_browser.TextField(Find.ByName(name)).TypeText(value.ToString());

			return this;
		}

		public void Save()
		{
			_browser.Forms[0].Submit();
		}
	}
}