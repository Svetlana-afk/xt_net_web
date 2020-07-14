using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[]{ 1, 2, 3, 4, 5, 6, 7 , 8, 1};
            array.SuperArray(MultiplyToTwo);
            Console.WriteLine("Массив после умножения его элементов на 2:");
            PrintArray(array);
            Console.WriteLine("\n\rСреднее значение массива:");
            Console.WriteLine(array.FindAverage());
            Console.WriteLine("\n\rСумма всех элементов массива:");
            Console.WriteLine(array.FindSum());
            Console.WriteLine("\n\rСамый часто встречающийся элемент массива:");
            Console.WriteLine(array.FindMostFrequent());
            
        }
        static int MultiplyToTwo(int A) => A * 2;
        static void PrintArray(int[] array) 
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
        }
    }
}
