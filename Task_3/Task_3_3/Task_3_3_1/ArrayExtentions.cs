using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_3_1
{
    public delegate int Function(int x);
    
    public static class ArrayExtentions
    {        
        public static void SuperArray(this int[] mass, Function function) 
        {
            for (int i = 0; i < mass.Length; i++)
            {
                mass[i] = function(mass[i]);
            }
        }
        public static double FindAverage(this int[] mass) 
        {
            return mass.Average();
        }

        public static double FindSum(this int[] mass)
        {
            return mass.Sum();
        }
        public static int FindMostFrequent(this int[] mass) 
        {
            var mostFrequent = mass.GroupBy(elem => elem).OrderBy(elem => elem.Count()).Last();
            return mostFrequent.Key;
        }
    }
}
