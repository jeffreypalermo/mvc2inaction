using System;

namespace T4Templates.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ActiveDate { get; set; }
        public DateTime RetireDate { get; set; }
    }
}