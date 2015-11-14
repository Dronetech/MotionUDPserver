using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MotionUdpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
                    
            byte[] data = new byte[1024];            
            UdpClient serverSocket = new UdpClient(new IPEndPoint(IPAddress.Any, 1000)); //socket em escuta
          
            Console.WriteLine("Server started");

            IPEndPoint udpCommsender = new IPEndPoint(IPAddress.Any, 0); //o ip de onde vem a informação serve só para mostrar de onde veio nesta aplicação

            String s_received = "";
            String welcome = "";
            

            while (true)
            {
                
                Console.WriteLine("Waiting for a client...");
                sw.Start();
                data = serverSocket.Receive(ref udpCommsender); //A escuta no porto 1000
                sw.Stop();
                s_received = Encoding.ASCII.GetString(data, 0, data.Length); //passar os bytes para string da mensagem recebida
                Console.WriteLine("Message received from {0} interval duration {1}:", udpCommsender.ToString(), sw.ElapsedMilliseconds); //imprime de onde veio a mensagem
                Console.WriteLine(s_received); //imprime a mensagem               
                //data = Encoding.ASCII.GetBytes(s_received); //Preparar mensagem de envio com um cabeçalho
                udpCommsender.Port = 1001;
                serverSocket.Send(data, data.Length, udpCommsender); //Envio no porto 1001
                sw.Reset();
            }
        }
    }
}
