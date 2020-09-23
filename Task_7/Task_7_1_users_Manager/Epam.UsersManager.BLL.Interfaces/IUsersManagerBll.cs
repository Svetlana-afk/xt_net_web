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
        User GetUserById(Guid id);
        void AddAward(Award award);
        IEnumerable<Award> GetUserAwards(Guid userId);
        bool Reward(Guid userId, Guid awardId);
        Award GetAwardById(Guid awardId);
        bool DepriveAward(Guid userId, Guid awardId);
        Award RemoveAward(Guid awardId);
        bool UpdateUser(Guid userId, string newUserName, DateTime newBirthday);
    }
}
