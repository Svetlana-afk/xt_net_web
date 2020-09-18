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
        User GetUserById(Guid id);
        void AddAward(Award award);
        IEnumerable<Award> GetUserAwards(Guid userId);
        IEnumerable<Award> GetAwards();
        bool Reward(Guid userId, Guid awardId);
        Award GetAwardById(Guid awardId);
        bool DepriveAward(Guid userId, Guid awardId);
        Award RemoveAward(Guid awardId);
        bool AddUserIdToAward(Guid userId, Guid awardId);
        bool DeleteUserIdFromAward(Guid userId, Guid awardId);


    }
}
