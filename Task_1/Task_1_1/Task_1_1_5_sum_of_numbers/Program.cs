using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_1_5_sum_of_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sum of numbers is: {0:D}", SumOfNumbers());
        }
        static int SumOfNumbers()
        {
            int num3 = 3;
            int num5 = 5;
            int sum3 = 0;
            int sum5 = 0;
            while (num3 < 1000)
            {
                sum3 += num3;
                num3 += 3;
            }
            while (num5 < 1000)
            { 
                sum5 += num5;
                num5 += 5;
            }
            int sumOfNumbers = sum3 + sum5;


            return sumOfNumbers;
        }

    }
}
