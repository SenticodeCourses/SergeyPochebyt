using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SergCo.SystemMonitoring.FolderMonitoring;
using System.Threading;

namespace SergCo.SystemMonitoring.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //Отслеживает удаление и создание файлов
            //Отслеживает изменения файлов

            FolderMonitor FolderMon = new FolderMonitor();
            string path = @"D:\dev1";
            FolderMon.FolderInitialize(path);
            FolderMon._isMonitoring = true;

            
          //  FolderMon.Monitoring();


            Thread thread = new Thread(FolderMon.MonitoringThead);
            thread.Start();
            thread.Priority = ThreadPriority.Normal;

            
            Console.ReadLine();
        }
    }
}
