using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Bai3
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Loopback, 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Dang ket noi voi server...");
            //bài 4
            try
            {
                serverSocket.Connect(serverEndPoint);
            }
            catch (SocketException ex)
            {
                Console.WriteLine("Khong the ket noi den server" + ex.ToString());
                Console.ReadLine();
                return;
            }
            //bài 6
            if (serverSocket.Connected)
            {

              Console.WriteLine("Ket noi thanh cong voi server ...");
                byte[] buff= new byte[1024];
                int byteReceive = serverSocket.Receive(buff, 0, buff.Length, SocketFlags.None);
                string str = Encoding.ASCII.GetString(buff, 0, byteReceive);
                Console.WriteLine(str);
                Console.ReadLine();
               

            }
           
            
        }
    }
}
