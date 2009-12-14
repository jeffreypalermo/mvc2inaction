using System;
using System.Collections.Generic;

namespace CustomActionResults.Controllers
{
    public static class UserRepository
    {
        public static IEnumerable<User> GetUsers()
        {
            return new[]
                       {
                           new User
                               {
                                   FirstName = "Fred",
                                   LastName = "Flintstone",
                                   LastLogin = new DateTime(2010, 3, 22),
                                   Username = "FFlintstone"
                               },
                           new User
                               {
                                   FirstName = "Willma",
                                   LastName = "Flintstone",
                                   LastLogin = new DateTime(2010, 1, 1),
                                   Username = "WFlintstone"
                               },
                           new User
                               {
                                   FirstName = "Jack",
                                   LastName = "Flintstone",
                                   LastLogin = new DateTime(2010, 2, 2),
                                   Username = "JFlintstone"
                               },
                           new User
                               {
                                   FirstName = "Jane",
                                   LastName = "Flintstone",
                                   LastLogin = new DateTime(2010, 3, 3),
                                   Username = "JaFlintstone"
                               },
                       };
        }
    }
}