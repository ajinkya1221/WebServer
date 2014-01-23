using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyHttpWebServer
{
    public class NetworkSocket
    {
        public Socket TcpSocket { get; set; }
        private NetworkStream _networkStream;
        //private StreamReader _streamReader;

        public NetworkSocket(Socket socket)
        {
            TcpSocket = socket;
        }

        public byte[] GetRequest()
        {
            _networkStream = new NetworkStream(TcpSocket,true);
            
            //_streamReader = new StreamReader(_networkStream);
            //var buffer = new byte[16 * 1024];

            
            using (var ms = new MemoryStream())
            {
                //int read;
                //while ((read = _networkStream.Read(buffer, 0, buffer.Length)) > 0)
                //{
                //    ms.Write(buffer, 0, read);
                //}
                _networkStream.CopyTo(ms);
                byte[] buffer = ms.ToArray();
                return buffer;

            }
            
        }

        public static bool flag = false;

        public void WriteResponse(byte[] response)
        {
            flag = true;
            _networkStream.Write(response, 0, response.Length);
            _networkStream.Flush();
            _networkStream.Dispose();
        }
    }
}
