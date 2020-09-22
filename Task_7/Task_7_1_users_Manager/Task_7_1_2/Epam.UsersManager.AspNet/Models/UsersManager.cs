using Epam.UsersManager.BLL.Interfaces;
using Epam.UsersManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.UsersManager.AspNet.Models
{
    public static class UsersManager
    {
        public static IUsersManagerBll usersManagerLogic = DependencyResolver.DependencyResolver.UsersManagerBll;
        public static void DisplayAllUsers(IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine(string.Format("User {0}, Age {1}, B-Day {2}", user.Name, user.Age, user.DateOfBirth));
            }
        }
    }
 
}