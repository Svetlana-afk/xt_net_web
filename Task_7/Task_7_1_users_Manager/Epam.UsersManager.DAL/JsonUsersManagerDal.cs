using Epam.UsersManager.DAL.Interfaces;
using Epam.UsersManager.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UsersManager.DAL
{
    public class JsonUsersManagerDal : IUsersManagerDal
    {
        public const string LocalDataPath = "Users\\";
        public static string DataPath => "D:\\epam\\xt_net_web\\Task_7\\Data\\";
        public void DeleteUser(Guid id)
        {
            var userDataPath = DataPath + LocalDataPath + "Users.json";
            StringBuilder users = new StringBuilder("");
            string str = "";
            using (StreamReader reader = new StreamReader(userDataPath)) 
            {
                while ((str = reader.ReadLine()) != null)
                {
                    if (!str.Contains(id.ToString()))
                    {
                        users.Append(str);
                        users.Append(Environment.NewLine);
                    }
                }
            }
            using (StreamWriter writer = new StreamWriter(userDataPath, false)) 
            {
                writer.Write(users);
            }


        }

        public IEnumerable<User> GetAllUsers()
        {
            var userDataPath = DataPath +LocalDataPath + "Users.json";
            using (StreamReader reader = new StreamReader(userDataPath))
            {
                string s;
                while ((s = reader.ReadLine()) != null)
                {
                    yield return JsonConvert.DeserializeObject<User>(s);
                }
            }
        }

        public bool AddUser(User user)
        {
            var userDataPath = DataPath + LocalDataPath + "Users.json";
            if (user == null)
            {
                throw new ArgumentNullException(nameof(User));
            }
            var userStr = JsonConvert.SerializeObject(user);
            using (var writer = new StreamWriter(userDataPath, true))
            {
                writer.WriteLine(userStr);
                //writer.Write(Environment.NewLine);
            }
            return true;
        }
        public User GetById(Guid id) 
        {
            return GetAllUsers().FirstOrDefault(user=>user.ID==id);
        }
    }
}
