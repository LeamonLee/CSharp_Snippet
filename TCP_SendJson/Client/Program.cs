using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 9011);
            Console.WriteLine("server connected successfully...");
            
            string jsonData = JsonConvert.SerializeObject(new { name="Leamon", age=28});
            byte[] dataBytes = Encoding.Default.GetBytes(jsonData);

            socket.Send(dataBytes);
            Console.WriteLine("jsonData sent...");

            byte[] rcvBuffer = new byte[1024 * 4];
            int readBytes = socket.Receive(rcvBuffer);
            Console.WriteLine("data receviced...");
            Console.WriteLine($"socket.Available: {socket.Available}");

            MemoryStream memoryStream = new MemoryStream();
            while (readBytes > 0)
            {
                memoryStream.Write(rcvBuffer, 0, readBytes);
                Console.WriteLine($"socket.Available2: {socket.Available}");
                if (socket.Available > 0)
                {
                    readBytes = socket.Receive(rcvBuffer);
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("read...");
            byte[] totalBytes = memoryStream.ToArray();
            memoryStream.Close();

            string rcvData = Encoding.Default.GetString(totalBytes);
            
            Console.WriteLine(rcvData);
            Console.ReadKey();
        }
    }
}
