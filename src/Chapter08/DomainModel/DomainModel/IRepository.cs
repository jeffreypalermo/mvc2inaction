using System;
using DomainModel.Model;

namespace DomainModel
{
	public interface IRepository<T> where T : Entity
	{
		void Delete();
		T[] GetAll();
		T GetById(Guid id);
		void Save(T entity);
	}

	public interface IKeyedRepository<T> : IRepository<T> where T : Entity
	{
		T GetByKey(string key);
	}

	public interface IProductRepository : IKeyedRepository<Product>
	{
		Product GetMostOrderedProduct();
		Product GetMostExpensiveProduct();
		Product[] GetUnorderedProducts();
	}
}