using Epam.PhotoAwards.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.PhotoAwards.DAL.Interfaces
{
    public interface IPhotographerDal
    {
        void AddPhotographer(Photographer photographer);
        void DeletePhotographer(Guid id);
        IEnumerable<Photographer> GetAllPhotographers();
        Photographer GetPhotographerById(Guid photographerId);
        Photographer GetPhotographerByUserId(Guid userId);
        void UpdatePhotographer(Guid photographerId, string newPhotographerName, DateTime newBirthday, int age, string newUserPic);
    }
}
