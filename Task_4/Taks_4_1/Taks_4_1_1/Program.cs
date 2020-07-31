using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taks_4_1_1
{
    class Program
    {
        public static string directoryPath = @"D:\epam\xt_net_web\Task_4\File storage";
        static void Main(string[] args)
        {            
            int choise;
            bool succes = true;           
            while (succes) 
            {
                Console.WriteLine("Пожалуйста, выберите режим работы: " +
                 "\r\n 1. Режим наблюдения" +
                 "\r\n 2. Режим отката изменений");
                if (int.TryParse(Console.ReadLine(), out choise) && (choise <= 2) && (choise > 0))
                {
                    switch (choise)
                    {
                        case 1:
                            Watcher.Watch(directoryPath);
                            break;
                        case 2:
                            Console.WriteLine("Введите дату и время к которому нужно совершить откат.");
                            var str = Console.ReadLine();
                            succes = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                }
            }
            RemoveTmpCopy(directoryPath);
        }
        

        public static void RemoveTmpCopy(string directoryPath)
        {
            string[] fileEntries = Directory.GetFiles(directoryPath, "*.tmp", SearchOption.AllDirectories);
            foreach (string fileName in fileEntries)
            {
                File.Delete(fileName);
            }
        }


    }
}
