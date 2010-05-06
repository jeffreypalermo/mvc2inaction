using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AreasExample.Areas.Admin.Models;

namespace AreasExample.Areas.Admin.Controllers
{
    public partial class ProfileController : Controller
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileController(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public ProfileController() : this(new ProfileRepository()) { }


public virtual ActionResult Index()
{
    var profiles = _profileRepository.GetAll();

    return View(profiles);
}

        public virtual ViewResult Show(string username)
        {
            var profile = _profileRepository.Find(username);
            if (profile == null)
            {
                profile = new Profile(username);
                _profileRepository.Add(profile);
            }

            return View(profile);
        }

        public virtual ViewResult Edit(string username)
        {
            var profile = _profileRepository.Find(username);

            return View(new EditProfileInput(profile));
        }

		[HttpPost]
		public ActionResult Edit(EditProfileInput profile) {
			var existingProfile = _profileRepository.Find(profile.Username);
			existingProfile.Email = profile.Email;
			existingProfile.FirstName = profile.FirstName;
			existingProfile.LastName = profile.LastName;

			return RedirectToAction("Index");
		}
    }
}
