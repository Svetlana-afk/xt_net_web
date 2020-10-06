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
    public class DbJuryDal : IJuryDal
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=photoawards;Integrated Security=True";
        public void AddJury(Jury jury)
        {
            string sqlAddJury = String.Format("INSERT INTO Juries (Id, UserId, Name, UserPic, Info) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')",
                jury.ID, jury.UserID, jury.Name, jury.Logo, jury.Info);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlAddJury, connection);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteJury(Guid juryId)
        {
            string sqlExpression = String.Format("DELETE FROM Juries WHERE Id='{0}'", juryId);
            string sqlExpression1 = String.Format("DELETE FROM JuriesVotes WHERE JuryId='{0}'", juryId);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();

                command = new SqlCommand(sqlExpression1, connection);
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Jury> GetAllJury()
        {
            string sqlExpression = "SELECT * FROM Juries";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Jury jury = new Jury();
                        jury.ID = Guid.Parse((string)reader["id"]);
                        jury.Name = (string)reader["name"];
                        jury.Info = (string)reader["info"];
                        jury.Logo = (string)reader["logo"];
                        yield return jury;
                    }
                }

                reader.Close();
            }
        }

        public Jury GetJuryById(Guid juryId)
        {
            string sqlJury = String.Format("SELECT * FROM Juries WHERE Id='{0}'", juryId);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlJury, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Jury jury = new Jury();
                        jury.ID = Guid.Parse((string)reader["id"]);
                        jury.Name = (string)reader["name"];
                        jury.Info = (string)reader["info"];
                        jury.Logo = (string)reader["logo"];
                        reader.Close();

                        return jury;
                    }
                }

                reader.Close();
                return null;
            }
        }

        public void UpdateJury(Guid juryId, string newJuryName, string newLogo, string newInfo)
        {
            string sqlExpression = String.Format("UPDATE Awards SET Name='{0}', Info='{1}', Logo='{2}' WHERE Id='{3}'",
                newJuryName, newInfo, newLogo, juryId);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
        }

        public int CountJuries()
        {
            string sqlExpression = "SELECT COUNT(*) FROM Juries";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                return (int)command.ExecuteScalar();
            }
        }

    }
}
