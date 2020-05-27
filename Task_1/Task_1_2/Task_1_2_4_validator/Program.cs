using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_2_4_validator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Напишите небольшой рассказ о себе:");
            string str = Console.ReadLine();
            Console.WriteLine(Validator(str));
        }

        static string Validator(string str)
        {
            StringBuilder validString = new StringBuilder(str);
            string[] endOfSentence = { "! ", ". ", "? ","?! ", "... ",".\" ", "!\" " , "?\" "};
            if (char.IsLetter(str[0]))
            {
                validString.Replace(str[0], char.ToUpper(str[0]), 0, 1);
            }
            else if (str[0]=='"')
            {
                validString.Replace(str[1], char.ToUpper(str[1]), 1, 1);
            }

            foreach (string end in endOfSentence)
            {
                int index = 0;
                while(validString.ToString().Substring(index).Contains(end))
                {
                    string curString = validString.ToString().Substring(index);
                    int curIndex = curString.IndexOf(end) + 2;
                    index += curIndex;
                    if (char.IsLetter(curString[curIndex]))
                    {
                        validString.Replace(curString[curIndex], char.ToUpper(curString[curIndex]), index, 1);
                    }
                    else 
                    {
                        curIndex++;
                        index++;
                        validString.Replace(curString[curIndex], char.ToUpper(curString[curIndex]), index, 1);
                    }                    
                }
            }
            return validString.ToString();
        }
    }
}
