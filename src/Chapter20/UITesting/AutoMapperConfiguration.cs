using AutoMapper;
using UITesting.Core.Domain;
using UITesting.Models;

namespace UITesting
{
	public static class AutoMapperConfiguration
	{
		public static void Configure()
		{
			Mapper.CreateMap<Product, ProductListModel>();
			Mapper.CreateMap<Product, ProductForm>();
		}
	}
}