using Infrastructure;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace IntegrationTests
{
	[TestFixture]
	public class DatabaseTester
	{
		[Test, Explicit]
		public void CreateDatabaseSchmea()
		{
			var export = new SchemaExport(DataConfig.BuildConfiguration());
			export.Execute(true, true, false);
		}
	}
}