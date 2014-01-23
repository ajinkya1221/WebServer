using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyHttpWebServer
{
    public class PortListener
    {
        public int Port { get; set; }

        public void Start()
        {
            var tcpListener = new TcpListener(IPAddress.Any, Port);
            tcpListener.Start();
            while (true)
            {
                if (NetworkSocket.flag == true)
                {
                    break;                    
                }
                var socket = tcpListener.AcceptSocket();
                var socketProcessor = new SocketProcessor();
                socketProcessor.Handle(new NetworkSocket(socket));    
            }
            
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
