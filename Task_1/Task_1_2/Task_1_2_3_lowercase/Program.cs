using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_2_3_lowercase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Напиши мне что-нибудь:");
            string str = Console.ReadLine();
            Console.WriteLine(Lowercase(str));
        }

        static int Lowercase(string str) 
        {
            int countLowercaseWords = 0;
            char[] delimiterChars = { ' ', ',', '.', ':', '\t', '!', '?', ';' , '"'};
            string[] arrayOfWords = str.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in arrayOfWords) 
            {
                if (char.IsLower(word[0])) 
                {
                    countLowercaseWords++;
                }
            }
            return countLowercaseWords;
        }
    }
}
