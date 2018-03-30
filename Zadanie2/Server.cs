using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Zadanie2
{
    public class Server
    {
        private readonly TcpListener _tcpListener = new TcpListener(IPAddress.Any, 8020);
        private readonly string _serverName = "advanced-c-sharp";
        private bool isListening = true;

        public Server()
        {
            var thread = new Thread(new ThreadStart(ListenForConnections));
            thread.Start();
        }

        private void ListenForConnections()
        {
            while (isListening)
            {
                _tcpListener.Start();
                Console.WriteLine("Server started.");
                var tcpSocket = _tcpListener.AcceptSocket();
                if (tcpSocket.Connected)
                {
                    var thread = new Thread(new ThreadStart(delegate () {
                            Console.WriteLine("Connected." + tcpSocket.AddressFamily);

                            var buffer = new Byte[tcpSocket.Available];
                            tcpSocket.Receive(buffer);

                            Console.WriteLine(Encoding.ASCII.GetString(buffer));

                            var randomPicker = new HtmlRandomPicker();
                            var body = randomPicker.Pick();

                            var memoryStream = FormatResponseBody(body);

                            tcpSocket.Send(memoryStream.GetBuffer());
                            tcpSocket.Close();

                            Console.WriteLine("Disconnected.");
                        }));
                    thread.Start();
                }
            }
            _tcpListener.Stop();
        }

        private MemoryStream FormatResponseBody(string body)
        {
            var memoryStream = new MemoryStream();
            var stream = new StreamWriter(memoryStream);
            stream.WriteLine("HTTP/1.1 200 OK");
            stream.WriteLine("Expires: -1");
            stream.WriteLine("Date: " + DateTime.Now);
            stream.WriteLine("Access-Control - Allow - Origin : *");
            stream.WriteLine("Content-Type : text/html; charset=utf-8");
            stream.WriteLine("Content-Length: " + body.Length);
            stream.WriteLine(_serverName);
            stream.WriteLine("x - xss - protection : 1; mode = block");
            stream.WriteLine("Connection : close");
            stream.Write(stream.NewLine);
            stream.WriteLine(body);
            stream.Flush();

            return memoryStream;
        }
    }
}