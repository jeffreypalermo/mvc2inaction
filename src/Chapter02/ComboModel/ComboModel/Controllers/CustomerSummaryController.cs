using System.Collections.Generic;
using System.Web.Mvc;
using ComboModel.Models;

namespace ComboModel.Controllers
{
    public class CustomerSummaryController : Controller
    {
        private readonly CustomerSummaries _customerSummaries = new CustomerSummaries();

        public ViewResult Index()
        {
            IEnumerable<CustomerSummary> summaries =
                _customerSummaries.GetAll();

            return View(summaries);
        }

        public ViewResult Save
            (List<CustomerSummary.CustomerSummaryInput> input)
        {
            return View(input);
        }
    }

    public class CustomerSummaries
    {
        public IEnumerable<CustomerSummary> GetAll()
        {
            return new[]
                       {
                           new CustomerSummary
                               {
                                   Input = new CustomerSummary.CustomerSummaryInput {Active = true, Number = 4},
                                   FirstName = "John",
                                   LastName = "Smith",
                                   MostRecentOrderDate = "02/07/10",
                                   OrderCount = "42",
                                   ServiceLevel = "Standard"
                               },
                           new CustomerSummary
                               {
                                   Input = new CustomerSummary.CustomerSummaryInput {Active = false, Number = 5},
                                   FirstName = "Susan",
                                   LastName = "Power",
                                   MostRecentOrderDate = "02/02/10",
                                   OrderCount = "1",
                                   ServiceLevel = "Standard"
                               },
                           new CustomerSummary
                               {
                                   Input = new CustomerSummary.CustomerSummaryInput {Active = true, Number = 6},
                                   FirstName = "Jim",
                                   LastName = "Doe",
                                   MostRecentOrderDate = "02/09/10",
                                   OrderCount = "7",
                                   ServiceLevel = "Premier"
                               },
                       };
        }
    }
}