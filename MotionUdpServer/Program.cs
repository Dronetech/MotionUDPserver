using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MotionUdpServer
{
    class Program
    {
        static void Main(string[] args)
        {
                       
            byte[] data = new byte[1024];
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 6969);
            UdpClient newsock = new UdpClient(ipep);
            Console.WriteLine("Server started");

            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

            String s_received = "";
            String welcome = "";
            

            while (true)
            {

                Console.WriteLine("Waiting for a client...");
                data = newsock.Receive(ref sender);
                s_received = Encoding.ASCII.GetString(data, 0, data.Length);
                Console.WriteLine("Message received from {0}:", sender.ToString());
                Console.WriteLine(s_received);
                welcome = "received:";
                data = Encoding.ASCII.GetBytes(welcome + s_received);
                newsock.Send(data, data.Length, sender);

            }
        }
    }
}
