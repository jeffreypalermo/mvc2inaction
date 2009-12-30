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