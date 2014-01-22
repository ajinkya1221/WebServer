using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyHttpWebServer
{
    public class NetworkSocket
    {
        public Socket TcpSocket { get; set; }
        public NetworkSocket(Socket socket)
        {
            TcpSocket = socket;
        }
    }
}
