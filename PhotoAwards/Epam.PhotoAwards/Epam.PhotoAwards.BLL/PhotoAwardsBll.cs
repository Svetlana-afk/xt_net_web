using Epam.PhotoAwards.BLL.Interfaces;
using Epam.PhotoAwards.DAL.Interfaces;
using Epam.PhotoAwards.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.PhotoAwards.BLL
{
    public class PhotoAwardsBll : IPhotoAwardsBll
    {
        private IUserDal _usersDal;
        private IAwardDal _awardsDal;
        private IPhotographerDal _photographersDal;
        private IJuryDal _juryDal;
        private IPhotoDal _photoDal;
        public PhotoAwardsBll(IUserDal usersDAL, IAwardDal awardsDAL, IPhotographerDal photographerDal, IJuryDal juryDal, IPhotoDal photoDal)
        {
            _usersDal = usersDAL;
            _awardsDal = awardsDAL;
            _photographersDal = photographerDal;
            _juryDal = juryDal;
            _photoDal = photoDal;

        }
        public Guid? AddAward(Award award)
        {
            if (award == null)
            {
                throw new ArgumentNullException(nameof(Award));
            }
            if (_awardsDal.GetAwards().Count() > 0)
            {
                foreach (var item in _awardsDal.GetAwards())
                {
                    if (item.Title == award.Title)
                    {
                        Console.WriteLine("An award with the same title already exists");
                        return null;
                    }
                }
            }
            award.ID = Guid.NewGuid();
            _awardsDal.AddAward(award);
            return award.ID;
        }

        public Guid AddJury(string email, string pass, string juryName)
        {
            User user = new User();
            user.EMail = email;
            user.Pass = pass;
            user.Role = UserRoles.Jury;
            user.ID = Guid.NewGuid();

            _usersDal.AddUser(user);

            Jury jury = new Jury();
            jury.ID = Guid.NewGuid();
            jury.UserID = user.ID;
            jury.Name = juryName;
            jury.Info = "";

            _juryDal.AddJury(jury);
            return jury.ID;
        }

        public Guid AddPhotographer(string email, string pass, string photographerName, DateTime bDay, string userpic)
        {
            if (_usersDal.GetUserByEmail(email)!=null)
            {
                throw new Exception("Already exists");
            }
            User user = new User();
            user.EMail = email;
            user.Pass = pass;
            user.Role = UserRoles.Photographer;
            user.ID = Guid.NewGuid();

          
            _usersDal.AddUser(user);

            Photographer photographer = new Photographer(photographerName, bDay);
            photographer.ID = photographer.ID = Guid.NewGuid();
            photographer.UserID = user.ID;
            photographer.Logo = userpic;

            _photographersDal.AddPhotographer(photographer);
            return photographer.ID;
        }

        public void AddVote(Guid juryId, Guid photoId)
        {
            Photo photo = _photoDal.GetPhotoById(photoId);
            if (photo != null)
            {
                Award award = _awardsDal.GetAwardById(photo.AwardId);
                if (award.PhotoWinner == null) return;

                _photoDal.VotePhoto(juryId, photoId);

                award = _awardsDal.GetAwardById(photo.AwardId);
                int count = 0;
                foreach (var item in award.Photos)
                {
                    count += item.JuryVotes.Count;
                }

                if (count >= _juryDal.CountJuries())
                {
                    award.PhotoWinner = award.Photos.OrderBy(ph => ph.JuryVotes.Count).Last().ID;                   
                }                
            }            
        }

        public void DeleteJuryById(Guid juryId)
        {
            Guid userId = _juryDal.GetJuryById(juryId).UserID;
            _juryDal.DeleteJury(juryId);
            _usersDal.DeleteUser(userId);
        }

        public void DeletePhotographerById(Guid photographerId)
        {
            Guid userId = _photographersDal.GetPhotographerById(photographerId).UserID;
            _photographersDal.DeletePhotographer(photographerId);
            _usersDal.DeleteUser(userId);
        }
       

        public IEnumerable<Jury> GetAllJury()
        {
            return _juryDal.GetAllJury();
        }

        public IEnumerable<Photographer> GetAllPhotographers()
        {
            return _photographersDal.GetAllPhotographers();
        }

        public Award GetAwardById(Guid awardId)
        {
            return _awardsDal.GetAwardById(awardId);
        }

        public IEnumerable<Award> GetAwards()
        {
            return _awardsDal.GetAwards();
        }

        public Jury GetJuryById(Guid juryId)
        {
            return _juryDal.GetJuryById(juryId);
        }

        public IEnumerable<Award> GetPhotographerAwards(Guid photographerId)
        {
            foreach (var award in GetPhotographerById(photographerId).Awards)
            {
                yield return award;
            }
        }

        public Photographer GetPhotographerById(Guid photographerId)
        {
            return _photographersDal.GetPhotographerById(photographerId);
        }

        public User GetUserByEmail(string email)
        {
            return _usersDal.GetUserByEmail(email);
        }

        public void UpdateJury(Guid juryId, string newJuryName, string newUserPic, string newInfo)
        {
            _juryDal.UpdateJury(juryId, newJuryName, newUserPic, newInfo);
        }

        public void UpdatePhotographer(Guid photographerId, string newPhotographerName, DateTime newBirthday, string newUserPic)
        {
            int age = DateTime.Now.Year - newBirthday.Year;
            if (DateTime.Now.DayOfYear < newBirthday.DayOfYear)
            {
                age++;
            }
            _photographersDal.UpdatePhotographer(photographerId, newPhotographerName, newBirthday, age, newUserPic);
        }
        public Photographer GetPhotographerByUser(User user) 
        {
            return _photographersDal.GetPhotographerByUserId(user.ID);
        }

        public void AddNewPhoto(Guid photographerId, Guid awardId, string name, string desc) 
        {
            Photo photo = new Photo();
            photo.ID = Guid.NewGuid();
            photo.Title = desc;
            photo.PhotographerID = photographerId;
            photo.AwardId = awardId;
            photo.Path = name;

            _photoDal.AddPhoto(photo);
        }
    }
}
