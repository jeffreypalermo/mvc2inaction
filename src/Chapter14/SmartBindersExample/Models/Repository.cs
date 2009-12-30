namespace SmartBindersExample.Models
{
	public interface IRepository
	{
		Entity GetById(int id);
	}

	public interface IRepository<TEntity> : IRepository
		where TEntity : Entity
	{
		TEntity Get(int id);
		void Add(TEntity entity);
	}


	public abstract class Repository<TEntity> : IRepository<TEntity>
		where TEntity : Entity
	{
		Entity IRepository.GetById(int id)
		{
			return Get(id);
		}

		public abstract TEntity Get(int id);
		public abstract void Add(TEntity entity);
	}
}