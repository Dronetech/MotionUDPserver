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
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 1001); //Endpoint desta maquina
            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(IP), 1000); //Endpoint para o servidor
            IPEndPoint bufferAddress = new IPEndPoint(IPAddress.Any, 0); //Endpoint vazio so para servir de buffer
            UdpClient clientSock = new UdpClient(ipep); //Abrir o porto nesta maquina
            data = Encoding.ASCII.GetBytes("Test Data"); //criar os dados

            //Inicio do Loop
            while(true)
            {
                clientSock.Send(data, data.Length, serverAddress); //envia dados
                data = clientSock.Receive(ref bufferAddress); //espera pela resposta
                Console.WriteLine("Data received:");
                Console.WriteLine(Encoding.ASCII.GetString(data));
                Thread.Sleep(1000); //dorme
            }

          

        }

        public void SendUDP() {


        }
        public void ReceiveUDP() {


        }

    }
}
