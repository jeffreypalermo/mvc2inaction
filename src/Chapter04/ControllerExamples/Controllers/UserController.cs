using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<User> users =
                UserRepository.GetAll();

            UserDisplay[] viewModel = users.Select(
                user => new UserDisplay
                            {
                                Username = user.Username,
                                Name =
                                    user.FirstName + " " +
                                    user.LastName
                            }).ToArray();

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Display(int Id)
        {
            User user = UserRepository.GetById(Id);

            var viewModel = new UserDisplay
                                {
                                    Username = user.Username,
                                    Name =
                                        user.FirstName + " " +
                                        user.LastName
                                };
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            User users = UserRepository.GetById(Id);

            var viewModel = new UserInput
                                {
                                    Username =
                                        users.Username,
                                    FirstName =
                                        users.FirstName,
                                    LastName =
                                        users.LastName,
                                };
            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Edit(UserInput input)
        {
            if (ModelState.IsValid)
            {
                UpdateUserFromInput(input);
                TempData["message"] = "The user was updated";
                return RedirectToAction("index");
            }

            return View(input);
        }

        private void UpdateUserFromInput(UserInput input)
        {
            User user =
                UserRepository.GetByUsername(input.Username);
            user.FirstName = input.FirstName;
            user.LastName = input.LastName;
            UserRepository.Save(user);
        }
    }

    public class UserDisplay
    {
        public string Username { get; set; }
        public string Name { get; set; }
    }

    public class UserInput
    {
        [Required]
        public string Username { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }


    public static class UserRepository
    {
        public static IEnumerable<User> GetAll()
        {
            return new[]
                       {
                           new User
                               {
                                   Username = "FFlintstone",
                                   FirstName = "Fred",
                                   LastName = "Flintstone"
                               },
                           new User
                               {
                                   Username = "brubble",
                                   FirstName = "Barney",
                                   LastName = "Rubble"
                               },
                           new User
                               {
                                   Username = "bbrubble",
                                   FirstName = "Bamm-Bamm",
                                   LastName = "Rubble"
                               },
                           new User
                               {
                                   Username = "wilma",
                                   FirstName = "Wilma",
                                   LastName = "Flintstone"
                               },
                           new User
                               {
                                   Username = "pebbles",
                                   FirstName = "Pebbles",
                                   LastName = "Flintstone"
                               },
                           new User
                               {
                                   Username = "dino",
                                   FirstName = "Dino",
                                   LastName = "Flintstone"
                               },
                       };
        }

        public static User GetById(int id)
        {
            if (id == 2)
                return new User();
            return new User
                       {
                           Username = "FFlintstone",
                           FirstName = "Fred",
                           LastName = "Flintstone"
                       };
        }

        public static User GetByUsername(string username)
        {
            return
                GetAll().Where(s => s.Username == username).
                    FirstOrDefault();
        }

        public static void Save(User user)
        {
            
        }
    }

    public class User
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}