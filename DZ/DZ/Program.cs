using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.IO;

namespace DZ
{
    [ServiceContract]
    public interface IMyDiskInfo
    {
        [OperationContract]
        string FreeSpace(string path);
        [OperationContract]
        string TotalSpace(string path);
    }

    public class MyDiskInfo : IMyDiskInfo
    {
        public string FreeSpace(string path)
        {
            DriveInfo di = new DriveInfo(path);
            long free = di.TotalFreeSpace;

            return Convert.ToString(free);
        }

        public string TotalSpace(string path)
        {
            DriveInfo di = new DriveInfo(path);
            long total = di.TotalSize;

            return Convert.ToString(total);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(MyDiskInfo));
            sh.Open();
            Console.WriteLine("Press <ENTER> to return...\n");
            Console.ReadLine();
            sh.Close();
        }
    }
}
