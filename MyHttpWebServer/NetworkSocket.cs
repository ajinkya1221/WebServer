using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace MyHttpWebServer
{
    public class NetworkSocket
    {
        public Socket TcpSocket { get; set; }
        private NetworkStream _networkStream;
        
        public NetworkSocket(Socket socket)
        {
            TcpSocket = socket;
        }

        public byte[] GetRequest()
        {
            _networkStream = new NetworkStream(TcpSocket,true);

                var buffer = new byte[16*1024];
                _networkStream.ReadAsync(buffer,0,buffer.Length);
                
                return buffer;
        }

        
        
        public void WriteResponse(List<byte[]> response )
        {                    
            this._networkStream.WriteAsync(response[0], 0, response[0].Length);
            this._networkStream.WriteAsync(response[1], 0, response[1].Length);            
            
            _networkStream.Flush();
            //_networkStream.Close();
            //_networkStream.Dispose();
            //TcpSocket.Close();
            //TcpSocket.Dispose();
            
            //Flag = true;
        }
    }
}
