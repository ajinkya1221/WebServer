using System;
using System.Net;
using System.Net.Sockets;

namespace MyHttpWebServer
{
    public class PortListener
    {
        public int Port { get; set; }

        public void Start()
        {
            //Socket socket = null;
            var tcpListener = new TcpListener(IPAddress.Any, Port);
            tcpListener.Start();
            ServerRunner.Flag = false;
            while (true)
            {
                if (ServerRunner.Flag == true)
                {
              //      socket.Close();
                    tcpListener.Stop();
                    break;
                }
                if (tcpListener.Pending())
                {
                    Socket socket = tcpListener.AcceptSocket();                    
                    var socketProcessor = new SocketProcessor();
                    socketProcessor.Handle(new NetworkSocket(socket));                    
                }
                
                
                
            }
            
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
