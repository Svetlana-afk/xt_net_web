using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.PhotoAwards.DAL.Interfaces;
using Epam.PhotoAwards.DependencyResolver;
using Epam.PhotoAwards.Entities;

namespace Epam.PhotoAwards.BLL
{
    public class Auth
    {
        public static bool CanLogin(string login, string password)
        {
            IUserDal userDal = DependencyResolver.DependencyResolver.UsersDal;
            User user = userDal.GetUserByEmail(login);
            if (user != null && user.Pass.Equals(password)) 
            {
                return true;
            }

            return false;
        }
    }
}
