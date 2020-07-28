﻿using System;
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
                            Watcher(directoryPath);
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
        }
        private static void Watcher(string directoryPath) 
        {     
            //  Create a FileSystemWatcher
            using (var watcher = new FileSystemWatcher(directoryPath, "*.txt"))
            {
                // Watch for changes
                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;

                //watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.Created += new FileSystemEventHandler(OnChanged);
                watcher.Deleted += new FileSystemEventHandler(OnChanged);
                watcher.Renamed += new RenamedEventHandler(OnRenamed);
                watcher.Error += new ErrorEventHandler(OnError);

                watcher.IncludeSubdirectories = true;
                watcher.EnableRaisingEvents = true;

                Console.WriteLine("Press 'q' to quit the sample.");
                while (Console.Read() != 'q') ;
            }
        }
        private static void OnChanged(object source, FileSystemEventArgs e) 
        {
            if (e.ChangeType == WatcherChangeTypes.Created && String.IsNullOrEmpty(File.ReadAllText(e.FullPath)))
            {
                return;
            }
            WatcherChangeTypes changeTypes = e.ChangeType;
            string logMessage = String.Format("File {0} {1}", e.FullPath, changeTypes.ToString());
            Log(logMessage);
            Console.WriteLine(logMessage);
        }
        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            WatcherChangeTypes changeTypes = e.ChangeType;
            Console.WriteLine("File {0} {1} to {2}", e.OldFullPath, e.FullPath, changeTypes.ToString());
        }
        private static void OnError(object source, ErrorEventArgs e) 
        {
            Console.WriteLine("The FileSystemWatcher has detected an error");
            if (e.GetException().GetType() == typeof(InternalBufferOverflowException))
            {
                Console.WriteLine(("The file system watcher experienced an internal buffer overflow: " + e.GetException().Message));
            }
        }
        public static void Log(string logMessage)
        {
            using (var w = new StreamWriter(directoryPath + @"\logg", true))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                w.WriteLine("  :");
                w.WriteLine($"  :{logMessage}");
                w.WriteLine("-------------------------------");
            }
        }
          
    }
}