using Epam.PhotoAwards.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.PhotoAwards.BLL.Interfaces
{
    public interface IPhotoAwardsBll
    {
        Guid AddPhotographer(string email, string pass, string photographerName, DateTime bDay, string userpic);
        Guid AddJury(string email, string pass, string juryName);
        void DeletePhotographerById(Guid photographerId);
        void DeleteJuryById(Guid juryId);
        IEnumerable<Photographer> GetAllPhotographers();
        IEnumerable<Jury> GetAllJury();
        IEnumerable<Award> GetAwards();
        Photographer GetPhotographerById(Guid photographerId);
        Jury GetJuryById(Guid juryId);
        Guid? AddAward(Award award);
        IEnumerable<Award> GetPhotographerAwards(Guid photographerId);
        void AddVote(Guid juryId, Guid photoId);
        Award GetAwardById(Guid awardId);       
        void UpdatePhotographer(Guid photographerId, string newPhotographerName, DateTime newBirthday, string newUserPic);
        void UpdateJury(Guid juryId, string newJuryName, string newUserPic, string newInfo);
        User GetUserByEmail(string email);
        Photographer GetPhotographerByUser(User user);
        void AddNewPhoto(Guid photographerId, Guid awardId, string name, string desc);

    }
}
