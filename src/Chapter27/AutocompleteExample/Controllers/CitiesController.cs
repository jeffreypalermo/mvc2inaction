using System.Web.Mvc;
using AutocompleteExample.Models;

namespace AutocompleteExample.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICityRepository _repository;

        public CitiesController()
        {
            string csvPath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/cities.csv");
            _repository = new CityRepository(csvPath);
        }

        public CitiesController(ICityRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Find(string q)
        {
            string[] cities = _repository.FindCities(q);
            return Content(string.Join("\n", cities));
        }
    }
}