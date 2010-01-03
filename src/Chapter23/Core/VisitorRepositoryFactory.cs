using System;

namespace Core
{
	public class VisitorRepositoryFactory
	{
		//meant to be set on application start
		public static Func<IVisitorRepository> RepositoryBuilder = 
			CreateDefaultRepositoryBuilder;

		private static IVisitorRepository CreateDefaultRepositoryBuilder()
		{
			//throw if factory not initialized
			throw new Exception("No repository builder specified.");
		}

		public IVisitorRepository BuildRepository()
		{
			//Uses the Func<IVisitorRepository> to build the instance
			IVisitorRepository repository = RepositoryBuilder();
			return repository;
		}
	}
}