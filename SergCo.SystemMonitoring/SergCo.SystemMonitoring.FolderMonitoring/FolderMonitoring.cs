using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Security.Cryptography;

namespace SergCo.SystemMonitoring.FolderMonitoring
{
    public class FolderMonitor
    {
        public string[] folderFiles = null;
        public string[] previosFolderFiles = null;
        public string[] resulCompare = null;
        public bool _isMonitoring;
        public string _path;
        public Dictionary<string, string> folderStateHash = new Dictionary<string, string>();
        public Dictionary<string, string> previosFolderStateHash = new Dictionary<string, string>();
        public Dictionary<string, string> resultCompareHash = new Dictionary<string, string>();


        public void FolderInitialize(string path)
        {
            if (Directory.Exists(path))
            {
                Console.WriteLine($"Monitoring folder {path}");
                {
                    folderFiles = Directory.GetFiles(path);
                    previosFolderFiles = Directory.GetFiles(path);
                    _path = path;

                    folderStateHash = GetFilesHashes();
                    previosFolderStateHash = GetFilesHashes();
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

            previosFolderStateHash = folderStateHash;
            folderStateHash = GetFilesHashes();

        }

        public void GetChangesDic(Dictionary<string, string> firstDic, Dictionary<string, string> secondDic)
        {
            if (firstDic.Count > secondDic.Count)
                {
                var temp = firstDic;
                firstDic = secondDic;
                secondDic = temp;
                resultCompareHash = firstDic.Where(x => x.Value != secondDic[x.Key]).ToDictionary(x => x.Key, x => x.Value);
                }
  
            resultCompareHash = firstDic.Where(x => x.Value != secondDic[x.Key]).ToDictionary(x => x.Key, x => x.Value);

        }

        public void ResultCompareHash()
        {
            GetChangesDic(previosFolderStateHash, folderStateHash);
            if (resultCompareHash.Count != 0)
            {
                Console.WriteLine("File changed:");
                foreach (var key in resultCompareHash)
                {
                    Console.WriteLine(key.Key + " " + key.Value);
                }
            }
        }


        public void GetChanges(string[] firstFolder, string[] secondFolder)
        {
            resulCompare = firstFolder.Except(secondFolder).ToArray();            
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


        public void MonitoringThead()
        {
            for (;;)
            {
                GetFolderFiles(_path);
                ResulCompareAdd();
                ResulCompareDelete();
                ResultCompareHash();

                //Thread.Sleep(100);
                //Console.WriteLine("\n1 second\n");
                //ShowFilesHash(previosFolderState);
                //ShowFilesHash(folderState);
            }
          
        }





        public void Monitoring()
        {
            while (_isMonitoring)
            {
                GetFolderFiles(_path);
                ResulCompareAdd();
                ResulCompareDelete();
                ResultCompareHash();
                
                Thread.Sleep(10000);
                Console.WriteLine("\n10 second\n");
                //ShowFilesHash(previosFolderState);
                //ShowFilesHash(folderState);
                
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
        


        public Dictionary<string, string> GetFilesHashes()
        {
            var HashesFilesDictionary = new Dictionary<string, string>();
            foreach (string file in Directory.GetFiles(_path))
            {
                string hash = ComputeFilesMD5(file);
                HashesFilesDictionary.Add(file, hash);
            }
            return HashesFilesDictionary;
        }


        public void ShowFilesHash(Dictionary<string,string> _filesHash)
        {
            foreach (var fh in _filesHash)
            {
                Console.WriteLine(fh.Key + " " + fh.Value);
            }

        }
      

        public string ComputeFilesMD5(string path)
        {
            using (FileStream fs = File.OpenRead(path))
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] filebytes = new byte[fs.Length];
                fs.Read(filebytes, 0, (int)fs.Length);
                byte[] Sum = md5.ComputeHash(filebytes);
                string result = BitConverter.ToString(Sum).Replace("-", String.Empty);
                return result;
            }
        }





    }
}
