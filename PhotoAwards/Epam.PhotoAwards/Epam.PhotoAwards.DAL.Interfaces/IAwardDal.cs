using Epam.PhotoAwards.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.PhotoAwards.DAL.Interfaces
{
    public interface IAwardDal
    {
        void AddAward(Award award);
        void UpdateAward(Award award);
        IEnumerable<Award> GetAwards();
        Award GetAwardById(Guid awardId);
    }
}
