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

        private static string directoryPath = @"D:\epam\xt_net_web\Task_4\File storage";
        static void Main(string[] args)
        {
            Watcher watcher = new Watcher(directoryPath);
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
                                try
                                {
                                    watcher.Watch(directoryPath);
                                }
                                catch (MakeTmpCopyException ex)
                                {
                                    Console.Error.WriteLine(ex.Message);
                                    Console.WriteLine("Oops. Something wrong with the process of making temp copies. Please ask developers help.");
                                    return;
                                }
                                catch (Exception ex)
                                {
                                    Console.Error.WriteLine(ex.Message);
                                    Console.WriteLine("Oops. Something wrong with directory path. Please ask developers help.");
                                    return;
                                }
                            }
                            else 
                            {
                                Console.WriteLine("Указанной дирректории не существует.");
                            }
                            
                            break;
                        case 2:
                            try
                            {
                                Console.WriteLine("Введите дату и время к которому нужно совершить откат. 08/07/2020 07:22:16");
                                DateTime dateTime = DateTime.Parse(Console.ReadLine());
                                watcher.UndoToData(dateTime.Ticks);
                            } catch (Exception ex) 
                            {
                                Console.Error.WriteLine(ex.Message);
                                Console.WriteLine("Вы ввели неверную дату или ввели ее в неверном формате");
                            }
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
            try
            {
                RemoveTmpCopies(directoryPath);
            } catch (Exception ex) 
            {
                Console.Error.WriteLine(ex.Message);
                Console.WriteLine("An error is occured on deleting tmp files from directory: {0}", directoryPath);
            }
            
        }      

        public static void RemoveTmpCopies(string directoryPath)
        {
            string[] fileEntries = Directory.GetFiles(directoryPath, "*.tmp", SearchOption.AllDirectories);
            foreach (string fileName in fileEntries)
            {
                try
                {
                    File.Delete(fileName);
                }
                catch (Exception ex) 
                {
                    Console.Error.WriteLine(ex.Message);
                    Console.WriteLine("An error is occured on deleting tmp file: {0}", fileName);
                }             
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
                    try
                    {
                        RemoveTmpCopies(directoryPath);
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine(ex.Message);
                        Console.WriteLine("An error is occured on deleting tmp files from directory: {0}", directoryPath);
                    }
                    Environment.Exit(0);
                    return false;

                default:
                    return false;
            }
        }
    }
}
