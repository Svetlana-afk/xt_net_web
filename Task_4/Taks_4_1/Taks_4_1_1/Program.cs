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
        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(EventHandler handler, bool add);
        private delegate bool EventHandler(CtrlType sig);
        private enum CtrlType
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }

        public static string directoryPath = @"D:\epam\xt_net_web\Task_4\File storage";
        static void Main(string[] args)
        {            
            int choise;
            bool succes = true;

            // Register the close program handler
            SetConsoleCtrlHandler(CloseProgramHandler, true);

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
                            if (Directory.Exists(directoryPath))
                            {
                                Watcher.Watch(directoryPath);
                            }
                            else 
                            {
                                Console.WriteLine("Указанной дирректории не существует.");
                            }
                            
                            break;
                        case 2:
                            Console.WriteLine("Введите дату и время к которому нужно совершить откат. 08/18/2018 07:22:16");
                            DateTime dateTime = DateTime.Parse(Console.ReadLine());
                            Watcher.UndoToData(dateTime.Ticks);
                            break;
                    }
                }
                if (Console.ReadLine()=="q")
                {
                    break;
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

        private static bool CloseProgramHandler(CtrlType signal)
        {
            switch (signal)
            {
                case CtrlType.CTRL_BREAK_EVENT:
                case CtrlType.CTRL_C_EVENT:
                case CtrlType.CTRL_LOGOFF_EVENT:
                case CtrlType.CTRL_SHUTDOWN_EVENT:
                case CtrlType.CTRL_CLOSE_EVENT:
                    Console.WriteLine("Closing");
                    RemoveTmpCopy(directoryPath);
                    // TODO Cleanup resources
                    Environment.Exit(0);
                    return false;

                default:
                    return false;
            }
        }
    }
}
