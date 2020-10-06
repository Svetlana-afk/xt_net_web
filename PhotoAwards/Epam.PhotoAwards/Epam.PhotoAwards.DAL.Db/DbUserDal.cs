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
    public class DbUserDal : IUserDal
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=photoawards;Integrated Security=True";
        public Guid AddUser(User user)
        {
            string sqlAddUser = String.Format("INSERT INTO Users (Id, Email, Pass, Role) VALUES ('{0}', '{1}', '{2}', '{3}')",
                user.ID, user.EMail, user.Pass, user.Role);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlAddUser, connection);
                command.ExecuteNonQuery();
                return user.ID;
            }
        }

        public void DeleteUser(Guid id)
        {
            string sqlExpression = String.Format("DELETE FROM Users WHERE Id='{0}'", id);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
        }

        public User GetUserByEmail(string email)
        {
            string sqlAward = String.Format("SELECT * FROM Users WHERE Email='{0}'", email);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlAward, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        User user = new User();
                        user.EMail = (string)reader["email"];
                        user.ID = Guid.Parse((string)reader["id"]);
                        user.Pass = (string)reader["pass"];
                        user.Role = (UserRoles)Enum.Parse(typeof(UserRoles), (string)reader["role"], true);
                        reader.Close();

                        return user;
                    }
                }

                reader.Close();
                return null;
            }
        }

        public User GetUserById(Guid id)
        {
            string sqlAward = String.Format("SELECT * FROM Users WHERE Id='{0}'", id);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlAward, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        User user = new User();
                        user.EMail = (string)reader["email"];
                        user.ID = Guid.Parse((string)reader["id"]);
                        user.Pass = (string)reader["pass"];
                        user.Role = (UserRoles)Enum.Parse(typeof(UserRoles), (string)reader["role"], true);
                        reader.Close();

                        return user;
                    }
                }

                reader.Close();
                return null;
            }
        }
    }
}
