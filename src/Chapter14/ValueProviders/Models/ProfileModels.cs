using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ValueProvidersExample.Models
{
	using System.ComponentModel.DataAnnotations;

	public class LogOnWidgetModel
{
	public bool IsAuthenticated { get; set; }
	public Profile CurrentUser { get; set; }
}


	public class Profile
	{
		public Profile() {}
		public Profile(string username)
		{
			Username = username;
		}

		public string Username { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
        public string Email { get; set; }
	}

	public class ProfileEditModel
	{
		public ProfileEditModel(Profile profile)
		{
			Username = profile.Username;
			FirstName = profile.FirstName;
			LastName = profile.LastName;
			Email = profile.Email;
		}

		public ProfileEditModel()
		{
		}

		[ScaffoldColumn(false)]
		public string Username { get; set; }

		[DisplayName("First Name")]
        public string FirstName { get; set; }

		[DisplayName("Last Name")]
		public string LastName { get; set; }

		public string Email { get; set; }
	}

	public interface IProfileRepository
	{
		Profile[] GetAll();
		Profile Find(string username);
		void Add(Profile profile);
	}

	public class ProfileRepository : IProfileRepository
	{
		private static List<Profile> _profiles = new List<Profile>();

		static ProfileRepository() {
			_profiles.Add(new Profile("JPalermo") { FirstName = "Jeffrey", LastName = "Palermo", Email = "jeffrey@MVC2Demo.example" });
			_profiles.Add(new Profile("BScheirman") {FirstName = "Ben", LastName = "Scheirman", Email = "ben@MVC2Demo.example" });
			_profiles.Add(new Profile("MHinze") { FirstName = "Matt", LastName = "Hinze", Email = "matt@MVC2Demo.example" });
			_profiles.Add(new Profile("JBogard") {FirstName = "Jimmy", LastName = "Bogard", Email = "jimmy@MVC2Demo.example" });
			_profiles.Add(new Profile("EHexter") { FirstName = "Eric", LastName = "Hexter", Email = "eric@MVC2Demo.example" });

		}

		public Profile[] GetAll()
		{
			return _profiles.ToArray();
		}

		public Profile Find(string username)
		{
			return _profiles.FirstOrDefault(p => p.Username == username);
		}

		public void Add(Profile profile)
		{
			_profiles.Add(profile);
		}
	}
}