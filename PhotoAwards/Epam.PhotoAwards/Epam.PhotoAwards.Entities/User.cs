using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.PhotoAwards.Entities
{
    public class User
    {
        public Guid ID { get; set; }
        public string EMail { get; set; }
        public string Pass { get; set; }
        public UserRoles Role { get; set; }

    }
    public enum UserRoles 
    {
        None = 0,
        Photographer = 1,
        Jury = 2
    }
}
