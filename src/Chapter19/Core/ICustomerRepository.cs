using System.Collections.Generic;
using System.Linq;
using Core.Database;
using Core.Model;

namespace Core
{
	public interface ICustomerRepository
	{
		Customer GetById(int id);
		IEnumerable<Customer> GetAll();
	}

	public class CustomerRepository : ICustomerRepository
	{
		private readonly FakeDatabase _database = new FakeDatabase();

		public Customer GetById(int id)
		{
			return _database.GetEverything().SingleOrDefault(customer => customer.Id == id);
		}

		public IEnumerable<Customer> GetAll()
		{
			return _database.GetEverything();
		}
	}
}