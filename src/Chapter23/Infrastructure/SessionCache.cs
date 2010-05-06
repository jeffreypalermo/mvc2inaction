using System.Collections;
using System.Web;
using NHibernate;

namespace Infrastructure
{
	public class SessionCache
	{
		private const string SESSION_KEY = "NHIBERNATE_SESSION";
		private static readonly IDictionary _cacheStore = new Hashtable();

		public ISession GetSession()
		{
			var session = (ISession) GetCacheStore()[SESSION_KEY];
			return session;
		}

		public void CacheSession(ISession session)
		{
			GetCacheStore()[SESSION_KEY] = session;
		}

		private static IDictionary GetCacheStore()
		{
			if (HttpContext.Current != null)
				return HttpContext.Current.Items;

			return _cacheStore;
		}
	}
}