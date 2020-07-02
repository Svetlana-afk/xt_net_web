using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_1_1
{
    public class Counting
    {
        public int NumberOfParticipants { get; set; }
        public int NumberToCrossedOut { get; set; }
        public LinkedList<Person> CircleOfPeople { get; private set; }

        //Вариант1
        public void makeCounting()
        {
            int i = 1;
            int removeAt = NumberToCrossedOut - 1;
            while (CircleOfPeople.Count >= NumberToCrossedOut) 
            {
                Console.WriteLine("РАУНД {0}. Вычеркнут человек с номером: {1}", i, CircleOfPeople.ElementAt(removeAt).SequenceNumber);
                
                CircleOfPeople.Remove(CircleOfPeople.ElementAt(removeAt));
                Console.WriteLine("Людей осталось: {0}", CircleOfPeople.Count);
              
                removeAt += NumberToCrossedOut - 1;
                if (removeAt >= CircleOfPeople.Count) 
                {
                    removeAt -= CircleOfPeople.Count;
                }
                i++;
            }
            Console.WriteLine("Игра окончена. Невозможно вычеркнуть больше людей.");
        }
        
        //Вариант2
        public void makeCounting2()
        {
            int i = 1;
            int removeAt = NumberToCrossedOut - 1;
            var currentItem = CircleOfPeople.First;
            int counter = 0;
            while (CircleOfPeople.Count >= NumberToCrossedOut)
            {
                if (currentItem != null)
                {              
                    if (counter == removeAt)
                    {
                        Console.WriteLine("РАУНД {0}. Вычеркнут человек с номером: {1}", i, currentItem.Value.SequenceNumber);
                        CircleOfPeople.Remove(currentItem);
                        Console.WriteLine("Людей осталось: {0}", CircleOfPeople.Count);
                        
                        removeAt += NumberToCrossedOut - 1;
                        if (removeAt >= CircleOfPeople.Count)
                        {
                            removeAt -= CircleOfPeople.Count;
                        }
                        i++;
                    }
                    counter++;
                    currentItem = currentItem.Next;
                } 
                else 
                {
                    counter = 0;
                    currentItem = CircleOfPeople.First;
                }
            }
            Console.WriteLine("Игра окончена. Невозможно вычеркнуть больше людей.");
        }
        public void GenerateCircleOfPeople() 
        {
            CircleOfPeople = new LinkedList<Person>();            

            for (int i = 1; i < NumberOfParticipants+1; i++)
            {               
                CircleOfPeople.AddLast(new Person(i));
            }            
        }
        public void PrintCircleOfPeople()
        {
            foreach (var item in CircleOfPeople)
            {
                Console.WriteLine(item.SequenceNumber);
            }            
        }        
    }
}
