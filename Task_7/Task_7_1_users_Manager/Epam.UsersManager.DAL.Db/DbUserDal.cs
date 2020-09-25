using Epam.UsersManager.DAL.Interfaces;
using Epam.UsersManager.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UsersManager.DAL
{
    public class DbUserDal : IUserDal
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=usersmanager;Integrated Security=True";
        public bool AddUser(User user)
        {
            string sqlAddAward = 
                String.Format("INSERT INTO Users (Id, Name, Birthdate, Age) VALUES ('{0}', '{1}', '{2}', {3})", user.ID, user.Name, user.DateOfBirth.ToShortDateString(), user.Age);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlAddAward, connection);
                int number = command.ExecuteNonQuery();
                if (number > 0) return true;
            }
            return false;
        }

        public void DeleteUser(Guid id)
        {
            string sqlExpression = String.Format("DELETE FROM Users WHERE Id='{0}'", id);
            string sqlExpression1 = String.Format("DELETE FROM UsersAwards WHERE UserId='{0}'", id);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();

                command = new SqlCommand(sqlExpression1, connection);
                command.ExecuteNonQuery();
            }
        }

        public bool DepriveAward(Guid userId, Guid awardId)
        {
            string sqlExpression = String.Format("DELETE FROM UsersAwards WHERE UserId='{0}' AND AwardId='{1}'", userId, awardId);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                if (number > 0) return true;
            }

            return false;
        }

        public IEnumerable<User> GetAllUsers()
        {
            string sqlExpression = "SELECT * FROM Users";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        User user = new User((string)reader["name"], (DateTime)reader["birthdate"]);
                        user.ID = Guid.Parse((string)reader["id"]);
                        yield return user;
                    }
                }

                reader.Close();
            }
        }

        public IEnumerable<Guid> GetUserAwardsId(Guid userId)
        {
            string sqlExpression = String.Format("SELECT * FROM UsersAwards WHERE UserId='{0}'", userId);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Guid awardID = Guid.Parse((string)reader["awardid"]);
                        yield return awardID;
                    }
                }

                reader.Close();
            }
        }

        public User GetUserById(Guid id)
        {
            string sqlAward = String.Format("SELECT * FROM Users WHERE Id='{0}'", id);
            string sqlUserAwards = String.Format("SELECT * FROM UsersAwards WHERE UserId='{0}'", id);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlAward, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        User user = new User((string)reader["name"], (DateTime)reader["birthdate"]);
                        user.ID = Guid.Parse((string)reader["id"]);
                        reader.Close();

                        command = new SqlCommand(sqlUserAwards, connection);
                        reader = command.ExecuteReader();  

                        List<Guid> awardsGuids = new List<Guid>();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                awardsGuids.Add(Guid.Parse((string)reader["AwardId"]));
                            }
                        }

                        user.AwardsId = awardsGuids;

                        reader.Close();

                        return user;
                    }
                }

                reader.Close();
                return null;
            }
        }

        public bool Reward(Guid userId, Guid awardId)
        {
            string sqlAddAward =
                String.Format("INSERT INTO UsersAwards (UserId, AwardId) VALUES ('{0}', '{1}')", userId, awardId);

            string sqlAward = String.Format("SELECT * FROM Awards WHERE Id='{0}'", awardId);
            string sqlUser = String.Format("SELECT * FROM Users WHERE Id='{0}'", userId);
          
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlAward, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (!reader.HasRows) return false;

                command = new SqlCommand(sqlUser, connection);
                reader = command.ExecuteReader();
                if (!reader.HasRows) return false;

                command = new SqlCommand(sqlAddAward, connection);
                int number = command.ExecuteNonQuery();
                if (number > 0) return true;
            }
            return false;
        }

        public bool UpdateUser(Guid userId, string newUserName, DateTime newBirthday)
        {
            User u = new User(newUserName, newBirthday);
            string sqlExpression = String.Format("UPDATE Users SET Name='{0}', Birthdate='{1}', Age={2} WHERE Id='{3}'", u.Name, u.DateOfBirth, u.Age, userId);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                if (number>0) return true;
            }

            return false;
        }
    }
}
