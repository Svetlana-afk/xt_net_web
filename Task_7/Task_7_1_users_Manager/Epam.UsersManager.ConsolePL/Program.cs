using Epam.UsersManager.BLL;
using Epam.UsersManager.BLL.Interfaces;
using Epam.UsersManager.DependencyResolver;
using Epam.UsersManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UsersManager.ConsolePL
{
    class Program
    {        
        static void Main(string[] args)
        {
            var usersManagerLogic = DependencyResolver.DependencyResolver.UsersManagerBll;
            //AddUser(usersManagerLogic);            
            DeleteUserById(usersManagerLogic, usersManagerLogic.GetAllUsers().FirstOrDefault(us=>us.Name == "me").ID);

            DisplayAllUsers(usersManagerLogic.GetAllUsers());
            Console.ReadLine();
        }
        private IUsersManagerBll _usersManagerBll;

        public static bool AddUser(IUsersManagerBll umb)
        {
            Console.WriteLine("Adding new User." + Environment.NewLine);
            Console.WriteLine("Input the Name:");
            var name = Console.ReadLine();
            Console.WriteLine("Input the Year of Birth:");
            var year = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Input the Month of Birth:");
            var month = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Input the Day of Birth:");
            var day = Int32.Parse(Console.ReadLine());
            var user = new User(name, new DateTime(year, month, day));
            umb.AddUser(user);
            return true;
        }
        public static void DeleteUserById(IUsersManagerBll umb, Guid id) 
        {
            umb.DeleteUserById(id);
        }
        public static void DisplayAllUsers(IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine(string.Format("User {0}, Age {1}, B-Day {2}", user.Name, user.Age, user.DateOfBirth));
            }
        }
    }

}
