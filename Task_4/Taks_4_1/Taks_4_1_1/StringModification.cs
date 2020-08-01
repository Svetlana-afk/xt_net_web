using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taks_4_1_1
{
    public class StringModification : IUnoFileModification
    {
        public int NumberOfString { get; private set; }
        public string OldString { get; private set; }
        public string NewString { get; private set; }

        public StringModification(int numberOfString, string oldString, string newString) 
        {
            NumberOfString = numberOfString;
            OldString = oldString;
            NewString = newString;
        }

    }
}
