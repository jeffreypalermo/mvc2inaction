using System;
using System.Globalization;
using System.Web.Mvc;
using ValueProvidersExample.Models;

namespace ValueProvidersExample.Helpers
{
	public class SessionValueProvider : IValueProvider
	{
		public const string CurrentUserKey = "CurrentUser";

		public bool ContainsPrefix(ControllerContext controllerContext, string prefix)
		{
			return prefix == CurrentUserKey;
		}

		public ValueProviderResult GetValue(ControllerContext controllerContext, string key)
		{
			if (key != CurrentUserKey)
				return null;

			var currentUserInSession = controllerContext.HttpContext.Session[CurrentUserKey];

			if (currentUserInSession == null)
				return null;

			return new ValueProviderResult(currentUserInSession, CurrentUserKey, CultureInfo.InvariantCulture);
		}
	}
}