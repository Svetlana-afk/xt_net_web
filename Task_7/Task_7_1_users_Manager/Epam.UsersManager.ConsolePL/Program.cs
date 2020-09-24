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
            //DeleteUserById(usersManagerLogic, Guid.Parse("c19e9793-12bf-4735-86d4-c03e20231b18"));
            Award award = new Award("Real Hero!");
            usersManagerLogic.AddAward(award);

            DisplayAllUsers(usersManagerLogic.GetAllUsers());            
            User dmitriy = usersManagerLogic.GetUserById(Guid.Parse("c19e9793-12bf-4735-86d4-c03e20231b18"));
            usersManagerLogic.Reward(dmitriy.ID, Guid.Parse("60361b47-5e12-456a-9229-336e5f4836c3"));
            Console.WriteLine("User by id:");
            DisplayUser(dmitriy);
            Console.ReadLine();
            Console.WriteLine("Real Hero");
            award = usersManagerLogic.GetAwardById(usersManagerLogic.GetAwards().FirstOrDefault(awards => awards.Title == "Real Hero!").ID);
            usersManagerLogic.Reward(dmitriy.ID, award.ID);
            DisplayUser(dmitriy);
            Console.ReadLine();
            usersManagerLogic.RemoveAward(Guid.Parse("ea601359-9769-4bb7-83cb-f96d39eb3bd1"));

        }
        
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
        public static void DisplayUser(User user) 
        {
            Console.WriteLine(string.Format("User {0}, Age {1}, B-Day {2}", user.Name, user.Age, user.DateOfBirth));
        }
    }

}
