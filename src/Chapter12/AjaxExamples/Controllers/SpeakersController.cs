using System.Web.Mvc;
using AjaxExamples.Models;

namespace AjaxExamples.Controllers
{
    public class SpeakersController : Controller
    {
        private readonly SpeakerRepository _repository = new SpeakerRepository();

        public ActionResult Index()
        {
            var speakers = _repository.FindAll();
            return View(speakers);
        }
        
        public ActionResult Details(string urlKey, string format)
        {            
            var speaker = _repository.FindSpeakerByUrlKey(urlKey);

            if (format == "json")
                return Json(speaker, JsonRequestBehavior.AllowGet);

            return View(speaker);
        }
    }
}