using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MotionUdpClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] data = new byte[1024];
            Console.WriteLine("Insert server IP address:");
            String IP = Console.ReadLine();
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 6970);
            UdpClient newsock = new UdpClient(ipep);
            data = Encoding.ASCII.GetBytes("Test Data");

            IPEndPoint server = new IPEndPoint(IPAddress.Parse(IP), 6969);
            newsock.Send(data, data.Length, server);

            data = newsock.Receive(ref server);
            Console.WriteLine("Data received:");
            Console.WriteLine(Encoding.ASCII.GetString(data));
            Console.ReadKey();

        }
    }
}
