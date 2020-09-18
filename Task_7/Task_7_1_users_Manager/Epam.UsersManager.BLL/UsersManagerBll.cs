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
        public User GetUserById(Guid id) 
        {
            return _usersManagerDal.GetUserById(id);
        }
        public IEnumerable<Award> GetUserAwards(Guid userId) 
        {
            return _usersManagerDal.GetUserAwards(userId);
        }

        public bool DepriveAward(Guid userId, Guid awardsId)
        {
            if (!_usersManagerDal.GetUserById(userId).AwardsId.Contains(awardsId))
            {
                Console.WriteLine("User does not have such an award");
                return false;
            }

            bool successByUser = _usersManagerDal.DepriveAward(userId, awardsId);
            bool successByAward = _usersManagerDal.DeleteUserIdFromAward(userId, awardsId);
            return successByAward && successByUser;
        }
        
        public void AddAward(Award award)
        {
            if (award == null)
            {
                throw new ArgumentNullException(nameof(Award));
            }
            if (_usersManagerDal.GetAwards().Count()>0)
            {
                foreach (var item in _usersManagerDal.GetAwards())
                {
                    if (item.Title == award.Title)
                    {
                        Console.WriteLine("An award with the same title already exists");
                        return;
                    }
                }
            }            
            _usersManagerDal.AddAward(award);
        }

        public bool Reward(Guid userId, Guid awardId)
        {
            if (_usersManagerDal.GetUserById(userId).AwardsId.Contains(awardId))
            {
                Console.WriteLine("the user has already been awarded this award");
                return false;
            }
            bool successByUser = _usersManagerDal.Reward(userId, awardId);
            bool successByAward = _usersManagerDal.AddUserIdToAward(userId, awardId);
            return successByAward && successByUser;
        }

        public Award GetAwardById(Guid awardId)
        {
            return _usersManagerDal.GetAwardById(awardId);
        }

        public Award RemoveAward(Guid awardId)
        {
            throw new NotImplementedException();
        }
    }
}
