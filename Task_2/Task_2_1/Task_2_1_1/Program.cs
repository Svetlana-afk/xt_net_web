using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringAsArrayLibrary;

namespace Task_2_1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            StringAsArray strA = new StringAsArray("Прекрасная ".ToCharArray());
            StringAsArray strB = new StringAsArray("Погода!".ToCharArray());
            StringAsArray strC = new StringAsArray(strB);
            StringAsArray strD = new StringAsArray(strB);

            Console.WriteLine("Сравнение строк 'Прекрасная' и  'погода!' методом CompareTo: {0}", strA.CompareTo(strB));
            Console.WriteLine("Сравнение строк 'Погода!' и  'Погода!' методом Equals: {0}", StringAsArray.Equals(strB, strC));
            Console.WriteLine("Конкатенация строк 'Прекрасная' и  'погода!' статическим методом Concat: {0}",
                                StringAsArray.Concat(strA, strB).ToString());
            int index = strC.IndexOf('о', 0, strC.Length);
            strC.Replace(index, 'a');
            Console.WriteLine("Пиши правильно: '{0}', пиши '{1}'!", strC, strC[1]);
            Console.WriteLine(strB.GetHashCode());
            Console.WriteLine(strD.GetHashCode());

        }
    }
}
