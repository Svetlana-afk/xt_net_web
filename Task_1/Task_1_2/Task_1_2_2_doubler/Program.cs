using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_2_2_doubler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Напиши мне что-нибудь:");
            string str1 = Console.ReadLine();
            Console.WriteLine("И еще немножко):");
            string str2 = Console.ReadLine();
            Console.WriteLine("Дублирую символы: {0}", Doubler(str1,str2));
        }

        static StringBuilder Doubler(string str1, string str2)
        {
            StringBuilder doubler = new StringBuilder("");
            
            foreach (var ch in str1)
            {
                if (str2.Contains(ch))
                {
                    doubler.Append(ch, 2);                    
                }
                else 
                {
                    doubler.Append(ch);
                }
            }
            return doubler;
        }
    }
}
