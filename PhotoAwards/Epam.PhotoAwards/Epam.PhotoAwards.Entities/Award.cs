using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.PhotoAwards.Entities
{
    public class Award
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public List<Photo> Photos { get; set; }
        public Guid PhotoWinner { get; set; }
        public Guid Winner { get; set; }
    }
}
