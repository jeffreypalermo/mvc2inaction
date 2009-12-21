using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AccountProfile.Models
{
	public class LogOnWidgetModel
	{
		public LogOnWidgetModel(bool isAuthenticated, Profile profile)
		{
			IsAuthenticated = isAuthenticated;
			Profile = profile;
		}

		public bool IsAuthenticated { get; private set; }
		public Profile Profile { get; private set; }
	}

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

	public class ProfileSearchCriteria
	{
		[DisplayName("First Name")]
		public string FirstName { get; set; }

		[DisplayName("Last Name")]
		public string LastName { get; set; }
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