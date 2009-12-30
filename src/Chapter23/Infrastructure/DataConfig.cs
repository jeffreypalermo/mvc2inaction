using System;
using System.IO;
using Core;
using FluentNHibernate.Cfg;
using log4net.Config;
using NHibernate;
using NHibernate.ByteCode.LinFu;
using NHibernate.Cfg;

namespace Infrastructure
{
	public class DataConfig
	{
		public static ISessionFactory SessionFactory;

		public void PerformStartup()
		{
			InitializeLog4Net();
			InitializeNHibernateSessionFactory();
			InitializeRepositories();
		}

		private void InitializeNHibernateSessionFactory()
		{
			//calling configure looks for a file named
			//hibernate.cfg.xml.  It reads this file
			Configuration configuration = BuildConfiguration();
			//We can build a session factory from the initialized
			//configuration and save it to a static property
			//so that it remains for the life of the appdomain
			SessionFactory = configuration.BuildSessionFactory();
		}

		public static Configuration BuildConfiguration()
		{
			return Fluently.Configure(new Configuration().Configure())
				.Mappings(cfg => cfg.FluentMappings.AddFromAssembly(typeof (VisitorMap).Assembly))
				.BuildConfiguration();
		}

		private void InitializeLog4Net()
		{
			//Initialize log4net from the config file.
			string configPath = Path.Combine(
				AppDomain.CurrentDomain.BaseDirectory,
				"Log4Net.config");
			var fileInfo = new FileInfo(configPath);
			XmlConfigurator.ConfigureAndWatch(fileInfo);
		}

		private void InitializeRepositories()
		{
			Func<IVisitorRepository> builder =
				() => new VisitorRepository();
			VisitorRepositoryFactory.RepositoryBuilder = builder;
		}

		public void StartSession()
		{
			//The session factory provides the session
			ISession session = SessionFactory.OpenSession();

			//In this context, we will use on transaction per 
			//web request
			session.BeginTransaction();
			var cache = new SessionCache();
			cache.CacheSession(session);
		}

		public void EndSession()
		{
			var cache = new SessionCache();
			ISession session = cache.GetSession();

			//Commit the transaction if it has not been
			//rolled back.
			ITransaction transaction = session.Transaction;
			if (transaction.IsActive)
			{
				transaction.Commit();
			}

			session.Dispose();
		}
	}
}