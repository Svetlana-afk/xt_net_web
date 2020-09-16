using Epam.UsersManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UsersManager.BLL.Interfaces
{
    public interface IUsersManagerBll
    {
        Guid AddUser(User user);
        void DeleteUserById(Guid id);
        IEnumerable<User> GetAllUsers();
    }
}
