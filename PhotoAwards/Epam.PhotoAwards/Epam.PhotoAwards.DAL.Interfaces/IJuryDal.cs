using Epam.PhotoAwards.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.PhotoAwards.DAL.Interfaces
{
    public interface IJuryDal
    {
        void AddJury(Jury jury);
        void DeleteJury(Guid juryId);
        IEnumerable<Jury> GetAllJury();
        Jury GetJuryById(Guid juryId);
        void UpdateJury(Guid juryId, string newJuryName, string newUserPic, string newInfo);
        int CountJuries();
    }
}
