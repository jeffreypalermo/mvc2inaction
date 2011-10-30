using System;
using System.Web.Mvc;
using AjaxExamples.Models;

namespace AjaxExamples.Controllers
{
    public class SessionsController : Controller
    {
        private SessionRepository _repository;

        public SessionsController() : this(new SessionRepository())
        {
        }

        public SessionsController(SessionRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var sessions = _repository.FindAll();

            //for ajax requests, we simply need to render the partial
            if(Request.IsAjaxRequest())
                return View("_sessionList", sessions);

            return View(sessions);
        }

        [HttpPost]
        public ActionResult Add(Session session)
        {
            _repository.SaveSession(session);

            if (Request.IsAjaxRequest())
                return Index();

            return RedirectToAction("index");
        }

        [HttpPost]
        public ActionResult Remove(Guid session_id)
        {
            _repository.RemoveSession(session_id);
            return RedirectToAction("index");
        }
    }
}