using System;
using System.Net;

namespace Zadanie2
{
    public class Server
    {
        private readonly HttpListener _httpListener = new HttpListener();

        public Server()
        {
            _httpListener.Prefixes.Add("http://+:8000/");
            _httpListener.Start();
            if (_httpListener.IsListening) Console.WriteLine("Server started.");

            var response = _httpListener.GetContext().Response;
                       
            response.Close();
        }
    }
}