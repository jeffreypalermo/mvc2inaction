using System.Collections.Generic;
using Core.Model;

namespace Core.Database
{
	public class FakeDatabase
	{
		public IEnumerable<Customer> GetEverything()
		{
			var product = new Product
			              	{
			              		Id = 1,
			              		Name = "MT 1000 Computer Mouse",
			              		Description = "High speed gaming mouse",
			              		Price = 35M
			              	};

			var product2 = new Product
			               	{
			               		Id = 2,
			               		Name = "KeyTech Keyboard 107",
			               		Description = "Customizable 107 key keyboard for Windows",
			               		Price = 50M
			               	};

			var product3 = new Product
			               	{
			               		Id = 3,
			               		Name = "UberMon Display X60",
			               		Description = "24' LCD monitor",
			               		Price = 150M
			               	};

			var customer1 = new Customer
			                	{
			                		Id = 1,
			                		Name = new Name("Jeffrey", "Palermo"),
			                		ShippingAddress = new Address
			                		                  	{
			                		                  		Line1 = "123 Any Street",
			                		                  		City = "Austin",
			                		                  		State = State.Texas,
			                		                  		Zip = "78735"
			                		                  	},
			                		Status = CustomerStatus.Gold
			                	};

			var customer2 = new Customer
			                	{
			                		Id = 2,
			                		Name = new Name("Ben", "Scheirman") {Middle = "David", Suffix = Suffix.SR},
			                		ShippingAddress = new Address
			                		                  	{
			                		                  		Line1 = "400 Main Street",
			                		                  		Line2 = "Suite 300",
			                		                  		City = "Houston",
			                		                  		State = State.Texas,
			                		                  		Zip = "77722"
			                		                  	},
			                		Status = CustomerStatus.Platinum
			                	};

			var customer3 = new Customer
			                	{
			                		Id = 3,
			                		Name = new Name("Jimmy", "Bogard") {Suffix = Suffix.JR},
			                		ShippingAddress = new Address
			                		                  	{
			                		                  		Line1 = "One Microsoft Way",
			                		                  		City = "Redmond",
			                		                  		State = State.Washington,
			                		                  		Zip = "98052"
			                		                  	},
			                		Status = CustomerStatus.Gold
			                	};

			return new[] {customer1, customer2, customer3};
		}
	}
}