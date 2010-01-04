using System.Globalization;
using System.Web;
using System.Web.Mvc;

namespace ValueProvidersExample.Helpers
{
    public class SessionValueProvider : IValueProvider
    {
        private readonly HttpSessionStateBase _session;

        public SessionValueProvider(HttpSessionStateBase session)
        {
            _session = session;
        }

        public SessionValueProvider() : this(new HttpContextWrapper(HttpContext.Current).Session)
        {
        }

        public const string CurrentUserKey = "CurrentUser";

        public bool ContainsPrefix(string prefix)
        {
            return prefix == CurrentUserKey;
        }

        public ValueProviderResult GetValue(string key)
        {
            if (key != CurrentUserKey)
                return null;

            object currentUserInSession = _session[CurrentUserKey];

            if (currentUserInSession == null)
                return null;

            return new ValueProviderResult(currentUserInSession, CurrentUserKey, CultureInfo.InvariantCulture);
        }
    }
}