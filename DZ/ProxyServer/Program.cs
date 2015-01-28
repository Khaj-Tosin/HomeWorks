using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ProxyServer.ServiceReference1;

namespace ProxyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDiskInfoClient proxy = new MyDiskInfoClient();

            string free = proxy.FreeSpace("D:");
            string total = proxy.TotalSpace("D:");
            Console.WriteLine("Free space: " + free);
            Console.WriteLine("Total space: " + total + "\n\n\n");
        }
    }
}
