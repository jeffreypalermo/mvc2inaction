using System;
using AutoMapper;
using Core.Model;
using NUnit.Framework;
using WithAutomapper.Models;

namespace WithAutomapper.Tests
{
	[TestFixture]
	public class AutoMapperExample1
	{
		private static Customer GetCustomerGraph()
		{
			var product = new Product {Price = 10m};

			var order = new Order
			            	{
			            		Status = OrderStatus.Shipped,
			            		ShipDate = new DateTime(2010, 1, 2)
			            	};

			order.AddOrderLine(2, product);

			var order1 = new Order
			             	{
			             		Status = OrderStatus.Shipped,
			             		ShipDate = new DateTime(2010, 1, 1)
			             	};

			order1.AddOrderLine(3, product);

			var customer = new Customer
			               	{
			               		Status = CustomerStatus.Normal,
			               		Name = new Name {First = "Joe", Last = "Smith"}
			               	};

			customer.AddOrder(order);
			customer.AddOrder(order1);

			return customer;
		}

		public class Source
		{
			public int Number { get; set; }
		}

		public class Destination
		{
			public string Number { get; set; }
		}

		[Test]
		public void SimpleDemonstration()
		{
			Mapper.CreateMap<Source, Destination>();
			var source = new Source {Number = 3};
			Destination destination =
				Mapper.Map<Source, Destination>(source);
			Console.WriteLine(destination.Number);
		}

		[Test]
		public void ComplexDemonstration()
		{
			Mapper.CreateMap<Customer, CustomerDestination>();
			Mapper.CreateMap<Order, OrderDestination>();

			Customer customer = GetCustomerGraph();

			CustomerDestination destination = Mapper.Map<Customer, CustomerDestination>(customer);

			Console.WriteLine(destination.NameFirst);
			Console.WriteLine(destination.NameLast);
			Console.WriteLine(destination.TotalAmountPaid);

			foreach (var order in destination.ShippedOrders)
			{
				Console.WriteLine(order.ShipDate);
			}
		}
	}
}