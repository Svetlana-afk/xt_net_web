using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taks_4_1_1
{
    class Watcher
    {
        public static string directoryPath = @"D:\epam\xt_net_web\Task_4\File storage";

        public static void Watch(string directoryPath)
        {            
            using (var watcher = new FileSystemWatcher(directoryPath, "*.txt"))
            {
                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;

                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.Created += new FileSystemEventHandler(OnChanged);
                watcher.Deleted += new FileSystemEventHandler(OnChanged);
                watcher.Renamed += new RenamedEventHandler(OnRenamed);
                watcher.Error += new ErrorEventHandler(OnError);

                watcher.IncludeSubdirectories = true;
                watcher.EnableRaisingEvents = true;
                MakeTmpCopy(directoryPath);

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
            if (e.ChangeType == WatcherChangeTypes.Changed) 
            {
                var fm = CompareFiles(e.FullPath, e.FullPath+".tmp");
                Log(JsonConvert.SerializeObject(fm));
            }            
            Console.WriteLine(logMessage);
            MakeTmpCopy(directoryPath);
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
        private static FileModification CompareFiles(string newFileName, string oldFileName) 
        {
            var fm = new FileModification() { Data = DateTime.Now.Ticks, FileName = newFileName };
            fm.Changes = new List<StringModification>();
            List<string> newFileToListString;
            List<string> oldFileToListString;
            ConvertFileToListString(newFileName, out newFileToListString);
            ConvertFileToListString(oldFileName, out oldFileToListString);
            for (int i = 0; i < oldFileToListString.Count; i++)
            {
                if (i >= newFileToListString.Count) 
                {
                    fm.Changes.Add(new StringModification(i, oldFileToListString[i], ""));
                }
                else if (newFileToListString[i] != oldFileToListString[i])
                {
                    fm.Changes.Add(new StringModification(i, oldFileToListString[i], newFileToListString[i]));
                }
            }
            if (newFileToListString.Count > oldFileToListString.Count)
            {
                for (int i = oldFileToListString.Count; i < newFileToListString.Count; i++) 
                {
                    fm.Changes.Add(new StringModification(i, "", newFileToListString[i]));                        
                }
            }
            Console.WriteLine(fm.FileName);
            Console.WriteLine(fm.Data);
            foreach (var item in fm.Changes)
            {
                Console.WriteLine("{0} : {1} => {2}", item.NumberOfString, item.OldString, item.NewString);
            }
            return fm;
        }
        private static bool ConvertFileToListString(string filename, out List<string> LS)
        {               
            StreamReader sr;
            try
            {
                sr = new StreamReader(filename);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                LS = null;
                return false;
            }
            LS = new List<string>(0);
            string s;
            while ((s = sr.ReadLine()) != null)
                LS.Add(s);
            sr.Close();
            return true;
        }
        public static void UndoToData(long data) 
        {
            List<string> logToString = new List<string>();
            if (ConvertFileToListString(directoryPath + @"\logg", out logToString)) 
            {
                for (int i = logToString.Count-1; i >= 0; i--)
                {
                    FileModification fm = JsonConvert.DeserializeObject<FileModification>(logToString[i]);
                    if (fm.Data > data)
                    {
                        List<string> fileToString = new List<string>();
                        ConvertFileToListString(fm.FileName, out fileToString);
                        foreach (var item in fm.Changes)
                        {
                            fileToString[item.NumberOfString] = item.OldString;
                        }                        
                        using (var undoFile = new StreamWriter(fm.FileName))
                        {
                            foreach (var item in fileToString)
                            {
                                undoFile.WriteLine(item);
                            }                            
                        }
                    }
                }
            }

        }
        public static void Log(string fileModificationJSON)
        {
            using (var w = new StreamWriter(directoryPath + @"\logg", true))
            {
                w.WriteLine(fileModificationJSON);
            }
        }
        public static void MakeTmpCopy(string directoryPath)
        {
            string[] fileEntries = Directory.GetFiles(directoryPath, "*.txt", SearchOption.AllDirectories);
            foreach (string fileName in fileEntries)
            {
                File.Copy(fileName, fileName + ".tmp", true);
            }
        }
    }
}
