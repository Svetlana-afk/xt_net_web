using Epam.UsersManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UsersManager.DAL.Interfaces
{
    public interface IAwardDal
    {
        void AddAward(Award award);
        bool AddUserIdToAward(Guid userId, Guid awardId);
        bool DeleteUserIdFromAward(Guid userId, Guid awardId);
        Award RemoveAward(Guid awardId);
        IEnumerable<Award> GetAwards();
        Award GetAwardById(Guid awardId);        
    }
}
