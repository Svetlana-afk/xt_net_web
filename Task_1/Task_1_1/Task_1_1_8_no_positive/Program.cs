using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_1_8_no_positive
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,,] arr = new int[3,4,2];
            FillArray(arr);
            Console.WriteLine("Сгенерированный случайным образом трехмерный массив:");
            PrintArray(arr);      
            
            Console.WriteLine("No Positive Массив:");
            NoPositive(arr);
            PrintArray(arr);
        }

        static void FillArray(int[,,] arr)
        {
            Random rand = new Random();
            for (int i = 0; i < arr.GetLength(0); ++i)
            {
                for (int j = 0; j < arr.GetLength(1); ++j)
                {
                    for (int k = 0; k < arr.GetLength(2); ++k)
                    {
                        arr[i, j, k] = rand.Next(-20, 20);
                    }
                }                  
            }
        }

        static void PrintArray(int[,,] arr)
        {            
            for (int i = 0; i < arr.GetLength(0); ++i)
            {
                for (int j = 0; j < arr.GetLength(1); ++j)
                {
                    for (int k = 0; k < arr.GetLength(2); ++k)
                    {
                        Console.Write("{0}  ", arr[i, j, k]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        static void NoPositive(int[,,] arr)
        {           
            for (int i = 0; i < arr.GetLength(0); ++i)
            {
                for (int j = 0; j < arr.GetLength(1); ++j)
                {
                    for (int k = 0; k < arr.GetLength(2); ++k)
                    {
                        if (arr[i, j, k] > 0) { arr[i, j, k] = 0; }                        
                    }
                }
            }
        }
    }
}
