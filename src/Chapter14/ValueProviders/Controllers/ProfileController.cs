using System;
using System.Web.Mvc;
using System.Web.UI;
using ValueProvidersExample.Models;

namespace ValueProvidersExample.Controllers
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

			bool hasPermission = User.Identity.Name == username;

			ViewData["hasPermission"] = hasPermission;

			return View(profile);
		}

		public ViewResult Edit(string username)
		{
			var profile = _profileRepository.Find(username);
			return View(new ProfileEditModel(profile));
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