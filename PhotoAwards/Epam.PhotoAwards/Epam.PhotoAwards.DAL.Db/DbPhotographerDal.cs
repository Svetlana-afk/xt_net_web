using Epam.PhotoAwards.DAL.Interfaces;
using Epam.PhotoAwards.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.PhotoAwards.DAL.Db
{
    public class DbPhotographerDal : IPhotographerDal
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=photoawards;Integrated Security=True";
        public void AddPhotographer(Photographer photographer)
        {
            string sqlAddAward = String.Format("INSERT INTO Photographers (Id, UserID, Name, DateOfBirth, Age, Logo) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                photographer.ID, photographer.UserID, photographer.Name, photographer.DateOfBirth, photographer.Age, photographer.Logo);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlAddAward, connection);
                command.ExecuteNonQuery();
            }
        }

        public void DeletePhotographer(Guid id)
        {
            string sqlExpression = String.Format("DELETE FROM Photographers WHERE Id='{0}'", id);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Photographer> GetAllPhotographers()
        {
            string sqlExpression = "SELECT * FROM Photographers";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Photographer photographer = new Photographer((string)reader["name"], (DateTime)reader["DateOfBirth"]);
                        photographer.ID = Guid.Parse((string)reader["id"]);
                        photographer.UserID = Guid.Parse((string)reader["userid"]);
                        photographer.Logo = (string)reader["logo"];
                        yield return photographer;
                    }
                }

                reader.Close();
            }
        }

        public Photographer GetPhotographerById(Guid photographerId)
        {
            string sqlPhotographer = String.Format("SELECT * FROM Photographers WHERE Id='{0}'", photographerId);
            string sqlPhotographerPhotos = String.Format("SELECT * FROM Photos WHERE PhotographerId='{0}'", photographerId);
            string sqlPhotographerAwards = String.Format("SELECT * FROM Awards WHERE Winner='{0}'", photographerId);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlPhotographer, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Photographer photographer = new Photographer((string)reader["name"], (DateTime)reader["DateOfBirth"]);
                        photographer.ID = Guid.Parse((string)reader["id"]);
                        photographer.UserID = Guid.Parse((string)reader["userid"]);
                        photographer.Logo = (string)reader["logo"];
                        reader.Close();

                        command = new SqlCommand(sqlPhotographerPhotos, connection);
                        reader = command.ExecuteReader();

                        List<Photo> photos = new List<Photo>();                        
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Photo photo = new Photo();
                                photo.ID = Guid.Parse((string)reader["Id"]);
                                photo.Title = (string)reader["Title"];
                                photo.AwardId = Guid.Parse((string)reader["AwardId"]);
                                photo.PhotographerID = Guid.Parse((string)reader["PhotographerID"]);
                                photo.Path = (string)reader["Path"];
                                photos.Add(photo);
                            }
                        }

                        photographer.Photos = photos;
                        reader.Close();

                        command = new SqlCommand(sqlPhotographerAwards, connection);
                        reader = command.ExecuteReader();

                        List<Award> awards = new List<Award>();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Award award = new Award();
                                award.Title = (string)reader["title"];
                                award.ID = Guid.Parse((string)reader["id"]);
                                award.PhotoWinner = Guid.Parse((string)reader["PhotoWinner"]);
                                award.Winner = Guid.Parse((string)reader["Winner"]);
                                awards.Add(award);
                            }
                        }

                        photographer.Awards = awards;
                        reader.Close();

                        return photographer;
                    }
                }

                reader.Close();
                return null;
            }
        }

        public Photographer GetPhotographerByUserId(Guid userId)
        {
            string sqlPhotographer = String.Format("SELECT * FROM Photographers WHERE UserId='{0}'", userId);
    
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlPhotographer, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Photographer photographer = new Photographer((string)reader["name"], (DateTime)reader["DateOfBirth"]);
                        photographer.ID = Guid.Parse((string)reader["id"]);
                        photographer.UserID = Guid.Parse((string)reader["userid"]);
                        photographer.Logo = (string)reader["logo"];
                        reader.Close();

                        string sqlPhotographerPhotos = String.Format("SELECT * FROM Photos WHERE PhotographerId='{0}'", photographer.ID);
                        string sqlPhotographerAwards = String.Format("SELECT * FROM Awards WHERE Winner='{0}'", photographer.ID);

                        command = new SqlCommand(sqlPhotographerPhotos, connection);
                        reader = command.ExecuteReader();

                        List<Photo> photos = new List<Photo>();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Photo photo = new Photo();
                                photo.ID = Guid.Parse((string)reader["Id"]);
                                photo.Title = (string)reader["Title"];
                                photo.AwardId = Guid.Parse((string)reader["AwardId"]);
                                photo.PhotographerID = Guid.Parse((string)reader["PhotographerID"]);
                                photo.Path = (string)reader["Path"];
                                photos.Add(photo);
                            }
                        }

                        photographer.Photos = photos;
                        reader.Close();

                        command = new SqlCommand(sqlPhotographerAwards, connection);
                        reader = command.ExecuteReader();

                        List<Award> awards = new List<Award>();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Award award = new Award();
                                award.Title = (string)reader["title"];
                                award.ID = Guid.Parse((string)reader["id"]);
                                award.PhotoWinner = Guid.Parse((string)reader["PhotoWinner"]);
                                award.Winner = Guid.Parse((string)reader["Winner"]);
                                awards.Add(award);
                            }
                        }

                        photographer.Awards = awards;
                        reader.Close();

                        return photographer;
                    }
                }

                reader.Close();
                return null;
            }
        }

        public void UpdatePhotographer(Guid photographerId, string newPhotographerName, DateTime newBirthday, int age, string newUserPic)
        {
            string sqlExpression = String.Format("UPDATE Photographers SET Name='{0}', DateOfBirth='{1}', Age='{2}', Logo='{3}' WHERE Id='{4}'",
                newPhotographerName, newBirthday, age, newUserPic, photographerId);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
