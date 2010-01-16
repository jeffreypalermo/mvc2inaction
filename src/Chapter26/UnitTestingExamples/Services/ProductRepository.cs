using System;
using UnitTestingExamples.Models;

namespace UnitTestingExamples.Services
{
    public class ProductRepository : IProductRepository
    {
        public Product[] FindAll()
        {
            return new[]
            {
                new Product {Category = "Electronics", Name = "Panasony HDTV", Price = 2199.99m},
                new Product {Category = "Appliances", Name = "Stainless Refrigerator", Price = 2359.96m},
                new Product {Category = "Outdoors", Name = "Rokia Lawnmower", Price = 239.99m},
            };
        }

        public void Save(Product product)
        {
        }
    }

    public interface IProductRepository
    {
        Product[] FindAll();
        void Save(Product product);
    }
}