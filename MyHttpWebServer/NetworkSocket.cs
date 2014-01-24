using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Contexts;
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
                byte[] buffer = new byte[16*1024];//ms.ToArray();
                _networkStream.ReadAsync(buffer,0,buffer.Length);
                
                return buffer;

            }
            
        }

        public static bool flag = false;
        //private Task<Socket> socket;

        public void WriteResponse(List<byte[]> response )
        {
            //flag = true;
            this._networkStream.WriteAsync(response[0], 0, response[0].Length);
            this._networkStream.WriteAsync(response[1], 0, response[1].Length);            
            
            _networkStream.Flush();
            _networkStream.Dispose();
        }
    }
}
