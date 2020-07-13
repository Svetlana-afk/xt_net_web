using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_2_1_Dynamic_Array
{
    class Program
    {
        static void Main(string[] args)
        {                     
            int[] a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            List<int> b = new List<int>() { 10, 11, 12, 13, 14, 15, 16, 17 };
            DynamicArray<int> darr = new DynamicArray<int>(a);
            Console.WriteLine("DYNAMIC ARRAY");
            printDynamicArray<int>(darr);
            Console.WriteLine("Вывод массива после объединения с другой коллекцией и после вставки элемента:");
            darr.AddRange(b);
            darr.Insert(8, 9);            
            printDynamicArray<int>(darr);
            Console.WriteLine("Изменение емкости массива на  число меньшее, чем количество элементов.");
            darr.Capasity = 11;
            printDynamicArray<int>(darr);
            Console.WriteLine("Удаление элемента:");
            darr.Remove(5);
            printDynamicArray<int>(darr);
            Console.WriteLine("Вывод элемента с отрицательным индексом -2:");
            Console.WriteLine(darr[-2]);
            Console.WriteLine("\r\nВывод с помощью Итератора:");
            IEnumerator<int> edarr = darr.GetEnumerator();
            while (edarr.MoveNext())
            {
                int value = edarr.Current;
                Console.Write(value + " ");               
            }            
        }
        public static void printDynamicArray<T>(DynamicArray<T> darr) 
        {
            Console.WriteLine("Вывод массива: ");
            foreach (var item in darr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\r\nДлина массива: {0}", darr.Length);
            Console.WriteLine("Емкость массива: {0}", darr.Capasity);
        }
    }
}
