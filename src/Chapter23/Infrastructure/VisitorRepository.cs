using System.Collections.Generic;
using System.Linq;
using Core;
using NHibernate;

namespace Infrastructure
{
	public class VisitorRepository : IVisitorRepository
	{
		public void Save(Visitor visitor)
		{
			ISession session = GetSession();
			session.SaveOrUpdate(visitor);
		}

		public Visitor[] GetRecentVisitors(int numberOfVisitors)
		{
			//using Hibernate Query Language to select Visitors
			IList<Visitor> visitors = GetSession()
				.CreateQuery("select v from Visitor v order by v.VisitDate desc")
				.SetMaxResults(numberOfVisitors)
				.List<Visitor>();
			
			//After listing the visitors, we want to return
			//an array.
			return visitors.ToArray();
		}

		private ISession GetSession()
		{
			//Retrieves a session from our own cache
			var cache = new SessionCache();
			ISession session = cache.GetSession();
			return session;
		}
	}
}