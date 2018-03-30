using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Zadanie2
{
    public class Server
    {
        private TcpListener _tcpListener;
        private readonly string _serverName = "advanced-c-sharp";
        private bool isListening = true;
        private Thread _listeningThread;
        public string _servingPath { get;  set; }

        public Server(int port)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");

            _tcpListener = new TcpListener(IPAddress.Any, port);
            _listeningThread = new Thread(new ThreadStart(ListenForConnections));
            _listeningThread.Start();
        }

        private void ListenForConnections()
        {
            while (isListening)
            {
                try
                {
                    _tcpListener.Start();
                }
                catch(SocketException)
                {
                    this.Stop();
                }

                Socket tcpSocket = null;
                try
                {
                    tcpSocket = _tcpListener.AcceptSocket();
                }
                catch
                {
                    this.Stop();
                }
                if (tcpSocket.Connected)
                {
                    var thread = new Thread(new ThreadStart(delegate () {
                            var buffer = new Byte[tcpSocket.Available];
                            tcpSocket.Receive(buffer);

                            string bufferString = Encoding.ASCII.GetString(buffer);

                            var bufferValidator = new BufferValidator();

                            MemoryStream memoryStream = null;
                            if (!bufferValidator.Validate(bufferString))
                            {
                                memoryStream = GetResponseInternalError("<h1>500</h1> Buffer validation failed.");
                                tcpSocket.Send(memoryStream.GetBuffer());
                                tcpSocket.Close();
                            }

                            var pathParser = new PathParser(_servingPath, bufferString);

                            string body = null;
                            try
                            {
                                body = File.ReadAllText(pathParser.getPath());

                                memoryStream = FormatResponseBody(body);
                            }
                            catch(FileNotFoundException e)
                            {
                                body = "<h1>404</h1>" + e.Message;

                                memoryStream = GetResponseNotFound(body);
                            }
                            catch(Exception e)
                            {
                                body = "<h1>500</h1>" + e.Message;
                                memoryStream = GetResponseInternalError(body);
                            }

                        
                            tcpSocket.Send(memoryStream.GetBuffer());
                            tcpSocket.Close();
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

        private MemoryStream GetResponseNotFound(string body)
        {
            var memoryStream = new MemoryStream();
            var stream = new StreamWriter(memoryStream);
            stream.WriteLine("HTTP/1.1 404 Not Found");
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

        private MemoryStream GetResponseInternalError(string body)
        {
            var memoryStream = new MemoryStream();
            var stream = new StreamWriter(memoryStream);
            stream.WriteLine("HTTP/1.1 500 Internal Server Error");
            stream.WriteLine("Expires: -1");
            stream.WriteLine("Date: " + DateTime.Now);
            stream.WriteLine("Access-Control - Allow - Origin : *");
            stream.WriteLine("Content-Length: " + body.Length);
            stream.WriteLine(_serverName);
            stream.WriteLine("x - xss - protection : 1; mode = block");
            stream.WriteLine("Connection : close");
            stream.Write(stream.NewLine);
            stream.WriteLine(body);
            stream.Flush();

            return memoryStream;
        }

        public void Stop()
        {
            _tcpListener.Stop();
        }
               
    }
}