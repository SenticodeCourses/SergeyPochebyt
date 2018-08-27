using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace SergCo.SystemMonitoring.FolderMonitoring
{
    public class FolderMonitor
    {
        public string[] folderFiles = null;
        public string[] previosFolderFiles = null;
        public string[] resulCompare = null;
        public bool _isMonitoring;
        public string _path;

        public void FolderInitialize(string path)
        {
            if (Directory.Exists(path))
            {
                Console.WriteLine($"Monitoring folder {path}");
                {
                    folderFiles = Directory.GetFiles(path);
                    previosFolderFiles = Directory.GetFiles(path);
                    _path = path;
                }
            }
            else
            {
                Console.WriteLine($"Invalid dir {path}");
            }
        }

        public void GetFolderFiles(string path)
        {
            previosFolderFiles = folderFiles;
            folderFiles = Directory.GetFiles(path);
        }

        public void GetChanges(string[] one, string[] two)
        {
            resulCompare = one.Except(two).ToArray();
        }

        public void ResulCompareAdd()
        {
            GetChanges(folderFiles, previosFolderFiles);
            if (resulCompare.Length != 0)
            {
                Console.WriteLine("Files was added:");
                foreach (string t in resulCompare)
                {
                    Console.WriteLine(t);
                }
            }
        }

        public void ResulCompareDelete()
        {
            GetChanges(previosFolderFiles, folderFiles);
            if (resulCompare.Length != 0)
            {
                Console.WriteLine("Files was deleted:");
                foreach (string t in resulCompare)
                {
                    Console.WriteLine(t);
                }
            }

        }

        public void Monitoring()
        {
            while (_isMonitoring)
            {
                GetFolderFiles(_path);
                ResulCompareAdd();
                ResulCompareDelete();
                Thread.Sleep(10000);
                Console.WriteLine("\n10 second\n");
            }
        }
        public void ShowFiles()
        {
            Console.WriteLine("Folder now");
            foreach (string t in folderFiles)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine("Folder later");
            foreach (string t in previosFolderFiles)
            {
                Console.WriteLine(t);
            }


        }

    }
}
