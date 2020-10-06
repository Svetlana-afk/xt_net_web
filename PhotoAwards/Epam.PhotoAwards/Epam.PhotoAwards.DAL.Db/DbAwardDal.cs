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
    public class DbAwardDal : IAwardDal
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=photoawards;Integrated Security=True";
        public void AddAward(Award award)
        {
            string sqlAddAward = String.Format("INSERT INTO Awards (Id, Title) VALUES ('{0}', '{1}')", award.ID, award.Title);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlAddAward, connection);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateAward(Award award)
        {
            string sqlExpression = String.Format("UPDATE Awards SET Title='{0}', PhotoWinner='{1}' WHERE Id='{2}'", 
                award.Title, award.PhotoWinner, award.ID);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
        }

        public Award GetAwardById(Guid awardId)
        {
            string sqlAward = String.Format("SELECT * FROM Awards WHERE Id='{0}'", awardId);
            string sqlAwardPhotos = String.Format("SELECT * FROM Photos WHERE AwardId='{0}'", awardId);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlAward, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Award award = new Award();
                        award.Title = (string)reader["title"];
                        award.ID = Guid.Parse((string)reader["id"]);
                        award.PhotoWinner = Guid.Parse((string)reader["PhotoWinner"]);
                        award.Winner = Guid.Parse((string)reader["Winner"]);
                        reader.Close();

                        command = new SqlCommand(sqlAwardPhotos, connection);
                        reader = command.ExecuteReader();

                        List<Photo> photos = new List<Photo>();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Photo photo = new Photo();
                                photo.ID = Guid.Parse((string)reader["UserId"]);
                                photo.Title = (string)reader["Title"];
                                photo.AwardId = Guid.Parse((string)reader["AwardId"]);
                                photo.PhotographerID = Guid.Parse((string)reader["PhotographerID"]);
                                photo.Path = (string)reader["Path"];
                                photos.Add(photo);
                            }
                        }

                        award.Photos = photos;

                        reader.Close();

                        return award;
                    }
                }

                reader.Close();
                return null;
            }
        }

        public IEnumerable<Award> GetAwards()
        {
            string sqlExpression = "SELECT * FROM Awards";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Award award = new Award();
                        award.Title = (string)reader["title"];
                        award.ID = Guid.Parse((string)reader["id"]);
                        yield return award;
                    }
                }

                reader.Close();
            }
        }
    }
}
