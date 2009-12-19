using System;
using System.Linq;
using System.Web.Security;

namespace Roles
{
	public class DemoRoleProvider : RoleProvider
	{
		public const string DeveloperRole = "developers";
		public const string ReaderRole = "readers";
		public const string AdminRole = "admins";

		public string[] RolesDemoUserIsIn = new[] {DeveloperRole, ReaderRole};
		public string[] RolesDemoUserIsNotIn = new[] {AdminRole};

		public override bool IsUserInRole(string username, string roleName)
		{
			return RolesDemoUserIsIn.Contains(roleName);
		}

		public override string[] GetRolesForUser(string username)
		{
			return RolesDemoUserIsIn;
		}

		public override void CreateRole(string roleName)
		{
			throw new NotImplementedException();
		}

		public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
		{
			throw new NotImplementedException();
		}

		public override bool RoleExists(string roleName)
		{
			return RolesDemoUserIsNotIn.Union(RolesDemoUserIsIn).Contains(roleName);
		}

		public override void AddUsersToRoles(string[] usernames, string[] roleNames)
		{
			throw new NotImplementedException();
		}

		public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
		{
			throw new NotImplementedException();
		}

		public override string[] GetUsersInRole(string roleName)
		{
			if (RolesDemoUserIsIn.Contains(roleName))
				return new[] {DemoMembershipProvider.Username};
			
			return new string[0];
		}

		public override string[] GetAllRoles()
		{
			return RolesDemoUserIsIn.Union(RolesDemoUserIsNotIn).ToArray();
		}

		public override string[] FindUsersInRole(string roleName, string usernameToMatch)
		{
			throw new NotImplementedException();
		}

		public override string ApplicationName
		{
			get; set;
		}
	}
}