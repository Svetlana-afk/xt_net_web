using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.PhotoAwards.Entities
{
    public class Photo
    {
        public Guid ID { get; set; }
        public Guid PhotographerID { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public Guid AwardId { get; set; }
        public List<Guid> JuryVotes { get; set; }
    }
}
