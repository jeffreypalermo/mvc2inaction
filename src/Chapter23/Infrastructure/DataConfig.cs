using System;
using System.IO;
using Core;
using FluentNHibernate.Cfg;
using log4net.Config;
using NHibernate;
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
            Configuration configuration =
                BuildConfiguration();
            SessionFactory =
                configuration.BuildSessionFactory();
        }

        public static Configuration BuildConfiguration()
        {
            return
                Fluently.Configure(
                    new Configuration().Configure())
                    .Mappings(
                    cfg =>
                    cfg.FluentMappings.AddFromAssembly(
                        typeof (VisitorMap).Assembly))
                    .BuildConfiguration();
        }

        private void InitializeLog4Net()
        {
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
            VisitorRepositoryFactory.RepositoryBuilder =
                builder;
        }

        public void StartSession()
        {
            ISession session = SessionFactory.OpenSession();
            session.BeginTransaction();
            var cache = new SessionCache();
            cache.CacheSession(session);
        }

        public void EndSession()
        {
            var cache = new SessionCache();
            ISession session = cache.GetSession();
            ITransaction transaction = session.Transaction;
            if (transaction.IsActive)
            {
                transaction.Commit();
            }

            session.Dispose();
        }
    }
}