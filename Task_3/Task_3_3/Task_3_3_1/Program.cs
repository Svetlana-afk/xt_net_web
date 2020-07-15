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
            double[] array1 = new double[] { 11.5, 12.3, 14.8, 12.3 };
            array1.SuperArray(MultiplyToTwo);
            Console.WriteLine("Массив после умножения его элементов на 2:");
            PrintArray(array1);
            Console.WriteLine("\n\rСреднее значение массива:");
            Console.WriteLine(array1.FindAverage());
            Console.WriteLine("\n\rСумма всех элементов массива:");
            try
            {
                Console.WriteLine(array1.FindSum());
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Значение суммы вышло за пределы допустимых значений: " + ex.Message);
            }
            catch (ArgumentNullException) 
            {
                Console.WriteLine("Нельзя вызвать метод Sum у пустого массива.");
            }            
            Console.WriteLine("\n\rСамый часто встречающийся элемент массива:");
            Console.WriteLine(array1.FindMostFrequent());            
        }
        static int MultiplyToTwo(int A) => A * 2;
        static int? MultiplyToTwo(int? A) => A * 2;
        static float MultiplyToTwo(float A) => A * 2;
        static float? MultiplyToTwo(float? A) => A * 2;
        static double MultiplyToTwo(double A) => A * 2;
        static double? MultiplyToTwo(double? A) => A * 2;
        static long MultiplyToTwo(long A) => A * 2;
        static long? MultiplyToTwo(long? A) => A * 2;
        static decimal MultiplyToTwo(decimal A) => A * 2;
        static decimal? MultiplyToTwo(decimal? A) => A * 2;

        static void PrintArray<T>(T[] array) 
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
        }
    }
}
