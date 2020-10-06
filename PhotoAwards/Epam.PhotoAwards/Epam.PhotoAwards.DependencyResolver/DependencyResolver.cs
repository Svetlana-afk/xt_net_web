using Epam.PhotoAwards.BLL;
using Epam.PhotoAwards.BLL.Interfaces;
using Epam.PhotoAwards.DAL.Db;
using Epam.PhotoAwards.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.PhotoAwards.DependencyResolver
{
    public static class DependencyResolver
    {
        private static IUserDal _usersDal;
        private static IPhotographerDal _photographersDal;
        private static IJuryDal _juryDal;
        private static IAwardDal _awardsDal;
        private static IPhotoDal _photosDal;
        private static IPhotoAwardsBll _photoAwardsBll;

        public static IUserDal UsersDal => _usersDal ?? (_usersDal = new DbUserDal());
        public static IAwardDal AwardsDal => _awardsDal ?? (_awardsDal = new DbAwardDal());
        public static IPhotographerDal PhotographersDal => _photographersDal ?? (_photographersDal = new DbPhotographerDal());
        public static IJuryDal JuryDal => _juryDal ?? (_juryDal = new DbJuryDal());
        public static IPhotoDal PhotoDal => _photosDal ?? (_photosDal = new DbPhotoDal());
        public static IPhotoAwardsBll PhotoAwardsBll => _photoAwardsBll ?? (_photoAwardsBll = new PhotoAwardsBll(UsersDal, AwardsDal, PhotographersDal, JuryDal, PhotoDal));
    }
}
