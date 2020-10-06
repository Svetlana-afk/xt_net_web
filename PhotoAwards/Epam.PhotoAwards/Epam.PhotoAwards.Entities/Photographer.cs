using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.PhotoAwards.Entities
{
    public class Photographer
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; private set; }
        public string Logo { get; set; }
        public List<Award> Awards { get; set; }
        public List<Photo> Photos { get; set; }

        public Photographer(string name, DateTime dateOfBirth)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            DateOfBirth = dateOfBirth;
            countAge();
            Awards = new List<Award>();
            Photos = new List<Photo>();
        }

        public void countAge()
        {
            this.Age = DateTime.Now.Year - DateOfBirth.Year;
            if (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear)
            {
                Age++;
            }
        }
    }
}
