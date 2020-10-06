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
    public class DbPhotoDal : IPhotoDal
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=photoawards;Integrated Security=True";

        public void AddPhoto(Photo photo)
        {
            string sqlAddJury = String.Format("INSERT INTO Photos (Id, PhotographerId, Title, Path, AwardId) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')",
                photo.ID, photo.PhotographerID, photo.Title, photo.Path, photo.AwardId);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlAddJury, connection);
                command.ExecuteNonQuery();
            }
            // TODO Add check if award exist
        }

        public void DeletePhoto(Guid photoId)
        {
            string sqlExpression = String.Format("DELETE FROM Photos WHERE Id='{0}'", photoId);
            string sqlExpression1 = String.Format("DELETE FROM JuriesVotes WHERE PhotoId='{0}'", photoId);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();

                command = new SqlCommand(sqlExpression1, connection);
                command.ExecuteNonQuery();
            }
        }

        public Photo GetPhotoById(Guid photoId)
        {
            string sqlPhoto = String.Format("SELECT * FROM Photos WHERE Id='{0}'", photoId);
            string sqlPhotoJuriesVotes = String.Format("SELECT * FROM JuriesVotes WHERE PhotoId='{0}'", photoId);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlPhoto, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Photo photo = new Photo();
                        photo.ID = Guid.Parse((string)reader["id"]);
                        photo.Title = (string)reader["title"];                      
                        photo.AwardId = Guid.Parse((string)reader["AwardId"]);
                        photo.PhotographerID = Guid.Parse((string)reader["PhotographerID"]);
                        photo.Path = (string)reader["Path"];
                        reader.Close();

                        command = new SqlCommand(sqlPhotoJuriesVotes, connection);
                        reader = command.ExecuteReader();

                        List<Guid> juriesVotes = new List<Guid>();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                juriesVotes.Add(Guid.Parse((string)reader["JuryId"]));
                            }
                        }

                        photo.JuryVotes = juriesVotes;

                        reader.Close();

                        return photo;
                    }
                }

                reader.Close();
                return null;
            }
        }

        public void UpdatePhoto(Photo photo)
        {
            string sqlExpression = String.Format("UPDATE Photos SET Title='{0}', Path='{1}', AwardId='{2}' WHERE Id='{3}'",
                photo.Title, photo.Path, photo.AwardId, photo.ID);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
        }

        public void VotePhoto(Guid juryId, Guid photoId)
        {
            string sqlAddVote = String.Format("INSERT INTO JuriesVotes (JuryId, PhotoId) VALUES ('{0}', '{1}')",
                juryId, photoId);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlAddVote, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
