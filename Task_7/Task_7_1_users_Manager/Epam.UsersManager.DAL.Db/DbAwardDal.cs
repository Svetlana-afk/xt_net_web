using Epam.UsersManager.DAL.Interfaces;
using Epam.UsersManager.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Epam.UsersManager.DAL
{
    public class DbAwardDal : IAwardDal
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=usersmanager;Integrated Security=True";
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

        public bool AddUserIdToAward(Guid userId, Guid awardId)
        {
            string sqlUserIdToAward = String.Format("INSERT INTO UsersAwards (UserId, AwardId) VALUES ('{0}', '{1}')", userId, awardId);
            string sqlAwards = String.Format("SELECT * FROM Awards WHERE Id='{0}'", awardId);
            string sqlUsers = String.Format("SELECT * FROM Users WHERE Id='{0}'", userId);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlAwards, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (!reader.HasRows) return false;
                reader.Close();

                command = new SqlCommand(sqlUsers, connection);
                reader = command.ExecuteReader();
                if (!reader.HasRows) return false;
                reader.Close();

                command = new SqlCommand(sqlUserIdToAward, connection);
                command.ExecuteNonQuery();
                return true;
            }
        }

        public bool DeleteUserIdFromAward(Guid userId, Guid awardId)
        {
            string sqlExpression = String.Format("DELETE FROM UsersAwards WHERE UserId='{0}' AND AwardId='{1}'", userId, awardId);
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();              
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                if (number>0) return true;
            }
            return false;
        }

        public Award GetAwardById(Guid awardId)
        {
            string sqlAward = String.Format("SELECT * FROM Awards WHERE Id='{0}'", awardId);
            string sqlAwardUsers = String.Format("SELECT * FROM UsersAwards WHERE AwardId='{0}'", awardId);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlAward, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Award award = new Award((string)reader["title"]);
                        award.ID = Guid.Parse((string)reader["id"]);
                        reader.Close();

                        command = new SqlCommand(sqlAwardUsers, connection);
                        reader = command.ExecuteReader();

                        List<Guid> usersGuids = new List<Guid>();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                usersGuids.Add(Guid.Parse((string)reader["UserId"]));
                            }
                        }

                        award.UsersId = usersGuids;
                        
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
                        Award award = new Award((string)reader["title"]);
                        award.ID = Guid.Parse((string)reader["id"]);
                        yield return award;
                    }
                }

                reader.Close();
            }
        }

        public void RemoveAward(Guid awardId)
        {
            string sqlExpression = String.Format("DELETE FROM Awards WHERE Id='{0}'", awardId);
            string sqlExpression1 = String.Format("DELETE FROM UsersAwards WHERE AwardId='{0}'", awardId);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();

                command = new SqlCommand(sqlExpression1, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
