using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
	public class UserController : Controller
	{
		public ActionResult Index()
		{
			IEnumerable<User> users = UserRepository.GetAll();

			UserDisplay[] viewModel = users.Select(
				user => new UserDisplay
				        	{
				        		Username = user.Username
				        	}).ToArray();

			return View(viewModel);
		}


		[HttpGet]
		public ActionResult Edit(int Id)
		{
			User users = UserRepository.GetById(Id);

			UserInput viewModel = new UserInput()
			                      	{
			                      		Username = users.Username
			                      	};
			return View(viewModel);
		}


		[HttpPost]
		public ActionResult Edit(UserInput input)
		{
			if (ModelState.IsValid)
			{
				//do some work to update a User from the UserInput and persist the User to the database.
				return RedirectToAction("index"); //Successful Flow
				//Post Redirect Get
			}

			return new ViewResult(){
				ViewData = this.ViewData,
				TempData = this.TempData,
				ViewName = ""};// Failure Flow}
		}
	}

	public class UserDisplay
	{
		public string Username { get; set; }
	}

	public class UserInput
	{
		public string Username;
	}


	public static class UserRepository
	{
		public static IEnumerable<User> GetAll()
		{
			return new[]
			       	{
			       		new User {Username = "FFlintstone"},
			       		new User {Username = "bruble"},
			       		new User {Username = "bambam"},
			       		new User {Username = "wilma"},
			       		new User {Username = "pebles"},
			       		new User {Username = "dino"},
			       	};
		}

		public static User GetById(int id)
		{
			return new User(){Username = "FFlintstone"};
		}
	}

	public class User
	{
		public string Username { get; set; }
	}
}