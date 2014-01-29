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
            //bool flag2 = false;
            while (true)
            {
            
                Console.WriteLine("do you want to make request? (y/n)");
                string isMakeRequest = Console.ReadLine();
                if (isMakeRequest == "y" || isMakeRequest == "Y")
                {
              //      socket.Close();
                    //tcpListener.Stop();
                    //break;
                
                //if (tcpListener.Pending())
                //{
                    var socket = tcpListener.AcceptSocket();                    
                    var socketProcessor = new SocketProcessor();
                    socketProcessor.Handle(new NetworkSocket(socket));

                    socket.Disconnect(true);
                    socket.Close();
                    socket.Dispose();
                }
                else
                {
                    tcpListener.Stop();
                    break;
                }
                //}
               
            }
            
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
