using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Infrastructure;
using NHibernate;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace IntegrationTests
{
    [TestFixture]
    public class VisitorRepositoryTester
    {
        [SetUp]
        public void Setup()
        {
            new DatabaseTester().CreateDatabaseSchmea();
        }

        [Test]
        public void When_saving_should_write_to_database()
        {
            var config = new DataConfig();
            config.PerformStartup();
            config.StartSession();

            var visitor = new Visitor
                              {
                                  Browser = "1",
                                  IpAddress = "2",
                                  LoginName = "3",
                                  PathAndQuerystring = "4",
                                  VisitDate =
                                      new DateTime(2000, 1, 1)
                              };

            var repository = new VisitorRepository();
            repository.Save(visitor);

            config.EndSession();
            config.StartSession();

            ISession session = new SessionCache().GetSession();
            var loadedVisitor = session.Load<Visitor>(visitor.Id);

            Assert.That(loadedVisitor, Is.Not.Null);
            Assert.That(loadedVisitor.Browser, Is.EqualTo("1"));
            Assert.That(loadedVisitor.IpAddress, Is.EqualTo("2"));
            Assert.That(loadedVisitor.LoginName, Is.EqualTo("3"));
            Assert.That(loadedVisitor.PathAndQuerystring,
                        Is.EqualTo("4"));
            Assert.That(loadedVisitor.VisitDate,
                        Is.EqualTo(new DateTime(2000, 1, 1)));
        }

        [Test]
        public void Should_get_two_most_recent_visitors()
        {
            var config = new DataConfig();
            config.PerformStartup();

            Visitor visitor1 =
                CreateVisitor(new DateTime(2000, 1, 1));
            Visitor visitor2 =
                CreateVisitor(new DateTime(2000, 1, 2));
            Visitor visitor3 =
                CreateVisitor(new DateTime(2000, 1, 3));
            config.StartSession();
            using (
                ISession session1 =
                    new SessionCache().GetSession())
            {
                session1.SaveOrUpdate(visitor1);
                session1.SaveOrUpdate(visitor2);
                session1.SaveOrUpdate(visitor3);
                session1.Flush();
                config.EndSession();
            }

            config.StartSession();

            var repository = new VisitorRepository();
            Visitor[] recentVisitors =
                repository.GetRecentVisitors(2);
            config.EndSession();

            Assert.That(recentVisitors.Length, Is.EqualTo(2));
            IEnumerable<Guid> idList =
                recentVisitors.Select(x => x.Id);
            Assert.That(idList.Contains(visitor3.Id), Is.True);
            Assert.That(idList.Contains(visitor2.Id), Is.True);
            Assert.That(idList.Contains(visitor1.Id), Is.False);
        }

        private Visitor CreateVisitor(DateTime visitDate)
        {
            return new Visitor
                       {
                           Browser = "1",
                           IpAddress = "2",
                           LoginName = "3",
                           PathAndQuerystring = "4",
                           VisitDate = visitDate
                       };
        }
    }
}