using System;

namespace T4Templates.Models
{
    public class ProductRepository : IProductRepository
    {
        public Product GetProduct(int id)
        {
            return new Product
                       {
                           Id = id,
                           Name = "1988 Lego Auto Chassis",
                           Description = "Most awesome kit ever",
                           ActiveDate = new DateTime(1988, 1, 1),
                           RetireDate = new DateTime(1993, 3, 15)
                       };
        }
    }
}