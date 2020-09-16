using Epam.UsersManager.BLL.Interfaces;
using Epam.UsersManager.DAL.Interfaces;
using Epam.UsersManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UsersManager.BLL
{
    public class UsersManagerBll : IUsersManagerBll
    {
        private IUsersManagerDal _usersManagerDal;
        public UsersManagerBll(IUsersManagerDal users_ManagerDAL)
        {
            _usersManagerDal = users_ManagerDAL;
        }
        public void DeleteUserById(Guid id)
        {
            _usersManagerDal.DeleteUser(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _usersManagerDal.GetAllUsers();
        }

        public Guid AddUser(User user)
        {            
            user.ID = Guid.NewGuid();
            _usersManagerDal.AddUser(user);
            return user.ID;
        }

    }
}
