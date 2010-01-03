using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AreasExample.Areas.Admin.Models;

namespace AreasExample.Areas.Admin.Controllers
{
    public class ProfileController : Controller
    {
		private readonly IProfileRepository _profileRepository;

		public ProfileController(IProfileRepository profileRepository)
		{
			_profileRepository = profileRepository;
		}

		public ProfileController() : this(new ProfileRepository()) { }


        public ActionResult Index()
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

			bool hasPermission = User.Identity.Name == username;

			ViewData["hasPermission"] = hasPermission;

			return View(profile);
		}

		public ViewResult Edit(string username)
		{
			var profile = _profileRepository.Find(username);
			return View(new EditProfileInput(profile));
		}
    }
}
