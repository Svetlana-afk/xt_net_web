using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_1_9_non_negative_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[15];
            FillArray(arr);
            Console.WriteLine("Сгенерированный случайным образом массив:");
            PrintArray(arr);
            Console.WriteLine("\nСумма неотрицательных элементов массива: {0}", NonNegativeSum(arr));
        }

        static void FillArray(int[] arr)
        {
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(-20, 20);

            }

        }
        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {

                Console.Write("{0:D}  ", arr[i]);
            }
        }

        static int NonNegativeSum(int[] arr)
        {
            int nonNegativeSum = 0;
            for (int i = 0; i < arr.Length; i++)
            {                
                if (arr[i] > 0) 
                {
                    nonNegativeSum += arr[i];                  
                }
            }
            return nonNegativeSum;
        }
    }
    
}
