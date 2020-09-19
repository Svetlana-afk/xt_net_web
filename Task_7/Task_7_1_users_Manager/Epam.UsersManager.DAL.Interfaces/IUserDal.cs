using Epam.UsersManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UsersManager.DAL.Interfaces
{
    public interface IUserDal
    {
        bool AddUser(User user);
        void DeleteUser(Guid id);
        IEnumerable<User> GetAllUsers();
        User GetUserById(Guid id);
        IEnumerable<Guid> GetUserAwardsId(Guid userId);
        bool Reward(Guid userId, Guid awardId);
        bool DepriveAward(Guid userId, Guid awardId);
    }
}
