using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Zadanie2
{
    public class Server
    {
        private readonly TcpListener _tcpListener = new TcpListener(IPAddress.Any, 8020);

        public Server()
        {
            while (true)
            {
                _tcpListener.Start();
                Console.WriteLine("Server started.");
                var tcpClient = _tcpListener.AcceptTcpClient();
                Console.WriteLine("Connected");

                var message = Encoding.ASCII.GetBytes("HTTP /1.1 200 OK");
                
                var stream = new System.IO.StreamWriter(tcpClient.GetStream());
                stream.Write("HTTP/1.1 200 OK");
                stream.Write(Environment.NewLine);
                stream.Write("Content-Type: text/plain; charset=UTF-8");
                stream.Write(Environment.NewLine);
                stream.Write("Content-Length: " + message.Length);
                stream.Write(Environment.NewLine);
                stream.Write(Environment.NewLine);
                stream.Write(message);
                stream.Flush();
                tcpClient.Close();
                _tcpListener.Stop();
                Console.WriteLine("Message sent.");
            }

            //var response = _tcpListener.GetContext().Response;
                       
            //response.Close();
        }
    }
}