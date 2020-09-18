using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UsersManager.Entities
{
    public class Award
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public List<Guid> UsersId { get; set; }
        //public Award(string title) 
        //{
        //    this.Title = title;
        //    UsersId = new List<Guid>();
        //}
    }
}
