using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using SparkViewExample.Models;

namespace SparkViewExample.Controllers
{
    public class ProductController : Controller
    {
        public ViewResult Index()
        {
            var products = new[]
            {
                new Product
                {
                    Name = "Toothbrush",
                    Description = "Cleans your teeth",
                    Price = 2.49m
                },
                new Product
                {
                    Name = "Hairbrush",
                    Description = "Styles your hair",
                    Price = 10.29m
                },
                new Product
                {
                    Name = "Shoes",
                    Description = "Protects your feet",
                    Price = 55.99m
                },
            };
            return View(products);
        }
    }
}