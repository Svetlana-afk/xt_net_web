using Epam.UsersManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UsersManager.DAL.Interfaces
{
    public interface IUsersManagerDal
    {
        bool AddUser(User user);
        void DeleteUser(Guid id);
        IEnumerable<User> GetAllUsers();
        User GetById(Guid id);
    }
}
