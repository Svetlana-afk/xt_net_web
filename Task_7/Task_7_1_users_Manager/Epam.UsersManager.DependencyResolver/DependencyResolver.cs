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
        private static IUserDal _usersDal;
        private static IAwardDal _awardsDal;
        private static IUsersManagerBll _usersManagerBll;


        //public static IUserDal UsersDal => _usersDal ?? (_usersDal = new JsonUserDal());
        //public static IAwardDal AwardsDal => _awardsDal ?? (_awardsDal = new JsonAwardDal());
        public static IUserDal UsersDal => _usersDal ?? (_usersDal = new DbUserDal());
        public static IAwardDal AwardsDal => _awardsDal ?? (_awardsDal = new DbAwardDal());
        public static IUsersManagerBll UsersManagerBll => _usersManagerBll ?? (_usersManagerBll = new UsersManagerBll(UsersDal, AwardsDal));
    }
}
