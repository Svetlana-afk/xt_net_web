using Epam.UsersManager.BLL;
using Epam.UsersManager.BLL.Interfaces;
using Epam.UsersManager.DAL;
using Epam.UsersManager.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UsersManager.DependencyResolver
{
    public static class DependencyResolver
    {
        private static IUsersManagerDal _usersManagerDal;
        private static IUsersManagerBll _usersManagerBll;


        public static IUsersManagerDal UsersManagerDal => _usersManagerDal ?? (_usersManagerDal = new JsonUsersManagerDal());
        public static IUsersManagerBll UsersManagerBll => _usersManagerBll ?? (_usersManagerBll = new UsersManagerBll(UsersManagerDal));
    }
}
