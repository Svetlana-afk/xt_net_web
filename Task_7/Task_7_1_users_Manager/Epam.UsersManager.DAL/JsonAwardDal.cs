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
    public class JsonAwardDal : IAwardDal
    {
        public static string DataPath => "D:\\epam\\xt_net_web\\Task_7\\Data\\Users\\";
        public void AddAward(Award award)
        {
            var awardDataPath = DataPath + "Awards.json";
            var awardStr = JsonConvert.SerializeObject(award);
            using (var writer = new StreamWriter(awardDataPath, true))
            {
                writer.WriteLine(awardStr);
            }
        }
        public bool AddUserIdToAward(Guid userId, Guid awardId)
        {
            bool success = false;
            var awardDataPath = DataPath + "Awards.json";
            StringBuilder awards = new StringBuilder("");
            string str = "";
            using (StreamReader reader = new StreamReader(awardDataPath))
            {
                while ((str = reader.ReadLine()) != null)
                {
                    if (!str.Contains(awardId.ToString()))
                    {
                        awards.Append(str);
                        awards.Append(Environment.NewLine);
                    }
                    else
                    {
                        var award = JsonConvert.DeserializeObject<Award>(str);
                        award.UsersId.Add(userId);
                        awards.Append(JsonConvert.SerializeObject(award));
                        awards.Append(Environment.NewLine);
                        success = true;
                    }
                }
            }
            using (StreamWriter writer = new StreamWriter(awardDataPath, false))
            {
                writer.Write(awards);
            }
            return success;
        }
        public bool DeleteUserIdFromAward(Guid userId, Guid awardId)
        {
            bool success = false;
            var awardDataPath = DataPath + "Awards.json";
            StringBuilder awards = new StringBuilder("");
            string str = "";
            using (StreamReader reader = new StreamReader(awardDataPath))
            {
                while ((str = reader.ReadLine()) != null)
                {
                    if (!str.Contains(awardId.ToString()))
                    {
                        awards.Append(str);
                        awards.Append(Environment.NewLine);
                    }
                    else
                    {
                        var award = JsonConvert.DeserializeObject<Award>(str);
                        award.UsersId.Remove(userId);
                        awards.Append(JsonConvert.SerializeObject(award));
                        awards.Append(Environment.NewLine);
                        success = true;
                    }
                }
            }
            using (StreamWriter writer = new StreamWriter(awardDataPath, false))
            {
                writer.Write(awards);
            }
            return success;
        }
        public void RemoveAward(Guid awardId)
        {
            var awardDataPath = DataPath + "Awards.json";
            StringBuilder awards = new StringBuilder("");
            string awardStr;
            using (StreamReader awardsReader = new StreamReader(awardDataPath))
            {
                while ((awardStr = awardsReader.ReadLine()) != null)
                {
                    if (!awardStr.Contains(awardId.ToString()))
                    {
                        awards.Append(awardStr);
                        awards.Append(Environment.NewLine);
                    }                    
                }
            }
            using (StreamWriter writer = new StreamWriter(awardDataPath, false))
            {
                writer.Write(awards);
            }
        }
        public IEnumerable<Award> GetAwards()
        {
            var awardDataPath = DataPath + "Awards.json";
            using (StreamReader reader = new StreamReader(awardDataPath))
            {
                string s;
                while ((s = reader.ReadLine()) != null)
                {
                    yield return JsonConvert.DeserializeObject<Award>(s);
                }
            }
        }
        public Award GetAwardById(Guid awardId)
        {
            return GetAwards().FirstOrDefault(award => award.ID == awardId);
        }
        
    }
}
