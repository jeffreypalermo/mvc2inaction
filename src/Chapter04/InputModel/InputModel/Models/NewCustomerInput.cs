using System;
using System.Linq;

namespace InputModel.Models
{
	public class NewCustomerInput
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public bool Active { get; set; }
	}
}