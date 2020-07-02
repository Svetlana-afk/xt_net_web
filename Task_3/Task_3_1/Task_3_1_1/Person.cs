using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_1_1
{
    public class Person
    {
        public int SequenceNumber { get; private set; }
        
        public Person(int sequenceNumber)
        {
            SequenceNumber = sequenceNumber;            
        }

        public static explicit operator Person(LinkedListNode<Person> v)
        {
            throw new NotImplementedException();
        }
    }
}
