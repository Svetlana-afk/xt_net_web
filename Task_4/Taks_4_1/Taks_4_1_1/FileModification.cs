using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taks_4_1_1
{
    class FileModification
    {
        public string FileName { get; set; }
        public string Data { get; set; }        
        public List<StringModification> Changes { get; set; }
    }
    public enum ModificationTypes
    {
    }
}
