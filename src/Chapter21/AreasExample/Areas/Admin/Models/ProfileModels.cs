using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AreasExample.Areas.Admin.Models
{
	public class Profile
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

	public class EditProfileInput
	{
		public EditProfileInput(Profile profile)
		{
			Username = profile.Username;
			FirstName = profile.FirstName;
			LastName = profile.LastName;
			Email = profile.Email;
		}

		public EditProfileInput()
		{
		}

		[Required]
		public string Username { get; set; }

		[DisplayName("First Name")]
		public string FirstName { get; set; }

		[DisplayName("Last Name")]
		public string LastName { get; set; }

		public string Email { get; set; }
	}


	public interface IProfileRepository
	{
		IEnumerable<Profile> GetAll();
		Profile Find(string username);
		void Add(Profile profile);
		IQueryable<Profile> Find();
	}

	public class ProfileRepository : IProfileRepository
	{
		private static List<Profile> _profiles = new List<Profile>();

		static ProfileRepository() {
			_profiles.Add(new Profile("JPalermo") { FirstName = "Jeffrey", LastName = "Palermo", Email = "jeffrey@MVC2Demo.example" });
			_profiles.Add(new Profile("BScheirman") { FirstName = "Ben", LastName = "Scheirman", Email = "ben@MVC2Demo.example" });
			_profiles.Add(new Profile("MHinze") { FirstName = "Matt", LastName = "Hinze", Email = "matt@MVC2Demo.example" });
			_profiles.Add(new Profile("JBogard") { FirstName = "Jimmy", LastName = "Bogard", Email = "jimmy@MVC2Demo.example" });
			_profiles.Add(new Profile("EHexter") { FirstName = "Eric", LastName = "Hexter", Email = "eric@MVC2Demo.example" });

		}

		public IEnumerable<Profile> GetAll()
		{
			return _profiles;
		}

		public Profile Find(string username)
		{
			return _profiles.FirstOrDefault(p => p.Username == username);
		}

		public void Add(Profile profile)
		{
			_profiles.Add(profile);
		}

		public IQueryable<Profile> Find()
		{
			return _profiles.AsQueryable();
		}
	}
}