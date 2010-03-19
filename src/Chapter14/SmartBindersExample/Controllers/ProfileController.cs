using System;
using System.Web.Mvc;
using System.Web.UI;
using SmartBindersExample.Models;

namespace SmartBindersExample.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileController(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public ProfileController() : this(new ProfileRepository()) { }

        public ViewResult Index()
        {
            var profiles = _profileRepository.GetAll();
            return View(profiles);
        }

        public ViewResult Show(string username)
        {
            var profile = _profileRepository.Find(username);
            if (profile == null)
            {
                profile = new Profile(username);
                _profileRepository.Add(profile);
            }

            return View(profile);
        }

        public ViewResult Edit(Profile id)
        {
            return View(new ProfileEditModel(id));
        }

        public RedirectToRouteResult Save(ProfileEditModel form)
        {
            var profile = _profileRepository.Find(form.Username);

            profile.Email = form.Email;
            profile.FirstName = form.FirstName;
            profile.LastName = form.LastName;

            return RedirectToAction("Index");
        }

    }
}