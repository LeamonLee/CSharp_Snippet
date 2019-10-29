using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP_SendJson
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            EndPoint endPoint = new IPEndPoint(IPAddress.Any, 9011);
            socket.Bind(endPoint);
            socket.Listen(5);
            while (true)
            {
                Console.WriteLine("waiting for new connection...");
                Socket newSocket = socket.Accept();
                Console.WriteLine("new connection established...");

                MemoryStream memoryStream = new MemoryStream();
                byte[] buffer = new byte[1024];
                int readBytes = newSocket.Receive(buffer);
                Console.WriteLine($"socket.Available: {socket.Available}");

                while (readBytes > 0)
                {
                    memoryStream.Write(buffer, 0, readBytes);
                    Console.WriteLine($"socket.Available2: {socket.Available}");
                    if (socket.Available > 0)
                    {
                        readBytes = newSocket.Receive(buffer);
                    }
                    else
                    {
                        break;
                    }
                }
                Console.WriteLine("data received...");
                byte[] totalBytes = memoryStream.ToArray();
                memoryStream.Close();

                string readRawData = Encoding.Default.GetString(totalBytes);
                var readJsonData = JsonConvert.DeserializeObject<dynamic>(readRawData);
                dynamic readJsonData2 = JValue.Parse(readRawData);
                Console.WriteLine($"readRawData : {readRawData}, type: {readRawData.GetType()}");
                Console.WriteLine($"readJsonData: {readJsonData}");
                Console.WriteLine($"readJsonData2: {readJsonData2}");

                Console.WriteLine($"readJsonData : {readJsonData}");

                newSocket.Close();
                Console.WriteLine("data sent...");
            }

        }
    }
}
