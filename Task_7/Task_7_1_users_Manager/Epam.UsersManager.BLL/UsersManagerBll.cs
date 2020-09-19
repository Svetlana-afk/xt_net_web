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
        private IUserDal _usersDal;
        private IAwardDal _awardsDal;
        public UsersManagerBll(IUserDal usersDAL, IAwardDal awardsDAL)
        {
            _usersDal = usersDAL;
            _awardsDal = awardsDAL;
        }
        public void DeleteUserById(Guid id)
        {
            _usersDal.DeleteUser(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _usersDal.GetAllUsers();
        }

        public Guid AddUser(User user)
        {            
            user.ID = Guid.NewGuid();
            _usersDal.AddUser(user);
            return user.ID;
        }
        public User GetUserById(Guid id) 
        {
            return _usersDal.GetUserById(id);
        }
        public IEnumerable<Award> GetUserAwards(Guid userId) 
        {
            foreach (var awardId in GetUserById(userId).AwardsId)
            {
                yield return _awardsDal.GetAwardById(awardId);
            }            
        }

        public bool DepriveAward(Guid userId, Guid awardsId)
        {
            if (!_usersDal.GetUserById(userId).AwardsId.Contains(awardsId))
            {
                Console.WriteLine("User does not have such an award");
                return false;
            }

            bool successByUser = _usersDal.DepriveAward(userId, awardsId);
            bool successByAward = _awardsDal.DeleteUserIdFromAward(userId, awardsId);
            return successByAward && successByUser;
        }
        
        public void AddAward(Award award)
        {
            if (award == null)
            {
                throw new ArgumentNullException(nameof(Award));
            }
            if (_awardsDal.GetAwards().Count()>0)
            {
                foreach (var item in _awardsDal.GetAwards())
                {
                    if (item.Title == award.Title)
                    {
                        Console.WriteLine("An award with the same title already exists");
                        return;
                    }
                }
            }            
            _awardsDal.AddAward(award);
        }

        public bool Reward(Guid userId, Guid awardId)
        {
            if (_usersDal.GetUserById(userId).AwardsId.Contains(awardId))
            {
                Console.WriteLine("the user has already been awarded this award");
                return false;
            }
            bool successByUser = _usersDal.Reward(userId, awardId);
            bool successByAward = _awardsDal.AddUserIdToAward(userId, awardId);
            return successByAward && successByUser;
        }

        public Award GetAwardById(Guid awardId)
        {
            return _awardsDal.GetAwardById(awardId);
        }

        public Award RemoveAward(Guid awardId)
        {
            return _awardsDal.RemoveAward(awardId);
        }
    }
}
