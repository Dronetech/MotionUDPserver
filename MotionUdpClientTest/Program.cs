using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace MotionUdpClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] data = new byte[1024];
            Console.WriteLine("Insert server IP address:");
            String IP = Console.ReadLine();
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 1002);
            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(IP), 1001);
            IPEndPoint bufferAddress = new IPEndPoint(IPAddress.Any, 0);
            UdpClient clientSock = new UdpClient(ipep);
            data = Encoding.ASCII.GetBytes("Test Data");

            while(true)
            {
                clientSock.Send(data, data.Length, serverAddress);
                data = clientSock.Receive(ref bufferAddress);
                Console.WriteLine("Data received:");
                Console.WriteLine(Encoding.ASCII.GetString(data));
                Thread.Sleep(1000);
            }

          

        }
    }
}
