using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_1_10_2d_array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[5, 8];
            FillArray(arr);
            Console.WriteLine("Сгенерированный случайным образом 2D массив:");
            PrintArray(arr);
            Console.WriteLine("Сумма чисел на четных позициях: {0}", SumArray(arr));            
        }
        static void FillArray(int[,] arr)
        {
            Random rand = new Random();
            for (int i = 0; i < arr.GetLength(0); ++i)
            {
                for (int j = 0; j < arr.GetLength(1); ++j)
                {
                    arr[i, j] = rand.Next(-40, 40);
                }
            }
        }

        static void PrintArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); ++i)
            {
                for (int j = 0; j < arr.GetLength(1); ++j)
                {
                    Console.Write("{0}  ", arr[i, j]);                  
                }
                Console.WriteLine();               
            }
        }

        static int SumArray(int[,] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); ++i)
            {
                for (int j = 0; j < arr.GetLength(1); ++j)
                {
                    if ((j + i) % 2 == 0) { sum += arr[i, j]; }
                }
                Console.WriteLine();
            }

            return sum;
        }
    }
}
