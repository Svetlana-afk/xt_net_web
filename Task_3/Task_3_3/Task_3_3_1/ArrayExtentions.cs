using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_3_1
{    
    public static class ArrayExtentions
    {        
        public static void SuperArray<T>(this T[] mass, Func<T, T> function) 
        {
            if (mass == null) 
            {
                throw new ArgumentNullException(nameof(mass), $"Parameter {mass} can't be null.");
            }
            if (function == null) 
            {
                throw new ArgumentNullException(nameof(function), $"Parameter {function} can't be null.");
            }   
            for (int i = 0; i < mass.Length; i++)
            {
                mass[i] = function(mass[i]);
            }
        }
        public static double FindAverage(this int[] mass)
        {
            if (mass == null)
            {
                throw new ArgumentNullException(nameof(mass), $"Parameter {mass} can't be null.");
            }
            return mass.Average();
        }
        public static double? FindAverage(this int?[] mass)
        {
            if (mass == null)
            {
                throw new ArgumentNullException(nameof(mass), $"Parameter {mass} can't be null.");
            }
            return mass.Average();
        }
        public static double FindAverage(this long[] mass)
        {
            if (mass == null)
            {
                throw new ArgumentNullException(nameof(mass), $"Parameter {mass} can't be null.");
            }
            return mass.Average();
        }
        public static double? FindAverage(this long?[] mass)
        {
            if (mass == null)
            {
                throw new ArgumentNullException(nameof(mass), $"Parameter {mass} can't be null.");
            }
            return mass.Average();
        }
        public static double FindAverage(this double[] mass)
        {
            if (mass == null)
            {
                throw new ArgumentNullException(nameof(mass), $"Parameter {mass} can't be null.");
            }
            return mass.Average();
        }
        public static double? FindAverage(this double?[] mass)
        {
            if (mass == null)
            {
                throw new ArgumentNullException(nameof(mass), $"Parameter {mass} can't be null.");
            }
            return mass.Average();
        }
        public static decimal FindAverage(this decimal[] mass)
        {
            if (mass == null)
            {
                throw new ArgumentNullException(nameof(mass), $"Parameter {mass} can't be null.");
            }
            return mass.Average();
        }
        public static decimal? FindAverage(this decimal?[] mass)
        {
            if (mass == null)
            {
                throw new ArgumentNullException(nameof(mass), $"Parameter {mass} can't be null.");
            }
            return mass.Average();
        }
        public static float FindAverage(this float[] mass)
        {
            if (mass == null)
            {
                throw new ArgumentNullException(nameof(mass), $"Parameter {mass} can't be null.");
            }
            return mass.Average();
        }
        public static float? FindAverage(this float?[] mass)
        {
            if (mass == null)
            {
                throw new ArgumentNullException(nameof(mass), $"Parameter {mass} can't be null.");
            }
            return mass.Average();
        }
        
        public static double FindSum(this double[] mass)
        {
            if (mass == null)
            {
                throw new ArgumentNullException(nameof(mass), $"Parameter {mass} can't be null.");
            }
            return mass.Sum();
        }
        public static double? FindSum(this double?[] mass)
        {
            if (mass == null)
            {
                throw new ArgumentNullException(nameof(mass), $"Parameter {mass} can't be null.");
            }
            return mass.Sum();
        }
        public static int FindSum(this int[] mass) 
        {
            if (mass == null)
            {
                throw new ArgumentNullException(nameof(mass), $"Parameter {mass} can't be null.");
            }
            return mass.Sum();
        }
        public static int? FindSum(this int?[] mass)
        {
            if (mass == null)
            {
                throw new ArgumentNullException(nameof(mass), $"Parameter {mass} can't be null.");
            }
            return mass.Sum();
        }
        public static float FindSum(this float[] mass)
        {
            if (mass == null)
            {
                throw new ArgumentNullException(nameof(mass), $"Parameter {mass} can't be null.");
            }
            return mass.Sum();
        }
        public static float? FindSum(this float?[] mass)
        {
            if (mass == null)
            {
                throw new ArgumentNullException(nameof(mass), $"Parameter {mass} can't be null.");
            }
            return mass.Sum();
        }
        public static long FindSum(this long[] mass)
        {
            if (mass == null)
            {
                throw new ArgumentNullException(nameof(mass), $"Parameter {mass} can't be null.");
            }
            return mass.Sum();
        }
        public static long? FindSum(this long?[] mass)
        {
            if (mass == null)
            {
                throw new ArgumentNullException(nameof(mass), $"Parameter {mass} can't be null.");
            }
            return mass.Sum();
        }
        public static decimal FindSum(this decimal[] mass)
        {
            if (mass == null)
            {
                throw new ArgumentNullException(nameof(mass), $"Parameter {mass} can't be null.");
            }
            return mass.Sum();
        }
        public static decimal? FindSum(this decimal?[] mass)
        {
            if (mass == null)
            {
                throw new ArgumentNullException(nameof(mass), $"Parameter {mass} can't be null.");
            }
            return mass.Sum();
        }
        /// <summary>
        /// Поиск наиболее часто встречаемого элемента
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mass"></param>
        /// <returns></returns>
        public static T FindMostFrequent<T>(this T[] mass) 
        {
            if (mass == null)
            {
                throw new ArgumentNullException(nameof(mass), $"Parameter {mass} can't be null.");
            }
            var mostFrequent = mass.GroupBy(elem => elem).OrderBy(elem => elem.Count()).Last();
            return mostFrequent.Key;
        }
    }
}
