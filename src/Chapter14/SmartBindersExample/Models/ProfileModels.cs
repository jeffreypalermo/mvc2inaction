using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SmartBindersExample.Models
{
	public class Profile : Entity
	{
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

		public string Username { get; set; }

		[DisplayName("First Name")]
        public string FirstName { get; set; }

		[DisplayName("Last Name")]
		public string LastName { get; set; }

		public string Email { get; set; }
	}

	public interface IProfileRepository : IRepository<Profile>
	{
		Profile[] GetAll();
		Profile Find(string username);
	}

	public class ProfileRepository : Repository<Profile>, IProfileRepository
	{
		private static List<Profile> _profiles = new List<Profile>();

		static ProfileRepository() {
			_profiles.Add(new Profile("JPalermo") { Id = 1, FirstName = "Jeffrey", LastName = "Palermo", Email = "jeffrey@MVC2Demo.example" });
			_profiles.Add(new Profile("BScheirman") { Id = 2, FirstName = "Ben", LastName = "Scheirman", Email = "ben@MVC2Demo.example" });
			_profiles.Add(new Profile("MHinze") { Id = 3, FirstName = "Matt", LastName = "Hinze", Email = "matt@MVC2Demo.example" });
			_profiles.Add(new Profile("JBogard") { Id = 4, FirstName = "Jimmy", LastName = "Bogard", Email = "jimmy@MVC2Demo.example" });
			_profiles.Add(new Profile("EHexter") { Id = 5, FirstName = "Eric", LastName = "Hexter", Email = "eric@MVC2Demo.example" });

		}

		public Profile[] GetAll()
		{
			return _profiles.ToArray();
		}

		public override Profile Get(int id)
		{
			return _profiles.FirstOrDefault(p => p.Id == id);
		}

		public Profile Find(string username)
		{
			return _profiles.FirstOrDefault(p => p.Username == username);
		}

		public override void Add(Profile profile)
		{
			_profiles.Add(profile);
			profile.Id = _profiles.Max(p => p.Id) + 1;
		}
	}
}