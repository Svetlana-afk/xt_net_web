using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taks_4_1_1
{
    public class RenameModification : IUnoFileModification
    {
        public string NewName { get; private set; }

        public RenameModification(string newName) 
        {
            NewName = newName;
        }
    }
}
