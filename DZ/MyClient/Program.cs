using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace MyClient
{
    [ServiceContract]
    public interface IMyDiskInfo
    {
        [OperationContract]
        string FreeSpace(string path);
        [OperationContract]
        string TotalSpace(string path);
    }

    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IMyDiskInfo> factory = new ChannelFactory<IMyDiskInfo>(
                    new BasicHttpBinding(),
                    new EndpointAddress("http://localhost/MyDiskInfo/ep2"));
            IMyDiskInfo channel = factory.CreateChannel();

            string free = channel.FreeSpace("D:");
            string total = channel.TotalSpace("D:");
            Console.WriteLine("Free space: " + free);
            Console.WriteLine("Total space: " + total + "\n\n\n");
        }
    }
}
