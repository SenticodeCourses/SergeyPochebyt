using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SergCo.SystemMonitoring.FolderMonitoring;

namespace SergCo.SystemMonitoring.App
{
    class Program
    {
        static void Main(string[] args)
        {
            FolderMonitor FolderMon = new FolderMonitor();
            string path = @"D:\dev1";
            FolderMon.FolderInitialize(path);
            FolderMon._isMonitoring = true;
            FolderMon.Monitoring();
            
            Console.ReadLine();
        }
    }
}
