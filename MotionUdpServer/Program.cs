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
            UdpClient serverSocket = new UdpClient(new IPEndPoint(IPAddress.Any, 1001)); //socket em escuta
          
            Console.WriteLine("Server started");

            IPEndPoint udpCommsender = new IPEndPoint(IPAddress.Any, 0); //o ip de onde vem a informação serve só para mostrar de onde veio nesta aplicação

            String s_received = "";
            String welcome = "";
            

            while (true)
            {
                
                Console.WriteLine("Waiting for a client...");
                data = serverSocket.Receive(ref udpCommsender); //A escuta no porto 1001
                s_received = Encoding.ASCII.GetString(data, 0, data.Length); //passar os bytes para string da mensagem recebida
                Console.WriteLine("Message received from {0}:", udpCommsender.ToString()); //imprime de onde veio a mensagem
                Console.WriteLine(s_received); //imprime a mensagem
                welcome = "received:"; // começa a preparar a mensagem
                data = Encoding.ASCII.GetBytes(welcome + s_received); //Preparar mensagem de envio com um cabeçalho
                serverSocket.Send(data, data.Length, udpCommsender); //Envio no porto 1001

            }
        }
    }
}
