using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace Bai1
{
    class Program
    {
        static void Main(string[] args)
        {

            //bai1
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp);
                serverSocket.Bind(serverEndPoint);
     
                serverSocket.Listen(1000);
               
         
                Socket clientSocket = serverSocket.Accept();

                EndPoint clientEndPoint = clientSocket.RemoteEndPoint;
                Console.WriteLine(clientEndPoint.ToString());
              
            //bai 2
                byte[] buff;
                string hello = "Hello Client";
                buff = Encoding.ASCII.GetBytes(hello);
                clientSocket.Send(buff, 0, buff.Length, SocketFlags.None);
              
            //bai 5
                while (serverSocket.Connected==true)
                {
                    string str = Console.ReadLine();
                    buff = Encoding.ASCII.GetBytes(str);
                    serverSocket.Send(buff, 0, buff.Length, SocketFlags.None);
                    buff = new byte[1024];
                    int byteReceive = serverSocket.Receive(buff, 0, buff.Length, SocketFlags.None);
                    str = Encoding.ASCII.GetString(buff, 0, byteReceive);
                    Console.WriteLine(str);
                   //IV.1 bao client mat ket noi 
                    if (serverSocket.Connected == false)
                    System.Console.WriteLine("Client mat ket noi");
                    
                }
                Console.ReadLine();
        }
            
    }
}
