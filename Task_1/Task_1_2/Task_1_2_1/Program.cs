using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Напишите небольшой рассказ о себе:");
            string str = Console.ReadLine();
            Console.WriteLine("Очень интересно, средняя длина слова: {0:F}", AverageWordLength(str));    
        }

        //Функция AverageWordLength возвращает значение в виде числа с плавающей точкой
        static float AverageWordLength(string str) 
        {
            int countOfWords = 0;
            int sumOfСhars = 0;
            char[] delimiterChars = { ' ', ',', '.', ':', '\t', '!', '?'};
            string[] arrayOfWords = str.Split(delimiterChars);
            foreach (var word in arrayOfWords)
            {              
                if (word.Length != 0) 
                {
                    countOfWords += 1;
                    sumOfСhars += word.Length;               
                }              
            }
            return (float)sumOfСhars / countOfWords;
        }
    }
}
