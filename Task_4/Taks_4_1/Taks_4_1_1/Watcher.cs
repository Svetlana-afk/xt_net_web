using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Taks_4_1_1
{
    class Watcher
    {
        private string directoryPath;

        public Watcher(string directoryPath) 
        {
            this.directoryPath = directoryPath;
        }

        public void Watch(string directoryPath)
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
                try
                {
                    MakeTmpCopy(directoryPath);
                } catch(Exception ex) 
                {
                    Console.Error.WriteLine(ex.Message);
                    throw new MakeTmpCopyException("Can't create temporary file copies.", ex);
                }
                
                Console.WriteLine("Press 'q' to quit the sample.");
                while (Console.Read() != 'q') ;
            }
        }
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            switch (e.ChangeType)
            {
                case WatcherChangeTypes.Changed:
                    {
                        var fm = FmCompareFiles(e.FullPath, e.FullPath + ".tmp");
                        Log(JsonConvert.SerializeObject(fm));
                        break;
                    }
                case WatcherChangeTypes.Deleted:
                    {
                        var fm = FmDeleteFile(e.FullPath);
                        Log(JsonConvert.SerializeObject(fm));
                        break;
                    }
                case WatcherChangeTypes.Created:
                    {
                        var fm = FmCreateFile(e.FullPath);
                        Log(JsonConvert.SerializeObject(fm));
                        break;
                    }
                default:
                    return;
            }

            string logMessage = String.Format("File {0} {1}", e.FullPath, e.ChangeType.ToString());
            Console.WriteLine(logMessage);
            MakeTmpCopy(directoryPath);
        }
        private void OnRenamed(object source, RenamedEventArgs e)
        {
            WatcherChangeTypes changeTypes = e.ChangeType;
            Console.WriteLine("File {0} {1} to {2}", e.OldFullPath, e.FullPath, changeTypes.ToString());

            var fm = new FileModification() { Data = DateTime.Now.Ticks, FileName = e.OldFullPath, NewFileName = e.FullPath,
                ModType = ModifType.Renamed };
            Log(JsonConvert.SerializeObject(fm));

            File.Copy(e.FullPath, e.FullPath + ".tmp", true);
            File.Delete(e.OldFullPath + ".tmp");
        }
        private void OnError(object source, ErrorEventArgs e)
        {
            Console.WriteLine("The FileSystemWatcher has detected an error");
            if (e.GetException().GetType() == typeof(InternalBufferOverflowException))
            {
                Console.WriteLine(("The file system watcher experienced an internal buffer overflow: " + e.GetException().Message));
            }
        }

        private FileModification FmCreateFile(string fileName)
        {
            var fm = new FileModification() { Data = DateTime.Now.Ticks, FileName = fileName, ModType = ModifType.Created };
            File.Copy(fileName, fileName + ".tmp", true);
            return fm;
        }
        private FileModification FmDeleteFile(string fileName)
        {
            var fm = new FileModification() { Data = DateTime.Now.Ticks, FileName = fileName, ModType = ModifType.Deleted };
            File.Copy(fileName + ".tmp", fileName + ".del", true);
            return fm;
        }

        private FileModification FmCompareFiles(string newFileName, string oldFileName)
        {
            var fm = new FileModification() { Data = DateTime.Now.Ticks, FileName = newFileName, ModType = ModifType.Changed };
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
                if (item is StringModification)
                {
                    StringModification sm = (StringModification)item;
                    Console.WriteLine("{0} : {1} => {2}", sm.NumberOfString, sm.OldString, sm.NewString);
                }

            }
            return fm;
        }
        private bool ConvertFileToListString(string filename, out List<string> LS)
        {
            try
            {
                StreamReader sr = new StreamReader(filename);
                LS = new List<string>();
                string s;
                while ((s = sr.ReadLine()) != null)
                    LS.Add(s);
                sr.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                LS = null;
                return false;
            }
            
        }

        private void UndoChangesInFile(FileModification fm)
        {
            List<string> fileToString = new List<string>();
            if (ConvertFileToListString(fm.FileName, out fileToString))
            {
                foreach (var item in fm.Changes)
                {
                    StringModification sm = (StringModification)item;
                    fileToString[sm.NumberOfString] = sm.OldString;
                }
                try
                {
                    using (var undoFile = new StreamWriter(fm.FileName))
                    {
                        foreach (var item in fileToString)
                        {
                            undoFile.WriteLine(item);
                        }
                    }
                } catch (Exception ex) 
                {
                    Console.Error.WriteLine(ex.Message);
                    Console.WriteLine("Can't undo changes in file {0} because of error in file", fm.FileName);
                }
            }
            else 
            {
                Console.WriteLine("Can't undo changes in file {0} because of error in file", fm.FileName);
            }
        }
        public void UndoToData(long data)
        {
            List<string> logToString = new List<string>();
            if (ConvertFileToListString(directoryPath + @"\logg", out logToString))
            {
                for (int i = logToString.Count - 1; i >= 0; i--)
                {
                    try
                    {
                        FileModification fm = JsonConvert.DeserializeObject<FileModification>(logToString[i]);
                        if (fm != null && fm.Data > data)
                        {
                            switch (fm.ModType)
                            {
                                case ModifType.Changed:
                                    {
                                        UndoChangesInFile(fm);
                                        break;
                                    }
                                case ModifType.Created:
                                    {
                                        File.Delete(fm.FileName);
                                        break;
                                    }
                                case ModifType.Renamed:
                                    {
                                        File.Move(fm.NewFileName, fm.FileName);
                                        break;
                                    }
                                case ModifType.Deleted:
                                    {
                                        File.Move(fm.FileName + ".del", fm.FileName);
                                        break;
                                    }
                                default:
                                    break;
                            }
                        }
                    } 
                    catch (Exception ex) 
                    {
                        Console.Error.WriteLine(ex.Message);
                        Console.WriteLine("Can't undo changes in file because of internal error");
                    }                  
                }
            }

            File.Delete(directoryPath + @"\logg");

        }
        private void Log(string fileModificationJSON)
        {
            using (var w = new StreamWriter(directoryPath + @"\logg", true))
            {
                w.WriteLine(fileModificationJSON);
            }
        }
        private void MakeTmpCopy(string directoryPath)
        {
            string[] fileEntries = Directory.GetFiles(directoryPath, "*.txt", SearchOption.AllDirectories);
            foreach (string fileName in fileEntries)
            {
                File.Copy(fileName, fileName + ".tmp", true);
            }
        }
    }
}
