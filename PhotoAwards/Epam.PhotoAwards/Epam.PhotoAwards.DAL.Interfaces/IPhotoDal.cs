using Epam.PhotoAwards.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.PhotoAwards.DAL.Interfaces
{
    public interface IPhotoDal
    {
        void AddPhoto(Photo photo);
        void DeletePhoto(Guid photoId);
        Photo GetPhotoById(Guid photoId);
        void UpdatePhoto(Photo photo);
        void VotePhoto(Guid juryId, Guid photoId);
    }
}
