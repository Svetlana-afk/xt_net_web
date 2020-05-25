using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_1_7_array_processing
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[15];
            FillArray(arr);
            Console.WriteLine("Сгенерированный случайным образом массив:");
            PrintArray(arr);
            SortArray(arr);
            Console.WriteLine("Отсортированный массив:");
            PrintArray(arr);
            Console.WriteLine("Минимальное значение в Массиве: {0:D}", arr[0]);
            Console.WriteLine("Максимальное значение в Массиве: {0:D}", arr[14]);

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
                
                Console.WriteLine("{0:D}", arr[i]);
            }
        }
        static void SortArray(int[] arr)
        {
            int a;
            for (int i = 0; i < arr.Length-1; i++)
            {
                for (int j = 0; j < arr.Length-i-1; j++) 
                {
                    if (arr[j] > arr[j + 1])
                    {
                        a = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = a;
                    }

                }
                
            }

        }
    }
}
