using System.Collections.Generic;
using UITesting.Core.Domain;

namespace UITesting.Core.Services
{
	public interface IProductRepository
	{
		IEnumerable<Product> FindAll();
		Product GetById(int id);
		void Save(Product product);
	}
}