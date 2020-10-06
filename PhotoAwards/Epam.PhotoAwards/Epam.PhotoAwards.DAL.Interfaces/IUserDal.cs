using Epam.PhotoAwards.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.PhotoAwards.DAL.Interfaces
{
    public interface IUserDal
    {
        Guid AddUser(User user);
        void DeleteUser(Guid id);
        User GetUserById(Guid id);
        User GetUserByEmail(string email);
    }
}
