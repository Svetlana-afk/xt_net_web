using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UsersManager.Entities
{
    public static class Auth
    {
        public static bool CanLogin(string login, string password) 
        {
            if (login == "user" && password == "user")
            {
                return true;
            }
            else
            {
                return login == "admin" && password == "admin";
            }
            
        }
    }
}
